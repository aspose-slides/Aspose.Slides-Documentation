---
title: Αυτοματοποίηση της τοπικής προσαρμογής παρουσιάσεων σε JavaScript
linktitle: Τοπική Προσαρμογή Παρουσίασης
type: docs
weight: 100
url: /el/nodejs-java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αυτοματοποίηση της τοπικής προσαρμογής διαφανειών PowerPoint και OpenDocument σε JavaScript με το Aspose.Slides, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για ταχύτερη παγκόσμια διάθεση."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να εκχωρήσετε έναν αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή γλώσσας για την παρουσίαση και το κείμενο του σχήματος**

- Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Λάβετε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) τύπου [Rectangle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσθέστε κείμενο στο TextFrame.
- [Ορισμός αναγνωριστικού γλώσσας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) στο κείμενο.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Ενεργοποιεί το Language ID αυτόματη μετάφραση κειμένου;**

Όχι. Το [setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) στο Aspose.Slides αποθηκεύει τη γλώσσα για ορθογραφικό και γραμματικό έλεγχο, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που καταλαβαίνει το PowerPoint για έλεγχο.

**Επηρεάζει το Language ID την συλλαβοποίηση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το [setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) χρησιμοποιείται για έλεγχο. Η ποιότητα της συλλαβοποίησης και η αναδίπλωση γραμμής εξαρτώνται κυρίως από τη διαθεσιμότητα [σωστών γραμματοσειρών](/slides/el/nodejs-java/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για σωστή απόδοση, διασφαλίστε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες, ρυθμίστε τις [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/nodejs-java/font-substitution/), και/ή [ενσωματώστε γραμματοσειρές](/slides/el/nodejs-java/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες μέσα σε μια παράγραφο;**

Ναι. Το [setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) εφαρμόζεται σε επίπεδο τμήματος κειμένου, έτσι μια ενιαία παράγραφος μπορεί να συνδυάσει πολλές γλώσσες με διαφορετικές ρυθμίσεις ελέγχου.