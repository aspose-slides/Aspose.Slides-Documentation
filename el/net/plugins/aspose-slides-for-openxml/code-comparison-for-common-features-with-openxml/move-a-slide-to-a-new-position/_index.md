---
title: Μετακίνηση μιας διαφάνειας σε νέα θέση
type: docs
weight: 140
url: /el/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Καταμέτρηση των διαφανειών στην παρουσίαση.

public static int CountSlides(string presentationFile)

{

    // Άνοιγμα της παρουσίασης μόνο για ανάγνωση.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Μεταβιβάζει την παρουσίαση στην επόμενη μέθοδο CountSlides
        // και επιστρέφει τον αριθμό των διαφανειών.

        return CountSlides(presentationDocument);

    }

}

// Καταμέτρηση των διαφανειών στην παρουσίαση.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Έλεγχος για αντικείμενο εγγράφου null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Λήψη του τμήματος παρουσίασης του εγγράφου.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Λήψη του αριθμού διαφανειών από τα SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Επιστροφή του αριθμού διαφανειών στην προηγούμενη μέθοδο.

    return slidesCount;

}

// Μετακίνηση μιας διαφάνειας σε διαφορετική θέση στη σειρά διαφανειών της παρουσίασης.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Μετακίνηση μιας διαφάνειας σε διαφορετική θέση στη σειρά διαφανειών της παρουσίασης.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Κλήση της μεθόδου CountSlides για λήψη του αριθμού των διαφανειών στην παρουσίαση.

    int slidesCount = CountSlides(presentationDocument);

    // Επαλήθευση ότι οι θέσεις from και to είναι εντός του εύρους και διαφορετικές η μία από την άλλη.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Λήψη του τμήματος παρουσίασης από το έγγραφο παρουσίασης.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Ο αριθμός διαφανειών δεν είναι μηδέν, επομένως η παρουσίαση πρέπει να περιέχει διαφάνειες.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Λήψη του ID της πηγαίας διαφάνειας.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Αναγνώριση της θέσης της διαφάνειας-στόχου μετά την οποία θα μετακινηθεί η πηγαία διαφάνεια.

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

    // Αφαίρεση της πηγαίας διαφάνειας από την τρέχουσα θέση της.

    sourceSlide.Remove();

    // Εισαγωγή της πηγαίας διαφάνειας στη νέα θέση της μετά τη διαφάνεια-στόχο.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Αποθήκευση της τροποποιημένης παρουσίασης.

    presentation.Save();

} 
```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Μετακίνηση μιας διαφάνειας σε διαφορετική θέση στη σειρά διαφανειών της παρουσίασης.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // Δημιουργία αντικειμένου PresentationEx για φόρτωση του αρχικού αρχείου PPTX
    using (Presentation pres = new Presentation(presentationFile))

    {

        // Λήψη της διαφάνειας της οποίας η θέση θα αλλάξει
        ISlide sld = pres.Slides[from];
        ISlide sld2 = pres.Slides[to];

        // Ορισμός της νέας θέσης για τη διαφάνεια
        sld2.SlideNumber = from;
        sld.SlideNumber = to;

        // Εγγραφή του PPTX στο δίσκο
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
```
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)