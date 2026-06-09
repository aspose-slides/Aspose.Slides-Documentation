---
title: Μετατροπή σε HTML
type: docs
weight: 20
url: /el/net/conversion-to-html/
---
**HTML** είναι μία από τις αρκετές ευρέως χρησιμοποιούμενες μορφές για ανταλλαγή δεδομένων. **Aspose.Slides for .NET** παρέχει υποστήριξη για τη μετατροπή μιας παρουσίασης σε HTML. Παρακάτω είναι το απόσπασμα κώδικα που δείχνει πώς.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Αποθήκευση της παρουσίασης σε HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)