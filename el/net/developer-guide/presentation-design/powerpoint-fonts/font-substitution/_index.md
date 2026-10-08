---
title: Διαμόρφωση Υποκατάστασης Γραμματοσειρών σε Παρουσιάσεις σε .NET
linktitle: Υποκατάσταση Γραμματοσειρών
type: docs
weight: 70
url: /el/net/font-substitution/
keywords:
- γραμματοσειρά
- εναλλακτική γραμματοσειρά
- υποκατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας υποκατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις υποκατεστημένες γραμματοσειρές στο Aspose.Slides για .NET κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η υποκατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιήσει μια διαθέσιμη γραμματοσειρά αντί για μια γραμματοσειρά που δεν μπορεί να προσπελαστεί όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η υποκατάσταση επηρεάζει το αποδοθέν αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει εκχωρηθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιηθεί όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να ελέγξετε τις υποκαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

Εάν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει αφιερωμένο έντονο τύπο, δείτε [Διαχείριση Γραμματοσειρών Χωρίς Αφιερωμένο Έντονο Γραμματοτύπο](/slides/el/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Αυτή η ενότητα εξηγεί πώς να ραστεροποιήσετε το επηρεασμένο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για την επιλογή κειμένου, την αναζήτηση και την κλιμάκωση.

## **Λήψη Υποκατάστασης Γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) για να καθορίσετε ποιες γραμματοσειρές θα υποκατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) που ταυτοποιούν τα αρχικά και τα υποκατεστημένα ονόματα γραμματοσειρών.

Το ακόλουθο παράδειγμα C# καταγράφει όλες τις υποκαταστάσεις γραμματοσειρών για μια παρουσίαση:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Λήψη Υποκατάστασης Γραμματοσειρών για Επιλεγμένες Διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) με όρισμα `int[] slides` για να ελέγξετε μόνο τις υποκαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγωνίζεστε διαφορές απόδοσης χωρίς να επεξεργάζεστε άσχετες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το 1: το `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, ο δείκτης της συλλογής [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) είναι μηδενικής βάσης, οπότε η ίδια διαφάνεια προσπελαύνεται ως `presentation.Slides[0]`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα «off‑by‑one».

Κλήστε την υπερφόρτωση μέσω της ιδιότητας [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Επιστρέφει μόνο τις υποκαταστάσεις που καθορίζονται κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα υποκατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντικατοπτρίζει το τρέχον περιβάλλον γραμματοσειρών και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/net/custom-font/). Οι κανόνες υποκατάστασης που αποθηκεύονται σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) αλλάζουν το αποδοθέν αποτέλεσμα αλλά δεν αντικατοπτρίζονται στο αποτέλεσμα.

Η ίδια υποκατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τις διπλότυπες εγγραφές όταν δημιουργείτε απολογισμό αποθέματος γραμματοσειρών ή προπτήρα. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη υποκατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Η διεπαφή [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στην έκταση της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) χωρίς ορίσματα | Χρειάζεστε υποκαταστάσεις για ολόκληρη την παρουσίαση. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) με `int[] slides` | Χρειάζεστε υποκαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός Κανόνων Υποκατάστασης Γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για την πηγή και τις εναλλακτικές γραμματοσειρές.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) με τη συνθήκη [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Εκχωρήστε τη συλλογή στην ιδιότητα [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα C# υποκαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η εναλλακτική γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Για μια ανεξάρτητη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε [Αντικατάσταση Γραμματοσειρών](/slides/el/net/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για Γραμματοσειρές Μαθηματικών Εξισώσεων**

Οι κανόνες υποκατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειρών που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που υποκαθιστά μια άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως μια [εξωτερική γραμματοσειρά](/slides/el/net/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι κανόνες υποκατάστασης που περιγράφηκαν παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και υποκατάστασης γραμματοσειράς;**

Η [font replacement](/slides/el/net/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η υποκατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το αποδοθέν αποτέλεσμα όταν πληρούται η διαμορφωμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στη [font selection sequence](/slides/el/net/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει διαμορφωθεί κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές ώστε να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/net/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει η Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε ένα μηχάνημα μπορεί να απαιτεί υποκατάσταση σε άλλο.

**Πώς μπορώ να κάνω την επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [load required external fonts](/slides/el/net/custom-font/), και [embed fonts](/slides/el/net/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε απρόσμενες υποκαταστάσεις.