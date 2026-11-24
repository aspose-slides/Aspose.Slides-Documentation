---
title: Διαχείριση Θεμάτων Παρουσίασης σε Python μέσω Java
linktitle: Θέμα Παρουσίασης
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
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Python μέσω Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή branding."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ παρασκηνίου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που λαμβάνουν υπόψη το θέμα αναφέρονται σε αυτούς τους κοινόχρηστους ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα επιπέδου παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), ενώ ένα layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη layout και παράκαμψη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ παρασκηνίου και εφέ](theme-constituents.png)

Τα τμήματα παρακάτω δείχνουν τις πιο κοινές ροές εργασίας για θέματα: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ παρασκηνίου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) αποκαλύπτει το χρωματοσχέδιο, το σχήμα γραμματοσειρών και το σχήμα μορφής του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). Η επιθεώρηση αυτών των συλλογών πριν την τροποποίησή τους είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των εγγραφών στυλ μπορεί να διαφέρει.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ παρασκηνίου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται αργότερα σε αυτό το άρθρο όταν υπάρχουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που λαμβάνουν υπόψη το θέμα μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/). Όταν αλλάζετε τη σχετική εγγραφή στο [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που ακόμα αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μελλοντικές αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Επιπλέον Παλέτα**

Το PowerPoint παράγει ελαφρότερες και σκοτεινότερες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides αποκαλύπτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ελαφρύτερα/σκοτεινότερα χρώματα που δημιουργούνται από το επιπλέον παλέτα](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.

**2** – Ελαφρύτερες και σκοτεινότερες παραλλαγές που δημιουργούνται από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα υπολογίζονται εκ νέου από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) αποκαλύπτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι στατική:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για τίτλους και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) και [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) αποκαλύπτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θέματος συμβατές με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` – Κυρίως Γραμματοσειρά Σώματος Λάτιν (Minor Latin Font)
* `+mj-lt` – Κυρίως Γραμματοσειρά Τίτλου Λάτιν (Major Latin Font)
* `+mn-ea` – Γραμματοσειρά Σώματος Ανατολικής Ασίας (Minor East Asian Font)
* `+mj-ea` – Γραμματοσειρά Τίτλου Ανατολικής Ασίας (Major East Asian Font)
* `+mn-cs` – Γραμματοσειρά Σώματος Πολύπλοκου Σεναρίου (Minor Complex Script Font)
* `+mj-cs` – Γραμματοσειρά Τίτλου Πολύπλοκου Σεναρίου (Major Complex Script Font)

Το παρακάτω παράδειγμα δημιουργεί έναν τίτλο που χρησιμοποιεί τη μεγαλύτερη γραμματοσειρά Λάτιν θέματος και μία γραμμή σώματος που χρησιμοποιεί τη μικρότερη γραμματοσειρά Λάτιν θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Ο τίτλος ακολουθεί τη μεγαλύτερη γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη μικρότερη γραμματοσειρά. Κείμενο που έχει ρητά ορισμένο όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό και Θάνα. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Συμβουλή" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/python-java/powerpoint-fonts/).

{{% /alert %}}

### **Επίλυση Αναφορών Γραμματοσειράς Θέματος**

Κατά την επιθεώρηση κειμένου, το [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) μπορεί να επιστρέψει μια αναφορά θέματος όπως `+mn-lt` αντί για όνομα οικογένειας γραμματοσειράς. Καλέστε το [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) με τα κατάλληλα αποτελεσματικά δεδομένα θέματος για να επιλύσετε αυτήν την αναφορά. Τα πρόθεματα `+mj` και `+mn` επιλέγουν τα μεγάλα και μικρά σύνολα γραμματοσειρών· τα κατάληξη `-lt`, `-ea` και `-cs` επιλέγουν τις αντίστοιχες γραμματοσειρές Λάτιν, Ανατολική Ασία και Πολύπλοκο Σενάριο.

Αποκτήστε το αποτελεσματικό θέμα μέσω του [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) στον διαχειριστή θέματος του αντικειμένου του οποίου το θέμα εφαρμόζεται στο εξεταζόμενο κείμενο. Για κανονικό κείμενο σε διαφάνεια, χρησιμοποιήστε το διαχειριστή θέματος της διαφάνειας ώστε το πλαίσιο να περιλαμβάνει το κληρονομημένο θέμα της διαφάνειας και τις τοπικές παρακάμψεις. Όταν επιθεωρείτε ένα layout ή master, χρησιμοποιήστε το δικό του αποτελεσματικό θέμα. Μην υποθέτετε ότι το θέμα του πρώτου master ισχύει για κάθε διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα κειμένου που αναφέρεται ρητά στη μικρή γραμματοσειρά Λάτιν. Αρχικοποιεί το σχήμα γραμματοσειρών διαφάνειας μέσω του [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) και ορίζει τις μεγάλες και μικρές Λάτιν οικογένειες σε `Arial` και `Calibri`, καθιστώντας το αποτέλεσμα αναπαραγώγιμο χωρίς αρχείο εισόδου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

Η έξοδος είναι `+mn-lt -> Calibri` ακολουθούμενη από `Verdana -> Verdana`. Η αποθηκευμένη αναφορά παραμένει αμετάβλητη, ενώ ένα ρητό όνομα οικογένειας επιστρέφεται όπως είναι. Αν το τμήμα χρησιμοποιούσε `+mj-lt`, θα επιλύεται σε `Arial` σε αυτό το θέμα.

Η επίλυση μιας αναφοράς θέματος προσδιορίζει την οικογένεια γραμματοσειράς που καθορίζεται από το θέμα. Δεν ελέγχει τη διαθεσιμότητα γραμματοσειράς ούτε προσδιορίζει το αρχείο γραμματοσειράς που τελικά χρησιμοποιείται μετά την αντικατάσταση ή την εφεδρεία γλυφών κατά την απόδοση. Δείτε τη [Font Selection Sequence](/slides/el/python-java/font-selection-sequence/) και την [Font Substitution](/slides/el/python-java/font-substitution/) για αυτά τα ξεχωριστά βήματα.

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετιζόμενα με θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Master**

Χρησιμοποιήστε το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), που αντιπροσωπεύεται από το [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες ενέργειες:

1. Δημιουργεί μια νέα master διαφάνεια βασισμένη στον επιλεγμένο master.
1. Εφαρμόζει το εξωτερικό θέμα στη νέα master.
1. Εκχωρεί τη νέα master σε όλες τις διαφάνειες που παλιότερα εξαρτώνταν από τον επιλεγμένο master.
1. Επιστρέφει το νέο [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/).

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

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχουν οι χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων, και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα έχει εφαρμοστεί επιτυχώς.

Μόνον οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επανεκχωρούνται. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τα υπάρχοντα masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα παρασκήνια και τα εφέ που λαμβάνουν υπόψη το θέμα επιλύονται με το εξωτερικό θέμα. Τα άμεσα εκχωρημένα χρώματα, γραμματοσειρές, γεμίσματα και άλλες ρητές μορφοποιήσεις μπορεί να παραμείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο layout και διαφάνειας μπορούν επίσης να προτεραιότητά τους πάνω στις κληρονομημένες τιμές από τον νέο master.

Το θέμα μπορεί να παραπέμπει σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τες μέσω [custom font sources](/slides/el/python-java/custom-font/), ή διαμορφώστε την [font substitution](/slides/el/python-java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί τη δημιουργία χειροκίνητων παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω των [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) και [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί ένα νέο master στην παρουσίαση.

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

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `first_group_master`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `second_group_master`. Διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Θέματος Πηγής Κατά τη Μεταφορά Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον master πηγής στην παρουσίαση-στόχο με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), στη συνέχεια κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) και τον κλωνοποιημένο master. Αυτό μεταφέρει τον master, τα layout του και το σχετιζόμενο θέμα μαζί.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η διαφάνεια πηγής πρέπει να φαίνεται το ίδιο στην προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν ασύνδετο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, παρασκήνια και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και layout της, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το θέμα πηγής. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) αντιγράφουν τα τρία κύρια συστατικά θέματος στην παρακάμψη.

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

Αυτή η αλλαγή επηρεάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **Εφαρμογή Παρακάμψης Θέματος σε Layout**

Μια παρακάμψη επιπέδου layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνο το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα master ή παρουσίασης όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετική μορφοποίηση, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις σε επίπεδο διαφάνειας καθιστούν τις μελλοντικές παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

<!-- visual-explanation:presentation-theme:start -->
[![Ένα master θέμα τροφοδοτεί δύο layout· μια παρακάμψη layout επηρεάζει τις διαφάνειές του εκτός από μια διαφάνεια με πιο τοπική παρακάμψη.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Μια παρακάμψη layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνο το layout εκτός εάν μια διαφάνεια παρέχει τη δική της παρακάμψη. Οι τιμές βάσει θέματος ακολουθούν το επιλυμένο σχήμα τους· αντικείμενα με ρητή μορφοποίηση μπορούν να διατηρήσουν την τοπική τους εμφάνιση. Διατηρήστε τις παρακάμψεις όσο πιο στενές είναι στην πρόθεση σχεδίου εξαίρεσης.*
<!-- visual-explanation:presentation-theme:end -->

## **Ενημέρωση Στυλ Παρασκηνίου Θέματος**

Τα γεμίσματα παρασκηνίου του θέματος αποθηκεύονται στο [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές παρασκηνίου στη διεπαφή του από τον αριθμό των γεμίσματος που αποθηκεύονται φυσικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ παρασκηνίου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ παρασκηνίου, επιθεωρήστε τη συλλογή που αποθηκεύτηκε και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex). Ένδειξη στυλ `0` σημαίνει ότι δεν υπάρχει γεμιστό θέμα· θετικές τιμές είναι αναφορές στυλ παρασκηνίου θέματος. Αυτό διαφέρει από την άμεση αρίθμηση της συλλογής, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος παρασκηνίου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων παρασκηνίου, εκχωρεί μια αναφορά θεματικού παρασκηνίου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την εγγραφή θέματος στην οποία αναφέρεται ο master και από τυχόν παρακάμψεις παρασκηνίου στο layout ή στο επίπεδο διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της παρασκήνιο, η αλλαγή μόνο του παρασκηνίου του master ενδέχεται να μην αλλάξει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) όταν χρειάζεται να γνωρίζετε το τελικό παρασκήνιο μετά την κληρονομική εφαρμογή.

{{% alert color="warning" title="Προειδοποίηση" %}}

Μην αντιμετωπίζετε την ένδειξη στυλ ως δείκτη μηδενικής βάσης της συλλογής. Αποφύγετε επίσης την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="success" title="Συμβουλή" %}}

Για άμεση μορφοποίηση παρασκηνίου και κληρονομικότητα παρασκηνίου, δείτε το [Presentation Background](/slides/el/python-java/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφής θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες εγγραφές στυλ που αντιστοιχούν οπτικά σε ήπια, μετρίως και έντονη μορφοποίηση, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπια, μετρή και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσεγγίζετε αυτές τις συλλογές σε Python μέσω Java, ο δείκτης της συλλογής είναι μηδενικής βάσης: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, που εκτίθεται μέσω του [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει ότι υπάρχουν οι απαιτούμενες εγγραφές στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος γίνεται πυκνό δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 points. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμα από το ποιοι δείκτες στυλ αναφέρεται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Επιλογή Στυλ Γεμίσματος και Γραμμής Θέματος για Σχήμα**

Ένα σχήμα μπορεί να επιλέξει ανεξάρτητα το γέμισμα και το περίγραμμα του μέσω των [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) και [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). Για κάθε μέθοδο, ο δείκτης `1` επιλέγει την πρώτη εγγραφή στην αντίστοιχη συλλογή θέματος (`get_Item(0)`), και ο δείκτης `2` επιλέγει τη δεύτερη (`get_Item(1)`).

Το παρακάτω παράδειγμα δημιουργεί δύο στυλ γεμίσματος (χρυσό και γαλάζιο) και δύο στυλ γραμμής (σκούρο μπλε στα 6 pt και σκούρο κόκκινο στα 12 pt) στο προεπιλεγμένο θέμα μιας νέας παρουσίασης. Αποθηκεύει τη διαφάνεια σε τρία στάδια ώστε να μπορείτε να συγκρίνετε τα αποτελέσματα στο PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Αρχικά στυλ | Αλλαγή δεξιού περιγράμματος | Επεξεργασία πρώτου γεμίσματος θέματος |
|:---:|:---:|:---:|
| ![Χρυσά και γαλάζια ορθογώνια με αντίστοιχα λεπτά σκούρο μπλε περιγράμματα](theme-style-initial.png) | ![Το γαλάζιο ορθογώνιο τώρα έχει παχύ σκούρο κόκκινο περίγραμμα](theme-style-line-changed.png) | ![Το αριστερό ορθογώνιο γίνεται πράσινο και και τα δύο περιγράμματα παραμένουν αμετάβλητα](theme-style-fill-changed.png) |

Η επιλογή διαφορετικού στυλ γραμμής αλλάζει μόνο το περίγραμμα του δεξιού ορθογωνίου. Η επεξεργασία του πρώτου γεμίσματος θέματος ενημερώνει κάθε σχήμα που το χρησιμοποιεί. Εδώ, μόνο το αριστερό ορθογώνιο γίνεται πράσινο.

Σε υπάρχον σχήμα, ένα τοπικό χρώμα γεμίσματος, χρώμα γραμμής ή πάχος γραμμής μπορεί να παρακάμψει αυτό το μέρος του στυλ θέματος. Αν η αλλαγή δείκτη στυλ δεν έχει ορατό αποτέλεσμα, ελέγξτε τη [direct formatting](/slides/el/python-java/shape-formatting/).

## **Καθορισμός Εάν Ένα Αποτελεσματικό Συμπαγές Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί άμεσα σε ένα αντικείμενο ή να κληρονομηθεί από μια παράγραφο, layout, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε το [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) για να επιλύσετε αυτήν την ιεραρχία σε αμετάβλητα αποτελεσματικά δεδομένα γεμίσματος. Πρώτα ελέγξτε το `getFillType` στο αντικείμενο αποτελεσματικών δεδομένων. Μόνο όταν είναι `FillType.Solid` θα πρέπει να διαβάσετε τις ιδιότητες συμπαγούς γεμίσματος.

Για συμπαγές γέμισμα, το `getSolidFillColor` επιστρέφει την τελική απόδοση τιμή RGB μετά την κληρονομικότητα, την αντιστοίχηση θέματος και την εφαρμογή μετασχηματισμών χρώματος. Το `getSolidFillSchemeColor` επιστρέφει την αντίστοιχη λογική θέση [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/), όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό συμπαγές γέμισμα δεν βασίζεται σε χρώμα σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσα χρώματα RGB, αυτή η τιμή προσδιορίζει ένα άμεσο RGB γέμισμα.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) για να κατηγοριοποιήσετε ένα γέμισμα. Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική τιμή του είναι `NotDefined`, ενώ το αποτελεσματικό γέμισμα κληρονομεί χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντίστροφα, το `getSolidFillSchemeColor` σας λέει ποιο λογικό σχήμα παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν λέει αν η θέση προέρχεται από το αντικείμενο, την παράγραφο, το layout, το master ή άλλο επίπεδο.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τα γεμίσματα σχήματος και τα γεμίσματα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και το σχετικό χρώμα σχήματος, και επισημαίνει συμπαγή γεμίσματα που δεν θα παρακολουθούν αλλαγές χρώματος θέματος:

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

Το κλαδί `NotDefined` προσφέρει μια λίστα ελέγχου γεμισμάτων που δεν θα ανταποκριθούν σε αλλαγές στις θέσεις χρώματος θέματος. Εξετάστε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθήσει μια νέα παλέτα εταιρικής ταυτότητας. Η αναφερόμενη τιμή RGB δείχνει ακόμα την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση συνδέεται με το θέμα.

Τα αντικείμενα αποτελεσματικής μορφής είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `getEffective` και διαβάστε ένα νέο αντικείμενο αποτελεσματικών δεδομένων γεμίσματος πριν συγκρίνετε ή αναφέρετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι είναι ορισμένο σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Για ένα παρασκήνιο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), και για ένα γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το παρασκήνιο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε αποτελεσματικά δεδομένα για διαγνωστικά απόδοσης, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme), μπορεί να χάσετε κάποιον master, layout, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) εκχωρεί μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παρακάμψη θέματος. Η αλλαγή παραμένει τοπική σε εκείνη τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος να μεταφερθούμε ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον master πηγής στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) και [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Αυτό διατηρεί το master, τα layout και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφής όπως το [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) και το [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την κληρονομική εφαρμογή και τις παρακάμψεις.