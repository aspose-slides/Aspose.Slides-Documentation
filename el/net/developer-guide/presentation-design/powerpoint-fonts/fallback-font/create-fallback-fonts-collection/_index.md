---
title: "Διαμόρφωση Συλλογών Εναλλακτικών Γραμματοσειρών σε .NET"
linktitle: "Συλλογή Εναλλακτικών Γραμματοσειρών"
type: docs
weight: 20
url: /el/net/create-fallback-fonts-collection/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαμορφώστε μια συλλογή εναλλακτικών γραμματοσειρών στο Aspose.Slides για .NET ώστε το κείμενο να παραμένει συνεπές και καθαρό στις παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η Aspose.Slides σάς επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εναλλακτικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εναλλακτικής γραμματοσειράς εκπροσωπείται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να την εκχωρήσετε στην ιδιότητα `FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο `Presentation` έχει τον δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι καθορισμένες εναλλακτικές γραμματοσειρές εφαρμόζονται κατά τη δημιουργία της παρουσίασης.

## **Εφαρμογή Κανόνων Εναλλακτικής Γραμματοσειράς**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε μια [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ifontfallbackrulescollection). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να εκχωρηθεί στην ιδιότητα [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) του κλάσης [FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager). Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) έχει μια ιδιότητα [FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/properties/fontsmanager) με τη δική του παρουσία της κλάσης `FontsManager`.

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών και να την αναθέσετε στον `FontsManager` μιας συγκεκριμένης παρουσίασης:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Αφού ο `FontsManager` αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι εναλλακτικές γραμματοσειρές εφαρμόζονται κατά τη δημιουργία της παρουσίασης.

{{% alert color="info" %}} 
Διαβάστε περισσότερα για το πώς να [Αναπαραγωγή Παρουσίασης με Εναλλακτική Γραμματοσειρά](/slides/el/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Θα ενσωματωθούν οι κανόνες εναλλακτικής γραμματοσειράς στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στο UI του PowerPoint.

### Εφαρμόζεται η εναλλακτική γραμματοσειρά σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;

Ναι. Ο ίδιος μηχανισμός αντικατάστασης χαρακτήρων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

### Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;

Όχι. Προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και με τη δική σας ευθύνη.

### Μπορούν οι αντικατάσταση/υποκατάσταση ελλιπών γραμματοσειρών και η εναλλακτική για ελλιπή γλύφους να χρησιμοποιηθούν μαζί;

Ναι. Είναι ανεξάρτητα στάδια της ίδιας αλυσίδας επίλυσης γραμματοσειρών: πρώτα η μηχανή λύνει τη διαθεσιμότητα γραμματοσειρών ([replacement](/slides/el/net/font-replacement/)/[substitution](/slides/el/net/font-substitution/)), στη συνέχεια η εναλλακτική καλύπτει τα κενά για ελλιπείς γλύφους στις διαθέσιμες γραμματοσειρές.