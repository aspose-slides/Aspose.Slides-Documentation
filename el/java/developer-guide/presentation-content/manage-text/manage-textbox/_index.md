---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσμου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Το Aspose.Slides for Java καθιστά εύκολο τη δημιουργία, την επεξεργασία και την κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να βάλετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides για Java παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κείμενο.

{{% alert title="Πληροφορίες" color="info" %}}

Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape) που σας επιτρέπει να προσθέσετε σχήματα σε διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` να περιέχουν κείμενο. Τα σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) μπορούν όμως να περιέχουν κείμενο. 

{{% /alert %}}

{{% alert title="Σημείωση" color="warning" %}} 

Επομένως, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θέλετε να ελέγξετε και να επιβεβαιώσετε ότι μετατράπηκε μέσω της διεπαφής `IAutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrame), το οποίο είναι μια ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/java/manage-textbox/#update-text) σε αυτή τη σελίδα. 

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation). 
2. Αποκτήστε αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) με [ShapeType](https://reference.aspose.com/slides/el/java/com.aspose.slides/IGeometryShape#setShapeType-int-) ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοπροστιθέμενου αντικειμένου `IAutoShape`. 
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το εξής κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

```java
import com.aspose.slides.*;

// Δημιουργεί παρουσίαση
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέτει TextFrame στο Rectangle
    ashp.addTextFrame(" ");

    // Προσπελάζει το πλαίσιο κειμένου
    ITextFrame txtFrame = ashp.getTextFrame();

    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
    IPortion portion = para.getPortions().get_Item(0);

    // Ορίζει το κείμενο
    portion.setText("Aspose TextBox");

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/#isTextBox--) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) που σας επιτρέπει να εξετάζετε σχήματα και να εντοπίζετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας Java σας δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου: 

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

Σημειώστε ότι αν απλώς προσθέσετε ένα αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `addAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/) , η μέθοδος `isTextBox` του αυτόματου σχήματος θα επιστρέψει `false`. Ωστόσο, μετά την προσθήκη κειμένου στο αυτόματο σχήμα με τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

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

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) χωρίς να γνωρίζετε εκ των προτέρων ποιο αντικείμενο παρουσίας το περιέχει. Χρησιμοποιήστε τη μέθοδο [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--) για να επιστρέψετε στο ιδιοκτητικό [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, το [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει τον ιδιοκτήτη και το [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει `null`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση, έτσι η κλήση τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη τιμή για `null` πριν προσπελάσετε το σχήμα.

Για ένα πλήρες παράδειγμα που αναγνωρίζει τους ιδιοκτήτες σχήματος και κελιού πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [ColumnCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) και [ColumnSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormat) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)) που σας επιτρέπουν να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να ορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και το διάστημα σε points μεταξύ των στηλών. 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Προσθέτει TextFrame στο Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Λαμβάνει τη μορφοποίηση κειμένου του TextFrame
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

Το Aspose.Slides για Java παρέχει την ιδιότητα [ColumnCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormat)) που σας επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να ορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου. 

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
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
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
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

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλα τα κείμενα που περιέχονται σε μια παρουσίαση. 

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Διέρχεται τις παραγράφους στο πλαίσιο κειμένου
                {
                    for (IPortion portion : paragraph.getPortions()) //Διέρχεται κάθε τμήμα στην παράγραφο
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

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο** 

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κλικάρεται, οι χρήστες ανακατευθύνονται για να ανοίξουν τον σύνδεσμο. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`. 
2. Αποκτήστε αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοπροστιθέμενου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `IHyperlinkManager`. 
6. Αντιστοιχίστε το αντικείμενο `IHyperlinkManager` στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/Shape#getHyperlinkClick--) που σχετίζεται με το προτιμώμενο τμήμα του `TextFrame`. 
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

```java
import com.aspose.slides.*;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει ένα αντικείμενο AutoShape με τύπο Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Κάνει cast το σχήμα σε AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Πρόσβαση στην ιδιότητα ITextFrame που σχετίζεται με το AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Προσθέτει κείμενο στο πλαίσιο
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ορίζει το Hyperlink για το κείμενο του portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Αποθηκεύει την παρουσίαση PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και κράτησης θέσης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/java/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/) και μπορεί να παρακαμφθεί σε [layouts](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να εκτελέσω μαζική αντικατάσταση κειμένου σε όλη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε γραφήματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε αυτόματα σχήματα που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.