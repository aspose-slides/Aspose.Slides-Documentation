---
title: Απόδοση ως Tiff
type: docs
weight: 30
url: /el/net/rendered-as-tiff/
---
Η μορφή TIFF είναι γνωστή για την ευελιξία της να φιλοξενεί πολυσελίδες εικόνες και δεδομένα. Λαμβάνοντας υπόψη τη σημασία και τη δημοτικότητα της μορφής TIFF, το Aspose.Slides for .NET παρέχει υποστήριξη για τη μετατροπή παρουσιάσεων σε έγγραφο TIFF.
Αυτό το άρθρο εξηγεί πώς διαφορετικές επιλογές εξαγωγής TIFF:

- Μετατροπή Παρουσίασης σε TIFF με προεπιλεγμένο μέγεθος.
- Μετατροπή Παρουσίασης σε TIFF με προσαρμοσμένο μέγεθος.

Η μέθοδος **Save** που εκτίθεται από την κλάση **Presentation** μπορεί να κληθεί από τους προγραμματιστές για να μετατρέψουν ολόκληρη την παρουσίαση σε έγγραφο **TIFF**. Επιπλέον, η κλάση TiffOptions εκθέτει την ιδιότητα ImageSize που επιτρέπει στον προγραμματιστή να ορίσει το μέγεθος της εικόνας εάν απαιτείται.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

using (Presentation pres = new Presentation(srcFileName))

{

    //Αποθηκεύει την παρουσίαση σε έγγραφο TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Λήψη Παραδείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)