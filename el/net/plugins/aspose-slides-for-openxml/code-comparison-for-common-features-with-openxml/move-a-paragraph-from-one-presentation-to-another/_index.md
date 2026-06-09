---
title: Μετακίνηση παραγράφου από μία παρουσίαση σε άλλη
type: docs
weight: 130
url: /el/net/move-a-paragraph-from-one-presentation-to-another/
---
## **Παρουσίαση OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Μετακινεί μια περιοχή παραγράφου σε σχήμα TextBody στο αρχικό έγγραφο
// σε άλλο σχήμα TextBody στο έγγραφο-στόχο.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Ανοίξτε το αρχείο πηγής σε λειτουργία ανάγνωση/εγγραφή.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Ανοίξτε το αρχείο προορισμού σε λειτουργία ανάγνωση/εγγραφή.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Αποκτήστε τη πρώτη διαφάνεια στην πηγαία παρουσίαση.
        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Αποκτήστε το πρώτο σχήμα TextBody μέσα σε αυτή.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Αποκτήστε την πρώτη παράγραφο στο σχήμα TextBody.
        // Σημείωση: "Drawing" είναι το ψευδώνυμο του ονοματοχώρου DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Αποκτήστε τη πρώτη διαφάνεια στην προορισμένη παρουσίαση.
        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Αποκτήστε το πρώτο σχήμα TextBody μέσα σε αυτή.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Κλωνοποιήστε την παραγράφο πηγής και εισάγετε την κλωνοποιημένη παράγραφο στο σχήμα TextBody του προορισμού.
        // Η μεταβίβαση του "true" δημιουργεί ένα βαθύ κλώνο, που δημιουργεί ένα αντίγραφο του 
        // αντικειμένου Paragraph και όλων όσων αναφέρονται άμεσα ή έμμεσα σε αυτό το αντικείμενο.
        textBody2.Append(p1.CloneNode(true));

        // Αφαιρέστε την παράγραφο πηγής από το αρχείο πηγής.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Αντικαταστήστε την αφαιρεμένη παράγραφο με έναν δωροθέτη.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Αποθηκεύστε τη διαφάνεια στο αρχείο πηγής.
        slide1.Slide.Save();

        // Αποθηκεύστε τη διαφάνεια στο αρχείο προορισμού.
        slide2.Slide.Save();

    }

}

}

// Αποκτήστε το τμήμα διαφάνειας της πρώτης διαφάνειας στο έγγραφο παρουσίασης.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Αποκτήστε το ID σχέσης της πρώτης διαφάνειας
PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Get the slide part by the relationship ID.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}
``` 
## **Aspose.Slides**
Δεν είναι σπάνιο οι προγραμματιστές να χρειάζονται να εξάγουν το κείμενο από μια παρουσίαση. Για να το επιτύχετε, πρέπει να εξάγετε το κείμενο από όλα τα σχήματα σε όλες τις διαφάνειες μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να εξάγετε κείμενο από παρουσιάσεις Microsoft PowerPoint PPTX χρησιμοποιώντας το Aspose.Slides. Είτε εξάγετε κείμενο από μία διαφάνεια είτε από ολόκληρη παρουσίαση, το Aspose.Slides χρησιμοποιεί την κλάση PresentationScanner και τις στατικές μεθόδους που αυτή παρέχει. Όλες αυτές είναι συσσωματωμένες στο namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Μετακινεί μια περιοχή παραγράφου σε σχήμα TextBody στο αρχικό έγγραφο
// σε άλλο σχήμα TextBody στο έγγραφο-στόχο.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει PPTX//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Πρόσβαση στο πρώτο σχήμα στην πρώτη διαφάνεια

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Ανάκτηση κειμένου από το placeholder

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Πρόσβαση στο πρώτο σχήμα στην πρώτη διαφάνεια

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Ανάκτηση κειμένου από το placeholder

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Λήψη Παραδείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Δείγμα Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)