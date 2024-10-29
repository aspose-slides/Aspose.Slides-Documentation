---
title: Génération d'une miniature à partir d'une diapositive avec des dimensions définies par l'utilisateur
type: docs
weight: 100
url: /fr/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Pour générer la miniature de n'importe quelle diapositive souhaitée à l'aide d'Aspose.Slides pour .NET :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Obtenez les facteurs d'échelle X et Y en fonction des dimensions X et Y définies par l'utilisateur.
- Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
- Enregistrez l'image miniature dans n'importe quel format d'image souhaité.
## **Exemple**
```cs
//Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation pres = new Presentation("TestPresentation.pptx"))
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
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger un exemple fonctionnel**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger un code exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Création de l'image miniature des diapositives](/slides/fr/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}