---
title: Απόδοση ως Tiff με Διάσταση που ορίζεται από το Χρήστη
type: docs
weight: 40
url: /el/net/rendered-as-tiff-by-user-defined-dimension/
---
Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο TIFF με προσαρμοσμένο μέγεθος εικόνας χρησιμοποιώντας την κλάση **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Δημιουργεί αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(srcFileName);

//Δημιουργεί την κλάση TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Ορισμός τύπου συμπίεσης

opts.CompressionType = TiffCompressionTypes.Default;

//Τύποι συμπίεσης

//Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).

//None - Ορίζει ότι δεν υπάρχει συμπίεση.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - εξαρτάται από τον τύπο συμπίεσης και δεν μπορεί να οριστεί χειροκίνητα.

//Resolution unit - είναι πάντα ίσο με "2" (σημεία ανά ίντσα)

//Ορισμός DPI εικόνας

opts.DpiX = 200;

opts.DpiY = 100;

//Ορισμός μεγέθους εικόνας

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)