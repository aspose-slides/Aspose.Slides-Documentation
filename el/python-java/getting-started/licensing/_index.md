---
title: Αδειοδότηση
type: docs
weight: 80
url: /el/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- αρχείο άδειας
- προσωρινή άδεια
- αδειοδότηση με μέτρηση
- περιορισμοί αξιολόγησης
description: "Εφαρμόστε άδεια από αρχείο, με βάση τα bytes ή μετρημένη άδεια στο Aspose.Slides για Python μέσω Java και αφαιρέστε τους περιορισμούς αξιολόγησης από τις εφαρμογές σας."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java μπορεί να λειτουργήσει σε λειτουργία αξιολόγησης ή με άδεια. Αυτό το άρθρο εξηγεί πώς να εφαρμόσετε μια άδεια από αρχείο ή bytes και πώς να ρυθμίσετε την αδειοδότηση με μέτρηση.

Για επιλογές αγοράς, δείτε [Πληροφορίες Τιμολόγησης](https://purchase.aspose.com/pricing/slides/el/family). Για γενικές ερωτήσεις αδειοδότησης και αγοράς, δείτε [Πολιτικές Αγοράς και Συχνές Ερωτήσεις](https://purchase.aspose.com/policies).

Για περιορισμούς αξιολόγησης και πώς να ζητήσετε προσωρινή άδεια, δείτε [Αξιολόγηση Aspose.Slides](/slides/el/python-java/evaluate-aspose-slides/). Εφαρμόστε μια προσωρινή άδεια με τον ίδιο τρόπο όπως ένα αρχείο άδειας που αγοράστηκε.

## **Σχετικά με την Άδεια**

Ένα αρχείο άδειας περιέχει πληροφορίες όπως το όνομα του προϊόντος, ο αριθμός των αδειοδοτημένων προγραμματιστών και η ημερομηνία λήξης συνδρομής. Το αρχείο είναι ψηφιακά υπογεγραμμένο XML.

{{% alert color="warning" title="Warning" %}}
Μην επεξεργαστείτε το αρχείο άδειας. Ακόμη και ένα επιπλέον διάλειμμα γραμμής μπορεί να ακυρώσει την ψηφιακή του υπογραφή.
{{% /alert %}}

Εφαρμόστε την άδεια μία φορά ανά εφαρμογή ή διεργασία, πριν δημιουργήσετε παρουσιάσεις ή εκτελέσετε άλλες λειτουργίες Aspose.Slides. Για αρχείο άδειας, χρησιμοποιήστε την κλάση [License](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/). Η αδειοδότηση με μέτρηση χρησιμοποιεί ένα ζεύγος δημόσιου και ιδιωτικού κλειδιού αντί του αρχείου άδειας.

## **Εφαρμογή Άδειας**

Τα παρακάτω παραδείγματα υποθέτουν ότι το Aspose.Slides για Python μέσω Java και οι προαπαιτούμενες εξαρτήσεις του είναι εγκατεστημένα. Κάθε παράδειγμα είναι ένα αυτόνομο script που ξεκινά το JVM, εισάγει το API και εφαρμόζει μια άδεια. Στην εφαρμογή σας, εκτελέστε τις λειτουργίες παρουσίασης μετά την εφαρμογή της άδειας και κλείστε το JVM μόνο αφού ολοκληρωθεί όλη η εργασία Aspose.Slides.

### **Εφαρμογή Άδειας από Αρχείο**

Περάστε τη διαδρομή του αρχείου άδειας στο [License.setLicense](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#setLicense). Αντικαταστήστε `Aspose.Slides.lic` με τη διαδρομή του αρχείου άδειας σας.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Εκτελέστε τις λειτουργίες παρουσίασης εδώ, πριν κλείσετε το JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Χρησιμοποιήστε το ακριβές όνομα αρχείου, συμπεριλαμβανομένης της επέκτασής του. Για παράδειγμα, αν το αρχείο ονομάζεται `Aspose.Slides.lic.xml`, συμπεριλάβτε `.xml` στη διαδρομή. Μια απόλυτη διαδρομή αποτρέπει την ασάφεια σχετικά με το φάκελο εργασίας της εφαρμογής.

Το παράδειγμα χρησιμοποιεί το [License.isLicensed](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#isLicensed) για να ελέγξει εάν έχει εφαρμοστεί η άδεια.

### **Εφαρμογή Άδειας από Bytes**

Χρησιμοποιήστε το [License.setLicenseFromBytes](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#setLicenseFromBytes) όταν η άδεια είναι διαθέσιμη ως bytes της Python. Το παρακάτω παράδειγμα διαβάζει το αρχείο σε δυαδική λειτουργία και το κλείνει πριν από την εφαρμογή της άδειας.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Εκτελέστε λειτουργίες παρουσίασης εδώ, πριν κλείσετε το JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Διατηρήστε τα αρχικά bytes αμετάβλητα. Μην αποκωδικοποιήσετε, αναμορφώσετε ή διαφορετικά τροποποιήσετε το περιεχόμενο της άδειας πριν την εφαρμόσετε.

## **Εφαρμογή Μετρημένης Άδειας**

Η αδειοδότηση με μέτρηση χρεώνει ανάλογα με τη χρήση του API. Αφού αποκτήσετε μια μετρημένη άδεια, εφαρμόστε τα δημόσια και ιδιωτικά κλειδιά της με το [Metered.setMeteredKey](https://reference.aspose.com/slides/el/python-java/aspose.slides/metered/#setMeteredKey). Αρχικοποιήστε το αντικείμενο [Metered](https://reference.aspose.com/slides/el/python-java/aspose.slides/metered/) και εφαρμόστε τα κλειδιά μία φορά κατά την εκκίνηση της εφαρμογής.

Το παρακάτω παράδειγμα διαβάζει τα κλειδιά από τις μεταβλητές περιβάλλοντος `ASPOSE_METERED_PUBLIC_KEY` και `ASPOSE_METERED_PRIVATE_KEY`. Ορίστε και τις δύο μεταβλητές πριν εκτελέσετε το script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Εκτελέστε λειτουργίες παρουσίασης εδώ, πριν κλείσετε το JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Η αδειοδότηση με μέτρηση απαιτεί σύνδεση στο Internet για την επαλήθευση των κλειδιών και την αναφορά της χρήσης. Διατηρήστε το ιδιωτικό κλειδί εκτός του κώδικα πηγής και των καταγραφών. Δείτε τις [Συχνές Ερωτήσεις για τη Μετρημένη Αδειοδότηση](https://purchase.aspose.com/faqs/licensing/metered) για λεπτομέρειες σύνδεσης και χρέωσης.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πρέπει να εγκαταστήσω διαφορετικό πακέτο μετά την αγορά άδειας;**

Όχι. Εφαρμόστε την άδεια στο ίδιο πακέτο που χρησιμοποιήσατε για αξιολόγηση.

**Πρέπει να εφαρμόζω άδεια για κάθε παρουσίαση;**

Όχι. Εφαρμόστε την μία φορά κατά την εκκίνηση της εφαρμογής, πριν δημιουργήσετε ή φορτώσετε παρουσιάσεις.

**Μπορώ να μετονομάσω το αρχείο άδειας;**

Ναι. Χρησιμοποιήστε το ακριβές νέο όνομα αρχείου στον κώδικά σας και διατηρήστε το περιεχόμενο του αρχείου αμετάβλητο.

**Μπορώ να χρησιμοποιήσω προσωρινή άδεια με το παράδειγμα που βασίζεται σε bytes;**

Ναι. Διαβάστε το προσωρινό αρχείο άδειας ως bytes και εφαρμόστε το με τον ίδιο τρόπο όπως μια αγορασμένη άδεια.