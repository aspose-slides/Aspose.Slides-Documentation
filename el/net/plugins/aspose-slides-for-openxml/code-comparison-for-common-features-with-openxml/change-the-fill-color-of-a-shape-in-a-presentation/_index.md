---
title: Αλλαγή του χρώματος γεμίσματος ενός σχήματος σε παρουσίαση
type: docs
weight: 40
url: /el/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Αλλαγή του χρώματος γεμίσματος ενός σχήματος.

// Το αρχείο δοκιμής πρέπει να περιέχει ένα γεμάτο σχήμα ως το πρώτο σχήμα στην πρώτη διαφάνεια.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Πάρε το αναγνωριστικό σχέσης (Relationship ID) της πρώτης διαφάνειας.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Πάρε το μέρος της διαφάνειας (slide part) από το αναγνωριστικό σχέσης.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Πάρε το δέντρο σχήματος (shape tree) που περιέχει το σχήμα προς αλλαγή.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Πάρε το πρώτο σχήμα στο δέντρο σχήματος.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Πάρε το στυλ του σχήματος.

                ShapeStyle style = shape.ShapeStyle;

                // Πάρε την αναφορά γεμίσματος (fill reference).

                Drawing.FillReference fillRef = style.FillReference;

                // Ορίσε το χρώμα γεμίσματος σε SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Αποθήκευσε τη τροποποιημένη διαφάνεια.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Πρέπει να ακολουθήσετε τα παρακάτω βήματα για να γεμίσετε τα σχήματα στην παρουσίαση:

- Δημιουργήστε ένα αντίγραφο της κλάσης Presentation.
- Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα IShape στη διαφάνεια.
- Ορίστε τον Τύπο Γέμισης του Σχήματος σε Στερεό.
- Ορίστε το χρώμα του Σχήματος.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Δημιουργία αντικειμένου PrseetationEx που αντιπροσωπεύει το PPTX 
using (Presentation pres = new Presentation())

{

    //Πάρε την πρώτη διαφάνεια

    ISlide sld = pres.Slides[0];

    //Πρόσθεσε αυτοσχήμα τύπου ορθογωνίου

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Ορίσε τον τύπο γεμίσματος σε Στερεό

    shp.FillFormat.FillType = FillType.Solid;

    //Ορίσε το χρώμα του ορθογωνίου

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Γράψε το αρχείο PPTX στο δίσκο

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Λήψη Παραδείγματος Κώδικα σε Εκτέλεση**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Δείγμα Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)