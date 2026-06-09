---
title: Αυτοματοποιήστε την τοπικοποίηση παρουσιάσεων σε .NET
linktitle: Τοπικοποίηση Παρουσίασης
type: docs
weight: 100
url: /el/net/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αυτοματοποιήστε την τοπικοποίηση διαφανειών PowerPoint και OpenDocument σε .NET με το Aspose.Slides, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα C# και συμβουλές για ταχύτερη παγκόσμια κυκλοφορία."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να αντιστοιχίσετε ένα αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή Γλώσσας για Παρουσίαση και Κείμενο Σχήματος**
- Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.
- Προσθέστε κάποιο κείμενο στο TextFrame.
- Ορισμός του Language Id στο κείμενο.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Ενεργοποιεί το Language ID αυτόματη μετάφραση κειμένου;**

Όχι. Το [LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/) στο Aspose.Slides αποθηκεύει τη γλώσσα για έλεγχο ορθογραφίας και γραμματικής, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που κατανοεί το PowerPoint για τον έλεγχο.

**Επηρεάζει το Language ID τη συσκοτάτωση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το [LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/) προορίζεται για έλεγχο. Η ποιότητα της συσκότωσης και η αναδίπλωση γραμμής εξαρτώνται κυρίως από τη διαθεσιμότητα των [σωστές γραμματοσειρές](/slides/el/net/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για να διασφαλίσετε σωστή απόδοση, κάντε διαθέσιμες τις απαραίτητες γραμματοσειρές, ρυθμίστε τους [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/net/font-substitution/) και/ή [ενσωμάτωση γραμματοσειρών](/slides/el/net/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες εντός μιας παραγράφου;**

Ναι. Το [LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/) εφαρμόζεται στο επίπεδο του τμήματος κειμένου, έτσι μια ενιαία παράγραφος μπορεί να συνδυάσει πολλαπλές γλώσσες με διαφορετικές ρυθμίσεις ελέγχου.