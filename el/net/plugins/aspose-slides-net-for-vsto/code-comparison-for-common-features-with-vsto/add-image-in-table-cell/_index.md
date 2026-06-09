---
title: Προσθήκη εικόνας σε κελί πίνακα
type: docs
weight: 10
url: /el/net/add-image-in-table-cell/
---
## **VSTO**
Παρακάτω είναι ο κώδικας για την προσθήκη εικόνας σε κελί πίνακα:

``` csharp

    //Ανοίξτε την κλάση Presentation που περιέχει τον πίνακα

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Αποκτήστε την πρώτη διαφάνεια

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Το Aspose.Slides για .NET παρέχει το πιο απλό API για τη δημιουργία πινάκων με τον ευκολότερο τρόπο. Για να προσθέσετε εικόνα σε κελί πίνακα κατά τη δημιουργία ενός νέου πίνακα, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Καθορίστε πίνακα στηλών με Πλάτος
- Καθορίστε πίνακα γραμμών με Ύψος
- Προσθέστε έναν Πίνακα στη διαφάνεια χρησιμοποιώντας τη μέθοδο AddTable που εκτίθεται από το αντικείμενο IShapes
- Δημιουργήστε ένα αντικείμενο Bitmap για να κρατήσει το αρχείο εικόνας
- Προσθέστε την εικόνα Bitmap στο αντικείμενο IPPImage
- Ορίστε τη μορφή γεμίσματος του κελιού του πίνακα ως Εικόνα
- Προσθέστε την εικόνα στο πρώτο κελί του πίνακα
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Αποκτήστε την πρώτη διαφάνεια

  ISlide sld = MyPresentation.Slides[0];

  //Δημιουργία αντικειμένου Bitmap Image για την αποθήκευση του αρχείου εικόνας

  using IImage image = Images.FromFile(ImageFile);

  //Δημιουργία αντικειμένου IPPImage χρησιμοποιώντας το αντικείμενο bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Προσθήκη εικόνας στο πρώτο κελί του πίνακα

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Αποθήκευση PPTX στο δίσκο

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Λήψη Εκτελέσιμου Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)