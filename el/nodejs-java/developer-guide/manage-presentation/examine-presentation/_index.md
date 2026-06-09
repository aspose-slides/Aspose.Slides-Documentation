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
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας JavaScript για γρηγορότερες αναλύσεις και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το παρόν άρθρο δείχνει πώς να εξετάζετε τις πληροφορίες μιας παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε την τρέχουσα μορφή της παρουσίασης χωρίς να φορτώσετε πλήρως το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν απαιτείται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/) και δείχνουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν εργαστείτε σε μια παρουσίαση, ίσως θέλετε να κατανοήσετε σε ποια μορφή (PPT, PPTX, ODP και άλλες) βρίσκεται αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να την φορτώσετε. Δείτε αυτόν τον κώδικα JavaScript:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες για την παρουσίαση):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Ίσως θελήσετε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου όπως φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες της παρουσίασης:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου φαίνονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, ενδέχεται να βρείτε χρήσιμους αυτούς συνδέσμους:

- [Έλεγχος αν μια παρουσίαση είναι κρυπτογραφημένη](https://docs.aspose.com/slides/el/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Έλεγχος αν μια παρουσίαση είναι προστατευμένη κατά την εγγραφή (μόνο για ανάγνωση)](https://docs.aspose.com/slides/el/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Έλεγχος αν μια παρουσίαση είναι προστατευμένη με κωδικό πριν τη φόρτωση](https://docs.aspose.com/slides/el/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Επιβεβαίωση του κωδικού που χρησιμοποιείται για την προστασία μιας παρουσίασης](https://docs.aspose.com/slides/el/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) στο επίπεδο της παρουσίασης, στη συνέχεια συγκρίνετε αυτές τις καταχωρήσεις με το σύνολο των [πραγματικά χρησιμοποιούμενων γραμματοσειρών στο περιεχόμενο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getfonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο περιέχει κρυφές διαφάνειες και πόσες;**

Περιηγηθείτε στη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) και εξετάστε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/gethidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslidesize/) και προσανατολισμό με τα τυπικά προκαθορισμένα, κάτι που βοηθά στην πρόβλεψη της συμπεριφοράς κατά την εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Διασχίστε όλα τα [διαγράμματα](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) τους και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασίζονται σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να καθυστερούν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, καταμετρήστε τον αριθμό των αντικειμένων και ψάξτε για μεγάλες εικόνες, διαφάνεια, σκιές, κινήσεις και πολυμέσα· αποδώστε μια κατά προσέγγιση βαθμολογία πολυπλοκότητας για να επισημάνετε πιθανά σημεία συμφόρησης απόδοσης.