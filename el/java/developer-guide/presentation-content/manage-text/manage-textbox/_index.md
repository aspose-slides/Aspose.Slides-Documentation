---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με Java
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
- πρόσθεση στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε, εντοπίστε, μορφοποιήστε και ενημερώστε πλαίσια κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Εισαγωγή**

Στο Aspose.Slides for Java, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) αντιπροσωπεύει το πιο κοινό σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου [IAutoShape.getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Note" %}}
Κάθε αυτόματο σχήμα υλοποιεί το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα υλοποιεί το [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) πριν προσπελάσετε το κείμενό του.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε μια διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στη μέθοδο [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) μετρώνται σε points. Η μέθοδος [IAutoShape.addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο [IAutoShape.isTextBox](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#isTextBox--) για να προσδιορίσετε εάν ένα αυτόματο σχήμα θεωρείται πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που περιέχουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Ένα πλαίσιο κειμένου και ένα σχήμα](istextbox.png)

Το παρακάτω παράδειγμα εξετάζει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ένα πρόσφατα προστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της [IAutoShape.addTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ή του [ITextFrame.setText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Η προσθήκη ή η ανάθεση ενός κενό string αφήνει τη μέθοδο [IAutoShape.isTextBox](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/#isTextBox--) να επιστρέφει `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Οι δύο πρώτες κλήσεις εκτυπώνουν `true`; οι δύο τελευταίες εκτυπώνουν `false`.

## **Βρείτε το σχήμα που είναι ιδιοκτήτης ενός πλαισίου κειμένου**

Ο γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε τη μέθοδο μόνο για ανάγνωση [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--) για να μεταβείτε πίσω στο ιδιοκτητικό του [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα αυτόματο σχήμα ή σε άλλο σχήμα που περιέχει κείμενο, η μέθοδος [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει τον ιδιοκτήτη και η μέθοδος [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει `null`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για να εντοπίσετε τόσο σχήματα όσο και ιδιοκτήτες κελιών πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) διαχωρίζει το πλαίσιο κειμένου σε στήλες, ενώ η μέθοδος [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) ορίζει το κενό μεταξύ των στηλών σε points. Και οι δύο ρυθμίσεις ανήκουν στο [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/) και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο αναδιατάσσεται μεταξύ των στηλών στο ίδιο σχήμα· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου με τρεις στήλες και 10 points κενό μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή κειμένου από ξεχωριστές στήλες**

Χρησιμοποιήστε το [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#splitTextByColumns--) για να ανακτήσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει μία συμβολοσειρά για κάθε στήλη, με σειρά ανάγνωσης κατά στήλη. Ένα πλαίσιο κειμένου με μία στήλη παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από μια κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η μορφοποίηση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:
- Εξάγετε το κείμενο διατηρώντας τη σειρά ανάγνωσης κατά στήλη.
- Καταχωρήσετε ή συγκρίνετε το περιεχόμενο διαφανειών με πολλαπλές στήλες.
- Εξάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Εξετάσετε πώς αναδιανέμεται το κείμενο μετά από αλλαγή του αριθμού των στηλών με [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), του διαστήματος με [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται μέσα στο τρέχον [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/); δεν ροπίζει αυτόματα το κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή των στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, οπότε φροντίστε οι απαιτούμενες γραμματοσειρές να είναι διαθέσιμες όταν είναι σημαντικά συνεπή αποτελέσματα.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα με πολλές στήλες και πλαίσιο κειμένου, διαβάζει τον προρυθμισμένο αριθμό στηλών του και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε τα αυτόματα σχήματα και στη συνέχεια επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση των χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με `months` στο κείμενο των αυτόματων σχημάτων και κάνει κάθε επηρεασμένο τμήμα έντονο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αυτή η διέλευση ενημερώνει το κείμενο μόνο στα αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των δικών τους συλλογών.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Μπορεί να ανατεθεί ένας υπερσύνδεσμος σε ένα συγκεκριμένο τμήμα κειμένου, ώστε μόνο εκείνο το κείμενο να λειτουργεί ως κλικ‑συνδεδεμένο. Χρησιμοποιήστε το [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί συνδεδεμένο κείμενο και το αποθηκεύει σε μια παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

Ένα [placeholder](/slides/el/java/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίηση του από μια [master slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/) ή μια [layout slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά placeholder όταν η διάταξη αλλάζει.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Περιορίστε τη διέλευση σε σχήματα που υλοποιούν το [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση κειμένου. Τα γραφήματα, οι πίνακες και το SmartArt αποθηκεύουν το κείμενο στα δικά τους μοντέλα αντικειμένων, οπότε δεν τροποποιούνται από αυτόν τον βρόχο.