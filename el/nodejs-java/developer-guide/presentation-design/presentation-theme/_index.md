---
title: Διαχείριση θεμάτων παρουσίασης σε JavaScript
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
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης σε JavaScript με το Aspose.Slides για Node.js για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή σήμανση."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ παρασκηνίων, γεμίσματα, γραμμές και εφέ. Τα αντικείμενα που γνωρίζουν το θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα επιπέδου παρουσίασης είναι διαθέσιμο μέσω του [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getmastertheme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας κύριος (master) μπορεί να παρακάμψει το θέμα παρουσίασης μέσω του [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterthememanager/), ενώ μια διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη κύριου, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ παρασκηνίων και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με θέματα: έλεγχος θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ παρασκηνίου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομιά και τις παρακάμψεις.

## **Έλεγχος Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mastertheme/) εκθέτει το σχήμα χρωμάτων, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/mastertheme/). Η εξέταση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ παρασκηνίου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς κύριους, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Ελέγξτε τον κύριο που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται παρακάτω όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που γνωρίζουν το θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την ατζέντρια [SchemeColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στην [ColorScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί το `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μεταγενέστερες αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Πρόσθετη Παλέτα**

Το PowerPoint παράγει φωτεινότερες και σκούρως παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της ατζέντριας [ColorTransformOperation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και φωτεινότερες/σκούρες παραλλαγές που δημιουργούνται από την πρόσθετη παλέτα](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.

**2** – Φωτεινότερες και σκούρες παραλλαγές που παραγίνονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η ατζέντρια [SchemeColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [ColorScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτές είναι εναλλακτικές ονομασίες για τις ίδιες θέσεις θέματος· δεν πρόκειται για τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιέχει ένα σύνολο κύριων γραμματοσειρών για επικεφαλίδες και ένα σύνολο δευτερευόντων γραμματοσειρών για το κυρίως κείμενο. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontscheme/) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτοποιητές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στην διαμόρφωση κειμένου:

* `+mn-lt` – Γραμματοσειρά σώματος Latin (Minor Latin Font)
* `+mj-lt` – Γραμματοσειρά επικεφαλίδας Latin (Major Latin Font)
* `+mn-ea` – Γραμματοσειρά σώματος Ανατολικής Ασίας (Minor East Asian Font)
* `+mj-ea` – Γραμματοσειρά επικεφαλίδας Ανατολικής Ασίας (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη μεγάλη γραμματοσειρά Latin και μια γραμμή σώματος που χρησιμοποιεί τη μικρή γραμματοσειρά Latin. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο τη μικρή γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτοποιητή θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι συλλογές μεγάλων και μικρών γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίες γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά και θανά. Για έλεγχο, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Έναν Master**

Χρησιμοποιήστε το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επαναστυλιζάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που αντιπροσωπεύεται από το [MasterSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslidecollection/), και περάστε το μονοπάτι του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις παρακάτω ενέργειες:

1. Δημιουργεί μια νέα διαφάνεια master με βάση τον επιλεγμένο master.  
1. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια.  
1. Αναθέτει τη νέα διαφάνεια σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.  
1. Επιστρέφει το νεοδημιουργημένο [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/).

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

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχουν οι χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επανατοποθετούνται. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα παρασκήνια και τα εφέ που γνωρίζουν το θέμα επιλύονται έναντι του εξωτερικού θέματος. Τα άμεσα καθορισμένα χρώματα, γραμματοσειρές, γεμίσματα και άλλες ρητές μορφοποιήσεις μπορεί να παραμείνουν αμετάβλητα. Παρακάμψεις επιπέδου διάταξης και διαφάνειας μπορούν επίσης να υπερισχύσουν των τιμών που κληρονομούνται από τον νέο master.

Το θέμα μπορεί να κάνει αναφορά σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τις μέσω των [custom font sources](/slides/el/nodejs-java/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/nodejs-java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας επιπέδου master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί χειροκίνητη δημιουργία παρακάμψεων θέματος επιπέδου διαφάνειας ή διάταξης.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω των [Slide.getLayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/) και [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν ακόμη master στην παρουσίαση.

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

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `firstGroupMaster`, ενώ η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επαναστυλιζάνονται.

### **Διατήρηση Θεματος Πηγής Κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον master πηγής στην παρουσίαση προορισμού με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslidecollection/), έπειτα κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει τον master, τις διατάξεις του και το σχετικό θέμα μαζί.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η διαφάνεια πηγής πρέπει να διατηρήσει την ίδια εμφάνιση στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν αχρειάσιμο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, παρασκήνια και εφέ που καθοδηγούνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Αν η διαφάνεια προορισμού πρέπει να παραμείνει στον τρέχοντα master και διάταξη, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το θέμα πηγής. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παρακάμψη.

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

Αυτή η ενέργεια αλλάζει το θέμα που χρησιμοποιείται από τη συγκεκριμένη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/overridetheme/).

### **Εφαρμογή Παραχώρησης Θέματος σε Διάταξη**

Μια παραχώρηση επιπέδου διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παραχώρηση. Οι ίδιες μέθοδοι εκκίνησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα master ή παρουσίασης όταν πολλά σχέδια και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παραχώρηση διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παραχώρηση διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παραχωρήσεις επιπέδου διαφάνειας κάνουν τις μελλοντικές παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Παρασκηνίου Θέματος**

Τα γέμισματα παρασκηνίου του θέματος αποθηκεύονται στην [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/formatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές παρασκηνίου στο UI του από τον αριθμό των ορισμών γεμίσματος που αποθηκεύονται πραγματικά σε αυτή τη συλλογή, επειδή το UI μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ παρασκηνίου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ παρασκηνίου, ελέγξτε τη συλλογή που αποθηκεύεται και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει γεμιστό θέμα· θετικές τιμές είναι αναφορές στυλ παρασκηνίου θέματος. Αυτό διαφέρει από τη δεικτοδότηση της συλλογής JavaScript απευθείας, όπου το `0` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος παρασκηνίου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων παρασκηνίου, εκχωρεί μια αναφορά themed background στον πρώτο master, και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις παρασκηνίου στη διάταξη ή στη διαφάνεια. Αν μια διαφάνεια χρησιμοποιεί το δικό της παρασκήνιο, η αλλαγή μόνο του παρασκηνίου του master μπορεί να μην επηρεάσει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/background/) όταν χρειάζεστε το τελικό παρασκήνιο μετά την εφαρμογή κληρονομιάς.

{{% alert color="warning" title="Προειδοποίηση" %}}

Μην αντιμετωπίζετε τον δείκτη στυλ ως δείκτη μηδενικής βάσης μιας συλλογής. Επίσης, αποφύγετε την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}

Για άμεση μορφοποίηση παρασκηνίου και κληρονομία παρασκηνίου, δείτε το [Presentation Background](/slides/el/nodejs-java/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιέχει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/formatscheme/), και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/formatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες καταχωρίσεις στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονη μορφοποίηση, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπια, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε JavaScript, ο δείκτης της συλλογής είναι μηδενικής βάσης: το `0` είναι το πρώτο αποθηκευμένο στυλ και το `2` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος αποτελούν ξεχωριστή έννοια, εκτινόμενη μέσω του [ShapeStyle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει ότι υπάρχουν οι απαιτούμενες καταχωρίσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται στερεό σκούρο πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποιες θέσεις στυλ αναφέρονται τα σχήματα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρυθμίσεων σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι είναι ορισμένο σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί μια διαφάνεια ή ένα σχήμα μετά την κληρονομιά και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseoverridethememanager/). Για ένα παρασκήνιο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/background/), και για ένα γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το παρασκήνιο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικούς ελέγχους απόδοσης, επικυρώσεις και συγκρίσεις. Αν ελέγχετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getmastertheme/), μπορεί να χάσετε έναν master, διάταξη, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) επανατοποθετεί μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το override theme της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής εμφάνισής της, κλωνοποιήστε τον master πηγής στην προορισμό με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslidecollection/) και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας το [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/). Αυτό διατηρεί τον master, τις διατάξεις και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομιά και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομιάς και παρακάμψεων.