---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε JavaScript
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας JavaScript για ταχύτερη κατανόηση και πιο έξυπνες ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε την τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στα APIs [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/) και επιδεικνύουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν ξεκινήσετε την εργασία σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP κ.ά.) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες σχετικά με την παρουσίαση):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Μπορεί να θέλετε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε κάποιες ιδιότητες παρουσίασης:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, ίσως βρείτε χρήσιμους τους παρακάτω συνδέσμους:

- [Παρουσιάσεις με προστασία κωδικού](/slides/el/nodejs-java/password-protected-presentation/)
- [Παρουσιάσεις με προστασία εγγραφής](/slides/el/nodejs-java/write-protected-presentation/)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) στο επίπεδο παρουσίασης, έπειτα συγκρίνετε αυτές τις καταχωρήσεις με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται στο περιεχόμενο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getfonts/) ώστε να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Διέλθετε τη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) και ελέγχετε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/gethidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslidesize/) και τον προσανατολισμό με τις προεπιλογές· αυτό βοηθά να προβλέψετε τη συμπεριφορά κατά την εκτύπωση και την εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δω αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Διασχίστε όλα τα [γράφημα](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν χαλασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, καταμετρήστε τα αντικείμενα και αναζητήστε μεγάλες εικόνες, διαφάνειες, σκιές, animations και πολυμέσα· δώστε μια κατά προσέγγιση βαθμολογία πολυπλοκότητας ώστε να εντοπίσετε πιθανές περιοχές προβλημάτων απόδοσης.