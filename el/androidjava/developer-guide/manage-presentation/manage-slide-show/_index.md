---
title: Διαχείριση Προβολής Διαφανειών σε Android
linktitle: Προβολή Διαφανειών
type: docs
weight: 90
url: /el/androidjava/manage-slide-show/
keywords:
- τύπος προβολής
- παρουσιάζεται από ομιλητή
- προβάλλεται από άτομο
- προβάλλεται σε περίπτερο
- επιλογές προβολής
- συνεχής επανάληψη
- προβολή χωρίς αφήγηση
- προβολή χωρίς κίνηση
- χρώμα γραφίδας
- προβολή διαφανειών
- προσαρμοσμένη προβολή
- πρόοδος διαφανειών
- χειροκίνητα
- χρήση χρονομέτρων
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις προβολές διαφανειών στο Aspose.Slides για Android μέσω Java. Ελέγξτε τις μεταβάσεις διαφανειών, τους χρονισμούς και πολλά άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Στο Microsoft PowerPoint, οι ρυθμίσεις **Slide Show** αποτελούν ένα βασικό εργαλείο για την προετοιμασία και την παρουσίαση επαγγελματικών διαφανειών. Ένα από τα πιο σημαντικά χαρακτηριστικά σε αυτήν την ενότητα είναι το **Set Up Show**, το οποίο σας επιτρέπει να προσαρμόσετε την παρουσίασή σας σε συγκεκριμένες συνθήκες και κοινό, εξασφαλίζοντας ευελιξία και άνεση. Με αυτήν τη δυνατότητα, μπορείτε να επιλέξετε τον τύπο προβολής (π.χ. παρουσίαση από ομιλητή, προβολή από άτομο ή προβολή σε περίπτερο), να ενεργοποιήσετε ή να απενεργοποιήσετε την επανάληψη, να επιλέξετε συγκεκριμένες διαφάνειες για εμφάνιση και να χρησιμοποιήσετε χρονισμούς. Αυτό το βήμα στην προετοιμασία είναι κρίσιμο για να γίνει η παρουσίασή σας πιο αποτελεσματική και επαγγελματική.

`getSlideShowSettings` είναι μια μέθοδος της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) που επιστρέφει ένα αντικείμενο τύπου [SlideShowSettings](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideshowsettings/), το οποίο σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις της προβολής διαφανειών σε μια παρουσίαση PowerPoint. Σε αυτό το άρθρο, θα εξετάσουμε πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να διαμορφώσετε και να ελέγξετε διάφορες πτυχές των ρυθμίσεων της προβολής διαφανειών. 

## **Επιλογή Τύπου Προβολής**

`SlideShowSettings.setSlideShowType` καθορίζει τον τύπο της προβολής διαφανειών, ο οποίος μπορεί να είναι ένα στιγμιότυπο των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σάς επιτρέπει να προσαρμόσετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο προβολής σε «Browsed by an individual» χωρίς να εμφανίζει τη γραμμή κύλισης.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ενεργοποίηση Επιλογών Προβολής**

`SlideShowSettings.setLoop` καθορίζει εάν η προβολή διαφανειών θα επαναλαμβάνεται σε βρόχο μέχρι να διακοπεί χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να εκτελούνται συνεχώς. `SlideShowSettings.setShowNarration` καθορίζει εάν θα αναπαράγονται φωνητικές αφήγηση κατά τη διάρκεια της προβολής διαφανειών. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητικές οδηγίες για το κοινό. `SlideShowSettings.setShowAnimation` καθορίζει εάν θα αναπαράγονται οι κινήσεις που έχουν προστεθεί σε αντικείμενα διαφανειών. Αυτό είναι χρήσιμο για να παρέχεται το πλήρες οπτικό εφέ της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και επαναλαμβάνει την προβολή διαφανειών.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Επιλογή Διαφανειών για Προβολή**

Η μέθοδος `SlideShowSettings.setSlides` σάς επιτρέπει να επιλέξετε ένα εύρος διαφανειών που θα προβληθούν κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να παρουσιάσετε μόνο μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει το εύρος διαφανειών που θα εμφανιστούν από τη διαφάνεια `2` έως τη `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Χρήση Προπροώθησης Διαφανειών**

Η μέθοδος `SlideShowSettings.setUseTimings` σάς επιτρέπει να ενεργοποιήσετε ή να απενεργοποιήσετε τη χρήση προρυθμισμένων χρονισμών για κάθε διαφάνειά. Αυτό είναι χρήσιμο για αυτόματη προβολή διαφανειών με προκαθορισμένες διάρκειες εμφάνισης. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρονισμών.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Εμφάνιση Ελέγχων Πολυμέσων**

Η μέθοδος `SlideShowSettings.setShowMediaControls` καθορίζει εάν οι έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) θα εμφανίζονται κατά τη διάρκεια της προβολής διαφανειών όταν προβάλται πολυμεσικό περιεχόμενο (π.χ. βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή τον έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση των ελέγχων πολυμέσων.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει απευθείας σε λειτουργία προβολής διαφανειών;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές εκκινούν άμεσα τη λειτουργία προβολής διαφανειών όταν ανοίγονται στο PowerPoint. Στο Aspose.Slides, επιλέξτε την αντίστοιχη μορφή αποθήκευσης [during export](/slides/el/androidjava/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από την προβολή χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά τη διάρκεια της προβολής διαφανειών.

**Μπορεί το Aspose.Slides να αναπαράγει μια προβολή διαφανειών ή να ελέγξει ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής όπως το PowerPoint.