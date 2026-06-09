---
title: Μετατροπή σε XPS
type: docs
weight: 40
url: /el/net/conversion-to-xps/
---
Η μορφή **XPS** χρησιμοποιείται επίσης ευρέως για ανταλλαγή δεδομένων. Το Aspose.Slides για .NET λαμβάνει υπόψη τη σημασία του και παρέχει ενσωματωμένη υποστήριξη για τη μετατροπή μιας παρουσίασης σε έγγραφο **XPS**.

Η μέθοδος **Save** που εκτίθεται από την κλάση Presentation μπορεί να χρησιμοποιηθεί για τη μετατροπή ολόκληρης της παρουσίασης σε έγγραφο **XPS**. Επιπλέον, η κλάση **XpsOptions** εκθέτει την ιδιότητα **SaveMetafileAsPng**, η οποία μπορεί να οριστεί σε true ή false ανάλογα με τις ανάγκες.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(srcFileName);

//Αποθήκευση της παρουσίασης σε έγγραφο TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Λήψη Δειγματικού Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)