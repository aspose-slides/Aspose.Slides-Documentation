---
title: Προσθήκη διαφάνειας στην παρουσίαση
type: docs
weight: 20
url: /el/net/adding-slide-to-presentation/
---
## **OpenXML Παρουσίαση**
Στην παρακάτω λειτουργία, εξ ορισμού προστίθεται μια διαφάνεια στην παρουσίαση. Εδώ προσθέτουμε μια νέα διαφάνεια στη θέση 2 με κάποιο κείμενο.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Προσθήκη διαφάνειας στην καθορισμένη παρουσίαση.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Άνοιγμα του πηγαίου εγγράφου σε ανάγνωση/εγγραφή. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Μετάδοση του πηγαίου εγγράφου, της θέσης και του τίτλου της διαφάνειας που θα εισαχθεί στη επόμενη μέθοδο.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Εισαγωγή της καθορισμένης διαφάνειας στην παρουσίαση στην καθορισμένη θέση.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Επαλήθευση ότι η παρουσίαση δεν είναι κενή.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Δήλωση και δημιουργία νέας διαφάνειας.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Δημιουργία του περιεχομένου της διαφάνειας.            

    // Καθορισμός των μη οπτικών ιδιοτήτων της νέας διαφάνειας.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Καθορισμός των ιδιοτήτων του ομαδικού σχήματος της νέας διαφάνειας.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Δήλωση και δημιουργία του σχήματος τίτλου της νέας διαφάνειας.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Καθορισμός των απαιτούμενων ιδιοτήτων σχήματος για το σχήμα τίτλου. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Καθορισμός του κειμένου του σχήματος τίτλου.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Δήλωση και δημιουργία του σχήματος κειμένου της νέας διαφάνειας.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Καθορισμός των απαιτούμενων ιδιοτήτων σχήματος για το σχήμα σώματος.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Καθορισμός του κειμένου του σχήματος σώματος.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Δημιουργία του τμήματος διαφάνειας για τη νέα διαφάνεια.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Αποθήκευση του νέου τμήματος διαφάνειας.

    slide.Save(slidePart);

    // Τροποποίηση της λίστας IDs διαφάνειας στο τμήμα παρουσίασης.

    // Η λίστα IDs διαφάνειας δεν πρέπει να είναι κενή.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Εύρεση του υψηλότερου ID διαφάνειας στην τρέχουσα λίστα.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Λήψη του ID της προηγούμενης διαφάνειας.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Χρήση της ίδιας διάταξης διαφάνειας όπως αυτή της προηγούμενης διαφάνειας.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Εισαγωγή της νέας διαφάνειας στη λίστα διαφάνειας μετά την προηγούμενη διαφάνεια.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Αποθήκευση της τροποποιημένης παρουσίασης.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Κάθε αρχείο παρουσίασης PowerPoint περιέχει μια **Κύρια διαφάνεια Master** και άλλες **Κανονικές διαφάνειες**. Αυτό σημαίνει ότι ένα αρχείο παρουσίασης περιέχει τουλάχιστον μία ή περισσότερες διαφάνειες. Είναι σημαντικό να γνωρίζετε ότι αρχεία παρουσίασης χωρίς διαφάνειες δεν υποστηρίζονται από το Aspose.Slides for .NET. Κάθε διαφάνεια έχει συγκεκριμένη θέση και ένα **μοναδικό Id**. Το **Id διαφάνειας** μπορεί να κυμαίνεται από 0 έως 255 για διαφάνειες master και από 256 έως 65535 για κανονικές διαφάνειες.

Το Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να προσθέτουν κενές διαφάνειες στις παρουσιάσεις χρησιμοποιώντας τη μέθοδο **AddEmptySlide** που εκτίθεται από το αντικείμενο **Presentation**. Για να προσθέσετε μια κενή διαφάνεια στην παρουσίαση, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα δείγμα της κλάσης Presentation
- Καλέστε τη μέθοδο AddEmptySlide που εκτίθεται από το αντικείμενο Presentation
- Κάντε κάποια ενέργεια με τη νεοπροσθεθείσα κενή διαφάνεια
- Προσθέστε άλλη μια διαφάνεια και εισάγετε κείμενο σε αυτήν.
- Τέλος, γράψτε το αρχείο PPT χρησιμοποιώντας τη μέθοδο Write που εκτίθεται από το αντικείμενο Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";
//Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPT
Presentation pres = new Presentation();
//Η κενή διαφάνεια προστίθεται εξ ορισμού, όταν δημιουργείτε
//παρουσίαση από τον προεπιλεγμένο κατασκευαστή
//Προσθήκη κενής διαφάνειας στην παρουσίαση και λήψη της αναφοράς της
//αυτής της κενής διαφάνειας
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
//Γράψιμο του αποτελέσματος στο δίσκο
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)