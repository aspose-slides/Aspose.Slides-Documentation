---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown με Python μέσω Java
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/python-java/convert-powerpoint-to-markdown/
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
- Εξαγωγή εικόνων Markdown
- Σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown με Python μέσω Java και ελέγξτε πού αποθηκεύονται και αναφέρονται οι εξαγώμενες bitmap, metafile και SVG εικόνες."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικές τοποθεσίες, μεταφορά περιεχομένου και διαδικασίες ελέγχου εκδόσεων. Μπορείτε να επιλέξετε μια γεύση Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να αποφασίσετε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενες αναφορές Markdown τις αναφέρονται.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί μόνο κείμενο. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τον τύπο εξαγωγής με τη μέθοδο [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setExportType) στο `Sequential` ή `Visual` τιμή από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με τη σειρά, ενώ το `Visual` διατηρεί τα ομαδοποιημένα στοιχεία μαζί για να διατηρήσει τη οπτική σχέση τους. Η τιμή `TextOnly` δεν εκδίδει πόρους εικόνων, επομένως οι callbacks αποθήκευσης εικόνας δεν καλούνται σε αυτή τη λειτουργία.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το πηγαίο αρχείο με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και, στη συνέχεια, καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Κάθε παράδειγμα διαβάζει το `presentation.pptx` από τον τρέχοντα φάκελο εργασίας. Εγκαταστήστε το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον εκτέλεσης Java πριν τρέξετε τα παραδείγματα. Ξεκινήστε το JVM μία φορά ανά διεργασία Python.

## **Επιλογή Γεύσης Markdown**

Η μέθοδος [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setFlavor) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για την παραγωγή. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/python-java/aspose.slides/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Εξαγωγή Εικόνων Χρησιμοποιώντας τη Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/) παρέχει δύο μεθόδους για τη διαμόρφωση τοπικά αποθηκευμένων εικόνων:

- [setBasePath](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setBasePath) καθορίζει τον βασικό κατάλογο για το έγγραφο Markdown και τους πόρους του.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) καθορίζει τον υποκατάλογο εικόνων. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνων στο έγγραφο Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Αυτή η συμπεριφορά λειτουργεί επίσης ως εναλλακτική όταν ένας προσαρμοσμένος διαχειριστής αποθήκευσης εικόνας επιστρέφει `False`.

## **Προσαρμογή Αποθήκευσης Εικόνας και Συνδέσμων Markdown**

Χρησιμοποιήστε τη μέθοδο [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/) για να καταχωρίσετε μια callback για μη‑SVG bitmap και μεταφαίρεση πόρων που εκδίδονται κατά την εξαγωγή σε Markdown. Η callback `MarkdownImageSavingHandler` λαμβάνει το αντικείμενο εικόνας, την τιμή του [ImageFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/) και τον παραγόμενο σύνδεσμο Markdown ως παράμετρο `String[]` με ένα στοιχείο. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοθείσα μορφή και αντικαταστήστε το `link[0]` με τη διεύθυνση που πρέπει να εμφανιστεί στην έξοδο Markdown.

Οι πόροι που εκδίδονται σε μορφή SVG επεξεργάζονται ξεχωριστά. Καταχωρίστε μια callback με τη μέθοδο [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/). Η callback `MarkdownSvgImageSavingHandler` λαμβάνει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) και την παράμετρο `String[] link` με ένα στοιχείο. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα δεδομένα XML του από τη μέθοδο [SvgImage.getSvgData](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/#getSvgData). Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγαία παρουσίαση μπορεί να μετατραπεί σε raster ή να συνδυαστεί με άλλο περιεχόμενο· ο παραγόμενος μη‑SVG πόρος τότε περνιέται στην callback αποθήκευσης εικόνας. Καταχωρίστε και τις δύο callbacks όταν κάθε εξαγόμενο οπτικό πόρο απαιτεί προσαρμοσμένη επεξεργασία.

Η τιμή επιστροφής της callback καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `True` αφού η callback έχει αποθηκεύσει, ανεβάσει, μετασχηματίσει ή με άλλο τρόπο επεξεργαστεί την εικόνα και έχει ορίσει μια έγκυρη τιμή στο `link[0]`. Το Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `False` ώστε το Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει τον σύνδεσμο σύμφωνα με τις τιμές που ορίστηκαν με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setBasePath) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Σημαντικό" %}}
Μια callback που επιστρέφει `True` παίρνει την ευθύνη για την εικόνα. Εάν επιστρέψει `True` χωρίς να αντιστοιχίσει μια έγκυρη, μη κενή διεύθυνση, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.
{{% /alert %}}

