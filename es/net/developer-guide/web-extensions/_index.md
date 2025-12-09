---
title: Nuevo sistema de exportación HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /es/net/web-extensions/
keywords:
- extensión web
- motor de plantillas
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- exportar diapositiva
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint a HTML
- OpenDocument a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- .NET
- C#
- Aspose.Slides
description: "Exporta presentaciones a HTML con plantillas, CSS y JS—sin SVG. Aprende sobre salida de una sola página o multipágina, control de recursos y personalización para PPT, PPTX y ODP."
---

## Introducción

* En versiones antiguas de la API de Aspose.Slides, cuando exportas PowerPoint a HTML, el HTML resultante se representa como un marcado SVG combinado con HTML. Cada diapositiva se exporta como un contenedor SVG. 
* En las versiones nuevas de Aspose.Slides, cuando utilizas el sistema WebExtensions para exportar presentaciones de PowerPoint a HTML, puedes personalizar la configuración de exportación HTML para obtener los mejores resultados. 

Usando el nuevo sistema WebExtensions, puedes exportar una presentación completa a HTML con un conjunto de clases CSS y animaciones JavaScript (sin SVG). El nuevo sistema de exportación también ofrece un número ilimitado de opciones y métodos que definen el proceso de exportación. 

El sistema WebExtensions se usa para generar HTML a partir de presentaciones en los siguientes casos y eventos:

* al usar estilos CSS o animaciones personalizados; sobrescribiendo el marcado de ciertos tipos de formas.  
* al sobrescribir la estructura del documento, por ejemplo, usando navegación personalizada entre páginas.  
* al guardar archivos .html, .css, .js en carpetas con una jerarquía personalizada, incluyendo tipos de archivo específicos en diferentes carpetas. Por ejemplo, exportar diapositivas a una carpeta basada en el nombre de la sección.  
* al guardar archivos CSS y JS en carpetas separadas por defecto y luego añadirlos a un archivo HTML. Las imágenes y fuentes incrustadas también se guardan en archivos separados. Sin embargo, pueden incrustarse en un archivo HTML (en formato base64). Puedes guardar algunas partes de los recursos en archivos y incrustar otros recursos en HTML como base64.  

Puedes consultar los ejemplos de PowerPoint a HTML en el proyecto [Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) en GitHub. Este proyecto contiene 2 partes: **Examples\SinglePageApp** y **Examples\MultiPageApp**. Los demás ejemplos utilizados en este artículo también se encuentran en el repositorio de GitHub.  

### **Plantillas**

Para ampliar aún más las capacidades de exportación HTML, te recomendamos usar el sistema de plantillas Razor de ASP.NET. La instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) puede usarse junto con un conjunto de plantillas para obtener un documento HTML como resultado de la exportación.  

**Demostración**

En este ejemplo, exportaremos texto de una presentación a HTML. Primero, creemos la plantilla:
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

Esta plantilla se guarda en disco como "shape-template-hello-world.html", que se usará en el paso siguiente.  

