---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/python-java/installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- εγκατάσταση Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Εγκαταστήστε το Aspose.Slides για Python μέσω Java στα Windows, Linux ή macOS, ρυθμίστε τη Java και το JPype και επαληθεύστε τη ρύθμιση με ένα λειτουργικό παράδειγμα."
---
Το Aspose.Slides για Python μέσω Java λειτουργεί σε Windows, Linux και macOS. Χρησιμοποιεί το JPype για πρόσβαση στη βιβλιοθήκη Java από την Python. Το Microsoft PowerPoint δεν απαιτείται.

## **Προαπαιτούμενα**

Πριν εγκαταστήσετε τα πακέτα Python, εγκαταστήστε την Python και ένα JDK που πληροί τις [System Requirements](/slides/el/python-java/system-requirements/). Η σελίδα αυτή παραθέτει τις συμβατές εκδόσεις, τις απαιτήσεις αρχιτεκτονικής και τυχόν εξαρτήσεις που χρειάζονται για τη δημιουργία του JPype από πηγαίο κώδικα.

Ορίστε το `JAVA_HOME` στον κατάλογο εγκατάστασης του JDK, όχι στον υποκατάλογο `bin`, και προσθέστε τον κατάλογο `bin` του JDK στο `PATH`. Ανοίξτε ένα νέο τερματικό μετά την αλλαγή των μεταβλητών περιβάλλοντος.

## **Εγκατάσταση από PyPI**

Εκτελέστε τις παρακάτω εντολές σε ένα τερματικό, όχι στο διαδραστικό περιβάλλον της Python. Δημιουργήστε έναν φάκελο έργου και ένα εικονικό περιβάλλον για να διατηρήσετε τα πακέτα απομονωμένα από άλλα έργα.

### **Windows**

Με τον επιλεγμένο διερμηνέα Python διαθέσιμο ως `python` στο `PATH`, εκτελέστε τις παρακάτω εντολές στο Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux και macOS**

Με την επιλεγμένη έκδοση της Python διαθέσιμη ως `python3`, εκτελέστε τις παρακάτω εντολές στο Bash ή zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Σε Debian ή Ubuntu, εάν η δημιουργία του περιβάλλοντος αποτύχει επειδή το `ensurepip` δεν είναι διαθέσιμο, εγκαταστήστε το πακέτο `python3-venv` με την εντολή `sudo apt-get install python3-venv` και, στη συνέχεια, επαναλάβετε την εντολή δημιουργίας του περιβάλλοντος. Μια ξεχωριστά εγκατεστημένη έκδοση της Python μπορεί να χρειάζεται το αντίστοιχο πακέτο `venv` για τη συγκεκριμένη έκδοση.

### **Εγκατάσταση των Πακέτων**

Με το εικονικό περιβάλλον ενεργό, εγκαταστήστε το JPype και το Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Η χρήση του `python -m pip` διασφαλίζει ότι τα πακέτα εγκαθίστανται για τον διερμηνέα που χρησιμοποιείται για την εκτέλεση της εφαρμογής σας.

Για να ενημερώσετε μια υπάρχουσα εγκατάσταση του Aspose.Slides, εκτελέστε την εντολή `python -m pip install --upgrade aspose-slides-java` στο ίδιο περιβάλλον.

## **Εγκατάσταση από αρχείο ZIP**

