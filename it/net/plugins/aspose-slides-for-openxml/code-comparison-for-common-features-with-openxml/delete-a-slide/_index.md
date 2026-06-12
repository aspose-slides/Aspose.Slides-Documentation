---
title: Elimina una diapositiva
type: docs
weight: 80
url: /it/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Ottieni l'oggetto presentazione e passalo al successivo metodo DeleteSlide.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Apri il documento sorgente in modalità lettura/scrittura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passa il documento sorgente e l'indice della diapositiva da eliminare al successivo metodo DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Elimina la diapositiva specificata dalla presentazione.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Usa l'esempio CountSlides per ottenere il numero di diapositive nella presentazione.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Ottieni la parte della presentazione dal documento di presentazione. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni la presentazione dalla parte della presentazione.

    Presentation presentation = presentationPart.Presentation;

    // Ottieni l'elenco degli ID delle diapositive nella presentazione.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Ottieni l'ID della diapositiva specificata

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Ottieni l'ID della relazione della diapositiva.

    string slideRelId = slideId.RelationshipId;

    // Rimuovi la diapositiva dall'elenco delle diapositive.

    slideIdList.RemoveChild(slideId);

    //

    // Rimuovi i riferimenti alla diapositiva da tutti gli spettacoli personalizzati.

    if (presentation.CustomShowList != null)

    {

        // Scorri l'elenco degli spettacoli personalizzati.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Dichiara una lista collegata di voci dell'elenco diapositive.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Trova il riferimento alla diapositiva da rimuovere dallo spettacolo personalizzato.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Rimuovi tutti i riferimenti alla diapositiva dallo spettacolo personalizzato.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Salva la presentazione modificata.

    presentation.Save();

    // Ottieni la parte della diapositiva per la diapositiva specificata.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Rimuovi la parte della diapositiva.

    presentationPart.DeletePart(slidePart);

}

// Ottieni l'oggetto presentazione e passalo al successivo metodo CountSlides.

public static int CountSlides(string presentationFile)

{

    // Apri la presentazione in modalità sola lettura.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passa la presentazione al successivo metodo CountSlide

        // e ritorna il conteggio delle diapositive.

        return CountSlides(presentationDocument);

    }

}

// Conta le diapositive nella presentazione.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Verifica l'esistenza di un oggetto documento null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Ottieni la parte di presentazione del documento.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ottieni il conteggio delle diapositive dalle SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Ritorna il conteggio delle diapositive al metodo precedente.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Istanzia un oggetto PresentationEx che rappresenta un file PPTX
    using (Presentation pres = new Presentation(presentationFile))

    {

        //Accedi a una diapositiva usando il suo indice nella raccolta di diapositive
        ISlide slide = pres.Slides[slideIndex];


        //Rimuovi una diapositiva usando il suo riferimento
        pres.Slides.Remove(slide);


        //Scrivi la presentazione come file PPTX
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Scarica codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)