---
title: Διαχείριση Θεμάτων Παρουσίασης στο Android
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/androidjava/presentation-theme/
keywords:
- Θέμα PowerPoint
- θέμα παρουσίασης
- θέμα διαφάνειας
- ορισμός θέματος
- αλλαγή θέματος
- διαχείριση θέματος
- εξωτερικό θέμα
- THMX
- χρώμα θέματος
- πρόσθετη παλέτα
- γραμματοσειρά θέματος
- στυλ θέματος
- εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχείριση κύριων θεμάτων παρουσίασης στο Aspose.Slides για Android μέσω Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εμπορική σήμανση."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ υποβάθρου, γεμίσματα, γραμμές και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτούς τους κοινόχρηστους ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), ενώ ένα layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα της μέσω [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παρακάμψη master, παρακάμψη layout και παρακάμψη διαφάνειας.

![Συστατικά θέματος: χρώματα, γραμματοσειρές, στυλ υποβάθρου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με το θέμα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ υποβάθρου και εφέ, και ανάγνωση των αποτελεσματικών τιμών μετά την επίλυση κληρονομίας και παρακάμψεων.

## **Επισκόπηση ενός Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) αποκαλύπτει το σχήμα χρωμάτων, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης του θέματος μέσω [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ υποβάθρου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένες στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρχουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Γεμίσματα, γραμμές και κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), όλα τα αντικείμενα που ακόμη αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

Το παρακάτω παράδειγμα από άκρη σε άκρη δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ξαναφορτώνει και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μεταγενέστερες αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Πρόσθετη Παλέτα**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτά και πιο σκούρα χρώματα που δημιουργούνται από την πρόσθετη παλέτα](additional-palette-colors.png)

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

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) αποκαλύπτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) και [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά Κυρίως Κειμένου Λατινική (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά Επικεφαλίδας Λατινική (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά Κυρίως Κειμένου Ανατολική Ασία (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά Επικεφαλίδας Ανατολική Ασία (Major East Asian Font)
* `+mn-cs` - Γραμματοσειρά Κυρίως Κειμένου Συμπλόκειο (Minor Complex Script Font)
* `+mj-cs` - Γραμματοσειρά Επικεφαλίδας Συμπλόκειο (Major Complex Script Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή κυρίως κειμένου που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη κύρια γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη δευτερεύουσα γραμματοσειρά. Το κείμενο που έχει σαφές όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως Κυριλλικά, Αραβικά, Ιαπωνικά, Γεωργιανά και Θάνα. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **Επίλυση Αναφορών Γραμματοσειρών Θέματος**

Κατά την επιθεώρηση κειμένου, η μέθοδος [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) μπορεί να επιστρέψει μια αναφορά θέματος όπως `+mn-lt` αντί για όνομα οικογένειας γραμματοσειράς. Καλέστε [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) με το κατάλληλο [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) για να επιλύσετε αυτή την αναφορά. Τα πρόθεμα `+mj` και `+mn` επιλέγουν τα κύρια και δευτερεύοντα σύνολα γραμματοσειρών· τα επιθήματα `-lt`, `-ea` και `-cs` επιλέγουν τις λατινικές, Ανατολικές Ασιατικές και Συμπλόκειες γραμματοσειρές αντίστοιχα.

Αποκτήστε το αποτελεσματικό θέμα μέσω [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) στο αντικείμενο του οποίου το θέμα εφαρμόζεται στο επιθεωρούμενο κείμενο. Για απλό κείμενο σε διαφάνεια, καλέστε αυτή τη μέθοδο στη διαφάνεια ώστε το περιβάλλον να περιλαμβάνει το κληρονομημένο θέμα της διαφάνειας και τις τοπικές παρακάμψεις. Όταν επιθεωρείτε ένα layout ή master, χρησιμοποιήστε το δικό του αποτελεσματικό θέμα. Μην υποθέτετε ότι το θέμα του πρώτου master ισχύει για κάθε διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα κειμένου που αναφέρει ρητά τη δευτερεύουσα λατινική γραμματοσειρά. Αρχικοποιεί ένα σχήμα γραμματοσειρών διαφάνειας μέσω [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) και ορίζει τις κύριες και δευτερεύουσες λατινικές οικογένειες σε `Arial` και `Calibri`, ώστε το αποτέλεσμα να είναι αναπαράξιμο χωρίς αρχικό αρχείο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `+mn-lt -> Calibri` ακολουθούμενη από `Verdana -> Verdana`. Η αποθηκευμένη αναφορά παραμένει αμετάβλητη, ενώ ένα ρητό όνομα οικογένειας επιστρέφεται όπως είναι. Εάν το τμήμα χρησιμοποιούσε `+mj-lt`, θα είχε επιλυθεί σε `Arial` σε αυτό το θέμα.

Η επίλυση μιας αναφοράς θέματος προσδιορίζει την οικογένεια γραμματοσειράς που καθορίζεται από το θέμα. Δεν ελέγχει τη διαθεσιμότητα της γραμματοσειράς ούτε καθορίζει το αρχείο γραμματοσειράς που τελικά χρησιμοποιείται μετά την αντικατάσταση ή την εναλλακτική αναπαράσταση κατά τη δημιουργία. Δείτε τη [Font Selection Sequence](/slides/el/androidjava/font-selection-sequence/) και την [Font Substitution](/slides/el/androidjava/font-substitution/) για αυτά τα ξεχωριστά βήματα.

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτώμενες από Master**

Χρησιμοποιήστε [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) που υλοποιεί την [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες λειτουργίες:

1. Δημιουργεί μια νέα διαφάνεια master βασισμένη στον επιλεγμένο master.  
1. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια master.  
1. Αντιστοιχίζει τη νέα διαφάνεια master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.  
1. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

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

Ένα άκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχονται από τους χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων, και αποθηκεύστε την παρουσίαση μόνο μετά την επιτυχή εφαρμογή του θέματος.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επαναανατίθενται. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα υπόβαθρα και τα εφέ που είναι ευαίσθητα στο θέμα επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα και άλλες άμεσες μορφοποιήσεις που έχουν οριστεί άμεσα μπορεί να παραμείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο layout ή διαφάνειας μπορούν επίσης να προτεραιοποιήσουν τις τιμές που κληρονομούνται από τον νέο master.

Το θέμα μπορεί να αναφέρει γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή αποτύπωση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, προσφέρετέ τες μέσω [custom font sources](/slides/el/androidjava/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/androidjava/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας επιπέδου master: η μέθοδος δέχεται μια διαδρομή αρχείου `.thmx` και δεν απαιτεί χειροκίνητη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Με Πολλούς Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) και [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

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

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από `firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Πηγής Θέματος κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχεδιασμό, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) και τον κλωνοποιημένο master. Έτσι μεταφέρονται μαζί του ο master, τα layout του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται το ίδιο στην προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν ανεξάρτητο master προορισμού μπορεί να αλλάξει τα χρώματα, τις γραμματοσειρές, τα υπόβαθρα και τα εφέ που εξαρτώνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Εάν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και layout της, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παρακάμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από αυτή τη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομασμένες τιμές, καλέστε [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Εφαρμογή Παρακάμψης Θέματος σε Layout**

Μια παρακάμψη σε επίπεδο layout εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνο το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται τον ίδιο βασικό σχεδιασμό, μια παρακάμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετική μορφοποίηση, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Η υπερβολική χρήση παρακάμψεων σε επίπεδο διαφάνειας καθιστά πιο δύσκολη την πρόβλεψη μετέπειτα παγκόσμιων αλλαγών θέματος.


<!-- visual-explanation:presentation-theme:start -->
[![Ένας master theme τροφοδοτεί δύο layouts· μια παρακάμψη layout επηρεάζει τις διαφάνειές του εκτός από μια διαφάνεια με πιο τοπική παρακάμψη.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Μια παρακάμψη layout εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνο το layout εκτός εάν μια διαφάνεια παρέχει τη δική της παρακάμψη. Οι τιμές βασισμένες σε θέμα ακολουθούν το επιλυμένο σχήμα τους· αντικείμενα που έχουν μορφοποιηθεί ρητά μπορούν να διατηρήσουν την τοπική εμφάνισή τους. Κρατήστε τις παρακάμψεις όσο το δυνατόν πιο περιορισμένες ώστε να ταιριάζουν με την προγραμματισμένη εξαίρεση σχεδίου.* 
<!-- visual-explanation:presentation-theme:end -->

## **Ενημέρωση Στυλ Υποβάθρου Θέματος**

Τα γεμίσματα υποβάθρου του θέματος αποθηκεύονται στο [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές υποβάθρου στη διεπαφή του από τον αριθμό των γεμισμάτων που αποθηκεύονται πραγματικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ υποβάθρου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ υποβάθρου, επιθεωρήστε τη αποθηκευμένη συλλογή και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει γεμιστικό θέμα· θετικές τιμές είναι αναφορές στυλ υποβάθρου θέματος. Αυτό διαφέρει από την ευθεία δεικτωση της συλλογής Java, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος υποβάθρου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων υποβάθρου, εκχωρεί μια αναφορά θεματικού υποβάθρου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος στην οποία αναφέρεται ο master και από τυχόν παρακάμψεις υποβάθρου σε επίπεδο layout ή διαφάνειας. Εάν μια διαφάνεια χρησιμοποιεί το δικό της υπόβαθρο, η αλλαγή μόνο του υπόβαθρου του master μπορεί να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό υπόβαθρο μετά την εφαρμογή της κληρονομίας.

{{% alert color="warning" title="Warning" %}}
Μην αντιμετωπίζετε τον δείκτη στυλ ως δείκτη μηδενικής βάσης. Επίσης αποφύγετε την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση υποβάθρου και κληρονομία υποβάθρου, δείτε [Presentation Background](/slides/el/androidjava/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιέχει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), και [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε ήπιες, μέτριες και έντονες μορφοποιήσεις, αλλά ο κώδικας θα πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Ήπια, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελαυνείτε αυτές τις συλλογές σε Java, ο δείκτης της συλλογής είναι μηδενική βάση: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει ότι υπάρχουν οι απαιτούμενες καταχωρίσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται συμπαγές δάσος πράσινο, και το τρίτο στυλ εφέ προσθέτει μια εξωτερική σκιά με απόσταση 10 μονάδες. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέση στυλ αναφέρεται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρυθμίσεων σκιάς](presentation-design_11.png)

## **Επιλογή Στυλ Γεμίσματος και Γραμμής Θέματος για Σχήμα**

Ένα σχήμα μπορεί να επιλέξει το γέμισμα και το περίγραμμα του ανεξάρτητα μέσω [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) και [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Για κάθε μέθοδο, ο δείκτης `1` επιλέγει την πρώτη καταχώρηση στην αντίστοιχη συλλογή θέματος (`get_Item(0)`), και ο δείκτης `2` επιλέγει τη δεύτερη (`get_Item(1)`).

Το παρακάτω παράδειγμα δημιουργεί δύο στυλ γεμίσματος (χρυσό και γαλάζιο) και δύο στυλ γραμμής (σκούρο μπλε 6 pt και σκούρο κόκκινο 12 pt) στο προεπιλεγμένο θέμα μιας νέας παρουσίασης. Αποθηκεύει τη διαφάνεια σε τρία στάδια ώστε να μπορείτε να συγκρίνετε τα αποτελέσματα στο PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Αρχικά στυλ | Αλλαγή του δεξιού περιγράμματος | Επεξεργασία του πρώτου γεμίσματος θέματος |
|:---:|:---:|:---:|
| ![Χρυσά και γαλάζια ορθογώνια με αντίστοιχα λεπτά σκούρα μπλε περιγράμματα](theme-style-initial.png) | ![Το γαλάζιο ορθογώνιο τώρα έχει παχύ σκούρο κόκκινο περίγραμμα](theme-style-line-changed.png) | ![Το αριστερό ορθογώνιο γίνεται πράσινο και και τα δύο περιγράμματα παραμένουν αμετάβλητα](theme-style-fill-changed.png) |

Η επιλογή διαφορετικού στυλ γραμμής αλλάζει μόνο το περίγραμμα του δεξιού ορθογωνίου. Η επεξεργασία του πρώτου γεμίσματος θέματος ενημερώνει κάθε σχήμα που το χρησιμοποιεί. Εδώ, μόνο το αριστερό ορθογώνιο γίνεται πράσινο.

Σε ένα υπάρχον σχήμα, ένα τοπικό χρώμα γεμίσματος, χρώμα γραμμής ή πλάτος γραμμής μπορεί να παρακάμψει αυτό το μέρος του στυλ θέματος. Εάν η αλλαγή ενός δείκτη στυλ δεν έχει ορατό αποτέλεσμα, ελέγξτε τη [direct formatting](/slides/el/androidjava/shape-formatting/).

## **Καθορισμός Εάν ένα Αποτελεσματικό Στερεό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί άμεσα σε αντικείμενο ή να κληρονομηθεί από παράγραφο, layout, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) για να επιλύσετε αυτήν την ιεραρχία σε αμετάβλητα [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Πρώτα ελέγξτε [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Μόνο όταν είναι `FillType.Solid` πρέπει να διαβάσετε τις ιδιότητες στερεού γεμίσματος.

Για στερεό γέμισμα, η μέθοδος [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) επιστρέφει την τελική τιμή RGB μετά την κληρονομία, την αναζήτηση θέματος και τους μετασχηματισμούς χρώματος. Η μέθοδος [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) επιστρέφει την αντίστοιχη λογική θέση [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε χρώμα σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσα χρώματα RGB, αυτή η τιμή προσδιορίζει ένα άμεσο RGB γέμισμα.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) για την ταξινόμηση ενός γεμίσματος. Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική του τιμή είναι `NotDefined`, ενώ το αποτελεσματικό του γέμισμα κληρονομεί ένα χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντίστροφα, η `getSolidFillSchemeColor` σας λέει ποιο λογικό slot θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν λέει αν αυτό το slot προήλθε από το αντικείμενο, την παράγραφο, το layout, το master ή κάποιο άλλο επίπεδο της ιεραρχίας μορφοποίησης.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τα γεμίσματα σχήματος και τα γεμίσματα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και το σχετικό χρώμα σχήματος, και σηματοδοτεί στερεά γεμίσματα που δεν θα παρακολουθούν αλλαγές χρώματος θέματος:

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

Το κλαδί `NotDefined` παρέχει λίστα ελέγχου στερεών γεμισμάτων που δεν θα ανταποκριθούν σε αλλαγές στις θέσεις χρώματος θέματος. Εξετάστε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθεί μια νέα παλέτα εταιρικής ταυτότητας. Η αναφερόμενη τιμή RGB παραμένει η τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση είναι συνδεδεμένη με το θέμα.

Τα αντικείμενα αποτελεσματικού-μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά `getEffective` και διαβάστε ένα νέο αντικείμενο `IFillFormatEffectiveData` πριν συγκρίνετε ή αναφέρετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα αψομεγέθη αντικειμένων θέματος σας λένε τι είναι ορισμένο σε κάποιο επίπεδο. Οι αποτελεσματικές τιμές σας δείχνουν τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομία και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Για ένα υπόβαθρο, χρησιμοποιήστε [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), και για ένα γέμισμα, χρησιμοποιήστε [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το υπόβαθρο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικά απόδοσης, επικύρωση και συγκρίσεις. Εάν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), μπορεί να χάσετε μια παρακάμψη master, layout, διαφάνειας ή σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Εφαρμόζει ένα εξωτερικό θέμα κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η μέθοδος [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) επαναορίζει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το override theme της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματά τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφερθεί ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και διατήρηση της αρχικής εμφάνισης, κλώνος τον πηγαίο master στην προορισμό και κλώνος τη διαφάνεια με αυτόν τον master χρησιμοποιώντας [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) και [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Αυτό διατηρεί τον master, τα layout και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομία και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) για μια διαφάνεια ή θέμα layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την κληρονομία και τις παρακάμψεις.