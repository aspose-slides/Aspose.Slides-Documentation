---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε PHP
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/php-java/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για PHP μέσω Java για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument, ώστε να επιτύχετε επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα χειρίζονται σε επίπεδο master της παρουσίασης, και το API παρέχει μεθόδους για τον ορισμό κειμένου υποσέλιδου, την αλλαγή ορατότητας του υποσέλιδου και την ενημέρωση του κειμένου κεφαλίδας στις master διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειριστείτε κεφαλίδες και υποσέλιδα για διαφάνειες φυλλαδίου και σημειώσεων. Αυτό περιλαμβάνει την αλλαγή ορατότητας και κειμένου των placeholder κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας/ώρας για το master σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μια μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση Κεφαλίδων και Υποσέλιδων σε Παρουσίαση**

Οι σημειώσεις κάποιων συγκεκριμένων διαφανειών μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```php
  # Φόρτωση Παρουσίασης
  $pres = new Presentation("headerTest.pptx");
  try {
    # Ορισμός Υποσέλιδου
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Πρόσβαση και Ενημέρωση Κεφαλίδας
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Αποθήκευση παρουσίασης
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Διαχείριση Κεφαλίδων και Υποσέλιδων σε Διαφάνειες Φυλλαδίου και Σημειώσεων**
Το Aspose.Slides for PHP via Java υποστηρίζει Κεφαλίδα και Υποσέλιδο σε διαφάνειες φυλλαδίου και σημειώσεων. Ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου για το master σημειώσεων και όλες τις διαφάνειες σημειώσεων.
- Ορίστε τα placeholder Υποσέλιδου του master σημειώσεων και όλων των θυγατρικών ορατά.
- Ορίστε τα placeholder Ημερομηνίας και ώρας του master σημειώσεων και όλων των θυγατρικών ορατά.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε το placeholder Κεφαλίδας της διαφάνειας σημειώσεων ορατό.
- Ορίστε κείμενο στο placeholder Κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στο placeholder Ημερομηνίας‑ώρας της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Κώδικας παραδείγματος παρέχεται στο παρακάτω παράδειγμα.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου για το master σημειώσεων και όλες τις διαφάνειες σημειώσεων
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// κάντε τη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Υποσέλιδου ορατά

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// κάντε τη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Κεφαλίδας ορατά

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// κάντε τη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Αριθμού Διαφάνειας ορατά

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// κάντε τη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Ημερομηνίας και ώρας ορατά

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// ορίστε κείμενο στη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Κεφαλίδας

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// ορίστε κείμενο στη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Υποσέλιδου

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// ορίστε κείμενο στη διαφάνεια master σημειώσεων και όλα τα θυγατρικά placeholder Ημερομηνίας και ώρας

    }
    # Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// κάντε αυτό το placeholder Κεφαλίδας της διαφάνειας σημειώσεων ορατό

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// κάντε αυτό το placeholder Υποσέλιδου της διαφάνειας σημειώσεων ορατό

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// κάντε αυτό το placeholder Αριθμού Διαφάνειας της διαφάνειας σημειώσεων ορατό

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// κάντε αυτό το placeholder Ημερομηνίας‑ώρας της διαφάνειας σημειώσεων ορατό

      $headerFooterManager->setHeaderText("New header text");// ορίστε κείμενο στο placeholder Κεφαλίδας της διαφάνειας σημειώσεων

      $headerFooterManager->setFooterText("New footer text");// ορίστε κείμενο στο placeholder Υποσέλιδου της διαφάνειας σημειώσεων

      $headerFooterManager->setDateTimeText("New date and time text");// ορίστε κείμενο στο placeholder Ημερομηνίας‑ώρας της διαφάνειας σημειώσεων

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω «κεφαλίδα» σε κανονικές διαφάνειες;**

Στο PowerPoint, η «Κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· στις κανονικές διαφάνειες, τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό αντικατοπτρίζει τις ίδιες περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδιο, και στις διαφάνειες—Υποσέλιδο/ΗμερομηνίαΏρα/ΑριθμόςΔιαφάνειας.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου—μπορώ να «ενεργοποιήσω» την ορατότητά του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την αν χρειάζεται. Αυτοί οι δείκτες και οι μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου το placeholder λείπει ή είναι κρυφό.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να αρχίζει από τιμή διαφορετική από 1;**

Ορίστε τον [first slide number](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/setfirstslidenumber/) της παρουσίασης· μετά από αυτό, όλες οι αρίθμησεις επανυπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στη διαφάνεια τίτλου.

**Τι γίνεται με τις κεφαλίδες/υποσέλιδα κατά την εξαγωγή σε PDF/εικόνες/HTML;**

Αυτά αποδίδονται ως κανονικά κειμενικά στοιχεία της παρουσίασης. Δηλαδή, εάν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης στην έξοδο μαζί με το υπόλοιπο περιεχόμενο.