---
title: Rendre la diapositive en vignette JPEG
type: docs
weight: 60
url: /fr/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs doivent afficher les diapositives sous forme d'images à l'aide de leur visualiseur d'images préféré. Dans ces cas, Aspose.Slides for .NET vous aide à générer des images miniatures des diapositives.

Pour générer la vignette de n'importe quelle diapositive souhaitée à l'aide d'Aspose.Slides for .NET :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son indice.
1. Récupérez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans le format d'image souhaité.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation pres = new Presentation(srcFileName))
{
    //Accéder à la première diapositive
    ISlide sld = pres.Slides[0];

    //Créer une image à pleine échelle
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Enregistrer l'image sur le disque au format JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)