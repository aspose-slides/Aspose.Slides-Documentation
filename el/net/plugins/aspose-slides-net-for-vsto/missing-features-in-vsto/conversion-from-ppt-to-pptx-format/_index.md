---
title: Μετατροπή από μορφή PPT σε PPTX
type: docs
weight: 20
url: /el/net/conversion-from-ppt-to-pptx-format/
---
Το μοναδικό χαρακτηριστικό του Aspose.Slides που παρέχει ευελιξία στις μετατροπές εκδόσεων χωρίς να επηρεάζει την εργασία.
Η SaveFormat είναι μια απαρίθμηση που μπορεί να μετατρέπει το έγγραφο στις παρακάτω επεκτάσεις που δίνονται στον πίνακα.

|**Όνομα Μέλους**|**Τιμή**|**Περιγραφή**|
| :- | :- | :- |
|HTML|13||
|ODP|6||
|PDF|1||
|PDF Notes|12||
|POTM|11||
|POTX|10||
|PPS|0||
|PPSM|9||
|PPSX|4||
|PPT|0||
|PPTM|7||
|PPTX|3||
|TIFF|5||
|TiffNotes|14||
|XPS|2||

Ακολουθεί ένα απόσπασμα κώδικα που δείχνει τη μετατροπή από PPT σε PPTX· μπορείτε να το κάνετε και αντίστροφα.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX

Presentation pres = new Presentation(srcFileName);

//Αποθήκευση της παρουσίασης PPTX σε μορφή PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)