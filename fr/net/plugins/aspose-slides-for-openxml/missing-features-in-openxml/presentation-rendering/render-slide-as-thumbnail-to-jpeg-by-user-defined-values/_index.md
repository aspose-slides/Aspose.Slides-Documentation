---
title: Rendre la diapositive en vignette JPEG avec des valeurs définies par l'utilisateur
type: docs
weight: 70
url: /fr/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Pour générer la vignette de toute diapositive souhaitée en utilisant Aspose.Slides pour .NET :

1. Créer une instance de la classe **Presentation**.
1. Obtenir la référence de la diapositive souhaitée en utilisant son ID ou son index.
1. Obtenir les facteurs d'échelle X et Y en fonction des dimensions X et Y définies par l'utilisateur.
1. Obtenir l'image de vignette de la diapositive référencée à une échelle spécifiée.
1. Enregistrer l'image de la vignette dans le format d'image souhaité.

```csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation pres = new Presentation(srcFileName))
{
    //Accéder à la première diapositive
    ISlide sld = pres.Slides[0];

    //Dimension définie par l'utilisateur
    int desiredX = 1200;
    int desiredY = 800;

    //Obtention des valeurs d'échelle de X et Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Créer une image à pleine échelle
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Enregistrer l'image sur le disque au format JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)