---
title: "Διαμόρφωση αντικατάστασης γραμματοσειράς σε παρουσιάσεις σε Android"
linktitle: "Αντικατάσταση γραμματοσειράς"
type: docs
weight: 70
url: /el/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Διαμορφώστε κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για Android μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που είναι ανατεθειμένη στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος σε συσκευές Android και περιβάλλοντα με διαφορετικές διαθέσιμες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsubstitutioninfo/) που προσδιορίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

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

Χρησιμοποιήστε τη μέθοδο [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με ένα όρισμα `int[] slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για μια εφαρμογή Android ή διαγνώσατε διαφορές απόδοσης χωρίς την επεξεργασία άσχετων διαφανειών.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με αρίθμηση από το 1: `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, ο συλλέκτης [Presentation.getSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlides--) χρησιμοποιεί μηδενική αρίθμηση, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation.getSlides().get_Item(0)`. Λάβετε υπόψη αυτή τη διαφορά κατά τη δημιουργία του πίνακα ώστε να αποφύγετε σφάλματα «ένα‑πέρα‑ένα».

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation.getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getFontsManager--). Επιστρέφει μόνο τις αντικαταστάσεις που καθορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες επιστροφής, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsubstrulecollection/), και τις [externally loaded fonts](/slides/el/androidjava/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τα διπλότυπα όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχιών γραμματοσειρών:

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

Η διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτήν που ταιριάζει στο πεδίο εφαρμογής της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειράς**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιήσει το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.  
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη γραμματοσειρά πηγής και τη γραμματοσειρά αντικατάστασης.  
3. Δημιουργήστε ένα αντικείμενο [FontSubstRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsubstrule/) με την συνθήκη [WhenInaccessible](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα Java αντικαθιστά τη γραμματοσειρά `Arial` με τη `SomeRareFont` όταν η `SomeRareFont` δεν είναι διαθέσιμη και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά αντικατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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
Για μια ανεξάρτητη αλλαγή στις γραμματοσειρές που χρησιμοποιούνται σε ολόκληρη την παρουσίαση, δείτε την [Font Replacement](/slides/el/androidjava/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειράς αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί τη **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως η **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτόν τον σκοπό· η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Φορτώστε τη ως [external font](/slides/el/androidjava/custom-font/) ώστε η εφαρμογή να μπορεί να τη χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι κανόνες αντικατάστασης που περιγράφονται παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και υποκατάστασης γραμματοσειράς;**

[Font replacement](/slides/el/androidjava/font-replacement/) αλλάζει προοδευτικά μία γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η υποκατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το αποδομένο αποτέλεσμα όταν πληρούνται οι ρυθμισμένες συνθήκες, όπως η μη διαθεσιμότητα της αρχικής γραμματοσειράς.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στη **font selection sequence**[/slides/el/androidjava/font-selection-sequence/] κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν υπάρχει κανένας κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/androidjava/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ συσκευών Android;**

Ναι. Οι διαθέσιμες γραμματοσειρές του συστήματος μπορεί να διαφέρουν μεταξύ εκδόσεων Android, συσκευών και κατασκευαστών, οπότε μια γραμματοσειρά που είναι διαθέσιμη σε ένα περιβάλλον μπορεί να απαιτεί υποκατάσταση σε άλλο.

**Πώς μπορώ να κάνω την επιλογή γραμματοσειράς συνεπή μεταξύ συσκευών Android;**

Συμπεριλάβετε τα ίδια απαραίτητα αρχεία γραμματοσειρών με την εφαρμογή, [load them as external fonts](/slides/el/androidjava/custom-font/), και [embed fonts](/slides/el/androidjava/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) πριν από την εξαγωγή για να εντοπίσετε απρόσμενες υποκαταστάσεις.