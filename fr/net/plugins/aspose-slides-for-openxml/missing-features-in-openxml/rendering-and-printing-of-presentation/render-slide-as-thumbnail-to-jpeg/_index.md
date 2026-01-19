---
title: Rendre la diapositive en vignette JPEG
type: docs
weight: 60
url: /fr/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs ont besoin de voir les diapositives sous forme d'images avec leur visualiseur d'images préféré. Dans de tels cas, Aspose.Slides for .NET vous aide à générer des images miniatures des diapositives.

Pour générer la vignette de n'importe quelle diapositive souhaitée en utilisant Aspose.Slides for .NET :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
1. Récupérez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans le format d'image souhaité.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)