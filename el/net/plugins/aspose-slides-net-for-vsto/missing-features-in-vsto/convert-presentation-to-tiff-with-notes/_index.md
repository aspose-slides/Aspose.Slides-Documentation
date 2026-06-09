---
title: Μετατροπή Παρουσίασης σε Tiff με Σημειώσεις
type: docs
weight: 50
url: /el/net/convert-presentation-to-tiff-with-notes/
---
Το TIFF είναι μία από τις πολλές ευρέως χρησιμοποιούμενες μορφές εικόνας που υποστηρίζει το Aspose.Slides for .NET για τη μετατροπή μιας παρουσίασης με σημειώσεις σε εικόνες. Μπορείτε επίσης να δημιουργήσετε μικρογραφίες διαφάνειας στην προβολή Σημειώσεων Διαφάνειας. Παρακάτω υπάρχουν δύο αποσπάσματα κώδικα που δείχνουν πώς να δημιουργήσετε εικόνες TIFF μιας παρουσίασης στην προβολή Σημειώσεων Διαφάνειας.

Η μέθοδος [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/methods/save) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) μπορεί να χρησιμοποιηθεί για τη μετατροπή ολόκληρης της παρουσίασης στην προβολή Σημειώσεων Διαφάνειας σε TIFF. Μπορείτε επίσης να δημιουργήσετε μια μικρογραφία διαφάνειας στην προβολή Σημειώσεων Διαφάνειας για μεμονωμένες διαφάνειες.
## **Παράδειγμα**

``` 

  //Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

 Presentation pres = new Presentation("Conversion.pptx");

 //Αποθήκευση της παρουσίασης σε TIFF με σημειώσεις

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Λήψη Εκτελέσιμου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Μετατροπή Παραστάσεων PowerPoint σε TIFF με Σημειώσεις στο .NET](/slides/el/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}