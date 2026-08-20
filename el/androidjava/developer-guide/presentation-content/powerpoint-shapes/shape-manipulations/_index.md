---
title: Διαχείριση Σχημάτων Παρουσίασης στο Android
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/androidjava/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα σε διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Μετατροπή σχήματος σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αναδιατάζετε, εξάγετε, στοιχίζετε και αντιστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Android via Java αναπαριστά τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/). Η συλλογή είναι τόσο ο χώρος όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοιβάγματός τους: το δείκτη `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να εντοπίσετε ένα σχήμα αξιόπιστα, μετά δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να αναδιατάξετε σχήματα. Τα τελευταία τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αντιστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, έτσι μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Ταυτοποίηση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και διατηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getName--) είναι χρήσιμο για πρότυπα υπό έλεγχο προγραμματιστών και είναι εύκολο να προβληθεί στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, οπότε καθιερώστε έναν κανόνα ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getAlternativeText--) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρέχει ο δημιουργός ήδη ταυτοποιεί το σχήμα. Είναι ορατό σε χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηρά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) είναι ένα αναγνωριστικό μόνο για ανάγνωση που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφής αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getUniqueId--) επιστρέφει ένα αναγνωριστικό με πεδίο εφαρμογής στην παρουσίαση, αλλά αυτό το αναγνωριστικό προορίζεται για πρόσθετα και μπορεί να επαναχρωματιστεί. Δεν πρέπει να θεωρηθεί μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτότητα είναι ουσιώδης, διατηρήστε την αντιστοίχηση σε δεδομένα εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Το παρακάτω παράδειγμα αναζητά με όνομα με ακριβή σύγκριση και αναφέρει το ID interop της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρεται σε αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Όταν μια λειτουργία είναι ειδική για τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη συγκεκριμένα τύπου. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν στη συλλογή άμεσα. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που συλλέχθηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν σε μέγεθος.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο στο μπροστά και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε κάθε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέους λογικούς ταυτοποιητές στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλόνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Κατά την αφαίρεση πολλαπλών αντιστοιχιών κατά τη διάρκεια επανάληψης με δείκτες, διατρέξτε τη συλλογή από το τέλος ώστε κάθε υπόλοιπος δείκτης να παραμένει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το σχήμα στον τρέχοντα δείκτη, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει περιττή μετατροπή τύπου.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μετά την αφαίρεση, ο αριθμός σχημάτων και οι δείκτες των μεταγενέστερων σχημάτων αλλάζουν. Οι αναφορές σε μη επηρεαζόμενα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης λάβετε υπόψη συνδέσμους, κινήσεις και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει παραπάνω από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ο καθορισμός του [Hidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) σε `true` διατηρεί το σχήμα στη συλλογή αλλά αποτρέπει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφέρθούν αργότερα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανισθεί ξανά από χρήστη ή από κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικάλυπτα σχήματα ζωγραφίζονται με σειρά της συλλογής. [reorder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `size() - 1` είναι το μπροστά μέρος.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στον τελικό δείκτη το φέρνει μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετιζόμενων σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν την προσανατολισμένη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα οπλισμένο παρόμοιο σχήμα σε κανονική διαφάνεια. Επιθεωρήστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getFillFormat--) και το [LineFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getLineFormat--) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλαπλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[writeAsSvg](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιέχει το σχήμα, όχι το πλήρες φόντο της διαφάνειας ή τα γειτονικά σχήματα.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Διατηρήστε την παρουσίαση ανοιχτή κατά την απόδοση. Το αποτέλεσμα εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Αν χρειάζεστε ολόκληρη τη σύνθεση, εξαγάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλώντης διεκδικεί την ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Η [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) υπερφορτώνει ώστε να στοιχίζει είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Η [ShapesAlignmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην άνω άκρη της διαφάνειας. Οι αναφορές σχήματος που επιστρέφονται μετατρέπονται στις τρέχουσες θέσεις τους αμέσως πριν τη στοίχιση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η στοίχιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για τον ορισμό του διαστήματος. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κάθετες ρυθμίσεις αντιστροφής και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/nullablebool/): `True` ενεργοποιεί την αντιστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα μη αναστραμμένο σχήμα.

![Το σχήμα πριν την αντιστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αντιστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) αντικαθιστά ολόκληρο το πλαίσιο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποθηκευμένο σχήμα κατοπτρίζεται οριζόντια και κάθετα διατηρώντας τη θέση, το μέγεθος και την περιστροφή.

![Το σχήμα μετά την αντιστροφή](flipped_shape.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Θα πρέπει να χρησιμοποιώ τον δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχυχρόνια επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε ένα επικυρωμένο `Name` ή συμβατική χρήση `AlternativeText` για πρότυπα που έχουν δημιουργηθεί, ή `OfficeInteropShapeId` για εργασίες interop σε επίπεδο διαφάνειας.

**Αφαιρεί η απόκρυψη ενός σχήματος το σχήμα από το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `addClone` προσθέτει το κλόνου στο τέλος της συλλογής, που είναι το μπροστινό τμήμα του z‑order. Χρησιμοποιήστε `insertClone` για να επιλέξετε αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.