---
title: Rendre la diapositive en vignette JPEG avec des valeurs définies par l'utilisateur
type: docs
weight: 70
url: /fr/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Pour générer la vignette de n'importe quelle diapositive souhaitée en utilisant Aspose.Slides pour .NET:

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez les facteurs d'échelle X et Y en fonction des dimensions X et Y définies par l'utilisateur.
1. Récupérez l'image vignette de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image vignette dans le format d'image souhaité.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)