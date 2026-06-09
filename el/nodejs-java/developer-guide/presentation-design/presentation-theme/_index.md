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
- Χρώμα θέματος
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε θέματα παρουσίασης σε JavaScript με το Aspose.Slides για Node.js, ώστε να δημιουργείτε, προσαρμόζετε και μετατρέπετε αρχεία PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, στην πραγματικότητα επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και των ιδιοτήτων τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [γραμματοσειρές](/slides/el/nodejs-java/powerpoint-fonts/), [στυλ φόντου](/slides/el/nodejs-java/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Αν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα στο θέμα. Για να επιλέξετε νέο χρώμα θέματος, το Aspose.Slides παρέχει τιμές στην αρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SchemeColor).

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Μπορείτε να καθορίσετε την αποτελεσματική τιμή του αποτελέσματος χρώματος με τον ακόλουθο τρόπο:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Για να δείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα άλλο στοιχείο και του αναθέτουμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), δημιουργούνται χρώματα από την πρόσθετη παλέτα(2). Μπορείτε τότε να ορίσετε και να λάβετε αυτά τα χρώματα θέματος. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος  
**2** - Χρώματα από την πρόσθετη παλέτα.

Αυτός ο κώδικας JavaScript επιδεικνύει μια λειτουργία όπου τα χρώματα της πρόσθετης παλέτας λαμβάνονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Τονισμός 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Τονισμός 4, Φωτεινότερο 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Τονισμός 4, Φωτεινότερο 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Τονισμός 4, Φωτεινότερο 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Τονισμός 4, Σκοτεινότερο 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Τονισμός 4, Σκοτεινότερο 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Χαρτογράφηση `SchemeColor` σε Χρώματα `ColorScheme`**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/schemecolor/), ίσως παρατηρήσετε ότι περιέχει τις ακόλουθες τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1` και `Text2`.

Ωστόσο, η μέθοδος `Presentation.getMasterTheme().getColorScheme()` επιστρέφει ένα [ColorScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/colorscheme/), το οποίο αποκαλύπτει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1` και `Light2`.

Αυτή η διαφορά είναι μόνο στην ονομασία. Οι τιμές αναφέρονται στις ίδιες θέσεις χρωμάτων θέματος και η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Είναι απλώς εναλλακτικές ονομασίες για τα ίδια χρώματα θέματος.

Αυτή η διαφορά ονομάτων προέρχεται από την ορολογία του Microsoft Office. Παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ νεότερες εκδόσεις UI εμφανίζουν τις ίδιες θέσεις ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέγετε γραμματοσειρές για θέματα και άλλους σκοπούς, το Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς αναγνωριστές (παρόμοιους με αυτούς που χρησιμοποιούνται στο PowerPoint):

* **+mn-lt** - Γραμματοσειρά σώματος Λατινική (Minor Latin Font)
* **+mj-lt** - Γραμματοσειρά επικεφαλίδας Λατινική (Major Latin Font)
* **+mn-ea** - Γραμματοσειρά σώματος Ανατολική Ασία (Minor East Asian Font)
* **+mj-ea** - Γραμματοσειρά σώματος Ανατολική Ασία (Major East Asian Font)

Αυτός ο κώδικας JavaScript δείχνει πώς να εκχωρήσετε τη λατινική γραμματοσειρά σε ένα στοιχείο θέματος:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε τη γραμματοσειρά θέματος παρουσίασης:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε τις [γραμματοσειρές PowerPoint](/slides/el/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προκαθορισμένα φόντα, αλλά μόνο 3 από αυτά αποθηκεύονται σε μια τυπική παρουσίαση. 

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα JavaScript για να προσδιορίσετε τον αριθμό των προκαθορισμένων φόντων στην παρουσίαση:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme), μπορείτε να προσθέσετε ή να προσπελάσετε το στυλ φόντου σε ένα θέμα PowerPoint.
{{% /alert %}} 

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε το φόντο για μια παρουσίαση:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Οδηγός δείκτη**: 0 σημαίνει χωρίς γέµι. Ο δείκτης αρχίζει από 1.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε το [Φόντο PowerPoint](/slides/el/nodejs-java/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε 3 εφέ: λεπτό, μέτριο και έντονο. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FormatScheme) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές του PowerPoint).

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας μέρη των στοιχείων:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Οι αλλαγές που προκύπτουν σε χρώμα γεμίσματος, τύπο γεμίσματος, εφέ σκιάς κ.λπ.:

![todo:image_alt_text](presentation-design_11.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Το Aspose.Slides υποστηρίζει παρακάμψεις θέματος επιπέδου διαφάνειας, ώστε να μπορείτε να εφαρμόσετε τοπικό θέμα μόνο σε αυτή τη διαφάνεια ενώ το master θέμα παραμένει ανεπηρέαστο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidethememanager/)).

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

[Κλωνοποιήστε τις διαφάνειες](/slides/el/nodejs-java/clone-slides/) μαζί με το master τους στην προοριστική παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το συσχετισμένο θέμα ώστε η εμφάνιση παραμένει συνεπής.

**Πώς μπορώ να δω τις “αποτελεσματικές” τιμές μετά από όλες τις κληρονομήσεις και τις παρακάμψεις;**

Χρησιμοποιήστε τις “αποτελεσματικές” προβολές του API [/slides/el/nodejs-java/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις τελικές, επιλυμένες ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών παρακάμψεων.