---
title: Διαμόρφωση αντικατάστασης γραμματοσειράς σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/python-java/font-substitution/
keywords:
- γραμματοσειρά
- εναλλακτική γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- αλλαγή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαμορφώστε κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για Python μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά στη θέση μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να ελέγξετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά να διατηρείται το αποτέλεσμα συνεπές μεταξύ περιβαλλοντικών διαφόρων εγκατεστημένων γραμματοσειρών.

## **Λήψη αντικαταστάσεων γραμματοσειράς**

Χρησιμοποιήστε τη μέθοδο [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstitutioninfo/) που αναφέρουν τα ονόματα της αρχικής και της αντικατεστημένης γραμματοσειράς.

Το ακόλουθο παράδειγμα Python απαριθμεί όλες τις αντικαταστάσεις γραμματοσειράς για μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Λήψη αντικαταστάσεων γραμματοσειράς για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) με όρισμα έναν πίνακα ακεραίων Java για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε σταδιακά μια μεγάλη παρουσίαση, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώσατε διαφορές απόδοσης χωρίς την επεξεργασία άσχετων διαφανειών.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση‑ένα: το `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, η προσπέλαση της συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) χρησιμοποιεί μηδενική αρίθμηση, ώστε η ίδια διαφάνεια να προσπελαστεί ως `presentation.getSlides().get_Item(0)`. Να έχετε υπόψη αυτή τη διαφορά όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα off‑by‑one.

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation.getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα ονόματα της αρχικής και της αντικατεστημένης γραμματοσειράς. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstrulecollection/), και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/python-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Καταργήστε τα διπλότυπα όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά preflight. Το ακόλουθο παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε την όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) με πίνακα ακεραίων Java | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειράς**

Για να προσδιορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.  
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη γραμματοσειρά πηγής και την εναλλακτική.  
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsubstrulecollection/).  
5. Εκχωρήστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Python αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η εναλλακτική γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Για μια μη υπό όρους αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε την ενότητα [Font Replacement](/slides/el/python-java/font-replacement/).

{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειράς αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για τον υπολογισμό και την απόδοση της διάταξης της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό και η απόδοση ενδέχεται ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για την απόδοση ή τη μετατροπή μιας τέτοιας παρουσίασης, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως [εξωτερική γραμματοσειρά](/slides/el/python-java/custom-font/).

Αυτός ο περιορισμός αφορά τη διάταξη της εξίσωσης. Οι κανόνες αντικατάστασης που περιγράφονται παραπάνω παραμένουν σε ισχύ για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και υποκατάστασης γραμματοσειράς;**

[Font replacement](/slides/el/python-java/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη καθ' όλη τη διάρκεια της παρουσίασης. Η υποκατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρείται η ρυθμισμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στην [ακολουθία επιλογής γραμματοσειράς](/slides/el/python-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν υπάρχει ρυθμισμένος κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/python-java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί υποκατάσταση σε άλλον.

**Πώς μπορώ να διατηρήσω τη συνεπή επιλογή γραμματοσειράς σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/python-java/custom-font/), και [ενσωματώστε γραμματοσειρές](/slides/el/python-java/embedded-font/) όταν επιτρέπουν οι άδειες. Μπορείτε επίσης να καλέσετε τη [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getSubstitutions) πριν την εξαγωγή για να εντοπίσετε απρόσμενες υποκαταστάσεις.