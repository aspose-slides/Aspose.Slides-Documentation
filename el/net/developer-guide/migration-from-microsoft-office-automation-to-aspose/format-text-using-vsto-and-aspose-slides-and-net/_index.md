---
title: Μορφοποίηση Κειμένου Χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 30
url: /el/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- μορφοποίηση κειμένου
- μετανάστευση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταβείτε από την αυτοματοποίηση του Microsoft Office στο Aspose.Slides για .NET και μορφοποιήστε το κείμενο σε παρουσιάσεις PowerPoint (PPT, PPTX) με ακριβή έλεγχο."
---
{{% alert color="info" %}} 
Μερικές φορές, χρειάζεται να μορφοποιήσετε το κείμενο στις διαφάνειες προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να διαβάσετε μια δείγμα παρουσίασης με κάποιο κείμενο στην πρώτη διαφάνεια χρησιμοποιώντας είτε [VSTO](/slides/el/net/format-text-using-vsto-and-aspose-slides-and-net/) και [Aspose.Slides for .NET](/slides/el/net/format-text-using-vsto-and-aspose-slides-and-net/). Ο κώδικας μορφοποιεί το κείμενο στο τρίτο πλαίσιο κειμένου της διαφάνειας ώστε να μοιάζει με το κείμενο στο τελευταίο πλαίσιο κειμένου.
{{% /alert %}} 
## **Μορφοποίηση Κειμένου**
Οι μέθοδοι VSTO και Aspose.Slides ακολουθούν τα παρακάτω βήματα:

1. Ανοίξτε την πηγή παρουσίασης.
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσπελάστε το τρίτο πλαίσιο κειμένου.
1. Αλλάξτε τη μορφοποίηση του κειμένου στο τρίτο πλαίσιο κειμένου.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

Οι στιγμιότυπα οθόνης παρακάτω δείχνουν τη δείγμα διαφάνειας πριν και μετά την εκτέλεση του κώδικα VSTO και Aspose.Slides για .NET.

**Η παρουσίαση εισόδου** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Παράδειγμα Κώδικα VSTO**
Ο παρακάτω κώδικας δείχνει πώς να επαναμορφοποιήσετε το κείμενο σε μια διαφάνεια χρησιμοποιώντας VSTO.

**Το κείμενο επαναμορφοποιημένο με VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Σημείωση: PowerPoint είναι ένας χώρος ονομάτων που έχει οριστεί παραπάνω όπως αυτό
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Άνοιγμα της παρουσίασης
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Πρόσβαση στην πρώτη διαφάνεια
PowerPoint.Slide slide = pres.Slides[1];

//Πρόσβαση στο τρίτο σχήμα
PowerPoint.Shape shp = slide.Shapes[3];

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και ύψος σε 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Με έντονη γραφή
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Με πλάγια γραφή
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Αλλαγή χρώματος κειμένου
txtRange.Font.Color.RGB = 0x00CC3333;

//Αλλαγή χρώματος φόντου σχήματος
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Μετακίνηση οριζόντια
shp.Left -= 70;

//Αποθήκευση εξόδου στο δίσκο
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Παράδειγμα Aspose.Slides για .NET**
Για να μορφοποιήσετε κείμενο με το Aspose.Slides, προσθέστε τη γραμματοσειρά πριν μορφοποιήσετε το κείμενο.

**Η έξοδος παρουσίασης που δημιουργήθηκε με το Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Άνοιγμα της παρουσίασης
Presentation pres = new Presentation("source.ppt");

//Πρόσβαση στην πρώτη διαφάνεια
ISlide slide = pres.Slides[0];

//Πρόσβαση στο τρίτο σχήμα
IShape shp = slide.Shapes[2];

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και ύψους σε 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Με έντονη γραφή
port.PortionFormat.FontBold = NullableBool.True;

//Με πλάγια γραφή
port.PortionFormat.FontItalic = NullableBool.True;

//Αλλαγή χρώματος κειμένου
//Ορισμός χρώματος γραμματοσειράς
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Αλλαγή χρώματος φόντου σχήματος
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Αποθήκευση εξόδου στο δίσκο
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```