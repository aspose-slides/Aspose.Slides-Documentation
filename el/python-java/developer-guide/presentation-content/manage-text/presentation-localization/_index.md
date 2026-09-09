---
title: Αυτοματοποιήστε την τοπική προσαρμογή παρουσιάσεων σε Python μέσω Java
linktitle: Τοπική Προσαρμογή Παρουσίασης
type: docs
weight: 100
url: /el/python-java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- καταστολή ορθογραφικού ελέγχου
- γλώσσα ελέγχου
- αναγνωριστικό γλώσσας
- πολυγλωσσικό κείμενο
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ορίστε γλώσσες ελέγχου για το κείμενο παρουσίασης PowerPoint και OpenDocument σε Python μέσω Java με το Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολυγλωσσικών παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java σάς επιτρέπει να διαμορφώσετε μεταδεδομένα ελέγχου απόδειξης για μεμονωμένες περιοχές κειμένου. Χρησιμοποιήστε [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) για να προσδιορίσετε τη γλώσσα ελέγχου, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) για να επιτρέψετε ή να καταστείλετε τον ορθογραφικό έλεγχο και [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setProofDisabled) για να ελέγξετε τη γενικότερη κατάσταση «μη απόδειξη». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο περιοχής, μία παράγραφος μπορεί να περιέχει πολλές γλώσσες και διαφορετικούς κανόνες ελέγχου.

Αυτό το άρθρο εξηγεί πώς να αντιστοιχίσετε μια γλώσσα σε συγκεκριμένο κείμενο, να ορίσετε τη προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), να δημιουργήσετε πολυγλωσσικές παραγράφους, να επιλέξετε ανάμεσα σε [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) και [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setProofDisabled) και να διατηρήσετε τις προτιμώμενες ρυθμίσεις όταν χρησιμοποιείτε [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν ορθογραφικό έλεγχο βάσει λεξικού ούτε επιστρέφουν λανθασμένες λέξεις.

## **Ορίστε τη Γλώσσα Ελέγχου για Κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), προσπελάστε την απαιτούμενη περιοχή κειμένου μέσω [Portion.getPortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getPortionFormat) και αντιστοιχίστε το αναγνωριστικό γλώσσας της. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τα βρετανικά αγγλικά ως γλώσσα ελέγχου και αποθηκεύει το αποτέλεσμα με [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορίστε την Προεπιλεγμένη Γλώσσα για Νέο Κείμενο**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να καθορίσετε τη γλώσσα ελέγχου που το Aspose.Slides αντιστοιχίζει σε νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν τα περισσότερα ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας κειμένου που ήδη έχει ρητή γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες ελέγχου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Χρησιμοποιήστε Πολλαπλές Γλώσσες σε Μία Παράγραφο**

Ένα [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) περιέχει μια συλλογή από περιοχές κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) για κάθε γλώσσα και ορίστε ανεξάρτητα το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId).

Αυτό το παράδειγμα δημιουργεί μία παράγραφο με περιοχές στα αγγλικά και τα γαλλικά:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ενεργοποίηση ή Καταστολή Ορθογραφικού Ελέγχου για Μεμονωμένες Περιοχές**

Το [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από το [BasePortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/). Προσπελάστε τη μορφή μιας περιοχής μέσω [Portion.getPortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getPortionFormat) και χρησιμοποιήστε [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) για να ελέγξετε αν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνη την περιοχή. Η προεπιλεγμένη τιμή είναι `False`: `True` επιτρέπει τον ορθογραφικό έλεγχο, ενώ `False` τον καταστέλλει.

Η ρύθμιση εφαρμόζεται σε μεμονωμένες περιοχές κειμένου. Διαφορετικές περιοχές στην ίδια παράγραφο μπορούν επομένως να χρησιμοποιούν διαφορετικές τιμές. Τα [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) και [setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) εξυπηρετούν συμπληρωματικούς σκοπούς: το [setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) προσδιορίζει τη γλώσσα ελέγχου, ενώ το [setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) καθορίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για την περιοχή.

Το [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setProofDisabled) ελέγχει επίσης το ελέγχο, αλλά αντιπροσωπεύει τη γενικότερη κατάσταση «μη απόδειξη» ως ένα [NullableBool](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/). Χρησιμοποιήστε [setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) όταν χρειάζεστε έναν άμεσο Boolean διακόπτη ειδικά για ορθογραφικούς ελέγχους. Χρησιμοποιήστε [setProofDisabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setProofDisabled) όταν χρειάζεται να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη απόδειξη» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης [NullableBool.NotDefined](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/#NotDefined). Αν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συνεπείς· μην συνδυάσετε το [setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) ορισμένο σε `True` με το [setProofDisabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setProofDisabled) ορισμένο στην κατάσταση [NullableBool.True](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/#True).

Αυτές οι ιδιότητες ρυθμίζουν τα μεταδεδομένα ελέγχου που χρησιμοποιούνται από το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για να εκτελέσει ορθογραφικό έλεγχο βάσει λεξικού ή για να επιστρέψει λίστα λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια παρουσίαση εισόδου, τη φορτώνει, αντιστοιχίζει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες ελέγχου σε δύο περιοχές στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ξανανοίγει και επαληθεύει τις αποθηκευμένες τιμές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) συγχωνεύει διαδοχικές περιοχές που έχουν την ίδια μορφοποίηση. Μια διαφορά μόνο στο [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpellCheck) δεν τα κρατά χωριστά· μετά τη συγχώνευση, η προκύπτουσα περιοχή διατηρεί την τιμή του [BasePortionFormat.setSpellCheck] της πρώτης περιοχής. Αν οι περιοχές χρειάζονται διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου, καλέστε το [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) πριν ορίσετε αυτές τις ρυθμίσεις, ή επιθεωρήστε τα όρια της προκύπτουσας περιοχής και επαναλάβετε τις ρυθμίσεις μετά. Οι περιοχές με διαφορετικές τιμές [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) παραμένουν χωριστές επειδή η μορφοποίηση της γλώσσας ελέγχου διαφέρει.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μεταφράζει το κείμενο ένα ID γλώσσας;**

Όχι. Το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) αποθηκεύει μεταδεδομένα ελέγχου για ορθογραφία και γραμματική· δεν τροποποιεί το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένη περιοχή.

**Ελέγχει η γλώσσα ελέγχου τις γραμματοσειρές, τη συλλαβοποίηση ή τη συσκότιση γραμμής;**

Όχι. Το αναγνωριστικό γλώσσας αφορά μόνο τον έλεγχο. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/python-java/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, ρυθμίστε την [font substitution](/slides/el/python-java/font-substitution/) ή [embed fonts](/slides/el/python-java/embedded-font/) στην παρουσίαση.

**Μπορεί μία παράγραφος να χρησιμοποιεί πολλές γλώσσες ελέγχου;**

Ναι. Αναθέστε κάθε γλώσσα σε ξεχωριστή περιοχή, όπως φαίνεται στο παράδειγμα πολυγλωσσικής παραγράφου.

**Πρέπει να χρησιμοποιήσω [setDefaultTextLanguage](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ή [setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId);**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) όταν θέλετε μια προεπιλογή για νέο κείμενο. Χρησιμοποιήστε το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) όταν μια συγκεκριμένη περιοχή χρειάζεται ρητή γλώσσα ελέγχου ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.