---
title: Διαμόρφωση υποκατάστασης γραμματοσειρών σε παρουσιάσεις σε .NET
linktitle: Υποκατάσταση γραμματοσειρών
type: docs
weight: 70
url: /el/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις υποκατεστημένες γραμματοσειρές στο Aspose.Slides για .NET κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειρών επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν μπορεί να προσπελαστεί όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη, και μπορείτε να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά τη διάρκεια της απόδοσης. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/net/aspose.slides/fontsubstitutioninfo/) που αναγνωρίζουν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα C# απαριθμεί όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) με όρισμα `int[] slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώστε διαφορές απόδοσης χωρίς την επεξεργασία άσχετων διαφανειών.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το 1: το `1` αναφέρει την πρώτη διαφάνεια. Αντίθετα, ο δείκτης της συλλογής [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) είναι μηδενικής βάσης, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation.Slides[0]`. Διατηρήστε αυτή τη διαφορά στο μυαλό όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα κατά ένα.

Καλέστε την υπερφόρτωση μέσω της ιδιότητας [Presentation.FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/fontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που καθορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/net/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsubstrulecollection/), και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/net/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Αφαιρέστε τα διπλότυπα στα αποτελέσματα όταν δημιουργείτε ένα απόθεμα γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

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

Η διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε μία ανάλογα με το πεδίο εφαρμογής της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για τον καθορισμό της γραμματοσειράς που πρέπει να χρησιμοποιεί το Aspose.Slides όταν η πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για την πηγαία και την αντικατάσταση.
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/el/net/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/el/net/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontsubstrulecollection/).
5. Εκχωρήστε τη συλλογή στην ιδιότητα [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα C# αντικαθιστά τη `Arial` με τη `SomeRareFont` όταν η `SomeRareFont` δεν είναι διαθέσιμη, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά αντικατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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
Για μια άνευ όρων αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε το [Αντικατάσταση γραμματοσειρών](/slides/el/net/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για τις γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί τη **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως η **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτόν το σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε τη στο λειτουργικό σύστημα ή φορτώστε τη ως μια [εξωτερική γραμματοσειρά](/slides/el/net/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι παραπάνω κανόνες υποκατάστασης ισχύουν ακόμη για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειρών (font replacement) και υποκατάστασης γραμματοσειρών (font substitution);**

Η [Αντικατάσταση γραμματοσειρών](/slides/el/net/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η υποκατάσταση γραμματοσειρών επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρούται η ρυθμισμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στη [ακολουθία επιλογής γραμματοσειράς](/slides/el/net/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει την πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/net/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose τις γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτήσει υποκατάσταση σε άλλο.

**Πώς μπορώ να κάνω τη επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/net/custom-font/), και [ενσωματώστε τις γραμματοσειρές](/slides/el/net/embedded-font/) όταν επιτρέπεται από την άδεια. Μπορείτε επίσης να καλέσετε την [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε μη αναμενόμενες υποκαταστάσεις.