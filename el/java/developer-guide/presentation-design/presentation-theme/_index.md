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
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης στο Aspose.Slides για Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή σήμανση."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, στην ουσία επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και των ιδιοτήτων τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [γραμματοσειρές](/slides/el/java/powerpoint-fonts/), [στυλ φόντου](/slides/el/java/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Αν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα στο θέμα. Για να μπορείτε να επιλέξετε ένα νέο χρώμα θέματος, το Aspose.Slides παρέχει τιμές στο [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/SchemeColor) απαρίθμηση.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το χρώμα ανάτσεσης για ένα θέμα:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Μπορείτε να προσδιορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος με αυτόν τον τρόπο:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Για να δείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα ακόμα στοιχείο και του αναθέτουμε το χρώμα ανάτσεσης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλτό**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), δημιουργούνται χρώματα από την πρόσθετη παλτό(2). Στη συνέχεια μπορείτε να θέσετε και να λάβετε αυτά τα χρώματα θέματος.

![additional-palette-colors](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος  
**2** - Χρώματα από την πρόσθετη παλτό.

Αυτός ο κώδικας Java δείχνει μια λειτουργία όπου τα χρώματα της πρόσθετης παλτό προέρχονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Έμφαση 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Έμφαση 4, Φωτεινότερο 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Έμφαση 4, Φωτεινότερο 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Έμφαση 4, Φωτεινότερο 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Έμφαση 4, Σκοτεινότερο 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Έμφαση 4, Σκοτεινότερο 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Χαρτογράφηση του `SchemeColor` στα Χρώματα `IColorScheme`**

Όταν εργάζεστε με το [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις παρακάτω τιμές χρωμάτων θέματος:
`Background1`, `Background2`, `Text1` και `Text2`.

Ωστόσο, το `Presentation.getMasterTheme().getColorScheme()` επιστρέφει το [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/), που αποκαλύπτει τα αντίστοιχα χρώματα ως:
`Dark1`, `Dark2`, `Light1` και `Light2`.

Αυτή η διαφορά είναι μόνο στη ονομασία. Αυτές οι τιμές αναφέρονται στα ίδια slots χρωμάτων θέματος και η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Απλώς αποτελούν εναλλακτικές ονομασίες για τα ίδια χρώματα θέματος.

Αυτή η διαφορά ονομασίας προέρχεται από την ορολογία του Microsoft Office. Οι παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεώτερες εκδόσεις UI εμφανίζουν τα ίδια slots ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέξετε γραμματοσειρές για θέματα και άλλους σκοπούς, το Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς αναγνωριστές (παρόμοιους με αυτούς που χρησιμοποιούνται στο PowerPoint):

* **+mn-lt** - Γραμματοσειρά σώματος Λατινική (Minor Latin Font)
* **+mj-lt** - Γραμματοσειρά κεφαλίδας Λατινική (Major Latin Font)
* **+mn-ea** - Γραμματοσειρά σώματος Ανατολική Ασία (Minor East Asian Font)
* **+mj-ea** - Γραμματοσειρά σώματος Ανατολική Ασία (Major East Asian Font)

Αυτός ο κώδικας Java δείχνει πώς να αναθέσετε τη λατινική γραμματοσειρά σε ένα στοιχείο θέματος:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη γραμματοσειρά θέματος παρουσίασης:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.
{{% alert color="info" title="TIP" %}} 
Μπορεί να θέλετε να δείτε τις [γραμματοσειρές PowerPoint](/slides/el/java/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προορισμένα φόντα, αλλά μόνο 3 από αυτά τα 12 φόντα αποθηκεύονται σε μια τυπική παρουσίαση.

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα Java για να μάθετε τον αριθμό των προεπιλεγμένων φόντων στην παρουσίαση:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme), μπορείτε να προσθέσετε ή να αποκτήσετε πρόσβαση στο στυλ φόντου σε ένα θέμα PowerPoint.
{{% /alert %}} 

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το φόντο για μια παρουσίαση:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Οδηγός ευρετηρίου**: το 0 χρησιμοποιείται για καμία γέμιση. Το ευρετήριο ξεκινά από το 1.
{{% alert color="info" title="TIP" %}} 
Μπορεί να θέλετε να δείτε το [Φόντο PowerPoint](/slides/el/java/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε πίνακα στυλ. Αυτοί οι πίνακες συνδυάζονται σε αυτά τα 3 εφέ: ήπιο, μέτριο και έντονο. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:
![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme#getEffectStyles--)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/FormatScheme), μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές στο PowerPoint).

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας μέρη των στοιχείων:
```java
import com.aspose.slides.*;
import java.awt.Color;

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

Οι προκύπτοντες αλλαγές στο χρώμα γεμίσματος, τον τύπο γεμίσματος, το εφέ σκιάς κ.λπ.:
![todo:image_alt_text](presentation-design_11.png)

## **Συχνές Ερωτήσεις**

### Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω το master;
Ναι. Το Aspose.Slides υποστηρίζει παρακαμφτικές ρυθμίσεις θέματος σε επίπεδο διαφάνειας, ώστε να μπορείτε να εφαρμόσετε ένα τοπικό θέμα μόνο σε αυτή τη διαφάνεια ενώ διατηρείτε αμετάβλητο το κύριο θέμα (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidethememanager/)).

### Ποιος είναι ο ασφαλέστερος τρόπος να μεταφέρετε ένα θέμα από μία παρουσίαση σε άλλη;
[Κλωνοποιήστε διαφάνειες](/slides/el/java/clone-slides/) μαζί με το master τους στην παρουσίαση προορισμού. Αυτό διατηρεί το αρχικό master, τα layout και το συσχετισμένο θέμα ώστε η εμφάνιση να παραμένει συνεπής.

### Πώς μπορώ να δω τις «αποτελεσματικές» τιμές μετά από όλες τις κληρονομιές και παρακάμψεις;
Χρησιμοποιήστε τις "αποτελεσματικές" προβολές του API [/slides/el/java/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις επιλυμένες, τελικές ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών παρακάμψεων.