---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Markdown με Python
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/python-net/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- εξαγωγή εικόνων Markdown
- σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- Python
- Python μέσω .NET
- Aspose.Slides
description: Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown με Python και ελέγξτε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενοι σύνδεσμοι Markdown τις αναφέρονται.
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικούς ιστότοπους, μεταφορά περιεχομένου και ροές εργασίας ελέγχου εκδόσεων. Μπορείτε να επιλέξετε μια γεύση Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενες αναφορές Markdown τις δείχνουν.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί έξοδο μόνο κειμένου. Για να εξάγετε οπτικό περιεχόμενο, ορίστε την ιδιότητα [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/export_type/) στην τιμή `SEQUENTIAL` ή `VISUAL` από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownexporttype/). Το `SEQUENTIAL` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με την σειρά, ενώ το `VISUAL` διατηρεί ομαδοποιημένα τα στοιχεία για να διατηρήσει τη οπτική τους σχέση. Η τιμή `TEXT_ONLY` δεν δημιουργεί πόρους εικόνας.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και, στη συνέχεια, καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/) με την τιμή `MD` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Επιλογή Γεύσης Markdown**

Η ιδιότητα [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/flavor/) ελέγχει την προδιαγραφή Markdown που θα χρησιμοποιηθεί για το αποτέλεσμα. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Εξαγωγή Εικόνων με τη Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/) παρέχει δύο ιδιότητες για τοπικά αποθηκευμένες εικόνες:

- [base_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/base_path/) ορίζει τον βασικό κατάλογο για το έγγραφο Markdown και τους πόρους του.
- [images_save_folder_name](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) ορίζει το υποκατάλογο εικόνων. Η προεπιλεγμένη τιμή είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνων στο έγγραφο Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Το Aspose.Slides δημιουργεί τον υποκατάλογο εικόνων όταν η εξαγωγή παράγει πόρους εικόνας, αλλά η εφαρμογή πρέπει να δημιουργήσει το `base_path` πριν αποθηκεύσει το αρχείο Markdown.

## **Προετοιμασία Markdown και Εικόνων για Δημοσίευση**

Το Aspose.Slides για Python μέσω .NET δεν εκθέτει τις κλήσεις επιστροφής .NET για αποθήκευση εικόνων ώστε να αντικαθιστά κάθε παραγόμενο σύνδεσμο εικόνας κατά την εξαγωγή. Αντ' αυτού, εξάγετε το έγγραφο Markdown και το φάκελο εικόνων σε έναν κατάλογο δημοσίευσης και, στη συνέχεια, δημοσιεύστε αυτόν τον κατάλογο χωρίς να αλλάξετε τη σχετική δομή του.

Το παρακάτω παράδειγμα προετοιμάζει το `cdn-origin/presentations/quarterly-report` ως συνδεδεμένο ή συγχρονισμένο κατάλογο δημοσίευσης. Το ίδιο το δείγμα δεν εκτελεί καμία δικτυακή μεταφόρτωση: οι παραγόμενοι σύνδεσμοι γίνονται έγκυροι μετά τη δημοσίευση του καταλόγου στην επιθυμητή τοποθεσία ή CDN.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Δημοσιεύστε το `presentation.md` μαζί με το φάκελο `assets`. Το έγγραφο Markdown χρησιμοποιεί σχετικές αναφορές εικόνων, έτσι και τα δύο αντικείμενα πρέπει να διατηρούν την ίδια σχέση στο προορισμό. Εάν ένα σύστημα δημοσίευσης απαιτεί απόλυτα εξωτερικά URLs, ξαναγράψτε τους παραγόμενους συνδέσμους ως ξεχωριστό βήμα μετα-επεξεργασίας μετά τη δημοσίευση όλων των αρχείων εικόνας.

## **ΣΥΧΝΑ ΕΡΩΤΗΣΗ (FAQ)**

**Μπορούν οι κλήσεις επιστροφής Python να προσαρμόζουν μεμονωμένα αρχεία εικόνας και συνδέσμους κατά την εξαγωγή σε Markdown;**

Όχι. Το Aspose.Slides για Python μέσω .NET δεν εκθέτει τις κλήσεις επιστροφής .NET `ImageSaving` και `SvgImageSaving`. Διαμορφώστε την τοπική έξοδο με [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/base_path/) και [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), στη συνέχεια δημοσιεύστε ή επεξεργαστείτε μετα-επεξεργασία τις παραγόμενες πηγές.

**Πού αποθηκεύονται οι εξαγόμενες εικόνες;**

Η τοποθεσία της εικόνας ελέγχεται από [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/base_path/) και [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Το έγγραφο Markdown αναφέρει αυτές τις εικόνες με σχετικές διαδρομές.

**Ποιος διαχωριστής διαδρομής πρέπει να χρησιμοποιείται σε συνδέσμους εικόνας;**

Χρησιμοποιήστε κάθετους παύλες (forward slashes) σε συνδέσμους και URLs του Markdown. Χρησιμοποιήστε `os.path.join` μόνο για διαδρομές συστήματος αρχείων και ομαλοποιήστε όποιον σύνδεσμο δημιουργηθεί κατά τη μετα-επεξεργασία ξεχωριστά.

**Διατηρούνται οι υπερσύνδεσμοι κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/python-net/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι διαφάνειες [transitions](/slides/el/python-net/slide-transition/) και [animations](/slides/el/python-net/powerpoint-animation/) δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζεστε την ίδια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/python-net/multithreading/) και χρησιμοποιήστε ξεχωριστό αντικείμενο για κάθε αρχείο.