Σε Python, καταχωρίστε αυτές τις callbacks με το `jpype.JProxy`, υλοποιώντας τη διεπαφή Java callback μέσω της μεθόδου `invoke`. Το όρισμα `link` είναι ένας μεταβλητός πίνακας συμβολοσειρών Java: μετατρέψτε το `link[0]` σε συμβολοσειρά Python πριν το επεξεργαστείτε, έπειτα εκχωρήστε τη νέα URL πίσω στο `link[0]`.

### **Αποθήκευση Εικόνων σε Κατάλογο Προέλευσης CDN και Χρήση Εξωτερικών URL**

Το παρακάτω παράδειγμα θεωρεί το `cdn-origin/presentations/quarterly-report` ως προσαρτημένο ή συγχρονισμένο κατάλογο προέλευσης CDN. Κάθε handler εξάγει το όνομα αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο κατάλογο και αντικαθιστά την παραγόμενη τοπική αναφορά με μια δημόσια URL CDN. Το παράδειγμα δεν εκτελεί καμία μεταφόρτωση δικτύου: η URL γίνεται έγκυρη μόνο αφού ο κατάλογος προσαρτηθεί ως προέλευση CDN ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε το γράψιμο στο σύστημα αρχείων με τη λειτουργία ανεβάσματος του SDK αποθήκευσης και εκχωρήστε το `link[0]` μόνο μετά την επιτυχή μεταφόρτωση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Ο bitmap handler επιστρέφει σκόπιμα `False` για εικόνες μικρότερες από 128 × 128 εικονοστοιχεία, έτσι το Aspose.Slides αποθηκεύει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας τη προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι bitmap και πόροι metafile, καθώς και πόροι SVG, επεξεργάζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια παραγόμενη τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι handlers χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο κατά τη γραφή αρχείων· οι σύνδεσμοι που γράφονται σε Markdown χρησιμοποιούν κάθετους (forward) παύλες και ονόματα αρχείων κωδικοποιημένα σε URL. Εφαρμόστε τον ίδιο κανόνα όταν δημιουργείτε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου ειδικό για την πλατφόρμα.

## **Συχνές Ερωτήσεις**

**Μπορεί ένας handler να επεξεργαστεί τόσο raster εικόνες όσο και SVG εικόνες;**

Όχι. Χρησιμοποιήστε το [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/) για bitmap και metafile πόρους και το [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/) για πόρους που εκδίδονται ως SVG. Το πρώτο παρέχει αντικείμενο εικόνας και τιμή [ImageFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/), το δεύτερο αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) του οποίου τα δεδομένα SVG μπορούν να διαβαστούν με το [SvgImage.getSvgData](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/#getSvgData). Ένα SVG που rasterizeται κατά την εξαγωγή επεξεργάζεται από το callback αποθήκευσης εικόνας.

**Τι συμβαίνει όταν ένα image‑saving handler επιστρέφει `False`;**

Το Aspose.Slides χρησιμοποιεί τη προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης. Η θέση της εικόνας και η παραγόμενη αναφορά ελέγχονται από τις τιμές που ορίστηκαν με [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setBasePath) και [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/el/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Μπορεί ένας handler να παρέχει URL χωρίς να αποθηκεύσει την εικόνα τοπικά;**

Ναι. Ο handler μπορεί να ανεβάσει την εικόνα σε αποθηκευτικό αντικείμενο ή να τη δώσει σε άλλη υπηρεσία, να εκχωρήσει το προκύπτο URL στο `link[0]` και να επιστρέψει `True`. Ο handler πρέπει να ολοκληρώνει την επεξεργασία μόνος του· η επιστροφή `True` εμποδίζει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown ρίχνει `InvalidOperationException` από έναν handler;**

Αυτή η εξαίρεση εμφανίζεται όταν ο handler επιστρέφει `True` χωρίς να παρέχει μια έγκυρη διεύθυνση. Εκχωρήστε τη σχετική διαδρομή ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `True`.

**Ποιο διαχωριστικό διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνων;**

Χρησιμοποιήστε forward slashes (`/`) σε συνδέσμους Markdown και URLs. Χρησιμοποιήστε `pathlib.Path` μόνο για διαδρομές συστήματος αρχείων, και στη συνέχεια δημιουργήστε ή κανονικοποιήστε την αναφορά Markdown ξεχωριστά.

**Διατηρούνται οι υπερσύνδεσμοι κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/python-java/manage-hyperlinks/) διατηρούνται ως κανονικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/python-java/slide-transition/) και οι [animations](/slides/el/python-java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργάζεστε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζεστε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/python-java/multithreading/) και χρησιμοποιήστε ξεχωριστό instance για κάθε αρχείο.