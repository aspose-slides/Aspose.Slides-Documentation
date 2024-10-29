---
title: Rendre la diapositive en miniature au format JPEG selon les valeurs définies par l'utilisateur
type: docs
weight: 70
url: /fr/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Pour générer la miniature de n'importe quelle diapositive souhaitée en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez les facteurs de mise à l'échelle X et Y basés sur les dimensions X et Y définies par l'utilisateur.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Miniature Définie par l'Utilisateur.pptx";
string destFileName = filePath + "Miniature Définie par l'Utilisateur.jpg";

//Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation pres = new Presentation(srcFileName))
{
    //Accéder à la première diapositive
    ISlide sld = pres.Slides[0];

    //Dimension définie par l'utilisateur
    int desiredX = 1200;
    int desiredY = 800;

    //Obtention de la valeur mise à l'échelle de X et Y
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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Miniature%20Définie%20par%20l'Utilisateur%20%28Aspose.Slides%29.zip)