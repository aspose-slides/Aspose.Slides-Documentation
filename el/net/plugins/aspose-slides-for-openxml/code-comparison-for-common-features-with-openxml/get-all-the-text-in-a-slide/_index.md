---
title: Αποκτήστε όλο το κείμενο σε μια διαφάνεια
type: docs
weight: 110
url: /el/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Λάβετε όλο το κείμενο σε μια διαφάνεια.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Ανοίξτε την παρουσίαση μόνο για ανάγνωση.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Μεταβιβάστε την παρουσίαση και τον δείκτη διαφάνειας

        // στην επόμενη μέθοδο GetAllTextInSlide, και

        // στη συνέχεια επιστρέψτε τον πίνακα των συμβολοσειρών που επιστρέφει. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Επαληθεύστε ότι το αρχείο παρουσίασης υπάρχει.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Επαληθεύστε ότι ο δείκτης διαφάνειας δεν είναι εκτός εύρους.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Λάβετε το τμήμα παρουσίασης του αρχείου παρουσίασης.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Επαληθεύστε ότι το τμήμα παρουσίασης και η παρουσίαση υπάρχουν.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Λάβετε το αντικείμενο Presentation από το τμήμα παρουσίασης.

        Presentation presentation = presentationPart.Presentation;

        // Επαληθεύστε ότι η λίστα ID διαφάνειας υπάρχει.

        if (presentation.SlideIdList != null)

        {

            // Λάβετε τη συλλογή των ID διαφανειών από τη λίστα ID διαφάνειας.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Εάν το ID διαφάνειας είναι εντός εύρους...

            if (slideIndex < slideIds.Count)

            {

                // Λάβετε το σχέση ID της διαφάνειας.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Λάβετε το καθορισμένο τμήμα διαφάνειας από το σχέση ID.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Μεταβιβάστε το τμήμα διαφάνειας στην επόμενη μέθοδο, και

                // στη συνέχεια επιστρέψτε τον πίνακα των συμβολοσειρών που η μέθοδος

                // επιστρέφει στην προηγούμενη μέθοδο.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Διαφορετικά, επιστρέψτε null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Επαληθεύστε ότι το τμήμα διαφάνειας υπάρχει.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Δημιουργήστε μια νέα συνδεδεμένη λίστα συμβολοσειρών.

    LinkedList<string> texts = new LinkedList<string>();

    // Εάν η διαφάνεια υπάρχει...

    if (slidePart.Slide != null)

    {

        // Διασχίστε όλες τις παραγράφους στη διαφάνεια.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Δημιουργήστε ένα νέο StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Διασχίστε τις γραμμές της παραγράφου.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Προσθέστε κάθε γραμμή στις προηγούμενες γραμμές.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Προσθέστε κάθε παράγραφο στη συνδεδεμένη λίστα.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Επιστρέψτε έναν πίνακα συμβολοσειρών.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Λάβετε όλο το κείμενο σε μια διαφάνεια.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Δημιουργήστε μια νέα συνδεδεμένη λίστα συμβολοσειρών.

List<string> texts = new List<string>();

//Instantiate PresentationEx class that represents PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Access the slide
    ISlide sld = pres.Slides[slideIndex];

    //Iterate through shapes to find the placeholder
    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //get the text of each placeholder
            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Επιστρέψτε έναν πίνακα συμβολοσειρών.

return texts;

}

``` 
## **Λήψη δείγματος κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)