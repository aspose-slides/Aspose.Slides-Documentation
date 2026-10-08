---
title: Διαμορφώστε την αντικατάσταση γραμματοσειρών σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/python-java/font-substitution/
keywords:
- γραμματοσειρά
- υποκατάστατη γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- εναλλαγή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας αντικατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στην Aspose.Slides για Python μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειρών επιτρέπει στην Aspose.Slides να χρησιμοποιήσει μια διαθέσιμη γραμματοσειρά στη θέση μιας γραμματοσειράς που δεν μπορεί να προσπελαστεί όταν μια παρουσία παρουσιάζεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να ελέγξετε τις αντικαταστάσεις που θα κάνει η Aspose.Slides κατά τη διάρκεια της απόδοσης. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

Αν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει ειδική έντονη μορφή, δείτε [Handle Fonts Without a Dedicated Bold Typeface](/slides/el/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Το τμήμα αυτό εξηγεί πώς να ραστεριόσετε το επηρεασμένο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για την επιλογή κειμένου, την αναζήτηση και την κλιμάκωση.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) που προσδιορίζουν τα αρχικά και τα αντικατασταθέντα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Python καταγράφει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

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

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) με όρισμα πίνακα ακεραίων Java για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγινώσκετε διαφορές απόδοσης χωρίς την επεξεργασία μη σχετικών διαφανειών.

Ο πίνακας `slides` περιλαμβάνει δείκτες διαφανειών με βάση το 1: το `1` αναγνωρίζει την πρώτη διαφάνεια. Αντίθετα, ο προσπελάστης συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) χρησιμοποιεί μηδενική αρίθμηση, οπότε η ίδια διαφάνεια προσπελάζεται ως `presentation.getSlides().get_Item(0)`. Κρατήστε αυτό το διαφορά κατά την κατασκευή του πίνακα για να αποφύγετε σφάλματα κατά ένα.

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατασταθέντα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), και [externally loaded fonts](/slides/el/python-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τις διπλές εγγραφές όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχιών γραμματοσειρών:

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

Η κλάση [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στο πεδίο εφαρμογής της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε την όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) με πίνακα ακεραίων Java | Χρειάζεστε αντικαταστάσεις για ένα επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που πρέπει η Aspose.Slides να χρησιμοποιήσει όταν μια πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τις πηγαίες και τις αντικαταστατικές γραμματοσειρές.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Εκχωρήστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Python αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η αντικαταστατική γραμματοσειρά πρέπει να είναι διαθέσιμη στην Aspose.Slides.

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
Για μια άνευ όρων αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε [Font Replacement](/slides/el/python-java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών είναι μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν η Aspose.Slides μπορεί να αντικαταστήσει μια μη προσπελάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, η Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στην Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως [external font](/slides/el/python-java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη της εξίσωσης. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειράς;**

[Font replacement](/slides/el/python-java/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά σε άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν ικανοποιείται η ρυθμισμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στην [font selection sequence](/slides/el/python-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν η Aspose.Slides δεν μπορεί να προσπελάσει τη πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν υπάρχει ρυθμισμένος κανόνας αντικατάστασης;**

Η Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών της. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/python-java/custom-font/) ώστε η Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει η Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, οπότε μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί αντικατάσταση σε άλλον.

**Πώς μπορώ να εξασφαλίσω συνέπεια στην επιλογή γραμματοσειρών κατά τις μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [load required external fonts](/slides/el/python-java/custom-font/), και [embed fonts](/slides/el/python-java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) πριν από την εξαγωγή για να εντοπίσετε ανεπιθύμητες αντικαταστάσεις.