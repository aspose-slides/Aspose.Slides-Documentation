---
title: Εξαγωγή αρχείων πολυμέσων σε αρχείο HTML
type: docs
weight: 40
url: /el/net/export-media-files-to-html-file/
---
Για να εξάγετε αρχεία πολυμέσων σε HTML. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά της διαφάνειας
- Ρύθμιση του εφέ μετάβασης
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, έχουμε εξάγει τα αρχεία πολυμέσων σε HTML.
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Φόρτωση παρουσίασης

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Ορισμός επιλογών HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Αποθήκευση αρχείου

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Λήψη δείγματος κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Λήψη εκτελέσιμου παραδείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Εξαγωγή αρχείων πολυμέσων σε αρχείο html](/slides/el/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}