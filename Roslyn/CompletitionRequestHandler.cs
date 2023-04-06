﻿using RoslynCat.Interface;

namespace RoslynCat.Roslyn
{
    public class CompletitionRequestHandler
    {
        public async static Task<IResponse> Handle(IRequest request) {
            var workspace = CompletionWorkspace.Create(request.Usings);
            var document = await workspace.CreateDocument(request.SourceCode);
            return await document.GetResult(request.Type,request.Position,CancellationToken.None);
        }
    }
}