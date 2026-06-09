---
title: Διαμόρφωση κειμένου χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Διαμόρφωση κειμένου
type: docs
weight: 30
url: /el/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- διαμόρφωση κειμένου
- μετανάστευση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταναστεύστε από την αυτοματοποίηση Microsoft Office σε Aspose.Slides για .NET και διαμορφώστε το κείμενο σε παρουσιάσεις PowerPoint (PPT, PPTX) με ακριβή έλεγχο."
---
{{% alert color="primary" %}} 

Μερικές φορές, χρειάζεται να μορφοποιήσετε το κείμενο σε διαφάνειες προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να διαβάσετε μια δείγμα παρουσίασης με κείμενο στην πρώτη διαφάνεια χρησιμοποιώντας είτε [VSTO](/slides/el/net/format-text-using-vsto-and-aspose-slides-and-net/) ή [Aspose.Slides for .NET](/slides/el/net/format-text-using-vsto-and-aspose-slides-and-net/). Ο κώδικας μορφοποιεί το κείμενο στο τρίτο πλαίσιο κειμένου στη διαφάνεια ώστε να μοιάζει με το κείμενο στο τελευταίο πλαίσιο κειμένου.

{{% /alert %}} 
## **Διαμόρφωση κειμένου**
Τόσο το VSTO όσο και το Aspose.Slides ακολουθούν τα παρακάτω βήματα:

1. Ανοίξτε την πηγή της παρουσίασης.
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσπελάστε το τρίτο πλαίσιο κειμένου.
1. Αλλάξτε τη μορφοποίηση του κειμένου στο τρίτο πλαίσιο κειμένου.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

Τα στιγμιότυπα οθόνης παρακάτω δείχνουν τη δειγματική διαφάνεια πριν και μετά την εκτέλεση του κώδικα VSTO και Aspose.Slides for .NET.

**Η εισαγώμενη παρουσίαση** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Παράδειγμα κώδικα VSTO**
Ο παρακάτω κώδικας δείχνει πώς να επαναμορφώσετε το κείμενο σε μια διαφάνεια χρησιμοποιώντας VSTO.

**Το κείμενο που επαναμορφώθηκε με VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Σημείωση: Το PowerPoint είναι ένας χώρος ονομάτων που ορίσθηκε παραπάνω ως εξής
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

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και το ύψος σε 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Εντονοποίηση
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Κλίση
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Αλλαγή χρώματος κειμένου
txtRange.Font.Color.RGB = 0x00CC3333;

//Αλλαγή χρώματος φόντου σχήματος
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Επανατοποθέτηση οριζόντια
shp.Left -= 70;

//Αποθήκευση του αποτελέσματος στο δίσκο
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Παράδειγμα Aspose.Slides for .NET**
Για να μορφοποιήσετε κείμενο με Aspose.Slides, προσθέστε τη γραμματοσειρά πριν από τη μορφοποίηση του κειμένου.

**Η έξοδος παρουσίασης που δημιουργήθηκε με Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Άνοιγμα της παρουσίασης
Presentation pres = new Presentation("c:\\source.ppt");

//Πρόσβαση στην πρώτη διαφάνεια
ISlide slide = pres.Slides[0];

//Πρόσβαση στο τρίτο σχήμα
IShape shp = slide.Shapes[2];

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και το ύψος σε 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Εντονοποίηση
port.PortionFormat.FontBold = NullableBool.True;

//Κλίση
port.PortionFormat.FontItalic = NullableBool.True;

//Αλλαγή χρώματος κειμένου
//Ορισμός χρώματος γραμματοσειράς
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Αλλαγή χρώματος φόντου σχήματος
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Αποθήκευση του αποτελέσματος στο δίσκο
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```