---
title: Διαμόρφωση Συλλογών Εφεδρικής Γραμματοσειράς σε Android
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/androidjava/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- κανόνας εφεδρείας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ρύθμιση μιας συλλογής εφεδρικών γραμματοσειρών στο Aspose.Slides για Android μέσω Java για να διατηρηθεί το κείμενο συνεπές και καθαρό στις παρουσιάσεις PowerPoint και OpenDocument."
---
## **Overview**

Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρείας αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Μετά τη δημιουργία της συλλογής, μπορείτε να την αναθέσετε στην ιδιότητα `FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο `Presentation` έχει τον δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Apply Fallback Rules**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRulesCollection), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια αυτή η συλλογή μπορεί να ανατεθεί στη μέθοδο [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager). Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) διαθέτει μια μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getFontsManager--) με τη δική της παρουσία της κλάσης [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager).

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών και να την αναθέσετε στο [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getFontsManager--) μιας συγκεκριμένης παρουσίασης:

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Αφού ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Render Presentation with Fallback Font](/slides/el/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Θα ενσωματωθούν οι κανόνες εφεδρείας μου στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης σε χρόνο εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

**Ισχύει η εφεδρεία για κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλύφων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και υπό τη δική σας ευθύνη.

**Μπορούν η αντικατάσταση/υποκατάσταση ελλιπών γραμματοσειρών και η εφεδρεία για ελλιπή γλύφα να χρησιμοποιηθούν μαζί;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειρών: πρώτα η μηχανή ελέγχει τη διαθεσιμότητα των γραμματοσειρών ([αντικατάσταση](/slides/el/androidjava/font-replacement/)/[υποκατάσταση](/slides/el/androidjava/font-substitution/)), έπειτα η εφεδρεία γεμίζει τα κενά για ελλιπή γλύφα στα διαθέσιμα γραμματοσειρές.