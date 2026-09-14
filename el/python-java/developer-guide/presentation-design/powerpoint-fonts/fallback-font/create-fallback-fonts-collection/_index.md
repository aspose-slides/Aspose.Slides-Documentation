---
title: Διαμόρφωση Συλλογών Εφεδρικών Γραμματοσειρών σε Python μέσω Java
linktitle: Συλλογή Εφεδρικής Γραμματοσειράς
type: docs
weight: 20
url: /el/python-java/create-fallback-fonts-collection/
keywords:
- εφεδρική γραμματοσειρά
- εφεδρικός κανόνας
- συλλογή γραμματοσειρών
- διαμόρφωση γραμματοσειράς
- ρύθμιση γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ρυθμίστε μια συλλογή εφεδρικών γραμματοσειρών στο Aspose.Slides για Python μέσω Java ώστε το κείμενο να παραμείνει συνεπές και καθαρό σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαμορφώσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς για μια παρουσίαση. Κάθε κανόνας εφεδρείας αντιπροσωπεύεται από την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/) και μπορεί να προστεθεί σε μια [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrulescollection/).

Μετά τη δημιουργία της συλλογής, μπορείτε να την αναθέσετε χρησιμοποιώντας τη μέθοδο [setFontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) του [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) της παρουσίασης. Ο [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση, και κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) έχει το δικό του [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/).

Μόλις ο [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) αρχικοποιηθεί με τη συλλογή εφεδρικών γραμματοσειρών, οι συγκεκριμένες εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

## **Εφαρμογή κανόνων εφεδρικής γραμματοσειράς**

Παραδείγματα της κλάσης [FontFallBackRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/) μπορούν να οργανωθούν σε μια [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrulescollection/). Μπορείτε να προσθέσετε ή να αφαιρέσετε κανόνες από τη συλλογή.

Αυτή η συλλογή μπορεί στη συνέχεια να ανατεθεί χρησιμοποιώντας τη μέθοδο [setFontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) της κλάσης [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/), η οποία ελέγχει τις γραμματοσειρές σε όλη την παρουσίαση.

Κάθε [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) διαθέτει τη μέθοδο [getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager) που επιστρέφει την δική του παρουσία της κλάσης [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/).

Το παρακάτω παράδειγμα δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς και να την αναθέσετε στο [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) μιας παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Μετά την αρχικοποίηση του [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) με τη συλλογή εφεδρικών γραμματοσειρών, οι εφεδρικές γραμματοσειρές εφαρμόζονται κατά την απόδοση της παρουσίασης.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα σχετικά με το πώς να [αποδώσετε μια παρουσίαση με εφεδρική γραμματοσειρά](/slides/el/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα ενσωματωθούν οι κανόνες εφεδρείας μου στο αρχείο PPTX και θα είναι ορατοί στο PowerPoint μετά την αποθήκευση;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης κατά το χρόνο εκτέλεσης· δεν σειριοποιούνται στο PPTX και δεν θα εμφανιστούν στη διεπαφή του PowerPoint.

**Εφαρμόζεται η εφεδρεία σε κείμενο μέσα σε SmartArt, WordArt, διαγράμματα και πίνακες;**

Ναι. Ο ίδιος μηχανισμός αντικατάστασης γλύφων χρησιμοποιείται για οποιοδήποτε κείμενο σε αυτά τα αντικείμενα.

**Διανέμει η Aspose κάποια γραμματοσειρά μαζί με τη βιβλιοθήκη;**

Όχι. Προσθέτετε και χρησιμοποιείτε τις γραμματοσειρές από τη δική σας πλευρά και υπό τη δική σας ευθύνη.

**Μπορούν η αντικατάσταση/υποκατάσταση για ελλείπουσες γραμματοσειρές και η εφεδρεία για ελλείπουσες γλύφους να χρησιμοποιηθούν μαζί;**

Ναι. Είναι ανεξάρτητα στάδια της ίδιας διαδικασίας επίλυσης γραμματοσειράς: πρώτα η μηχανή επιλύει τη διαθεσιμότητα των γραμματοσειρών ([αντικατάσταση](/slides/el/python-java/font-replacement/)/[υποκατάσταση](/slides/el/python-java/font-substitution/)), στη συνέχεια η εφεδρεία συμπληρώνει τα κενά για ελλείπουσες γλύφους στις διαθέσιμες γραμματοσειρές.