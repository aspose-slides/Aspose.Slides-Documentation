---
title: Διαμόρφωση αντικατάστασης γραμματοσειρών σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Αντικατάσταση γραμματοσειρών
type: docs
weight: 70
url: /el/java/font-substitution/
keywords:
- γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας αντικατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαμορφώστε κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει εκχωρηθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη, και μπορείτε να ελέγξετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διαφύλαξη της συνέπειας του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstitutioninfo/) που αναφέρουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Java εμφανίζει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με ένα όρισμα `int[] slides` για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για έναν διακομιστή ή κοντέινερ, ή διαγνώστε διαφορές απόδοσης χωρίς να επεξεργάζεστε μη σχετικές διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το ένα: το `1` αναφέρεται στην πρώτη διαφάνεια. Αντιθέτως, η συλλογή προσβάσιμη μέσω της μεθόδου [Presentation.getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) χρησιμοποιεί αρίθμηση που ξεκινά από το μηδέν, έτσι ώστε η ίδια διαφάνεια να προσπελαστεί ως `presentation.getSlides().get_Item(0)`. Λάβετε υπόψη αυτή τη διαφορά κατά τη δημιουργία του πίνακα ώστε να αποφύγετε σφάλματα κατά ένα.

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation.getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getFontsManager--) . Αυτή επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εναλλακτικότητας και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/java/custom-font/). Οι κανόνες αντικατάστασης αποθηκευμένοι σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsubstrulecollection/) εφαρμόζονται όταν η παρουσίαση αποδίδεται, αλλά το αποτέλεσμα δεν τα παραθέτει· ελέγξτε τις γραμματοσειρές στο αρχείο εξόδου αντ' αυτού.

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αφαιρέστε τις διπλές εγγραφές όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προεπιλογής. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Η διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε την όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που το Aspose.Slides πρέπει να χρησιμοποιεί όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τη γραμματοσειρά αντικατάστασης.
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Java αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά αντικατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Για μια ανεξάρτητη αλλαγή στις γραμματοσειρές που χρησιμοποιούνται σε ολόκληρη την παρουσίαση, δείτε την ενότητα [Font Replacement](/slides/el/java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών τύπων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι μαθηματικές εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί το **Cambria Math**, το Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά μια άλλη μαθηματική γραμματοσειρά, όπως το **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως [external font](/slides/el/java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη εξίσωσης. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω ισχύουν ακόμη για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς (font replacement) και αντικατάστασης γραμματοσειράς κατά την απόδοση (font substitution);**

[Font replacement] αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρείται η διαμορφωμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στη [font selection sequence](/slides/el/java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την κατάσταση `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειες τους.

**Μπορούν τα αποτελέσματα αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι περιοχές αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, επομένως μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί αντικατάσταση σε έναν άλλο.

**Πώς μπορώ να διασφαλίσω τη συνεπή επιλογή γραμματοσειρών σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [load required external fonts](/slides/el/java/custom-font/), και [embed fonts](/slides/el/java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) πριν από την εξαγωγή για να εντοπίσετε ανεπιθύμητες αντικαταστάσεις.