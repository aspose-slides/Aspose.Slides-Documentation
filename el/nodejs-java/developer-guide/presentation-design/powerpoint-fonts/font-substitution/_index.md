---
title: Διαμόρφωση Υποκατάστασης Γραμματοσειρών σε Παρουσιάσεις με JavaScript
linktitle: Υποκατάσταση Γραμματοσειρών
type: docs
weight: 70
url: /el/nodejs-java/font-substitution/
keywords:
- γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- υποκατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις αντικατασταθείσες γραμματοσειρές στο Aspose.Slides για Node.js μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειρών επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά στη θέση μιας γραμματοσειράς που δεν μπορεί να προσπελαστεί όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να επιθεωρήσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά τη διάρκεια της απόδοσης. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη Αντικαταστάσεων Γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstitutioninfo/) που αναγνωρίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα JavaScript παραθέτει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη Αντικαταστάσεων Γραμματοσειρών για Επιλεγμένες Διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) με έναν πίνακα δεικτών διαφανειών για να επιθεωρήσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε σταδιακά μια μεγάλη παρουσίαση, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, ετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για έναν διακομιστή ή κοντέινερ, ή διαγνώσετε διαφορές απόδοσης χωρίς να επεξεργαστείτε μη σχετικές διαφάνειες.

Η υπερφόρτωση αναμένει μια Java primitive `int[]`. Δημιουργήστε την με `java.newArray("int", [...])`; ένας απλός πίνακας JavaScript μετατρέπεται σε `Integer[]` και δεν ταιριάζει με αυτήν την υπερφόρτωση.

Ο πίνακας περιέχει δείκτες διαφανειών με αρίθμηση από το 1: το `1` εντοπίζει την πρώτη διαφάνεια. Αντιθέτως, ο προσπελάστης συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslides/) χρησιμοποιεί μηδενική αρίθμηση, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation.getSlides().get_Item(0)`. Δώστε προσοχή σε αυτή τη διαφορά κατά τη δημιουργία του πίνακα για να αποφύγετε σφάλματα κατά ένα.

Κλήστε την υπερφόρτωση μέσω του [Presentation.getFontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getfontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που καθορίστηκαν κατά την απόδοση των επιλεγμένων διαφανών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους διαμορφωμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstrulecollection/), και τις [externally loaded fonts](/slides/el/nodejs-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αφαιρέστε τα διπλότυπα στα αποτελέσματα όταν δημιουργείτε ένα αποθετήριο γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε μία ανάλογα με την εμβέλεια της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρήση όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός Κανονισμών Αντικατάστασης Γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη γραμματοσειρά προέλευσης και την αντικαταστάτη.
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Ανάθεστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα JavaScript αντικαθιστά το `Arial` για το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά αντικατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Για μια ανεξάρτητη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε την [Font Replacement](/slides/el/nodejs-java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για Γραμματοσειρές Μαθηματικών Εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειρών που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσπελάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί τη **Cambria Math**, το Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη γραμματοσειρά μαθηματικών, όπως η **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτό το σκοπό, και η απόδοση μπορεί να εξακολουθήσει να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε την στο λειτουργικό σύστημα ή φορτώστε την ως [external font](/slides/el/nodejs-java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη εξισώσεων. Οι παραπάνω κανόνες υποκατάστασης εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και υποκατάστασης γραμματοσειράς;**

Η [Font replacement](/slides/el/nodejs-java/font-replacement/) αλλάζει εσκεμμένα μια γραμματοσειρά με μια άλλη σε όλη την παρουσίαση. Η υποκατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρούται η ρυθμισμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στη [font selection sequence](/slides/el/nodejs-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά προέλευσης.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/nodejs-java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειες τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε μια μηχανή μπορεί να απαιτεί υποκατάσταση σε άλλη.

**Πώς μπορώ να διασφαλίσω την συνέπεια της επιλογής γραμματοσειρών σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και εκδόσεις σε κάθε μηχανή ή κοντέινερ, [load required external fonts](/slides/el/nodejs-java/custom-font/), και [embed fonts](/slides/el/nodejs-java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε την [FontsManager.getSubstitutions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε απροσδόκητες υποκαταστάσεις.