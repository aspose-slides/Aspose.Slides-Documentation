---
title: Προσθήκη Πλαισίων Εικόνας με Κίνηση Χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Πλαίσια Εικόνας με Κίνηση
type: docs
weight: 60
url: /el/net/adding-picture-frame-with-animation/
keywords:
- πλαίσιο εικόνας
- προσθήκη εικόνας
- προσθήκη εικόνας
- εικόνα με κίνηση
- εικόνα με κίνηση
- μετεγκατάσταση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταβείτε από την αυτοματοποίηση του Microsoft Office στο Aspose.Slides για .NET και κινήστε τα πλαίσια εικόνας στις διαφάνειες PowerPoint (PPT, PPTX) με καθαρό κώδικα C#."
---
{{% alert color="primary" %}} 

Τα πλαίσια εικόνας εφαρμόζονται σε σχήματα ή εικόνες στο Microsoft PowerPoint για να περιβάλλουν τις εικόνες σε μια παρουσίαση. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας και να εφαρμόσετε κίνηση σε αυτό προγραμματιστικά χρησιμοποιώντας πρώτα [VSTO 2008](/slides/el/net/adding-picture-frame-with-animation/) και μετά [Aspose.Slides for .NET](/slides/el/net/adding-picture-frame-with-animation/). Πρώτα, σας δείχνουμε πώς να εφαρμόσετε ένα πλαίσιο και κίνηση χρησιμοποιώντας το VSTO 2008. Στη συνέχεια, σας δείχνουμε πώς να εκτελέσετε τα ίδια βήματα χρησιμοποιώντας το Aspose.Slides for .NET.

{{% /alert %}} 
## **Προσθήκη Πλαισίων Εικόνας με Κίνηση**
Τα παρακάτω δείγματα κώδικα δημιουργούν μια παρουσίαση με μια διαφάνεια, προσθέτουν μια εικόνα με πλαίσιο εικόνας και εφαρμόζουν κίνηση σε αυτήν.
### **Παράδειγμα VSTO 2008**
Χρησιμοποιώντας το VSTO 2008, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση.
1. Προσθέστε μια κενή διαφάνεια.
1. Προσθέστε ένα σχήμα εικόνας στη διαφάνεια.
1. Εφαρμόστε κίνηση στην εικόνα.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

**Η παρουσίαση εξόδου, δημιουργημένη με VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Δημιουργία κενής παρουσίασης
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Προσθήκη κενής διαφάνειας
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Προσθήκη πλαισίου εικόνας
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Εφαρμογή κίνησης στο πλαίσιο εικόνας
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Αποθήκευση παρουσίασης
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Παράδειγμα Aspose.Slides for .NET**
Χρησιμοποιώντας το Aspose.Slides for .NET, εκτελέστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε μια εικόνα στη συλλογή εικόνων.
1. Προσθέστε ένα σχήμα εικόνας στη διαφάνεια.
1. Εφαρμόστε κίνηση στην εικόνα.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

**Η παρουσίαση εξόδου, δημιουργημένη με Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Δημιουργία κενής παρουσίασης
using (Presentation pres = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];

    // Προσθήκη εικόνας στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Προσθήκη πλαισίου εικόνας του οποίου το ύψος και το πλάτος ταιριάζουν με το ύψος και το πλάτος της εικόνας
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Λήψη της κύριας ακολουθίας κίνησης της διαφάνειας
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Προσθήκη του εφέ Πτήση από αριστερά στο πλαίσιο εικόνας
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Αποθήκευση της παρουσίασης
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```