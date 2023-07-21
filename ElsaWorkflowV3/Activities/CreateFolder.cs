using Elsa.Extensions;
using Elsa.Workflows.Core.Models;

namespace ElsaWorkflowV3.Activities
{
    public class CreateFolder : CodeActivity<string>
    {
        
        public Input<string> Path { get; set; } = default!;

        public Input<string> FolderName { get; set; } = default!;

        protected override void Execute(ActivityExecutionContext context)
        {
            try
            {
                var path = Path.Get(context);
                var folderName = FolderName.Get(context);

                string pathAux = System.IO.Path.Combine(path, folderName);
                Directory.CreateDirectory(pathAux);
                //PathOfCreatedFolder = pathAux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}