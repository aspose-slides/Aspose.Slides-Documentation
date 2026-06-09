---
title: Άνοιγμα παρουσίασης σε VSTO και Aspose.Slides
type: docs
weight: 120
url: /el/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Παρακάτω είναι το απόσπασμα κώδικα για το άνοιγμα μιας παρουσίασης:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET παρέχει την κλάση **Presentation** που χρησιμοποιείται για το άνοιγμα μιας υπάρχουσας παρουσίασης. Προσφέρει μερικούς υπερφορτωμένους κατασκευαστές και μπορούμε να χρησιμοποιήσουμε έναν από τους κατάλληλους κατασκευαστές της κλάσης **Presentation** για να δημιουργήσουμε το αντικείμενό της με βάση μια υπάρχουσα παρουσίαση. Στο παρακάτω παράδειγμα, περνάμε το όνομα του αρχείου παρουσίασης (που θα ανοίξει) στον κατασκευαστή της κλάσης Presentation. Αφού το αρχείο ανοίξει, λαμβάνουμε τον συνολικό αριθμό των διαφάνειων που περιέχονται στην παρουσίαση για να τον εμφανίσουμε στην οθόνη.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Λήψη Εκτελέσιμου Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Λήψη Δείγματικού Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)