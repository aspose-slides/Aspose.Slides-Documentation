---
title: Μετατροπή από PPT σε μορφή PPTX στο Aspose.Slides
type: docs
weight: 10
url: /el/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** για .NET τώρα διευκολύνει τους προγραμματιστές να έχουν πρόσβαση στο PPT χρησιμοποιώντας την κλάση Presentation και να το μετατρέπουν στην αντίστοιχη μορφή PPTX. Προς το παρόν, υποστηρίζει μερική μετατροπή του PPT σε PPTX. Για περισσότερες λεπτομέρειες σχετικά με τα χαρακτηριστικά που υποστηρίζονται και δεν υποστηρίζονται στη μετατροπή PPT σε PPTX, παρακαλούμε προχωρήστε σε αυτόν τον σύνδεσμο τεκμηρίωσης.

**Aspose.Slides** για .NET προσφέρει την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης PPTX. Η κλάση Presentation μπορεί τώρα επίσης να έχει πρόσβαση σε PPT μέσω της Presentation όταν το αντικείμενο δημιουργείται.

``` csharp

 //Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Αποθήκευση της παρουσίασης PPTX σε μορφή PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Λήψη Δείγματος Κώδικα**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)