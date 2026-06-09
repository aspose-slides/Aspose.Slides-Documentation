---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Markdown με Python
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/python-net/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint σε Markdown
- μετατροπή OpenDocument σε Markdown
- μετατροπή παρουσίασης σε Markdown
- μετατροπή διαφάνειας σε Markdown
- μετατροπή PPT σε Markdown
- μετατροπή PPTX σε Markdown
- μετατροπή ODP σε Markdown
- μετατροπή PowerPoint σε MD
- μετατροπή OpenDocument σε MD
- μετατροπή παρουσίασης σε MD
- μετατροπή διαφάνειας σε MD
- μετατροπή PPT σε MD
- μετατροπή PPTX σε MD
- μετατροπή ODP σε MD
- PowerPoint
- OpenDocument
- παρουσίαση
- Markdown
- Python
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument—PPT, PPTX, ODP—σε καθαρό Markdown με Aspose.Slides για Python μέσω .NET, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για ροές εργασίας τεκμηρίωσης, δημιουργία στατικών ιστοτόπων, μετανάστευση περιεχομένου και έκδοση κειμένου με έλεγχο εκδόσεων. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει πρόσθετες επιλογές για να ελέγχετε πώς το περιεχόμενο των διαφανειών αναπαρίσταται στο προκύπτον έγγραφο Markdown.

Μπορείτε να εξάγετε παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλαπλές παραλλαγές Markdown όπως CommonMark και GitHub Flavored Markdown, και να διαμορφώσετε τον τρόπο διαχείρισης των εικόνων κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides σας επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις αναφέρετε από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}}
Η εξαγωγή PowerPoint σε Markdown είναι **χωρίς εικόνες** εξ ορισμού. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να ορίσετε `export_type = MarkdownExportType.VISUAL` και να καθορίσετε το `base_path`, όπου θα αποθηκευτούν οι εικόνες που αναφέρονται στο έγγραφο Markdown.
{{% /alert %}}

## **Μετατροπή Παρουσιάσεων σε Markdown**

Το παρακάτω παράδειγμα δείχνει τον πιο απλό τρόπο μετατροπής μιας παρουσίασης PowerPoint σε Markdown χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET με τις προεπιλεγμένες ρυθμίσεις.

1. Δημιουργήστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση.
1. Καλείτε τη μέθοδο `save` για να το εξάγετε ως αρχείο Markdown.

Χρησιμοποιήστε το παρακάτω απόσπασμα Python για να εκτελέσετε τη μετατροπή:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Μετατροπή Παρουσιάσεων σε Παραλλαγή Markdown**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις σε μορφές Markdown, συμπεριλαμβανομένων του βασικού Markdown, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab και 17 άλλων παραλλαγών Markdown.

Το παρακάτω παράδειγμα Python δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

Οι 23 υποστηριζόμενες παραλλαγές Markdown αναφέρονται στην απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) της κλάσης [MarkdownSaveOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Μετατροπή Παρουσιάσεων που Περιέχουν Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να διαμορφώσετε το προκύπτον αρχείο Markdown. Για παράδειγμα, η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) ελέγχει πώς θα διαχειριστούν οι εικόνες: `SEQUENTIAL`, `TEXT_ONLY` ή `VISUAL`.

### **Μετατροπή Εικόνων Διαδοχικά**

Εάν θέλετε οι εικόνες να εμφανίζονται μεμονωμένα — μία μετά την άλλη — στο παραγόμενο Markdown, επιλέξτε την επιλογή `SEQUENTIAL`. Το παρακάτω παράδειγμα Python δείχνει πώς να μετατρέψετε μια παρουσίαση με εικόνες σε Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Μετατροπή Ε εικόνων Οπτικά**

Εάν θέλετε οι εικόνες να εμφανίζονται μαζί στο τελικό Markdown, επιλέξτε την επιλογή `VISUAL`. Σε αυτή τη λειτουργία, οι εικόνες αποθηκεύονται στον τρέχοντα φάκελο της εφαρμογής (και το έγγραφο Markdown χρησιμοποιεί σχετικές διαδρομές), ή μπορείτε να καθορίσετε προσαρμοσμένη διαδρομή εξόδου και όνομα φακέλου.

Το παρακάτω παράδειγμα Python επιδεικνύει αυτή τη λειτουργία:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/python-net/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/python-net/slide-transition/) και [animations](/slides/el/python-net/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παραλληλοποιήσετε ανά αρχείο, αλλά [μην μοιράζεστε](/slides/el/python-net/multithreading/) το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστά αντικείμενα/διεργασίες ανά αρχείο για να αποφύγετε συγκρούσεις.

**Τι γίνεται με τις εικόνες — πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [Images](/slides/el/python-net/image/) εξάγονται σε αφιερωμένο φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές εξ ορισμού. Μπορείτε να διαμορφώσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου πόρων για να διατηρήσετε μια προβλέψιμη δομή αποθετηρίου.