---
title: Εξαγωγή Παρουσιάσεων σε XAML με Python μέσω Java
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/python-java/export-to-xaml/
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
  - Java
  - Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε XAML με Aspose.Slides για Python μέσω Java. Χρησιμοποιήστε τις προεπιλεγμένες επιλογές ή συμπεριλάβετε κρυφές διαφάνειες."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides for Python via Java. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και ερευνά πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές συνηθισμένες ερωτήσεις σχετικά με τις εναλλακτικές γραμματοσειρές, τη συμβατότητα στο στοίβα XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

Τα παραδείγματα απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον Java. Τοποθετήστε το `pres.pptx` στο τρέχον κατάλογο εργασίας. Κάθε παράδειγμα ξεκινά το JVM μόνο αν δεν εκτελείται ήδη.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σημειώσεων βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε έναν οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε τη σημείωση απευθείας.

## **Εξαγωγή παρουσιάσεων σε XAML με προεπιλεγμένες επιλογές**

Το παρακάτω παράδειγμα Python δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Από προεπιλογή, οι εξαγόμενες διαφάνειες αποθηκεύονται σε έναν υποκατάλογο `pres` του τρέχοντος καταλόγου εργασίας της διεργασίας. Ο φάκελος δημιουργείται αυτόματα και τυχόν απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχείου προέλευσης χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.ο.κ. Ακόμη και αν περάσετε μια απόλυτη διαδρομή στο αρχείο εισόδου, ο φάκελος εξόδου δημιουργείται σχετικώς με τον τρέχοντα κατάλογο εργασίας, όχι δίπλα στο αρχείο εισόδου.

## **Εξαγωγή παρουσιάσεων σε XAML με προσαρμοσμένες επιλογές**

