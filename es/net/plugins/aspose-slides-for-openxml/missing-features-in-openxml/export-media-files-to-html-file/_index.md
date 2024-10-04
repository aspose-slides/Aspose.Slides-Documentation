---
title: Exportar archivos de multimedia a un archivo HTML
type: docs
weight: 40
url: /net/export-media-files-to-html-file/
---

Para exportar archivos de multimedia a HTML. Por favor, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de la diapositiva
- Configure el efecto de transición
- Escriba la presentación como un archivo PPTX

En el ejemplo dado a continuación, hemos exportado los archivos de multimedia a HTML.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Cargando una presentación

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Configurando opciones HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Guardando el archivo

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Descargar código de ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Descargar ejemplo en ejecución**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Para más detalles, visite [Exportando archivos de multimedia a un archivo html](/slides/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}