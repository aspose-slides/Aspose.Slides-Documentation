---
title: "Διαμόρφωση αντικατάστασης γραμματοσειρών σε παρουσιάσεις με Python"
linktitle: "Αντικατάσταση γραμματοσειράς"
type: docs
weight: 70
url: /el/python-net/font-substitution/
keywords:
- γραμματοσειρά
- γραμματοσειρά υποκατάστασης
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαμορφώστε κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις γραμματοσειρές που έχουν υποκατασταθεί στο Aspose.Slides για Python μέσω .NET κατά την απόδοση ή μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά στη θέση μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν ένα παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το αποτέλεσμα της απόδοσης· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε ποια γραμματοσειρά θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να ελέγξετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση συνεπούς εξόδου σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager.get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsubstitutioninfo/) που προσδιορίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Python εμφανίζει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε το [FontsManager.get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) με λίστα από δείκτες διαφάνειας για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μία μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, ετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγωνίζεστε διαφορές απόδοσης χωρίς την επεξεργασία άσχετων διαφανειών.

Η λίστα περιέχει δείκτες διαφάνειας με βάση το 1: `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, η συλλογή [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) είναι μηδενική, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation.slides[0]`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τη λίστα ώστε να αποφύγετε σφάλματα «off‑by‑one».

Καλέστε τη μέθοδο μέσω της ιδιότητας [Presentation.fonts_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/fonts_manager/). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν ενώ αποδιδόμενες οι επιλεγμένες διαφάνειες. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες υποκατάστασης, τους κανόνες υποκατάστασης που αποθηκεύονται σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/ifontsubstrulecollection/), και [εξωτερικές γραμματοσειρές](/slides/el/python-net/custom-font/).

Η ίδια υποκατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αποδεκατοποιήστε τα αποτελέσματα όταν δημιουργείτε κατάλογο γραμματοσειρών ή έκθεση προεγγραφής. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη υποκατάσταση και στη συνέχεια δημιουργεί ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/) παρέχει και τις δύο μορφές της μεθόδου. Επιλέξτε αυτή που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Κλήση μεθόδου | Πότε να τη χρησιμοποιήσετε |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) με λίστα δεικτών διαφάνειας | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για τον καθορισμό της γραμματοσειράς που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.  
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη γραμματοσειρά πηγής και την υποκατάστασή της.  
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsubstrule/) με τη συνθήκη [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsubstcondition/).  
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsubstrulecollection/).  
5. Αναθέστε τη συλλογή στην ιδιότητα [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Python αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά υποκατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Σημείωση" %}}
Για ακανόνιστη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε ολόκληρη την παρουσίαση, δείτε το [Font Replacement](/slides/el/python-net/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειράς είναι μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτόν τον σκοπό και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε τη στο λειτουργικό σύστημα ή φορτώστε την ως [εξωτερική γραμματοσειρά](/slides/el/python-net/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη της εξίσωσης. Οι κανόνες υποκατάστασης που περιγράφονται παραπάνω παραμένουν σε ισχύ για το κανονικό κείμενο της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειράς;**  
[Font replacement](/slides/el/python-net/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το αποδιδόμενο αποτέλεσμα όταν ισχύει η καθορισμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**  
Οι κανόνες συμμετέχουν στη [font selection sequence](/slides/el/python-net/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WHEN_INACCESSIBLE`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν υπάρχει ρυθμισμένος κανόνας υποκατάστασης;**  
Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο χρόνο εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**  
Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/python-net/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**  
Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορεί το αποτέλεσμα της υποκατάστασης να διαφέρει μεταξύ Windows, Linux και macOS;**  
Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, οπότε μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί υποκατάσταση σε άλλον.

**Πώς μπορώ να κάνω την επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**  
Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/python-net/custom-font/), και [ενσωματώστε γραμματοσειρές](/slides/el/python-net/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [FontsManager.get_substitutions](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_substitutions/) πριν από την εξαγωγή για να εντοπίσετε απροσδόκητες υποκαταστάσεις.