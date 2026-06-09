---
title: Αυτοματοποιήστε την Εντοπισμό Παρουσίασης σε Java
linktitle: Εντοπισμός Παρουσίασης
type: docs
weight: 100
url: /el/java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Αυτοματοποιήστε την εντοπισμό διαφανειών PowerPoint και OpenDocument σε Java με Aspose.Slides, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για ταχύτερη παγκόσμια κυκλοφορία."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να εκχωρήσετε έναν αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή Γλώσσας για Παρουσίαση και Κείμενο Σχήματος**
- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) τύπου [Rectangle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσθέστε κείμενο στο TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) στο κείμενο.
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

**Ενεργοποιεί το language ID αυτόματη μετάφραση κειμένου;**

Όχι. Το [Language ID](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) στο Aspose.Slides αποθηκεύει τη γλώσσα για έλεγχο ορθογραφίας και γραμματικής, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που κατανοεί το PowerPoint για τη διόρθωση.

**Επηρεάζει το language ID την συσσωμάτωση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το [language ID](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) προορίζεται για διορθωτικό έλεγχο. Η ποιότητα της συσσωμάτωσης και η αναδίπλωση γραμμής εξαρτώνται κυρίως από τη διαθεσιμότητα [proper fonts](/slides/el/java/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για να εξασφαλίσετε σωστή απόδοση, διαθέστε τις απαιτούμενες γραμματοσειρές, ρυθμίστε [font substitution rules](/slides/el/java/font-substitution/) και/ή [embed fonts](/slides/el/java/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες σε μία παράγραφο;**

Ναι. Το [Language ID](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) εφαρμόζεται σε επίπεδο τμήματος κειμένου, έτσι ώστε μια ενιαία παράγραφος να μπορεί να περιλαμβάνει πολλαπλές γλώσσες με διαφορετικές ρυθμίσεις διορθωτικού ελέγχου.