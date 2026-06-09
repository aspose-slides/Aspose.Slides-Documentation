---
title: Διαγραφή διαφάνειας
type: docs
weight: 80
url: /el/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Λάβετε το αντικείμενο παρουσίασης και περάστε το στη επόμενη μέθοδο DeleteSlide method.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Ανοίξτε το πηγαίο έγγραφο ως ανάγνωση/εγγραφή.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Περάστε το πηγαίο έγγραφο και τον δείκτη της διαφάνειας που θα διαγραφεί στην επόμενη μέθοδο DeleteSlide method.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Διαγράψτε τη συγκεκριμένη διαφάνεια από την παρουσίαση.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Χρησιμοποιήστε το παράδειγμα CountSlides για να λάβετε τον αριθμό των διαφανειών στην παρουσίαση.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Λάβετε το μέρος παρουσίασης από το έγγραφο παρουσίασης. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Λάβετε την παρουσίαση από το μέρος παρουσίασης.

    Presentation presentation = presentationPart.Presentation;

    // Λάβετε τη λίστα των αναγνωριστικών διαφανειών στην παρουσίαση.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Λάβετε το αναγνωριστικό διαφάνειας της συγκεκριμένης διαφάνειας

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Λάβετε το αναγνωριστικό σχέσης της διαφάνειας.

    string slideRelId = slideId.RelationshipId;

    // Αφαιρέστε τη διαφάνεια από τη λίστα διαφανειών.

    slideIdList.RemoveChild(slideId);

    //

    // Αφαιρέστε τις αναφορές στη διαφάνεια από όλες τις προσαρμοσμένες παραστάσεις.

    if (presentation.CustomShowList != null)

    {

        // Επανάληψη στη λίστα των προσαρμοσμένων παραστάσεων.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Δηλώστε μια λίστα συνδέσμων των καταχωρίσεων λίστας διαφανειών.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Βρείτε την αναφορά στη διαφάνεια για να αφαιρεθεί από την προσαρμοσμένη παράσταση.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Αφαιρέστε όλες τις αναφορές στη διαφάνεια από την προσαρμοσμένη παράσταση.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Αποθηκεύστε την τροποποιημένη παρουσίαση.

    presentation.Save();

    // Λάβετε το τμήμα διαφάνειας για τη συγκεκριμένη διαφάνεια.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Αφαιρέστε το τμήμα διαφάνειας.

    presentationPart.DeletePart(slidePart);

}

// Λάβετε το αντικείμενο παρουσίασης και περάστε το στην επόμενη μέθοδο CountSlides method.

public static int CountSlides(string presentationFile)

{

    // Ανοίξτε την παρουσίαση ως μόνο ανάγνωση.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Περάστε την παρουσίαση στην επόμενη μέθοδο CountSlide method

        // και επιστρέψτε τον αριθμό διαφανειών.

        return CountSlides(presentationDocument);

    }

}

// Μετρήστε τις διαφάνειες στην παρουσίαση.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ελέγξτε για αντικείμενο εγγράφου null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Λάβετε το μέρος παρουσίασης του εγγράφου.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Λάβετε τον αριθμό διαφανειών από τα SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Επιστρέψτε τον αριθμό διαφανειών στη προηγούμενη μέθοδο.

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

    //Δημιουργήστε ένα αντικείμενο PresentationEx που αντιπροσωπεύει ένα αρχείο PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Πρόσβαση σε διαφάνεια χρησιμοποιώντας το δείκτη της στη συλλογή διαφανειών

        ISlide slide = pres.Slides[slideIndex];


        //Αφαίρεση μιας διαφάνειας χρησιμοποιώντας την αναφορά της

        pres.Slides.Remove(slide);


        //Αποθήκευση της παρουσίασης ως αρχείο PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Λήψη δείγματος κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)