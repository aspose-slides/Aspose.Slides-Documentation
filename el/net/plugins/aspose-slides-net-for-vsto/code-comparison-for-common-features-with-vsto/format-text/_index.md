---
title: Μορφοποίηση Κειμένου
type: docs
weight: 110
url: /el/net/format-text/
---
Και οι μέθοδοι VSTO και Aspose.Slides ακολουθούν τα παρακάτω βήματα:

- Ανοίξτε την πηγαία παρουσίαση.
- Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
- Αποκτήστε πρόσβαση στο τρίτο πλαίσιο κειμένου.
- Αλλάξτε τη μορφοποίηση του κειμένου στο τρίτο πλαίσιο κειμένου.
- Αποθηκεύστε την παρουσίαση στο δίσκο.
## **VSTO**
``` csharp

 //Άνοιγμα της παρουσίασης

Presentation pres = new Presentation("source.ppt");

//Προσθήκη γραμματοσειράς Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Πρόσβαση στην πρώτη διαφάνεια

Slide slide = pres.GetSlideByPosition(1);

//Πρόσβαση στο τρίτο σχήμα

Shape shp = slide.Shapes[2];

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και ύψους σε 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Κάντε το έντονο

port.FontBold = true;

//Κάντε το πλάγιο

port.FontItalic = true;

//Αλλαγή χρώματος κειμένου

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Αλλαγή χρώματος φόντου σχήματος

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Γράψτε το αποτέλεσμα στο δίσκο

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Άνοιγμα της παρουσίασης

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoTrue);

//Πρόσβαση στην πρώτη διαφάνεια

PowerPoint.Slide slide = pres.Slides[1];

//Πρόσβαση στο τρίτο σχήμα

PowerPoint.Shape shp = slide.Shapes[3];

//Αλλαγή της γραμματοσειράς του κειμένου σε Verdana και ύψους σε 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Κάντε το έντονο

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Κάντε το πλάγιο

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Αλλαγή χρώματος κειμένου

txtRange.Font.Color.RGB = 0x00CC3333;

//Αλλαγή χρώματος φόντου σχήματος

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Επανατοποθέτηση οριζόντια

shp.Left -= 70;

//Γράψτε το αποτέλεσμα στο δίσκο

pres.SaveAs("outVSTO.ppt",

    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

    Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)