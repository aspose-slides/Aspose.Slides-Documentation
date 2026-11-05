---
title: Μορφοποίηση Σχημάτων PowerPoint σε Java
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σχεδίου
- γραμμή σχήματος σε στυλ σκίτσο
- μορφοποίηση στυλ σύνδεσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- συμπαγής γέμιση χρώματος
- διαφάνεια σχήματος
- αποτύπωση σχήματος μαυρό‑άσπρη
- αποτύπωση σχήματος σε κλίμακα του γκρι
- περιστροφή σχήματος
- εφέ 3Δ λοξής άκρης
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Java χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint ρυθμίζοντας τα περιγράμματα, τα γέμισμα και τα εφέ τους. Το Aspose.Slides for Java σας επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της τρισδιάστατης διαμόρφωσης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Διαμόρφωση Γραμμών**

Use [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) to control a shape’s outline. This example creates an unfilled rectangle with a blue, dashed outline. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) selects a thick-thin compound line, while [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) sets its width to 7 points and [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) selects the dash pattern.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός Προσαρμοσμένων Μοτίβων Παύσης Γραμμής**

Use [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) when predefined line styles do not provide the dash lengths and gaps you need, for example for branded outlines or technical diagrams. Assigning a pattern automatically changes the line dash style to [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μηκών παύσης και διαστήματος, ξεκινώντας με παύση. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `{ 4, 2 }` σε πλάτος 3 σημείων παράγει παύση 12 σημείων ακολουθούμενη από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα παύσης‑και‑κενών. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε παύση και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε γαλάζιες γραμμές ίσου μήκους και επίπεδων άκρων. Οι τρεις πρώτες συγκρίνουν μοτίβα με πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο με διπλάσιο πλάτος, διπλασιάζοντας τόσο τη διάρκεια της παύσης όσο και του κενού. Η πέμπτη περνά από προσαρμοσμένο μοτίβο σε συμπαγή γραμμή.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Επιστρέψτε την τελευταία γραμμή σε συμπαγή μορφή.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να επιστρέψετε σε ένα προ‑καθορισμένο στυλ παυλών, περάστε το [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) στη [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα παυλών, μια πιο πλατιά γραμμή που χρησιμοποιεί το πρώτο μοτίβο, και μια συμπαγή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Use [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) to set the ends of an open line. The [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) class provides three explicit cap styles:

- `Flat`: Η γραμμή σταματά στο άκρο.
- `Round`: Ένα ημικυκλικό άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.
- `Square`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.

Η κλάση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητά στυλ άκρου.

Τα άκρα διαφέρουν από τα βέλη, τα οποία προσθέτουν σύμβολα στα άκρα της γραμμής, και τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βέλη μέσω των [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) και [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) ώστε να συγκριθούν μόνο τα σχήματα των άκρων.

Το παρακάτω παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές, 20 σημείων πλάτος, διαφορετικά μόνο στα άκρα τους. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round**, και **Square**.

![Επίπεδα, στρογγυλεμένα και τετράγωνα άκρα σε πανομοιότυπες παχείς γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Εφέ Σχέδιας στις Γραμμές Σχήματος**

Ένα εφέ σχέδιας κάνει τη γραμμή του σχήματος να φαίνεται σχεδιασμένη με το χέρι. Use [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) to access the line settings, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) to access the sketch settings, and [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) to select a value from the [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) class.

The following Java code shows how to apply a [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) effect, read the explicitly assigned value, and remove the effect with [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), προσπελάστε το [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πράγματι μετά την επίλυση της κληρονομικότητας. Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Διαμόρφωση Στυλ Συνδέσεων**

Εδώ είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντιούνται σε γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξείες γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 σημείων πλάτος. Χρησιμοποιεί το [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) για να ορίσει τις τιμές miter, bevel και round της [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), αντίστοιχα, ώστε να συγκρίνει τον τρόπο σχεδίασης των γωνιών.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Περιορισμός Στιλ Μίτερ σε Όξιες Γωνίες**

Use [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) with [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) set to [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) to limit how far a sharp corner can extend.

Ο περιορισμός είναι ένα ποσοστό της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος μίτερ μέχρι οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία θα έπαιρνε πάνω από το όριο, το PowerPoint χρησιμοποιεί μια λοξή σύνδεση σε εκείνη τη γωνία. Μεγαλύτερο όριο επιτρέπει πιο οξείς άκρα. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις μίτερ και η αλλαγή της δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμένει εντός των δύο ορίων.

Αυτό το παράδειγμα δημιουργεί δύο ίσες, μη γεμιστές τρίγωνα με περιγράμματα 20 σημείων πλάτος. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, και το δεξιό `8`. Κάθε τρίγωνο έχει πλάτος 80 σημείων και ύψος 160 σημείων, δίνοντας στην κορυφαία γωνία του ένα λόγο μήκους μίτερ‑πλάτους περίπου `4.12`. Συνεπώς, το PowerPoint λοξοποιεί την αριστερή άκρη και διατηρεί την δεξιά.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![Μία λοξή άκρη με όριο μίτερ 2 και μία αιχμηρή άκρη με όριο μίτερ 8 στο PowerPoint](miter-limits.png)

## **Γέμιση Διαβάθμισης**

Μία γέμιση διαβάθμισης αναμειγνύει χρώματα σε ένα σχήμα. Αυτό το παράδειγμα γεμίζει ένα έλλειψο με γραμμική διαβάθμιση 45 μοιρών από κόκκινο σε μοβ χρησιμοποιώντας το [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Η μέθοδος [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) τοποθετεί τα χρωματικά στάδια στα 0 και 1, στην αρχή και στο τέλος της διαβάθμισης. Η εκκαθάριση των υφιστάμενων σταδίων διασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το έλλειψο με γέμιση διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε μια εξαγόμενη εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση που αποθηκεύεται στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Διαβάθμισης**

Use [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) to control the orientation of a [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) fill. The angle is measured in degrees and increases clockwise: `0` runs from left to right, `90` from top to bottom, `180` from right to left, and `270` from bottom to top. Fractional angles are supported. Finite angles outside `[0, 360)` are normalized to one revolution; for example, `-45` becomes `315` and `360` becomes `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με ίδιους κόκκινους, πράσινους και μπλε σταθμούς στις θέσεις `0`, `0.5` και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς τα δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα στο PowerPoint:

![Γραμμικές διαβάθμιση στις γωνίες 0, 45 και 90 στην πάνω σειρά, και 135, 180 και 270 στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) accepts a [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) value. Set it explicitly to `False` to keep the geometric gradient angle as the shape's proportions change, or to `True` to scale the gradient with the shape's width and height. With scaling enabled, the visible angle can differ from the assigned angle on a non-square shape.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια χρωματικά στάδια με τη σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά `True`. Κάθε στήλη περιέχει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και τα δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς το γέμισμα αντιδρά σε αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις της διαβάθμισης.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργοποιημένη στα δεξιά:

![Πλατιά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, συγκρίνοντας LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν την ίδια προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν το σχήμα προσαρμόζεται σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της διαβάθμισης 45 μοιρών.

Τanto η γωνία όσο και η κλιμάκωση εφαρμόζονται σε γραμμικές διαβαθμίσεις. Δεν ελέγχουν τις διαβαθμίσεις [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) selects a gradient style from the [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) class; it is not a substitute for a numeric angle. For a linear gradient, the corner styles can change the area over which the colors are distributed without changing the angle assigned through [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Keep the direction unchanged when comparing angles or scaling.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γέμιση Καταλόγου**

Μια γέμιση κατάλογου εφαρμόζει σχέδιο δύο χρωμάτων, όπως κουκίδες, ρίγες ή τετράγωνα. Αυτό το παράδειγμα χρησιμοποιεί το [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) για να επιλέξει μοτίβο πλέγματος. Το [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) δίνει το ανοιχτό γκρι φόντο, και το [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) δίνει το κίτρινο χρώμα του μοτίβου.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμιση κατάλογου](pattern-fill.png)

## **Γέμιση Εικόνας**

Μία γέμιση εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) σε λειτουργία επαναλαμβανόμενης εικόνας (tile) η εικόνα επαναλαμβάνεται μέσα στο ορθογώνιο. Η πηγή εικόνας που χρησιμοποιείται παρακάτω φαίνεται παρακάτω:

![Η εικόνα λωτού](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Επανάληψη Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επανάληψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους του διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει εάν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει τη κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και διαμορφώνει το [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) ώστε να την επαναλαμβάνει στο 50 % του αρχικού μεγέθους. Μετατοπίσεις −32 σημείων μετατοπίζουν τα πλακίδια οριζόντια και κάθετα· ευθυγράμμιση κάτω‑δεξιά και ανάποδη αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς το επαναλαμβανόμενο υφασματικό μοτίβο τακτοποιείται.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Συμπαγής Γέμιση Χρώματος**

Μία συμπαγής γέμιση δίνει στο σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα χρησιμοποιεί το [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) για να ορίσει τη λειτουργία συμπαγούς γέμισης και αναθέτει κίτρινο μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), στη συνέχεια αποθηκεύει το ορθογώνιο στην παρουσίαση.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγή γέμιση χρώματος](solid-color-fill.png)

### **Αντιγραφή Χρωμάτων Διατηρώντας Αναφορές Θέματος**

Use [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) to copy a color definition, including its color type, theme reference, and transformations. This is useful when transferring a fill color between shapes that should continue to follow the presentation theme. The method copies only the color: it does not copy the fill type, outline, or other shape formatting. Set the destination's fill type explicitly with [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

Αυτό το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς τα δεξιά: την πηγή, ένα αντίγραφο συνειδητό του θέματος, και ένα σταθερό RGB αντίγραφο. Η πηγή χρησιμοποιεί το [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) για να αναφερθεί στο πρώτο χρώμα έμφασης και προσθέτει αποχρώση μέσω του [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). Η RGB αντίγραφο χρησιμοποιεί το αποτελεσματικό χρώμα γέμισης της πηγής ώστε και τα τρία αρχικά να φαίνονται ταυτόσημα. Κάνοντας κλήση στο [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) ορίζεται μια σταθερή τιμή RGB και καθαρίζονται τυχόν υπάρχουσες μετασχηματισμοί χρώματος.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Οι αναφορές θέματος ακολουθούν το νέο χρώμα έμφασης· η σταθερή τιμή RGB δεν το ακολουθεί.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Πριν την αλλαγή θέματος, όλα τα τρία γέμισμα ταιριάζουν:

![Πηγή, copyFrom προορισμός, και σταθερό RGB προορισμός με ταυτόσημα μπλε γέμισμα](color-copy-before.png)

Μετά την αλλαγή θέματος, η πηγή και το αντιγραμμένο με θέμα ακολουθούν το νέο χρώμα έμφασης και διατηρούν την απόχρωση. Το σταθερό RGB αντίγραφο παραμένει μπλε:

![Πηγή και copyFrom προορισμός με πορτοκαλί γέμισμα, ενώ το σταθερό RGB προορισμός παραμένει μπλε](color-copy-after.png)

Ο αντίγραφος ορισμός είναι ανεξάρτητος από την πηγή. Η μεταγενέστερη αλλαγή της αναφοράς θέματος της πηγής, η ανάθεση άλλου χρώματος ή η προσθήκη/αφαίρεση των μετασχηματισμών δεν επηρεάζει τον προορισμό. Η αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή κάθε ένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επανέναρξη του PPTX διατηρεί τον τύπο του αντιγραμμένου χρώματος όπως επιστρέφει το [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--), την αναφορά θέματος και τη συλλογή μετασχηματισμών όπως επιστρέφει το [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--); δεν μετατρέπει τον ορισμό σε RGB.

Κατά τη μεταφορά μεταξύ διαφορετικών πλαισίων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έμφασης, η αντιγραμμένη αναφορά λύνει το θέμα του προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν επομένως να παράγουν διαφορετικό ορατό χρώμα. Δείτε το [Presentation Theme](/slides/el/java/presentation-theme/) για περισσότερα σχετικά με τη διαμόρφωση χρωμάτων θέματος.

## **Χρήση Υπόβαθρου Διαφάνειας ως Γέμιση Σχήματος**

Use [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) when a shape should match the slide background, for example in a presentation template. Set the fill type with [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) to [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) first to remove any explicit fill. With this combination, the shape uses the slide background instead of its style fill. Enabling the flag alone does not remove an existing explicit fill.

Αυτό διαφέρει από το [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): το γέμισμα φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να ξεκινά μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κύριο φόντο κληρονομημένο από τη διαφάνεια και τοποθετεί μια ματζέντα λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξιό αλλάζει από γέμισμα φόντου σε ρητό πορτοκαλί γέμισμα.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Κληρονομεί τη διαβάθμιση από το κύριο πρότυπο.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Προσθέστε αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Απενεργοποιήστε το γέμισμα φόντου πριν εφαρμόσετε ρητό γέμισμα.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **γέμισμα φόντου**, **χωρίς γέμισμα**, και **ρητό γέμισμα**. Η ματζέντα λωρίδα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Γέμισμα φόντου, χωρίς γέμισμα, και ρητό πορτοκαλί γέμισμα πάνω από λωρίδα ματζέντα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο ορισμένο απευθείας στη διαφάνεια ή κληρονομημένο από διάταξη. Το σχήμα χρησιμοποιεί το ανάλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τόσο το φόντο της διαφάνειας όσο και της διάταξης ακαθόριστα ώστε το κύριο να το παρέχει.

## **Ορισμός Διαφάνειας**

Για μια συμπαγή γέμιση, το άλφα του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 είναι πλήρως αδιαπέραστο. Αυτό το παράδειγμα χρησιμοποιεί τιμή άλφα 128 για ένα κίτρινο ορθογώνιο, καθιστώντας το περίπου 50 % διαφανές ώστε το ορθογώνιο από κάτω να παραμένει ορατό. Το χρώμα ανατίθεται μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Use [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) to rotate a shape in the slide plane. The angle is measured in degrees; this example rotates a rectangle 5 degrees clockwise and saves the presentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3D Πλάγιας Άκρης**

Use [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) to give a shape depth and beveled edges. This example creates a green ellipse with an orange outline, uses [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) to set the depth to 4 points, and applies a circular top bevel with a width and height of 6 points through [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). A front-facing orthographic camera and three-point lighting make the bevel visible.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3D πλάγιας άκρης](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3D Περιστροφής**

Η 3D προβολή ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) με γωνίες πλάτους, μήκους και επανάληψης 40, 35 και 20 μοιρών, αντίστοιχα. Επιλέγει μια ισομετρική κάμερα μέσω του [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) και ισορροπημένο φωτισμό μέσω του [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), στη συνέχεια αποθηκεύει το μορφοποιημένο ορθογώνιο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3D περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μαυρό‑Άσπρης Απόδοσης για Σχήματα**

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) καθορίζει πώς ένα μεμονωμένο σχήμα αποδίδεται όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε μαυρό‑άσπρη λειτουργία. Δεν ενεργοποιεί την μαυρό‑άσπρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, το περίγραμμα ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρωματισμό, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και άσπρο, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` παραλείπει το σχήμα σε μαυρό‑άσπρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει ανατεθεί λειτουργία σε επίπεδο σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και χρησιμοποιεί το [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) για να ορίσει τη λειτουργία σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα για κανονική χρωματική προβολή και ζητά γκρι χρωματισμό από τις εφαρμογές που σέβονται τις ρυθμίσεις μαυρό‑άσπρης προβολής:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε ροή εργασίας μαυρό‑άσπρης προβολής, χρησιμοποιεί γκρι χρωματισμό επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως χρωματισμένη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μαυρό‑άσπρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Use [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) to restore the position, size, and formatting of slide placeholders from their corresponding layout placeholders. This example requires an existing presentation with layout‑linked placeholders and resets every slide before saving. Shapes without corresponding layout placeholders are not reset.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Does shape formatting affect the final presentation file size?**

Colors, line styles, and effect settings generally add little data compared with embedded images and media. Picture fills can increase the file size because their images are stored in the presentation.

**How can I detect shapes on a slide that share identical formatting so I can group them?**

Compare each shape’s key formatting properties—fill, line, and effect settings. If all corresponding values match, treat their styles as identical and logically group those shapes, which simplifies later style management.

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

Yes. Store sample shapes with the desired styles in a template slide deck or a .POTX template file. When creating a new presentation, open the template, clone the styled shapes you need, and reapply their formatting wherever required.