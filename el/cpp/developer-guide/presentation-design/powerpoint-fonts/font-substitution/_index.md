---
title: Διαμόρφωση αντικατάστασης γραμματοσειράς σε παρουσιάσεις σε C++
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και εξετάστε τις αντικαταστημένες γραμματοσειρές στο Aspose.Slides για C++ κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και μπορείτε να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά τη διάρκεια της απόδοσης. Αυτό βοηθά να διατηρείται η συνέπεια του αποτελέσματος σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

Αν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν έχει αφιερωμένη έντονη γραμματοσειρά, δείτε [Διαχείριση γραμματοσειρών χωρίς αφιερωμένη έντονη γραμματοσειρά](/slides/el/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Αυτό το τμήμα εξηγεί πώς να ραστεράρετε το επηρεασμένο κείμενο κατά την εξαγωγή PDF και τις συνέπειες για την επιλογή κειμένου, την αναζήτηση και την κλιμάκωση.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν κατά την απόδοση της παρουσίασης. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) που ταυτοποιούν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα C++ καταγράφει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) με ένα όρισμα `System::ArrayPtr<int32_t> slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, ετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώστε διαφορές απόδοσης χωρίς να επεξεργαστείτε άσχετες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με αρίθμηση που αρχίζει από το ένα: το `1` αναπαριστά την πρώτη διαφάνεια. Αντίθετα, η μέθοδος [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) χρησιμοποιεί δείκτη μηδενικής βάσης, έτσι η ίδια διαφάνεια προσπελαύνεται ως `presentation->get_Slide(0)`. Λάβετε υπόψη αυτή τη διαφορά όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα κατά το ένα-προς-ένα.

Κλήστε την υπερφόρτωση μέσω της μεθόδου [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που καθορίζονται κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντικατοπτρίζει το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εναλλακτικής, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/cpp/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτηθεί από περισσότερες από μία επιλεγμένες διαφάνειες. Απλοποιήστε τα αποτελέσματα όταν δημιουργείτε ένα απογραφή γραμματοσειρών ή μια αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και έπειτα δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Η διεπαφή [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε μία ανάλογα με το πεδίο της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρήση όταν |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειράς για τη πηγή και τις εναλλακτικές γραμματοσειρές.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) με την κατάσταση [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα C++ αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να ελέγξει το αποτέλεσμα. Η εναλλακτική γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Για μια ανεξάρτητη αλλαγή στις γραμματοσειρές που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε [Αντικατάσταση γραμματοσειρών](/slides/el/cpp/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειρών που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί το **Cambria Math**, το Aspose.Slides ενδέχεται να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά μια άλλη μαθηματική γραμματοσειρά, όπως το **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτό το σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται το **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως μια [εξωτερική γραμματοσειρά](/slides/el/cpp/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι παραπάνω κανόνες αντικατάστασης παραμένουν σε ισχύ για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αλλαγής γραμματοσειράς και αντικατάστασης γραμματοσειράς;**

[Αντικατάσταση γραμματοσειρών](/slides/el/cpp/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση (font substitution) επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν ικανοποιείται η ρυθμισμένη κατάσταση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στην [ακολουθία επιλογής γραμματοσειράς](/slides/el/cpp/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την κατάσταση `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πλησιέστερη διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειρών του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/cpp/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και για τη συμμόρφωση με τις άδειες τους.

**Μπορούν τα αποτελέσματα της αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί αντικατάσταση σε άλλο.

**Πώς μπορώ να κάνω την επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/cpp/custom-font/), και [ενσωματώσετε τις γραμματοσειρές](/slides/el/cpp/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) πριν την εξαγωγή για να εντοπίσετε ανεπιθύμητες αντικαταστάσεις.