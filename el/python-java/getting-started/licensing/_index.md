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
- χρεώσιμη αδειοδότηση
- περιορισμοί αξιολόγησης
description: "Εφαρμόστε μια άδεια από αρχείο, με βάση τα bytes, ή χρεώσιμη άδεια στο Aspose.Slides για Python μέσω Java και αφαιρέστε τους περιορισμούς αξιολόγησης από τις εφαρμογές σας."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java μπορεί να λειτουργεί σε λειτουργία αξιολόγησης ή με άδεια. Σε λειτουργία αξιολόγησης, προσθέτει ένα πλαίσιο κειμένου με υδατογράφημα αξιολόγησης σε κάθε διαφάνεια κάθε παρουσίασης που αποθηκεύει και περικόπτει το κείμενο που διαβάζει ο κώδικάς σας από τις παρουσιάσεις. Αυτό το άρθρο εξηγεί πώς να εφαρμόσετε μια άδεια από αρχείο ή από bytes και πώς να διαμορφώσετε τη χρεώσιμη άδεια.

Για επιλογές αγοράς, δείτε [Pricing Information](https://purchase.aspose.com/pricing/slides/el/family). Για γενικές ερωτήσεις σχετικά με τις άδειες και τις αγορές, δείτε [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Για περιορισμούς αξιολόγησης και πώς να ζητήσετε προσωρινή άδεια, δείτε [Evaluate Aspose.Slides](/slides/el/python-java/evaluate-aspose-slides/). Εφαρμόστε μια προσωρινή άδεια με τον ίδιο τρόπο όπως ένα αγορασμένο αρχείο άδειας.

## **Σχετικά με την Άδεια**

Ένα αρχείο άδειας περιέχει πληροφορίες όπως το όνομα του προϊόντος, τον αριθμό των αδειοδοτημένων προγραμματιστών και την ημερομηνία λήξης της συνδρομής. Το αρχείο είναι ψηφιακά υπογεγραμμένο XML.

{{% alert color="warning" title="Warning" %}}
Μην επεξεργαστείτε το αρχείο άδειας. Ακόμη και ένα επιπλέον διάλειμμα γραμμής μπορεί να ακυρώσει την ψηφιακή του υπογραφή.
{{% /alert %}}

Εφαρμόστε την άδεια μία φορά ανά εφαρμογή ή διαδικασία, πριν τη δημιουργία παρουσιάσεων ή την εκτέλεση άλλων λειτουργιών του Aspose.Slides. Για ένα αρχείο άδειας, χρησιμοποιήστε την κλάση [License](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/). Η χρεώσιμη άδεια χρησιμοποιεί ένα ζεύγος δημόσιου και ιδιωτικού κλειδιού αντί για αρχείο άδειας.

## **Εφαρμογή Άδειας**

Τα παρακάτω παραδείγματα υποθέτουν ότι το Aspose.Slides για Python μέσω Java και οι προαπαιτούμενες εξαρτήσεις του είναι εγκατεστημένα. Κάθε παράδειγμα είναι ένα αυτόνομο σενάριο που εκκινεί το JVM, εισάγει το API και εφαρμόζει μια άδεια. Στην εφαρμογή σας, εκτελείτε τις λειτουργίες παρουσίασης μετά την εφαρμογή της άδειας και τερματίζετε το JVM μόνο αφού ολοκληρωθεί όλη η εργασία του Aspose.Slides.

### **Εφαρμογή Άδειας από Αρχείο**

Παραδώστε τη διαδρομή του αρχείου άδειας στο [License.setLicense](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#setLicense). Αντικαταστήστε `Aspose.Slides.lic` με τη διαδρομή του αρχείου άδειάς σας.

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
        # Εκτελέστε τις λειτουργίες παρουσίασης εδώ, πριν τερματίσετε το JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Χρησιμοποιήστε το ακριβές όνομα του αρχείου, συμπεριλαμβανομένης της επέκτασής του. Για παράδειγμα, εάν το αρχείο ονομάζεται `Aspose.Slides.lic.xml`, συμπεριλάβετε το `.xml` στη διαδρομή. Μια απόλυτη διαδρομή αποφεύγει την αβεβαιότητα σχετικά με το φάκελο εργασίας της εφαρμογής.

Το παράδειγμα χρησιμοποιεί το [License.isLicensed](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#isLicensed) για να ελέγξει εάν η άδεια έχει εφαρμοστεί.

### **Εφαρμογή Άδειας από Bytes**

Χρησιμοποιήστε το [License.setLicenseFromBytes](https://reference.aspose.com/slides/el/python-java/aspose.slides/license/#setLicenseFromBytes) όταν η άδεια διατίθεται ως bytes της Python. Το παρακάτω παράδειγμα διαβάζει το αρχείο σε δυαδική λειτουργία και το κλείνει πριν εφαρμόσει την άδεια.

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
        # Εκτελέστε τις λειτουργίες παρουσίασης εδώ, πριν τερματίσετε το JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Διατηρήστε τα αρχικά bytes αμετάβλητα. Μην αποκωδικοποιήσετε, μορφοποιήσετε ή αλλιώς τροποποιήσετε το περιεχόμενο της άδειας πριν την εφαρμόσετε.

## **Εφαρμογή Χρεώσιμης Άδειας**

Η χρεώσιμη άδεια χρεώνει με βάση τη χρήση του API. Αφού αποκτήσετε μια χρεώσιμη άδεια, εφαρμόστε τα δημόσια και ιδιωτικά της κλειδιά με το [Metered.setMeteredKey](https://reference.aspose.com/slides/el/python-java/aspose.slides/metered/#setMeteredKey). Αρχικοποιήστε το αντικείμενο [Metered](https://reference.aspose.com/slides/el/python-java/aspose.slides/metered/) και εφαρμόστε τα κλειδιά μία φορά κατά την εκκίνηση της εφαρμογής.

Το παρακάτω παράδειγμα διαβάζει τα κλειδιά από τις μεταβλητές περιβάλλοντος `ASPOSE_METERED_PUBLIC_KEY` και `ASPOSE_METERED_PRIVATE_KEY`. Ορίστε και τις δύο μεταβλητές πριν τρέξετε το σενάριο.

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
        # Εκτελέστε τις λειτουργίες παρουσίασης εδώ, πριν τερματίσετε το JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Η χρεώσιμη άδεια απαιτεί σύνδεση στο Διαδίκτυο για την επικύρωση των κλειδιών και την αναφορά χρήσης. Κρατήστε το ιδιωτικό κλειδί εκτός του πηγαίου κώδικα και των αρχείων καταγραφής. Δείτε το [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) για λεπτομέρειες σύνδεσης και χρέωσης.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πρέπει να εγκαταστήσω διαφορετικό πακέτο μετά την αγορά μιας άδειας;**

Όχι. Εφαρμόστε την άδεια στο ίδιο πακέτο που χρησιμοποιήσατε για αξιολόγηση.

**Πρέπει να εφαρμόζω άδεια για κάθε παρουσίαση;**

Όχι. Εφαρμόστε τη μία φορά κατά την εκκίνηση της εφαρμογής, πριν τη δημιουργία ή τη φόρτωση παρουσιάσεων.

**Μπορώ να μετονομάσω το αρχείο άδειας;**

Ναι. Χρησιμοποιήστε το ακριβές νέο όνομα αρχείου στον κώδικά σας και διατηρήστε το περιεχόμενο του αρχείου αμετάβλητο.

**Μπορώ να χρησιμοποιήσω προσωρινή άδεια με το παράδειγμα που βασίζεται σε bytes;**

Ναι. Διαβάστε το προσωρινό αρχείο άδειας ως bytes και εφαρμόστε το με τον ίδιο τρόπο όπως μια αγορασμένη άδεια.