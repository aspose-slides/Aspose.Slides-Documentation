---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/java/examples/elements/hyperlink/
keywords:
- παράδειγμα κώδικα
- υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσθέστε και διαχειριστείτε υπερσυνδέσμους στο Aspose.Slides for Java: κείμενο συνδέσμου, σχήματα και εικόνες, ορίστε προορισμούς και ενέργειες για PPT, PPTX και ODP με παραδείγματα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέτετε, να προσπελάζετε, να αφαιρείτε και να ενημερώνετε υπερσυνδέσμους σε σχήματα χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε μια εξωτερική ιστοσελίδα.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε υπερσύνδεσμο**

Διαβάστε πληροφορίες υπερσυνδέσμου από το τμήμα κειμένου ενός σχήματος.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο ενός σχήματος.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που ήδη περιέχει υπερσύνδεσμο, όπως το PowerPoint ενημερώνει ασφαλώς τους υπερσυνδέσμους.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
        // HyperlinkManager αντί για την άμεση ρύθμιση της ιδιότητας.
        // Αυτό μιμείται τον τρόπο με τον οποίο το PowerPoint ενημερώνει ασφαλώς τους υπερσυνδέσμους.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```