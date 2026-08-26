---
title: Ανάκτηση και ενημέρωση πληροφοριών παρουσίασης σε Java
linktitle: Πληροφορίες παρουσίασης
type: docs
weight: 30
url: /el/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Java για ταχύτερη κατανόηση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να ελέγξετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε τη τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες του εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/) και δείχνουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν εργαστείτε σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP και άλλες) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας Java σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες για την παρουσίαση):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// …
```

Ίσως θέλετε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που εμφανίζονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες παρουσίασης:

```java
import com.aspose.slides.*;
import java.util.Date;

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

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε χρήσιμους αυτούς συνδέσμους:

- [Πρόσβαση με κωδικό στις παρουσιάσεις](/slides/el/java/password-protected-presentation/)
- [Προστασία εγγραφής παρουσιάσεων](/slides/el/java/write-protected-presentation/)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) στο επίπεδο της παρουσίασης, έπειτα συγκρίνετε αυτές τις καταγραφές με το σύνολο των [πραγματικά χρησιμοποιούμενων γραμματοσειρών στο περιεχόμενο](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#getFonts--) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο περιέχει κρυφές διαφάνειες και πόσες;**

Διέξτε τη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidecollection/) και ελέγξτε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#getHidden--) κάθε διαφάνειας.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlideSize--) και προσανατολισμό με τις τυπικές προρυθμίσεις· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς κατά την εκτύπωση και την εξαγωγή.

**Υπάρχει ένας γρήγορος τρόπος να δω αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Διέλθετε όλα τα [γραφήματα](https://reference.aspose.com/slides/el/java/com.aspose.slides/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getDataSourceType--) και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να καθυστερούν την απόδοση ή την εξαγωγή σε PDF;**

Για κάθε διαφάνεια, μετρήστε τον αριθμό αντικειμένων και ψάξτε για μεγάλες εικόνες, διαφάνεια, σκιές, εφέ κίνησης και πολυμέσα· αποδώστε έναν κατά προσέγγιση δείκτη πολυπλοκότητας για να επισημάνετε πιθανά κρίσιμα σημεία απόδοσης.