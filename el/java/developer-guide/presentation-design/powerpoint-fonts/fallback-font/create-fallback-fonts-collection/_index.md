---
title: Διαμόρφωση Συλλογών Εφεδρικών Γραμματοσειρών σε Java
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/java/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- εφεδρικός κανόνας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εφεδρικών γραμματοσειρών στο Aspose.Slides για Java, ώστε το κείμενο να παραμένει συνεπές και καθαρό στις παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides επιτρέπει τη διαμόρφωση μιας συλλογής κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρείας αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`, η οποία υλοποιεί τη διεπαφή `IFontFallBackRulesCollection`.

Αφού δημιουργήσετε τη συλλογή, μπορείτε να τη εκχωρήσετε στην ιδιότητα `FontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε παράδειγμα `Presentation` διαθέτει το δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εφεδρικής γραμματοσειράς, οι καθορισμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εφεδρείας**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRulesCollection), που υλοποιεί τη διεπαφή [IFontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFontFallBackRulesCollection). Είναι δυνατόν να προστεθούν ή να αφαιρεθούν κανόνες από τη συλλογή.

Στη συνέχεια, αυτή η συλλογή μπορεί να εκχωρηθεί στη μέθοδο [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) διαθέτει μια μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getFontsManager--) με τη δική της περίπτωση της κλάσης [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager).

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών και να τη εκχωρήσετε στον [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getFontsManager--) μιας συγκεκριμένης παρουσίασης:

```java
import com.aspose.slides.*;

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

Μετά την αρχικοποίηση του FontsManager με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="info" %}} 
Διαβάστε περισσότερα για το πώς να [Απόδοση παρουσίασης με εφεδρική γραμματοσειρά](/slides/el/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Θα ενσωματωθούν οι κανόνες εφεδρείας στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν εμφανίζονται στη διεπαφή του PowerPoint.

### Εφαρμόζεται η εφεδρεία σε κείμενο εντός SmartArt, WordArt, διαγραμμάτων και πινάκων;

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλυφών χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

### Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;

Όχι. Εσείς προσθέτετε και χρησιμοποιείτε τις γραμματοσειρές από τη δική σας πλευρά και υπό τη δική σας ευθύνη.

### Μπορούν η αντικατάσταση/υποκατάσταση για ελλιπείς γραμματοσειρές και η εφεδρεία για ελλιπή γλυφία να χρησιμοποιηθούν μαζί;

Ναι. Είναι ανεξάρτητα στάδια της ίδιας αλυσίδας επίλυσης γραμματοσειρών: πρώτα η μηχανή επιλύει τη διαθεσιμότητα των γραμματοσειρών ([replacement](/slides/el/java/font-replacement/)/[substitution](/slides/el/java/font-substitution/)), έπειτα η εφεδρεία γεμίζει τα κενά για ελλιπή γλυφία στις διαθέσιμες γραμματοσειρές.