---
title: Διαμόρφωση Συλλογών Εφεδρικών Γραμματοσειρών σε Java
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/java/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- κανόνας εφεδρείας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- εγκατάσταση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε μια συλλογή εφεδρικών γραμματοσειρών στο Aspose.Slides για Java ώστε το κείμενο να παραμένει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρείας αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να την αντιστοιχίσετε στην ιδιότητα `FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε στιγμιότυπο `Presentation` έχει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή Κανόνων Εφεδρείας**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRulesCollection), η οποία υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFontFallBackRulesCollection). Είναι δυνατόν να προσθέτετε ή να αφαιρείτε κανόνες από τη συλλογή.

Στη συνέχεια αυτή η συλλογή μπορεί να αντιστοιχιστεί στη μέθοδο [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) διαθέτει τη μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getFontsManager--) με τη δική του παρουσία της κλάσης [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager).

Ακολουθεί ένα παράδειγμα δημιουργίας συλλογής κανόνων εφεδρικών γραμματοσειρών και ανάθεσης της στο [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getFontsManager--) μιας συγκεκριμένης παρουσίασης:  

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

Αφού ο FontsManager αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με το πώς να [Αποδώσετε Παρουσίαση με Εφεδρική Γραμματοσειρά](/slides/el/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα ενσωματώνονται οι κανόνες εφεδρείας στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης κατά την εκτέλεση· δεν σειριοποιούνται στο PPTX και δεν εμφανίζονται στη διεπαφή του PowerPoint.

**Εφαρμόζεται η εφεδρεία σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλύφων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Προσθέτετε και χρησιμοποιείτε τις γραμματοσειρές δικά σας, υπό τη δική σας ευθύνη.

**Μπορούν να χρησιμοποιηθούν μαζί η αντικατάσταση/υποκατάσταση ελλείπουσων γραμματοσειρών και η εφεδρεία για ελλείπουσες γλύφους;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας ροής επίλυσης γραμματοσειρών: πρώτα η μηχανή επιλύει τη διαθεσιμότητα γραμματοσειράς ([replacement](/slides/el/java/font-replacement/)/[substitution](/slides/el/java/font-substitution/)), στη συνέχεια η εφεδρεία καλύπτει τα κενά για ελλείπουσες γλύφους στις διαθέσιμες γραμματοσειρές.