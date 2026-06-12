---
title: Esporta file multimediali in file HTML
type: docs
weight: 40
url: /it/net/export-media-files-to-html-file/
---
Per esportare i file multimediali in HTML, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento della diapositiva
- Imposta l'effetto di transizione
- Scrivi la presentazione come file PPTX

Nell'esempio riportato di seguito, abbiamo esportato i file multimediali in HTML.
## **Esempio**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Caricamento della presentazione

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Impostazione delle opzioni HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Salvataggio del file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Scarica il codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica l'esempio funzionante**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
Per ulteriori dettagli, visita [Esportazione di file multimediali in file HTML](/slides/it/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}