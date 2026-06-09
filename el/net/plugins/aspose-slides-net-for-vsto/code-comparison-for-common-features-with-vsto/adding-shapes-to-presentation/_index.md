---
title: Προσθήκη Σχημάτων στην Παρουσίαση
type: docs
weight: 30
url: /el/net/adding-shapes-to-presentation/
---
## **VSTO**
Παρακάτω βρίσκεται το απόσπασμα κώδικα για την προσθήκη σχήματος γραμμής:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Για να προσθέσετε μια απλή ευθεία γραμμή σε μία επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Δείκτη της
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που παρέχεται από το αντικείμενο Shapes
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

``` csharp

   //Δημιουργία της κλάσης Prseetation που αντιπροσωπεύει το PPTX

  Presentation pres = new Presentation();

  //Αποκτήστε την πρώτη διαφάνεια

  ISlide slide = pres.Slides[0];

  //Προσθέστε ένα AutoShape τύπου γραμμής

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Λήψη Εκτελέσιμου Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Λήψη Δειγματικού Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)