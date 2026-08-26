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
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για PHP για γρηγορότερη κατανόηση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εξετάσετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να καθορίσετε το τρέχον φορμά μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν απαιτείται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) και επιδεικνύουν τυπικές λειτουργίες εργασίας με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν εργαστείτε σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποιο φορμά (PPT, PPTX, ODP και άλλα) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε το φορμά μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας PHP σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες για την παρουσίαση):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Μπορείτε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες της παρουσίασης:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου φαίνονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, ενδέχεται να βρείτε χρήσιμους αυτούς συνδέσμους:

- [Παρουσιάσεις με προστασία κωδικού](/slides/el/php-java/password-protected-presentation/)
- [Παρουσιάσεις με προστασία εγγραφής](/slides/el/php-java/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getembeddedfonts/) σε επίπεδο παρουσίασης, στη συνέχεια συγκρίνετε αυτές τις καταχωρήσεις με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά στο περιεχόμενο](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getfonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να καταλάβω αν το αρχείο έχει κρυμμένες διαφάνειες και πόσες;**

Διατρέξτε τη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) και εξετάστε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/gethidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getslidesize/) και προσανατολισμό με τα πρότυπα προεπιλογών· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς κατά την εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δω αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Περιηγηθείτε σε όλα τα [διαγράμματα](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getdatasourcetype/) τους, και σημειώστε εάν τα δεδομένα είναι εσωτερικά ή βασίζονται σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, υπολογίστε τον αριθμό των αντικειμένων και ψάξτε για μεγάλες εικόνες, διαφάνειες, σκιές, κινούμενα σχέδια και πολυμέσα· αποδώστε μια κατά προσέγγιση βαθμολογία πολυπλοκότητας για να επισημάνετε πιθανές περιοχές με χαμηλή απόδοση.