---
title: Προσαρμογή Γραμματοσειρών PowerPoint σε Python
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
description: "Ενσωματώστε προσαρμοσμένες γραμματοσειρές σε διαφάνειες PowerPoint με το Aspose.Slides για Python μέσω .NET ώστε οι παρουσιάσεις σας να παραμένουν οξύνες και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Aspose.Slides for Python σας επιτρέπει να παρέχετε προσαρμοσμένες γραμματοσειρές κατά το χρόνο εκτέλεσης ώστε οι παρουσιάσεις να εμφανίζονται σωστά ακόμη και όταν οι απαιτούμενες γραμματοσειρές δεν είναι εγκατεστημένες στο σύστημα ξενιστή. Κατά την εξαγωγή σε PDF ή εικόνες, μπορείτε να παρέχετε φακέλους γραμματοσειρών ή γραμματοσειρές σε μνήμη για να διατηρηθεί η διάταξη κειμένου, οι μετρήσεις των χαρακτήρων και η τυπογραφία. Αυτό κάνει την απόδοση στο διακομιστή προβλέψιμη σε διαφορετικά περιβάλλοντα, αφαιρεί τις εξαρτήσεις από τις γραμματοσειρές του λειτουργικού συστήματος και αποτρέπει ανεπιθύμητες εναλλακτικές ή επαναδιάταξη. Το άρθρο δείχνει πώς να καταχωρίσετε πηγές γραμματοσειρών.

Aspose.Slides σας επιτρέπει να φορτώσετε τις παρακάτω γραμματοσειρές χρησιμοποιώντας τις μεθόδους `load_external_font` και `load_external_fonts` της κλάσης [FontsLoader](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/) :

- TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) γραμματοσειρές. Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Aspose.Slides επιτρέπει τη φόρτωση γραμματοσειρών που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/load_external_fonts/) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.clear_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/clear_cache/) για να καθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```py
import aspose.slides as slides

# Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/load_external_fonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη του Φακέλου Προσαρμοσμένων Γραμματοσειρών**

Aspose.Slides παρέχει τη μέθοδο `get_font_folders` για την ανάκτηση των φακέλων γραμματοσειρών. Επιστρέφει τόσο τους φακέλους που προστέθηκαν μέσω `load_external_fonts` όσο και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε το `get_font_folders`:

```python
import aspose.slides as slides

# Αυτή η κλήση επιστρέφει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
# Αυτοί περιλαμβάνουν φακέλους που προστέθηκαν μέσω της μεθόδου load_external_fonts και τους φακέλους γραμματοσειρών του συστήματος.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για μια Παρουσίαση**

Aspose.Slides παρέχει την ιδιότητα `document_level_font_sources`, η οποία σας επιτρέπει να καθορίσετε εξωτερικές γραμματοσειρές προς χρήση με μια παρουσίαση.

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
    # Εργασία με την παρουσίαση.
    # Τα CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts και global\fonts (και τους υποφακέλους τους) είναι διαθέσιμα στην παρουσίαση.
    # ...
    print(len(presentation.slides))
```

## **Φόρτωση Εξωτερικών Γραμματοσειρών από Δεδομένα Δυαδικού**

Aspose.Slides παρέχει τη μέθοδο `load_external_font` για τη φόρτωση εξωτερικών γραμματοσειρών από δυαδικά δεδομένα.

Το παρακάτω παράδειγμα Python παρουσιάζει τη φόρτωση μιας γραμματοσειράς από έναν πίνακα byte:

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
        # Οι εξωτερικές γραμματοσειρές είναι διαθέσιμες καθ' όλη τη διάρκεια αυτής της παρουσίασης.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Συχνές Ερωτήσεις**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον προσαρμογέα σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε ένα PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές δυνατότητες [embedding features](/slides/el/python-net/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γράμματα;**

Ναι. Διαμορφώστε την [font substitution](/slides/el/python-net/font-substitution/), τους [replacement rules](/slides/el/python-net/font-replacement/), και τα [fallback sets](/slides/el/python-net/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο σύμβολο.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλον Linux/Docker χωρίς να τις εγκαταστήσω σε όλο το σύστημα;**

Ναί. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί κάθε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

**Τι γίνεται με την άδεια χρήσης — μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή εμπορική χρήση. Πάντα ελέγχετε τη συμφωνία χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.