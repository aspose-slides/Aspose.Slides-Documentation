---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Python
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/python-net/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- προσκόλληση κάθετου διαχωριστή
- μοναδική προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET ιδιότητες προβολής για να προσαρμόσετε μορφές PPT, PPTX και ODP διαφανειών - να ρυθμίσετε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν την τοποθέτηση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της στο αρχείο, ώστε όταν ξαναανοίξει η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η ιδιότητα [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/) προστέθηκε ώστε να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης.  

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewrestoredproperties/) και οι κληρονόμοι τους, καθώς και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-net/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με INormalViewProperties** 

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν ο κάθετος διαχωριστής πρέπει να «σκαλίζει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να βλέπει μια περιοχή περιεχομένου πλήρους παραθύρου αντί για την τυπική κανονική προβολή με τρεις περιοχές. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η αντίστοιχη γραμμή διαχωριστή. Μία οριζόντια γραμμή διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωριστή χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Οι δυνατές τιμές είναι: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** εφαρμόζεται στην **VerticalBarState** και την **HorizontalBarState** αντίστοιχα.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του **RestoredTop**, ύψος όταν είναι παιδί του **RestoredLeft**) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του **RestoredTop**, ύψος όταν είναι παιδί του **RestoredLeft**).

Η ιδιότητα **AutoAdjust** καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμοστεί στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει τη προβάλλουσα προβολή στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να έχετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Προεπιλεγμένης Τιμής Ζουμ**

Το Aspose.Slides για Python μέσω .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας το [view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) μιας παρουσίασης. Οι ιδιότητες Προβολής Διαφάνειας καθώς και το [notes_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/notes_view_properties/) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσετε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) 
1. Ορίστε τις [view properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/) της παρουσίασης 
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX 

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.view_properties.slide_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.view_properties.notes_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διάφορα τμήματα μιας παρουσίασης;**

Οι [View settings](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/slide_view_properties/)), όχι ανά τμήμα, έτσι ένα μοναδικό σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο όταν ανοίγει.

**Μπορώ να ορίσω εκ των προτέρων διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινόχρηστες. Οι εφαρμογές προβολής μπορούν να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Εφόσον οι [view properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.