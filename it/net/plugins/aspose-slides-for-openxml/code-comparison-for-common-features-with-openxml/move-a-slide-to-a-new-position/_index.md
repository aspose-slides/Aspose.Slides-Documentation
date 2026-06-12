---
title: Sposta una diapositiva in una nuova posizione
type: docs
weight: 140
url: /it/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Conteggio delle diapositive nella presentazione.

public static int CountSlides(string presentationFile)

{

    // Apri la presentazione in sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione al metodo CountSlides successivo

        // e restituisce il conteggio delle diapositive.

        return CountSlides(presentationDocument);

    }

}

// Conta le diapositive nella presentazione.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifica se l'oggetto documento è null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Ottieni la parte di presentazione del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni il conteggio delle diapositive da SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Restituisci il conteggio delle diapositive al metodo precedente.

    return slidesCount;

}

// Sposta una diapositiva in una posizione diversa nell'ordine delle diapositive nella presentazione.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Sposta una diapositiva in una posizione diversa nell'ordine delle diapositive nella presentazione.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Chiama il metodo CountSlides per ottenere il numero di diapositive nella presentazione.

    int slidesCount = CountSlides(presentationDocument);

    // Verifica che entrambe le posizioni da e a siano nell'intervallo e diverse tra loro.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Ottieni la parte di presentazione dal documento di presentazione.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Il conteggio delle diapositive non è zero, quindi la presentazione deve contenere diapositive.

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Ottieni l'ID della diapositiva di origine.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identifica la posizione della diapositiva di destinazione dopo la quale spostare la diapositiva di origine.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Rimuovi la diapositiva di origine dalla sua posizione attuale.

    sourceSlide.Remove();

    // Inserisci la diapositiva di origine nella sua nuova posizione dopo la diapositiva di destinazione.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Salva la presentazione modificata.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Sposta una diapositiva in una posizione diversa nell'ordine delle diapositive nella presentazione.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Istanzia la classe PresentationEx per caricare il file PPTX sorgente

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Ottieni la diapositiva la cui posizione deve essere cambiata

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Imposta la nuova posizione per la diapositiva

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Scrivi il PPTX su disco

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Scarica codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)