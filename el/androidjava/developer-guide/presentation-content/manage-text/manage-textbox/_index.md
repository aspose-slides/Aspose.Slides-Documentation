---
title: Διαχείριση κουτιών κειμένου σε παρουσιάσεις για Android
linktitle: Διαχείριση κουτιού κειμένου
type: docs
weight: 20
url: /el/androidjava/manage-textbox/
keywords:
  - κουτί κειμένου
  - πλαίσιο κειμένου
  - προσθήκη κειμένου
  - ενημέρωση κειμένου
  - δημιουργία κουτιού κειμένου
  - έλεγχος κουτιού κειμένου
  - προσθήκη στήλης κειμένου
  - προσθήκη υπερσυνδέσμου
  - PowerPoint
  - παρουσίαση
  - Android
  - Java
  - Aspose.Slides
description: "Το Aspose.Slides for Android μέσω Java διευκολύνει τη δημιουργία, την επεξεργασία και την κλωνοποίηση κουτιών κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε κουτιά κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα κουτί κειμένου και έπειτα να τοποθετήσετε κάποιο κείμενο μέσα στο κουτί. Το Aspose.Slides for Android via Java παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κείμενο.

{{% alert title="Πληροφορίες" color="info" %}}
Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape) που σας επιτρέπει να προσθέτετε σχήματα σε διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` να περιέχουν κείμενο. Αντιθέτως, σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) μπορεί να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Σημείωση" color="warning" %}} 
Επομένως, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι αυτό μετατράπηκε μέσω της διεπαφής `IAutoShape`. Μόνον τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrame), το οποίο είναι μια ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/androidjava/manage-textbox/#update-text) σε αυτήν τη σελίδα.
{{% /alert %}}

## **Δημιουργία κουτιού κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα κουτί κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) με [ShapeType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοπροστιθέμενου αντικειμένου `IAutoShape`.
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε αυτό το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας Java — υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```java
import com.aspose.slides.*;

// Αρχικοποιεί την παρουσίαση
Presentation pres = new Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο ορισμένο σε Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέτει TextFrame στο Rectangle
    ashp.addTextFrame(" ");

    // Αποκτά το πλαίσιο κειμένου
    ITextFrame txtFrame = ashp.getTextFrame();

    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Δημιουργεί το αντικείμενο Portion για την παράγραφο
    IPortion portion = para.getPortions().get_Item(0);

    // Ορίζει το κείμενο
    portion.setText("Aspose TextBox");

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Έλεγχος για σχήμα κουτιού κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#isTextBox--) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/), επιτρέποντάς σας να εξετάζετε σχήματα και να εντοπίζετε κουτιά κειμένου.

![Κουτί κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας Java δείχνει πώς να ελέγξετε εάν ένα σχήμα δημιουργήθηκε ως κουτί κειμένου: 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Σημειώστε ότι εάν απλώς προσθέσετε ένα αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `addAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/), η μέθοδος `isTextBox` του αυτόματου σχήματος θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο αυτόματο σχήμα με τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() επιστρέφει false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() επιστρέφει true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() επιστρέφει false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() επιστρέφει true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() επιστρέφει false
shape3.addTextFrame("");
// shape3.isTextBox() επιστρέφει false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() επιστρέφει false
shape4.getTextFrame().setText("");
// shape4.isTextBox() επιστρέφει false
```

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) χωρίς να γνωρίζετε εκ των προτέρων ποια παρουσίαση το περιέχει. Χρησιμοποιήστε τη μέθοδο [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentShape--) για να μεταβείτε πίσω στο ιδιοκτητικό [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, η μέθοδος [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει τον κάτοχο και η [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει `null`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση, έτσι η κλήση τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη τιμή για `null` πριν έχετε πρόσβαση στο σχήμα.

Για ένα πλήρες παράδειγμα που εντοπίζει κατόχους σχήματος και κελιού πίνακα, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/androidjava/search-and-replace-text/).

## **Προσθήκη στηλών σε κουτί κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [ColumnCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) και [ColumnSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat)) που σας επιτρέπουν να προσθέτετε στήλες σε κουτιά κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα κουτί κειμένου και να ορίσετε το διάστημα σε σημεία μεταξύ των στηλών.

Αυτός ο κώδικας σε Java δείχνει τη περιγραφόμενη λειτουργία: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο ορισμένο σε Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Προσθέτει TextFrame στο Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Αποκτά τη μορφοποίηση κειμένου του TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Καθορίζει τον αριθμό των στηλών στο TextFrame
    format.setColumnCount(3);

    // Καθορίζει το διάστημα μεταξύ των στηλών
    format.setColumnSpacing(10);

    // Αποθηκεύει την παρουσίαση
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη στηλών σε πλαίσιο κειμένου**
Το Aspose.Slides for Android via Java παρέχει την ιδιότητα [ColumnCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat)) που σας επιτρέπει να προσθέτετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα κουτί κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσίαση.

Αυτός ο κώδικας Java δείχνει μια λειτουργία κατά την οποία όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζουν:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Ελέγχει αν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Διασχίζει τις παραγράφους στο πλαίσιο κειμένου
                {
                    for (IPortion portion : paragraph.getPortions()) //Διασχίζει κάθε τμήμα στην παράγραφο
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Αλλάζει το κείμενο
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Αλλάζει τη μορφοποίηση
                    }
                }
            }
        }
    }

    //Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη κουτιού κειμένου με υπερσύνδεσμο** 

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα κουτί κειμένου. Όταν το κουτί κειμένου κάνει κλικ, οι χρήστες οδηγούνται στο άνοιγμα του συνδέσμου. 

Για να προσθέσετε ένα κουτί κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation`. 
2. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε μια αναφορά του νεοπροστιθέμενου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` και ορίστε το κείμενο του πρώτου τμήματός του. Στο παρακάτω παράδειγμα, χρησιμοποιήσαμε αυτό το κείμενο: *Aspose.Slides*
5. Αποκτήστε το αντικείμενο [IHyperlinkManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/) από το `PortionFormat` του προτιμώμενου τμήματος του `TextFrame`.
6. Καλέστε τη μέθοδο [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) σε αυτό το αντικείμενο για να ορίσετε το σύνδεσμο που ανοίγει όταν γίνει κλικ στο κείμενο.
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας Java — υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε ένα κουτί κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```java
import com.aspose.slides.*;

// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο σε Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Μετατρέπει το σχήμα σε AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Προσπελαύνει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Προσθέτει κείμενο στο πλαίσιο
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ορίζει τον υπερσύνδεσμο για το κείμενο του τμήματος
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Αποθηκεύει την παρουσίαση PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ κουτιού κειμένου και θέσης κράτησης κειμένου όταν εργάζεστε με κυρίως διαφάνειες;**

Ένα [placeholder](/slides/el/androidjava/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/) και μπορεί να αντικατασταθεί στα [layouts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslide/), ενώ ένα κανονικό κουτί κειμένου είναι ένα ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layouts.

**Πώς μπορώ να εκτελέσω αντικατάσταση κειμένου μαζικά σε ολόκληρη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε διαγράμματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε auto‑shapes που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.