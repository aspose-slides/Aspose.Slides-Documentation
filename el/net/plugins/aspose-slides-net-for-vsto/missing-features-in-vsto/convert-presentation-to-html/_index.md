---
title: Μετατροπή Παρουσίασης σε HTML
type: docs
weight: 40
url: /el/net/convert-presentation-to-html/
---
**HTML** είναι μία από τις πολλές ευρέως χρησιμοποιούμενες μορφές για την ανταλλαγή δεδομένων. **Aspose.Slides for .NET** παρέχει υποστήριξη για τη μετατροπή μιας παρουσίασης σε HTML. Ακολουθεί ένα απόσπασμα κώδικα που δείχνει πώς.
## **Παράδειγμα**
``` 

 //Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Αποθήκευση της παρουσίασης σε HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Λήψη Εκτελέσιμου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Για περισσότερες λεπτομέρειες, επισκεφθείτε [Μετατροπή Παρουσιάσεων PowerPoint σε HTML στο .NET](/slides/el/net/convert-powerpoint-to-html/).
{{% /alert %}}