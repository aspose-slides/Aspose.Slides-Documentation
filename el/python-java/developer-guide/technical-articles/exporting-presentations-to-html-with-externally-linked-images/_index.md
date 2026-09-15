---
title: Εξαγωγή Παρουσιάσεων σε HTML με Εξωτερικά Συνδεδεμένες Εικόνες
type: docs
weight: 100
url: /el/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- Εξαγωγή PowerPoint
- Εξαγωγή OpenDocument
- Εξαγωγή παρουσίασης
- Εξαγωγή διαφάνειας
- Εξαγωγή PPT
- Εξαγωγή PPTX
- Εξαγωγή ODP
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
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML με Python χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται άμεσα στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για έναν ιστότοπο, ένα CMS ή μια διακομιστική αλυσίδα μετατροπής.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:
- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε στην cache εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε έναν φυλλομετρητή ή CDN·
- ελέγξετε, αντικαταστήσετε, συμπιέσετε ή επεξεργαστείτε μετά την εξαγωγή τους παραγόμενους πόρους·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτό που αναμένει μια διαδικτυακή εφαρμογή.

Για τη γενική ροή εργασίας μετατροπής HTML, δείτε [Convert PowerPoint Presentations to HTML](/slides/el/python-java/convert-powerpoint-to-html/). Αυτό το άρθρο επικεντρώνεται στο τμήμα σύνδεσης πόρων της εξαγωγής.

## **Πώς Λειτουργεί η Εξαγωγή Συνδεδεμένων Πόρων**

`ILinkEmbedController` επιτρέπει στην εφαρμογή σας να αποφασίσει, πόρος κατά πόρο, εάν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει έναν σύνδεσμο.

Η διεπαφή έχει τρεις μεθόδους:
- `ILinkEmbedController.getObjectStoringLocation` αποφασίζει εάν ένας πόρος πρέπει να συνδεθεί ή να ενσωματωθεί.
- `ILinkEmbedController.getUrl` επιστρέφει το URL που θα γραφτεί στο παραγόμενο HTML ή σε άλλο συνδεδεμένο πόρο.
- `ILinkEmbedController.saveExternal` γράφει τα δεδομένα του συνδεδεμένου πόρου στο δίσκο ή σε άλλο στόχο αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και το URL του φυλλομετρητή είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω δείγμα γράφει αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές URL όπως `assets/resource-1.svg`. Ένας φυλλομετρητής επιλύει αυτές τις URL σε σχέση με το αρχείο που περιέχει το σύνδεσμο. Συνεπώς, ένας σύνδεσμος από `presentation.html` σε ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από αυτό το αρχείο SVG σε μια εικόνα αποθηκευμένη στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με Συνδεδεμένους Πόρους**

Το παρακάτω παράδειγμα Python δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί και αποθηκεύει τους συνδεδεμένους πόρους σε ένα υποφάκελο `assets`. Ο ελεγκτής συνδέει κοινόχρηστους πόρους εικόνας, γραμματοσειρών, ήχου, βίντεο και CSS όταν το Aspose.Slides παρέχει ή μπορεί να συμπεράνει μια ασφαλή επέκταση αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Μετά την εξαγωγή, ο φάκελος εξόδου έχει αυτή τη δομή:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, τα ραστερά εικόνων συνήθως εξάγονται ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγαία παρουσίαση όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για Ανάπτυξη**

Το παράδειγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Εάν το `presentation.html` ανοίξει από το `html-output/presentation.html`, ο φυλλομετρητής φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος αναφέρεται σε άλλον συνδεδεμένο πόρο, το παράδειγμα χρησιμοποιεί την παράμετρο `referrer` στο `ILinkEmbedController.getUrl` και επιστρέφει μόνο το όνομα αρχείου. Για παράδειγμα, εάν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στο φάκελο `assets`, το αρχείο SVG πρέπει να αναφέρεται στο `resource-4.jpg`, όχι στο `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτυχθούν αλλού:
- Χρησιμοποιήστε `assets/` όταν ο φάκελος πόρων βρίσκεται δίπλα στο αρχείο HTML.
- Χρησιμοποιήτε `../assets/` όταν ο φάκελος πόρων είναι ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβαίνουν σε CDN ή σε διακομιστή στατικών αρχείων.

Το URL που επιστρέφεται από το `ILinkEmbedController.getUrl` πρέπει να ταιριάζει με την τελική τοποθεσία που αναπτύχθηκε το αρχείο που γράφτηκε από το `ILinkEmbedController.saveExternal`. Σε εφαρμογές διακομιστή, χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένων για κάθε εργασία μετατροπής ώστε να αποφύγετε την αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε Να Ενσωματώσετε Αντί Αυτό**

Το ενσωματωμένο Base64 HTML παραμένει χρήσιμο όταν η έξοδος πρέπει να είναι ένα ενιαίο αρχείο, όπως συνημμένο email, προεπισκόπηση εκτός σύνδεσης ή έγγραφο που θα μετακινηθεί χωρίς φάκελο πόρων. Οι συνδεδεμένοι πόροι είναι καλύτερη επιλογή όταν το HTML θα σερβιστεί από μια διαδικτυακή εφαρμογή, αποθηκευθεί σε CMS, βελτιστοποιηθεί από μια αλυσίδα κατασκευής ή αποθηκευτεί στην cache των φυλλομετρητών ανεξάρτητα από το HTML.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξωτερικοποιήσω μόνο τις εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στο `ILinkEmbedController.getObjectStoringLocation`, επιστρέψτε [LinkEmbedDecision.Link](https://reference.aspose.com/slides/el/python-java/aspose.slides/linkembeddecision/#Link) μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία και επιστρέψτε [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/el/python-java/aspose.slides/linkembeddecision/#Embed) για όλα τα υπόλοιπα.

**Γιατί η εξαγόμενη επέκταση εικόνας διαφέρει από την πηγή της παρουσίασης;**

Το Aspose.Slides μπορεί να κωδικοποιήσει ξανά τα ραστερά εικόνες κατά την εξαγωγή HTML για να βελτιώσει το μέγεθος ή τη συμβατότητα με τον φυλλομετρητή. Για παράδειγμα, μια εικόνα από το αρχείο προέλευσης μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα απόδοσης.

**Λειτουργούν οι σχετικές URL μετά τη μετακίνηση του αρχείου HTML;**

Οι σχετικές URL λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Εάν το HTML αναφέρει `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και εμποδίζει μια εξαγωγή από το να αντικαθιστά πόρους που δημιουργήθηκαν από άλλη εξαγωγή.