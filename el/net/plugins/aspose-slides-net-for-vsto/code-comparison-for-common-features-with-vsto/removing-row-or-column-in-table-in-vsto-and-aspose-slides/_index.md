---
title: Αφαίρεση γραμμής ή στήλης σε Πίνακα στο VSTO και Aspose.Slides
type: docs
weight: 130
url: /el/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Παρακάτω βρίσκεται ο κώδικας για την αφαίρεση γραμμών ή στηλών από πίνακα χρησιμοποιώντας το VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Λάβετε την πρώτη διαφάνεια

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Το Aspose.Slides για .NET παρέχει το απλούστατο API για τη δημιουργία πινάκων με τον πιο εύκολο τρόπο. Για να δημιουργήσετε έναν πίνακα σε μια διαφάνεια και να εκτελέσετε κάποιες βασικές λειτουργίες στον πίνακα, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Ορίστε έναν πίνακα στηλών με το Πλάτος
- Ορίστε έναν πίνακα γραμμών με το Ύψος
- Προσθέστε έναν πίνακα στη διαφάνεια χρησιμοποιώντας τη μέθοδο AddTable που εκτίθεται από το αντικείμενο IShapes
- Αφαιρέστε τη γραμμή του πίνακα
- Αφαιρέστε τη στήλη του πίνακα
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Λάβετε την πρώτη διαφάνεια

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Λήψη Εκτελέσιμου Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)