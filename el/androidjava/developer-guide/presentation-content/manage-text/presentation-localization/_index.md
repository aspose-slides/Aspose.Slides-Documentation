---
title: Αυτοματοποίηση Τοπικοποίησης Παρουσίασης σε Android
linktitle: Τοπικοποίηση Παρουσίασης
type: docs
weight: 100
url: /el/androidjava/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αυτοματοποίηση της τοπικοποίησης διαφανειών PowerPoint και OpenDocument σε Java με Aspose.Slides για Android, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για ταχύτερη παγκόσμια ανάπτυξη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να εκχωρήσετε αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή Γλώσσας για Παρουσίαση και Κείμενο Σχήματος**
- Δημιουργήστε μια παρουσία της κλάσης[Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
- Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα[IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) τύπου[Rectangle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσθέστε κάποιο κείμενο στο TextFrame.
- [Ορισμός Αναγνωριστικού Γλώσσας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) στο κείμενο.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Διευθύνει το αναγνωριστικό γλώσσας (Language ID) αυτόματη μετάφραση κειμένου;**

Όχι. Το[Αναγνωριστικό Γλώσσας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) στο Aspose.Slides αποθηκεύει τη γλώσσα για ορθογραφικό και γραμματικό έλεγχο, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που καταλαβαίνει το PowerPoint για έλεγχο.

**Επηρεάζει το αναγνωριστικό γλώσσας (Language ID) τη συλλαβιστική και τη διάσπαση γραμμών κατά την απόδοση;**

Στο Aspose.Slides, το[αναγνωριστικό γλώσσας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) χρησιμοποιείται για έλεγχο. Η ποιότητα συλλαβισμού και η αναδίπλωση γραμμών εξαρτώνται κυρίως από τη διαθεσιμότητα των[σωστών γραμματοσειρών](/slides/el/androidjava/powerpoint-fonts/) και των ρυθμίσεων διάταξης/αναγκασμού γραμμής για το σύστημα γραφής. Για να διασφαλιστεί η σωστή απόδοση, κάντε τις απαιτούμενες γραμματοσειρές διαθέσιμες, ρυθμίστε τους[κανόνες αντικατάστασης γραμματοσειρών](/slides/el/androidjava/font-substitution/), και/ή[ενσωματώστε γραμματοσειρές](/slides/el/androidjava/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες μέσα σε μία παράγραφο;**

Ναι. Το[Αναγνωριστικό Γλώσσας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) εφαρμόζεται στο επίπεδο τμήματος κειμένου, έτσι ώστε μια ενιαία παράγραφος μπορεί να αναμιγνύει πολλαπλές γλώσσες με διαφορετικές ρυθμίσεις ελέγχου.