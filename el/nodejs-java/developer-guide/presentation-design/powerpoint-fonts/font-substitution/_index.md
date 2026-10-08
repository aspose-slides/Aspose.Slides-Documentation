---
title: Διαμόρφωση αντικατάστασης γραμματοσειρών σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Αντικατάσταση γραμματοσειρών
type: docs
weight: 70
url: /el/nodejs-java/font-substitution/
keywords:
- γραμματοσειρά
- εναλλακτική γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας αντικατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για Node.js μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειρών επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί της γραμματοσειράς που δεν μπορεί να προσπελαστεί όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει οριστεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη, καθώς και να ελέγξετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

Εάν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει αφιερωμένο έντονο στυλ, δείτε το [Διαχείριση γραμματοσειρών χωρίς αφιερωμένο έντονο στυλ](/slides/el/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Αυτή η ενότητα εξηγεί πώς να ραστερίσετε το επηρεαζόμενο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για την επιλογή κειμένου, την αναζήτηση και την κλιμάκωση.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) που αναγνωρίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα JavaScript καταγράφει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

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

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε τη μέθοδο [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) με μια σειρά ευρετηρίων διαφανειών για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγωνίζεστε διαφορές απόδοσης χωρίς να επεξεργάζεστε μη σχετικές διαφάνειες.

Η υπερφόρτωση απαιτεί μια Java primitive `int[]`. Δημιουργήστε τη με `java.newArray("int", [...])`; ένας απλός πίνακας JavaScript μετατρέπεται σε `Integer[]` και δεν ταιριάζει με αυτήν την υπερφόρτωση.

Ο πίνακας περιέχει ευρετήρια διαφανειών που ξεκινούν από το 1: το `1` αναγνωρίζει την πρώτη διαφάνεια. Αντιθέτως, η πρόσβαση στη συλλογή [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) χρησιμοποιεί μηδενική αρίθμηση, ώστε η ίδια διαφάνεια να προσπελαστεί ως `presentation.getSlides().get_Item(0)`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τον πίνακα ώστε να αποφύγετε σφάλματα κατά ένα.

Καλέστε την υπερφόρτωση μέσω του [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντικατοπτρίζει το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης που έχουν αποθηκευτεί σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), καθώς και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/nodejs-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αποαποφύγετε τις διπλότυπες καταχωρήσεις όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

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

Η κλάση [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτήν που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) με ένα Java `int[]` ευρετηρίων διαφάνειας | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, διαδοχικό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να ορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.  
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη γραμματοσειρά πηγής και την υποκατάστατη.  
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Αντιστοιχίστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα JavaScript αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η υποκατάστατη γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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

{{% alert color="info" title="Σημείωση" %}}

Για αλγοριθμική αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε το [Αντικατάσταση γραμματοσειρών](/slides/el/nodejs-java/font-replacement/).

{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για τον υπολογισμό και την απόδοση της διάταξης της εξίσωσης. Ένας κανόνας που αντικαθιστά μια άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό, και η απόδοση ενδέχεται ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως [εξωτερική γραμματοσειρά](/slides/el/nodejs-java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη της εξίσωσης. Οι κανόνες αντικατάστασης που περιγράφονται παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειρών και αντικατάστασης γραμματοσειράς;**

[Font replacement](/slides/el/nodejs-java/font-replacement/) αλλάζει σκοπίμως μια γραμματοσειρά σε άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρείται η ρυθμισμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στη [ακολουθία επιλογής γραμματοσειράς](/slides/el/nodejs-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν υπάρχει ρυθμισμένος κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/nodejs-java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμε το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνος/ή για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, επομένως μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί αντικατάσταση σε άλλον.

**Πώς μπορώ να διασφαλίσω συνεπή επιλογή γραμματοσειράς σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/nodejs-java/custom-font/), και [ενσωματώστε γραμματοσειρές](/slides/el/nodejs-java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε απρόσμενες αντικαταστάσεις.