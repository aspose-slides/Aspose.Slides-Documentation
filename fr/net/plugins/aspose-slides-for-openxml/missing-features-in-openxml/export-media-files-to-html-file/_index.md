---
title: Exporter des fichiers multimédias vers un fichier HTML
type: docs
weight: 40
url: /fr/net/export-media-files-to-html-file/
---

Afin d'exporter des fichiers multimédias vers HTML. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir une référence de la diapositive
- Définir l'effet de transition
- Écrire la présentation en tant que fichier PPTX

Dans l'exemple donné ci-dessous, nous avons exporté les fichiers multimédias vers HTML.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Chargement d'une présentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Définition des options HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Sauvegarde du fichier

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Télécharger le code exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Télécharger l'exemple fonctionnel**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Exporter des fichiers multimédias vers un fichier html](/slides/fr/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}