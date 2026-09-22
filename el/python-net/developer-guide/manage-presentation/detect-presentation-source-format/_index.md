---
title: Καθορίστε την αρχική μορφή παρουσίασης σε Python
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/python-net/detect-presentation-source-format/
keywords:
- μορφή πηγής
- εντοπισμός μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης σε Python με το Aspose.Slides για Python μέσω .NET, συγκρίνετε τα APIs εντοπισμού και χειριστείτε αρχεία, ροές και κληρονομικές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, διαβάστε την μόνο για ανάγνωση ιδιότητα [Presentation.source_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/source_format/) για να καθορίσετε την αρχική της μορφή. Χρησιμοποιήστε την όταν η επακόλουθη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε η τρέχουσα παρουσίαση.

Η μορφή πηγής διαφέρει από το [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει τη μορφή πηγής της υπάρχουσας παρουσίασης.

## **Ανάγνωση της Μορφής Πηγής ενός Αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας εφαρμογής χρησιμοποιώντας [Presentation.source_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/source_format/), αντί για το όνομα αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Το [SourceFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/sourceformat/) enumeration διακρίνει τις ακόλουθες μορφές παρουσίασης. Οι παρακάτω καταλήξεις είναι συμβατικές, όχι ανασυγκρότηση του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `PPT` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Παρουσίαση Office Open XML |
| `PPTM` | `.pptm` | Παρουσίαση Office Open XML με ενεργοποιημένα μακροεντολές |
| `PPS` | `.pps` | Παρουσίαση διαφάνειας PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Παρουσίαση διαφάνειας Office Open XML |
| `PPSM` | `.ppsm` | Παρουσίαση διαφάνειας Office Open XML με ενεργοποιημένα μακροεντολές |
| `POT` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `POTX` | `.potx` | Πρότυπο Office Open XML |
| `POTM` | `.potm` | Πρότυπο Office Open XML με ενεργοποιημένα μακροεντολές |
| `ODP` | `.odp` | Παρουσίαση OpenDocument |
| `OTP` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `FODP` | `.fodp` | Παρουσίαση Flat XML ODF |
| `XML` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της Μορφής Πηγής από Ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των bytes του σε μια ροή μνήμης προσομοιώνει είσοδο που λαμβάνεται χωρίς όνομα αρχείου, π.χ. τιμή βάσης δεδομένων ή ανεβασμένο byte array. Ο κατασκευαστής του [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) δέχεται μόνο τη ροή.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

Τα `PPT`, `PPS` και `POT` χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Όταν φορτώνεται με διαδρομή αρχείου, η κατάληξη μπορεί να βοηθήσει να διακριθεί μια διαφάνεια ή πρότυπο. Χωρίς όνομα αρχείου, τα παλαιά περιεχόμενα `PPS` και `POT` μπορεί να αναφερθούν ως `SourceFormat.PPT`; το παράδειγμα `PPS` παραπάνω αναφέρει `PPT`.

Αν η εφαρμογή σας πρέπει να διατηρήσει τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου χωριστά. Η κατάληξη είναι χρήσιμη υπόδειξη για αυτά τα παλαιά υποτυπώματα, αλλά δεν πρέπει να αποτελεί την μοναδική βάση για την ταυτοποίηση αυθαίρετου περιεχομένου παρουσίασης.

## **Σύγκριση Ανίχνευσης Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και [PresentationInfo.load_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/load_format/) όταν χρειάζεται να εξετάσετε ένα αρχείο πριν φορτώσετε το πλήρες μοντέλο αντικειμένων παρουσίασης. Χρησιμοποιήστε [Presentation.source_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/source_format/) όταν η παρουσίαση υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί `sample.pptx` και εκτυπώνει `PPTX` και για τις δύο ελέγχους. Στην παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν χρειάζεται δεύτερη επιθεώρηση μόνο για την απόκτηση της μορφής πηγής.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Τα αποτελέσματα έχουν διαφορετικούς τύπους enumeration: [LoadFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/sourceformat/). Μην τα συγκρίνετε μετατρέποντας τις αριθμητικές τους τιμές ή υποθέτετε ότι κάθε μορφή έχει ταυτόσια αποτελέσματα ανίχνευσης. Στον έλεγχο αποθήκευσης‑ανοιγματος που περιγράφεται παρακάτω, το PowerPoint XML αναφέρθηκε ως `LoadFormat.UNKNOWN` πριν τη φόρτωση και ως `SourceFormat.XML` μετά τη φόρτωση.

## **Διατήρηση Ξεχωριστών Μορφών Πηγής και Εξόδου**

Αυτό το παράδειγμα απαιτεί `sample.pptx` και γράφει `converted.odp`. Εκτυπώνει `PPTX` πριν και μετά την αποθήκευση της αρχικής παρουσίασης. Μόνο η νέα παρουσίαση που φορτώνεται από το αρχείο εξόδου ODP αναφέρει `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Μια παρουσίαση που δημιουργείται από το μηδέν με `slides.Presentation()` αναφέρει `SourceFormat.PPTX`. Δεν έχει αρχείο εισόδου: αυτή είναι η προεπιλογή για μια νεοδημιουργημένη παρουσίαση, όχι ένδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθήστε εάν η εφαρμογή σας δημιούργησε ή φόρτωσε την παρουσίαση ξεχωριστά αν αυτή η διάκριση είναι σημαντική.

## **Χαρτογράφηση Μορφής Πηγής σε Επέκταση**

Αυτό το παράδειγμα απαιτεί `sample.pptx`. Χαρτογραφεί κάθε τρέχουσα υποστηριζόμενη τιμή του [SourceFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/sourceformat/) σε μία συμβατική κατάληξη, χωρίς να αναλύει το όνομα αρχείου εισόδου. Η εναλλακτική λύση αποτρέπει την αθόρυβη ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Αυτή η χαρτογράφηση δεν μετατρέπει αρχείο ούτε ανακτά παλαιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση από ροή. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών μέσω Αποθήκευσης και Επαναφοράς**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Ανοίγει ξανά κάθε έξοδο τόσο με διαδρομή όσο και μέσω ροής μνήμης. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `PPS`, ενώ η φόρτωση των ίδιων bytes χωρίς όνομα αρχείου αναφέρει `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Ο ίδιος έλεγχος με όλες τις παραπάνω μορφές παρήγαγε τα ακόλουθα αποτελέσματα για δημιουργημένες παρουσιάσεις με αντιστοιχίες καταλήξεων:

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| ODP, OTP | `ODP`, `OTP` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Σε αυτούς τους ελέγχους, η μόνη κανονικοποίηση μορφής πηγής ήταν η μετατροπή PPS/POT σε `PPT` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την ταυτοποίηση μορφής, όχι τη διατήρηση κάθε χαρακτηριστικού παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP τη μορφή πηγής μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα παρουσίαση εξακολουθεί να αναφέρει `PPTX`. Μια παρουσίαση που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `ODP`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλαιά παρουσίαση, μια διαφάνεια και ένα πρότυπο;**

Όχι. Τα `PPT`, `PPS` και `POT` μοιράζονται την ίδια δυαδική μορφή. Κρατήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου χωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω εάν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε [Presentation.source_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/source_format/). Χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για επιθεώρηση πριν τη φόρτωση.