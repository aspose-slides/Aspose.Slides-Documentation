---
title: Διαμόρφωση Συλλογών Εναλλακτικών Γραμματοσειρών σε Python
linktitle: Συλλογή Εναλλακτικής Γραμματοσειράς
type: docs
weight: 20
url: /el/python-net/create-fallback-fonts-collection/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εναλλακτικών γραμματοσειρών στο Aspose.Slides για Python μέσω .NET ώστε το κείμενο να παραμένει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών για μια παρουσίαση. Κάθε κανόνας εναλλακτικής γραμματοσειράς αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να την εκχωρήσετε στην ιδιότητα `font_fall_back_rules_collection` του `fonts_manager` της παρουσίασης. Ο `fonts_manager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο `Presentation` διαθέτει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι καθορισμένες εναλλακτικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εναλλακτικής**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/python-net/aspose.slides/FontFallBackRule/) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontfallbackrulescollection/). Είναι δυνατή η προσθήκη ή η αφαίρεση κανόνων από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να εκχωρηθεί στην ιδιότητα [font_fall_back_rules_collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) του κλάση [FontsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) έχει μια ιδιότητα [fonts_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/fonts_manager/) με τη δική του παρουσία της κλάσης FontsManager.

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών και να την εκχωρήσετε στον FontsManager μιας συγκεκριμένης παρουσίασης:   

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Αφού ο FontsManager αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι εναλλακτικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Απόδοση Παρουσίασης με Εναλλακτική Γραμματοσειρά](/slides/el/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εναλλακτικής γραμματοσειράς στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης κατά την εκτέλεση· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στο UI του PowerPoint.

**Εφαρμόζεται η εναλλακτική γραμματοσειρά σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλυφών χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και υπό την ευθύνη σας.

**Μπορούν να χρησιμοποιηθούν ταυτόχρονα η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εναλλακτική για ελλιπή γλυφία;**

Ναι. Αποτελούν ανεξάρτητα στάδια του ίδιου αγωγού επίλυσης γραμματοσειρών: πρώτα η μηχανή καθορίζει τη διαθεσιμότητα των γραμματοσειρών ([replacement](/slides/el/python-net/font-replacement/)/[substitution](/slides/el/python-net/font-substitution/)), έπειτα η εναλλακτική καλύπτει τα κενά για ελλιπή γλυφία σε διαθέσιμες γραμματοσειρές.