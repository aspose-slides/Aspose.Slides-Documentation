---
title: Διαμόρφωση υποκατάστασης γραμματοσειρών σε παρουσιάσεις σε C++
linktitle: Υποκατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Διαμορφώστε κανόνες υποκατάστασης γραμματοσειρών και ελέγξτε τις υποκατεστημένες γραμματοσειρές στο Aspose.Slides για C++ κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιήσει μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει εκχωρηθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη, και μπορείτε να ελέγξετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) για να καθορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsubstitutioninfo/) που ταυτοποιούν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το ακόλουθο παράδειγμα C++ εμφανίζει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

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

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) με όρισμα `System::ArrayPtr<int32_t> slides` για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε μια μεγάλη παρουσίαση σταδιακά, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώσετε διαφορές απόδοσης χωρίς να επεξεργαστείτε άσχετες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών που ξεκινούν από το 1: το `1` αναφέρεται στην πρώτη διαφάνεια. Αντιθέτως, η μέθοδος [Presentation::get_Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slide/) χρησιμοποιεί δείκτη μηδενικής βάσης, έτσι ώστε η ίδια διαφάνεια να προσπελαστεί ως `presentation->get_Slide(0)`. Λάβετε υπόψη αυτή τη διαφορά όταν δημιουργείτε τον πίνακα ώστε να αποφύγετε σφάλματα κατά ένα.

Κλήστε την υπερφόρτωση μέσω της μεθόδου [Presentation::get_FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_fontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντικατοπτρίζει το τρέχον περιβάλλον γραμματοσειρών, τους κανόνες προσωρινής ανάκτησης, τους κανόνες αντικατάστασης που αποθηκεύονται σε μια [IFontSubstRuleCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsubstrulecollection/), και [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/cpp/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τις διπλές καταχωρήσεις όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά ελέγχου. Το παρακάτω παράδειγμα εμφανίζει κάθε επιστρεφόμενη αντικατάσταση και έπειτα δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχιών γραμματοσειρών:

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

Το interface [IFontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε τη μία ανάλογα με το πεδίο εφαρμογής της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε την όταν |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) με `System::ArrayPtr<int32_t> slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειράς**

Για να ορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν η πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τη γραμματοσειρά αντικατάστασης.
3. Δημιουργήστε έναν [FontSubstRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsubstrule/) με την προϋπόθεση [WhenInaccessible](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το ακόλουθο παράδειγμα C++ αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο, και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά υποκατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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

{{% alert color="info" title="Σημείωση" %}}
Για μια ανεξάρτητη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε την [Αντικατάσταση γραμματοσειράς](/slides/el/cpp/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειράς αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν μια πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει την **Cambria Math** για αυτόν τον σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε την στο λειτουργικό σύστημα ή φορτώστε την ως [εξωτερική γραμματοσειρά](/slides/el/cpp/custom-font/).

Ο περιορισμός αυτός εφαρμόζεται στη διάταξη των εξισώσεων. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω ισχύουν ακόμα για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και υποκατάστασης γραμματοσειράς;**

Η [αντικατάσταση γραμματοσειράς](/slides/el/cpp/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η υποκατάσταση επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρείται η ρυθμισμένη προϋπόθεση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες υποκατάστασης;**

Οι κανόνες συμμετέχουν στην [ακολουθία επιλογής γραμματοσειράς](/slides/el/cpp/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την προϋπόθεση `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας υποκατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την υποκατάσταση;**

Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/cpp/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα υποκατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, έτσι μια γραμματοσειρά που είναι διαθέσιμη σε έναν υπολογιστή μπορεί να απαιτεί υποκατάσταση σε άλλο.

**Πώς μπορώ να εξασφαλίσω σταθερή επιλογή γραμματοσειρών σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε υπολογιστή ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/cpp/custom-font/), και [ενσωματώστε τις γραμματοσειρές](/slides/el/cpp/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε απρόσμενες υποκαταστάσεις.