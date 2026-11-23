---
title: Διαμόρφωση κειμένου παρουσίασης σε JavaScript
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/nodejs-java/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- παρασκήνιο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμών
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- καρτέλες κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαμορφώστε και μορφοποιήστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και πολλά άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, διάστημα παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, διακοπές καρτέλας και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη του διαφάνεια είναι ένα πλαίσιο κειμένου, και η πρώτη του παράγραφος περιέχει το κείμενο που εμφανίζεται παρακάτω. Και οι δείκτες των διαφανειών και των σχημάτων είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/nodejs-java/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης μιας παραγράφου, ή χρησιμοποιήστε το [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) για μεμονωμένες περιοχές κειμένου.

Το ακόλουθο παράδειγμα ορίζει μια ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένες περιοχές έχουν προτεραιότητα πάνω από αυτήν την προεπιλογή:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **μερίδες κειμένου με έντονη γραμματοσειρά**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ορίστε το χρώμα επισήμανσης για την περιοχή κειμένου.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) για να ορίσετε την ευθυγράμμιση της παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά, δεξιά, μονόπλευρη κ.λπ.

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Μέσα σε Μία Γραμμή**

Χρησιμοποιήστε το [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) για να ευθυγραμμίσετε κάθετα περιοχές κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μία γραμμή. Αυτή η ρύθμιση εφαρμόζεται σε όλη την παράγραφο και ελέγχει την ευθυγράμμιση σε κάθε γραμμή της.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τέσσερα ετικετοποιημένα πλαίσια κειμένου σε μία διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε 18, 36 και 54 μονάδες, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί την αυτόματη προσαρμογή και τη περιτύλιξη, και κρατά τα πλαίσια κειμένου αρκετά μεγάλα ώστε να χωράει μόνο μία γραμμή.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Σύγκριση στοίχισης γραμματοσειράς Βάσης, Πάνω, Κέντρο και Κάτω με μικτές μεγέθη γραμματοσειράς](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι οι ορατά άκρα των μεμονωμένων γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει τόσο ένα κεφαλαίο γράμμα όσο και έναν πτώχο για να δείξει τη διαφορά μεταξύ στοίχισης βάσης και κάτω. Η διαθεσιμότητα και η αντικατάσταση γραμματοσειράς, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις του πλαισίου, τα περιθώρια, το διάστημα γραμμής, η περιτύλιξη και η αυτόματη προσαρμογή επίσης επηρεάζουν τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και τις ίδιες ρυθμίσεις διάταξης όταν συγκρίνετε λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), το οποίο ελέγχει οριζόντια στοίχιση παραγράφου, και από το [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), το οποίο θέτει το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η μορφοποίηση εκθέτη και υποσέλιδου μέσω του [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) μετατοπίζει τις μεμονωμένες περιοχές σε σχέση με τη βάση αντί να ορίζει στοίχιση γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που έχει οριστεί στο [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή αλφακαναλιού ARGB σε κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **μερίδες κειμένου με έντονη γραμματοσειρά**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Ορίστε τη διαφάνεια της περιοχής κειμένου.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Απόστασης Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε το [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 μονάδες διάστημα· οι αρνητικές τιμές μειώνουν το κείμενο.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη την παράγραφο**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **μερίδες κειμένου με έντονη γραμματοσειρά**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.getPortionFormat().setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο στενό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint ενδέχεται να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να γίνει η απόδοση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Το παράδειγμα αυτό απαιτεί το αρχείο «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων γραμματοσειρών, και θέτει ένα κατώφλι 100 μονάδων για περιοχές που χρησιμοποιούν Roboto. Αυτό απενεργοποιεί το kerning για τις αντίστοιχες περιοχές με μέγεθος γραμματοσειράς κάτω από 100 μονάδες:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για το κείμενο που είναι κάτω από το όριο, αυτή η ρύθμιση εμποδίζει το kerning και μπορεί να βοηθήσει το Aspose.Slides να ταιριάζει περισσότερο με την οπτική έξοδο του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτήν τη συγκεκριμένη συμπεριφορά του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ή σε μεμονωμένες περιοχές μέσω του [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Το ακόλουθο παράδειγμα ορίζει το προεπιλεγμένο μέγεθος γραμματοσειράς της πρώτης παραγράφου σε 12 μονάδες Times New Roman με έντονη, πλάγια και υπογράμμιση με κουκκίδες. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα πάνω από αυτές τις προεπιλογές.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Set the font properties for the paragraph.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το ακόλουθο παράδειγμα εφαρμόζει 13 μονάδες Times New Roman, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Ορίστε τις ιδιότητες γραμματοσειράς για την περιοχή κειμένου.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για περιοχές κειμένου](font_properties_for_text_portions.png)

## **Έλεγχος Κανονικοποίησης Ύψους Κειμένου**

Χρησιμοποιήστε το [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) όταν επαναφέρετε τυπογραφία προτύπου ή ερευνάτε διαφορές στο ύψος χαρακτήρων. Στο PowerPoint, η ενεργοποίηση της κανονικοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κατακόρυφα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στην περιοχή κειμένου. Δεν εγγυάται ίσα ύψη κειμένου μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool.True ή False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) για να ενεργοποιήσετε ή να απενεργοποιήσετε ρητά την κανονικοποίηση. `NullableBool.NotDefined` αφήνει τη τοπική ρύθμιση ανέπαφη, ώστε η περιοχή να κληρονομήσει την τιμή της, π.χ. από το [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) και διαβάστε το [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) για να λάβετε την επιλυμένη Boolean τιμή.

Το παρακάτω αυτόνομο παράδειγμα απαιτεί την εγκατάσταση του **Arial**. Δημιουργεί δύο μπλοκ κειμένου που περιέχουν τα ίδια κεφαλαία γράμματα, πεζά, πτώχους και τηρημένους χαρακτήρες σε 54 μονάδες. Και οι δύο παράγραφοι ενεργοποιούν την κανονικοποίηση εξ ορισμού. Η πάνω περιοχή την απενεργοποιεί ρητά· η κάτω κληρονομεί την τιμή. Τα μεγέθη πλαισίου, τα περιθώρια και το διάστημα παραγράφων είναι τα ίδια, με την περιτύλιξη και την αυτόματη προσαρμογή ανενεργές ώστε η σύγκριση να παραμένει συνεπής. Το παράδειγμα εκτυπώνει `False: false` και `NotDefined: true`, μετά αποθηκεύει το «text_height_normalization.pptx».

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η πάνω σειρά έχει την κανονικοποίηση απενεργοποιημένη (`False`); η κάτω σειρά κληρονομεί την ενεργοποιημένη ρύθμιση (`NotDefined` → `True`). Κρατήστε το Arial εγκατεστημένο για να αναπαραγάγετε αυτήν την εμφάνιση.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Η κανονικοποίηση αλλάζει το ύψος χαρακτήρων χωρίς να αλλάζει την τιμή του [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), η οποία καθορίζει το μέγεθος γραμματοσειράς σε μονάδες. Η παράγραφος [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) ελέγχει το διάστημα γραμμής, ενώ η [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το περιεχόμενό του προσαρμόζεται. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν ανεξάρτητα να επηρεάσουν τη συνολική διάταξη. Για περισσότερα σχετικά με τη μορφοποίηση και κληρονομικότητα παραγράφων, δείτε [Διαχείριση Παραγράφου](/slides/el/nodejs-java/manage-paragraph/).

## **Εφαρμογή και Κατάργηση Διακριτής Διαγραφής (Strikethrough)**

Χρησιμοποιήστε το [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) σε μια περιοχή κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένες εκφράσεις ή προηγούμενες τιμές χωρίς να διαγράψετε το αρχικό κείμενο. Ορίστε το σε [TextStrikethroughType.Single ή Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές μέσα από το κείμενο.

Για να καταργήσετε τη διακριτή διαγραφή, περάστε το [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Αυτό την απενεργοποιεί ρητά, ακόμη και αν η περιβάλλουσα μορφοποίηση την έχει ορίσει. Αντίθετα, το [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στην περιοχή να κληρονομήσει μορφοποίηση, π.χ. από την παράγραφο. Δεν εγγυάται ότι η διακριτή διαγραφή έχει αφαιρεθεί. Χρησιμοποιήστε το [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) για να διαβάσετε τη μορφοποίηση που προκύπτει, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει ξεχωριστές περιοχές για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, έτσι ώστε μόνο η προηγούμενη τιμή να επηρεαστεί. Η πρώτη σειρά εφαρμόζει και μετά αφαιρεί τη διακριτή διαγραφή· οι άλλες σειρές διατηρούν μονή και διπλή διακριτή διαγραφή. Η αλλαγή αυτής της ρύθμισης διατηρεί το κείμενο και τη λοιπή μορφοποίησή του, συμπεριλαμβανομένου του έντονου προηγούμενου τιμής.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Εφαρμόστε διακριτή διαγραφή, στη συνέχεια αφαιρέστε την ρητά από την πρώτη προηγούμενη τιμή.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς διακριτή διαγραφή, με μονή διακριτή διαγραφή και με διπλή διακριτή διαγραφή.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του κειμένου](text_rotation.png)

## **Προβολή Ψηφίων Δίπλα Δίπλα σε Κατακόρυφο Κείμενο**

Για να διατηρήσετε έναν δίψήφιο αριθμό ενωμένο σε μια κατακόρυφη ιαπωνική ετικέτα, τοποθετήστε και τα δύο ψηφία σε μία περιοχή κειμένου και καλέστε το [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) στη μορφοποίηση εκείνης της περιοχής. Το παράδειγμα χρησιμοποιεί το [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) και 40 μονάδες MS Gothic για και τις δύο ετικέτες. Μόνο η τιμή του [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) που περνάται στην αριθμητική περιοχή διαφέρει.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στο PowerPoint, η αριστερή ετικέτα (`True`) εμφανίζει τα ψηφία στη θέση τους, ένα δίπλα στο άλλο, μεταξύ των χαρακτήρων 和 και 年. Στη δεξιά ετικέτα (`False`), τα ψηφία περιστρέφονται 90 μοίρες δεξιόστροφα. Οι γύρω ιαπωνικοί χαρακτήρες παραμένουν όρθιοι και στις δύο ετικέτες.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαισίες Κειμένου**

Χρησιμοποιήστε το [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή του κειμένου](custom_text_rotation.png)

## **Ορισμός Διάστιχου Γραμμών Παραγράφων**

Το Aspose.Slides παρέχει τις μεθόδους [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) και [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) για να ελέγξετε το διάστημα παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε μονάδες.

Το ακόλουθο παράδειγμα θέτει το εσωτερικό διάστημα της πρώτης παραγράφου στο 200 % του ύψους της γραμμής (διπλό διάστημα):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Αναδιπλώσεων Γραμμής**

Οι κανόνες αναδίπλωσης γραμμής της παραγράφου είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ανατολικοασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), έτσι εφαρμόζονται σε ολόκληρη την παράγραφο:

- Το [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) ελέγχει τους κανόνες αναδίπλωσης για το λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου περιβάλλει το ανατολικοασιατικό κείμενο και η στίξη.
- Το [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ελέγχει τους κανόνες αναδίπλωσης για το ανατολικοασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών σε χαρακτήρες στην αρχή και στο τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), το οποίο ενεργοποιεί την αυτόματη αναδίπλωση εντός ενός πλαισίου κειμένου. Επηρεάζουν τη διάταξη όταν συμβαίνει η αναδίπλωση· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής εξαναγκάζει νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινεζικό και λατινικό κείμενο. Ορίζει ρητά και τις δύο επιλογές αναδίπλωσης και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάποιον από τους κανόνες, αλλάξτε την αντίστοιχη τιμή ενώ διατηρείτε τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί 24 μονάδες Arial και SimSun με πλάτος πλαισίου 160 μονάδες και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) καλείται με το [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερές.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Hanging Punctuation**

Το [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) επιτρέπει σε κατάλληλη στίξη να εκτείνεται πέρα από το δεξί άκρο της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε όλη την παράγραφο και διαφέρει από το hanging indent.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί την hanging punctuation σε ένα πλαίσιο κειμένου πλάτους 100 μονάδων και αποθηκεύει το «hanging_punctuation.pptx». Με 24 μονάδες Arial και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η περιτύλιξη είναι ενεργοποιημένη και η αυτόματη προσαρμογή ανενεργή ώστε το διαθέσιμο πλάτος να παραμείνει σταθερό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Δεν κάθε σημάδι στίξης μπορεί να κρεμαστεί. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφησαν πιο πάνω](#control-line-breaking) ισχύουν επίσης για αυτή τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο θα συρρικνωθεί, θα υπερχειλίσει ή θα αλλάξει το μέγεθος του σχήματος αυτόματα. Το παρακάτω παράδειγμα διαμορφώνει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει στο κείμενό του και αποθηκεύει το αποτέλεσμα σε «autofit_type.pptx».

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς αλλάζει το πλάτος του κειμένου ή του σχήματος, δείτε [Count Rendered Lines](/slides/el/nodejs-java/manage-paragraph/). Ο μόνος αριθμός γραμμών δεν δείχνει αν το κείμενο υπερέχει του περιέκτη του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα σε «text_anchor.pptx».

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Καρτέλας Κειμένου**

Χρησιμοποιήστε το [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) και το [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) για να διαμορφώσετε τις διακοπές καρτέλας σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα καρτέλας σε 100 μονάδες και προσθέτει μια αριστερά ευθυγραμμισμένη διακοπή καρτέλας στα 30 μονάδες. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες καρτέλας.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι διακοπές καρτέλας της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου (Proofing Language)**

Το Aspose.Slides παρέχει το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου για μια περιοχή κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για έλεγχο ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά τα περιεχόμενα της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά της και ορίζει τη γλώσσα ελέγχου για απλοποιημένα κινέζικα (`zh-CN`). Αποθηκεύει το αποτέλεσμα σε «proofing_language.pptx»:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ορίστε το Id της γλώσσας ελέγχου.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αντιγραφή Μεταδεδομένων Γλώσσας**

Κατά την αντιγραφή πολυγλωσσικού κειμένου από ένα πρότυπο, διατηρήστε τόσο το [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) όσο και το [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια πηγή με US English ως γλώσσα και French ως εναλλακτική γλώσσα και αντιγράφει το κείμενο και τα αναγνωριστικά σε μια περιοχή σε μια νέα παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Αν η πηγή δεν έχει εναλλακτική γλώσσα, το null καθαρίζει την τιμή προορισμού.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να δοκιμάσετε μια πηγή χωρίς εναλλακτική γλώσσα, παραλείψτε την ανάθεση του `"fr-FR"`. Η εναλλακτική ταυτοποίηση είναι τότε `null`, και η ίδια δήλωση αντιγραφής διατηρεί την απουσία της χωρίς να εισάγει προεπιλεγμένη τιμή, ακόμα και αν ο προορισμός είχε προηγουμένως ανατεθεί εναλλακτική γλώσσα.

Αυτοί οι ταυτοποιητές αποθηκεύονται ως μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό θα επιλέξει το PowerPoint για έλεγχο ορθογραφίας ή γραμματικής.

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποίηστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να καθορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με US English ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη του περιοχή κειμένου.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα νέο ορθογώνιο σχήμα με κείμενο.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Ελέγξτε τη γλώσσα της πρώτης περιοχής.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 μονάδων, έντονη, ως προεπιλογή για παραγράφους ανώτερου επιπέδου σε νέα παρουσίαση και την αποθηκεύει ως «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός αν μια πιο συγκεκριμένη μορφοποίηση τις υπερκαλύψει.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε τη μορφοποίηση παραγράφου πρώτου επιπέδου.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή Κειμένου με το Εφέ All‑Caps**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** στη γραμματοσειρά κάνει το κείμενο να εμφανίζεται κεφαλαία στη διαφάνεια, ακόμη και αν αρχικά είχε πληκτρολογηθεί πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάζει με το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του παράγραφος η πρώτη της περιοχή περιέχει το «Hello, Aspose!» με εφαρμοσμένο εφέ All Caps, όπως φαίνεται παρακάτω.

![The All Caps effect](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) και μορφοποίηστε την παράγραφο μέσω του [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Πώς μπορώ να εφαρμόσω ένα διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε ένα διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Ορίστε το [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) σε [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) και ρυθμίστε τις διαβαθμίσεις, την κατεύθυνση και τη διαφάνεια.