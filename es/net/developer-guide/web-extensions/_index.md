---
title: Nuevo Sistema de Exportación HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /es/net/web-extensions/
keywords: "Exportar PowerPoint HTML, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Exportación HTML de PowerPoint en C# o .NET"
---


## Introducción

* En las versiones antiguas de la API de Aspose.Slides, cuando exportabas PowerPoint a HTML, el HTML resultante se representaba como un marcado SVG combinado con HTML. Cada diapositiva se exportaba como un contenedor SVG.
* En las nuevas versiones de Aspose.Slides, cuando utilizas el sistema WebExtensions para exportar presentaciones de PowerPoint a HTML, puedes personalizar los ajustes de exportación HTML para obtener los mejores resultados.

Usando el nuevo sistema WebExtensions, puedes exportar una presentación completa a HTML con un conjunto de clases CSS y animaciones JavaScript (sin SVG). El nuevo sistema de exportación también proporciona un número ilimitado de opciones y métodos que definen el proceso de exportación.

El nuevo sistema de WebExtensions se utiliza para generar HTML a partir de presentaciones en estos casos y eventos:

* al usar estilos CSS personalizados o animaciones; sobrescribiendo el marcado para ciertos tipos de formas.
* al sobrescribir la estructura del documento, por ejemplo, utilizando navegación personalizada entre páginas.
* al guardar archivos .html, .css, .js en carpetas con una jerarquía personalizada, incluyendo tipos de archivos específicos en diferentes carpetas. Por ejemplo, exportando diapositivas a una carpeta basada en el nombre de la sección.
* al guardar archivos CSS y JS en carpetas separadas por defecto y luego añadirlos a un archivo HTML. Las imágenes y las fuentes incrustadas también se guardan en archivos separados. Sin embargo, pueden ser incrustadas en un archivo HTML (en formato base64). Puedes guardar algunas partes de los recursos en los archivos y incrustar otros recursos en HTML como base64.

Puedes revisar ejemplos de PowerPoint a HTML en el [proyecto Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) en GitHub. Este proyecto contiene 2 partes: **Examples\SinglePageApp** y **Examples\MultiPageApp**. Los otros ejemplos utilizados en este artículo también se pueden encontrar en el repositorio de GitHub.

### **Plantillas**

Para extender aún más las capacidades de la exportación HTML, te recomendamos que utilices el sistema de plantillas ASP.NET Razor. La instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) se puede usar junto con un conjunto de plantillas para obtener un documento HTML como resultado de la exportación.

**Demostración**

En este ejemplo, exportaremos texto de una presentación a HTML. Primero, vamos a crear la plantilla:

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
Esta plantilla se guarda en el disco como "shape-template-hello-world.html", que se utilizará en el siguiente paso.

En esta plantilla, estamos iterando los marcos de texto en las formas de la presentación para mostrar el texto. Generemos el archivo HTML utilizando WebDocument y luego exportemos la Presentación en el archivo:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hola Mundo";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Tenemos la intención de usar el motor de plantillas Razor. Otros motores de plantillas se pueden usar implementando ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Otros ahorradores de resultado se pueden usar implementando la interfaz IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // añadir documento "entrada" - qué fuente se usará para generar el documento HTML
    document.Input
        .AddTemplate<Presentation>( // la plantilla tendrá Presentation como objeto "modelo" (Model.Object) 
        "index", // clave de plantilla - necesaria por el motor de plantillas para hacer coincidir un objeto (Presentation) con la plantilla cargada desde el disco ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // plantilla que creamos anteriormente
                
    // añadir salida - cómo se verá el documento HTML resultante cuando se exporte al disco
    document.Output.Add(
        "hola-mundo.html", // ruta de archivo de salida
        "index", // clave de plantilla que se utilizará para este archivo (la configuramos en una declaración anterior)  
        pres); // una instancia real de Model.Object 
                
    document.Save();
}
```

Por ejemplo, queremos añadir estilos CSS al resultado de la exportación para cambiar el color del texto a rojo. Vamos a añadir la plantilla CSS:

``` css
.text {
    color: red;
}
```

Ahora, lo añadimos a la entrada y salida:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hola Mundo";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hola-mundo.html", "index", pres); 
    document.Output.Add("hola-mundo.css", "styles", pres);
                
    document.Save();
}
```

Vamos a añadir la referencia a los estilos en la plantilla y la clase "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hola-mundo.css" />
</head>
...
</html>
```

### **Plantillas Predeterminadas**

WebExtensions proporciona 2 conjuntos de plantillas básicas para exportar presentaciones a HTML:
* Una sola página: todo el contenido de la presentación se exporta en un solo archivo HTML. Todos los demás recursos (imágenes, fuentes, estilos, etc.) se exportan en archivos separados.
* Múltiples páginas: cada diapositiva de la presentación se exporta en un archivo HTML individual. La lógica predeterminada para exportar recursos es la misma que en una sola página.

La clase `PresentationExtensions` se puede usar para simplificar el proceso de exportación de presentaciones utilizando plantillas. La clase `PresentationExtensions` contiene un conjunto de métodos de extensión para la clase Presentation. Para exportar una presentación en una sola página, simplemente incluye el espacio de nombres Aspose.Slides.WebExtensions y llama a dos métodos. El primer método, `ToSinglePageWebDocument`, crea una instancia de `WebDocument`. El segundo método guarda el documento HTML:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

El método ToSinglePageWebDocument puede tomar dos parámetros: carpeta de plantillas y carpeta de exportación.

Para exportar la presentación a múltiples páginas, usa el método ToMultiPageWebDocument con los mismos parámetros:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"multi-page-output");
    document.Save();
}
```

