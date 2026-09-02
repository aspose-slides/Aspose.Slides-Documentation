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
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης καθορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ υποβάθρων, γεμισμάτων, γραμμών και εφέ. Τα αντικείμενα που γνωρίζουν το θέμα αναφέρονται σε αυτούς τους κοινά ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως στατική τιμή, έτσι μια αλλαγή θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα επιπέδου παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterthememanager/), ενώ ένα layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη layout και παράκαμψη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ υποβάθρων και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με θέματα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή ενός θέματος, ενημέρωση στυλ υποβάθρων και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) εκθέτει το σχήμα χρωμάτων, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των εγγραφών στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ υποβάθρου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένες στο θέμα:

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

Εάν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Ελέγξτε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που παρουσιάζεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρχουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που γνωρίζουν το θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώριση στην [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν επηρεάζονται από την ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μελλοντικές αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Πρόσθετη Παλέτα**

Το PowerPoint παράγει ελαφρύτερες και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/java/com.aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ελαφρύτερα και σκούρα χρώματα που δημιουργούνται από την πρόσθετη παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Ελαφρύτερες και σκούρες παραλλαγές που προκύπτουν από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή `Accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν πρόκειται για τιμές που μετατρέπονται δυναμικά.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κείμενο σώματος. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θέματος συμβατές με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη κύρια γραμματοσειρά Latin του θέματος και μία γραμμή κειμένου σώματος που χρησιμοποιεί τη δευτερεύουσα γραμματοσειρά Latin. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη κύρια γραμματοσειρά και το κείμενο σώματος ακολουθεί τη δευτερεύουσα γραμματοσειρά. Το κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειράς θέματος.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά και Θαάνα. Για να επιθεωρήσετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίσεις, δείτε [Script-Specific Theme Fonts](/slides/el/java/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/java/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Master**

Χρησιμοποιήστε [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) όταν έχετε αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να αλλάξετε το στυλ κάθε διαφάνειας που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) που υλοποιεί την [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες λειτουργίες:

1. Δημιουργεί μια νέα master διαφάνεια βασισμένη στον επιλεγμένο master.
1. Εφαρμόζει το εξωτερικό θέμα στη νέα master.
1. Εκχωρεί τη νέα master σε όλες τις διαφάνειες που παλαιότερα εξαρτώνταν από τον επιλεγμένο master.
1. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχονται από χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμόστηκε επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επαναανατίθενται. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα υποβάθρα και τα εφέ που γνωρίζουν το θέμα επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα και άλλες άμεσες μορφοποιήσεις που έχουν οριστεί ρητά ενδέχεται να παραμείνουν αμετάβλητα. Παρακάμψεις σε επίπεδο layout ή διαφάνειας μπορούν επίσης να προεξέχουν πάνω από τις τιμές που κληρονομούνται από τον νέο master.

Το θέμα μπορεί να αναφέρει γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τες μέσω [custom font sources](/slides/el/java/custom-font/), ή ρυθμίστε [font substitution](/slides/el/java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί χειροκίνητη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, λάβετε τον από μια αντιπροσωπευτική διαφάνεια μέσω [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) και [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από `firstGroupMaster`, ενώ η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από `secondGroupMaster`. Διαφάνειες που ανήκουν σε άλλον master δεν επανεμφανίζονται.

### **Διατήρηση Πηγής Θέματος Κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχεδιασμό, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει τον master, τα layout του και το σχετικό θέμα μαζί.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν μη σχετικό master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, υποβάθρα και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Αν η στοχευμένη διαφάνεια πρέπει να παραμείνει στον τρέχοντα master και layout, αρχικοποιήστε μια τοπική παράκαμψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παράκαμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από αυτή τη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε τη τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε [OverrideTheme.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/).

### **Εφαρμογή Παράκαμψης Θέματος σε Layout**

Μια παράκαμψη σε επίπεδο layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνο το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε θέμα master ή παρουσίασης όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται τον ίδιο βασικό σχεδιασμό, μια παράκαμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παρακάμψεις σε επίπεδο διαφάνειας κάνουν τις μελλοντικές παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Υποβάθρων Θέματος**

Τα γεμίσματα υποβάθρου του θέματος αποθηκεύονται στη [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές υποβάθρου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που είναι φυσικά αποθηκευμένοι σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ υποβάθρου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ υποβάθρου, επιθεωρήστε τη συλλογή που είναι αποθηκευμένη και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/). Δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές στυλ υποβάθρου θέματος. Αυτό διαφέρει από την ευθεία αρίθμηση της συλλογής Java, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος υποβάθρου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων υποβάθρου, εκχωρεί μια θεματική αναφορά υποβάθρου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις υποβάθρου σε επίπεδο layout ή διαφάνειας. Εάν μια διαφάνεια χρησιμοποιεί το δικό της υπόβαθρο, η αλλαγή μόνο του υποβάθρου του master μπορεί να μην αλλάξει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό υπόβαθρο μετά την κληρονομικότητα.

{{% alert color="warning" title="Προειδοποίηση" %}}
Μην αντιμετωπίζετε τον δείκτη στυλ ως δείκτη μηδενικής βάσης σε συλλογή. Αποφύγετε επίσης την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}
Για άμεση μορφοποίηση υποβάθρου και κληρονομικότητα υποβάθρου, δείτε [Presentation Background](/slides/el/java/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/), και [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Τα τυπικά θέματα Office συχνά περιλαμβάνουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονη μορφοποίηση, αλλά ο κώδικας θα πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει έναν σταθερό αριθμό.

![Ήπια, μέτρια και έντονα εφέ θέματος εφαρμοσμένα στο ίδιο σχήμα](presentation-design_10.png)

Κατά την πρόσβαση στις συλλογές αυτές σε Java, ο δείκτης συλλογής είναι μηδενική βάση: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, που εκτίθεται μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες καταχωρίσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται στερεό δάση πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμη από το ποια θέσεις στυλ κάθε σχήμα αναφέρει και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρύθμισης σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι είναι ορισμένο σε συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή ένα σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Για ένα υπόβαθρο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/), και για ένα γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το υπόβαθρο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικές απεικονίσεις, επικυρώσεις και συγκρίσεις. Εάν επιθεωρείτε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), μπορεί να χάσετε έναν master, layout, διαφάνεια ή παράκαμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Σ/Α**

**Επηρεάζει η εφαρμογή ενός εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η μέθοδος [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) επαναντιστοιχίζει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παρακαμψής της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφερθεί ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/) και [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/). Αυτό διατηρεί μαζί τον master, τα layout και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/) για μια διαφάνεια ή layout θέμα και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την κληρονομικότητα και τις παρακάμψεις.