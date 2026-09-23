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
- προσκόλληση κάθετης διαχωριστικής γραμμής
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides for Python via .NET για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια περιοχή περιεχομένου στο κάτω μέρος. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η ιδιότητα [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης.  

Προστέθηκαν οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/normalviewrestoredproperties/) και οι απογόνους τους, καθώς και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-net/aspose.slides/splitterbarstatetype/).

## **Σχετικά με το INormalViewProperties**

Αναπαριστά τις ιδιότητες κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει αν η εφαρμογή θα εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει αν η κάθετη διαχωριστική γραμμή θα «κλειδώνει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει αν ο χρήστης προτιμά να βλέπει μια περιοχή περιεχομένου πλήρους παραθύρου αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή καθέτου γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ μια κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή **SplitterBarStateType.Restored** έχει εφαρμοστεί για τις **VerticalBarState** και **HorizontalBarState** αντίστοιχα.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να αντισταθμίζεται για το νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Παρατίθεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

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

## **Ορισμός Προεπιλεγμένης Τιμής Zoom**

Το Aspose.Slides for Python via .NET υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για την παρουσίαση, ώστε όταν η παρουσίαση ανοίξει το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) μιας παρουσίασης. Οι ιδιότητες προβολής διαφάνειας καθώς και οι [notes_view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/notes_view_properties/) μπορούν να οριστούν προγραμματιστικά. Στο παρόν άρθρο, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Ορίστε τις [view properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/) της παρουσίασης.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.view_properties.slide_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.view_properties.notes_view_properties.scale = 100 # Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation.view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) για να έχετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Η ιδιότητα [ViewProperties.grid_spacing](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/grid_spacing/) διαβάζει ή αλλάζει το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισούνται με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα ενός τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/python-net/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένα τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, μετακίνηση ή διαγραφή των οδηγών σχεδίασης δεν αλλάζει την απόσταση του πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του θεατή ή του επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation.view_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) για να έχετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Διαβάστε ή αλλάξτε το [ViewProperties.show_comments](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/show_comments/) για να αποθηκεύσετε μια προτίμηση σχετικά με το αν τα σχόλια πρέπει να εμφανίζονται όταν η παρουσίαση ανοίξει στο PowerPoint ή σε άλλο συμβατό επεξεργαστή.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, καταργεί, επεξεργάζεται ή λύνει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τα [Presentation Comments](/slides/el/python-net/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Επίσης ορίζει το [ViewProperties.last_view](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/last_view/) στο [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewtype/) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα σχολίων.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Αυτή η ρύθμιση δεν καθορίζει αν τα σχόλια θα συμπεριληφθούν σε εξαγόμενα PDF, HTML, εικόνα, σημειώσεις ή φυλλάδια. Διαμορφώστε τις σχετικές επιλογές εξαγωγής χωριστά.

## **Συχνές Ερωτήσεις**

**Γιατί δεν είναι ορατό το πλέγμα μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει το διάστημα του πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/slide_view_properties/)), όχι ανά ενότητα, έτσι ένα σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προεγκαταστήσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορούν να τιμήσουν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/view_properties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.