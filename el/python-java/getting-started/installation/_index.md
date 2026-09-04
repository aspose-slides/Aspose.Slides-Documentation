---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/python-java/installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Εγκαταστήστε το Aspose.Slides για Python μέσω Java σε Windows, Linux ή macOS, διαμορφώστε το Java και το JPype και επαληθεύστε τη ρύθμιση με ένα λειτουργικό παράδειγμα."
---
Aspose.Slides για Python μέσω Java λειτουργεί σε Windows, Linux και macOS. Χρησιμοποιεί το JPype για να έχει πρόσβαση στη βιβλιοθήκη Java από την Python. Το Microsoft PowerPoint δεν απαιτείται.

## **Προαπαιτούμενα**

Πριν εγκαταστήσετε τα πακέτα Python, εγκαταστήστε Python και ένα JDK που πληρούν τις [Απαιτήσεις Συστήματος](/slides/el/python-java/system-requirements/). Η σελίδα αυτή καταγράφει τις συμβατές εκδόσεις, τις απαιτήσεις αρχιτεκτονικής και τυχόν εξαρτήσεις που χρειάζονται για τη δημιουργία του JPype από πηγαίο κώδικα.

Ορίστε το `JAVA_HOME` στον φάκελο εγκατάστασης του JDK, όχι στον υποφάκελο `bin`, και προσθέστε το φάκελο `bin` του JDK στο `PATH`. Ανοίξτε ένα νέο τερματικό μετά την αλλαγή των μεταβλητών περιβάλλοντος.

## **Εγκατάσταση από PyPI**

Εκτελέστε τις παρακάτω εντολές σε ένα τερματικό, όχι στο διαδραστικό περιβάλλον της Python. Δημιουργήστε έναν φάκελο έργου και ένα εικονικό περιβάλλον για να κρατήσετε τα πακέτα απομονωμένα από άλλα έργα.

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

Σε Debian ή Ubuntu, εάν η δημιουργία του περιβάλλοντος αποτύχει επειδή το `ensurepip` δεν είναι διαθέσιμο, εγκαταστήστε το πακέτο `python3-venv` με `sudo apt-get install python3-venv`, και στη συνέχεια επαναλάβετε την εντολή δημιουργίας του περιβάλλοντος. Μια ξεχωριστά εγκατεστημένη έκδοση της Python ενδέχεται να χρειάζεται το αντίστοιχο πακέτο `venv` για τη συγκεκριμένη έκδοση.

### **Εγκατάσταση των Πακέτων**

Με το εικονικό περιβάλλον ενεργό, εγκαταστήστε το JPype και το Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Η χρήση του `python -m pip` διασφαλίζει ότι τα πακέτα εγκαθίστανται για τον διερμηνέα που χρησιμοποιείται για την εκτέλεση της εφαρμογής σας.

Για να ενημερώσετε μια υπάρχουσα εγκατάσταση του Aspose.Slides, εκτελέστε `python -m pip install --upgrade aspose-slides-java` στο ίδιο περιβάλλον.

## **Εγκατάσταση από αρχείο ZIP**

