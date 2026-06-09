---
title: Διαχείριση Παρουσίασης Διαφάνειας σε JavaScript
linktitle: Παρουσίαση Διαφάνειας
type: docs
weight: 90
url: /el/nodejs-java/manage-slide-show/
keywords:
- τύπος παρουσίασης
- παρουσιάζεται από ομιλητή
- προβάλλεται από άτομο
- προβάλλεται σε περίπτερο
- επιλογές παρουσίασης
- συνεχής επανάληψη
- παρουσίαση χωρίς αφήγηση
- παρουσίαση χωρίς κίνηση
- χρώμα γραφίδας
- προβολή διαφανειών
- προσαρμοσμένη παρουσίαση
- προώθηση διαφανειών
- χειροκίνητα
- χρήση χρόνων
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις παρουσιάσεις διαφάνειας σε JavaScript με το Aspose.Slides για Node.js. Ελέγξτε τις μεταβάσεις διαφανειών, τα χρονόμετρα και πολλά άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Στο Microsoft PowerPoint, οι ρυθμίσεις της **Παρουσίασης Διαφάνειας** είναι ένα βασικό εργαλείο για την προετοιμασία και την παράδοση επαγγελματικών παρουσιάσεων. Μία από τις πιο σημαντικές λειτουργίες σε αυτήν την ενότητα είναι η **Ρύθμιση Παρουσίασης**, η οποία σας επιτρέπει να προσαρμόσετε την παρουσίασή σας σε συγκεκριμένες συνθήκες και κοινά, εξασφαλίζοντας ευελιξία και άνεση. Με αυτήν τη λειτουργία, μπορείτε να επιλέξετε τον τύπο της παρουσίασης (π.χ., παρουσιαζόμενη από ομιλητή, προβολή από άτομο ή προβολή σε περίπτερο), να ενεργοποιήσετε ή να απενεργοποιήσετε την επανάληψη, να επιλέξετε συγκεκριμένες διαφάνειες για εμφάνιση και να χρησιμοποιήσετε χρόνους. Αυτό το βήμα στην προετοιμασία είναι κρίσιμο για να κάνετε την παρουσίασή σας πιο αποτελεσματική και επαγγελματική.

`getSlideShowSettings` είναι μια μέθοδος της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που επιστρέφει ένα αντικείμενο τύπου [SlideShowSettings](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideshowsettings/), το οποίο σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις της παρουσίασης διαφάνειας σε μια παρουσίαση PowerPoint. Σε αυτό το άρθρο, θα εξερευνήσουμε πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να διαμορφώσετε και να ελέγξετε διάφορες πτυχές των ρυθμίσεων της παρουσίασης διαφάνειας. 

## **Επιλογή Τύπου Παρουσίασης**

`SlideShowSettings.setSlideShowType` ορίζει τον τύπο της παρουσίασης διαφάνειας, ο οποίος μπορεί να είναι ένα αντικείμενο των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σας επιτρέπει να προσαρμόσετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο παρουσίασης σε "Browsed by an individual" χωρίς την εμφάνιση της γραμμής κύλισης.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ενεργοποίηση Επιλογών Παρουσίασης**

`SlideShowSettings.setLoop` καθορίζει εάν η παρουσίαση διαφάνειας θα επαναλαμβάνεται σε βρόχο μέχρι να σταματήσει χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να τρέχουν συνεχώς. `SlideShowSettings.setShowNarration` καθορίζει εάν θα αναπαράγονται φωνητικές αφηγήσεις κατά τη διάρκεια της παρουσίασης διαφάνειας. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητικές οδηγίες για το κοινό. `SlideShowSettings.setShowAnimation` καθορίζει εάν θα αναπαράγονται οι κινήσεις που έχουν προστεθεί στα αντικείμενα των διαφανειών. Αυτό είναι χρήσιμο για την παροχή του πλήρους οπτικού εφέ της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και κάνει την παρουσίαση διαφάνειας να επαναλαμβάνεται σε βρόχο.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Επιλογή Διαφανειών προς Εμφάνιση**

`SlideShowSettings.setSlides` επιτρέπει την επιλογή ενός εύρους διαφανειών που θα εμφανιστούν κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να εμφανίσετε μόνο μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει το εύρος διαφανειών που θα εμφανιστούν από τη διαφάνεια `2` έως τη διαφάνεια `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Χρήση Προώθησης Διαφανειών**

`SlideShowSettings.setUseTimings` επιτρέπει την ενεργοποίηση ή απενεργοποίηση της χρήσης προκαθορισμένων χρόνων για κάθε διαφάνεια. Αυτό είναι χρήσιμο για την αυτόματη προβολή διαφανειών με προκαθορισμένες διάρκειες εμφάνισης. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρόνων.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Εμφάνιση Ελέγχων Πολυμέσων**

`SlideShowSettings.setShowMediaControls` καθορίζει εάν θα εμφανίζονται έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) κατά τη διάρκεια της παρουσίασης διαφάνειας όταν προβάλλεται πολυμεσικό περιεχόμενο (π.χ., βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση των ελέγχων πολυμέσων.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει απευθείας σε λειτουργία παρουσίασης διαφάνειας;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές ανοίγουν απευθείας σε παρουσίαση διαφάνειας όταν ανοίγονται στο PowerPoint. Στο Aspose.Slides, επιλέξτε την αντίστοιχη μορφή αποθήκευσης [during export](/slides/el/nodejs-java/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από την παρουσίαση χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/sethidden/). Οι κρυφές διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά την παρουσίαση διαφάνειας.

**Μπορεί το Aspose.Slides να προβάλλει μια παρουσίαση διαφάνειας ή να ελέγξει μια ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής όπως το PowerPoint.