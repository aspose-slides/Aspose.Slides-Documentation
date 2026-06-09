---
title: Διαχείριση Θεμάτων Παρουσίασης σε Java
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/java/presentation-theme/
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
- Παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης στο Aspose.Slides για Java για να δημιουργήσετε, προσαρμόσετε και μετατρέψετε αρχεία PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των σχεδιαστικών στοιχείων. Όταν επιλέγετε ένα θέμα παρουσίασης, ουσιαστικά επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και τις ιδιότητές τους.

Στο PowerPoint, ένα θέμα αποτελείται από χρώματα, [γραμματοσειρές](/slides/el/java/powerpoint-fonts/), [στυλ φόντου](/slides/el/java/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Εάν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα για το θέμα. Για να μπορείτε να επιλέξετε ένα νέο χρώμα θέματος, το Aspose.Slides παρέχει τιμές στο απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/SchemeColor).

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Μπορείτε να καθορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος με αυτόν τον τρόπο:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Για να δείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα άλλο στοιχείο και του αναθέτουμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), δημιουργούνται χρώματα από την πρόσθετη παλέτα(2). Μπορείτε στη συνέχεια να ορίσετε και να λάβετε αυτά τα χρώματα θέματος.

![additional-palette-colors](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος  
**2** - Χρώματα από την πρόσθετη παλέτα.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Έμφαση 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Έμφαση 4, πιο φωτεινό 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Έμφαση 4, πιο φωτεινό 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Έμφαση 4, πιο φωτεινό 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Έμφαση 4, πιο σκοτεινό 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Έμφαση 4, πιο σκοτεινό 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Χαρτογράφηση `SchemeColor` σε Χρώματα `IColorScheme`**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις παρακάτω τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1`, and `Text2`.

Ωστόσο, το `Presentation.getMasterTheme().getColorScheme()` επιστρέφει [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/), που εκθέτει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Αυτή η διαφορά είναι μόνο στην ονομασία. Οι τιμές αναφέρονται στα ίδια slots χρωμάτων θέματος και η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Είναι απλώς εναλλακτικές ονομασίες για τα ίδια χρώματα θέματος.

Αυτή η διαφορά ονοματολογίας προέρχεται από τη τεκμηρίωση του Microsoft Office. Οι παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τα ίδια slots ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέξετε γραμματοσειρές για θέματα και άλλους σκοπούς, το Aspose.Slides χρησιμοποιεί αυτά τα ειδικά αναγνωριστικά (παρόμοια με αυτά που χρησιμοποιούνται στο PowerPoint):

* **+mn-lt** - Γραμματοσειρά Σώματος Λατινική (Μικρή Λατινική Γραμματοσειρά)
* **+mj-lt** - Γραμματοσειρά Τίτλου Λατινική (Κύρια Λατινική Γραμματοσειρά)
* **+mn-ea** - Γραμματοσειρά Σώματος Ανατολική Ασιατική (Μικρή Ανατολική Ασιατική Γραμματοσειρά)
* **+mj-ea** - Γραμματοσειρά Σώματος Ανατολική Ασιατική (Κύρια Ανατολική Ασιατική Γραμματοσειρά)

Αυτός ο κώδικας Java δείχνει πώς να αναθέσετε τη Λατινική γραμματοσειρά σε ένα στοιχείο θέματος:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη γραμματοσειρά του θέματος παρουσίασης:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="primary" title="TIP" %}} 
Ίσως θέλετε να δείτε [γραμματοσειρές PowerPoint](/slides/el/java/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Κατά προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προορισμένα φόντα, αλλά μόνο 3 από αυτά τα 12 φόντα αποθηκεύονται σε μια τυπική παρουσίαση.

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα Java για να βρείτε τον αριθμό των προορισμένων φόντων στην παρουσίαση:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme), μπορείτε να προσθέσετε ή να έχετε πρόσβαση στο στυλ φόντου σε ένα θέμα PowerPoint. 
{{% /alert %}} 

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το φόντο για μια παρουσίαση:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Οδηγός ευρετηρίου**: 0 χρησιμοποιείται για χωρίς γέμισμα. Το ευρετήριο ξεκινά από 1.

{{% alert color="primary" title="TIP" %}} 
Ίσως θέλετε να δείτε [Φόντο PowerPoint](/slides/el/java/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε αυτά τα 3 εφέ: ήπιος, μέτριος και έντονος. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getEffectStyles--)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές του PowerPoint).

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Οι προκύπτοντες αλλαγές στο χρώμα γεμίσματος, τύπο γεμίσματος, εφέ σκιάς κ.λπ.:

![todo:image_alt_text](presentation-design_11.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Το Aspose.Slides υποστηρίζει επικάλυψη θέματος σε επίπεδο διαφάνειας, ώστε μπορείτε να εφαρμόσετε ένα τοπικό θέμα σε αυτή τη διαφάνεια ενώ το master θέμα παραμένει αμετάβλητο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidethememanager/)).

**Ποιος είναι ο ασφαλέστερος τρόπος να μεταφέρετε ένα θέμα από μια παρουσίαση σε άλλη;**

[Κλωνοποιήστε διαφάνειες](/slides/el/java/clone-slides/) μαζί με το master τους στην προορισμένη παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το σχετικό θέμα ώστε η εμφάνιση να παραμείνει συνεπής.

**Πώς μπορώ να δω τις "αποτέλεσματικές" τιμές μετά από όλες τις κληρονομίες και τις παρακάμψεις;**

Χρησιμοποιήστε τις [αποτελεσματικές προβολές](/slides/el/java/shape-effective-properties/) για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις επιλυμένες, τελικές ιδιότητες μετά την εφαρμογή του master συν οποιεσδήποτε τοπικές παρακάμψεις.