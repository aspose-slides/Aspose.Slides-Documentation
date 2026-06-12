---
title: Esporta file multimediali in file HTML
type: docs
weight: 80
url: /it/net/export-media-files-into-html-file/
---
Per esportare i file multimediali in HTML, seguire i passaggi seguenti:

- Creare un'istanza della classe Presentation
- Ottenere il riferimento della diapositiva
- Impostare l'effetto di transizione
- Scrivere la presentazione come file PPTX

Nell'esempio riportato di seguito, abbiamo esportato i file multimediali in HTML.
## **Esempio**
``` 

 //Caricamento di una presentazione

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Impostazione delle opzioni HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Salvataggio del file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Scarica Esempio in Esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)