En esta plantilla, iteramos los marcos de texto en las formas de la presentación para mostrar el texto. Generemos el archivo HTML usando WebDocument y luego exportemos la Presentation al archivo: 
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Tenemos la intención de usar el motor de plantillas Razor. Otros motores de plantillas pueden usarse implementando ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Otros guardadores de resultados pueden usarse implementando la interfaz IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // agregar documento "input" - qué origen se usará para generar el documento HTML
    document.Input
        .AddTemplate<Presentation>( // la plantilla tendrá Presentation como un objeto "model" (Model.Object) 
        "index", // clave de plantilla - necesaria por el motor de plantillas para asociar un objeto (Presentation) con la plantilla cargada del disco ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // plantilla que creamos antes
                
    // agregar salida - cómo será el documento HTML resultante cuando se exporte al disco
    document.Output.Add(
        "hello-world.html", // ruta del archivo de salida
        "index", // clave de plantilla que se usará para este archivo (la establecimos en una instrucción anterior)  
        pres); // una instancia real de Model.Object 
                
    document.Save();
}
```


Por ejemplo, queremos añadir estilos CSS al resultado de la exportación para cambiar el color del texto a rojo. Añadamos la plantilla CSS:
``` css
.text {
    color: red;
}
```


Ahora la insertamos en la entrada y salida:
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


Añadamos la referencia a los estilos en la plantilla y la clase "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **Plantillas predeterminadas**

WebExtensions proporciona 2 conjuntos de plantillas básicas para exportar presentaciones a HTML:
* Página única: todo el contenido de la presentación se exporta a un solo archivo HTML. Todos los demás recursos (imágenes, fuentes, estilos, etc.) se exportan a archivos separados.  
* Multipágina: cada diapositiva de la presentación se exporta a un archivo HTML individual. La lógica predeterminada para exportar recursos es la misma que en una página única.  

La clase `PresentationExtensions` puede usarse para simplificar el proceso de exportación de presentaciones usando plantillas. La clase `PresentationExtensions` contiene un conjunto de métodos de extensión para la clase Presentation. Para exportar una presentación a una página única, solo incluye el espacio de nombres Aspose.Slides.WebExtensions y llama a dos métodos. El primer método, `ToSinglePageWebDocument`, crea una instancia de `WebDocument`. El segundo método guarda el documento HTML: 
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


El método ToSinglePageWebDocument puede recibir dos parámetros: carpeta de plantillas y carpeta de exportación.  

Para exportar la presentación a múltiples páginas, usa el método ToMultiPageWebDocument con los mismos parámetros:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


En WebExtensions, cada plantilla usada para la generación de marcado está asociada a una clave. La clave puede usarse en las plantillas. Por ejemplo, en la directiva @Include, puedes insertar una plantilla determinada en otra mediante la clave.  

Podemos demostrar el procedimiento en el ejemplo de uso de la plantilla de porción de texto dentro de la plantilla de párrafo. Puedes encontrar el ejemplo en el proyecto Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Para dibujar las porciones en un párrafo, las iteramos usando la directiva @foreach del motor Razor:
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


La porción tiene su propia plantilla [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) y se genera un modelo para ella. Ese modelo se añadirá al template de salida paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


Para cada tipo de forma, usamos una plantilla personalizada, que se agrega al conjunto general de plantillas del proyecto Aspose.Slides.WebExtensions. Las plantillas se combinan en los métodos ToSinglePageWebDocument y ToMultiPageWebDocument para proporcionar un resultado final. Estas son plantillas comunes usadas tanto en la página única como en la multipágina:

-templates  
+-common  
  ¦ +-scripts: scripts JavaScript para animaciones de transición de diapositivas, como instancia.  
  ¦ +-styles: estilos CSS comunes.  
  +-multi-page: índices, menús, plantillas de diapositivas para la salida multipágina.  
  +-single-page: índices, plantillas de diapositivas para la salida de página única.  

Puedes descubrir cómo se enlaza la parte común para todas las plantillas en el método `PresentationExtensions.AddCommonInputOutput` [aquí](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **Personalización de la plantilla predeterminada**

Puedes modificar cualquier elemento en la plantilla del modelo común. Por ejemplo, podrías decidir cambiar los estilos de formato de tabla pero mantener sin cambios los demás estilos de la página única.  

Por defecto, se usa Templates\common\table.html, y la tabla tiene el mismo aspecto que la tabla en PowerPoint. Cambiemos el formato de tabla usando estilos CSS personalizados:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


Podemos crear la misma estructura de plantillas de entrada y archivos de salida (tal como se genera) al llamar al método `PresentationExtensions.ToSinglePageWebDocument`. Añadamos el método `ExportCustomTableStyles_AddCommonStructure` para eso. La diferencia entre este método y `ToSinglePageWebDocument`—no necesitamos añadir la plantilla estándar para la tabla y la página de índice principal (se sustituirá para incluir la referencia a los estilos de tabla personalizados):
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


Añadamos una plantilla personalizada en su lugar:
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

    // configurar valores globales del documento
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // agregar estructura común (excepto la plantilla de tabla)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // agregar plantilla de tabla personalizada
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // agregar estilos de tabla personalizados
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // agregar índice personalizado - es solo una copia del "index.html" estándar, pero incluye una referencia a "table-custom-style.css"
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


**Nota** que la plantilla de tabla personalizada se añadió con la misma clave “table” que la tabla estándar. Por lo tanto, puedes reemplazar una plantilla predeterminada concreta sin reescribirla. También puedes usar las plantillas de la estructura predeterminada con las mismas claves. Por ejemplo, puedes usar una plantilla de párrafo estándar en la plantilla de tabla; también puedes reemplazarla con la clave.  
También puedes usar index.html para incluir la referencia a los estilos CSS de tabla personalizada en él: 
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


## **Crear proyecto desde cero: transiciones de diapositivas animadas**

WebExtensions permite exportar presentaciones con transiciones de diapositivas animadas—solo necesitas establecer la propiedad `AnimateTransitions` en `WebDocumentOptions` a `true`:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... otras opciones
    AnimateTransitions = true
};
```


Creemos un nuevo proyecto que use Aspose.Slides y Aspose.Slides.WebExtensions para crear un visor HTML para PDF con transiciones de página suaves animadas. Aquí, necesitaremos usar la función de importación de PDF de Aspose.Slides.  

Creemos un proyecto PdfToPresentationToHtml y añadamos el paquete NuGet Aspose.Slides.WebExtensions (el paquete Aspose.Slides también se añadirá como dependencia):
![NuGet Package](screen.png)

Comenzamos importando el documento PDF, que será animado y exportado a una presentación HTML:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


Ahora, podemos configurar las transiciones de diapositivas animadas (cada diapositiva es la página PDF importada). Usamos 9 diapositivas en el documento PDF de ejemplo. Añadamos transiciones de diapositiva a cada una de ellas (demostración al ver el HTML):
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


Finalmente, exportémoslo a HTML usando `WebDocument` con la propiedad `AnimateTransitions` establecida en `true`:
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


Ejemplo completo del código fuente:
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


Eso es todo lo que necesitas para crear HTML con transiciones de página animadas generadas a partir del documento PDF.  

* [Descargar archivo HTML de muestra](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [Descargar proyecto de muestra](/slides/es/net/web-extensions/sample.zip).