Χρησιμοποιήστε την κλάση [XamlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένο σημείο, υλοποιήστε το `IXamlOutputSaver` και περάστε μια παρουσία της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/#setOutputSaver) της [XamlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) με `True`, όπως φαίνεται στο παρακάτω παράδειγμα Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Συλλογή όλων των παραγόμενων αντικειμένων XAML**

Μια εξαγωγή XAML μπορεί να δημιουργήσει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια συν ξεχωριστές εικόνες και βοηθητικούς πόρους. Αναθέστε ένα προσαρμοσμένο `IXamlOutputSaver` στη μέθοδο [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/#setOutputSaver) για να λαμβάνετε αυτά τα αντικείμενα αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με την υπερφόρτωση [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) που δέχεται επιλογές XAML.

Στην Python, χρησιμοποιήστε `jpype.JProxy` για να υλοποιήσετε τη διεπαφή Java `IXamlOutputSaver`. Μετατρέψτε τη διαδρομή κλήσης σε `str` και αντιγράψτε τον πίνακα byte Java σε `bytes` Python πριν επιστρέψετε, όπως φαίνεται παρακάτω.

### **Κατανόηση του κύκλου ζωής της κλήσης επιστροφής**

Ο εξαγωγέας καλεί το `IXamlOutputSaver.save` ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` αναγνωρίζει το αντικείμενο και μπορεί να περιλαμβάνει σχετικούς καταλόγους. Διατηρήστε αυτήν την πληροφορία επειδή το XAML ενδέχεται να αναφέρεται σε πόρους μέσω σχετικών διαδρομών.
- `data` περιέχει τα byte του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιούνται ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την αποθήκευση των δεδομένων πριν την επιστροφή. Τα παραδείγματα αντιγράφουν κάθε πίνακα byte στη μνήμη που κατέχει η εφαρμογή.
- Θεωρήστε την εξαγωγή επιτυχής μόνο όταν η ενέργεια αποθήκευσης της παρουσίασης επιστρέψει και κάθε κλήση επιστροφής ολοκληρωθεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή μην ξεκινάτε αόρατες εγγραφές στο παρασκήνιο. Εάν η διατήρηση συμβεί αργότερα, αναφέρετε τη συνολική επιτυχία μόνο μετά την ολοκλήρωση του βήματος αυτού.

Το [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) ισχύει επίσης για προσαρμοσμένο αποθηκευτή. Η προεπιλογή, `False`, εξαιρεί τα έγγραφα XAML κρυφών διαφανειών. Η μεταφορά `True` τα περιλαμβάνει μαζί με τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Οι μετρήσεις πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε μία κλήση ανά διαφάνεια ή σταθερή σειρά κλήσεων.

### **Εξαγωγή στη μνήμη και εξέταση των αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε αντικείμενο σε ένα λεξικό Python με ονόματα και αμετάβλητες τιμές `bytes`, και εκτυπώνει το όνομα, τον τύπο και το μέγεθος των byte. Διατηρεί ακριβώς τα παρεχόμενα ονόματα. Τα διπλότυπα ονόματα σηματοδοτούν τη συλλογή ως άκυρη αντί να αντικαθιστούν σιωπηρά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό πριν χρησιμοποιήσει τα αποτελέσματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Αποκωδικοποίηση μόνο του XAML και μόνο όταν χρειάζεται κειμενική επιθεώρηση.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων των άγνωστων τύπων πόρων. Μην τροποποιείτε τα byte κατά την αποθήκευση ή τη μετάδοση. Χρησιμοποιήστε `bytes.decode` με UTF-8 μόνο για XAML που χρειάζεται κειμενική επεξεργασία.

### **Συσκευασία των συλλεγμένων αντικειμένων σε αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά byte σε ένα αρχείο ZIP. Ένα μοναδικό όνομα αρχείου διαχωρίζει τα ταυτόχρονα τρέχοντα έργα εξαγωγής. Τα στοιχεία ZIP χρησιμοποιούν διαγώνιες κάθετες γραμμές και διατηρούν τους σχετικούς καταλόγους. Τα μη ασφαλή ονόματα ή τα ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτονται πριν τη δημιουργία του πακέτου.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Το κλείσιμο ολοκληρώνει τον κατάλογο ZIP πριν αναφερθεί η επιτυχία.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Το παράδειγμα χρησιμοποιεί το `zipfile.ZipFile` της Python για να γράψει ένα τοπικό αρχείο. Ο εξαγωγέας δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για αποθήκευση απομακρυσμένα, αντικαταστήστε το βήμα γραφής του αρχείου με ανεβάσματα των συλλεγμένων πινάκων byte. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής μαζί με το πλήρες σχετικό όνομα του αντικειμένου ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε μια εγγραφή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο μετά την ολοκλήρωση όλων των ανεβάσματος ή την επιβεβαίωση της συναλλαγής στη βάση. Καθαρίστε τυχόν ενδιάμεση έξοδο εάν η αποθήκευση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει κάθε αντικείμενο απευθείας στην αποθήκη της εφαρμογής ώστε να αποφεύγεται η διατήρηση ενός επιπλέον αντιγράφου ολόκληρης της εξαγωγής στη μνήμη. Κρατήστε κάθε κλήση συγχρονισμένη από την προοπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός αποδεχθεί τα byte και επιτρέψτε τις αποτυχίες να φτάσουν στον καλούντα.

### **Διατήρηση ονομάτων πόρων και επαλήθευση αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομής όταν ο προορισμός το απαιτεί, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο `pathlib.Path.name` εκτός εάν κάθε παραγόμενο όνομα είναι γνωστό ότι είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων ειδική για τον προορισμό. Κατά τη δημιουργία ξεχωριστών αρχείων, απορρίψτε διαδρομές που ξεκινούν από τη ρίζα και τμήματα πλοήγησης, επιλύστε τον προορισμό με `pathlib.Path.resolve` και βεβαιωθείτε ότι παραμένει κάτω από τον προοριζόμενο κατάλογο εξαγωγής, συμπεριλαμβανομένου του διαχωριστή καταλόγου στον έλεγχο περιεχομένου. Χρησιμοποιήστε έναν κατάλογο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να αναπροσανατολίσουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Ανιχνεύστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και εξετάστε τις αναφορές πόρων βάσει αρχείου, όπως τα χαρακτηριστικά `Source` ή `ImageSource` εικόνας. Επίλυση κάθε σχετικού URI έναντι του καταλόγου του περιεχόμενου αντικειμένου XAML, κανονικοποίηση του προκύπτοντος ονόματος αποθήκευσης και επιβεβαίωση ότι το αντίστοιχο κλειδί χάρτη, στοιχείο ZIP ή αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε εξωτερικές URI και εκφράσεις σήμανσης XAML χωριστά από ονόματα αρχείων.

Για παράδειγμα, εάν το `pres/Slide_1.xaml` αναφέρει το `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα διακόψει αυτή τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το ολοκληρωμένο ZIP για επαλήθευση των ονομάτων των στοιχείων και των byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο περιβάλλον XAML-στόχο για επιβεβαίωση ότι οι εικόνες επιλύονται σωστά.

## **ΣΥΝΧΩΜΑΤΙΚΑ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στον υπολογιστή;**

Καλέστε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [XamlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/) — χρησιμοποιείται ως γραμματοσειρά εναλλακτική κατά την εξαγωγή όταν λείπει η αρχική. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφερθεί στη γραμματοσειρά εναλλακτική ή ότι η γραμματοσειρά είναι διαθέσιμη στον προορισμό. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Απευθύνεται το εξαγόμενο XAML μόνο για WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο περιβάλλον-στόχο σας.

**Υποστηρίζονται κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την εξαγωγή τους από προεπιλογή;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) στο [XamlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xamloptions/) — κρατήστε το απενεργοποιημένο εάν δεν χρειάζεστε την εξαγωγή τους.