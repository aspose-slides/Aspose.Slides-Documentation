---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε PHP
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/php-java/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP για πιο γρήγορες πληροφορίες και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να ελέγξετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε τη τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) και παρουσιάζουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος Μορφής Παρουσίασης**

Πριν εργαστείτε με μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP και άλλες) βρίσκεται αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **Λήψη Ιδιοτήτων Παρουσίασης**

Αυτός ο κώδικας PHP σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες σχετικά με την παρουσίαση):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Μπορείτε επίσης να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) που επιτρέπει την αλλαγή των ιδιοτήτων παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που φαίνονται παρακάτω.

![Original document properties of the PowerPoint presentation](input_properties.png)

Αυτό το παράδειγμα κώδικα δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες παρουσίασης:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε χρήσιμους τους παρακάτω συνδέσμους:

- [Έλεγχος αν η παρουσίαση είναι κρυπτογραφημένη](https://docs.aspose.com/slides/el/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Έλεγχος αν η παρουσίαση είναι προστατευμένη από εγγραφή (μόνο ανάγνωση)](https://docs.aspose.com/slides/el/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Έλεγχος αν η παρουσίαση είναι προστατευμένη με κωδικό πριν τη φόρτωση](https://docs.aspose.com/slides/el/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Επιβεβαίωση του κωδικού που χρησιμοποιήθηκε για την προστασία της παρουσίασης](https://docs.aspose.com/slides/el/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε [embedded‑font information](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getembeddedfonts/) στο επίπεδο παρουσίασης, έπειτα συγκρίνετε αυτές τις καταχωρίσεις με το σύνολο των [fonts actually used across content](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getfonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο περιέχει κρυμμένες διαφάνειες και πόσες;**

Διατρέξτε τη [slide collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) και ελέγξτε τη [visibility flag](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/gethidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω εάν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [slide size](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getslidesize/) και τον προσανατολισμό με τα τυπικά presets· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς κατά την εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος για να δούμε αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Περιηγηθείτε όλα τα [charts](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/), ελέγξτε την [data source](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getdatasourcetype/), και σημειώστε εάν τα δεδομένα είναι εσωτερικά ή συνδεδεμένα, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Για κάθε διαφάνεια, καταμετρήστε τα αντικείμενα και ψάξτε για μεγάλες εικόνες, διαφάνειες, σκιές, κινήσεις και πολυμέσα· αποδώστε μια ενδεικτική βαθμολογία πολυπλοκότητας για να επισημάνετε πιθανά σημεία συμφόρησης.