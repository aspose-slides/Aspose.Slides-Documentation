---
title: "Αυτοματοποιήστε τον Εντοπισμό Παρουσίασης σε PHP"
linktitle: "Εντοπισμός Παρουσίασης"
type: docs
weight: 100
url: /el/php-java/presentation-localization/
keywords:
  - "αλλαγή γλώσσας"
  - "ορθογραφικός έλεγχος"
  - "αναγνωριστικό γλώσσας"
  - "PowerPoint"
  - "OpenDocument"
  - "παρουσίαση"
  - "PHP"
  - "Aspose.Slides"
description: "Αυτοματοποιήστε τον εντοπισμό διαφανειών PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για ταχύτερη παγκόσμια διάθεση."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να αντιστοιχίσετε έναν αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή γλώσσας για το κείμενο παρουσίασης και σχήματος**
- Δημιουργήστε μια παρουσία της κλάσης[Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Αποκτήστε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα[AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου[Rectangle](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσθέστε κάποιο κείμενο στο TextFrame.
- Ορίστε το[Set Language Id](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) στο κείμενο.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Η ταυτοποίηση γλώσσας (Language ID) προκαλεί αυτόματη μετάφραση κειμένου;**

Όχι. Το[Language ID](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) στο Aspose.Slides αποθηκεύει τη γλώσσα για ορθογραφικό και γραμματικό έλεγχο, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που καταλαβαίνει το PowerPoint για έλεγχο.

**Το Language ID επηρεάζει την συλλαβοποίηση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το[language ID](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) χρησιμοποιείται για έλεγχο. Η ποιότητα της συλλαβοποίησης και η αναδίπλωση γραμμών εξαρτώνται κυρίως από τη διαθεσιμότητα των[proper fonts](/slides/el/php-java/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για να εξασφαλίσετε σωστή απόδοση, διαθέστε τις απαιτούμενες γραμματοσειρές, διαμορφώστε τους[font substitution rules](/slides/el/php-java/font-substitution/) και/ή[embed fonts](/slides/el/php-java/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες μέσα σε μία παράγραφο;**

Ναι. Το[Language ID](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) εφαρμόζεται σε επίπεδο τμήματος κειμένου, επομένως μια ενιαία παράγραφος μπορεί να συνδυάζει πολλές γλώσσες με διαφορετικές ρυθμίσεις ελέγχου.