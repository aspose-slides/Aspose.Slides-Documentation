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
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Java
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας κύριος (master) μπορεί να παρακάμψει το θέμα παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterthememanager/), ενώ μια διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληθέν του θέμα μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Στην πράξη, το ενεργό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη κύριου, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με τα θέματα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση των ενεργών τιμών μετά την κληρονόμηση και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) εκθέτει το σχήμα χρωμάτων, το σχήμα γραμματοσειράς και το σχήμα μορφοποίησης του θέματος μέσω [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορούν να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γέμισματος, γραμμής και εφέ είναι αποθηκευμένες στο θέμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Εάν ένα αρχείο χρησιμοποιεί πολλαπλούς κύριους, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο ενεργό θέμα. Επιθεωρήστε τον κύριο που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας του ενεργού‑θέματος που παρουσιάζεται αργότερα σε αυτό το άρθρο όταν ενδέχεται να υπάρχουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/), όλα τα αντικείμενα που ακόμη αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Όσα αντικείμενα χρησιμοποιούν άμεσο χρώμα RGB δεν τροποποιούνται από μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί το `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το ενεργό χρώμα γεμίσματος:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό χρώμα του γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με ένα άμεσο χρώμα στο σχήμα, οι μετέπειτα αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Επιπλέον Παλέτα**

Το PowerPoint παράγει ελαφρύτερες και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/java/com.aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ελαφρύτερα/σκούρα χρώματα που δημιουργούνται από την επιπλέον παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Ελαφρύτερες και σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επαναυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν πρόκειται για τιμές που μετατρέπονται δυναμικά από μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειράς θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για κεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θέματος συμβατές με το PowerPoint μπορούν να χρησιμοποιηθούν στην μορφοποίηση κειμένου:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια κεφαλίδα που χρησιμοποιεί τη μεγάλη λατινική γραμματοσειρά θέματος και μια γραμμή κυρίως κειμένου που χρησιμοποιεί τη μικρή λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο την μικρή γραμματοσειρά. Κείμενο που έχει ρητά ορισμένο όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/java/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Υπάρχουν δύο συνηθισμένες ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση Πηγαίου Θέματος Κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο κύριο στην προορισμένη παρουσίαση με [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/), έπειτα κλωνοποιήστε τη διαφάνεια με [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/) και τον κλωνοποιημένο κύριο. Αυτό μεταφέρει τον κύριο, τις διατάξεις του και το σχετικό θέμα μαζί.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται τα ίδια στο προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν άσχετο προορισμό κύριο μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντο και εφέ που οδηγούνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Εάν η διαφάνεια‑στόχος πρέπει να παραμείνει στον τρέχοντα κύριο και τη διάταξή της, αρχικοποιήστε μια παράκαμψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παράκαμψη.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε [OverrideTheme.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/).

### **Εφαρμογή Παράκαμψης Θέματος σε Διάταξη**

Μια παράκαμψη σε επίπεδο διάταξης εφαρμόζεται σε όλες τις διαφάνειες που χρησιμοποιούν αυτή τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο κύριου ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παράκαμψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις σε επίπεδο διαφάνειας καθιστούν τις μετέπειτα καθολικές αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γεμίσματα φόντου του θέματος αποθηκεύονται στο [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που αποθηκεύονται στη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που αποθηκεύεται και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την ευθεία αρίθμηση της συλλογής Java, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, εκχωρεί μια θεματική αναφορά φόντου στον πρώτο κύριο και αποθηκεύει την παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορατό αποτέλεσμα εξαρτάται από την είσοδο θέματος που παραπέμπει ο κύριος και από τυχόν παρακάμψεις φόντου στη διάταξη ή στη διαφάνεια. Εάν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του κύριου ενδέχεται να μην επηρεάσει αυτή τη διαφάνεια. Χρησιμοποιήστε [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) όταν χρειάζεστε να γνωρίζετε το τελικό φόντο μετά την εφαρμογή της κληρονόμησης.

{{% alert color="warning" title="Warning" %}}
Μην θεωρείτε ότι ο δείκτης στυλ είναι μηδενικής βάσης. Επίσης, αποφύγετε την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση φόντου και κληρονόμηση φόντου, δείτε [Presentation Background](/slides/el/java/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιέχει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/) και [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Τα τυπικά θέματα του Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονα μορφοποιήσεις, αλλά ο κώδικας πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπιο, μέτριο και έντονο εφέ θέματος εφαρμόσμένα στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε Java, ο δείκτης συλλογής είναι μηδενικής βάσης: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω [IShapeStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει την ύπαρξη των απαιτούμενων καταχωρήσεων στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θεμάτων γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θεμάτων γίνεται στερεό δάσος πράσινο και το τρίτο στυλ εφέ αποκτά εξωτερική σκίαση με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποιες θέσεις στυλ αναφέρονται κάθε σχήμα και εάν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή ρυθμίσεων γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Ανάγνωση Ενεργών Τιμών Θέματος**

Οι ακατέργαστες αντικειμενικές του θέματος σας λένε τι είναι ορισμένο σε συγκεκριμένο επίπεδο. Οι ενεργές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή ένα σχήμα μετά την κληρονόμηση και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Για ένα φόντο, χρησιμοποιήστε [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/), και για ένα γέμισμα, χρησιμοποιήστε [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το ενεργό θέμα, το φόντο και το γέμισμα του πρώτου σχήματος από μια διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε ενεργά δεδομένα για διαγνωστικές απεικονίσεις, επικυρώσεις και συγκρίσεις. Εάν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), μπορεί να παραβλεφθεί ένας κύριος, διάταξη, διαφάνεια ή παράμετρος σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω τον κύριο;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παράκαμψής της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής εμφάνισής της, κλωνοποιήστε τον πηγαίο κύριο στον προορισμό και κλωνοποιήστε τη διαφάνεια με εκείνο τον κύριο χρησιμοποιώντας [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/) και [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/). Αυτό διατηρεί τον κύριο, τις διατάξεις και το θέμα μαζί.

**Πώς μπορώ να δω τις ενεργές τιμές μετά την κληρονόμηση και τις παρακάμψεις;**

Χρησιμοποιήστε [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/) για μια διαφάνεια ή θέμα διάταξης και τις αντίστοιχες μεθόδους ενεργών‑δεδομένων για αντικείμενα μορφοποίησης όπως [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) και [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή της κληρονόμησης και των παρακάμψεων.