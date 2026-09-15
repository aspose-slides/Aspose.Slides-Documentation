---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε Python μέσω Java
type: docs
weight: 90
url: /el/python-java/presentation-warnings/
aliases:
- /python-java/παραλαβη-προειδοποιησεων-για-αντικατασταση-γραμματοσειρων-στο-aspose-slides/
keywords:
- callback προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- φθορά πηγής
- ζήτημα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: Μάθετε πώς να συλλέγετε, κατηγοριοποιείτε και ενεργείτε στις προειδοποιήσεις κατά τη φόρτωση, την απόδοση, τη μετατροπή και την αποθήκευση παρουσιάσεων με το Aspose.Slides για Python μέσω Java.
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει ανακτήσιμα προβλήματα κατά τη φόρτωση, την απόδοση, τη μετατροπή ή την αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένες πηγικές εγγραφές, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειρών και περιορισμούς του μορφότυπου προορισμού. Ένα callback προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει αν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Υλοποιήστε τη διεπαφή `IWarningCallback` μέσω του `jpype.JProxy` και εξετάστε τις τιμές `getWarningType` και `getDescription` που παρέχονται μέσω του `IWarningInfo`. Επιστρέψτε [ReturnAction.Continue](https://reference.aspose.com/slides/el/python-java/aspose.slides/returnaction/#Continue) για να αποδεχθείτε την προειδοποίηση ή [ReturnAction.Abort](https://reference.aspose.com/slides/el/python-java/aspose.slides/returnaction/#Abort) για να διακόψετε τη λειτουργία.

Χρησιμοποιήστε το [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setWarningCallback) για προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setWarningCallback), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφανειών, τη μετατροπή και την αποθήκευση. Δεδομένου ότι η προειδοποίηση από μόνη της δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε instance του callback με ένα στάδιο λειτουργίας όταν δημιουργείτε μια ενιαία αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακτήσει εάν το callback επιστρέφει `ReturnAction.Continue`. Μια εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να αντιμετωπιστούν από μια πολιτική προειδοποίησης.

