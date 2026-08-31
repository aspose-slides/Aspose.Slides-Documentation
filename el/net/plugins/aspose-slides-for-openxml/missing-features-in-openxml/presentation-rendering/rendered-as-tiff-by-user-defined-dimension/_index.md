---
title: Αποδόθηκε ως Tiff με Διάσταση Ορισμένη από τον Χρήστη
type: docs
weight: 40
url: /el/net/rendered-as-tiff-by-user-defined-dimension/
---
Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο TIFF με προσαρμοσμένο μέγεθος εικόνας χρησιμοποιώντας την κλάση **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο Presentation
Presentation pres = new Presentation(srcFileName);

//Δημιουργία μιας κλάσης TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Ορισμός τύπου συμπίεσης
opts.CompressionType = TiffCompressionTypes.Default;

//Τύποι συμπίεσης
//Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
//None - Καθορίζει καμία συμπίεση.
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

//Αποθήκευση της παρουσίασης σε TIFF με καθορισμένο μέγεθος εικόνας
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)