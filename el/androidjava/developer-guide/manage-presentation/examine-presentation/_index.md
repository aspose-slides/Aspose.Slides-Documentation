---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης στο Android
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Java για πιο γρήγορη αντίληψη και πιο έξυπνες ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να καθορίσετε την τρέχουσα μορφή μιας παρουσίασης χωρίς τη φόρτωση ολόκληρου του αρχείου, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Οι παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/documentproperties/) και δείχνουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Ελέγξτε τη μορφή μιας παρουσίασης**

Πριν ξεκινήσετε την εργασία σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP και άλλα) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Αποκτήστε ιδιότητες παρουσίασης**

Αυτός ο κώδικας Java σας δείχνει πώς να αποκτήσετε τις ιδιότητες της παρουσίασης (πληροφορίες σχετικά με την παρουσίαση):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Ίσως θέλετε να δείτε τις [ιδιότητες κάτω από το DocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) κλάση.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Έστω ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που εμφανίζονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε κάποιες ιδιότητες της παρουσίασης:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τις ασφαλιστικές της ιδιότητες, μπορεί να βρείτε χρήσιμους αυτούς συνδέσμους:

- [Έλεγχος εάν μια παρουσίαση είναι κρυπτογραφημένη](https://docs.aspose.com/slides/el/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Έλεγχος εάν μια παρουσίαση είναι προστατευμένη από εγγραφή (μόνο για ανάγνωση)](https://docs.aspose.com/slides/el/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Έλεγχος εάν μια παρουσίαση είναι προστατευμένη με κωδικό πριν τη φόρτωση](https://docs.aspose.com/slides/el/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Επιβεβαίωση του κωδικού που χρησιμοποιείται για την προστασία μιας παρουσίασης](https://docs.aspose.com/slides/el/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) σε επίπεδο παρουσίασης, στη συνέχεια συγκρίνετε αυτές τις καταχωρίσεις με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά στο περιεχόμενο](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#getFonts--) για να προσδιορίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να καταλάβω εάν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Περιηγηθείτε στη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidecollection/) και ελέγξτε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#getHidden--) κάθε διαφάνειας.

**Μπορώ να εντοπίσω εάν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και εάν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlideSize--) και τον προσανατολισμό με τα πρότυπα προεπιλογές· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς για εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δούμε εάν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Διασχίστε όλα τα [γράφηματα](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) τους και σημειώστε εάν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, καταμετρήστε τα αντικείμενα και ψάξτε για μεγάλες εικόνες, διαφάνεια, σκιές, κινούμενα σχέδια και πολυμέσα· εκχωρήστε ένα περίπου σκορ πολυπλοκότητας για να επισημάνετε πιθανά σημεία συμφόρησης απόδοσης.