---
title: Διαχείριση Θεμάτων Παρουσίασης στο Android
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης στο Aspose.Slides για Android μέσω Java για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπές σήμα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι ενημερωμένα με θέμα αναφέρονται σε αυτούς τους κοινά ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή του θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω του [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterthememanager/), ενώ ένα layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη layout και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες εμφανίζουν τις πιο κοινές ροές εργασίας με θέματα: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονόμηση και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mastertheme/) εκθέτει το χρωματικό σχήμα, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν από τις αλλαγές είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρει.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένα στο θέμα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Εάν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που εμφανίζεται παρακάτω στο άρθρο όταν μπορεί να υπάρξουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι θέμα‑aware μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στην [IColorScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icolorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μετέπειτα αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Πρόσθετη Παλέτα**

Το PowerPoint δημιουργεί πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτά/σκοτεινά χρώματα που προκύπτουν από την πρόσθετη παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [IColorScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτές είναι εναλλακτικές ονομασίες για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μια μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα σύνολο κυρίων γραμματοσειρών για τίτλους και ένα σύνολο δευτερευόντων γραμματοσειρών για το κύριο κείμενο. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontscheme/) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θέματος συμβατές με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά σώματος Latin (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά τίτλου Latin (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά τίτλου East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί έναν τίτλο που χρησιμοποιεί τη βασική γραμματοσειρά Latin του θέματος και μια γραμμή σώματος που χρησιμοποιεί τη δευτερεύουσα γραμματοσειρά Latin του θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Ο τίτλος ακολουθεί τη βασική γραμματοσειρά και το κείμενο σώματος ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτοποιητή θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι συλλογές βασικών και δευτερευόντων γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό και θάανα. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα που σχετίζονται με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτημένες από Master**

Χρησιμοποιήστε το [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) που υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/) και περάστε το μονοπάτι του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες εργασίες:

1. Δημιουργεί μια νέα διαφάνεια master βάσει του επιλεγμένου master.  
1. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια master.  
1. Εκχωρεί τη νέα διαφάνεια master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.  
1. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/).

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

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxreadexception/). Επικυρώστε τα μονοπάτια που παρέχονται από τους χρήστες, χειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα έχει εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επανατοποθετούνται. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα φόντα και τα εφέ που είναι θέμα‑aware επιλύονται βάσει του εξωτερικού θέματος. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα και άλλες άμεσες μορφοποιήσεις ενδέχεται να παραμείνουν αμετάβλητα. Παρακάμψεις σε επίπεδο layout ή διαφάνειας μπορούν επίσης να προτεραιοποιηθούν έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφέρεται σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τις μέσω [custom font sources](/slides/el/androidjava/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/androidjava/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται το μονοπάτι ενός αρχείου `.thmx` και δεν απαιτεί τη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση με Πολλαπλούς Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/) και του [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

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

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `firstGroupMaster`, ενώ η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανεμφανίζονται.

### **Διατήρηση Πρώτου Θέματος Κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον master της πηγής στην παρουσίαση-στόχο με το [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του το master, τα layouts του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να διατηρήσει την ίδια εμφάνιση στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν άσχετο master προορισμού μπορεί να αλλάξει τα χρώματα, τις γραμματοσειρές, τα φόντα και τα εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Εάν η διαφάνεια‑στόχος πρέπει να παραμείνει στον τρέχοντα master και layout της, αρχικοποιήστε μια παρακάμψη σε επίπεδο διαφάνειας από το θέμα πηγής. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παρακάμψη.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να καταργήσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/overridetheme/).

### **Εφαρμογή Παρακαπήματος Θέματος σε Layout**

Μια παρακάμψη σε επίπεδο layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνο το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Χρησιμοποιήστε θέμα master ή παρουσίασης όταν πολλοί layout και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη layout όταν μια οικογένεια layout απαιτεί διαφορετική μορφοποίηση, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις σε επίπεδο διαφάνειας κάνουν τις μεταγενέστερες παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γεμίσματα φόντου του θέματος αποθηκεύονται στην [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iformatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των πραγματικών ορισμών γεμίσματος που αποθηκεύονται σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που αποθηκεύεται και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει γεμιστό θέμα· θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την απευθείας δεικτοδότηση της συλλογής Java, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος φόντου.

Το παρακάτω παράδειγμα αναφέρει τον αριθμό των διαθέσιμων γεμίσματος φόντου, εκχωρεί μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το εμφανιζόμενο αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου στο layout ή στη διαφάνεια. Εάν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master ενδέχεται να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό φόντο μετά την κληρονόμηση.

{{% alert color="warning" title="Προειδοποίηση" %}}
Μην αντιμετωπίζετε τον δείκτη στυλ ως δείκτη μηδενικής βάσης στη συλλογή. Αποφύγετε επίσης την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}
Για άμεση μορφοποίηση φόντου και κληρονόμηση φόντου, δείτε το [Presentation Background](/slides/el/androidjava/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iformatscheme/), και [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iformatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες καταχωρήσεις στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονη μορφοποίηση, αλλά ο κώδικας πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπια, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές στη Java, ο δείκτης της συλλογής είναι μηδενικής βάσης: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, που εκτίθενται μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες καταχωρήσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται πυκνό δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ αναφέρονται κάθε σχήμα και εάν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή των ρυθμίσεων γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Προσδιορισμός Εάν Ένα Αποτελεσματικό Σταθερό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί απευθείας σε ένα αντικείμενο ή να κληρονομηθεί από μια παράγραφο, layout, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε το [IFillFormat.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformat/) για να επιλύσετε αυτήν την ιεραρχία σε αμετάβλητο [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/). Πρώτα ελέγξτε το [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/). Μόνο όταν είναι `FillType.Solid` πρέπει να διαβάσετε τις ιδιότητες του γεμίσματος στερεού.

Για στερεό γέμισμα, το [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/) επιστρέφει την τελική RGB τιμή μετά την κληρονόμηση, την αναζήτηση θέματος και την εφαρμογή μετασχηματισμών χρώματος. Το [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/) επιστρέφει τη σχετική λογική θέση [SchemeColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/schemecolor/), όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε χρώμα σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσα χρώματα RGB, αυτή η τιμή προσδιορίζει ένα άμεσο γεμιστικό RGB.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icolorformat/) για να ταξινομήσετε ένα γέμισμα. Για παράδειγμα, ένα απόσπασμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική του τιμή είναι `NotDefined`, ενώ το αποτελεσματικό του γέμισμα κληρονομεί χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντίστροφα, το `getSolidFillSchemeColor` σας λέει ποια λογική θέση θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν λέει από ποιο επίπεδο (αντικείμενο, παράγραφος, layout, master κλπ.) προήλθε.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τόσο τα γεμίσματα σχήματος όσο και τα γεμίσματα αποσπασμάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και τη σχετική θέση σχήματος, και σημαδώνει στερεά γεμίσματα που δεν θα παρακολουθούν τις αλλαγές χρωμάτων θέματος:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Το κλαδί `NotDefined` παρέχει μια λίστα ελέγχου στερεών γεμισμάτων που δεν θα ανταποκριθούν στις αλλαγές των θέσεων χρώματος θέματος. Εξετάστε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθήσει μια νέα εταιρική παλέτα. Η αναφερόμενη τιμή RGB εξακολουθεί να δείχνει την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση είναι συνδεδεμένη με το θέμα.

Τα αντικείμενα αποτελεσματικής μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `getEffective` και διαβάστε ένα νέο αντικείμενο `IFillFormatEffectiveData` πριν συγκρίνετε ή αναφέρετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονόμηση και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseoverridethememanager/). Για φόντο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/background/), και για γέμισμα, χρησιμοποιήστε το [FillFormat.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωσμούς απόδοσης, επαλήθευση και συγκρίσεις. Εάν επιθεωρείτε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/), μπορείτε να χάσετε έναν master, layout, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η μέθοδος [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) επανατοποθετεί μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μία μόνο διαφάνεια χωρίς αλλαγή του master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παρακάμψη θέματος. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος να μεταφέρω ένα θέμα από μία παρουσίαση στην άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της πηγαίας εμφάνισης, κλωνοποιήστε τον master πηγής στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/) και [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/). Αυτό διατηρεί μαζί του τον master, τα layouts και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονόμηση και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως [Background.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/background/) και [FillFormat.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/). Αυτές οι API επιστρέφουν τις επιλυμένες τιμές μετά την κληρονόμηση και τις παρακάμψεις.