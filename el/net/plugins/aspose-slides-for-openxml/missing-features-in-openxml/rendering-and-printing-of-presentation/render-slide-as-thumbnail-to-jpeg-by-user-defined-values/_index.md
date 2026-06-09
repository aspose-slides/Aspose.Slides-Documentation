---
title: Απόδοση διαφάνειας ως μικρογραφία σε JPEG με τιμές ορισμένες από το χρήστη
type: docs
weight: 70
url: /el/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Για να δημιουργήσετε τη μικρογραφία οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το Aspose.Slides για .NET:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης **Presentation**.
1. Αποκτήστε την αναφορά της επιθυμητής διαφάνειας χρησιμοποιώντας το ID ή το ευρετήριο της.
1. Λάβετε τους συντελεστές κλίμακας X και Y βάσει των διαστάσεων X και Y που ορίζονται από τον χρήστη.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας σε καθορισμένη κλίμακα.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation pres = new Presentation(srcFileName))
{
    //Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    //Διαστάσεις ορισμένες από το χρήστη
    int desiredX = 1200;
    int desiredY = 800;

    //Λήψη κλιμακωμένης τιμής των X και Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Δημιουργία εικόνας πλήρους κλίμακας
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)