Μπορείτε επίσης να χρησιμοποιήσετε τη βιβλιοθήκη από τη [σελίδα λήψεων του Aspose.Slides](https://releases.aspose.com/slides/el/python-java/):

1. Εγκαταστήστε την Python και τη Java όπως περιγράφεται στις [Προαπαιτούμενα](#prerequisites).
2. Δημιουργήστε και ενεργοποιήστε ένα εικονικό περιβάλλον χρησιμοποιώντας τις παραπάνω οδηγίες.
3. Εγκαταστήστε το JPype με `python -m pip install JPype1`.
4. Κατεβάστε και εξάγετε το αρχείο ZIP του Aspose.Slides για Python μέσω Java.
5. Βρείτε τον εξαγμένο φάκελο πακέτου `asposeslides`. Κρατήστε τα περιεχόμενά του, συμπεριλαμβανομένου του φακέλου `lib` και του αρχείου JAR, μαζί.
6. Τοποθετήστε το `example.py` από την επόμενη ενότητα παράλληλα με το φάκελο `asposeslides` ώστε η Python να μπορεί να εισάγει το πακέτο.

## **Επαλήθευση της Εγκατάστασης**

Αποθηκεύστε τον παρακάτω κώδικα ως `example.py`. Δημιουργεί μια παρουσίαση με ένα πλαίσιο κειμένου και την αποθηκεύει ως `out.pptx` στον τρέχοντα κατάλογο εργασίας.

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

Με το εικονικό περιβάλλον ενεργό, εκτελέστε το παράδειγμα από τον φάκελο που περιέχει το `example.py`:

```sh
python example.py
```

Η εισαγωγή `asposeslides` καταχωρεί τη συσκευασμένη βιβλιοθήκη Java πριν ξεκινήσει η JVM. Εισάγετε το `asposeslides.api` μετά την εκκίνηση της JVM και απελευθερώστε τους πόρους της παρουσίασης πριν την τερματισμό της.

{{% alert color="info" title="Note" %}}
Χωρίς άδεια, η έξοδος περιλαμβάνει ένα υδατογράφημα αξιολόγησης. Δείτε την [Αξιολόγηση του Aspose.Slides](/slides/el/python-java/evaluate-aspose-slides/) για περιορισμούς αξιολόγησης και πληροφορίες προσωρινής άδειας.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί η Python αναφέρει ότι η JVM δεν μπορεί να βρεθεί ή να φορτωθεί;**

Βεβαιωθείτε ότι το `JAVA_HOME` δείχνει σε ένα JDK συμβατό με την εγκατάσταση της Python και του JPype, όπως περιγράφεται στις [Απαιτήσεις Συστήματος](/slides/el/python-java/system-requirements/). Δείτε τον [οδηγό αντιμετώπισης προβλημάτων εγκατάστασης του JPype](https://jpype.readthedocs.io/en/latest/install.html) για επιπλέον ελέγχους.

**Γιατί η Python αναφέρει ότι λείπει το `asposeslides` μετά την εγκατάσταση;**

Το πακέτο ενδέχεται να έχει εγκατασταθεί για διαφορετικό διερμηνέα Python. Ενεργοποιήστε το εικονικό περιβάλλον που χρησιμοποιήθηκε για την εγκατάσταση και εκτελέστε `python -m pip show aspose-slides-java`. Για εγκατάσταση από ZIP, βεβαιωθείτε ότι ο φάκελος `asposeslides` βρίσκεται παράλληλα με το script σας ή είναι διαθέσιμος στη διαδρομή αναζήτησης των μονάδων της Python.

**Μπορώ να εκτελέσω το παράδειγμα επανειλημμένα σε notebook;**

Το παράδειγμα προορίζεται για μια αυτόνομη διαδικασία Python. Πριν το προσαρμόσετε για επανειλημμένη εκτέλεση σε notebook, δείτε τις [Περιορισμούς και Διαφορές API](/slides/el/python-java/limitations-and-api-differences/#import-the-library) για τον κύκλο ζωής της JVM και οδηγίες για notebooks.

**Γιατί το pip αποτυγχάνει με `CERTIFICATE_VERIFY_FAILED`;**

Εάν το δίκτυό σας χρησιμοποιεί proxy επιθεώρησης HTTPS, το pip πρέπει να εμπιστεύεται την αρχή πιστοποίησής του. Διαμορφώστε το αξιόπιστο πακέτο CA χρησιμοποιώντας την επιλογή `--cert` του pip ή τη μεταβλητή περιβάλλοντος `PIP_CERT`, ακολουθώντας τις [οδηγίες πιστοποιητικού HTTPS του pip](https://pip.pypa.io/en/stable/topics/https-certificates/). Η απαιτούμενη διαμόρφωση εξαρτάται από το δίκτυό σας και τη έκδοση του pip.