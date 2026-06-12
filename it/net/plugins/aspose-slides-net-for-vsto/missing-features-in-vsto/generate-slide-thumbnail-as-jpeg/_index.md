---
title: Genera miniatura della diapositiva come JPEG
type: docs
weight: 90
url: /it/net/generate-slide-thumbnail-as-jpeg/
---
Per generare la miniatura di qualsiasi diapositiva desiderata utilizzando Aspose.Slides per .NET:

- Creare un'istanza della classe Presentation.
- Ottenere il riferimento di qualsiasi diapositiva desiderata utilizzando il suo ID o indice.
- Recuperare l'immagine miniatura della diapositiva di riferimento a una scala specificata.
- Salvare l'immagine miniatura in qualsiasi formato immagine desiderato.
## **Esempio**
```cs
//Istanzia la classe Presentation che rappresenta il file di presentazione
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Accedi alla prima diapositiva
    ISlide sld = pres.Slides[0];

    //Crea un'immagine a scala intera
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Salva l'immagine su disco in formato JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Scarica Esempio Eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Per ulteriori dettagli, visita [Converti PPT e PPTX in JPG in .NET](/slides/it/net/convert-powerpoint-to-jpg/).
{{% /alert %}}