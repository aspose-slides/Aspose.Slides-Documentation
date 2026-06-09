---
title: Διαμόρφωση Συλλογών Εφεδρικών Γραμματοσειρών σε C++
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/cpp/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- εφεδρικός κανόνας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εφεδρικών γραμματοσειρών στο Aspose.Slides για C++ ώστε το κείμενο να παραμένει συνεπές και ευκρινές σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρικής γραμματοσειράς αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να τη εκχωρήσετε χρησιμοποιώντας τη μέθοδο `set_FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο `Presentation` διαθέτει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή Κανόνων Εφεδρικής Γραμματοσειράς**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrulescollection/), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrulescollection/). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να περάσει στη μέθοδο [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/). Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) έχει μια μέθοδο [get_FontsManager()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_fontsmanager/) με τη δική της παρουσία της κλάσης `FontsManager`.

Ακολουθεί ένα παράδειγμα δημιουργίας συλλογής κανόνων εφεδρικής γραμματοσειράς και ανάθεσής της στο `FontsManager` μιας συγκεκριμένης παρουσίασης:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Μετά την αρχικοποίηση του `FontsManager` με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με το πώς να [Render Presentation with Fallback Font](/slides/el/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εφεδρείας στη διεπαφή PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης σε χρόνο εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν εμφανίζονται στη διεπαφή του PowerPoint.

**Εφαρμόζεται η εφεδρεία σε κείμενο εντός SmartArt, WordArt, γραφημάτων και πινάκων;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλυφών χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά μαζί με τη βιβλιοθήκη;**

Όχι. Εσείς προσθέτετε και χρησιμοποιείτε τις γραμματοσειρές από τη δική σας πλευρά και με τη δική σας ευθύνη.

**Μπορούν να χρησιμοποιηθούν ταυτόχρονα η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εφεδρεία για ελλιπή γλύφα;**

Ναι. Αποτελούν ανεξάρτητα στάδια της ίδιας αλυσίδας επίλυσης γραμματοσειράς: πρώτα η μηχανή επιλύει τη διαθεσιμότητα των γραμματοσειρών ([replacement](/slides/el/cpp/font-replacement/)/[substitution](/slides/el/cpp/font-substitution/)), στη συνέχεια η εφεδρεία γεμίζει τα κενά για ελλιπή γλύφα στις διαθέσιμες γραμματοσειρές.