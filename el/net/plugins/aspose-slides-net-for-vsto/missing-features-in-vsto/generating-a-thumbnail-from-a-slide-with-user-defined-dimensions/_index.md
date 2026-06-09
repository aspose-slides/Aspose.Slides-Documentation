---
title: Δημιουργία μικρογραφίας από διαφάνεια με διαστάσεις καθορισμένες από τον χρήστη
type: docs
weight: 100
url: /el/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Για να δημιουργήσετε μικρογραφία (thumbnail) οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το Aspose.Slides for .NET:

- Δημιουργήστε μια παρουσία της κλάσης Presentation.
- Αποκτήστε την αναφορά οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το ID ή το δείκτη της.
- Λάβετε τους συντελεστές κλιμάκωσης X και Y με βάση τις διαστάσεις X και Y που ορίζονται από τον χρήστη.
- Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας σε καθορισμένη κλίμακα.
- Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.
## **Παράδειγμα**
```cs
//Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    //Διαστάσεις καθορισμένες από τον χρήστη
    int desiredX = 1200;
    int desiredY = 800;

    //Λήψη κλιμακωμένης τιμής του X και του Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Δημιουργία εικόνας πλήρους κλίμακας
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Λήψη Εκτελούμενου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Μετατροπή Διαφάνειας](/slides/el/net/convert-slide/).

{{% /alert %}}