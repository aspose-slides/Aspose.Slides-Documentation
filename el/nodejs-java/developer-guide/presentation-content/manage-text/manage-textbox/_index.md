---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/nodejs-java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Στο Aspose.Slides για Node.js μέσω Java, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η κλάση [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) αντιπροσωπεύει το πιο συνηθισμένο σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου [AutoShape.getTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Κάθε αυτόματο σχήμα προέρχεται από το [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα είναι μια παρουσία του [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) πριν αποκτήσετε πρόσβαση στο κείμενό του.

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στο [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addAutoShape) μετρώνται σε σημεία. Η [AutoShape.addTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#addTextFrame) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο [AutoShape.isTextBox](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#isTextBox) για να προσδιορίσετε εάν ένα αυτόματο σχήμα θεωρείται πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα με κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Ένα πλαίσιο κειμένου και ένα σχήμα](istextbox.png)

Το παρακάτω παράδειγμα ελέγχει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ένα πρόσφατα προστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της [AutoShape.addTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#addTextFrame) ή της [TextFrame.setText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#setText). Η προσθήκη ή η ανάθεση ενός κενής συμβολοσειράς αφήνει τη [AutoShape.isTextBox](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#isTextBox) να επιστρέφει `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Οι δύο πρώτες κλήσεις εκτυπώνουν `true`; οι δύο τελευταίες εκτυπώνουν `false`.

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε τη μέθοδο μόνο για ανάγνωση [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape) για να επιστρέψετε στο ιδιοκτήτη του [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα αυτόματο σχήμα ή σε άλλο σχήμα που φέρει κείμενο, η [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape) επιστρέφει τον ιδιοκτήτη και η [TextFrame.getParentCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentCell) επιστρέφει `null`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για να εντοπίσετε τόσο ιδιοκτήτες σχήματος όσο και κελιού πίνακα, συμπεριλαμβανομένων σ shapes που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/nodejs-java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setColumnCount) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) ορίζει το κενό μεταξύ των στηλών σε σημεία. Και οι δύο ρυθμίσεις ανήκουν στο [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/) και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο επαναδιανέμεται μεταξύ των στηλών εντός του ίδιου σχήματος· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 σημεία μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή κειμένου από επιμέρους στήλες**

Χρησιμοποιήστε το [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#splitTextByColumns) για να ανακτήσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει μια συμβολοσειρά για κάθε στήλη, με βάση τη σειρά ανάγνωσης στήλης. Ένα πλαίσιο κειμένου μίας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η μορφοποίηση επιπέδου τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:

- Εξάγετε κείμενο διατηρώντας τη σειρά ανάγνωσης βάσει στηλών.
- Ευρετήσετε ή συγκρίνετε το περιεχόμενο διαφανειών πολλαπλών στηλών.
- Εξάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Εξετάσετε πώς το κείμενο αναδιανέμεται μετά την αλλαγή του αριθμού στηλών με [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setColumnCount), του διαστήματος με [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/); δεν ρέει αυτόματα κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, γι' αυτό βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν τα συνεπή αποτελέσματα είναι σημαντικά.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον ρυθμισμένο αριθμό στηλών και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με το `months` σε κείμενο αυτόματου σχήματος και κάνει κάθε επηρεασμένο τμήμα έντονο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η διέλευση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των δικών τους συλλογών.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεση**

Μια υπερσύνδεση μπορεί να εκχωρηθεί σε ένα συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικστέ σύνδεσμος. Χρησιμοποιήστε το [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί συνδεδεμένο κείμενο και το αποθηκεύει σε μια παρουσίαση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός κράτησης θέσης κειμένου σε κύρια ή διάταξη διαφάνειας;**

Ένα [placeholder](/slides/el/nodejs-java/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίηση του από μια [master slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) ή μια [layout slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά συμπεριφορά κράτησης θέσης όταν η διάταξη αλλάζει.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διέλευση σε σχήματα που είναι παρουσίες του [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση Κειμένου. Τα διαγράμματα, οι πίνακες και το SmartArt αποθηκεύουν το κείμενο στα δικά τους μοντέλα αντικειμένων, επομένως δεν τροποποιούνται από αυτόν τον βρόχο.