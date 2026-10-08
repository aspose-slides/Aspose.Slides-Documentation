---
title: Διαμόρφωση Υποκατάστασης Γραμματοσειρών σε Παρουσιάσεις με Python
linktitle: Υποκατάσταση Γραμματοσειρών
type: docs
weight: 70
url: /el/python-net/font-substitution/
keywords:
- γραμματοσειρά
- υποκατάσταση γραμματοσειράς
- υποκατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις υποκατεστημένες γραμματοσειρές στο Aspose.Slides για Python μέσω .NET κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί για μια γραμματοσειρά που δεν μπορεί να προσπελαστεί όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το αποδώμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά να διατηρείται η ομοιομορφία του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

Αν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει αφιερωμένο έντονο πρότυπο, δείτε [Διαχειριστείτε Γραμματοσειρές Χωρίς Αφιερωμένο Έντονο Πρόστυπο](/slides/el/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Αυτό το τμήμα εξηγεί πώς να ραστεριστεί το επηρεαζόμενο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για την επιλογή κειμένου, την αναζήτηση και την κλιμάκωση.

## **Απόκτηση Αντικαταστάσεων Γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) που αναγνωρίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Python παραθέτει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:
```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Απόκτηση Αντικαταστάσεων Γραμματοσειρών για Επιλεγμένες Διαφάνειες**

Χρησιμοποιήστε το [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) με μια λίστα δεικτών διαφανειών για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε σταδιακά μια μεγάλη παρουσίαση, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώστε διαφορές απόδοσης χωρίς επεξεργασία μη σχετικών διαφανειών.

Η λίστα περιέχει δείκτες διαφανειών που αρχίζουν από το 1: `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, η συλλογή [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) είναι μηδενική βάση, έτσι η ίδια διαφάνεια προσπελάζεται ως `presentation.slides[0]`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τη λίστα για να αποφύγετε σφάλματα κατά ένα.

Καλέστε τη μέθοδο μέσω της ιδιότητας [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εναλλακτικών, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/python-net/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τις διπλότυπες εγγραφές όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχιών γραμματοσειρών:
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

Η κλάση [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) παρέχει και τις δύο μορφές της μεθόδου. Επιλέξτε μία ανάλογα με το πεδίο εφαρμογής της λειτουργίας απόδοσης:

| Method call | Use it when |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) με λίστα δεικτών διαφανειών | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός Κανόνων Αντικατάστασης Γραμματοσειρών**

Για να ορίσετε τη γραμματοσειρά που το Aspose.Slides πρέπει να χρησιμοποιεί όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τις αντικαταστάτες γραμματοσειρές.
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) με την κατάσταση [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή στην ιδιότητα [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Python αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά υποκατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.
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

{{% alert color="info" title="Note" %}}
Για μια άνευ προϋποθέσεων αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε [Αντικατάσταση Γραμματοσειρών](/slides/el/python-net/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για Γραμματοσειρές Μαθηματικών Εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών είναι μέρος της τυπικής διαδικασίας επιλογής γραμματοσειρών που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί το **Cambria Math**, το Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως το **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτό το σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως μια [εξωτερική γραμματοσειρά](/slides/el/python-net/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι κανόνες υποκατάστασης που περιγράφθηκαν παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειρών και υποκατάστασης γραμματοσειρών;**

[Αντικατάσταση Γραμματοσειρών](/slides/el/python-net/font-replacement/) αλλάζει εκ προθέσεως μια γραμματοσειρά σε άλλη σε όλη την παρουσίαση. Η υποκατάσταση γραμματοσειρών επιλέγει μια γραμματοσειρά για το αποδιδόμενο αποτέλεσμα όταν πληρούται η διαμορφωμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στη [σειρά επιλογής γραμματοσειράς](/slides/el/python-net/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την κατάσταση `WHEN_INACCESSIBLE`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά προέλευσης.

**Τι συμβαίνει όταν μια γραμματοσειρά λείπει και δεν έχει ρυθμιστεί κανένας κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/python-net/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι θέσεις αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί υποκατάσταση σε άλλο.

**Πώς μπορώ να κάνω τη επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/python-net/custom-font/), και [ενσωματώστε γραμματοσειρές](/slides/el/python-net/embedded-font/) όταν η άδεια το επιτρέπει. Μπορείτε επίσης να καλέσετε το [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) πριν από την εξαγωγή για να εντοπίσετε ανεπιθύμητες υποκαταστάσεις.