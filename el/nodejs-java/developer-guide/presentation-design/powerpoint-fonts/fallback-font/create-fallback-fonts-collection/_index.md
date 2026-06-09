---
title: "Διαμόρφωση Συλλογών Εφεδρικών Γραμματοσειρών σε JavaScript"
linktitle: "Συλλογή Εφεδρικής Γραμματοσειράς"
type: docs
weight: 20
url: /el/nodejs-java/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- εφεδρικός κανόνας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εφεδρικών γραμματοσειρών σε JavaScript με το Aspose.Slides για Node.js ώστε το κείμενο να παραμένει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρικής γραμματοσειράς αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να την αντιστοιχίσετε χρησιμοποιώντας τη μέθοδο `setFontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση και κάθε αντικείμενο `Presentation` έχει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εφεδρικής γραμματοσειράς**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε μια [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRulesCollection), η οποία υλοποιεί την κλάση [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRulesCollection). Είναι δυνατόν να προστεθούν ή να αφαιρεθούν κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να αντιστοιχιστεί στη μέθοδο [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) διαθέτει τη μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getFontsManager--) με τη δική του παρουσία της κλάσης [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager).

Ακολουθούν παραδείγματα για το πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών και να την εκχωρήσετε στον [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getFontsManager--) μιας συγκεκριμένης παρουσίασης:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αφού ο FontsManager αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Render Presentation with Fallback Font](/slides/el/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εφεδρικής γραμματοσειράς στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης κατά την εκτέλεση· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

**Εφαρμόζεται η εφεδρεία σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλύφων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει το Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Εσείς προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και με δική σας ευθύνη.

**Μπορούν η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εφεδρεία για ελλιπείς γλύφους να χρησιμοποιηθούν μαζί;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειράς: πρώτα η μηχανή επιλύει τη διαθεσιμότητα γραμματοσειρών ([replacement](/slides/el/nodejs-java/font-replacement/)/[substitution](/slides/el/nodejs-java/font-substitution/)), έπειτα η εφεδρεία καλύπτει τα κενά για ελλιπείς γλύφους σε διαθέσιμες γραμματοσειρές.