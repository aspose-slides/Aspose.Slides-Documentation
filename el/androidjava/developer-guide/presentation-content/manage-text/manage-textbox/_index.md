---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις στο Android
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
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

Στο Aspose.Slides for Android via Java, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η διεπαφή IAutoShape αντιπροσωπεύει το πιο κοινό σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου IAutoShape.getTextFrame.

{{% alert color="info" title="Σημείωση" %}}
Κάθε αυτόματο σχήμα υλοποιεί το IShape, αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα υλοποιεί το IAutoShape πριν αποκτήσετε πρόσβαση στο κείμενό του.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

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

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στη μέθοδο IShapeCollection.addAutoShape μετρώνται σε πόντους. Η μέθοδος IAutoShape.addTextFrame αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο IAutoShape.isTextBox για να προσδιορίσετε εάν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που περιέχουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

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

Ένα νέο προστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου έως ότου περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της IAutoShape.addTextFrame ή της ITextFrame.setText. Η προσθήκη ή η ανάθεση ενός κενού συμβολοσειράς κάνει τη μέθοδο IAutoShape.isTextBox να επιστρέφει `false`:

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

Οι πρώτες δύο κλήσεις εκτυπώνουν `true`; οι τελευταίες δύο εκτυπώνουν `false`.

## **Βρείτε το σχήμα που κατέχει ένα πλαίσιο κειμένου**

Ο γενικός κώδικας επεξεργασίας κειμένου ενδέχεται να λάβει ένα ITextFrame χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε τη μόνο για ανάγνωση μέθοδο ITextFrame.getParentShape για να μεταβείτε πίσω στο κατέχον IShape.

Για ένα πλαίσιο κειμένου που ανήκει σε αυτόματο σχήμα ή άλλο σχήμα που περιέχει κείμενο, η ITextFrame.getParentShape επιστρέφει τον κάτοχο και η ITextFrame.getParentCell επιστρέφει `null`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για την ταυτοποίηση τόσο των σ Shape όσο και των ιδιοκτητών κελιών πίνακα, περιλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/androidjava/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος ITextFrameFormat.setColumnCount διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η ITextFrameFormat.setColumnSpacing ορίζει το κενό μεταξύ των στηλών σε πόντους. Και οι δύο ρυθμίσεις ανήκουν στο ITextFrameFormat και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο αναδιατάσσεται μεταξύ των στηλών μέσα στο ίδιο σχήμα· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 πόντους μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

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

## **Εξαγωγή κειμένου από μεμονωμένες στήλες**

Χρησιμοποιήστε τη ITextFrame.splitTextByColumns για να ανακτήσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει μια συμβολοσειρά για κάθε στήλη, με σειρά ανάγνωσης βάσει στήλης. Ένα πλαίσιο κειμένου μίας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από μια κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η μορφοποίηση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:
- Εξαγωγή κειμένου διατηρώντας τη σειρά ανάγνωσης βάσει στήλης.
- Δείκτης ή σύγκριση του περιεχομένου των διαφανειών πολλών στηλών.
- Εξαγωγή κάθε στήλης σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλη προορισμός.
- Επιθεώρηση του τρόπου που αναδιανέμεται το κείμενο μετά την αλλαγή του αριθμού στηλών με ITextFrameFormat.setColumnCount, του διαστήματος με ITextFrameFormat.setColumnSpacing, της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος ITextFrame· δεν ρέει αυτόματα το κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή των στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, οπότε βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν είναι σημαντικό το συνεπές αποτέλεσμα.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον διαμορφωμένο αριθμό στηλών του και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε τα αυτόματα σχήματα και στη συνέχεια επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με `months` στο κείμενο των αυτόματων σχημάτων και κάνει κάθε επηρεαζόμενο τμήμα έντονο:

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

Αυτή η διέλευση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των δικών τους συλλογών.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Μπορείτε να αντιστοιχίσετε έναν υπερσύνδεσμο σε ένα συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικ-σύνδεσμος. Χρησιμοποιήστε την IHyperlinkManager.setExternalHyperlinkClick για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με σύνδεσμο και το αποθηκεύει σε μια παρουσίαση:

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

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός θέματος κράτησης κειμένου σε κύρια ή διάταξη διαφάνειας;**

Ένα [θέμα κράτησης](/slides/el/androidjava/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίησή του από μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/) ή μια [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στην διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά θέματος κράτησης όταν η διάταξη αλλάζει.

**Πώς μπορώ να αντικαταστήσω το κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διέλευση σε σχήματα που υλοποιούν το IAutoShape, όπως φαίνεται στο παράδειγμα Ενημέρωση κειμένου. Τα διαγράμματα, οι πίνακες και το SmartArt αποθηκεύουν το κείμενο στα δικά τους μοντέλα αντικειμένων, οπότε δεν τροποποιούνται από αυτόν τον βρόχο.