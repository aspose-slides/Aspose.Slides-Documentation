---
title: Exporter des fichiers multimédias en fichier HTML
type: docs
weight: 80
url: /fr/net/export-media-files-into-html-file/
---

Pour exporter des fichiers multimédias en HTML. Veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence de la diapositive
- Définir l’effet de transition
- Enregistrer la présentation au format PPTX

Dans l’exemple ci‑dessous, nous avons exporté les fichiers multimédias en HTML.
## **Exemple**
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
## **Télécharger l’exemple en cours d’exécution**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Télécharger le code d’exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)