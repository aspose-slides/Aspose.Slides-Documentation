---
title: Διαχείριση θεμάτων παρουσίασης σε Python μέσω Java
linktitle: Θέμα παρουσίασης
type: docs
weight: 10
url: /el/python-java/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Επιπρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στύλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Python μέσω Java για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσεων, γραμμών και εφέ. Τα αντικείμενα που είναι συνειδητά του θέματος αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasterTheme). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterthememanager/#getOverrideTheme), ενώ μια διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομικό της θέμα μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με τα θέματα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την επίλυση κληρονομικότητας και παρακάμψεων.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme] εκθέτει το χρωματικό σχήμα, το σχήμα γραμματοσειράς και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/mastertheme/#getFontScheme) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/mastertheme/#getFormatScheme). Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των εγγραφών στυλ μπορεί να διαφέρει.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσης, γραμμής και εφέ είναι αποθηκευμένες στο θέμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Εάν ένα αρχείο χρησιμοποιεί πολλαπλά master, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε το master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που εμφανίζεται παρακάτω σε αυτό το άρθρο όταν μπορεί να υπάρχουν παράκαμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Οι γεμιστικές, γραμμικές και κειμενικές εντολές που είναι συνειδητές του θέματος μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [ColorScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος αξιολογούνται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

Το παρακάτω παράδειγμα end‑to‑end δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, τη ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το εμφανιζόμενο χρώμα του γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μελλοντικές αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Επιπρόσθετη Παλέτα**

