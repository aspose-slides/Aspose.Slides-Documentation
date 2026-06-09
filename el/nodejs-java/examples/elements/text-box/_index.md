---
title: Πλαίσιο κειμένου
type: docs
weight: 40
url: /el/nodejs-java/examples/elements/text-box/
keywords:
- παράδειγμα κώδικα
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δουλέψτε με πλαίσια κειμένου στο Aspose.Slides για Node.js: προσθέστε, μορφοποιήστε, ευθυγραμμίστε, αναμίξτε, προσαρμόστε αυτόματα και μορφοποιήστε το κείμενο χρησιμοποιώντας JavaScript για παρουσιάσεις PPT, PPTX και ODP."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Πρακτικά οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέσετε, να προσπελάσετε και να αφαιρέσετε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη πλαισίου κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με μορφοποιημένο κείμενο. Ακολουθεί η διαδικασία δημιουργίας ενός:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Δημιουργήστε ένα ορθογώνιο σχήμα (προεπιλογή: γεμάτο με περίγραμμα και χωρίς κείμενο).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Αφαιρέστε το γέμισμα και το περίγραμμα ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Ορίστε τη μορφοποίηση κειμένου.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Αναθέστε το πραγματικό περιεχόμενο κειμένου.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση:** Οποιοδήποτε `AutoShape` που περιέχει ένα μη κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε πλαίσιο κειμένου**

Ανακτήστε το πρώτο πλαίσιο κειμένου από τη διαφάνεια.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Μόνο τα AutoShape μπορούν να περιέχουν επεξεργάσιμο κείμενο.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση πλαισίων κειμένου κατά περιεχόμενο**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη-κλειδί:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Συμβουλή:** Πάντα δημιουργείτε ένα αντίγραφο της συλλογής σχημάτων πριν το τροποποιήσετε κατά την επανάληψη, ώστε να αποφύγετε σφάλματα τροποποίησης της συλλογής.