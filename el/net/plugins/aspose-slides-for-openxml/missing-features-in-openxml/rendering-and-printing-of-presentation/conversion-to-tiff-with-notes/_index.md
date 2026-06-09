---
title: Μετατροπή σε Tiff με Σημειώσεις
type: docs
weight: 10
url: /el/net/conversion-to-tiff-with-notes/
---
TIFF είναι μία από τις πολλές ευρέως χρησιμοποιούμενες μορφές εικόνας που το Aspose.Slides για .NET υποστηρίζει για τη μετατροπή μιας παρουσίασης με σημειώσεις σε εικόνες. Μπορείτε επίσης να δημιουργήσετε μικρογραφίες διαφανειών στην προβολή Σημειώσεων Διαφάνειας. Παρακάτω υπάρχουν δύο αποσπάσματα κώδικα που δείχνουν πώς να δημιουργήσετε εικόνες TIFF μιας παρουσίασης στην προβολή Σημειώσεων Διαφάνειας.

Η μέθοδος **Save** που εκτίθεται από την κλάση **Presentation** μπορεί να χρησιμοποιηθεί για τη μετατροπή ολόκληρης της παρουσίασης στην προβολή Σημειώσεων Διαφάνειας σε TIFF. Μπορείτε επίσης να δημιουργήσετε μικρογραφία διαφάνειας στην προβολή Σημειώσεων Διαφάνειας για μεμονωμένες διαφάνειες.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(srcFileName);

//Αποθήκευση της παρουσίασης σε TIFF με σημειώσεις

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Λήψη Παράδειγμα Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)