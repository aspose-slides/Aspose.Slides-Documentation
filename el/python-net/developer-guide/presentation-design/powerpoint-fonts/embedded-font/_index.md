---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις με Python
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/python-net/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides for Python μέσω .NET. Χρησιμοποιήστε την Python για προσθήκη, ανάκτηση, αφαίρεση και συμπίεση γραμματοσειρών ώστε να διατηρείτε την εμφάνιση του κειμένου και να μειώνετε το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίσει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα‑στόχο. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος του κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να ανακτήσετε, να προσθέσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές μέσω της ιδιότητας [fonts_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/fonts_manager/) ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Μπορείτε επίσης να μειώσετε το μέγεθος των δεδομένων ενσωματωμένων γραμματοσειρών αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Λήψη και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [get_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) για να παραθέσετε τις γραμματοσειρές που αποθηκεύονται σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μία γραμματοσειρά από αυτή τη λίστα στη μέθοδο [remove_embedded_font](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/remove_embedded_font/), μετά αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα παραθέτει τις ενσωματωμένες γραμματοσειρές στο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri εάν υπάρχει:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Η αφαίρεση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα‑στόχο, το κείμενο μπορεί ακόμα να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτεί [υποκατάσταση γραμματοσειράς](/slides/el/python-net/font-substitution/), κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Επιθεώρηση Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήστε την κλάση [FontsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/) για να εξετάσετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε τη μέθοδο [get_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontdata/) και την απαιτούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontstyletype/) στη μέθοδο [get_font_bytes](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_font_bytes/). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για αυτό το στυλ γραμματοσειράς, ή `None` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε ένα αποτέλεσμα `None` στη μέθοδο [get_font_embedding_level](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), επειδή αυτή απαιτεί έναν πίνακα byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides/embeddinglevel/) είναι μια απαρίθμηση σημαιών που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `INSTALLABLE` επιτρέπει την ενσωμάτωση και μόνιμη εγκατάσταση σε άλλο σύστημα, υπό τους όρους της άδειας της γραμματοσειράς.
- `RESTRICTED` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PREVIEW_PRINT` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `EDITABLE` επιτρέπει προσωρινή χρήση και επιτρέπει το έγγραφο να επεξεργαστεί και να αποθηκευτεί.
- `NO_SUBSETTING` είναι ένας επιπλέον περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλύφων. Ενσωματώνονται όλοι οι χαρακτήρες όταν αυτή η σημαία υπάρχει.
- `BITMAP_ONLY` είναι ένας επιπλέον περιορισμός που επιτρέπει μόνο bitmap strikes να ενσωματωθούν, όχι δεδομένα περιγράμματος. Εάν η γραμματοσειρά δεν έχει bitmap strikes, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ οι `NO_SUBSETTING` και `BITMAP_ONLY` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τους τροποποιητές με δεοντολογικές (bitwise) πράξεις. Δεδομένου ότι το `INSTALLABLE` είναι μηδέν, μάσκαρε τα bits άδειας χρήσης και σύγκρινε το αποτέλεσμα με το `INSTALLABLE`. Οι τρέχουσες γραμματοσειρές πρέπει να θέτουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που ορίζουν περισσότερα από ένα, ο βοηθός παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `EDITABLE`, μετά `PREVIEW_PRINT`, μετά `RESTRICTED`.

Το παρακάτω παράδειγμα ελέγχει τα κανονικά, έντονα, πλάγιες και έντονα‑πλάγιες δεδομένα που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφει το `get_fonts`. Παραλείπει μη διαθέσιμα στυλ, περιορισμένες γραμματοσειρές, γραμματοσειρές μόνο‑bitmap, γραμματοσειρές περιορισμένες στην προεπισκόπηση και εκτύπωση επειδή η έξοδος παραμένει επεξεργάσιμη, και γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NO_SUBSETTING`, ενσωματώνει όλους τους χαρακτήρες για αυτήν την οικογένεια γραμματοσειρών.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν χορηγεί άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα, ούτε αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν διανείμετε ένα ενσωματωμένο αντίγραφο.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [add_embedded_font](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/add_embedded_font/) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontdata/) είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/embedfontcharacters/) καθορίζει ποιους χαρακτήρες θα περιληφθούν:

- [ALL](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες της γραμματοσειράς. Χρησιμοποιήστε αυτήν την επιλογή όταν οι παραλήπτες χρειάζεται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [ONLY_USED](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για μείωση του μεγέθους του αρχείου. Επιλέξτε αυτήν την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το [get_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνημα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Η μέθοδος [compress_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) μειώνει τα δεδομένα ενσωματωμένης γραμματοσειράς αφαιρώντας αχρησιμοποίητους χαρακτήρες. Δρα σε γραμματοσειρές που είναι ήδη ενσωματωμένες, έτσι η μείωση μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα σε ξεχωριστό αρχείο:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Διατηρήστε το αρχικό αρχείο εάν οι παραλήπτες μπορεί να χρειαστούν να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν μια ενσωματωμένη γραμματοσειρά θα αντικατασταθεί κατά την απόδοση;**

Καλέστε τη μέθοδο [get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Επίσης ελέγξτε τις ρυθμίσεις [υποκατάστασης γραμματοσειράς](/slides/el/python-net/font-substitution/) και τους κανόνες [fallback‑font](/slides/el/python-net/fallback-font/). Το fallback διαχειρίζεται ελλείποντες χαρακτήρες, έτσι η ενσωμάτωση μιας γραμματοσειράς δεν λύνει χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Θα πρέπει να ενσωματώσω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βάλετε την απόφαση σε σχέση με το περιβάλλον-στόχο. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωσή τους μπορεί να αυξήσει άσκοπα το μέγεθος του αρχείου. Εάν οι παραλήπτες ή οι διακομιστές ενδέχεται να μην έχουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης εμφάνισης, εφόσον οι άδειές τους το επιτρέπουν.