---
title: Διαμόρφωση Σχημάτων PowerPoint σε Android
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/androidjava/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύνδεσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- γέμιση στερεού χρώματος
- διαφάνεια σχήματος
- ασπρόμαυρη απόδοση σχήματος
- απόδοση σχήματος σε γκρι αποχρώσεις
- περιστροφή σχήματος
- εφέ 3Δ λοξής άκρης
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Android χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint προσαρμόζοντας τα περιγράμματά τους, τα γεμίσματα και τα εφέ. Το Aspose.Slides for Android via Java σάς επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της 3Δ διαμόρφωσης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Android via Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) για να ελέγξετε το περιγράμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμάτο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) επιλέγει μια σύνθετη γραμμή παχιά‑λεπτή, ενώ [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ορίζει το πλάτος της στα 7 σημεία και [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) επιλέγει το μοτίβο διαγράμματος.

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

### **Ορισμός Προσαρμοσμένων Μοτίβων Διαγράμματος Γραμμής**

Χρησιμοποιήστε [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη διαγραμμάτων και κενών που χρειάζεστε, για παράδειγμα για επωνυμημένα περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου αλλάζει αυτόματα το στυλ διαγράμματος γραμμής σε [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μηκών διαγράμματος και κενών, ξεκινώντας με διάγραμμα. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `{ 4, 2 }` σε πλάτος 3 σημείων δημιουργεί διάγραμμο 12 σημείων, ακολουθούμενο από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε ολοκληρωμένα τμήματα διαγράμματος‑και‑κενών. Το παράδειγμα χρησιμοποιεί θετικές τιμές για να διατηρηθεί κάθε διάγραμμα και κενό ορατό.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδες άκρες. Οι πρώτες τρεις συγκρίνουν μοτίβα σε πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο με διπλάσιο πλάτος, διπλασιάζοντας τόσο το μήκος του διαγράμματος όσο και του κενού. Η πέμπτη αλλάζει από προσαρμοσμένο μοτίβο σε στερεή γραμμή.

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

    // Επιστρέψτε την τελευταία γραμμή σε στυλ στερεής γραμμής.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να επιστρέψετε σε προεπιλεγμένο στυλ διαγράμματος, περάστε το [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) στη μέθοδο [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα διαγραμμάτων, μια πιο πλατιά γραμμή με το πρώτο μοτίβο και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η κλάση [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `Flat`: Η γραμμή σταματά στο άκρο.
- `Round`: Μια ημικυκλική άκρη εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.
- `Square`: Μια τετράγωνη άκρη εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.

Η κλάση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητό στυ λ άκρου.

Τα άκρα διαφέρουν από τα βέλη, τα οποία προσθέτουν σύμβολα στα άκρα της γραμμής, και τις ενώσεις, οι οποίες ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βέλη μέσω των μεθόδων [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) και [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το ακόλουθο παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές, άλλωστε πανομοιότυπες, πλάτους 20 σημείων. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

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

## **Εφαρμογή Σκετσοειδών Εφέ σε Γραμμές Σχήματος**

Ένα σκετσοειδές εφέ κάνει τη γραμμή ενός σχήματος να φαίνεται χειρόγραφη. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) για να προσπελάσετε τις ρυθμίσεις γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) για να προσπελάσετε τις ρυθμίσεις σκετς, και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) για να επιλέξετε μια τιμή από την κλάση [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), να διαβάσετε την ρητά εκχωρημένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί απευθείας στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διαφάνεια διάταξης, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), προσπελάστε το [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

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

## **Μορφοποίηση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξείες γωνίες ή **Bevel** για ισοπεδωμένες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα πλάτους 15 σημείων. Χρησιμοποιεί το [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) για να εφαρμόσει τις τιμές miter, bevel και round της κλάσης [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), αντίστοιχα, ώστε να συγκρίνει πώς σχεδιάζονται οι γωνίες.

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

### **Περιορισμός Συνδέσεων Miter σε Οξές Γωνίες**

Χρησιμοποιήστε το [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) μαζί με το [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ορισμένο σε [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μακριά μπορεί να εκτείνεται μια οξεία γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος miter μέχρι οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία ξεπεράσει το όριο, το PowerPoint χρησιμοποιεί συνδεσμολογία bevel σε εκείνη τη γωνία. Μεγαλύτερο όριο επιτρέπει πιο οξείς άκρα. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις miter και δεν έχει οπτικό αποτέλεσμα όταν η γωνία παραμένει εντός του ορίου.

Αυτό το παράδειγμα δημιουργεί δύο πανομοιότυπα μη γεμάτα τρίγωνα με περιγράμματα πλάτους 20 σημείων. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, το δεξιό `8`. Κάθε τρίγωνο έχει πλάτος 80 σημείων και ύψος 160 σημείων, δίνοντας στην άνω γωνία λόγο miter‑length‑to‑line‑width περίπου `4.12`. Συνεπώς, το PowerPoint εφαρμόζει bevel στην αριστερή κορυφή και διατηρεί την δεξιά.

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

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![Κορυφή bevel με όριο miter 2 και αιχμή με όριο miter 8 στο PowerPoint](miter-limits.png)

## **Γραμμική Γέμιση (Gradient Fill)**

Μια γραμμική γέμιση αναμειγνύει χρώματα σε ένα σχήμα. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική γέμιση υπό γωνία 45 μοιρών από κόκκινο σε μωβ χρησιμοποιώντας το [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Η μέθοδος [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) τοποθετεί τις στάσεις χρώματος στο 0 και 1, στην αρχή και το τέλος της γέμισης. Η εκκαθάριση των υπαρχόντων στάσεων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

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

![Η έλλειψη με γραμμική γέμιση](gradient-fill.png)

Εάν μια γέμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε το άρθρο [Choose a Gradient Rendering Style](/slides/el/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη γέμιση που αποθηκεύεται στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Γέμισης**

Χρησιμοποιήστε το [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) για να ελέγξετε τον προσανατολισμό μιας γέμισης [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Η γωνία μετράται σε μοίρες και αυξάνεται δεξιόστροφα: `0` από αριστερά προς δεξιά, `90` από πάνω προς κάτω, `180` από δεξιά προς αριστερά, και `270` από κάτω προς πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι πεπερασμένες γωνίες εκτός του εύρους `[0, 360)` κανονικοποιούνται σε μια πλήρη περιφορά· για παράδειγμα, `-45` γίνεται `315` και `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με πανομοιότυπες στάσεις κόκκινου, πράσινου και μπλε στις θέσεις `0`, `0.5` και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

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

![Γραμμικές γέμισεις στις γωνίες 0, 45 και 90 στην επάνω σειρά, και 135, 180 και 270 στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Γέμισης με το Σχήμα**

Το [IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Ορίστε την ρητά σε `False` για να διατηρείται η γεωμετρική γωνία της γέμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `True` για να κλιμακώσει η γέμιση με το πλάτος και το ύψος του σχήματος. Με ενεργοποιημένη την κλιμάκωση, η οπτική γωνία μπορεί να διαφέρει από την ανατεθειμένη γωνία σε μη τετράγωνο σχήμα.

Το ακόλουθο παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τις ίδιες στάσεις χρώματος όπως στην σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά στήλη χρησιμοποιεί `True`. Κάθε στήλη περιέχει ένα ευρύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και οι δύο ξεκινούν με τις ίδιες ευρείες διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς η γέμιση ανταποκρίνεται στην αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις γέμισης.

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

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργοποιημένη στα δεξιά:

![Ευρείς και ψηλοί ορθογώνιοι με γέμιση 45 μοιρών, σύγκριση LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται μαζί με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας γέμισης προτύπου όταν προσαρμόζεται ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της γέμισης 45 μοιρών.

Τanto η γωνία όσο και η ρύθμιση κλιμάκωσης εφαρμόζονται σε γραμμικές γέμισεις. Δεν ελέγχουν γέμισεις [GradientShape.Radial ή GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Γέμισης**

Το [IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) επιλέγει στυλ γέμισης από την κλάση [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/). Δεν αντικαθιστά μια αριθμητική γωνία. Για μια γραμμική γέμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή διασποράς των χρωμάτων χωρίς να αλλάξουν τη γωνία που έχει οριστεί μέσω του [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Διατηρήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το ακόλουθο παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

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

## **Γέμισμα Προτύπου (Pattern Fill)**

Μια γέμιση προτύπου εφαρμόζει σχεδιασμό δύο χρωμάτων, όπως κουκίδες, λωρίδες ή τετράγωνα. Αυτό το παράδειγμα χρησιμοποιεί το [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) για να επιλέξει ένα μοτίβο τύπου πλέγματος. Το [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) παρέχει το ανοιχτό γκρι φόντο, και το [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) παρέχει το κίτρινο χρώμα του μοτίβου.

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

![Το ορθογώνιο με γέμιση προτύπου](pattern-fill.png)

## **Γέμισμα Εικόνας (Picture Fill)**

Μια γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) σε λειτουργία επικάλυψης (tiled) επαναλαμβάνει την εικόνα μέσα στο ορθογώνιο. Η πηγή εικόνας που χρησιμοποιείται παρακάτω φαίνεται παρακάτω:

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

### **Επικάλυψη Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια επικάλυψη εικόνας ως υφή και να προσαρμόσετε τη συμπεριφορά επικάλυψης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους του διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει αν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κατακόρυφη μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κατακόρυφη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και διαμορφώνει το [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) ώστε να την επαναλαμβάνει στο 50 % του αρχικού μεγέθους. Μετατοπίσεις −32 σημείων μετακινούν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω‑δεξιά και η ανάστροφη σε κατεύθυνση και οι δύο καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

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

## **Στερεά Γέμιση Χρώματος (Solid Color Fill)**

Μια στερεή γέμιση δίνει στο σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα χρησιμοποιεί το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξει τη στερεή λειτουργία γέμισης και ορίζει κίτρινο χρώμα μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), έπειτα αποθηκεύει το ορθογώνιο στην παρουσίαση.

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

![Το σχήμα με στερεό χρώμα γέμισης](solid-color-fill.png)

### **Αντιγραφή Χρωμάτων Διατηρώντας Αναφορές Θέματος**

Χρησιμοποιήστε το [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) για να αντιγράψετε έναν ορισμό χρώματος, συμπεριλαμβανομένου του τύπου χρώματος, της αναφοράς θέματος και των μετασχηματισμών. Αυτό είναι χρήσιμο όταν μεταφέρετε χρώμα γεμίσματος μεταξύ σχημάτων που πρέπει να συνεχίσουν να ακολουθούν το θέμα της παρουσίασης. Η μέθοδος αντιγράφει μόνο το χρώμα: δεν αντιγράφει το τύπο γεμίσματος, το περίγραμμα ή άλλες μορφοποιήσεις του σχήματος. Ορίστε ρητά το τύπο γεμίσματος του προορισμού με το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

Αυτό το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς δεξιά: την πηγή, ένα αντίγραφο που λαμβάνει υπόψη το θέμα, και ένα σταθερό αντίγραφο RGB. Η πηγή χρησιμοποιεί το [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) για να αναφερθεί στο πρώτο χρώμα έμφασης και προσθέτει απόχρωση μέσω του [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). Το αντίγραφο RGB χρησιμοποιεί το αποτελεσματικό χρώμα γεμίσματος της πηγής, ώστε όλα τα τρία αρχικά να φαίνονται ταυτόσημα. Η κλήση του [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) ορίζει μια σταθερή τιμή RGB και διαγράφει τυχόν υπάρχουσες μετατροπές χρώματος.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

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

    // Οι αναφορές θέματος ακολουθούν το νέο χρώμα έμφασης· η σταθερή τιμή RGB δεν το κάνει.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

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

Πριν από την αλλαγή του θέματος, όλες οι γέμισεις ταιριάζουν:

![Πηγή, προορισμός copyFrom και σταθερό προορισμό RGB με πανομοιότυπες μπλε γέμισεις](color-copy-before.png)

Μετά την αλλαγή του θέματος, η πηγή και το αντίγραφο που λάβει υπόψη το θέμα ακολουθούν το νέο χρώμα έμφασης και διατηρούν την απόχρωσή τους. Το σταθερό αντίγραφο RGB παραμένει μπλε:

![Πηγή και προορισμό copyFrom με πορτοκαλί γέμισμα, ενώ το σταθερό RGB προορισμό παραμένει μπλε](color-copy-after.png)

Ο αντίγραφος ορισμός είναι ανεξάρτητος από την πηγή. Η επακόλουθη αλλαγή της αναφοράς θέματος της πηγής, η εκχώρηση άλλου χρώματος ή η προσθήκη/αφαίρεση των μετασχηματισμών της δεν αλλάζει τον προορισμό. Μια αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή καθένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επανάνοιξη του PPTX διατηρεί τον τύπο του αντιγραφόμενου χρώματος που επιστρέφεται από το [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--), την αναφορά θέματος και τη συλλογή μετασχηματισμών που επιστρέφεται από το [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--); δεν μετατρέπει τον ορισμό σε RGB.

Κατά την αντιγραφή μεταξύ διαφορετικών συμφραζομένων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έμφασης, η αντιγραμμένη αναφορά λύνει το θέμα του προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν έτσι να παράγουν διαφορετικό ορατό χρώμα. Δείτε το άρθρο [Presentation Theme](/slides/el/androidjava/presentation-theme/) για περισσότερα σχετικά με τη διαμόρφωση χρωμάτων θέματος.

## **Χρήση του Φόντου της Διαφάνειας ως Γέμιση Σχήματος**

Χρησιμοποιήστε το [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, π.χ. σε πρότυπο παρουσίασης. Ορίστε πρώτα τον τύπο γεμίσματος με το [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) σε [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) για να αφαιρέσετε τυχόν ρητή γέμιση. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για τη δική του γέμιση. Η ενεργοποίηση της σημαίας μόνη της δεν αφαιρεί μια υπάρχουσα ρητή γέμιση.

Αυτό διαφέρει από το [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): η γέμιση φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει τα αντικείμενα ορατά. Μια γέμιση gradient παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να επανεκκινείται μέσα σε κάθε σχήμα.

Το ακόλουθο παράδειγμα δημιουργεί ένα φόντο master που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λωτό πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμιση, και το δεξιό εναλλάσσει από γέμιση φόντου σε ρητή πορτοκαλί γέμιση.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Κληρονομήστε τη διαβάθμιση από το master.
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

    // Απενεργοποιήστε τη γέμιση φόντου πριν εφαρμόσετε ρητή γέμιση.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **γέμιση φόντου**, **καμία γέμιση**, και **ρητή γέμιση**. Η λωτό μπάντα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Γέμιση φόντου, χωρίς γέμιση και ρητή πορτοκαλί γέμιση πάνω από λωτό μπάντα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται απευθείας στη διαφάνεια ή κληρονομείται από διάταξη. Το σχήμα χρησιμοποιεί το επιλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει ακαθόριστα τα φόντα της διαφάνειας και της διάταξης ώστε το master να το παράσχει.

## **Ορισμός Διαφάνειας**

Για μια στερεή γέμιση, το συστατικό άλφα του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφάνεια. Αυτό το παράδειγμα χρησιμοποιεί τιμή άλφα 128 για ένα κίτρινο ορθογώνιο, καθιστώντας το περίπου 50 % διαφανές ώστε το ορθογώνιο από κάτω να παραμένει ορατό. Το χρώμα εκχωρείται μέσω του [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

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

![Το διαφανές σχήμα](shape-transparency.png)

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

## **Προσθήκη 3D Εφέ Πλάγιας Πλευράς (Bevel)**

Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να δώσετε βάθος και πλάγιες άκρες σε ένα σχήμα. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, χρησιμοποιεί το [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) για να ορίσει το βάθος σε 4 σημεία, και εφαρμόζει μια κυκλική επάνω πλάγια με πλάτος και ύψος 6 σημείων μέσω του [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Μια μπροστινή ορθογώνια ορθογραφική κάμερα και τριπλή φωτισμός κάνουν το bevel ορατό.

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

![Το 3D εφέ πλάγιας πλευράς](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής**

Η τρισδιάστατη όψη ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) με γωνίες πυκνότητας, γεωγραφικού μήκους και επανάληψης 40, 35 και 20 μοιρών, αντίστοιχα. Επιλέγει ισομετρική κάμερα μέσω του [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) και ισορροπημένο φωτισμό μέσω του [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), έπειτα αποθηκεύει το μορφοποιημένο ορθογώνιο.

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

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μαύρου‑Άσπρου Rendering για Σχήματα**

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβολή ή επεξεργάζεται σε μαύρο‑άσπρο λειτουργία. Δεν ενεργοποιεί από μόνη της την προβολή μαύρου‑άσπρου και δεν αλλάζει το γέμισμα, την γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόφασης να επιλέξει τη μετατροπή, `Gray` και `LightGray` χρησιμοποιούν γκρι χρωματισμό, `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, `Black` και `White` επιβάλλουν ένα μόνο χρώμα, `Color` διατηρεί το κανονικό χρώμα, και `Hidden` παραλείπει το σχήμα σε μαύρο‑άσπρη λειτουργία. `NotDefined` σημαίνει ότι δεν έχει εκχωρηθεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και χρησιμοποιεί το [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) για να επιλέξει γκρι χρωματισμό. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα για κανονική χρωματική προβολή και ζητά γκρι χρωματισμό σε εφαρμογές που σέβονται τις ρυθμίσεις μαύρο‑άσπρου.

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

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε ροή εργασίας μαύρο‑άσπρου, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως χρωματιστή διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μαύρο‑άσπρου της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) για να αποκαταστήσετε τη θέση, το μέγεθος και τη μορφοποίηση των placeholders διαφάνειας από τα αντίστοιχα placeholders διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με placeholders συνδεδεμένα με τη διάταξη και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Τα σχήματα χωρίς αντίστοιχο placeholder διάταξης δεν επαναφέρονται.

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

## **FAQ**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σύγκριση με τις ενσωματωμένες εικόνες και τα μέσα. Η γέμιση εικόνας μπορεί να αυξήσει το μέγεθος του αρχείου επειδή οι εικόνες της αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τα βασικά χαρακτηριστικά μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως ταυτόσημα και λογικά ομαδοποιήστε τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναί. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.