Μπορείτε επίσης να χρησιμοποιήσετε τη βιβλιοθήκη από τη [Aspose.Slides σελίδα λήψης](https://releases.aspose.com/slides/el/python-java/):

1. Εγκαταστήστε την Python και τη Java όπως περιγράφεται στα [Προαπαιτούμενα](#prerequisites).
2. Δημιουργήστε και ενεργοποιήστε ένα εικονικό περιβάλλον ακολουθώντας τις παραπάνω οδηγίες.
3. Εγκαταστήστε το JPipe με την εντολή `python -m pip install JPype1`.
4. Κατεβάστε και αποσυμπιέστε το αρχείο ZIP του Aspose.Slides για Python μέσω Java.
5. Εντοπίστε τον εξαγόμενο κατάλογο πακέτου `asposeslides`. Διατηρήστε τα περιεχόμενά του, συμπεριλαμβανομένου του καταλόγου `lib` και του αρχείου JAR, μαζί.
6. Τοποθετήστε το `example.py` από την επόμενη ενότητα δίπλα στον κατάλογο `asposeslides` ώστε η Python να μπορεί να εισάγει το πακέτο. Το αρχείο ZIP περιέχει ήδη το δικό του `example.py` δίπλα στο `asposeslides`; αντικαταστήστε το με το παρακάτω.

## **Επαλήθευση της Εγκατάστασης**

Αποθηκεύστε τον παρακάτω κώδικα ως `example.py`. Δημιουργεί μια παρουσίαση με ένα πεδίο κειμένου και την αποθηκεύει ως `out.pptx` στον τρέχοντα κατάλογο εργασίας.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Με το εικονικό περιβάλλον ενεργό, εκτελέστε το παράδειγμα από τον κατάλογο που περιέχει το `example.py`:

```sh
python example.py
```

Η εισαγωγή `asposeslides` καταχωρίζει τη συσκευασμένη βιβλιοθήκη Java πριν ξεκινήσει η JVM. Εισάγετε το `asposeslides.api` μετά την έναρξη της JVM και απελευθερώστε τους πόρους της παρουσίασης πριν κλείσει.

{{% alert color="info" title="Note" %}}
Χωρίς άδεια, το αποτέλεσμα περιλαμβάνει υδατογράφημα αξιολόγησης. Δείτε τη σελίδα [Αξιολόγηση Aspose.Slides](/slides/el/python-java/evaluate-aspose-slides/) για περιορισμούς αξιολόγησης και πληροφορίες σχετικά με προσωρινή άδεια.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί η Python αναφέρει ότι η JVM δεν μπορεί να βρεθεί ή να φορτωθεί;**

Ελέγξτε ότι το `JAVA_HOME` δείχνει σε ένα JDK συμβατό με την Python και την εγκατάσταση του JPype, όπως περιγράφεται στις [System Requirements](/slides/el/python-java/system-requirements/). Δείτε τον [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) για επιπλέον ελέγχους.

**Γιατί η Python αναφέρει ότι λείπει το `asposeslides` μετά την εγκατάσταση;**

Το πακέτο μπορεί να έχει εγκατασταθεί για διαφορετικό διερμηνέα Python. Ενεργοποιήστε το εικονικό περιβάλλον που χρησιμοποιήθηκε για την εγκατάσταση και εκτελέστε `python -m pip show aspose-slides-java`. Σε εγκατάσταση μέσω ZIP, βεβαιωθείτε ότι ο κατάλογος `asposeslides` βρίσκεται δίπλα στο σενάριό σας ή είναι διαθέσιμος με άλλο τρόπο στη διαδρομή αναζήτησης των μονάδων της Python.

**Μπορώ να εκτελώ το παράδειγμα επανειλημμένα σε notebook;**

Το παράδειγμα προορίζεται για μια αυτόνομη διαδικασία Python. Πριν το προσαρτήσετε για επαναλαμβανόμενη εκτέλεση σε notebook, δείτε τις [Limitations and API Differences](/slides/el/python-java/limitations-and-api-differences/#import-the-library) για το κύκλο ζωής της JVM και οδηγίες για notebook.

**Γιατί το pip αποτυγχάνει με `CERTIFICATE_VERIFY_FAILED`;**

Αν το δίκτυό σας χρησιμοποιεί διακομιστή μεσολάβησης (proxy) που ελέγχει το HTTPS, το pip πρέπει να εμπιστεύεται την αρχή έκδοσης του πιστοποιητικού του. Διαμορφώστε το αξιόπιστο πακέτο CA χρησιμοποιώντας την επιλογή `--cert` του pip ή τη μεταβλητή περιβάλλοντος `PIP_CERT`, ακολουθώντας τις [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Η απαιτούμενη διαμόρφωση εξαρτάται από το δίκτυό σας και την έκδοση του pip.