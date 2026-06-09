---
title: Novo Sistema de Exportação HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /pt/net/web-extensions/
keywords:
- extensão web
- motor de modelos
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- exportar slide
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint para HTML
- OpenDocument para HTML
- apresentação para HTML
- slide para HTML
- PPT para HTML
- PPTX para HTML
- ODP para HTML
- .NET
- C#
- Aspose.Slides
description: "Exporte apresentações para HTML com modelos, CSS e JS—sem SVG. Aprenda a gerar saída de página única ou múltiplas páginas, controle de recursos e personalização para PPT, PPTX e ODP."
---
## **Introdução**

* Em versões antigas da API Aspose.Slides, ao exportar PowerPoint para HTML, o HTML resultante era representado como marcação SVG combinada com HTML. Cada slide era exportado como um contêiner SVG. 
* Nas versões mais recentes do Aspose.Slides, ao usar o sistema WebExtensions para exportar apresentações PowerPoint para HTML, você pode personalizar as configurações de exportação HTML para obter os melhores resultados. 

Usando o novo sistema WebExtensions, você pode exportar uma apresentação inteira para HTML com um conjunto de classes CSS e animações JavaScript (sem SVG). O novo sistema de exportação também fornece um número ilimitado de opções e métodos que definem o processo de exportação. 

O sistema WebExtensions é usado para gerar HTML a partir de apresentações nesses casos e eventos:

* ao usar estilos CSS ou animações personalizados; sobrescrevendo a marcação para determinados tipos de formas.  
* ao sobrescrever a estrutura do documento, por exemplo, usando navegação personalizada entre páginas. 
* ao salvar arquivos .html, .css, .js em pastas com hierarquia personalizada, incluindo tipos de arquivo específicos em pastas diferentes. Por exemplo, exportar slides para uma pasta baseada no nome da seção. 
* ao salvar arquivos CSS e JS em pastas separadas por padrão e então adicioná‑los a um arquivo HTML. Imagens e fontes incorporadas também são salvas em arquivos separados. Contudo, eles podem ser incorporados em um arquivo HTML (em formato base64). Você pode salvar algumas partes dos recursos nos arquivos e incorporar outros recursos no HTML como base64. 

Você pode conferir exemplos de PowerPoint para HTML no [projeto Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) no GitHub. Este projeto contém 2 partes: **Examples\SinglePageApp** e **Examples\MultiPageApp**. Os demais exemplos usados neste artigo também podem ser encontrados no repositório do GitHub. 

### **Modelos**

Para expandir ainda mais as capacidades de exportação HTML, recomendamos o uso do sistema de modelos Razor do ASP.NET. A instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) pode ser usada juntamente com um conjunto de modelos para obter um documento HTML como resultado da exportação. 

**Demonstração**

Neste exemplo, exportaremos texto de uma apresentação para HTML. Primeiro, vamos criar o modelo:

``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```
Este modelo é salvo no disco como "shape-template-hello-world.html", que será usado na próxima etapa. 

Neste modelo, iteramos quadros de texto nas formas da apresentação para exibir o texto. Vamos gerar o arquivo HTML usando WebDocument e então exportar a Presentation para o arquivo: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Pretendemos usar o motor de templates Razor. Outros motores de templates podem ser usados implementando ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Outros salvadores de resultado podem ser usados implementando a interface IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // adicionar documento "input" - qual fonte será usada para gerar o documento HTML
    document.Input
        .AddTemplate<Presentation>( // o template terá Presentation como objeto "model" (Model.Object) 
        "index", // chave do template - necessária ao motor de template para associar um objeto (Presentation) ao template carregado do disco ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // template que criamos anteriormente
                
    // adicionar saída - como o documento HTML resultante aparecerá quando for exportado para o disco
    document.Output.Add(
        "hello-world.html", // caminho do arquivo de saída
        "index", // chave do template que será usada para este arquivo (definimos em uma instrução anterior)  
        pres); // uma instância real de Model.Object 
                
    document.Save();
}
```

Por exemplo, queremos adicionar estilos CSS ao resultado da exportação para mudar a cor do texto para vermelho. Vamos adicionar o modelo CSS: 

``` css
.text {
    color: red;
}
```

