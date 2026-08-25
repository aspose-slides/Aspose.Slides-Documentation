---
title: Προσαρμογή γραμματοσειρών PowerPoint σε Python
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/python-net/custom-font/
keywords:
- γραμματοσειρά
- προσαρμοσμένη γραμματοσειρά
- εξωτερική γραμματοσειρά
- φόρτωση γραμματοσειράς
- διαχείριση γραμματοσειρών
- φάκελος γραμματοσειρών
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ενσωματώστε προσαρμοσμένες γραμματοσειρές σε διαφάνειες PowerPoint με το Aspose.Slides for Python μέσω .NET για να διατηρήσετε τις παρουσιάσεις σας καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides for Python σας επιτρέπει να παρέχετε προσαρμοσμένες γραμματοσειρές κατά την εκτέλεση, ώστε οι παρουσιάσεις να αποδίδουν σωστά ακόμη και όταν οι απαιτούμενες γραμματοσειρές δεν είναι εγκατεστημένες στο σύστημα του κεντρικού υπολογιστή. Κατά την εξαγωγή σε PDF ή εικόνες, μπορείτε να παρέχετε φακέλους γραμματοσειρών ή γραμματοσειρές στη μνήμη για να διατηρήσετε τη διάταξη κειμένου, τις μετρήσεις των γλυφών και την τυπογραφία. Αυτό κάνει την απόδοση στον διακομιστή προβλέψιμη σε διαφορετικά περιβάλλοντα, αφαιρεί τις εξαρτήσεις γραμματοσειρών σε επίπεδο λειτουργικού συστήματος και αποτρέπει ανεπιθύμητες εναλλακτικές ή επαναδιάταξη. Το άρθρο δείχνει πώς να καταχωρίσετε πηγές γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρεται σε διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτοί οι χάρτες αποθηκεύουν ονόματα γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε [Script-Specific Theme Fonts](/slides/el/python-net/script-specific-font-mappings/) για τη διαχείριση των αντιστοιχίσεων και χρησιμοποιήστε τις επιλογές φόρτωσης παρακάτω για να κάνετε τις αναφερθείσες γραμματοσειρές διαθέσιμες για συνεπή απόδοση.

Το Aspose.Slides σας επιτρέπει να φορτώνετε τις παρακάτω γραμματοσειρές χρησιμοποιώντας τις μεθόδους `load_external_font` και `load_external_fonts` της κλάσης [FontsLoader](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) γραμματοσειρές. Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλα υποστηριζόμενα μορφότυπα — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/load_external_fonts/) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.clear_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/clear_cache/) για να καθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης των γραμματοσειρών:

```py
import aspose.slides as slides

# Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
font_folders = ["fonts", "external_fonts"]

# Φορτώστε προσαρμοσμένες γραμματοσειρές από τους συγκεκριμένους φακέλους.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά το πέρας της εργασίας.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/load_external_fonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω [FontsLoader](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένου Φακέλου Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο `get_font_folders` για την ανάκτηση των φακέλων γραμματοσειρών. Επιστρέφει τόσο τους φακέλους που προστέθηκαν μέσω `load_external_fonts` όσο και τους φακέλους συστήματος.

Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε το `get_font_folders`:

```python
import aspose.slides as slides

# Αυτή η κλήση επιστρέφει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
# Αυτοί περιλαμβάνουν φακέλους που προστέθηκαν μέσω της μεθόδου load_external_fonts και τους φακέλους γραμματοσειρών του συστήματος.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα `document_level_font_sources`, η οποία σας επιτρέπει να καθορίσετε εξωτερικές γραμματοσειρές για χρήση σε μια παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να χρησιμοποιήσετε το `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Εργαστείτε με την παρουσίαση.
    # Οι CustomFont1, CustomFont2 και γραμματοσειρές από τους φακέλους assets\fonts και global\fonts (και τους υποφακέλους τους) είναι διαθέσιμες στην παρουσίαση.
    # ...
    print(len(presentation.slides))
```

## **Φόρτωση Εξωτερικών Γραμματοσειρών από Δυαδικά Δεδομένα**

Το Aspose.Slides παρέχει τη μέθοδο `load_external_font` για τη φόρτωση εξωτερικών γραμματοσειρών από δυαδικά δεδομένα.

Το παρακάτω παράδειγμα Python δείχνει τη φόρτωση μιας γραμματοσειράς από έναν πίνακα byte:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Φορτώστε εξωτερικές γραμματοσειρές από πίνακες byte.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Οι εξωτερικές γραμματοσειρές είναι διαθέσιμες κατά τη διάρκεια της ζωής αυτής της παρουσίασης.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

### Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδοχέα σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε ένα PPTX. Εάν χρειάζεστε τη γραμματοσειρά μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [embedding features](/slides/el/python-net/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλύφα;

Ναι. Διαμορφώστε την [font substitution](/slides/el/python-net/font-substitution/), τους [replacement rules](/slides/el/python-net/font-replacement/), και τα [fallback sets](/slides/el/python-net/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν το ζητούμενο γλύφη λείπει.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε Linux/Docker containers χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;

Ναι. Κατευθύνετε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε τις γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από καταλόγους γραμματοσειρών του συστήματος στην εικόνα του container.

### Τι γίνεται με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγξτε την EULA της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.