---
title: Generazione di una miniatura da una diapositiva con dimensioni definite dall'utente
type: docs
weight: 100
url: /it/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Per generare la miniatura di qualsiasi diapositiva desiderata utilizzando Aspose.Slides per .NET:

- Creare un'istanza della classe Presentation.
- Ottenere il riferimento di qualsiasi diapositiva desiderata utilizzando il suo ID o indice.
- Recuperare i fattori di scala X e Y in base alle dimensioni X e Y definite dall'utente.
- Ottenere l'immagine della miniatura della diapositiva di riferimento a una scala specificata.
- Salvare l'immagine della miniatura in qualsiasi formato immagine desiderato.
## **Esempio**
```cs
//Instanzia la classe Presentation che rappresenta il file di presentazione
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Accedi alla prima diapositiva
    ISlide sld = pres.Slides[0];

    //Dimensione definita dall'utente
    int desiredX = 1200;
    int desiredY = 800;

    //Ottenere il valore scalato di X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Crea un'immagine a scala completa
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Salva l'immagine su disco in formato JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Scarica Esempio in Esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Converti Diapositiva](/slides/it/net/convert-slide/).

{{% /alert %}}