---
title: Rendre une diapositive en tant que miniature en JPEG
type: docs
weight: 60
url: /fr/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides pour .NET** est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant des fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de voir des diapositives sous forme d'images en utilisant leur visionneuse d'images préférée. Dans de tels cas, Aspose.Slides pour .NET vous aide à générer des images miniatures des diapositives.

Pour générer la miniature d'une diapositive souhaitée en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans le format d'image désiré.

```csharp
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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)