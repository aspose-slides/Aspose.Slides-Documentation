---
title: Προσθήκη πλαισίου εικόνας με κίνηση σε VSTO και Aspose.Slides
type: docs
weight: 20
url: /el/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Τα παρακάτω παραδείγματα κώδικα δημιουργούν μια παρουσίαση με μία διαφάνεια, προσθέτουν μια εικόνα με πλαίσιο εικόνας και εφαρμόζουν κίνηση σε αυτήν.
## **VSTO**
Χρησιμοποιώντας VSTO, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση.
1. Προσθέστε μια κενή διαφάνεια.
1. Προσθέστε ένα σχήμα εικόνας στη διαφάνεια.
1. Εφαρμόστε κίνηση στην εικόνα.
1. Γράψτε την παρουσίαση στο δίσκο.

``` csharp

 //Δημιουργία κενής παρουσίασης

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Προσθήκη κενής διαφάνειας

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Προσθήκη πλαισίου εικόνας

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Εφαρμογή κίνησης στο πλαίσιο εικόνας

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Αποθήκευση παρουσίασης

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Χρησιμοποιώντας το Aspose.Slides για .NET, εκτελέστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε μια εικόνα σε μια συλλογή εικόνων.
1. Προσθέστε ένα σχήμα εικόνας στη διαφάνεια.
1. Εφαρμόστε κίνηση στην εικόνα.
1. Γράψτε την παρουσίαση στο δίσκο.

``` csharp

 //Δημιουργία κενής παρουσίασης

Presentation pres = new Presentation();

 //Πρόσβαση στην πρώτη διαφάνεια

Slide slide = pres.GetSlideByPosition(1);

 //Προσθήκη του αντικειμένου εικόνας στη συλλογή εικόνων της παρουσίασης

Picture pic = new Picture(pres, "pic.jpeg");

 //Αφού το αντικείμενο εικόνας προστεθεί, η εικόνα δίνεται ένα μοναδικό αναγνωριστικό εικόνας

int picId = pres.Pictures.Add(pic);

 //Προσθήκη πλαισίου εικόνας

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

 //Εφαρμογή κίνησης στο πλαίσιο εικόνας

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

 //Αποθήκευση παρουσίασης

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)