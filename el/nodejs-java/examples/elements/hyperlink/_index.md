---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/nodejs-java/examples/elements/hyperlink/
keywords:
- παράδειγμα κώδικα
- υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε και διαχειριστείτε υπερσυνδέσμους στο Aspose.Slides για Node.js: κείμενο συνδέσμου, σχήματα και εικόνες, ορίστε προορισμούς και ενέργειες για PPT, PPTX και ODP με παραδείγματα."
---
Αυτό το άρθρο δείχνει την προσθήκη, την πρόσβαση, την αφαίρεση και την ενημέρωση υπερσυνδέσμων σε σχήματα χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε έναν εξωτερικό ιστότοπο.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε υπερσύνδεσμο**

Διαβάστε τον υπερσύνδεσμο από το τμήμα κειμένου ενός σχήματος.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει το κείμενο με υπερσύνδεσμο.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο ενός σχήματος.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει το κείμενο με υπερσύνδεσμο.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που περιέχει ήδη έναν υπερσύνδεσμο, προσομοιώνοντας τον τρόπο με τον οποίο το PowerPoint ενημερώνει τους υπερσυνδέσμους με ασφάλεια.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει το κείμενο με υπερσύνδεσμο.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
        // HyperlinkManager αντί για άμεση ρύθμιση της ιδιότητας.
        // Αυτό προσομοιώνει τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```