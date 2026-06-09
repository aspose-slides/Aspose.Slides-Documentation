---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/androidjava/examples/elements/hyperlink/
keywords:
- παράδειγμα κώδικα
- υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθήκη και διαχείριση υπερσυνδέσμων στο Aspose.Slides για Android: σύνδεση κειμένου, σχημάτων και εικόνων, ορισμός προορισμών και ενεργειών για PPT, PPTX και ODP με παραδείγματα Java."
---
Αυτό το άρθρο παρουσιάζει την προσθήκη, την πρόσβαση, την κατάργηση και την ενημέρωση των υπερσυνδέσμων σε σχήματα χρησιμοποιώντας το **Aspose.Slides for Android via Java**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε εξωτερική ιστοσελίδα.

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

Διαβάστε τις πληροφορίες του υπερσυνδέσμου από το τμήμα κειμένου ενός σχήματος.

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

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που ήδη περιέχει υπερσύνδεσμο, μιμούμενοι τον τρόπο με τον οποίο το PowerPoint ενημερώνει ασφαλώς τους υπερσυνδέσμους.

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

        // Η αλλαγή ενός υπερσυνδέσμου σε υπάρχον κείμενο πρέπει να γίνεται μέσω
        // HyperlinkManager αντί να ορίζετε την ιδιότητα άμεσα.
        // Αυτό μιμείται τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```