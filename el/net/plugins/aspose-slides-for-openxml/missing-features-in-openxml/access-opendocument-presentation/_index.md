---
title: Πρόσβαση στην παρουσίαση OpenDocument
type: docs
weight: 10
url: /el/net/access-opendocument-presentation/
---
Το Aspose.Slides για .NET προσφέρει την κλάση **Presentation** που αντιπροσωπεύει ένα αρχείο παρουσίασης. Η κλάση **Presentation** μπορεί τώρα επίσης να έχει πρόσβαση στο **ODP** μέσω του κατασκευαστή **Presentation** όταν δημιουργείται το αντικείμενο.
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης

using (Presentation pres = new Presentation(srcFileName))

{

    //Αποθήκευση της παρουσίασης PPTX σε μορφή PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Λήψη κώδικα δείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Λήψη εκτελέσιμου παραδείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)