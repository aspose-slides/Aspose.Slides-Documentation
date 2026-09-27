---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/python-net/installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- χρήση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Εγκαταστήστε το Aspose.Slides για Python μέσω .NET από το PyPI με pip στα Windows, Linux και macOS, και εγκαταστήστε τις εγγενείς βιβλιοθήκες που χρειάζονται τα Linux και macOS."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εγκαταστήσετε το Aspose.Slides for Python via .NET στα Windows, Linux και macOS. Το πακέτο δημοσιεύεται στο [PyPI](https://pypi.org/project/aspose.slides/) και εγκαθίσταται με pip. Περιλαμβάνει το .NET runtime που χρησιμοποιεί, έτσι δεν χρειάζεται να εγκαταστήσετε .NET. Στα Linux και macOS, αυτό το runtime χρειάζεται εγγενείς βιβλιοθήκες που το λειτουργικό σύστημα ενδέχεται να μην περιλαμβάνει· οι παρακάτω ενότητες τις ονομάζουν.

Το Aspose.Slides for Python via .NET υποστηρίζει Python 3.5 έως 3.14. Το PyPI παρέχει πακέτα για Windows (32-bit και 64-bit), Linux (x86_64 και ARM64) και macOS (Intel και Apple silicon).

## **Windows**

Στα Windows, εγκαταστήστε το πακέτο με pip. Δεν απαιτούνται άλλες βιβλιοθήκες.

```bash
pip install aspose.slides
```

## **Linux**

Στα Linux, το .NET runtime που περιλαμβάνεται στο πακέτο χρειάζεται δύο βιβλιοθήκες:

- **libgdiplus**, μια υλοποίηση του Windows GDI+ graphics API. Χωρίς αυτήν, η αποθήκευση μιας παρουσίασης αποτυγχάνει με το σφάλμα `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Χωρίς αυτήν, η διεργασία Python τερματίζεται στην πρώτη κλήση του Aspose.Slides με το μήνυμα `Couldn't find a valid ICU package installed on the system`.

Στα Debian και Ubuntu, εγκαταστήστε και τις δύο με apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Το όνομα του πακέτου ICU περιέχει την έκδοσή του: το `libicu76` είναι το πακέτο για Debian 13. Στο Debian 12, εγκαταστήστε το `libicu72`, και στο Ubuntu 24.04, το `libicu74`. Για να βρείτε το όνομα στο σύστημά σας, εκτελέστε:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Στη συνέχεια εγκαταστήστε το πακέτο σε ένα εικονικό περιβάλλον. Στις τρέχουσες εκδόσεις του Debian και Ubuntu, το σύστημα Python δεν επιτρέπει το `pip install` εκτός εικονικού περιβάλλοντος και σταματά με το σφάλμα `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Εκτελέστε τα σενάρια σας με το ίδιο ενεργό εικονικό περιβάλλον. Εάν χρησιμοποιείτε μια έκδοση Python που δεν διαχειρίζεται η διανομή σας, όπως αυτή στις επίσημες εικόνες Docker `python`, μπορείτε επίσης να εκτελέσετε `pip install aspose.slides` χωρίς εικονικό περιβάλλον.

Οι γραμματοσειρές που χρησιμοποιούνται στις παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει να είναι εγκατεστημένες στο σύστημα ώστε το κείμενο να αποδίδεται σωστά όταν μετατρέπετε τις διαφάνειες σε PDF ή εικόνες.

## **macOS**

Δεν έχουμε επαληθεύσει την εγκατάσταση σε macOS. Στο macOS, το Aspose.Slides χρειάζεται τα ακόλουθα προαπαιτούμενα:

- **Python with shared libraries**, δηλαδή Python που έχει δομηθεί με την επιλογή διαμόρφωσης `--enable-shared`. Εάν εγκαταστήσετε Python με [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), ορίστε τη μεταβλητή περιβάλλοντος `PYTHON_CONFIGURE_OPTS` σε `--enable-shared` όταν εγκαθιστάτε μια έκδοση του Python.
- **The libpython library in a system library directory.** Ένα Python που εγκαταστάθηκε με pyenv διατηρεί τη βιβλιοθήκη libpython, όπως *libpython3.9.dylib*, στο *~/.pyenv/versions*· δημιουργήστε έναν συμβολικό σύνδεσμο σε αυτήν στο */usr/local/lib*.
- **libgdiplus**, μια υλοποίηση του Windows GDI+ graphics API. Το Homebrew το παρέχει ως το πακέτο `mono-libgdiplus`.

Στη συνέχεια εγκαταστήστε το πακέτο με pip.

## **Έλεγχος της Εγκατάστασης**

Για να ελέγξετε την εγκατάσταση, αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/python-net/create-presentation/) ως *hello.py* και εκτελέστε `python hello.py`. Θα αποθηκευτεί το *new_presentation.pptx* στον τρέχοντα φάκελο.

## **Αναβάθμιση**

Για να αναβαθμίσετε μια υπάρχουσα εγκατάσταση στην τελευταία έκδοση, εκτελέστε αυτήν την εντολή στο περιβάλλον όπου εγκαταστήσατε το πακέτο:

```bash
pip install --upgrade aspose.slides
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εγκαταστήσω το Aspose.Slides σε εικονικό περιβάλλον;**

Ναι. Μπορείτε να το εγκαταστήσετε σε οποιοδήποτε εικονικό περιβάλλον Python με pip. Οι εγγενείς βιβλιοθήκες που χρειάζονται τα Linux και macOS εγκαθίστανται στο σύστημα, όχι στο εικονικό περιβάλλον.

**Μπορώ να χρησιμοποιήσω το Aspose.Slides σε Docker containers;**

Ναι. Η εικόνα πρέπει να περιλαμβάνει τις ίδιες εγγενείς βιβλιοθήκες όπως ένα σύστημα Linux — libgdiplus και ICU — και τις γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας.

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι. Χωρίς άδεια, το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης: προσθέτει ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει και περικόπτει το κείμενο που διαβάζει από τις παρουσιάσεις. Για να αφαιρέσετε αυτούς τους περιορισμούς, εφαρμόστε μια έγκυρη [license](/slides/el/python-net/licensing/).