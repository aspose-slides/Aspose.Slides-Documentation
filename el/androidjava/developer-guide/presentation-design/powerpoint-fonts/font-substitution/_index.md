---
title: Διαμόρφωση αντικατάστασης γραμματοσειράς σε παρουσιάσεις στο Android
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και επιθεωρήστε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για Android μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσπελάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει την παραγόμενη έξοδο· δεν αλλάζει τη γραμματοσειρά που έχει εκχωρηθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθάει στη διατήρηση της συνέπειας της εξόδου σε Android συσκευές και περιβάλλοντα με διαφορετικές διαθέσιμες γραμματοσειρές.

Εάν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει αφιερωμένο έντονο στυλ, δείτε το [Χειρισμός γραμματοσειρών χωρίς αφιερωμένο έντονο στυλ](/slides/el/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Η ενότητα αυτή εξηγεί πώς να ραστεροποιήσετε το επηρεασμένο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για επιλογή κειμένου, αναζήτηση και κλιμάκωση.

## **Λήψη αντικαταστάσεων γραμματοσειράς**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) που αναγνωρίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα Java καταγράφει όλες τις αντικαταστάσεις γραμματοσειράς για μια παρουσίαση:

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

## **Λήψη αντικαταστάσεων γραμματοσειράς για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με όρισμα `int[] slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για μια Android εφαρμογή ή διαγνώσετε διαφορές απόδοσης χωρίς να επεξεργαστείτε ανεξάρτητες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το 1: το `1` αντιστοιχεί στην πρώτη διαφάνεια. Αντίστροφα, ο προσπελάστης συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) χρησιμοποιεί δείκτες με βάση το 0, έτσι η ίδια διαφάνεια προσπελάζεται ως `presentation.getSlides().get_Item(0)`. Διατηρήστε αυτή τη διαφορά κατά τη δημιουργία του πίνακα για να αποφύγετε σφάλματα off‑by‑one.

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντικατοπτρίζει το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/androidjava/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τις διπλότυπες εγγραφές όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

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

Το interface [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτήν που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειράς**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τις πηγές και τις υποκατάστατες γραμματοσειρές.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Java αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η υποκατάστατη γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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
Για μια άνευ προϋπόθετων αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε το [Αντικατάσταση γραμματοσειρών](/slides/el/androidjava/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειράς αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που έχει οριστεί από έναν κανόνα.

Οι εξισώσεις Office Math έχουν επιπλέον απαίτηση. Εάν μια εξίσωση χρησιμοποιεί το **Cambria Math**, το Aspose.Slides μπορεί να χρειαστεί ακριβώς αυτή τη γραμματοσειρά για τον υπολογισμό και την απόδοση της διάταξης της εξίσωσης. Ένας κανόνας που αντικαθιστά με άλλη μαθηματική γραμματοσειρά, όπως το **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτό το σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Φορτώστε το ως [εξωτερική γραμματοσειρά](/slides/el/androidjava/custom-font/) ώστε η εφαρμογή να το χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω παραμένουν εφαρμόσιμοι στο κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειράς;**

Η [αντικατάσταση γραμματοσειράς](/slides/el/androidjava/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για την παραγόμενη έξοδο όταν ικανοποιείται η ρυθμισμένη προϋπόθεση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στη [ακολουθία επιλογής γραμματοσειράς](/slides/el/androidjava/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει διαμορφωθεί κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/androidjava/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose τις γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα της αντικατάστασης να διαφέρουν μεταξύ Android συσκευών;**

Ναι. Οι διαθέσιμες γραμματοσειρές συστήματος μπορεί να διαφέρουν μεταξύ εκδόσεων Android, συσκευών και κατασκευαστών, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε ένα περιβάλλον μπορεί να απαιτεί αντικατάσταση σε άλλο.

**Πώς μπορώ να καταστήσω την επιλογή γραμματοσειράς σύμφωνη σε όλες τις Android συσκευές;**

Συμπεριλάβετε τα ίδια απαιτούμενα αρχεία γραμματοσειρών με την εφαρμογή, [φορτώστε τα ως εξωτερικές γραμματοσειρές](/slides/el/androidjava/custom-font/), και [ενσωματώστε τις γραμματοσειρές](/slides/el/androidjava/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) πριν την εξαγωγή για να εντοπίσετε απρόσμενες αντικαταστάσεις.