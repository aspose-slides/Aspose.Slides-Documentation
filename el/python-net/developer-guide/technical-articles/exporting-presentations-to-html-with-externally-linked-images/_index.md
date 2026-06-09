---
title: Εξαγωγή παρουσιάσεων σε HTML με εξωτερικές συνδεδεμένες εικόνες στην Python
linktitle: Εξαγωγή παρουσιάσεων σε HTML με εξωτερικές συνδεδεμένες εικόνες
type: docs
weight: 100
url: /el/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- εξαγωγή διαφάνειας
- εξαγωγή PPT
- εξαγωγή PPTX
- εξαγωγή ODP
- PowerPoint σε HTML
- OpenDocument σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- ODP σε HTML
- συνδεδεμένη εικόνα
- εξωτερικά συνδεδεμένη εικόνα
- συνδεδεμένος πόρος
- εξωτερικός πόρος
- Python
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML στην Python χρησιμοποιώντας Aspose.Slides, με τις εικόνες αποθηκευμένες ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για έναν ιστότοπο, ένα CMS ή μια διαδρομή μετατροπής στο διακομιστή.

Χρησιμοποιήστε εξωτερικά συνδεδεμένες εικόνες όταν θέλετε να:

- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε τις εικόνες ξεχωριστά σε cache σε πρόγραμμα περιήγησης ή CDN·
- ελέγξετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε περαιτέρω τις παραγόμενες εικόνες μετά την εξαγωγή·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτό που αναμένει μια web εφαρμογή·

Για τη γενική ροή εργασίας μετατροπής HTML, δείτε [Convert PowerPoint Presentations to HTML](/slides/el/python-net/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο τμήμα σύνδεσης των εικόνων κατά την εξαγωγή.

## **Πώς Λειτουργεί η Εξαγωγή Συνδεδεμένων Εικόνων**

Στα .NET και Java, το [ILinkEmbedController](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/ilinkembedcontroller/) αντιπροσωπεύει τη διεπαφή callback που χρησιμοποιεί ο εξαγωγέας για να αποφασίσει αν ένας πόρος θα ενσωματωθεί ή θα συνδεθεί. Στην Python μέσω .NET, οι κλάσεις Python δεν μπορούν επί του παρόντος να υλοποιήσουν άμεσα αυτή τη .NET διεπαφή callback, οπότε η πρακτική ροή εργασίας είναι:

1. Εξαγωγή της παρουσίασης σε HTML με το [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/).
2. Χρήση του [SlideImageFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/slideimageformat/) μαζί με το [SVGOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/), ώστε οι διαφάνειες να αντιπροσωπεύονται ως SVG στο HTML.
3. Μετακίνηση των δεδομένων εικόνας Base64 από τα URLs `data:` του HTML σε ξεχωριστά αρχεία.
4. Αντικατάσταση των αρχικών URLs `data:` με σχετικούς συνδέσμους όπως `assets/resource-1.jpg`.

Η διαδρομή του συστήματος αρχείων και το URL του προγράμματος περιήγησης είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω παράδειγμα γράφει τα αρχεία εικόνας στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικά URLs όπως `assets/resource-1.jpg`. Ένας περιηγητής επιλύει αυτά τα URLs σε σχέση με το αρχείο HTML που περιέχει τον σύνδεσμο.

## **Εξαγωγή HTML με Συνδεδεμένες Εικόνες**

Το παρακάτω παράδειγμα Python δημιουργεί έναν κατάλογο εξόδου, αποθηκεύει το αρχείο HTML εκεί, αποθηκεύει τις εξαγόμενες εικόνες σε υποκατάλογο `assets`, και ξαναγράφει τα URLs των εικόνων Base64 σε σχετικούς συνδέσμους. Το παράδειγμα εξάγει συνήθεις μορφές εικόνας Base64 όταν το Aspose.Slides παρέχει μια ασφαλή επέκταση αρχείου. Τα Data URLs που δεν αναγνωρίζονται παραμένουν ενσωματωμένα.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Μετά την εξαγωγή, ο φάκελος εξόδου μπορεί να έχει την ακόλουθη δομή:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ράστερ εικόνες συνήθως εξάγονται ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην αρχική παρουσίαση όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το παράδειγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Εάν το `presentation.html` ανοιχτεί από το `html-output/presentation.html`, ο περιηγητής φορτώνει το `html-output/assets/resource-1.jpg`.

- Χρησιμοποιήστε `assets/` όταν ο φάκελος assets βρίσκεται δίπλα στο αρχείο HTML.
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος assets βρίσκεται ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία έχουν ανεβεί σε CDN ή σε στατικό διακομιστή αρχείων.

Σε εφαρμογές διακομιστή, χρησιμοποιήστε έναν μοναδικό κατάλογο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφεύγεται η αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε να Ενσωματώνετε Αντ’Αυτού**

Το ενσωματωμένο Base64 HTML είναι ακόμη χρήσιμο όταν η έξοδος πρέπει να είναι ένα μόνο αρχείο, όπως ένα συνημμένο email, μια offline προεπισκόπηση ή ένα έγγραφο που θα μεταφερθεί χωρίς φάκελο assets. Οι συνδεδεμένες εικόνες είναι πιο κατάλληλες όταν το HTML θα σερβιριστεί από μια web εφαρμογή, θα αποθηκευτεί σε CMS, θα βελτιστοποιηθεί από μια διαδικασία build, ή θα αποθηκευτούν στην cache από προγράμματα περιήγησης ανεξάρτητα από το HTML.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξωτερικεύσω μόνο τις εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Το παράδειγμα εξάγει μόνο τα Base64 data URLs `image/*` των οποίων οι τύποι περιεχομένου αναφέρονται στο `EXTENSIONS_BY_CONTENT_TYPE`. Τα άλλα data URLs παραμένουν ενσωματωμένα.

**Γιατί η επέκταση της εξαγόμενης εικόνας διαφέρει από την πηγή της παρουσίασης;**

Το Aspose.Slides μπορεί να ξανακωδικοποιήσει τις ράστερ εικόνες κατά την εξαγωγή HTML για να βελτιώσει το μέγεθος ή τη συμβατότητα με τον περιηγητή. Για παράδειγμα, μια εικόνα από το αρχικό αρχείο μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα απόδοσης.

**Λειτουργούν τα σχετικά URLs μετά τη μετακίνηση του αρχείου HTML;**

Τα σχετικά URLs λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Αν το HTML αναφέρει `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε έναν μοναδικό κατάλογο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και εμποδίζει μια εξαγωγή από το να αντικαταστήσει πόρους που δημιουργήθηκαν από άλλη εξαγωγή.