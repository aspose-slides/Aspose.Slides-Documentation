---
title: Μετατροπή παρουσιάσεων PowerPoint σε SWF Flash σε C++
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/cpp/convert-powerpoint-to-swf-flash/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε SWF
- παρουσίαση σε SWF
- διαφάνεια σε SWF
- PPT σε SWF
- PPTX σε SWF
- PowerPoint σε Flash
- παρουσίαση σε Flash
- διαφάνεια σε Flash
- PPT σε Flash
- PPTX σε Flash
- αποθήκευση PPT ως SWF
- αποθήκευση PPTX ως SWF
- εξαγωγή PPT σε SWF
- εξαγωγή PPTX σε SWF
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατροπή PowerPoint (PPT/PPTX) σε SWF Flash σε C++ με Aspose.Slides. Παραδείγματα κώδικα βήμα-βήμα, γρήγορο αποτέλεσμα υψηλής ποιότητας, χωρίς αυτοματισμό PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο SWF με τη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) και πώς να διαμορφώσετε την εξαγωγή με το [SwfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/), συμπεριλαμβανομένων των ρυθμίσεων προβολέα και της διάταξης σημειώσεων ή σχολίων.

## **Μετατροπή παρουσιάσεων σε Flash**

Η [Save](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) μέθοδος που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) μπορεί να χρησιμοποιηθεί για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο SWF.  Μπορείτε επίσης να συμπεριλάβετε σχόλια στο παραγόμενο SWF χρησιμοποιώντας την κλάση [SWFOptions](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.swf_options) και την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/).  Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο SWF χρησιμοποιώντας τις επιλογές που παρέχονται από την κλάση SWFOptions.

``` cpp
// Η διαδρομή προς το φάκελο εγγράφων.
    System::String dataDir = GetDataPath();

    // Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Αποθήκευση παρουσίασης και σελίδων σημειώσεων
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **Συχνές ερωτήσεις**

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο SWF;**

Ναι. Χρησιμοποιήστε τη μέθοδο [set_ShowHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) στην [SwfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/). Από προεπιλογή, οι κρυφές διαφάνειες δεν εξάγονται.

**Πώς μπορώ να ελέγξω τη συμπίεση και το τελικό μέγεθος του SWF;**

Χρησιμοποιήστε τη μέθοδο [set_Compressed](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/set_compressed/) και προσαρμόστε την [JPEG quality](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/set_jpegquality/) για να εξισορροπήσετε το μέγεθος του αρχείου και την ποιότητα της εικόνας.

**Για τι χρησιμεύει το 'set_ViewerIncluded' και πότε πρέπει να το χρησιμοποιήσω;**

Η μέθοδος [set_ViewerIncluded](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) προσθέτει ένα ενσωματωμένο UI παίκτη (πλήκτρα πλοήγησης, πίνακες, αναζήτηση). Απενεργοποιήστε το αν σκοπεύετε να χρησιμοποιήσετε τον δικό σας παίκτη ή χρειάζεστε ένα απλό πλαίσιο SWF χωρίς UI.

**Τι συμβαίνει αν μια γραμματοσειρά προέλευσης λείπει στη μηχανή εξαγωγής;**

Το Aspose.Slides θα αντικαταστήσει τη γραμματοσειρά που έχετε ορίσει μέσω της [set_DefaultRegularFont](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) στην [SwfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/swfoptions/) για να αποφευχθεί μια ανεπιθύμητη εναλλαγή.