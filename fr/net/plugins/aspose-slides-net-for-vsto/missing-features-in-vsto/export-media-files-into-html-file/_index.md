---
title: Exporter des fichiers multimédias dans un fichier HTML
type: docs
weight: 80
url: /fr/net/export-media-files-into-html-file/
---

Afin d'exporter des fichiers multimédias en HTML. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence de la diapositive
- Configurer l'effet de transition
- Écrire la présentation en tant que fichier PPTX

Dans l'exemple donné ci-dessous, nous avons exporté les fichiers multimédias en HTML.
## **Exemple**
``` 

 //Chargement d'une présentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "chemin";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Configuration des options HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Sauvegarde du fichier

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Télécharger un exemple opérationnel**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)