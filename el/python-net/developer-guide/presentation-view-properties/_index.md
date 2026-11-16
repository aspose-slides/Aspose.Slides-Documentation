---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Python
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/python-net/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περίγραμμα
- εικονίδια περιγράμματος
- πρύσιμο κάθετου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Python μέσω .NET για να διαμορφώσετε τη διάταξη της κανονικής προβολής, το ζουμ της διαφάνειας και των σημειώσεων, την απόσταση του πλέγματος και την ορατότητα των σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού πλαισίου για μικρογραφίες ή ένα περίγραμμα και ενός πλαισίου σημειώσεων από κάτω. Το Aspose.Slides for Python μέσω .NET εκθέτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Αυτές περιλαμβάνουν τη διάταξη των πλαισίων, τα επίπεδα ζουμ, την απόσταση του πλέγματος και την ορατότητα των σχολίων.

## **Σχετικά με NormalViewProperties**

Χρησιμοποιήστε [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) για να αποκτήσετε πρόσβαση στο αντικείμενο [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). Το [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) ελέγχει αν εμφανίζονται εικονίδια δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) επιτρέπει στο πλευρικό πλαίσιο να κλειδώνει στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το σμικρύνει. Το [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) υποδεικνύει προτίμηση για εμφάνιση ενός πλαισίου σε όλο το παράθυρο.

Το [vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) ελέγχει το διαχωριστικό μεταξύ του πλευρικού πλαισίου και της διαφάνειας. Το [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) ελέγχει το διαχωριστικό πάνω από το πλαίσιο σημειώσεων. Και τα δύο δέχονται μια τιμή [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) του `MINIMIZED`, `MAXIMIZED` ή `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Ένας εννοιολογικός επεξεργαστής διαχωρίζει ένα πλευρικό πάνελ, περιοχή διαφάνειας και κάτω περιοχή με σημειωμένα κάθετα και οριζόντια διαχωριστικά.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Στην κανονική προβολή, το κάθετο διαχωριστικό ελέγχει το πλάτος του πλευρικού πλαισίου. Το οριζόντιο διαχωριστικό ελέγχει το χώρο πάνω από το πλαίσιο σημειώσεων.*  
<!-- visual-explanation:presentation-view-properties:end -->

## **Σχετικά με την Επαναφορά NormalViewProperties**

Όταν ένα διαχωριστικό επαναφέρεται, το [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) παρέχει το αποθηκευμένο μέγεθος του πλευρικού πλαισίου και το [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και τα δύο εκθέτουν το [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Η ιδιότητα [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) δέχεται ένα ποσοστό από 0 έως 100, και το [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει μέγεθος.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο διαχωριστικό, ορίζει το [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) στο 80% με ενεργοποιημένη την αυτόματη προσαρμογή, και μεγιστοποιεί το κάθετο διαχωριστικό. Επίσης ενεργοποιεί το [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) για την προβολή περιγράμματος.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

Τα [slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) και [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) αποθηκεύουν ανεξάρτητες ρυθμίσεις ζουμ για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή της παρουσίασης ή την ανάλυση εξαγόμενων εικόνων.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και ενεργοποιεί το [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) ώστε η διαφάνεια να προσαρμόζεται στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλιμάκωση και ορίζει το [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) σε σταθερό ζουμ 80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός της Απόστασης Πλέγματος**

Το [grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) ορίζει την απόσταση μεταξύ των γραμμών του πλέγματος επεξεργασίας σε όλη την παρουσίαση. Δέχεται μια θετική τιμή σε σημεία, με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει την τρέχουσα απόσταση σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τέταρτου ίντσας ορίζοντας το διάστημα σε 18 σημεία.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Τα [Οδηγοί σχεδίασης](/slides/el/python-net/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κατακόρυφες θέσεις. Και τα δύο είναι βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι παρουσιάσεις και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) αποθηκεύει μια προτίμηση που χρησιμοποιούν οι συμβατοί επεξεργαστές κατά το άνοιγμα της παρουσίασης. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει την τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με τα σχόλια κρυμμένα. Επίσης ορίζει το [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) στο [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) ώστε το αντίγραφο να ανοίγει σε προβολή διαφάνειας.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Η απόκρυψη των σχολίων διατηρεί το κείμενό τους, τους δημιουργούς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Για να αλλάξετε τα ίδια τα σχόλια, δείτε [Presentation Comments](/slides/el/python-net/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί το πλέγμα είναι κρυφό όταν ξανανοιώ την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητα του πλέγματος στον επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης την απόσταση του πλέγματος;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή ενός οδηγού δεν αλλάζει το διάστημα του πλέγματος.

**Μπορούν διαφορετικές ενότητες μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις ενός χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής του.