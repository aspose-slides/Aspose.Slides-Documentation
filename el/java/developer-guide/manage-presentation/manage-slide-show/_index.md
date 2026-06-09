---
title: Διαχείριση Παρουσίασης Διαφάνειας σε Java
linktitle: Παρουσίαση Διαφάνειας
type: docs
weight: 90
url: /el/java/manage-slide-show/
keywords:
- τύπος παρουσίασης
- παρουσιάζεται από ομιλητή
- προβάλλεται από άτομο
- προβάλλεται σε περίπτερο
- επιλογές παρουσίασης
- συνεχής επανάληψη
- παρουσίαση χωρίς αφήγηση
- παρουσίαση χωρίς κίνηση
- χρώμα στυλό
- παρουσίαση διαφανειών
- προσαρμοσμένη παρουσίαση
- προώθηση διαφανειών
- χειροκίνητα
- χρήση χρονισμών
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις παρουσιάσεις διαφάνειας στο Aspose.Slides για Java. Ελέγξτε τις μεταβάσεις διαφανειών, τους χρονισμούς και άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Στο Microsoft PowerPoint, οι ρυθμίσεις **Slide Show** είναι ένα βασικό εργαλείο για την προετοιμασία και παράδοση επαγγελματικών παρουσιάσεων. Ένα από τα πιο σημαντικά χαρακτηριστικά σε αυτήν την ενότητα είναι το **Set Up Show**, το οποίο σας επιτρέπει να προσαρμόζετε την παρουσίασή σας σε συγκεκριμένες συνθήκες και κοινά, εξασφαλίζοντας ευελιξία και άνεση. Με αυτήν τη λειτουργία, μπορείτε να επιλέξετε τον τύπο παρουσίασης (π.χ., παρουσίαση από ομιλητή, περιήγηση από άτομο ή περιήγηση σε περίπτευρο), να ενεργοποιήσετε ή να απενεργοποιήσετε την επανάληψη, να επιλέξετε συγκεκριμένες διαφάνειες για προβολή και να χρησιμοποιήσετε χρόνους. Αυτό το βήμα στην προετοιμασία είναι κρίσιμο για την πιο αποτελεσματική και επαγγελματική παρουσίαση.

`getSlideShowSettings` είναι μια μέθοδος της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) που επιστρέφει ένα αντικείμενο τύπου [SlideShowSettings](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideshowsettings/), το οποίο σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις παρουσίασης διαφάνειας σε μια παρουσίαση PowerPoint. Σε αυτό το άρθρο, θα εξερευνήσουμε πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να διαμορφώσετε και να ελέγξετε διάφορες πτυχές των ρυθμίσεων παρουσίασης διαφάνειας. 

## **Επιλογή Τύπου Παρουσίασης**

`SlideShowSettings.setSlideShowType` καθορίζει τον τύπο της παρουσίασης διαφάνειας, ο οποίος μπορεί να είναι μια περίπτωση των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/java/com.aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/java/com.aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σας επιτρέπει να προσαρμόζετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο παρουσίασης σε "Browsed by an individual" χωρίς εμφάνιση της γραμμής κύλισης.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ενεργοποίηση Επιλογών Παρουσίασης**

`SlideShowSettings.setLoop` καθορίζει εάν η παρουσίαση διαφάνειας πρέπει να επαναλαμβάνεται σε βρόχο μέχρι να σταματήσει χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να τρέχουν συνεχώς. `SlideShowSettings.setShowNarration` καθορίζει εάν οι φωνητικές αφήγηση πρέπει να αναπαραχθούν κατά τη διάρκεια της παρουσίασης. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητικές οδηγίες για το κοινό. `SlideShowSettings.setShowAnimation` καθορίζει εάν οι προστιθέμενες κινήσεις στα αντικείμενα διαφάνειας πρέπει να αναπαραχθούν. Αυτό είναι χρήσιμο για την πλήρη οπτική επίδραση της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και επαναλαμβάνει την παρουσίαση διαφάνειας.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Επιλογή Διαφανειών προς Παρουσίαση**

Η μέθοδος `SlideShowSettings.setSlides` σας επιτρέπει να επιλέξετε ένα εύρος διαφανειών που θα προβληθεί κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να εμφανίσετε μόνο ένα μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει το εύρος διαφανειών να εμφανιστούν από τις διαφάνειες `2` έως `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Χρήση Προώθησης Διαφανειών**

Η μέθοδος `SlideShowSettings.setUseTimings` επιτρέπει την ενεργοποίηση ή απενεργοποίηση της χρήσης προρυθμισμένων χρόνων για κάθε διαφάνεια. Αυτό είναι χρήσιμο για αυτόματη προβολή διαφανειών με προκαθορισμένες διάρκειες εμφάνισης. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρόνων.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Εμφάνιση Ελέγχων Πολυμέσων**

Η μέθοδος `SlideShowSettings.setShowMediaControls` καθορίζει εάν οι έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) πρέπει να εμφανίζονται κατά τη διάρκεια της παρουσίασης όταν αναπαράγεται πολυμεσικό περιεχόμενο (π.χ., βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση των ελέγχων πολυμέσων.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει κατευθείαν σε λειτουργία παρουσίασης;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές εκκινούν άμεσα σε παρουσίαση όταν ανοίγουν στο PowerPoint. Στο Aspose.Slides, επιλέξτε την αντίστοιχη μορφή αποθήκευσης [κατά την εξαγωγή](/slides/el/java/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από την παρουσίαση χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#setHidden-boolean-). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν προβάλλονται κατά τη διάρκεια της παρουσίασης.

**Μπορεί το Aspose.Slides να παίξει μια παρουσίαση διαφάνειας ή να ελέγξει μια ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσιάσεων· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής όπως το PowerPoint.