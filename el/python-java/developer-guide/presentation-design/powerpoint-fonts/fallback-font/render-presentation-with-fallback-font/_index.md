---
title: Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές σε Python μέσω Java
linktitle: Απόδοση παρουσιάσεων
type: docs
weight: 30
url: /el/python-java/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Python μέσω Java – διατηρήστε το κείμενο συνεπές μεταξύ PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς ανατεθεί στο [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/) της παρουσίασης, οι κανόνες εφαρμόζονται κατά τη διάρκεια εργασιών όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μικρογραφίας διαφάνειας και την αποθήκευση της ως εικόνα JPEG.

## **Απόδοση Διαφάνειας με Χρήση Κανόνων Εφεδρικής Γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. [Δημιουργία συλλογής κανόνων εφεδρικής γραμματοσειράς](/slides/el/python-java/create-fallback-fonts-collection/).
2. [Αφαιρέστε](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/#remove) μια εφεδρική γραμματοσειρά από έναν κανόνα και [προσθέστε εφεδρικές γραμματοσειρές](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) σε έναν άλλο κανόνα.
3. Αναθέστε τη συλλογή κανόνων χρησιμοποιώντας τη [setFontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) στον διαχειριστή γραμματοσειρών που επιστρέφεται από τη [getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager).
4. Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να αποθηκεύσετε την παρουσίαση στην ίδια μορφή ή σε άλλη μορφή. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς ανατεθεί στο [FontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/), αυτοί οι κανόνες εφαρμόζονται κατά τις εργασίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Δημιουργία νέας συλλογής κανόνων.
fallback_rules = FontFallBackRulesCollection()

# Δημιουργία πολλαπλών κανόνων.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους κανόνες.
    fallback_rule.remove("Tahoma")

    # Ενημέρωση των κανόνων για το καθορισμένο εύρος.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Αφαίρεση υπάρχοντος κανόνα, διατηρώντας τουλάχιστον έναν κανόνα για την απόδοση.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Ανάθεση της προετοιμασμένης συλλογής κανόνων.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Απόδοση μικρογραφίας χρησιμοποιώντας τη ρυθμισμένη συλλογή κανόνων.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Σημείωση" %}}
Διαβάστε περισσότερα για το πώς να [μετατρέψετε PPT και PPTX σε JPG σε Python μέσω Java](/slides/el/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}