Επιστρέφοντας `ReturnAction.Abort` ζητά από τον διαχειριστή προειδοποιήσεων να τερματίσει την τρέχουσα λειτουργία εγείροντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο της παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να εμφανίσει μια [PptxReadException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxreadexception/) ή [PptReadException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptreadexception/), ενώ η αποθήκευση ή η εξαγωγή μπορεί να εμφανίσει μια [PptxException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxexception/). Διαχειριστείτε την εξαίρεση στα όρια της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να προσδιορίσετε αν η πολιτική της εφαρμογής προκάλεσε το τερματισμό αντί να βασίζεστε σε έναν υποτύπο ή μήνυμα εξαίρεσης. Το callback καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction.Abort`, διασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποίησης**

Η κλάση [WarningType](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/) παρέχει ακέραιους σταθερούς για τις παρακάτω κατηγορίες:

| Τύπος προειδοποίησης | Σημασία | Τυπική πολιτική |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Η πηγαία παρουσίαση περιέχει φθορές που μπορούν να κάνουν κάποιο έγγραφο αποθηκευμένο στο αρχικό του μορφότυπο ακατάλληλο για χρήση. | Απόρριψη. |
| [DataLoss](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#DataLoss) | Κείμενο, διαγράμματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή την αποθήκευση. | Απόρριψη. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Απόρριψη σε αυστηρή λειτουργία επικύρωσης· διαφορετικά καταγραφή και συνέχεια. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Μπορεί να εμφανιστεί περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διάγνωση και συνέχεια. |
| [CompatibilityIssue](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Το αποτέλεσμα μπορεί να μην ανοίξει ή να λειτουργήσει σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Καταγραφή και συνέχεια εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| [UnexpectedContent](https://reference.aspose.com/slides/el/python-java/aspose.slides/warningtype/#UnexpectedContent) | Η πηγή περιέχει μη υποστηριζόμενο ή μη αναγνωρισμένο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Καταγραφή και συνέχεια, ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία θα πρέπει να καθορίζει την απόφαση πολιτικής. Αποθηκεύστε την τιμή που επιστρέφει η `getDescription` για διαγνωστικούς σκοπούς, αλλά μη βασίζεστε στη διατύπωσή της για λογική εφαρμογής, επειδή το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ διαφορετικών σεναρίων προειδοποίησης και εκδόσεων του προϊόντος.

## **Συλλογή και Κατηγοριοποίηση Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μία αναφορά επιπέδου εφαρμογής για ολόκληρη τη διαδικασία επεξεργασίας. Ένα ξεχωριστό instance του callback επισημαίνει τις προειδοποιήσεις από τη φόρτωση, την απόδοση, τη μετατροπή σε PDF και την αποθήκευση σε PPTX. Η πολιτική απορρίπτει σε περίπτωση φθορών πηγής ή απώλειας δεδομένων, προαιρετικά απορρίπτει σε περίπτωση σημαντικής απώλειας μορφοποίησης και συνεχίζει για τις άλλες προειδοποιήσεις.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Δώστε `False` για το `abort_on_major_formatting_loss` κατά την κατασκευή του `WarningPolicy` εάν οι σημαντικές διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζεται. Επεκτείνετε τη μέθοδο `WarningPolicy.get_action` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποίησης**

Οι προειδοποιήσεις μπορούν να εμφανιστούν σε διαφορετικά στάδια μιας ροής εργασίας:

- **Ψηφιακές υπογραφές:** Μια υπογεγραμμένη παρουσίαση μπορεί να παράγει μια προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτή την κατάσταση `DataLoss` μέσω του `IPresentationSignedWarningInfo`. Ένα callback στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερόμενη απώλεια.
- **Αντικατάσταση γραμματοσειράς:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω απορρίπτει ακόμη και αν η εφαρμογή θεωρεί την αντικατάσταση οπτικά αποδεκτή. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο περιβάλλον εκτέλεσης. Η περιγραφή της προειδοποίησης προσδιορίζει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή τους [font substitution rules](/slides/el/python-java/font-substitution/) πριν ξαναδοκιμάσετε.
- **Μη υποστηριζόμενο ή μη αναμενόμενο περιεχόμενο:** Ένας φορτωτής μπορεί να αντιμετωπίσει εγγραφές παρουσίασης ή λειτουργίες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν το `UnexpectedContent`, ή μια πιο σοβαρή κατηγορία όταν γνωρίζεται ότι τα δεδομένα ή η μορφοποίηση επηρεάζονται.
- **Συμβατότητα μορφότυπου:** Η αποθήκευση σε διαφορετικό μορφότυπο παρουσίασης μπορεί να παραλείψει λειτουργίες ή να παραγάγει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερα από οκτώ οριζόντια ή οκτώ κάθετα οδηγούς σχεδίασης σε κλησθέν PPT αναφέρει ένα `CompatibilityIssue`. Το callback στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να το απορρίψει εάν απαιτείται η διατήρηση όλων των οδηγών.
- **Συμπεριφορά φόρτωσης:** Οι επιλογές φόρτωσης και οι παλαιές συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το `IObsoletePresLockingBehaviorWarningInfo` εντοπίζει τη χρήση παλιάς συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το πηγαίο έγγραφο, το μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέτετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μόνο μία κατηγορία.

## **Ασφαλής Διαχείριση Απορριφθέντων Λειτουργιών**

Όταν ένα callback επιστρέφει `ReturnAction.Abort`, μην χρησιμοποιήσετε ένα αντικείμενο που απέτυχε να φορτωθεί και μην υποθέτετε ότι η έξοδος απόδοση ή αποθήκευσης είναι πλήρης. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε ξεχωριστή διαδρομή, π.χ. `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποιήσεων ικανοποιεί την πολιτική της εφαρμογής και η έξοδος μπορεί να ανοιχθεί και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου πηγαίου αρχείου με ένα μερικό ή απορριφθέν αποτέλεσμα.

Μια κενή αναφορά προειδοποιήσεων δεν αποτελεί εγγύηση ότι κάθε πηγαία δυνατότητα έχει διατηρηθεί. Εφαρμόστε τυχόν πρόσθετους ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης [Open Presentations](/slides/el/python-java/open-presentation/) και [Save Presentations](/slides/el/python-java/save-presentation/).

## **FAQ**

**Μπορεί ένα callback προειδοποίησης να διαχειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Διαχειρίζεται ανακτήσιμες καταστάσεις που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που εμφανίζονται ανεξάρτητα από το callback πρέπει να αντιμετωπίζονται από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Η επιστροφή `ReturnAction.Continue` εγγυάται πανομοιότυπο αποτέλεσμα;**

Όχι. Επιτρέπει μόνο τη συνέχιση της επεξεργασίας. Η αναφερόμενη κατάσταση μπορεί ακόμη να προκαλέσει διαφορές στα δεδομένα, τη μορφοποίηση ή τη συμβατότητα, επομένως πρέπει να εξετάζετε τους συλλεχθέντες τύπους προειδοποιήσεων και τις περιγραφές τους.

**Πώς μπορεί μια εφαρμογή να προσδιορίσει τη λειτουργία που παρήγαγε μια προειδοποίηση;**

Δημιουργήστε ένα instance του callback για κάθε λειτουργία και αποθηκεύστε ένα στάδιο που ορίζεται από την εφαρμογή μαζί με τις τιμές που επιστρέφονται από τη `getWarningType` και τη `getDescription`, όπως φαίνεται στο παράδειγμα.