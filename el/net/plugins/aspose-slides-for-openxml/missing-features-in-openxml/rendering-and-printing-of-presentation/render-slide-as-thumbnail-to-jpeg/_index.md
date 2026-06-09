---
title: Απόδοση διαφάνειας ως μικρογραφία σε JPEG
type: docs
weight: 60
url: /el/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης που περιλαμβάνουν διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, κάποιες φορές, οι προγραμματιστές μπορεί να χρειαστεί να προβάλλουν τις διαφάνειες ως εικόνες χρησιμοποιώντας τον αγαπημένο τους προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides for .NET σας βοηθά να δημιουργήσετε εικόνες μικρογραφιών των διαφανειών.

Για να δημιουργήσετε τη μικρογραφία οποιασδήποτε επιθυμητής διαφάνειας χρησιμοποιώντας το Aspose.Slides for .NET:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης **Presentation**.
1. Αποκτήστε την αναφορά σε οποιαδήποτε επιθυμητή διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας σε καθορισμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Δημιουργία στιγμιότυπου της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
using (Presentation pres = new Presentation(srcFileName))
{
    //Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];

    //Δημιουργία εικόνας πλήρους κλίμακας
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)