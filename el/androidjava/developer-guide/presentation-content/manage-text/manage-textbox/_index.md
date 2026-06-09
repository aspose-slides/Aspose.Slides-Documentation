---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις Android
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/androidjava/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Το Aspose.Slides για Android μέσω Java κάνει εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως υπάρχουν σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να τοποθετήσετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides για Android μέσω Java παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) που επιτρέπει την προσθήκη ενός σχήματος που περιέχει κείμενο.

{{% alert title="Info" color="info" %}}
Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape) που επιτρέπει την προσθήκη σχημάτων στις διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` να περιέχουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) μπορούν να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Επομένως, όταν ασχολείστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της διεπαφής `IAutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrame), το οποίο είναι ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/androidjava/manage-textbox/#update-text) σε αυτή τη σελίδα.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στην νεοδημιουργημένη παρουσία.
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) με [ShapeType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ορισμένο ως `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά για το νεοπροστέθηκε αντικείμενο `IAutoShape`.
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`.

Αυτός ο κώδικας Java—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```java
// Δημιουργεί παρουσίαση
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέτει TextFrame στο Rectangle
    ashp.addTextFrame(" ");

    // Πρόσβαση στο πλαίσιο κειμένου
    ITextFrame txtFrame = ashp.getTextFrame();

    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Δημιουργεί ένα αντικείμενο Portion για το παράγραφο
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

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/#isTextBox--) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/), επιτρέποντάς σας να εξετάζετε σχήματα και να εντοπίζετε πλαίσια κειμένου.

![Text box and shape](istextbox.png)

Αυτός ο κώδικας Java σας δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```java
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

Σημειώστε ότι εάν απλώς προσθέσετε ένα autoshape χρησιμοποιώντας τη μέθοδο `addAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/), η μέθοδος `isTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

```java
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

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [ColumnCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) και [ColumnSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat)) που σας επιτρέπουν να προσθέτετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε το διάστημα μεταξύ των στηλών σε points.

Αυτός ο κώδικας Java επιδεικνύει τη περιγραφόμενη λειτουργία:

```java
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Προσθέτει TextFrame στο Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Λαμβάνει τη μορφή κειμένου του TextFrame
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

Το Aspose.Slides για Android μέσω Java παρέχει την ιδιότητα [ColumnCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrameFormat)) που επιτρέπει την προσθήκη στηλών σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον προτιμώμενο αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```java
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
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσίαση.

Αυτός ο κώδικας Java επιδεικνύει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζουν:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Ελέγχει αν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Διατρέχει τις παραγράφους στο πλαίσιο κειμένου
                {
                    for (IPortion portion : paragraph.getPortions()) //Διατρέχει κάθε τμήμα στην παράγραφο
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

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν κάνετε κλικ στο πλαίσιο κειμένου, οι χρήστες κατευθύνονται για να ανοίξουν τον σύνδεσμο.

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`.
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στην νεοδημιουργημένη παρουσία.
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο ως `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε τη αναφορά του νεοπροστέθηκε αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο.
5. Δημιουργήστε μια παρουσία της κλάσης `IHyperlinkManager`.
6. Αναθέστε το αντικείμενο `IHyperlinkManager` στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) που σχετίζεται με το προτιμώμενο τμήμα του `TextFrame`.
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`.

Αυτός ο κώδικας Java—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Μετατρέπει το σχήμα σε AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Πρόσβαση στην ιδιότητα ITextFrame που σχετίζεται με το AutoShape
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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός σύμβολου θέσης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/androidjava/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/) και μπορεί να παρακαμφθεί σε [layouts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layouts.

**Πώς μπορώ να εκτελέσω μαζική αντικατάσταση κειμένου σε όλη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε διαγράμματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε auto‑shapes που διαθέτουν πλαίσια κειμένου και εξαιρέστε τα ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.