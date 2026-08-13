---
title: Δι��μόρφωση Συλλογών Εναλλακτικών Γραμματοσειρών σε C++
linktitle: Συλλογή Εναλλακτικής Γραμματοσειράς
type: docs
weight: 20
url: /el/cpp/create-fallback-fonts-collection/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής γραμματοσειράς
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εναλλακτικών γραμματοσειρών στο Aspose.Slides για C++ ώστε το κείμενο να παραμένει συνεπές και σαφές σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών για μια παρουσίαση. Κάθε κανόνας εναλλακτικής γραμματοσειράς εκπροσωπείται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Μετά τη δημιουργία της συλλογής, μπορείτε να την αναθέσετε χρησιμοποιώντας τη μέθοδο `set_FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε στιγμιότυπο `Presentation` έχει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι καθορισμένες εναλλακτικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εναλλακτικών γραμματοσειρών**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrulescollection/), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrulescollection/). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να περάσει στη μέθοδο [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) διαθέτει τη μέθοδο [get_FontsManager()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_fontsmanager/), η οποία επιστρέφει τη δική της εμφάνιση της κλάσης FontsManager.

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών και να την αναθέσετε στον FontsManager μιας συγκεκριμένης παρουσίασης:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Μετά την αρχικοποίηση του FontsManager με τη συλλογή εναλλακτικών γραμματοσειρών, οι εναλλακτικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="info" %}} 
Διαβάστε περισσότερα για το πώς να [Απόδοση Παρουσίασης με Εναλλακτική Γραμματοσειρά](/slides/el/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές ερωτήσεις**

### Θα ενσωματωθούν οι κανόνες εναλλακτικής γραμματοσειράς στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης κατά το χρόνο εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

### Εφαρμόζεται η εναλλακτική γραμματοσειρά σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλύφων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

### Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;

Όχι. Προσθέτετε και χρησιμοποιείτε γραμματοσειρές από την πλευρά σας και υπό τη δική σας ευθύνη.

### Μπορούν η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εναλλακτική για ελλιπή γλύφα να χρησιμοποιηθούν μαζί;

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειρών: πρώτα η μηχανή επιλύει τη διαθεσιμότητα γραμματοσειρών ([αντικατάσταση](/slides/el/cpp/font-replacement/)/[υποκατάσταση](/slides/el/cpp/font-substitution/)), στη συνέχεια η εναλλακτική γεμίζει τα κενά για ελλιπείς γλύφους σε διαθέσιμες γραμματοσειρές.