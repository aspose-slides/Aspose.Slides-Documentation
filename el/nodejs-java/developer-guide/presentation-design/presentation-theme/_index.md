---
title: Διαχείριση Θεμάτων Παρουσίασης σε JavaScript
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/nodejs-java/presentation-theme/
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
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης σε JavaScript με Aspose.Slides για Node.js για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή ταυτότητα επωνυμίας."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμισμάτων, γραμμών και εφέ. Τα αντικείμενα που είναι συνειδητά του θέματος αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε η αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), ενώ ένας layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομικό του θέμα μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια καθορίζεται μέσω αυτής της αλυσίδας κληρονομιάς: θέμα παρουσίασης, παρακάμπτη master, παρακάμπτη layout και παρακάμπτη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας θεμάτων: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομιά και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) εκθέτει το χρωματικό σχήμα, το σχήμα γραμματοσειράς και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των εγγραφών στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται αργότερο στο άρθρο όταν υπάρχουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι συνειδητά του θέματος μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη εγγραφή στο [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);

    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μετέπειτα αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Επιπλέον Παλέτα**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτά και πιο σκούρα χρώματα που παράγονται από το επιπλέον παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βάσει του `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επαναϋπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η χαρτογράφηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειράς θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για τίτλους και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) και [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτοποιητές γραμματοσειράς συμβατών με PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά Κυρίως Κειμένου Λατινική (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά Τίτλου Λατινική (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά Κυρίως Κειμένου Ανατολική Ασιατική (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά Τίτλου Ανατολική Ασιατική (Major East Asian Font)
* `+mn-cs` - Γραμματοσειρά Κυρίως Κειμένου Σύνθετο Σύστημα (Minor Complex Script Font)
* `+mj-cs` - Γραμματοσειρά Τίτλου Σύνθετο Σύστημα (Major Complex Script Font)

Το παρακάτω παράδειγμα δημιουργεί έναν τίτλο που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή κειμένου που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));

    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο τίτλος ακολουθεί τη κύρια γραμματοσειρά και το κύριο κείμενο ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτοποιητή θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειράς θέματος.

Τα κύρια και δευτερεύοντα σύνολα γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλική, αραβική, ιαπωνική, γεωργιανή και θανά. Για επιθεώρηση, προσθήκη, αντικατάσταση ή κατάργηση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

### **Επίλυση Αναφορών Γραμματοσειρών Θέματος**

Κατά την επιθεώρηση κειμένου, το [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) μπορεί να επιστρέψει μια αναφορά θέματος όπως `+mn-lt` αντί για όνομα οικογένειας γραμματοσειράς. Καλέστε το [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) με το κατάλληλο αποτελεσματικό θέμα για να επιλύσετε αυτήν την αναφορά. Τα προθέματα `+mj` και `+mn` επιλέγουν τα κύρια και δευτερεύοντα σύνολα γραμματοσειρών· τα επιθήματα `-lt`, `-ea` και `-cs` επιλέγουν τις λατινικές, ανατολικές ασιατικές και σύνθετες γραμματοσειρές αντιστοίχως.

Αποκτήστε το αποτελεσματικό θέμα μέσω του [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) στο αντικείμενο του οποίου το θέμα εφαρμόζεται στο επιθεωρημένο κείμενο. Για απλό κείμενο σε διαφάνεια, καλέστε αυτή τη μέθοδο στη διαφάνεια ώστε το πλαίσιο να περιλαμβάνει το κληρονομικό θέμα της διαφάνειας και τις τοπικές παρακάμψεις. Όταν επιθεωρείτε ένα layout ή master, χρησιμοποιήστε το δικό του αποτελεσματικό θέμα. Μην υποθέτετε ότι το θέμα του πρώτου master ισχύει για κάθε διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα κειμένου που αναφέρει ρητά τη δευτερεύουσα λατινική γραμματοσειρά. Αρχικοποιεί ένα σχήμα γραμματοσειράς διαφάνειας μέσω του [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) και ορίζει τις κύριες και δευτερεύουσες λατινικές οικογένειες σε `Arial` και `Calibri`, κάνοντας το αποτέλεσμα επαναλήψιμο χωρίς αρχείο εισόδου.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `+mn-lt -> Calibri` ακολουθούμενη από `Verdana -> Verdana`. Η αποθηκευμένη αναφορά παραμένει αμετάβλητη, ενώ ένα ρητό όνομα οικογένειας επιστρέφεται ως έχει. Αν το τμήμα χρησιμοποιούσε `+mj-lt`, θα επιλύονταν σε `Arial` σε αυτό το θέμα.

Η επίλυση μιας αναφοράς θέματος προσδιορίζει την οικογένεια γραμματοσειράς που ορίζει το θέμα. Δεν επαληθεύει τη διαθεσιμότητα της γραμματοσειράς ή το αρχείο γραμματοσειράς που τελικά χρησιμοποιείται μετά την αντικατάσταση ή την εναλλακτική glyph κατά τη διάρκεια της απόδοσης. Δείτε τη [Font Selection Sequence](/slides/el/nodejs-java/font-selection-sequence/) και τη [Font Substitution](/slides/el/nodejs-java/font-substitution/) για αυτά τα ξεχωριστά βήματα.

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτημένες από Master**

Χρησιμοποιήστε το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επαναστυλοποιήσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) που αντιπροσωπεύεται από το [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες ενέργειες:

1. Δημιουργεί μια νέα διαφάνεια master βάσει του επιλεγμένου master.
1. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια.
1. Αναθέτει τη νέα διαφάνεια σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.
1. Επιστρέφει το νέο [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχουν οι χρήστες, διαχειριστείτε τις αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master μετατεθούν. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα φόντα και τα εφέ που είναι συνειδητά του θέματος επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, γραμματοσειρές, γεμίσματα και άλλες ρητές μορφοποιήσεις που έχουν οριστεί άμεσα μπορεί να παραμείνουν αμετάβλητα. Παράλληλα, οι παρακάμψεις σε επίπεδο layout ή διαφάνειας μπορούν επίσης να έχουν προτεραιότητα έναντι των τιμών που κληρονομούνται από τον νέο master.

Το θέμα μπορεί να αναφέρεται σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τες μέσω [custom font sources](/slides/el/nodejs-java/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/nodejs-java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί τη χειροκίνητη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Πολυ-Master Παρουσίαση**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, λάβετε τον από μια αντιπροσωπευτική διαφάνεια μέσω των [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) και [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, καθώς κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επαναστυλοποιούνται.

### **Διατήρηση Θεματος Πηγής Κατά τη Μεταφορά Διαφάνειας**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον source master στην προοριστική παρουσίαση με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του το master, τα layouts του και το συσχετισμένο θέμα.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);

        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγή διαφάνειας πρέπει να φαίνεται ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν ασύνδετο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντα και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και layout, αρχικοποιήστε μια παρακάμπτη διαφάνειας από το source theme. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παρακάμπτη.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από άλλες διαφάνειες. Για αφαίρεση της τοπικής παρακάμπτης και επιστροφή στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/).

### **Εφαρμογή Παρακάμπτη Θέματος σε Layout**

Μια παρακάμπτη σε επίπεδο layout εφαρμόζεται στις διαφάνειες που χρησιμοποιούν το συγκεκριμένο layout, εκτός αν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμπτη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλαπλά layouts και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμπτη layout όταν μια οικογένεια layout απαιτεί διαφορετικό στυλ, και μια παρακάμπτη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παρακάμπτες σε επίπεδο διαφάνειας καθιστούν πιο δύσκολη την πρόβλεψη των μελλοντικών παγκόσμιων αλλαγών θέματος.

<!-- visual-explanation:presentation-theme:start -->
[![Ένας master theme τροφοδοτεί δύο layouts· μια παρακάμπτη layout επηρεάζει τις διαφάνειες του εκτός από μια διαφάνεια με πιο τοπική παρακάμπτη.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Μια παρακάμπτη layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν αυτό το layout εκτός εάν μια διαφάνεια διαθέτει τη δική της παρακάμπτη. Οι τιμές βάσει θέματος ακολουθούν το επιλυμένο σχήμα τους· τα αντικείμενα με ρητή μορφοποίηση μπορούν να διατηρήσουν την τοπική τους εμφάνιση. Κρατήστε τις παρακάμπτες όσο το δυνατόν πιο περιορισμένες ώστε να ταιριάζουν στην προσεγγιστική σχεδίαση εξαίρεσης.* 
<!-- visual-explanation:presentation-theme:end -->

## **Ενημέρωση Στυλ Φόντου Θεματος**

Τα γεμίσματα φόντου του θέματος αποθηκεύονται στο [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των γεμισμάτων που είναι αποθηκευμένα στην συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη αποθηκευμένη συλλογή και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την απευθείας αρίθμηση της JavaScript συλλογής, όπου το `0` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, αναθέτει μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορατό αποτέλεσμα εξαρτάται από την εγγραφή θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου σε επίπεδο layout ή διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην αλλάξει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό φόντο μετά την κληρονομιά.

{{% alert color="warning" title="Warning" %}}
Μην αντιμετωπίζετε το δείκτη στυλ ως δείκτη συλλογής με βάση το μηδέν. Επίσης, αποφύγετε τον σκληρό κωδικό αριθμό στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση φόντου και κληρονομιά φόντου, δείτε το [Presentation Background](/slides/el/nodejs-java/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες εγγραφές στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονη μορφοποίηση, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπια, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε JavaScript, ο δείκτης της συλλογής είναι μηδενισμένος: το `0` είναι το πρώτο αποθηκευμένο στυλ και το `2` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτινόμενη μέσω του [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· τα σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες εγγραφές στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);

    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής του θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος του θέματος γίνεται έντονο δάση πράσινο, και το τρίτο στυλ εφέ κερδίζει εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ κάθε σχήμα αναφέρει και εάν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρυθμίσεων σκιάς](presentation-design_11.png)

## **Επιλογή Στυλ Γεμίσματος και Γραμμής Θέματος για Σχήμα**

Ένα σχήμα μπορεί να επιλέξει το γέμισμα και το περίγραμμα του ανεξάρτητα μέσω των [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) και [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). Για κάθε μέθοδο, το δείκτη `1` επιλέγει την πρώτη εγγραφή στη σχετική συλλογή θέματος (`get_Item(0)`), και το `2` την δεύτερη (`get_Item(1)`).

Το παρακάτω παράδειγμα δημιουργεί δύο στυλ γεμίσματος (χρυσό και γαλάζιο) και δύο στυλ γραμμής (σκούρο μπλε στα 6 pt και σκούρο κόκκινο στα 12 pt) στο προεπιλεγμένο θέμα μιας νέας παρουσίασης. Αποθηκεύει τη διαφάνεια σε τρία στάδια ώστε να μπορείτε να συγκρίνετε τα αποτελέσματα στο PowerPoint.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Αρχικά στυλ | Αλλαγή δεξιού περιγράμματος | Επεξεργασία του πρώτου γεμίσματος θέματος |
|:---:|:---:|:---:|
| ![Χρυσά και γαλάζια ορθογώνια με αντίστοιχα λεπτά σκούρα μπλε περιγράμματα](theme-style-initial.png) | ![Το γαλάζιο ορθογώνιο έχει τώρα παχύ σκούρο κόκκινο περίγραμμα](theme-style-line-changed.png) | ![Το αριστερό ορθογώνιο γίνεται πράσινο και και τα δύο περιγράμματα παραμένουν αμετάβλητα](theme-style-fill-changed.png) |

Η επιλογή διαφορετικού στυλ γραμμής αλλάζει μόνο το περίγραμμα του δεξιού ορθογωνίου. Η επεξεργασία του πρώτου γεμίσματος θέματος ενημερώνει κάθε σχήμα που το χρησιμοποιεί. Εδώ, μόνο το αριστερό ορθογώνιο γίνεται πράσινο.

Σε υπάρχον σχήμα, ένα τοπικό χρώμα γεμίσματος, χρώμα γραμμής ή πάχος γραμμής μπορεί να παρακάμψει αυτό το μέρος του στυλ θέματος. Αν η αλλαγή ενός δείκτη στυλ δεν έχει οπτικό αποτέλεσμα, ελέγξτε τη [direct formatting](/slides/el/nodejs-java/shape-formatting/).

## **Καθορισμός Αν Ένα Αποτελεσματικό Σταθερό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί άμεσα σε αντικείμενο ή να κληρονομηθεί από παράγραφο, layout, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε το [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) για να επιλύσετε αυτήν την ιεραρχία σε ένα αμετάβλητο στιγμιότυπο αποτελεσματικού γεμίσματος. Πρώτα ελέγξτε την τιμή `getFillType`. Μόνο όταν είναι `FillType.Solid` πρέπει να διαβάσετε τις ιδιότητες στερεού γεμίσματος.

Για στερεό γέμισμα, το `getSolidFillColor` επιστρέφει την τελική απόδοση τιμή RGB μετά την κληρονόμηση, την αναζήτηση θέματος και την εφαρμογή μετασχηματισμών χρώματος. Η μέθοδος `getSolidFillSchemeColor` επιστρέφει την αντίστοιχη λογική θέση [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/), όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε θέση σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσες τιμές RGB, αυτή η τιμή προσδιορίζει ένα άμεσο γεμίσμα RGB.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) για την ταξινόμηση ενός γεμίσματος. Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική του τιμή είναι `NotDefined`, ενώ το αποτελεσματικό του γέμισμα κληρονομεί ένα χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντίστροφα, το `getSolidFillSchemeColor` λέει ποια λογική θέση θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν λέει από ποιο επίπεδο (αντικείμενο, παράγραφος, layout, master κ.λπ.) προέρχεται.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τα γεμίσματα σχήματος και τα γεμίσματα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και τη σχετική θέση σχήματος, και επισημαίνει στερεά γεμίσματα που δεν θα παρακολουθούν αλλαγές χρώματος θέματος:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Το κλαδί `NotDefined` παρέχει μια λίστα ελέγχου στερεών γεμισμάτων που δεν θα ανταποκριθούν σε αλλαγές στις θέσεις χρώματος θέματος. Εξετάστε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθεί μια νέα παλέτα εμπορικού σήματος. Η αναφερόμενη τιμή RGB δείχνει ακόμη την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση συνδέεται με το θέμα.

Τα αντικείμενα αποτελεσματικής μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμπτης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `getEffective` και διαβάστε ένα νέο αντικείμενο αποτελεσματικού γεμίσματος πριν συγκρίνετε ή δημοσιεύσετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομιά και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). Για φόντο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), και για γέμισμα, χρησιμοποιήστε το [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();

    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστική απόδοση, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/), μπορεί να χάσετε μια παράμετρο master, layout, διαφάνειας ή σχήματος που αλλάζει την τελική εμφάνιση.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Εφαρμόζει ένα εξωτερικό θέμα κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) επανααναθέτει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το παρακάμπτο θέμα της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρετε ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της εμφάνισης της πηγής, κλωνοποιήστε τον source master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) και [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). Αυτό διατηρεί τον master, τα layouts και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομιά και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την κληρονομιά και τις παρακάμψεις.