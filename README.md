# ElsaWorkflowV3

ServerAuth : Username: admin
            Password: password

To Execute Wf 
POST -- https://localhost:5001/elsa/api/workflow-definitions/a88f6a2cab5442a18841ba11dc5c563d/execute
  This call needs authorization -- Use Bearer Token. APIKey doesnt work

To get Bearer Token
POST -- https://localhost:5001/elsa/api/identity/login
        body: {
              "username": "admin",
              "password": "password"
              }
