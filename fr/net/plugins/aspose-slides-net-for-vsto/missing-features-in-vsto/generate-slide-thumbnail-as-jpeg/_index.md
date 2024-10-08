---
title: Générer une miniature de diapositive au format JPEG
type: docs
weight: 90
url: /fr/net/generate-slide-thumbnail-as-jpeg/
---

Pour générer la miniature d'une diapositive souhaitée en utilisant Aspose.Slides pour .NET :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
- Enregistrez l'image miniature dans n'importe quel format d'image désiré.
## **Exemple**
```cs
//Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Accéder à la première diapositive
    ISlide sld = pres.Slides[0];

    //Créer une image à échelle complète
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Enregistrer l'image sur le disque au format JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger l'exemple en cours d'exécution**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Création d'image miniature de diapositives](/slides/fr/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}