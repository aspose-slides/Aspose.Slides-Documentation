---
title: Ανακτηση και Ενημερωση Ιδιοτήτων Προβολής Παρουσίασης σε Python
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/python-net/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- κόλλημα κατακόρυφου διαχωριστή
- μοναδική προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET τις ιδιότητες προβολής για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, έτσι ώστε όταν ξανανοίξει η προβολή να βρίσκεται στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η ιδιότητα [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewrestoredproperties/) και οι απογόνους τους, καθώς και η αρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-net/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή θα εμφανίζει εικονίδια όταν προβάλλει το περιεχόμενο περίγραμμα σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν η κάθετη γραμμή διαχωρισμού θα “πιαστεί” σε μια ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να βλέπει μια ενιαία περιοχή περιεχομένου σε πλήρη παράθυρο έναντι της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένη, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της πάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** έχει εφαρμοστεί αντίστοιχα στις ιδιότητες **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμοστεί αυτόματα στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει τη προβολή εντός της εφαρμογής.

Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να έχετε πρόσβαση στις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Προεπιλεγμένης Τιμής Ζουμ**

Το Aspose.Slides for Python via .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για την παρουσίαση, ώστε όταν η παρουσίαση ανοίξει το ζουμ να είναι ήδη ρυθμισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) μιας παρουσίασης. Τα View Properties της διαφάνειας καθώς και οι [notes_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/notes_view_properties/) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής μιας παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/)  
2. Ορίστε τις [view properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/) της παρουσίασης  
3. Γράψτε την παρουσίαση ως αρχείο PPTX  

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.view_properties.slide_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για την προβολή διαφάνειας
    presentation.view_properties.notes_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για την προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Απόστασης Πλέγματος**

Χρησιμοποιήστε [Presentation.view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) για πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Η ιδιότητα [ViewProperties.grid_spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/grid_spacing/) διαβάζει ή αλλάζει το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισούνται με ένα ίντ. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον διάστημα πλέγματος, ορίζει ένα διάστημα τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/python-net/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, η μετακίνηση ή η εκκαθάριση οδηγών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργαστή.

## **Συχνές Ερωτήσεις**

**Γιατί δεν είναι ορατό το πλέγμα μετά το ξαναάνοιγμα της παρουσίασης;**  
Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει εάν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η εκκαθάριση των οδηγών σχεδίασης την απόσταση του πλέγματος;**  
Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών δεν αλλάζει το αποθηκευμένο διάστημα του πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**  
Οι [View settings](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/slide_view_properties/)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο κατά το άνοιγμά του.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**  
Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορούν να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προκαθορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**  
Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.