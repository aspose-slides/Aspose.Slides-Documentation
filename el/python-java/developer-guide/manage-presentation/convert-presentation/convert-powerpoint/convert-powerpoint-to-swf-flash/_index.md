---
title: Μετατροπή παρουσιάσεων PowerPoint σε SWF Flash σε Python μέσω Java
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/python-java/convert-powerpoint-to-swf-flash/
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
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε SWF Flash σε Python μέσω Java με το Aspose.Slides. Διαμορφώστε τον προβολέα, τις σημειώσεις, τις κρυμμένες διαφάνειες, τη συμπίεση και τις γραμματοσειρές."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java σας επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χωρίς το Microsoft PowerPoint. Χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να εξάγετε την παρουσίαση και [SwfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/) για να διαμορφώσετε τις ρυθμίσεις του προβολέα, την ποιότητα των εικόνων και τη διάταξη σημειώσεων ή σχολίων.

## **Μετατροπή Παρουσιάσεων σε Flash**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), διαμορφώστε τις [SwfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/) και αποθηκεύστε το χρησιμοποιώντας το [SaveFormat.Swf](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Swf).

Το παρακάτω παράδειγμα εξάγει το `presentation.pptx` σε `presentation.swf`. Απενεργοποιεί τον ενσωματωμένο προβολέα με την μέθοδο [setViewerIncluded](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setViewerIncluded) και περιλαμβάνει τις σημειώσεις ομιλητή κάτω από τις διαφάνειες χρησιμοποιώντας το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Πριν εκτελέσετε το παράδειγμα, [εγκαταστήστε το Aspose.Slides for Python via Java](/slides/el/python-java/installation/) και τοποθετήστε το `presentation.pptx` στον τρέχοντα φάκελο εργασίας. Η JVM ξεκινά μία φορά ανά διαδικασία Python.

Το παράδειγμα εφαρμόζει το [NotesPositions.BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomFull) μέσω του [setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) και περνά τη διάταξη στο [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Για να συμπεριληφθούν επίσης τα σχόλια, διαμορφώστε το [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) πριν από την εξαγωγή.

## **Συχνές Ερωτήσεις**

**Μπορώ να συμπεριλάβω κρυμμένες διαφάνειες στο SWF;**

Ναι. Καλέστε το [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) με `True`. Από προεπιλογή, οι κρυμμένες διαφάνειες δεν εξάγονται.

**Πώς μπορώ να ελέγξω τη συμπίεση και το τελικό μέγεθος του SWF;**

Χρησιμοποιήστε το [SwfOptions.setCompressed](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setCompressed) για να ενεργοποιήσετε ή να απενεργοποιήσετε τη συμπίεση και το [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setJpegQuality) για να προσαρμόσετε την ποιότητα των εικόνων JPEG. Χαμηλότερη ποιότητα JPEG μπορεί να μειώσει το μέγεθος του αρχείου με κόστος στη πιστότητα της εικόνας.

**Ποιος είναι ο σκοπός του ενσωματωμένου προβολέα και πότε πρέπει να τον απενεργοποιήσω;**

Το [SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/#setViewerIncluded) ελέγχει αν το παραγόμενο SWF περιλαμβάνει τον προβολέα. Περάστε `False` όταν χρειάζεστε τις εξαγόμενες διαφάνειες χωρίς τον ενσωματωμένο προβολέα, όπως στο παραπάνω παράδειγμα.

**Τι συμβαίνει αν μια γραμματοσειρά προέλευσης λείπει στη μηχανή εξαγωγής;**

Μπορείτε να καθορίσετε μια προεπιλεγμένη κανονική γραμματοσειρά με το [setDefaultRegularFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), η οποία κληρονομείται από τις [SwfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/swfoptions/). Επιλέξτε μια γραμματοσειρά που είναι διαθέσιμη στη διαδικασία εξαγωγής· η αντικατάσταση γραμματοσειράς μπορεί να αλλάξει την εμφάνιση του κειμένου και τη διάταξη.