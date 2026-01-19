---
title: Générer une vignette à partir d'une diapositive avec des dimensions définies par l'utilisateur
type: docs
weight: 100
url: /fr/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Pour générer la vignette de n'importe quelle diapositive souhaitée à l'aide d'Aspose.Slides for .NET :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Récupérez les facteurs d'échelle X et Y en fonction des dimensions X et Y définies par l'utilisateur.
- Obtenez l'image vignette de la diapositive référencée à une échelle spécifiée.
- Enregistrez l'image vignette dans le format d'image souhaité.
## **Exemple**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
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
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Télécharger l'exemple en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Pour plus de détails, consultez [Convertir la diapositive](/slides/fr/net/convert-slide/).
{{% /alert %}}