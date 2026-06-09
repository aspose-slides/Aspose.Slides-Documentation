---
title: Μετατροπή σε PDF
type: docs
weight: 30
url: /el/net/conversion-to-pdf/
---
Τα έγγραφα PDF χρησιμοποιούνται ευρέως ως τυπική μορφή ανταλλαγής εγγράφων μεταξύ οργανισμών, κυβερνητικών τομέων και ιδιωτών. Είναι μια δημοφιλής μορφή, επομένως συχνά ζητείται από τους προγραμματιστές να μετατρέπουν αρχεία παρουσιάσεων Microsoft PowerPoint σε έγγραφα PDF. Αναγνωρίζοντας αυτή τη δυνατότητα, το Aspose.Slides for .NET υποστηρίζει τη μετατροπή παρουσιάσεων σε έγγραφα PDF χωρίς τη χρήση άλλου στοιχείου.

**Aspose.Slides for .NET** προσφέρει την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης. Η κλάση **Presentation** εκθέτει τη μέθοδο Save η οποία μπορεί να κληθεί για τη μετατροπή ολόκληρης της παρουσίασης σε έγγραφο **PDF**. Η κλάση **PdfOptions** παρέχει επιλογές για τη δημιουργία του **PDF**, όπως JpegQuality, TextCompression, Compliance και άλλες. Αυτές οι επιλογές μπορούν να χρησιμοποιηθούν για την επίτευξη του επιθυμητού προτύπου PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation(srcFileName);

//Αποθηκεύστε την παρουσίαση σε PDF με τις προεπιλεγμένες επιλογές

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Λήψη παραδείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)