---
title: Μετατροπή Παρουσίασης σε XPS
type: docs
weight: 60
url: /el/net/convert-presentation-to-xps/
---
**XPS** μορφή χρησιμοποιείται επίσης ευρέως για ανταλλαγή δεδομένων. Το Aspose.Slides για .NET λαμβάνει υπόψη τη σημασία του και παρέχει ενσωματωμένη υποστήριξη για τη μετατροπή μιας παρουσίασης σε έγγραφο **XPS**.

Η μέθοδος **Save** που εκτίθεται από την κλάση Presentation μπορεί να χρησιμοποιηθεί για τη μετατροπή ολόκληρης της παρουσίασης σε έγγραφο **XPS**. Επιπλέον, η κλάση **XpsOptions** εκθέτει την ιδιότητα **SaveMetafileAsPng** που μπορεί να οριστεί σε true ή false ανάλογα με τις απαιτήσεις.
## **Παράδειγμα**

``` 
 //Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

Presentation pres = new Presentation("Conversion.ppt");

//Αποθήκευση της παρουσίασης σε έγγραφο TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Λήψη Εκτελούμενου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Μετατροπή Παρουσιάσεων PowerPoint σε XPS στο .NET](/slides/el/net/convert-powerpoint-to-xps/).

{{% /alert %}}