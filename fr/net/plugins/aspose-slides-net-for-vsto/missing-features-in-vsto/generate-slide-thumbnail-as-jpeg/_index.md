---
title: Générer la vignette de diapositive au format JPEG
type: docs
weight: 90
url: /fr/net/generate-slide-thumbnail-as-jpeg/
---

Pour générer la miniature de n'importe quelle diapositive souhaitée à l'aide d'Aspose.Slides for .NET :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Récupérez l'image miniature de la diapositive référencée à une échelle spécifiée.
- Enregistrez l'image miniature dans le format d'image souhaité.
## **Exemple**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger l'exemple en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pour plus de détails, consultez [Convert PPT and PPTX to JPG in .NET](/slides/fr/net/convert-powerpoint-to-jpg/).

{{% /alert %}}