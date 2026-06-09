---
title: Εξαγωγή αρχείων πολυμέσων σε αρχείο HTML
type: docs
weight: 80
url: /el/net/export-media-files-into-html-file/
---
Για να εξάγετε αρχεία πολυμέσων σε HTML, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια περίπτωση της κλάσης Presentation
- Αποκτήστε αναφορά στη διαφάνεια
- Ορίστε το εφέ μετάβασης
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, έχουμε εξάγει τα αρχεία πολυμέσων σε HTML.
## **Παράδειγμα**
``` 

 //Φόρτωση παρουσίασης

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Ρύθμιση επιλογών HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Αποθήκευση του αρχείου

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Λήψη Εκτελούμενου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)