Το PowerPoint παράγει ανοιχτότερες και σκούροτερες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/python-java/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ανοιχτότερα/σκούροτερα χρώματα που δημιουργούνται από την επιπρόσθετη παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Ανοιχτότερες και σκούροτερες παραλλαγές που προέρχονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα θα επανυπολογιστούν από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [ColorScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειράς θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για κεφαλίδες και ένα δευτερεύον σύνολο για το κύριο κείμενο. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontscheme/#getMajor) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontscheme/#getMinor) εκθέτουν αυτά τα σύνολα.

Οι ταυτοποιητές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn‑lt` - Body Font Latin (Minor Latin Font)
* `+mj‑lt` - Heading Font Latin (Major Latin Font)
* `+mn‑ea` - Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` - Heading Font East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια κεφαλίδα που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή κυρίως κειμένου που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές του θέματος και αποθηκεύει το αποτέλεσμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η κεφαλίδα ακολουθεί τη κύρια γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα μεταβεί αυτόματα όταν το σχήμα γραμματοσειρών του θέματος αλλάξει.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλική, αραβική, ιαπωνική, γεωργιανή και θανα. Για να επιθεωρήσετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίες, δείτε [Script‑Specific Theme Fonts](/slides/el/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Συμβουλή" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/python-java/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα που σχετίζονται με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Master**

Χρησιμοποιήστε [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να αλλάξετε το στυλ κάθε διαφάνειας που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasters), η οποία εκπροσωπείται από το [MasterSlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις παρακάτω ενέργειες:

1. Δημιουργεί μια νέα διαφάνεια master βασισμένη στον επιλεγμένο master.
2. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια master.
3. Αντιστοιχίζει τη νέα διαφάνεια master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.
4. Επιστρέφει τη νεοδημιουργημένη [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχονται από τους χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επαναανατίθενται. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, οι γεμισμοί, οι γραμμές, τα φόντα και τα εφέ που είναι συνειδητά του θέματος αξιολογούνται με βάση το εξωτερικό θέμα. Τα άμεσα κατειλημμένα χρώματα, γραμματοσειρές, γεμισμοί και άλλες ρητές μορφοποιήσεις ενδέχεται να παραμείνουν αμετάβλητα. Παρακάμψεις σε επίπεδο διάταξης και διαφάνειας μπορούν επίσης να έχουν προτεραιότητα έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφερθεί σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τις μέσω [custom font sources](/slides/el/python-java/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/python-java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται μια διαδρομή αρχείου `.thmx` και δεν απαιτεί τη χειροκίνητη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή διάταξης.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω του [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getLayoutSlide) και του [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getMasterSlide). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί ένα ακόμη master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `first_group_master`, ενώ η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `second_group_master`. Διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν αλλάζουν στυλ.

### **Διατήρηση Πηγαίου Θέματος κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον master προέλευσης στην παρουσίαση‑στόχο με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone), έπειτα κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) και τον κλωνοποιημένο master. Έτσι μεταφέρονται μαζί ο master, οι διατάξεις και το σχετικό θέμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η διαφάνεια‑πηγή πρέπει να φαίνεται η ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν μη σχετικό master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντα και εφέ που καθοδηγούνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Εάν η διαφάνεια‑στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξη, αρχικοποιήστε μια παράκαμψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παράκαμψη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Αυτή η ενέργεια αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/overridetheme/#clear).

### **Εφαρμογή Παράκαμψης Θέματος σε Διάταξη**

Μια παράκαμψη σε επίπεδο διάταξης εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παράκαμψη διάταξης όταν μία οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παράκαμψη σε επίπεδο διαφάνειας καθιστούν πιο δύσκολη την πρόβλεψη παγκόσμιων αλλαγών θεμάτων.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γέμισμα φόντου του θέματος αποθηκεύονται μέσω του [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στο UI του από ό,τι το πλήθος των ορισμών γεμίσματος που αποθηκεύονται στην συλλογή, επειδή το UI μπορεί να συνδυάσει γέμισμα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, εξετάστε τη αποθηκευμένη συλλογή και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/#getStyleIndex). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές σε στυλ φόντου θέματος. Αυτό διαφέρει από την άμεση ευρεία στην συλλογή, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος φόντου.

Το παρακάτω παράδειγμα αναφέρει το διαθέσιμο πλήθος γεμισμάτων φόντου, αναθέτει μια αναφορά θεματικού φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το εμφανιζόμενο αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου σε επίπεδο διάταξης ή διαφάνειας. Εάν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην επηρεάσει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/#getEffective) όταν χρειάζεται να γνωρίζετε το τελικό φόντο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Προειδοποίηση" %}}

Μην αντιμετωπίζετε τον δείκτη στυλ ως μηδενικό δείκτη συλλογής. Επίσης, αποφύγετε την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="success" title="Συμβουλή" %}}

Για άμεση μορφοποίηση φόντου και κληρονομικότητα φόντου, δείτε [Presentation Background](/slides/el/python-java/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφότυπου θέματος περιέχει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/el/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/el/python-java/aspose.slides/formatscheme/#getLineStyles) και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/python-java/aspose.slides/formatscheme/#getEffectStyles). Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε ήπια, μετρίως και έντονα μορφοποίηση, αλλά ο κώδικας θα πρέπει να εξετάζει κάθε συλλογή αντί να υποθέτει σταθερό πλήθος.

![Ήπια, μετρίως και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν αποκτάτε πρόσβαση σε αυτές τις συλλογές σε Python μέσω Java, ο δείκτης συλλογής είναι μηδενικός: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [ShapeStyle](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει την ύπαρξη των απαιτούμενων στοιχείων στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής του θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος του θέματος γίνεται στερεό δάσιος πράσινο και το τρίτο στυλ εφέ κερδίζει εξωτερική σκιά με απόσταση 10 points. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμη από το ποια στυλ θέσης αναφέρεται κάθε σχήμα και εάν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή των ρυθμίσεων γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Καθορισμός εάν ένα Αποτελεσματικό Στερεό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί άμεσα σε ένα αντικείμενο ή να κληρονομηθεί από παράγραφο, διάταξη, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε το [FillFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getEffective) για να μετατρέψετε αυτήν την ιεραρχία σε αμετάβλητα αποτελεσματικά δεδομένα γεμίσματος. Πρώτα ελέγξτε το `getFillType` στο αντικείμενο αποτελεσματικών δεδομένων. Μόνο όταν είναι `FillType.Solid` πρέπει να διαβάσετε τις ιδιότητες στερεού γεμίσματος.

Για στερεό γέμισμα, το `getSolidFillColor` επιστρέφει την τελική τιμή RGB μετά την κληρονομικότητα, την αναζήτηση θέματος και την εφαρμογή μετασχηματισμών χρώματος. Το `getSolidFillSchemeColor` επιστρέφει το αντίστοιχο λογικό slot [SchemeColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/schemecolor/), όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε χρώμα σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσα χρώματα RGB, αυτή η τιμή προσδιορίζει ένα άμεσο γέμισμα RGB.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/colorformat/#getSchemeColor) για την ταξινόμηση ενός γεμίσματος. Για παράδειγμα, μια φράση κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική της τιμή είναι `NotDefined`, ενώ το αποτελεσματικό της γέμισμα κληρονομεί ένα χρώμα θέματος και λύνει σε `Text1` ή `Accent6`. Αντιθέτως, το `getSolidFillSchemeColor` σας λέει ποιο λογικό slot θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν σας λέει από ποιο επίπεδο (αντικείμενο, παράγραφος, διάταξη, master ή άλλο) προέρχεται.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τόσο τα γεμίσματα σχημάτων όσο και τα γεμίσματα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και το σχετικό χρώμα σχήματος, και σημαίνει τα στερεά γεμίσματα που δεν θα ακολουθήσουν τις αλλαγές χρώματος θέματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Το κλαδί `NotDefined` παρέχει μια λίστα ελέγχου στερεών γεμισμάτων που δεν θα αντιδράσουν σε αλλαγές στα slots χρωμάτων θέματος. Ελέγξτε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθεί μια νέα παλέτα εταιρικής ταυτότητας. Η αναφερόμενη τιμή RGB εξακολουθεί να δείχνει την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί εάν αυτή η εμφάνιση είναι συνδεδεμένη με το θέμα.

Τα αποτελεσματικά αντικείμενα μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος της παρουσίασης, μιας παράκαμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `getEffective` και διαβάστε ένα νέο αντικείμενο αποτελεσματικού γεμίσματος πριν συγκρίνετε ή αναφέρετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι μια διαφάνεια ή σχήμα χρησιμοποιεί πραγματικά μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Για φόντο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/#getEffective) και για γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getEffective).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικές αποδόσεις, επικυρώσεις και συγκρίσεις. Εάν εξετάζετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasterTheme), risk V... (the text continues but the original did not have more after this point). 

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η μέθοδος [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) επανααντιστοιχίζει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παράκαμψής της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρω ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον master προέλευσης στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone) και [SlideCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone). Αυτό διατηρεί μαζί τον master, τις διατάξεις και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/#getEffective) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getEffective). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.