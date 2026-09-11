---
title: Προσαρμόστε τις γραμματοσειρές PowerPoint σε Python μέσω Java
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/python-java/custom-font/
keywords:
- γραμματοσειρά
- προσαρμοσμένη γραμματοσειρά
- εξωτερική γραμματοσειρά
- φόρτωση γραμματοσειράς
- διαχείριση γραμματοσειρών
- φάκελος γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Python μέσω Java, ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε κάθε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών σε επίπεδο εγγράφου ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθάει να διατηρείται η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να αδειάσετε την προσωρινή μνήμη γραμματοσειρών μετά από εργασία με εξωτερικές γραμματοσειρές.

Η καταγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρει διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτές οι αντιστοιχίσεις αποθηκεύουν ονόματα γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε [Γραμματοσειρές Θέματος Κατά Σενάριο](/slides/el/python-java/script-specific-font-mappings/) για τη διαχείριση των αντιστοιχίσεων και χρησιμοποιήστε τις επιλογές φόρτωσης παρακάτω για να κάνετε τις αναφερόμενες γραμματοσειρές διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Σημείωση" %}}
Το Aspose.Slides σάς επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειράς.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFonts) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε τη μέθοδο [FontsLoader.clearCache](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#clearCache) για να αδειάσετε την προσωρινή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Αποδώστε/εξάγετε την παρουσίαση χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Αδειάστε την προσωρινή μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Σημείωση" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFonts) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#getFontFolders) ώστε να μπορείτε να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει τους φακέλους που προστέθηκαν μέσω της μεθόδου [loadExternalFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFonts) και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Λάβετε φακέλους που προστέθηκαν μέσω του loadExternalFonts και φακέλους γραμματοσειρών του συστήματος.
font_folders = FontsLoader.getFontFolders()
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Μία Παρουσίαση**

Το Aspose.Slides παρέχει τη μέθοδο [getDocumentLevelFontSources](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε τη μέθοδο [getDocumentLevelFontSources](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Εργαστείτε με την παρουσίαση.
    # CustomFont1, CustomFont2 και γραμματοσειρές από assets/fonts και global/fonts
    # και οι υποφακέλοι τους είναι διαθέσιμοι στην παρουσίαση.
    pass
finally:
    presentation.dispose()
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFont) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας Python επιδεικνύει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Οι εξωτερικές γραμματοσειρές φορτώνονται κατά τη διάρκεια της ζωής της παρουσίασης.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδοχέα σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [δυνατότητες ενσωμάτωσης](/slides/el/python-java/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπει κάποιες γλύφους;**

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/python-java/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/python-java/font-replacement/) και τα [σετ εναλλακτικών](/slides/el/python-java/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφος.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλοντα Linux/Docker χωρίς να τις εγκαταστήσω σε όλο το σύστημα;**

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του container.

**Τι γίνεται με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· κάποιες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα ελέγχετε το EULA της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.