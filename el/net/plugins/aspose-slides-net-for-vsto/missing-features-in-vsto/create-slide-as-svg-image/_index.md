---
title: Δημιουργία Διαφάνειας ως Εικόνα SVG
type: docs
weight: 70
url: /el/net/create-slide-as-svg-image/
---
Για να δημιουργήσετε μια εικόνα SVG από οποιαδήποτε επιθυμητή διαφάνεια με Aspose.Slides.Pptx για .NET, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
- Αποκτήστε την αναφορά της επιθυμητής διαφάνειας χρησιμοποιώντας το ID ή το ευρετήριο της.
- Λάβετε την εικόνα SVG σε μια ροή μνήμης.
- Αποθηκεύστε τη ροή μνήμης σε αρχείο.
## **Παράδειγμα**

```

 //Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{
   //Πρόσβαση στη δεύτερη διαφάνεια
   ISlide sld = pres.Slides[1];
   //Δημιουργία αντικειμένου ροής μνήμης
   MemoryStream SvgStream = new MemoryStream();
   //Δημιουργία εικόνας SVG της διαφάνειας και αποθήκευση στη ροή μνήμης
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //Αποθήκευση ροής μνήμης σε αρχείο
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
}

SvgStream.Close();

``` 
## **Λήψη Εκτελούμενου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Για περισσότερες λεπτομέρειες, επισκεφθείτε [Απόδοση Διαφανειών Παρουσίασης ως Εικόνες SVG σε .NET](/slides/el/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}