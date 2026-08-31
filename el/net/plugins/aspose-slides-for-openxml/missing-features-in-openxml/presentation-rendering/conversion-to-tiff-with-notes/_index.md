---
title: Μετατροπή σε Tiff με Σημειώσεις
type: docs
weight: 10
url: /el/net/conversion-to-tiff-with-notes/
---
Το TIFF είναι μία από τις πολλές ευρέως χρησιμοποιούμενες μορφές εικόνας που υποστηρίζει το Aspose.Slides για .NET για τη μετατροπή μιας παρουσίασης με σημειώσεις σε εικόνες. Μπορείτε επίσης να δημιουργήσετε μικρογραφίες διαφάνειας στην προβολή Σημειώσεων Διαφάνειας. Παρακάτω υπάρχουν δύο αποσπάσματα κώδικα που δείχνουν πώς να δημιουργήσετε εικόνες TIFF μιας παρουσίασης στην προβολή Σημειώσεων Διαφάνειας.

Η μέθοδος **Save** που εκτίθεται από την κλάση **Presentation** μπορεί να χρησιμοποιηθεί για τη μετατροπή ολόκληρης της παρουσίασης στην προβολή Σημειώσεων Διαφάνειας σε TIFF. Μπορείτε επίσης να δημιουργήσετε μια μικρογραφία διαφάνειας στην προβολή Σημειώσεων Διαφάνειας για μεμονωμένες διαφάνειες.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation(srcFileName))
{
    //Τοποθετήστε τις σημειώσεις ομιλητή κάτω από κάθε αποδιδόμενη διαφάνεια
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Αποθήκευση της παρουσίασης σε TIFF με σημειώσεις
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)