---
title: Προσθήκη Πλαισίου Εικόνας στην Παρουσίαση
type: docs
weight: 50
url: /el/net/add-picture-frame-to-presentation/
---
## **VSTO**
Ακολουθεί ο κώδικας για την προσθήκη εικόνας σε παρουσίαση VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Για να προσθέσετε ένα απλό πλαίσιο εικόνας στη διαφάνειά σας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης Presentation.
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.
1. Δημιουργήστε ένα αντικείμενο Image προσθέτοντας μια εικόνα στη συλλογή Images που συσχετίζεται με το αντικείμενο Presentation και θα χρησιμοποιηθεί για τη γέμιση του Shape.
1. Υπολογίστε το πλάτος και το ύψος της εικόνας.
1. Δημιουργήστε ένα PictureFrame σύμφωνα με το πλάτος και το ύψος της εικόνας χρησιμοποιώντας τη μέθοδο AddPictureFrame που εκτίθεται από το αντικείμενο Shapes που συσχετίζεται με τη διαφάνεια που ανακλήθηκε.
1. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Τα παραπάνω βήματα υλοποιούνται στο παρακάτω παράδειγμα.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το PPTX

  Presentation pres = new Presentation();

  //Λήψη της πρώτης διαφάνειας

  ISlide sld = pres.Slides[0];

  //Δημιουργία της κλάσης ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Προσθήκη πλαισίου εικόνας με ύψος και πλάτος ίσα με την εικόνα

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)