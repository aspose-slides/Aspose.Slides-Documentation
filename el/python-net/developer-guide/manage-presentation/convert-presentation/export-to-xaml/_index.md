---
title: Export Presentations to XAML with Python
linktitle: Presentation to XAML
type: docs
weight: 30
url: /el/python-net/export-to-xaml/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- PowerPoint σε XAML
- OpenDocument σε XAML
- παρουσίαση σε XAML
- PPT σε XAML
- PPTX σε XAML
- ODP σε XAML
- αποθήκευση PPT ως XAML
- αποθήκευση PPTX ως XAML
- αποθήκευση ODP ως XAML
- εξαγωγή PPT σε XAML
- εξαγωγή PPTX σε XAML
- εξαγωγή ODP σε XAML
- Python
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML με Python χρησιμοποιώντας το Aspose.Slides—γρήγορη, λύση χωρίς Office που διατηρεί το στήσιμο σας ανέπαφο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές κοινές ερωτήσεις σχετικά με τις εναλλακτικές γραμματοσειρές, τη συμβατότητα στοίβας XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης που βασίζεται σε XML και χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε έναν οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα Python δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Από προεπιλογή, οι εξαγώμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `pres` του τρέχοντος καταλόγου εργασίας της διεργασίας, όπως επιστρέφει η [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Ο φάκελος δημιουργείται αυτόματα και οι απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του πηγαίου αρχείου χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.λπ. Ακόμη και αν περάσετε έναν απόλυτο δρόμο προς την είσοδο της παρουσίασης, ο φάκελος εξόδου δημιουργείται σχετικό με τον τρέχοντα κατάλογο εργασίας, όχι δίπλα στο αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Ρυθμίσεις**

Χρησιμοποιήστε την κλάση [XamlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, ορίστε την ιδιότητα [export_hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) σε `True`, όπως φαίνεται στο παρακάτω παράδειγμα Python:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Καταγραφή Όλων των Δημιουργημένων XAML Αντικειμένων**

Μια εξαγωγή XAML μπορεί να παράγει ένα έγγραφο XAML για κάθε εξαγώμενη διαφάνεια, καθώς και ξεχωριστές εικόνες και βοηθητικούς πόρους. Διατηρήστε όλα αυτά τα αρχεία όταν αποθηκεύετε ή μεταβιβάζετε μια εξαγωγή.

Τα παραδείγματα παρακάτω χρησιμοποιούν τον προεπιλεγμένο αποθηκευτικό σύστημα αρχείων σε έναν προσωρινό φάκελο, έπειτα συλλέγουν τα δημιουργημένα αρχεία.

### **Κατανόηση του Κύκλου Ζωής της Εξαγωγής**

- Ξεκινήστε την εξαγωγή με την XAML‑συγκεκριμένη [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) υπερφόρτωση που δέχεται επιλογές XAML. Διαβάστε τα δημιουργημένα αρχεία μόνο αφού η κλήση επιστρέψει επιτυχώς.
- Διατηρήστε τη σχετική διαδρομή κάθε αντικειμένου επειδή το XAML μπορεί να αναφέρει πόρους με σχετικές διαδρομές.
- Διαβάστε τα αντικείμενα ως bytes. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιούνται ως κείμενο.
- Αναφέρετε τη συνολική επιτυχία μόνο αφού ολοκληρωθεί η συλλογή και οποιαδήποτε επακόλουθη αποθήκευση. Αφήστε τα σφάλματα αποθήκευσης να φτάσουν στον καλούντα και καθαρίστε την μερική έξοδο αν η διατήρηση αποτύχει.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) είναι προεπιλογή `False`, το οποίο αποκλείει τα XAML έγγραφα των κρυφών διαφανειών. Ορίζοντάς το σε `True` τα περιλαμβάνει μαζί με τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Οι μετρήσεις πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε ένα αρχείο ανά διαφάνεια.

{{% alert color="warning" title="Warning" %}}
Τα παραδείγματα αλλάζουν προσωρινά τον τρέχοντα κατάλογο εργασίας της διεργασίας, γεγονός που επηρεάζει όλα τα νήματα. Εκτελέστε κάθε εξαγωγή σε μια αφιερωμένη διεργασία εργαζομένων ή βεβαιωθείτε ότι καμία άλλη εργασία στη διεργασία δεν εξαρτάται από τον τρέχοντα κατάλογο κατά την εξαγωγή. Ένας μοναδικός προσωρινός φάκελος από μόνος του δεν καθιστά ασφαλείς τις ταυτόχρονες εξαγωγές στην ίδια διεργασία.
{{% /alert %}}

### **Εξαγωγή στη Μνήμη και Επιθεώρηση των Αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, το εξάγει σε έναν προσωρινό φάκελο, συλλέγει κάθε αντικείμενο σε ένα λεξικό σχετικών ονομάτων και bytes, και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε bytes. Διατηρεί τη δομή του φακέλου που δημιουργήθηκε και αφαιρεί τα προσωρινά αρχεία μετά τη συλλογή. Η διαδρομή εισόδου επιλύεται πριν αλλάξει ο τρέχων κατάλογος εργασίας.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Αποκωδικοποιήστε μόνο το XAML και μόνο όταν απαιτείται κειμενική επιθεώρηση.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων των άγνωστων τύπων πόρων. Αφήστε τα bytes χωρίς αλλαγές κατά την αποθήκευση ή τη μεταφορά. Αποκωδικοποιήστε μόνο το XAML που απαιτεί επεξεργασία κειμένου. Αυτή η προσέγγιση χρησιμοποιεί προσωρινό χώρο δίσκου καθώς και μνήμη για την συγκεντρωμένη εξαγωγή.

### **Συσκευασία Συγκεντρωμένων Αντικειμένων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά bytes σε ένα αρχείο ZIP. Ένα μοναδικό όνομα αρχείου χωρίζει τις εργασίες εξαγωγής. Οι καταχωρήσεις ZIP χρησιμοποιούν μπροστιγές παύλες και διατηρούν τις σχετικές διαδρομές. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτονται ολόκληρο το πακέτο πριν γραφτούν.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Ο κατάλογος ZIP ολοκληρώθηκε πριν την αναφορά επιτυχίας.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Το παράδειγμα χρησιμοποιεί το [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) για να γράψει ένα τοπικό αρχείο μετά τη συλλογή της προσωρινής εξαγωγής. Για αποθήκευση απομακρυσμένα, αντικαταστήστε το στάδιο εγγραφής αρχείου με ανεβάσματα των συλλεγμένων bytes. Χρησιμοποιήστε έναν ταυτοποιητή εργασίας εξαγωγής μαζί με το πλήρες σχετικό όνομα του αντικειμένου ως κλειδί αντικειμένου, ή αποθηκεύστε τον ταυτοποιητή εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε μια γραμμή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλες οι ανεβάσεις ή η συναλλαγή της βάσης δεδομένων ολοκληρωθεί. Καθαρίστε την εν μέρει έξοδο αν η διατήρηση αποτύχει.

Για μεγάλες παρουσιάσεις, επεξεργαστείτε τα προσωρινά αρχεία ένα προς ένα μετά την εξαγωγή αντί να συλλέξετε όλα τα bytes τους σε λεξικό. Αυτό αποφεύγει ένα επιπλέον αντίγραφο σε μνήμη ολόκληρης της εξαγωγής, αλλά δεν εξαλείφει τις απαιτήσεις μνήμης του εξαγωγέα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομών όταν ο προορισμός το απαιτεί, αλλά διατηρήστε τις σχετικές διαδρομές. Μην κρατάτε μόνο το τελικό όνομα αρχείου εκτός αν γνωρίζετε ότι κάθε δημιουργημένο όνομα είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων ειδική για τον προορισμό. Όταν γράφετε ανεξάρτητα αρχεία, απορρίψτε απόλυτες διαδρομές και τμήματα διαπέρασης, επιλύστε τον προορισμό και βεβαιωθείτε ότι παραμένει κάτω από τον προορισμένο φάκελο εξαγωγής. Χρησιμοποιήστε φάκελο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να ανακατευθύνουν τις εγγραφές.
- Χρησιμοποιήστε χωριστό χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας σε πεζά/κεφαλαία του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και επιθεωρήστε τις αναφορές πόρων με βάση αρχεία, όπως τα χαρακτηριστικά `Source` ή `ImageSource` των εικόνων. Επιλύστε κάθε σχετικό URI έναντι του φακέλου του περιέχοντος αντικειμένου XAML, κανονικοποιήστε το προκύπτον όνομα αποθήκευσης και επιβεβαιώστε ότι το αντίστοιχο κλειδί λεξικού, η καταχώρηση ZIP ή το αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε εξωτερικά URI και εκφράσεις σήμανσης XAML ξεχωριστά από τα ονόματα αρχείων.

Για παράδειγμα, αν το `pres/Slide_1.xaml` αναφέρει το `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα διακόπτει αυτή τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε αυτά τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ξαναανοίξτε το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα καταχωρήσεων και τα bytes των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο περιβάλλον XAML-στόχο ώστε να επιβεβαιώσετε ότι οι εικόνες επιλύονται σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές αν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Ορίστε το [default_regular_font](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) στο [XamlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/) — χρησιμοποιείται ως εναλλακτική γραμματοσειρά κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει τη εναλλακτική γραμματοσειρά ή ότι η γραμματοσειρά θα είναι διαθέσιμη στο τελικό μηχάνημα. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται από το XAML είναι διαθέσιμες στο περιβάλλον όπου θα εμφανιστεί.

**Απευθύνεται το εξαγόμενο XAML μόνο σε WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Ελέγξτε το παραγόμενο σήμα στο περιβάλλον-στόχο σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [export_hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) στο [XamlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export.xaml/xamloptions/) — κρατήστε το απενεργοποιημένο αν δεν χρειάζεται να τις εξάγετε.