---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις με Python μέσω Java
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/python-java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides για Python μέσω Java. Προσθέστε, ανακτήστε, αφαιρέστε και συμπιέστε γραμματοσειρές ώστε να διατηρήσετε την εμφάνιση του κειμένου και να μειώσετε το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίσει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα προορισμού. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides για Python μέσω Java σάς επιτρέπει να ανακτήσετε, να προσθέσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) που επιστρέφεται από το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager). Μπορείτε επίσης να μειώσετε το μέγεθος των δεδομένων ενσωματωμένων γραμματοσειρών αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδεια της επιτρέπει την ενσωμάτωση.

## **Λήψη και κατάργηση ενσωματωμένων γραμματοσειρών**

Χρησιμοποιήστε το [getEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να απαριθμήσετε τις γραμματοσειρές που αποθηκεύονται σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στο [removeEmbeddedFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), κατόπιν αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα απαριθμεί τις ενσωματωμένες γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri εάν υπάρχει:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Η κατάργηση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα προορισμού, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει αντικατάσταση γραμματοσειράς, κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Έλεγχος δεδομένων γραμματοσειράς και δικαιωμάτων ενσωμάτωσης**

Χρησιμοποιήστε την κλάση [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) για να ελέγξετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε το [FontsManager.getFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFonts) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontdata/) και τη ζητούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontstyletype/) στο [FontsManager.getFontBytes](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFontBytes). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για το συγκεκριμένο στυλ γραμματοσειράς ή `None` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε το αποτέλεσμα `None` στο [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), επειδή αυτή η μέθοδος απαιτεί έναν πίνακα byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/embeddinglevel/) είναι μια απαρίθμηση σημάνσεων που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και την μόνιμη εγκατάσταση σε άλλο σύστημα, υπό την προϋπόθεση της άδειας της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει την επεξεργασία και αποθήκευση του εγγράφου.
- `NoSubsetting` είναι πρόσθετος περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλυφών. Ενσωματώστε όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι πρόσθετος περιορισμός που επιτρέπει μόνο ενσωμάτωση bitmap‑strikes, όχι δεδομένα περίγραμμα. Εάν η γραμματοσειρά δεν έχει bitmap‑strikes, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ οι `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τις μεταβολές με τελεστές λογικού ή. Επειδή το `Installable` είναι μηδέν, εφαρμόστε μάσκα στα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με το `Installable` αντί να το ελέγχετε ως σημαία. Οι τρέχουσες γραμματοσειρές θα πρέπει να θέτουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που θέτουν περισσότερα από ένα, ο βοηθός παρακάτω επιλέγει την πιο χαλαρή άδεια: `Editable`, έπειτα `PreviewPrint`, έπειτα `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα κανονικά, έντονα, πλάγια και έντονα‑πλάγια δεδομένα που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφεται από το `getFonts`. Παραλείπει στυλ που δεν είναι διαθέσιμα, περιορισμένες γραμματοσειρές, γραμματοσειρές μόνο bitmap, γραμματοσειρές περιορισμένες στην προεπισκόπηση και εκτύπωση επειδή το αποτέλεσμα παραμένει επεξεργάσιμο, και γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν οποιοδήποτε διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για αυτή τη οικογένεια γραμματοσειρών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα και δεν αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν διανείμετε ένα ενσωματωμένο αντίγραφο.

## **Προσθήκη ενσωματωμένων γραμματοσειρών**

Χρησιμοποιήστε το [addEmbeddedFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontdata/) είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/python-java/aspose.slides/embedfontcharacters/) ελέγχει ποιοι χαρακτήρες θα συμπεριληφθούν:

- [All](https://reference.aspose.com/slides/el/python-java/aspose.slides/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες της γραμματοσειράς. Χρησιμοποιήστε αυτή την επιλογή όταν οι παραλήπτες χρειάζονται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/python-java/aspose.slides/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειώσει το μέγεθος του αρχείου. Επιλέξτε αυτή την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το [getFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFonts) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο αρχείο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στη μηχανή που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συμπίεση ενσωματωμένων γραμματοσειρών**

Η μέθοδος [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#compressEmbeddedFonts) μειώνει τα δεδομένα ενσωματωμένων γραμματοσειρών αφαιρώντας αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, επομένως η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Διατηρήστε το αρχικό αρχείο εάν οι παραλήπτες ενδέχεται να χρειαστούν να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν μια ενσωματωμένη γραμματοσειρά θα αντικατασταθεί ακόμη κατά την απόδοση;**

Καλέστε το [getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Ελέγξτε επίσης τις ρυθμίσεις αντικατάστασης γραμματοσειρών και τους κανόνες πτώσης (fallback). Η πτώση αντιμετωπίζει ελλιπείς χαρακτήρες, επομένως η ενσωμάτωση μιας γραμματοσειράς δεν λύνει χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Πρέπει να ενσωματώσω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βάστε την απόφαση στο περιβάλλον προορισμού. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωσή τους μπορεί να προσθέσει άσκοπο μέγεθος αρχείου. Εάν οι παραλήπτες ή οι διακομιστές ενδέχεται να μην έχουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης εμφάνισης, υπό την προϋπόθεση ότι οι άδειες τους το επιτρέπουν.