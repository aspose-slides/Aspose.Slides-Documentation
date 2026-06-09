---
title: Δημιουργία Μικρογραφίας Διαφάνειας ως JPEG
type: docs
weight: 90
url: /el/net/generate-slide-thumbnail-as-jpeg/
---
Για τη δημιουργία της μικρογραφίας οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το Aspose.Slides for .NET:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
- Αποκτήστε την αναφορά οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το ID ή το ευρετήριο της.
- Λάβετε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας σε καθορισμένη κλίμακα.
- Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.
## **Παράδειγμα**
```cs
//Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Προσπελάστε την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    //Δημιουργήστε εικόνα πλήρους κλίμακας
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Λήψη Εκτελέσιμου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Μετατροπή PPT και PPTX σε JPG σε .NET](/slides/el/net/convert-powerpoint-to-jpg/).

{{% /alert %}}