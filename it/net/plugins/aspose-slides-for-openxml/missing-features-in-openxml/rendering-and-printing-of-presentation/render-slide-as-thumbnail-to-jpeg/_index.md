---
title: Renderizza diapositiva come miniatura JPEG
type: docs
weight: 60
url: /it/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** è utilizzato per creare file di presentazione contenenti diapositive. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini usando il loro visualizzatore di immagini preferito. In tali casi, Aspose.Slides for .NET ti aiuta a generare immagini thumbnail delle diapositive.

Per generare la miniatura di qualsiasi diapositiva desiderata usando Aspose.Slides for .NET:

1. Crea un'istanza della classe **Presentation**.
1. Ottieni il riferimento di qualsiasi diapositiva desiderata utilizzando il suo ID o indice.
1. Ottieni l'immagine thumbnail della diapositiva di riferimento a una scala specificata.
1. Salva l'immagine thumbnail in qualsiasi formato immagine desiderato.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Istanzia la classe Presentation che rappresenta il file di presentazione
using (Presentation pres = new Presentation(srcFileName))
{
    //Accedi alla prima diapositiva
    ISlide sld = pres.Slides[0];

    //Crea un'immagine a scala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Salva l'immagine su disco in formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Scarica il Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)