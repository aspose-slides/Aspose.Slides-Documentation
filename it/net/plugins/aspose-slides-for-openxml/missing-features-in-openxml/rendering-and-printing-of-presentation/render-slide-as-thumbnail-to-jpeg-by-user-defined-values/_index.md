---
title: Genera la diapositiva come miniatura JPEG con valori definiti dall'utente
type: docs
weight: 70
url: /it/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Per generare l'anteprima di qualsiasi diapositiva desiderata utilizzando Aspose.Slides per .NET:

1. Creare un'istanza della classe **Presentation**.
1. Ottenere il riferimento di qualsiasi diapositiva desiderata utilizzando il suo ID o indice.
1. Recuperare i fattori di scala X e Y in base alle dimensioni X e Y definite dall'utente.
1. Ottenere l'immagine in miniatura della diapositiva di riferimento a una scala specificata.
1. Salvare l'immagine in miniatura in qualsiasi formato immagine desiderato.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Istanzia la classe Presentation che rappresenta il file di presentazione
using (Presentation pres = new Presentation(srcFileName))
{
    //Accedi alla prima diapositiva
    ISlide sld = pres.Slides[0];

    //Dimensione definita dall'utente
    int desiredX = 1200;
    int desiredY = 800;

    //Ottenere i valori scalati di X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Crea un'immagine a scala piena
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Salva l'immagine su disco in formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)