---
title: Προσθήκη Κειμένου Δυναμικά Χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Προσθήκη Κειμένου Δυναμικά
type: docs
weight: 20
url: /el/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- προσθήκη κειμένου
- μετάβαση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δείτε πώς να μεταβείτε από την αυτοματοποίηση Microsoft Office σε Aspose.Slides για .NET και να προσθέσετε δυναμικό κείμενο σε παρουσιάσεις PowerPoint (PPT, PPTX) με C#."
---
{{% alert color="info" %}} 

Μια κοινή εργασία που οι προγραμματιστές πρέπει να εκτελούν είναι η προσθήκη κειμένου σε διαφάνειες δυναμικά. Αυτό το άρθρο παρουσιάζει παραδείγματα κώδικα για δυναμική προσθήκη κειμένου χρησιμοποιώντας [VSTO](/slides/el/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) και [Aspose.Slides for .NET](/slides/el/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Προσθήκη Κειμένου Δυναμικά**
Και οι δύο μέθοδοι ακολουθούν τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση.
1. Προσθέστε μια κενή διαφάνεια.
1. Προσθέστε ένα πλαίσιο κειμένου.
1. Ορίστε κάποιο κείμενο.
1. Αποθηκεύστε την παρουσίαση.
## **Παράδειγμα Κώδικα VSTO**
Τα αποσπάσματα κώδικα παρακάτω δημιουργούν μια παρουσίαση με μια απλή διαφάνεια και μια σειρά κειμένου πάνω της.

**Η παρουσίαση όπως δημιουργήθηκε στο VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Σημείωση: Το PowerPoint είναι ένας χώρος ονομάτων που έχει οριστεί πιο πάνω ως εξής
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Δημιουργία παρουσίασης
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Παράδειγμα Aspose.Slides for .NET**
Τα αποσπάσματα κώδικα παρακάτω χρησιμοποιούν Aspose.Slides για να δημιουργήσουν μια παρουσίαση με μια απλή διαφάνεια και μια σειρά κειμένου πάνω της.

**Η παρουσίαση όπως δημιουργήθηκε με τη χρήση Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Δημιουργία παρουσίασης
Presentation pres = new Presentation();

//Η κενή διαφάνεια προστίθεται αυτόματα, όταν δημιουργείτε
//την παρουσίαση από τον προεπιλεγμένο κατασκευαστή
//Άρα, δεν χρειάζεται να προσθέσουμε καμία κενή διαφάνεια
ISlide sld = pres.Slides[1];

//Προσθήκη πλαισίου κειμένου
//Για να το προσθέσουμε, πρώτα θα προσθέσουμε ένα ορθογώνιο
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Απόκρυψη της γραμμής του
shp.LineFormat.Style = LineStyle.NotDefined;

//Στη συνέχεια προσθέτουμε ένα πλαίσιο κειμένου μέσα σε αυτό
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Ορισμός κειμένου
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Αποθήκευση του αποτελέσματος στο δίσκο
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```