---
title: Διαμόρφωση αντικατάστασης γραμματοσειρών σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/java/font-substitution/
keywords:
- γραμματοσειρά
- υποκατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις υποκατεστημένες γραμματοσειρές στο Aspose.Slides για Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιήσει μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να εξετάσετε τις αντικαταστάσεις που το Aspose.Slides θα κάνει κατά την απόδοση. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstitutioninfo/) που προσδιορίζουν τα αρχικά και τα υποκατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Java παραθέτει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

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

Χρησιμοποιήστε το υπερφορτωμένο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με όρισμα `int[] slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγωνίζεστε διαφορές απόδοσης χωρίς να επεξεργαστείτε άσχετες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το 1: το `1` αναφέρεται στην πρώτη διαφάνεια. Αντίθετα, η πρόσβαση στη συλλογή [Presentation.getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) χρησιμοποιεί δείκτες που ξεκινούν από το 0, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation.getSlides().get_Item(0)`. Έχετε υπόψη αυτή τη διαφορά όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα «off‑by‑one».

Καλέστε το υπερφορτωμένο μέθοδο μέσω του [Presentation.getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getFontsManager--) . Η μέθοδος επιστρέφει μόνο τις αντικαταστάσεις που καθορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα υποκατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsubstrulecollection/), και [εξωτερικές γραμματοσειρές](/slides/el/java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αφαιρέστε τις διπλότυπες καταχωρίσεις όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

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

Το interface [IFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.  
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τη γραμματοσειρά υποκατάστασης.  
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstcondition/).  
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsubstrulecollection/).  
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Java αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά υποκατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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
Για μια ανεπιφύλακτη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε το [Font Replacement](/slides/el/java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί τη **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη γραμματοσειρά μαθηματικών, όπως η **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτόν τον σκοπό, και η απόδοση μπορεί ακόμα να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε τη στο λειτουργικό σύστημα ή φορτώστε τη ως [εξωτερική γραμματοσειρά](/slides/el/java/custom-font/).

Αυτός ο περιορισμός εφαρμόζεται στη διάταξη των εξισώσεων. Οι παραπάνω κανόνες αντικατάστασης εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειράς;**

[Font replacement](/slides/el/java/font-replacement/) αλλάζει σκόπιμα μία γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρούται η ρυθμισμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στην [ακολουθία επιλογής γραμματοσειράς](/slides/el/java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την κατάσταση `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose τις γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, οπότε μια γραμματοσειρά που είναι διαθέσιμη σε ένα σύστημα μπορεί να χρειάζεται αντικατάσταση σε άλλο.

**Πώς μπορώ να κάνω τη επιλογή γραμματοσειρών συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/java/custom-font/), και [ενσωματώστε τις γραμματοσειρές](/slides/el/java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) πριν από την εξαγωγή για να εντοπίσετε απρόβλεπτες αντικαταστάσεις.