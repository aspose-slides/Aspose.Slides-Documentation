---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις με Python
linktitle: Ενσωμάτωση γραμματοσειράς
type: docs
weight: 40
url: /el/python-net/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET, εξασφαλίζοντας ακριβή απόδοση σε όλα τα πλατφόρμες."
---
## **Εισαγωγή**

**Ενσωμάτωση γραμματοσειρών στο PowerPoint** εξασφαλίζει ότι η παρουσίασή σας διατηρεί την προοριζόμενη εμφάνισή της σε διαφορετικά συστήματα. Είτε χρησιμοποιείτε μοναδικές γραμματοσειρές για δημιουργικότητα είτε τυπικές, η ενσωμάτωση των γραμματοσειρών αποτρέπει τη διαταραχή του κειμένου και της διάταξης.

Εάν χρησιμοποιήσατε μια γραμματοσειρά τρίτου μέρους ή μη τυπική επειδή ήσασταν δημιουργικοί με τη δουλειά σας, τότε έχετε ακόμη περισσότερους λόγους για να ενσωματώσετε τη γραμματοσειρά σας. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), το κείμενο ή οι αριθμοί στις διαφάνειές σας, η διάταξη, το στυλ κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγκεχυμένα ορθογώνια.

Χρησιμοποιήστε τις κλάσεις [FontsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontdata/), και [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) για τη διαχείριση των ενσωματωμένων γραμματοσειρών.

## **Ανάκτηση και Κατάργηση Ενσωματωμένων Γραμματοσειρών**

Ανακτήστε ή αφαιρέστε ενσωματωμένες γραμματοσειρές από μια παρουσίαση εύκολα με τις μεθόδους [get_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) και [remove_embedded_font](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Αυτός ο κώδικας Python δείχνει πώς να ανακτήσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές από μια παρουσίαση:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Αποδώστε τη διαφάνεια που περιέχει ένα πλαίσιο κειμένου και χρησιμοποιεί την ενσωματωμένη γραμματοσειρά 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Αποκτήστε όλες τις ενσωματωμένες γραμματοσειρές.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Βρείτε τη γραμματοσειρά 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Αφαιρέστε τη γραμματοσειρά 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Αποδώστε τη διαφάνεια· η γραμματοσειρά 'Calibri' θα αντικατασταθεί με μια υπάρχουσα.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Αποθηκεύστε την παρουσίαση χωρίς την ενσωματωμένη γραμματοσειρά 'Calibri' στο δίσκο.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιώντας το enum [EmbedFontCharacters](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/embedfontcharacters/) και τις δύο υπερφορτώσεις της μεθόδου [add_embedded_font](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/add_embedded_font/), μπορείτε να επιλέξετε τον προτιμώμενο (ενσωμάτωση) κανόνα για την ενσωμάτωση των γραμματοσειρών σε μια παρουσίαση. Αυτός ο κώδικας Python δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

```python
import aspose.slides as slides

# Φορτώστε μια παρουσίαση.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Βελτιστοποιήστε το μέγεθος του αρχείου συμπιέζοντας τις ενσωματωμένες γραμματοσειρές χρησιμοποιώντας το [compress_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Παράδειγμα κώδικα για τη συμπίεση:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να καταλάβω αν μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί ακόμη και κατά τη διάρκεια της απόδοσης παρόλο που έχει ενσωματωθεί;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/python-net/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικών/αντικατάστασης](/slides/el/python-net/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή είναι περιορισμένη, θα χρησιμοποιηθεί εναλλακτική.

**Αξίζει η ενσωμάτωση των "συστημικών" γραμματοσειρών όπως Arial/Calibri;**

Συνήθως όχι—είναι σχεδόν πάντα διαθέσιμες. Αλλά για πλήρη φορητότητα σε "thin" περιβάλλοντα (Docker, ένας διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση των συστημικών γραμματοσειρών μπορεί να εξαλείψει τον κίνδυνο ανεπιθύμητων αντικαταστάσεων.