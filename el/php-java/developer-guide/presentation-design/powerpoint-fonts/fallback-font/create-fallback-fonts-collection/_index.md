---
title: Διαμόρφωση Συλλογών Εναλλακτικών Γραμματοσειρών σε PHP
linktitle: Συλλογή Εναλλακτικής Γραμματοσειράς
type: docs
weight: 20
url: /el/php-java/create-fallback-fonts-collection/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε μια συλλογή εναλλακτικών γραμματοσειρών στο Aspose.Slides για PHP μέσω Java ώστε το κείμενο να παραμένει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών για μια παρουσίαση. Κάθε κανόνας εναλλακτικής γραμματοσειράς αντιπροσωπεύεται από την κλάση `FontFallBackRule` και μπορεί να προστεθεί σε μια `FontFallBackRulesCollection`.

Μετά τη δημιουργία της συλλογής, μπορείτε να την αναθέσετε χρησιμοποιώντας τη μέθοδο `setFontFallBackRulesCollection` του `FontsManager` της παρουσίασης. Ο `FontsManager` ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε στιγμιότυπο `Presentation` διαθέτει τον δικό του `FontsManager`.

Μόλις ο `FontsManager` αρχικοποιηθεί με τη συλλογή εναλλακτικών γραμματοσειρών, οι καθορισμένες εναλλακτικές γραμματοσειρές εφαρμόζονται κατά τη διαδικασία απόδοσης της παρουσίασης.

## **Εφαρμογή Κανόνων Εναλλακτικών Γραμματοσειρών**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontFallBackRule) μπορούν να οργανωθούν σε [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontFallBackRulesCollection). Είναι δυνατόν να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Στη συνέχεια αυτή η συλλογή μπορεί να ανατεθεί στη μέθοδο [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager). Ο FontsManager ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) διαθέτει τη μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#getFontsManager) με τη δική του εμφάνιση της κλάσης [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/FontsManager).

Ακολουθεί ένα παράδειγμα για το πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών και να την αναθέσετε στον [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#getFontsManager) μιας συγκεκριμένης παρουσίασης:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Μετά την αρχικοποίηση του FontsManager με τη συλλογή εναλλακτικών γραμματοσειρών, οι εναλλακτικές γραμματοσειρές εφαρμόζονται κατά τη διαδικασία απόδοσης της παρουσίασης.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Render Presentation with Fallback Font](/slides/el/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εναλλακτικών γραμματοσειρών στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εναλλακτικών γραμματοσειρών είναι ρυθμίσεις απόδοσης σε χρόνο εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

**Εφαρμόζεται η εναλλακτική γραμματοσειρά σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός υποκατάστασης γλυφών χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά με τη βιβλιοθήκη;**

Όχι. Προσθέτετε και χρησιμοποιείτε γραμματοσειρές από τη δική σας πλευρά και υπό τη δική σας ευθύνη.

**Μπορούν η αντικατάσταση/υποκατάσταση για απουσιάζουσες γραμματοσειρές και η εναλλακτική για απουσιάζοντα γλυφά να χρησιμοποιηθούν μαζί;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειρών: πρώτα η μηχανή ελέγχει τη διαθεσιμότητα των γραμματοσειρών ([replacement](/slides/el/php-java/font-replacement/)/[substitution](/slides/el/php-java/font-substitution/)), στη συνέχεια η εναλλακτική γεμίζει τα κενά για τα απουσιάζοντα γλυφά σε διαθέσιμες γραμματοσειρές.