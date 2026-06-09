---
title: Διαμόρφωση Συλλογών Εφεδρικής Γραμματοσειράς σε .NET
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/net/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- εφεδρικός κανόνας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εφεδρικών γραμματοσειρών στο Aspose.Slides για .NET ώστε το κείμενο να παραμένει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρείας αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να τη αναθέσετε στην ιδιότητα `FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο `Presentation` έχει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εφεδρείας**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ifontfallbackrulescollection). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να ανατεθεί στην ιδιότητα [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) έχει μια ιδιότητα [FontsManager ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/properties/fontsmanager) με τη δική του παρουσία της κλάσης FontsManager.

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών και να την αντιστοιχίσετε στον FontsManager μιας συγκεκριμένης παρουσίασης:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Αφού ο FontsManager αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Απόδοση Παρουσίασης με Εφεδρική Γραμματοσειρά](/slides/el/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εφεδρείας μου στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης κατά την εκτέλεση· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

**Ισχύει η εφεδρεία για κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης χαρακτήρων (glyph) χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Εσείς προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και υπό τη δική σας ευθύνη.

**Μπορούν να χρησιμοποιηθούν ταυτόχρονα η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εφεδρεία για ελλιπείς γλύφους;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειρών: πρώτα η μηχανή επιλύει τη διαθεσιμότητα των γραμματοσειρών ([replacement](/slides/el/net/font-replacement/)/[substitution](/slides/el/net/font-substitution/)), στη συνέχεια η εφεδρεία συμπληρώνει τα κενά για ελλιπείς γλύφα σε διαθέσιμες γραμματοσειρές.