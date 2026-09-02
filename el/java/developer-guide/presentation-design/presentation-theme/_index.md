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
- Πρόσθετο παλέτο
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Java
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Java για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εταιρική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμισμάτων, γραμμών και εφέ. Τα αντικείμενα που είναι «theme‑aware» αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω του [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterthememanager/), ενώ μια διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονόμησης: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο κοινές ροές εργασίας για θέματα: επισκόπηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονόμηση και τις παρακάμψεις.

## **Επισκόπηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) εκθέτει το χρωματικό σχήμα του θέματος, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης μέσω των μεθόδων [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν τις τροποποιήσετε είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επισκοπήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που εμφανίζεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι «theme‑aware» μπορούν να αναφέρονται σε ένα λογικό χρώμα από την αρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί το `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μελλοντικές αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Πρόσθετο Παλέτο**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες εκδοχές ενός χρώματος θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της αρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/java/com.aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτές/σκούρες εκδοχές που δημιουργούνται από το πρόσθετο παλέτο](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.  

**2** – Πιο ανοιχτές και πιο σκούρες εκδοχές που παράγονται από τα κύρια χρώματα θέματος.

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

Αυτές οι εκδοχές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η αρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για κείμενο σώματος. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn‑lt` – Γραμματοσειρά Σώματος Λατινικό (Minor Latin Font)  
* `+mj‑lt` – Γραμματοσειρά Επικεφαλίδας Λατινικό (Major Latin Font)  
* `+mn‑ea` – Γραμματοσειρά Σώματος Ανατολικού Ασιατικού (Minor East Asian Font)  
* `+mj‑ea` – Γραμματοσειρά Επικεφαλίδας Ανατολικού Ασιατικού (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή σώματος που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη κύρια γραμματοσειρά και το σώμα το κείμενο ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για αναγνωριστή θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά και θάνα. Για να επιθεωρήσετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίσεις, δείτε το άρθρο [Script‑Specific Theme Fonts](/slides/el/java/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το άρθρο [PowerPoint Fonts](/slides/el/java/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα που αφορούν θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Master**

Χρησιμοποιήστε το [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.getMasters](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες λειτουργίες:

1. Δημιουργεί ένα νέο master slide βασισμένο στον επιλεγμένο master.  
1. Εφαρμόζει το εξωτερικό θέμα στο νέο master.  
1. Αναθέτει το νέο master σε όλες τις διαφάνειες που πριν εξαρτώνταν από τον επιλεγμένο master.  
1. Επιστρέφει το νέο [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/).

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

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxreadexception/). Επαληθεύστε τις διαδρομές που παρέχονται από χρήστες, χειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επαναχρεώνονται. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα. Τα χρώματα, οι γραμματοσειρές, τα γέμισματα, οι γραμμές, τα φόντα και τα εφέ που είναι «theme‑aware» επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, γραμματοσειρές, γέμισματα κ.λπ. που έχουν οριστεί άμεσα μπορεί να παραμείνουν αμετάβλητα. Παρακάμψεις σε επίπεδο διάταξης ή διαφάνειας μπορούν επίσης να προτιμηθούν έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφορά σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον χρόνου εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τες μέσω [custom font sources](/slides/el/java/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας επιπέδου master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί χειροκίνητη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή διάταξης.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) και του [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

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

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `secondGroupMaster`. Διαφάνειες που ανήκουν σε οποιοδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Πρώτου Θέματος κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχεδιασμό, κλωνοποιήστε τον source master στην προοριστική παρουσίαση με το [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/), έπειτα κλωνοποιήστε τη διαφάνεια με το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει τον master, τις διατάξεις του και το σχετικό θέμα μαζί.

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

Αυτή είναι η προτεινόμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται ακριβώς το ίδιο στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν αδιάσπαστο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντα και εφέ που ελέγχονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρουσα Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξη, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παρακάμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από τη συγκεκριμένη διαφάνεια χωρίς να επηρεάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/overridetheme/).

### **Εφαρμογή Παράκαμψης Θέματος σε Διάταξη**

Μια παρακάμψη επιπέδου διάταξης εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός αν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις επιπέδου διαφάνειας καθιστούν τις μελλοντικές παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γεμίσματα φόντου του θέματος αποθηκεύονται στο [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή χρήστη του απ’ ότι ο αριθμός των γεμισμάτων που είναι φυσικά αποθηκευμένα σε αυτή τη συλλογή, επειδή η UI μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που είναι αποθηκευμένη και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θέματος γέμισμα· θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την απευθείας χρήση του δείκτη στη συλλογή Java, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου γεμίσματος.

Το παρακάτω παράδειγμα αναφέρει τον αριθμό των διαθέσιμων γεμισμάτων φόντου, εκχωρεί μια αναφορά φόντου θέματος στο πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου σε επίπεδο διάταξης ή διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου master μπορεί να μην επηρεάσει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό φόντο μετά την εφαρμογή της κληρονόμησης.

{{% alert color="warning" title="Προειδοποίηση" %}}

Μην αντιμετωπίζετε τον δείκτη στυλ ως δείκτη μηδενικής βάσης μιας συλλογής. Αποφύγετε επίσης τον σκληρό κωδικό ενός αριθμού στυλ από ένα αρχείο ελπίζοντας ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}

Για άμεση μορφοποίηση φόντου και κληρονόμηση φόντου, δείτε το άρθρο [Presentation Background](/slides/el/java/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/) και [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/java/com.aspose.slides/iformatscheme/). Τα τυπικά θέματα του Office συχνά περιλαμβάνουν τρεις κύριες καταχωρήσεις στυλ που αντιστοιχούν οπτικά σε διακριτά, μέτρια και έντονα μορφοποιήσεις, αλλά ο κώδικας θα πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Διακριτά, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν έχετε πρόσβαση σε αυτές τις συλλογές στην Java, ο δείκτης συλλογής είναι μηδενικός: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες καταχωρήσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται αμοιβαία πράσινο δάσος, και το τρίτο στυλ εφέ προσθέτει εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποιες θέσεις στυλ αναφέρεται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Προσδιορισμός Εάν ένα Αποτελεσματικό Στερεό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να αποθηκευτεί άμεσα σε ένα αντικείμενο ή να κληρονομείται από παράγραφο, διάταξη, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε το [IFillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformat/) για να επιλύσετε αυτήν την ιεραρχία σε αμετάβλητα [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/). Πρώτα ελέγχετε το [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/). Μόνο όταν είναι `FillType.Solid` πρέπει να διαβάζετε τις ιδιότητες στερεού γεμίσματος.

Για στερεό γέμισμα, το [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/) επιστρέφει την τελική απόδοση τιμής RGB μετά την κληρονόμηση, την αναζήτηση θέματος και την εφαρμογή μετασχηματισμών χρώματος. Το [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/) επιστρέφει την αντίστοιχη λογική θέση [SchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/schemecolor/), όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor.NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε χρώμα σχήματος. Σε μία ροή εργασίας όπου τα γέμισματα είναι είτε χρώματα θέματος είτε άμεσες τιμές RGB, αυτή η τιμή ενδείκνυει άμεσο γέμισμα RGB.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorformat/) για την ταξινόμηση ενός γεμίσματος. Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική τιμή είναι `NotDefined`, ενώ το αποτελεσματικό του γέμισμα κληρονομεί ένα χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντιθέτως, το `getSolidFillSchemeColor` σας λέει ποιο λογικό slot του θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν σας λέει από ποιο επίπεδο (αντικείμενο, παράγραφος, διάταξη, master ή άλλο) προέρχεται.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τόσο τα γέμισμα σχήματος όσο και τα γέμισμα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και το σχετικό χρώμα σχήματος, και επισημαίνει στερεά γέμισμα που δεν θα παρακολουθεί αλλαγές χρωμάτων θέματος:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

Το κλαδί `NotDefined` παρέχει μια λίστα ελέγχου στερεών γεμισμάτων που δεν θα ανταποκριθούν σε αλλαγές στις θέσεις χρωμάτων θέματος. Ελέγξτε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθήσει ένα νέο χρωματικό παλέτα μάρκας. Η αναφερθείσα τιμή RGB εξακολουθεί να εμφανίζει την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση είναι συνδεδεμένη με το θέμα.

Τα αντικείμενα αποτελεσματικής μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `getEffective` και διαβάστε ένα νέο αντικείμενο `IFillFormatEffectiveData` πριν συγκρίνετε ή καταγράψετε χρώματα.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι είναι ορισμένο σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονόμηση και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/). Για φόντο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/), και για γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικούς σκοπούς απόδοσης, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), μπορεί να χάσετε έναν master, διάταξη, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή ενός εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) επανεκχωρεί μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παρακάμψη θέματος. Η αλλαγή παραμένει τοπική σ’ αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από την μια παρουσίαση στην άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον source master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/) και [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/). Αυτό κρατά μαζί τον master, τις διατάξεις και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονόμηση και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονόμησης και παρακάμψεων.