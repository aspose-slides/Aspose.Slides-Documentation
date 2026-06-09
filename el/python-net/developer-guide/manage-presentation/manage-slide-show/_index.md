---
title: Διαχείριση προβολής διαφανειών σε Python
linktitle: Προβολή Διαφανειών
type: docs
weight: 90
url: /el/python-net/manage-slide-show/
keywords:
- τύπος προβολής
- παρουσιάζεται από ομιλητή
- προβάλλεται από άτομο
- προβάλλεται σε περίπτερο
- επιλογές προβολής
- αδιάλειπτη επανάληψη
- προβολή χωρίς αφήγηση
- προβολή χωρίς κίνηση
- χρώμα στυλό
- προβολή διαφανειών
- προσαρμοσμένη προβολή
- προώθηση διαφανειών
- χειροκίνητα
- χρήση χρονομετρήσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις προβολές διαφανειών στο Aspose.Slides για Python μέσω .NET. Ελέγξτε τις μεταβάσεις διαφάνειας, τις χρονομετρήσεις και πολλά άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Στο Microsoft PowerPoint, οι ρυθμίσεις **Slide Show** είναι ένα βασικό εργαλείο για την προετοιμασία και παράδοση επαγγελματικών παρουσιάσεων. Ένα από τα πιο σημαντικά χαρακτηριστικά σε αυτήν την ενότητα είναι το **Set Up Show**, το οποίο σας επιτρέπει να προσαρμόζετε την παρουσίασή σας σε συγκεκριμένες συνθήκες και ακροατήρια, εξασφαλίζοντας ευελιξία και ευκολία. Με αυτό το χαρακτηριστικό, μπορείτε να επιλέξετε τον τύπο προβολής (π.χ., παρουσίαση από ομιλητή, περιήγηση από άτομο ή περιήγηση σε περίπτερο), να ενεργοποιήσετε ή να απενεργοποιήσετε την επανάληψη, να επιλέξετε συγκεκριμένες διαφάνειες για προβολή και να χρησιμοποιήσετε χρονομετρήσεις. Αυτό το βήμα στην προετοιμασία είναι κρίσιμο για να κάνετε την παρουσίασή σας πιο αποτελεσματική και επαγγελματική.

`slide_show_settings` είναι μια ιδιότητα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), τύπου [SlideShowSettings](https://reference.aspose.com/slides/el/python-net/aspose.slides/slideshowsettings/), η οποία σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις του slide show σε μια παρουσίαση PowerPoint. Σε αυτό το άρθρο, θα εξερευνήσουμε πώς να χρησιμοποιήσετε αυτήν την ιδιότητα για να διαμορφώσετε και να ελέγξετε διάφορες πτυχές των ρυθμίσεων του slide show. 

## **Επιλογή Τύπου Προβολής**

`SlideShowSettings.slide_show_type` ορίζει τον τύπο του slide show, ο οποίος μπορεί να είναι ένα στιγμιότυπο των παρακάτω κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/python-net/aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/python-net/aspose.slides/browsedatkiosk/). Η χρήση αυτής της ιδιότητας σας επιτρέπει να προσαρμόζετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο προβολής σε «Browsed by an individual» χωρίς εμφάνιση της μπάρας κύλισης.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενεργοποίηση Επιλογών Προβολής**

`SlideShowSettings.loop` καθορίζει εάν το slide show θα επαναλαμβάνεται σε βρόχο μέχρι να σταματήσει χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να λειτουργούν συνεχώς. `SlideShowSettings.show_narration` καθορίζει εάν θα αναπαράγονται φωνητικές αφήγησες κατά τη διάρκεια του slide show. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιλαμβάνουν φωνητικές οδηγίες για το κοινό. `SlideShowSettings.show_animation` καθορίζει εάν θα αναπαράγονται οι κινήσεις (animations) που προστέθηκαν σε αντικείμενα διαφάνειας. Αυτό είναι χρήσιμο για να προσφέρει το πλήρες οπτικό αποτέλεσμα της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και επαναλαμβάνει το slide show.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Επιλογή Διαφανειών για Προβολή**

Η ιδιότητα `SlideShowSettings.slides` σάς επιτρέπει να επιλέξετε μια σειρά διαφανειών που θα εμφανιστούν κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να προβάλετε μόνο μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει το εύρος διαφανειών που θα εμφανιστούν από τις διαφάνειες `2` έως `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Χρήση Αυτόματης Προώθησης Διαφανειών**

Η ιδιότητα `SlideShowSettings.use_timings` σάς επιτρέπει να ενεργοποιήσετε ή να απενεργοποιήσετε τη χρήση προκαθορισμένων χρονομετρήσεων για κάθε διαφάνεια. Αυτό είναι χρήσιμο για αυτόματη προβολή διαφανειών με προ‑ορισμένες διάρκειες εμφάνισης. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρονομετρήσεων.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εμφάνιση Ελέγχων Πολυμέσων**

Η ιδιότητα `SlideShowSettings.show_media_controls` καθορίζει εάν θα εμφανίζονται έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) κατά τη διάρκεια του slide show όταν αναπαράγεται πολυμεσικό περιεχόμενο (π.χ., βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση των ελέγχων πολυμέσων.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει απευθείας σε λειτουργία slide show;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές ξεκινούν απευθείας σε slide show όταν ανοίγονται στο PowerPoint. Στο Aspose.Slides, επιλέξτε την αντίστοιχη μορφή αποθήκευσης [during export](/slides/el/python-net/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από την προβολή χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/hidden/). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά τη διάρκεια του slide show.

**Μπορεί το Aspose.Slides να αναπαράγει ένα slide show ή να ελέγξει μια ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής, όπως το PowerPoint.