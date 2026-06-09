---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε C++
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/cpp/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κάθετης διαχωριστικής γραμμής
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides for C++ για να προσαρμόσετε τις μορφές PPT, PPTX και ODP διαφάνειες — ρυθμίστε τις διατάξεις, τα επίπεδα ζουμ και τις ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθ' αυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση της προβολής στο αρχείο, ώστε όταν ξαναανοιχτεί η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Διαβάσματα [INormalViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/inormalviewrestoredproperties/) και οι απογόνους τους, καθώς και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/cpp/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Η ιδιότητα **ShowOutlineIcons** καθορίζει εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Η ιδιότητα **SnapVerticalSplitter** καθορίζει εάν η κάθετη διαχωριστική γραμμή θα κλειδώνει σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα **PreferSingleView** καθορίζει εάν ο χρήστης προτιμά να βλέπει μια μονή περιοχή περιεχομένου σε πλήρη παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι ιδιότητες **VerticalBarState** και **HorizontalBarState** καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μία οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από αυτήν, ενώ η κάθετη χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** και **SplitterBarStateType.Restored**.

Οι ιδιότητες **RestoredLeft** και **RestoredTop** καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή **SplitterBarStateType.Restored** εφαρμόζεται αντίστοιχα στις **VerticalBarState** και **HorizontalBarState**.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft) της κανονικής προβολής, όταν η περιοχή είναι σε μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η ιδιότητα **DimensionSize** καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του RestoredTop, ύψος όταν είναι παιδί του RestoredLeft).

Η ιδιότητα **AutoAdjust** καθορίζει εάν η πλευρική περιοχή περιεχομένου πρέπει να προσαρμοστεί αυτόματα στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει τη προβολή στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες **ViewProperties.NormalViewProperties** για μια παρουσίαση.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ορισμός της προεπιλεγμένης τιμής Zoom**

Το Aspose.Slides for C++ υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής Zoom για μια παρουσίαση, ώστε όταν ανοίγει η παρουσίαση, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τα [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) μιας παρουσίασης. Οι ιδιότητες προβολής της διαφάνειας καθώς και το [get_NotesViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_notesviewproperties/) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις Ιδιότητες Προβολής μιας Παρουσίασης στο Aspose.Slides.

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/)
1. Ορίστε τις [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) της Παρουσίασης
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX

Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ορισμός των ιδιοτήτων προβολής της παρουσίασης
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικά τμήματα μιας παρουσίασης;**

Οι [View settings](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), όχι ανά τμήμα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίξει.

**Μπορώ να ορίσω προκαθορισμένες καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορούν να τηρούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Εφόσον οι [view properties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_viewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.