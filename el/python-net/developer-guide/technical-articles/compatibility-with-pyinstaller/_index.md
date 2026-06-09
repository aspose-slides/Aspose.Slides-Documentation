---
title: Συμβατότητα με PyInstaller και cx_Freeze
linktitle: Συμβατότητα με PyInstaller
type: docs
weight: 122
url: /el/python-net/compatibility-with-pyinstaller/
keywords:
- συμβατότητα
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Συσκευάστε το Aspose.Slides for Python via .NET με το PyInstaller. Ακολουθήστε αυτόν τον οδηγό για να ενσωματώσετε, ρυθμίσετε και αντιμετωπίσετε προβλήματα της εφαρμογής σας σε ένα αυτόνομο εκτελέσιμο."
---
## **Εισαγωγή**

Aspose.Slides for Python via .NET extensions είναι τυπικές επεκτάσεις Python C, επομένως μπορούν να παγώσουν ως εξαρτήσεις προγράμματος με εργαλεία όπως PyInstaller και cx_Freeze (ή παρόμοια). Αυτό σας επιτρέπει να δημιουργείτε εκτελέσιμα αρχεία από τα σενάρια Python. Τα εργαλεία αυτά ονομάζονται «freezers» επειδή ενσωματώνουν τον κώδικά σας και τις εξαρτήσεις του σε ένα ενιαίο διανέμετο αρχείο που εκτελείται σε άλλους υπολογιστές χωρίς να απαιτεί την εγκατάσταση του Python ή πρόσθετες βιβλιοθήκες. Αυτή η προσέγγιση απλοποιεί τη διανομή των εφαρμογών Python.

Η παγώση μιας Aspose.Slides for Python via .NET επέκτασης ως εξάρτηση παρουσιάζεται παρακάτω με ένα απλό πρόγραμμα που χρησιμοποιεί Aspose.Slides.

## **PyInstaller**

Γενικά, δεν απαιτείται κάτι ιδιαίτερο όταν πακετάρετε ένα πρόγραμμα που εξαρτάται από μια Aspose.Slides for Python via .NET επέκταση. Όταν ένα πρόγραμμα εισάγει την επέκταση με τρόπο ορατό στο PyInstaller, η επέκταση θα ενσωματωθεί στο πρόγραμμα. Επειδή η Aspose.Slides for Python via .NET περιλαμβάνει hooks για το PyInstaller, οι εξαρτήσεις της ανιχνεύονται αυτόματα και αντιγράφονται στο πακέτο.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Ωστόσο, το PyInstaller μερικές φορές μπορεί να παραλείψει κρυφές εισαγωγές — μονάδες που εισάγονται δυναμικά ή έμμεσα από τον κώδικά σας. Για να συμπεριλάβετε μια κρυφή εισαγωγή, χρησιμοποιήστε τις επιλογές του PyInstaller. Οι εξαρτήσεις της επέκτασης καθορίζονται στα hooks του PyInstaller που διανέμονται με την Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Για να παγώσετε ένα πρόγραμμα με το cx_Freeze, ρυθμίστε το ώστε να περιλαμβάνει το κύριο πακέτο της Aspose.Slides for Python via .NET επέκτασης που χρησιμοποιείτε. Αυτό εξασφαλίζει ότι η επέκταση και όλες οι εξαρτημένες μονάδες θα αντιγραφούν στη δημιουργία μαζί με την εφαρμογή σας.

### **Χρήση του cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Χρήση του Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **Συχνές Ερωτήσεις**

**Χρειάζομαι το Microsoft PowerPoint ή το .NET εγκατεστημένο στον υπολογιστή του χρήστη;**

Όχι, το PowerPoint δεν απαιτείται. Η Aspose.Slides είναι μια αυτόνομη μηχανή· το πακέτο Python παραδίδει όλα όσα χρειάζονται ως επέκταση για το CPython. Ο χρήστης δεν χρειάζεται να εγκαταστήσει το .NET ξεχωριστά.

**Πώς πρέπει να προσθέσω σωστά την άδεια σε μια παγωμένη εφαρμογή;**

Μπορείτε να αποθηκεύσετε το XML της άδειας δίπλα στο εκτελέσιμο ή να το ενσωματώσετε ως πόρο και να το φορτώσετε από ένα προσβάσιμο μονοπάτι πριν από την πρώτη κλήση API. Σημαντικό: μην τροποποιήσετε το περιεχόμενο του XML (ούτε τα διαστήματα γραμμής).

**Τι πρέπει να κάνω αν οι γραμματοσειρές εμφανίζονται διαφορετικά μετά τη δημιουργία σε σύγκριση με την ανάπτυξη;**

Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιείτε είναι διαθέσιμες στο περιβάλλον προορισμού (ενσωματωμένες ή εγκατεστημένες στο σύστημα) και ότι τα μονοπάτια τους επιλύονται σωστά σε χρόνο εκτέλεσης· η συμπεριφορά των γραμματοσειρών είναι ιδιαίτερα ευαίσθητη σε Linux.