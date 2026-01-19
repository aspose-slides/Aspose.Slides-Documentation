---
title: Exportar archivos multimedia a archivo HTML
type: docs
weight: 40
url: /es/net/export-media-files-to-html-file/
---

Para exportar archivos multimedia a HTML. Por favor, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de la diapositiva
- Configurar el efecto de transición
- Guardar la presentación como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos exportado los archivos multimedia a HTML.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
Para obtener más detalles, visite [Exportar archivos multimedia a archivo html](/slides/es/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}