Agora, adicionamos ao input e output: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```

Vamos acrescentar a referência aos estilos no modelo e na classe "text": 
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Modelos Padrão**

WebExtensions fornece 2 conjuntos de modelos básicos para exportar apresentações para HTML:
* Página única: todo o conteúdo da apresentação é exportado para um único arquivo HTML. Todos os demais recursos (imagens, fontes, estilos, etc.) são exportados para arquivos separados. 
* Múltiplas páginas: cada slide da apresentação é exportado para um arquivo HTML individual. A lógica padrão para exportar recursos é a mesma de uma página única. 

A classe `PresentationExtensions` pode ser usada para simplificar o processo de exportação da apresentação usando modelos. A classe `PresentationExtensions` contém um conjunto de métodos de extensão para a classe Presentation. Para exportar uma apresentação para uma página única, basta incluir o namespace Aspose.Slides.WebExtensions e chamar dois métodos. O primeiro método, `ToSinglePageWebDocument`, cria uma instância `WebDocument`. O segundo método salva o documento HTML: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

O método ToSinglePageWebDocument pode receber dois parâmetros: pasta de modelos e pasta de exportação. 

Para exportar a apresentação para múltiplas páginas, use o método ToMultiPageWebDocument com os mesmos parâmetros: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

No WebExtensions, cada modelo usado para geração de marcação está vinculado a uma chave. A chave pode ser usada nos modelos. Por exemplo, na diretiva @Include, você pode inserir um determinado modelo em outro pelo nome da chave. 

Podemos demonstrar o procedimento no exemplo de uso do modelo de porção de texto dentro do modelo de parágrafo. Você pode encontrar o exemplo no projeto Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Para desenhar as porções em um parágrafo, iteramos elas usando a diretiva @foreach do Razor Engine: 

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

A porção tem seu próprio modelo [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) e um modelo é gerado para ela. Esse modelo será adicionado ao modelo de saída paragraph.html: 
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Para cada tipo de forma, usamos um modelo personalizado, que é adicionado ao conjunto geral de modelos do projeto Aspose.Slides.WebExtensions. Os modelos são combinados nos métodos ToSinglePageWebDocument e ToMultiPageWebDocument para fornecer o resultado final. Estes são os modelos comuns usados tanto em página única quanto em múltiplas páginas:

- templates  
+-common  
  ¦ +-scripts: scripts javascript para animações de transição de slides, como exemplo.  
  ¦ +-styles: estilos CSS comuns.  
  +-multi-page: index, menu, slide templates para a saída de múltiplas páginas.  
  +-single-page: index, slide templates para a saída de página única.  

Você pode descobrir como a parte comum é vinculada a todos os modelos no método `PresentationExtensions.AddCommonInputOutput` [aqui](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs). 

### **Customização de Modelo Padrão**

Você pode modificar qualquer elemento no modelo do modelo comum. Por exemplo, pode decidir alterar os estilos de formatação de tabelas, mas manter todos os outros estilos da página única inalterados. 

Por padrão, Templates\common\table.html é usado, e a tabela tem a mesma aparência da tabela no PowerPoint. Vamos mudar a formatação da tabela usando estilos CSS personalizados: 
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Podemos criar a mesma estrutura de modelos de entrada e arquivos de saída (conforme é gerado) ao chamar o método `PresentationExtensions.ToSinglePageWebDocument`. Vamos adicionar o método `ExportCustomTableStyles_AddCommonStructure` para isso. A diferença entre este método e o método `ToSinglePageWebDocument` — não precisamos adicionar o modelo padrão para a tabela e a página de índice principal (ele será substituído para incluir a referência aos estilos de tabela personalizados): 

``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```

Vamos acrescentar um modelo personalizado em vez disso: 

``` csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // configurar valores globais do documento
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // adicionar estrutura comum (exceto o modelo de tabela)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // adicionar modelo de tabela personalizado
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // adicionar estilos de tabela personalizados
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // adicionar índice personalizado - é apenas uma cópia do "index.html" padrão, mas inclui uma referência ao "table-custom-style.css"
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
	{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```

**Nota** que o modelo de tabela personalizado foi adicionado com a mesma chave “table” do modelo padrão. Assim, você pode substituir um determinado modelo padrão sem reescrevê‑lo. Você também pode usar os modelos da estrutura padrão com as mesmas chaves. Por exemplo, pode usar um modelo de parágrafo padrão no modelo de tabela; também pode substituí‑lo pela chave. 
Você pode ainda usar index.html para incluir a referência aos estilos CSS personalizados da tabela: 

``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```

## **Criar um Projeto do Zero: Transições de Slides Animadas**

WebExtensions permite exportar apresentações com transições de slides animadas — basta definir a propriedade `AnimateTransitions` em `WebDocumentOptions` como `true`: 

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... outras opções
    AnimateTransitions = true
};
```

Vamos criar um novo projeto que usa Aspose.Slides e Aspose.Slides.WebExtensions para criar um visualizador HTML para PDF com transições de página suaves animadas. Aqui, precisamos usar o recurso de importação de PDF do Aspose.Slides. 

Vamos criar um projeto PdfToPresentationToHtml e adicionar o pacote NuGet Aspose.Slides.WebExtensions (o pacote Aspose.Slides também será adicionado como dependência):
![NuGet Package](screen.png)

Começamos importando o documento PDF, que será animado e exportado para uma apresentação HTML: 

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Agora, podemos configurar as transições de slide animadas (cada slide é a página PDF importada). Usamos 9 slides no documento PDF de exemplo. Vamos adicionar transições de slide a cada um deles (demonstração ao visualizar o HTML): 

``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```

Por fim, vamos exportá‑lo para HTML usando `WebDocument` com a propriedade `AnimateTransitions` definida como `true`: 

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```

Exemplo de código completo:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```

Isso é tudo que você precisa para criar HTML com transições de página animadas geradas a partir do documento PDF. 

* [Baixar arquivo HTML de exemplo](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples). 
* [Baixar projeto de exemplo](/slides/pt/net/web-extensions/sample.zip).