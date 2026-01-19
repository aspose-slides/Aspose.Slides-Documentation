---
title: Exportar archivos multimedia a archivo HTML
type: docs
weight: 80
url: /es/net/export-media-files-into-html-file/
---

Para exportar archivos multimedia a HTML. Siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de la diapositiva
- Establecer el efecto de transición
- Guardar la presentación como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos exportado los archivos multimedia a HTML.
## **Ejemplo**
``` 

 //Loading a presentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Setting HTML options

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Saving the file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)