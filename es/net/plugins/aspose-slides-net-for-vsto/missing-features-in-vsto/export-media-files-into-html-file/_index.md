---
title: Exportar archivos multimedia a un archivo HTML
type: docs
weight: 80
url: /es/net/export-media-files-into-html-file/
---

Para exportar archivos multimedia a HTML. Por favor, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de la diapositiva
- Establecer el efecto de transición
- Escribir la presentación como un archivo PPTX

En el ejemplo dado a continuación, hemos exportado los archivos multimedia a HTML.
## **Ejemplo**
``` 

 //Cargando una presentación

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Estableciendo opciones HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Guardando el archivo

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)