---
title: Löschen einer Folie
type: docs
weight: 80
url: /de/net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Löschen einer Folie.pptx";

DeleteSlide(FileName, 1);

// Holen Sie sich das Präsentationsobjekt und übergeben Sie es an die nächste DeleteSlide-Methode.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Öffne das Quell-Dokument im Lese-/Schreibmodus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Übergeben Sie das Quell-Dokument und den Index der zu löschenden Folie an die nächste DeleteSlide-Methode.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Löschen Sie die angegebene Folie aus der Präsentation.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Verwenden Sie das CountSlides-Beispiel, um die Anzahl der Folien in der Präsentation zu ermitteln.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Holen Sie sich den Präsentationsteil aus dem Präsentationsdokument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Holen Sie sich die Präsentation aus dem Präsentationsteil.

    Presentation presentation = presentationPart.Presentation;

    // Holen Sie sich die Liste der Folien-IDs in der Präsentation.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Holen Sie sich die Folien-ID der angegebenen Folie

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Holen Sie sich die Beziehungs-ID der Folie.

    string slideRelId = slideId.RelationshipId;

    // Entfernen Sie die Folie aus der Folienliste.

    slideIdList.RemoveChild(slideId);

    //

    // Entfernen Sie Referenzen zur Folie aus allen benutzerdefinierten Shows.

    if (presentation.CustomShowList != null)

    {

        // Durchlaufen Sie die Liste der benutzerdefinierten Shows.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Deklarieren Sie eine verlinkte Liste von Folienlisteneinträgen.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Finden Sie die Folienreferenz, die aus der benutzerdefinierten Show entfernt werden soll.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Entfernen Sie alle Referenzen zur Folie aus der benutzerdefinierten Show.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Speichern Sie die geänderte Präsentation.

    presentation.Save();

    // Holen Sie sich den Folienteil für die angegebene Folie.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Entfernen Sie den Folienteil.

    presentationPart.DeletePart(slidePart);

}

// Holen Sie sich das Präsentationsobjekt und übergeben Sie es an die nächste CountSlides-Methode.

public static int CountSlides(string presentationFile)

{

    // Öffnen Sie die Präsentation im Nur-Lesen-Modus.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Übergabe der Präsentation an die nächste CountSlide-Methode

        // und Rückgabe der Folienanzahl.

        return CountSlides(presentationDocument);

    }

}

// Zählen Sie die Folien in der Präsentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Überprüfen Sie, ob das Dokumentobjekt null ist.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Holen Sie sich den Präsentationsteil des Dokuments.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Holen Sie sich die Folienanzahl aus den SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Geben Sie die Folienanzahl an die vorherige Methode zurück.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Löschen einer Folie.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instanziieren Sie ein PresentationEx-Objekt, das eine PPTX-Datei darstellt

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Zugriff auf eine Folie über ihren Index in der Folienkollektion

        ISlide slide = pres.Slides[slideIndex];


        //Eine Folie über ihren Verweis entfernen

        pres.Slides.Remove(slide);


        //Speichern der Präsentation als PPTX-Datei

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Beispielcode herunterladen**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Löschen%20einer%20Folie%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Löschen%20einer%20Folie%20\(Aspose.Slides\).zip)