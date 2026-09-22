---
title: Καθορισμός της Αρχικής Μορφής Παρουσίασης σε Python μέσω Java
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/python-java/detect-presentation-source-format/
keywords:
- μορφή πηγής
- ανίχνευση μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης σε Python μέσω Java με Aspose.Slides for Python via Java, συγκρίνετε τις API ανίχνευσης και διαχειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat) για να καθορίσετε το αρχικό της μορφότυπο. Χρησιμοποιήστε τη όταν η επακόλουθη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε το τρέχον στιγμιότυπο.

Η πηγαία μορφή είναι διαφορετική από το [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει την πηγαία μορφή του υπάρχοντος στιγμιότυπου.

Τα παραδείγματα απαιτούν το Aspose.Slides για Python μέσω Java και ένα συμβατό Java runtime. Κάθε παράδειγμα ξεκινά το JVM εάν δεν εκτελείται ήδη.

## **Ανάγνωση της Πηγαίας Μορφής Αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας εφαρμογής χρησιμοποιώντας τη [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Η κλάση [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) ορίζει ακέραιους σταθερούς που διακρίνουν τις παρακάτω μορφές παρουσίασης. Οι παρακάτω επεκτάσεις είναι συμβατικές επεκτάσεις, όχι μια ανακατασκευή του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολές |
| `Pps` | `.pps` | Παρουσίαση διαφανειών PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Σειρά διαφανειών Office Open XML |
| `Ppsm` | `.ppsm` | Σειρά διαφανειών Office Open XML με μακροεντολές |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολές |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της Πηγαίας Μορφής από Ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των byte του σε μια μνήμη-ροή προσομοιώνει είσοδο που λήφθηκε χωρίς όνομα αρχείου, όπως μια τιμή βάσης δεδομένων ή ένας ανεβασμένος πίνακας byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) δέχεται μόνο τη ροή. Η Python διαβάζει τα byte του αρχείου, και το JPype τα μετατρέπει σε έναν πίνακα byte Java για τη μνήμη-ροή Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Όταν φορτώνεται με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει στον διαχωρισμό μιας σειράς διαφανειών ή προτύπου. Χωρίς όνομα αρχείου, το παλιό περιεχόμενο PPS και POT μπορεί να αναφερθεί ως `SourceFormat.Ppt`; το παραπάνω παράδειγμα PPS εκτυπώνει την ακέραια τιμή του `SourceFormat.Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Μια επέκταση είναι ένα χρήσιμο στοιχείο για αυτά τα παλιά υποτύπων, αλλά δεν πρέπει να αποτελεί τη μοναδική βάση για την αναγνώριση τυχαίου περιεχομένου παρουσίασης.

## **Σύγκριση Ανίχνευσης Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και το [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#getLoadFormat) όταν χρειάζεται να ελέγξετε ένα αρχείο πριν φορτώσετε το πλήρες μοντέλο αντικειμένων της παρουσίασης. Χρησιμοποιήστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat) όταν το στιγμιότυπο υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και εκτυπώνει τις ακέραιες τιμές των `LoadFormat.Pptx` και `SourceFormat.Pptx`, αντίστοιχα. Σε παραγωγή, επιλέξτε το API κατάλληλο για το στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν χρειάζεται δεύτερο έλεγχο μόνο για να ληφθεί η πηγαία της μορφή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Τα αποτελέσματα χρησιμοποιούν σταθερές από διαφορετικές κλάσεις: [LoadFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/). Μην συγκρίνετε τις αριθμητικές τους τιμές ή υποθέτετε ότι κάθε μορφή έχει ταυτόστροφα αποτελέσματα ανίχνευσης. Το PowerPoint XML μπορεί να αναφερθεί ως `LoadFormat.Unknown` πριν τη φόρτωση και ως `SourceFormat.Xml` μετά τη φόρτωση.

## **Διαχωρισμός Πηγαίας και Εξόδου Μορφών**

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και γράφει το `converted.odp`. Εκτυπώνει την ακέραια τιμή του `SourceFormat.Pptx` τόσο πριν όσο και αφού αποθηκευτεί το αρχικό στιγμιότυπο. Μόνο το νέο στιγμιότυπο που φορτώνεται από το αρχείο εξόδου ODP αναφέρει `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Μια παρουσίαση που δημιουργείται από την αρχή με `Presentation()` αναφέρει `SourceFormat.Pptx`. Δεν έχει αρχείο εισόδου: αυτή είναι η προεπιλεγμένη τιμή για ένα νεοδημιουργημένο στιγμιότυπο, όχι απόδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθήστε εάν η εφαρμογή σας δημιούργησε ή φόρτωσε το στιγμιότυπο ξεχωριστά εάν αυτή η διάκριση έχει σημασία.

## **Χαρτογράφηση Πηγαίας Μορφής σε Επέκταση**

Το παρακάτω παράδειγμα απαιτεί το `sample.pptx`. Αντιστοιχίζει κάθε τρέχουσα υποστηριζόμενη τιμή του [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) σε μια συμβατική επέκταση, χωρίς ανάλυση του ονόματος αρχείου εισόδου. Η εναλλακτική λύση αποτρέπει την σιωπηρή ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Αυτή η αντιστοίχηση δεν μετατρέπει ένα αρχείο ή δεν επαναφέρει έναν παλιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση ροής. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/), ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών με Αποθήκευση και Επανάληψη Άνοιγμα**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Ανοίγει εκ νέου κάθε έξοδο τόσο με τη διαδρομή όσο και μέσω μνήμης-ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων byte χωρίς όνομα αρχείου αναφέρει `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT περιεχόμενο αναγνωρίζεται ως `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την αναγνώριση μορφής, όχι τη διατήρηση κάθε χαρακτηριστικού παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP τη πηγαία μορφή μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Το υπάρχον στιγμιότυπο εξακολουθεί να αναφέρει `Pptx`. Ένα στιγμιότυπο που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλιά παρουσίαση, σειρά διαφανειών και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την δυαδική μορφή. Κρατήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω εάν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat). Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για έλεγχο πριν τη φόρτωση.