En WebExtensions, cada plantilla utilizada para la generación de marcado está vinculada a una clave. La clave se puede usar en plantillas. Por ejemplo, en la directiva @Include, puedes insertar una plantilla determinada en otra por la clave.

Podemos demostrar el procedimiento en el ejemplo del uso de la plantilla de porciones de texto dentro de la plantilla de párrafo. Puedes encontrar el ejemplo en el proyecto Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Para dibujar las porciones en un párrafo, las iteramos usando la directiva @foreach del Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
    @Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

La porción tiene su propia plantilla [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) y se genera un modelo para ella. Ese modelo se añadirá a la plantilla de salida paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Para cada tipo de forma, usamos una plantilla personalizada que se añade al conjunto general de plantillas del proyecto Aspose.Slides.WebExtensions. Las plantillas se combinan en los métodos ToSinglePageWebDocument y ToMultiPageWebDocument para proporcionar un resultado final. Estas son las plantillas comunes utilizadas tanto en una sola página como en varias páginas:

-templates
+-common
  ¦ +-scripts: scripts de javascript para animaciones de transición de diapositivas, por ejemplo.
  ¦ +-styles: estilos CSS comunes.
  +-multi-page: plantilla de índice, menú, diapositivas para la salida de múltiples páginas.
  +-single-page: plantilla de índice, diapositivas para la salida de una sola página.

Puedes averiguar cómo se vincula la parte común a todas las plantillas en el método `PresentationExtensions.AddCommonInputOutput` [aquí](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Personalización de Plantillas Predeterminadas**

Puedes modificar cualquier elemento en la plantilla del modelo común. Por ejemplo, puedes decidir cambiar los estilos de formato de la tabla, pero deseas que todos los demás estilos de la página única permanezcan sin cambios.

Por defecto, se utiliza Templates\common\table.html, y la tabla tiene la misma apariencia que la tabla en PowerPoint. Vamos a cambiar el formato de la tabla utilizando estilos CSS personalizados:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Podemos crear la misma estructura de plantillas de entrada y archivos de salida (como se genera) al llamar al método `PresentationExtensions.ToSinglePageWebDocument`. Añadamos el método `ExportCustomTableStyles_AddCommonStructure` para ello. La diferencia entre este método y el método `ToSinglePageWebDocument` es que no necesitamos añadir la plantilla estándar para la tabla y la página de índice principal (será reemplazada para incluir la referencia a los estilos de la tabla personalizada):

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

Vamos a añadir una plantilla personalizada en su lugar:

``` csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "estilos-tabla-personalizados";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // configurar valores globales del documento
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // añadir estructura común (excepto plantilla de tabla)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // añadir plantilla de tabla personalizada
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // añadir estilos de tabla personalizados
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // añadir índice personalizado - es solo una copia del estándar "index.html", pero incluye una referencia a "table-custom-style.css"
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

**Nota** que la plantilla de tabla personalizada se añadió con la misma clave “table” que la tabla estándar. Así, puedes reemplazar una plantilla predeterminada sin reescribirla. También puedes usar las plantillas de la estructura predeterminada con las mismas claves. Por ejemplo, puedes usar una plantilla de párrafo estándar en la plantilla de tabla; también puedes reemplazarla con la clave.
También puedes usar index.html para incluir la referencia a los estilos CSS personalizados de la tabla en ella: 

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

## **Crear Proyecto desde Cero: Transiciones de Diapositivas Animadas**

WebExtensions te permite exportar presentaciones con transiciones animadas de diapositivas; solo necesitas establecer la propiedad `AnimateTransitions` en `WebDocumentOptions` a `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... otras opciones
    AnimateTransitions = true
};
```

Crearemos un nuevo proyecto que utilice Aspose.Slides y Aspose.Slides.WebExtensions para crear un visor HTML para PDF con transiciones de página animadas suaves. Aquí, necesitamos usar la función de importación de PDF de Aspose.Slides.

Creemos un proyecto PdfToPresentationToHtml y agreguemos el paquete NuGet Aspose.Slides.WebExtensions (el paquete Aspose.Slides también se añadirá como dependencia):
![Paquete NuGet](screen.png)

Comenzamos importando el documento PDF, que será animado y exportado a una presentación HTML:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Ahora, podemos establecer las transiciones animadas de las diapositivas (cada diapositiva es una página importada del PDF). Usamos 9 diapositivas en el documento PDF de muestra. Vamos a añadir transiciones de diapositivas en cada una de ellas (demostración al ver HTML):

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

Finalmente, exportemos a HTML usando `WebDocument` con la propiedad `AnimateTransitions` establecida en `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "pdf-animado");
document.Save();
```

Código fuente completo de ejemplo:
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

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "pdf-animado");
    document.Save();
}
```

Eso es todo lo que necesitas para crear HTML con las transiciones de página animadas generadas a partir del documento PDF.

* [Descargar archivo HTML de muestra](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Descargar proyecto de muestra](/slides/es/net/web-extensions/sample.zip).