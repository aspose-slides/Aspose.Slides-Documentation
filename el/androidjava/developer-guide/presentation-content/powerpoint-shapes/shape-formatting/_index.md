---
title: Διαμόρφωση Σχημάτων PowerPoint σε Android
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/androidjava/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύνδεσης
- διαβαθμισμένο γέμισμα
- γεμισμα μοτίβου
- γεμισμα εικόνας
- γεμισμα υφής
- στερεό χρωματικό γέμισμα
- διαφάνεια σχήματος
- μαυρόασπρη απόδοση σχήματος
- γκρι κλίμακα απόδοση σχήματος
- περιστροφή σχήματος
- εφέ 3Δ σμίλη
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Android χρησιμοποιώντας το Aspose.Slides—ορίστε στιλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε τα σχήματα στο PowerPoint προσαρμόζοντας τα περιγράμματά τους, τις γεμίσεις και τα εφέ. Το Aspose.Slides for Android μέσω Java σάς επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένων της διαφάνειας, της περιστροφής και της 3D διαμόρφωσης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Android μέσω Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να διαμορφώνετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμιστό ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) επιλέγει μια σύνθετη γραμμή παχιά‑λεπτή, ενώ [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ορίζει το πλάτος της στα 7 σημεία και [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) επιλέγει το μοτίβο παύλας.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Ορισμός Προσαρμοσμένων Μοτίβων Γραμμής**

Χρησιμοποιήστε [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη διακεκοσμένων τμημάτων και κενών που χρειάζεστε, για παράδειγμα για επωνυμικές γραμμές ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου αλλάζει αυτόματα το στυλ παύλας σε [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μήκους παύλας και κενών, ξεκινώντας με παύλα. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `{ 4, 2 }` με πλάτος 3 σημείων παράγει παύλα 12 σημείων και κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα παύλας‑κενών. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε παύλα και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδα άκρα. Οι τρεις πρώτες συγκρίνουν μοτίβα με πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο με διπλάσιο πλάτος, διπλασιάζοντας τόσο την παύλα όσο και το κενό. Η πέμπτη μεταβαίνει από προσαρμοσμένο μοτίβο σε στερεή γραμμή.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να επιστρέψετε σε ένα προεπιλεγμένο διακεκομμένο στυλ, περάστε το [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) στη μέθοδο [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα διακεκοσμένης γραμμής, μια πιο πλατιά γραμμή που χρησιμοποιεί το πρώτο μοτίβο, και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η κλάση [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `Flat`: Η γραμμή σταματά στο τελικό σημείο.
- `Round`: Ένα ημικυκλικό άκρο εκτείνεται πέρα από το τελικό σημείο κατά το ήμισυ του πλάτους της γραμμής.
- `Square`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το τελικό σημείο κατά το ήμισυ του πλάτους της γραμμής.

Η κλάση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητά κάποιο στυλ άκρου.

Τα άκρα διαφέρουν από τις κεφαλές βέλους, οι οποίες προσθέτουν σύμβολα στα άκρα της γραμμής, και από τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τις κεφαλές βέλους μέσω των [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) και [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το παρακάτω παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές με ίδια χαρακτηριστικά, πλάτους 20 σημείων. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

![Επίπεδα, στρογγυλεμένα και τετράγωνα άκρα σε πανομοιότυπες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Σχεδίου Σκίτσου σε Γραμμές Σχήματος**

Ένα εφέ σκίτσου κάνει μια γραμμή σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις της γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σκίτσου, και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) για να επιλέξετε μια τιμή από την κλάση [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), να διαβάσετε τη ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, την κύρια διαφάνεια ή τη διαφάνεια διάταξης, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

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

## **Μορφοποίηση Τύπων Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε μια γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για αιχμηρές γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 σημείων. Χρησιμοποιεί το [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) για να εφαρμόσει τις τιμές miter, bevel και round της κλάσης [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), αντίστοιχα, ώστε να συγκρίνει πώς σχεδιάζονται οι γωνίες.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Περιορισμός Σύνδεσεων Miter σε Αιχμηρές Γωνίες**

Χρησιμοποιήστε το [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) μαζί με το [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ορισμένο σε [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μπορεί να εκτείνεται μια αιχμηρή γωνία.

Το όριο είναι το ποσοστό της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, τιμή `8` επιτρέπει μήκος μιτέρ έως οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία υπερβεί το όριο, το PowerPoint χρησιμοποιεί μια πλατιές σύνδεση σε εκείνη τη γωνία. Μεγαλύτερο όριο επιτρέπει πιο αιχμηρά σημεία. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις miter και δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμένει εντός των ορίων.

Αυτό το παράδειγμα δημιουργεί δύο ίδια, μη γεμιστά τρίγωνα με περιγράμματα 20 σημείων. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, και το δεξιό `8`. Κάθε τρίγωνο είναι 80 σημείων πλατύ και 160 σημείων υψηλό, δίνοντας στην κορυφή του λόγο μήκους μιτέρ‑πλάτους περίπου `4.12`. Συνεπώς, το PowerPoint κακοτρέπει το αριστερό άκρο και διατηρεί το δεξιό.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα στο PowerPoint: **Όριο μιτέρ 2** αριστερά και **όριο μιτέρ 8** δεξιά.

![Μια πλατιζόμενη κορυφή με όριο μιτέρ 2 και μια αιχμική κορυφή με όριο μιτέρ 8 στο PowerPoint](miter-limits.png)

## **Γέμισμα Διαβάθμισης**

Ένα γέμισμα διαβάθμισης αναμειγνύει χρώματα κατά μήκος ενός σχήματος. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμικό διάγραμμα κλίσης 45 μοιρών από το κόκκινο προς το μοβ χρησιμοποιώντας το [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Η μέθοδος [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) τοποθετεί τα χρωματικά σημεία στα 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η διαγραφή των υπαρχουσών σημείων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

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

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση που αποθηκεύεται στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικού Διαγράμματος**

Χρησιμοποιήστε το [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) για να ελέγξετε τον προσανατολισμό μιας γέμισης [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Η γωνία μετράται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει από αριστερά προς δεξιά, `90` από πάνω προς τα κάτω, `180` από δεξιά προς αριστερά, και `270` από κάτω προς πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι πεπερασμένες γωνίες εκτός του εύρους `[0, 360)` κανονικοποιούνται σε μία πλήρη περιδία; π.χ., `-45` γίνεται `315` και `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με ίδια σημεία χρώματος κόκκινου, πράσινου και μπλε στις θέσεις `0`, `0.5` και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Γραμμικές διαβάθμιση στις 0, 45 και 90 μοίρες στην πάνω σειρά, και 135, 180, 270 μοίρες στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

Το [IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Ορίστε την αυστηρά σε `False` για να διατηρείται η γεωμετρική γωνία της διαβάθμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `True` για να κλιμακώνεται η διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από την ανατεθειμένη γωνία σε μη τετράγωνο σχήμα.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια σημεία χρώματος όπως στη σύγκριση γωνίας. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά στήλη χρησιμοποιεί `True`. Κάθε στήλη περιέχει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και τα δύο ξεκινούν με τις ίδιες πλάστιχες διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς η γέμιση αντιδρά σε αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις διαβάθμισης.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Το αποτέλεσμα στο PowerPoint, με την κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργή στα δεξιά:

![Πλατιά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, συγκρίνοντας LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με την κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν την ίδια προσανατολισμό και στα δύο ορθογώνια. Με την κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν προσαρμόζεται ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της διαβάθμισης `45` μοιρών.

Και η γωνία και η κλιμάκωση ισχύουν για γραμμικές διαβάθμιση. Δεν ελέγχουν διαδιαγραφές [GradientShape.Radial ή GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαγράμματος**

Το [IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) επιλέγει ένα στυλ διαγράμματος από την κλάση [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); δεν αποτελεί αντικατάσταση για αριθμητική γωνία. Για μια γραμμική διαβάθμιση, τα στυλ γωνίας μπορούν να αλλάξουν την περιοχή που διανέμονται τα χρώματα χωρίς να αλλάζουν την γωνία που έχει οριστεί μέσω του [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Κρατήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το ακόλουθο παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίθετη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η εκχώρηση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Γέμισμα Σχεδίου**

Ένα γέμισμα σχεδίου εφαρμόζει ένα σχεδιασμό δύο χρωμάτων, όπως κουκκίδες, λωρίδες ή καβούρια. Αυτό το παράδειγμα χρησιμοποιεί το [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) για να επιλέξει ένα μοτίβο πλέγματος. Το [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) παρέχει το ανοιχτό γκρι φόντο, και το [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) παρέχει το κίτρινο χρώμα του μοτίβου.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Ένα γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) στην κατάσταση επαναληπτικής (tiled) λειτουργίας επαναλαμβάνει την εικόνα μέσα στο ορθογώνιο. Η πηγαία εικόνα που χρησιμοποιείται φαίνεται παρακάτω:

![Η εικόνα λωτόσ" (lotus)](lotus.png)

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

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Επανάληψη Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια επαναληπτική εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά επανάληψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει εάν το πλακίδιο αντιστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει τη οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κατακόρυφη μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κατακόρυφη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και ρυθμίζει το [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) να την επαναλάβει στο 50 % του αρχικού μεγέθους. Οι μετατοπίσεις –32 σημείων μετακινούν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω‑δεξιά και η αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

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

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμισμα Στερεού Χρώματος**

Ένα στερεό γέμισμα δίνει σε ένα σχήμα ένα ενιαίο, ομοιογενές χρώμα. Αυτό το παράδειγμα χρησιμοποιεί το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξει τη λειτουργία στερεού γεμίσματος και ορίζει κίτρινο χρώμα μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), στη συνέχεια αποθηκεύει το ορθογώνιο σε παρουσίαση.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Το σχήμα με στερεό γέμισμα χρώματος](solid-color-fill.png)

## **Χρήση Φόντου Διαφάνειας ως Γέμισμα Σχήματος**

Χρησιμοποιήστε το [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, για παράδειγμα σε πρότυπο παρουσίασης. Χρησιμοποιήστε το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) με το [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) πρώτα για να αφαιρέσετε οποιοδήποτε ρητό γέμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για το στυλ γεμίσματος του. Η ενεργοποίηση της σημαίας μόνη της δεν αφαιρεί ένα υπάρχον ρητό γέμισμα.

Αυτό διαφέρει από το [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): το γέμισμα φόντου καλύπτει τα αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να επανεκκινείται μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κύριο φόντο που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξιό εναλλάσσει το φόντο με ένα ρητό πορτοκαλί γέμισμα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Κληρονομεί τη διαβάθμιση από το master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Προσθέτει αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
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

    // Απενεργοποιεί το γέμισμα φόντου πριν εφαρμόσει ρητό γέμισμα.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **φόντο γέμισμα**, **χωρίς γέμισμα**, και **ρητό γέμισμα**. Η λωρίδα ματζέντα κρύβεται από τα αριστερά και δεξιά ορθογώνια, αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Φόντο γέμισμα, χωρίς γέμισμα και ρητό πορτοκαλί γέμισμα πάνω από λωρίδα ματζέντα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται άμεσα στη διαφάνεια ή κληρονομείται από τη διάταξη. Το σχήμα χρησιμοποιεί το επιλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τόσο τη διαφάνεια όσο και το φόντο διάταξης ακαθόριστα ώστε το κύριο να το παρέχει.

## **Ορισμός Διαφάνειας**

Για ένα στερεό γέμισμα, το αλφα-συστατικό του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαυγές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή alpha 128 για ένα κίτρινο ορθογώνιο, κάνοντάς το περίπου 50 % διαυγές ώστε να παραμένει ορατό το ορθογώνιο από κάτω. Το χρώμα ορίζεται μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαυγές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε το [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

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

## **Προσθήκη Εφέ 3D Σμίλης**

Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να δώσετε σε ένα σχήμα βάθος και ασκήσεις. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, χρησιμοποιεί το [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) για να ορίσει το βάθος στα 4 σημεία, και εφαρμόζει μια κυκλική άνω σμίλη με πλάτος και ύψος 6 σημείων μέσω του [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Μια ορθογώνια κάμερα προέκτασης και τριών‑σημειακό φωτισμό καθιστούν τη σμίλη ορατή.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

![Το εφέ 3D σμίλης](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3D Περιστροφής**

Η 3D προβολή ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) με γωνίες γεωγραφικού πλάτους, μηκους και περιδίας 40, 35 και 20 μοίρες, αντίστοιχα. Επιλέγει μια ισομετρική κάμερα μέσω του [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) και εξισορροπημένο φωτισμό μέσω του [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), στη συνέχεια αποθηκεύει το μορφοποιημένο ορθογώνιο.

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

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβάλλεται ή υποβάλλεται σε επεξεργασία σε ασπρόμαυρο τρόπο. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, το περίγραμμα ή άλλες μορφοποιήσεις του σχήματος σε κανονική έγχρωμη κατάσταση.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι αποχρώσεις, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα μόνο χρώμα, το `Color` διατηρεί την κανονική χρωματική απόδοση, και το `Hidden` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και χρησιμοποιεί το [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) για να επιλέξει γκρι απόχρωση. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμά του για την κανονική έγχρωμη προβολή και ζητά γκρι χρώμα από εφαρμογές που τιμούν τις ρυθμίσεις ασπρόμαυρης εμφάνισης.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε κανονική έγχρωμη λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του είναι ορισμένη ως `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ καθορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των δεσμευτικών θέσεων διαφάνειας από τις αντίστοιχες θέσεις του διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με δεσμευμένες θέσεις διάταξης και επαναφέρει κάθε διαφάνεια πριν αποθηκεύσει. Τα σχήματα χωρίς αντίστοιχες θέσεις διάταξης δεν επαναφέρονται.

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

## **ΣΥΚΓΕΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σύγκριση με ενσωματωμένες εικόνες και πολυμέσα. Τα γέμισμα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε παραδείγματα σχήματος με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλώνοστε τα σχήματα που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.