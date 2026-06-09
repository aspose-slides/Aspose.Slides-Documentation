---
title: Μετατροπή εγγράφου OpenOffice
type: docs
weight: 30
url: /el/net/conversion-of-openoffice-document/
---
Το Aspose.Slides για .NET προσφέρει την κλάση **Presentation** που αντιπροσωπεύει ένα αρχείο παρουσίασης. Η κλάση **Presentation** μπορεί τώρα επίσης να έχει πρόσβαση σε **ODP** μέσω του κατασκευαστή Presentation όταν δημιουργείται το αντικείμενο.

Παρακάτω είναι το παράδειγμα μετατροπής από ODP σε PPT/PPTX.
## **Παράδειγμα**
```

 //Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{
   //Αποθήκευση της παρουσίασης PPTX σε μορφή PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);
}
``` 

Παρακάτω είναι το παράδειγμα μετατροπής από PPT/PPTX σε ODP.
## **Παράδειγμα**
``` 

 //Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Αποθήκευση της παρουσίασης PPTX σε μορφή PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);
}
``` 
## **Λήψη Εκτελέσιμου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)