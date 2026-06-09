---
title: Πλαίσιο κειμένου
type: docs
weight: 40
url: /el/java/examples/elements/text-box/
keywords:
- παράδειγμα κώδικα
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δουλέψτε με πλαίσια κειμένου στο Aspose.Slides for Java: προσθέστε, μορφοποιήστε, ευθυγραμμίστε, αναδίπλωστε, αυτόματη προσαρμογή και μορφοποιήστε το κείμενο χρησιμοποιώντας Java για παρουσιάσεις PPT, PPTX και ODP."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ούτε περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέσετε, να προσπελάσετε και να αφαιρέσετε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη Πλαισίου Κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με μορφοποιημένο κείμενο. Δείτε πώς να δημιουργήσετε ένα:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Δημιουργία σχήματος ορθογωνίου (προεπιλογή γεμάτο με περίγραμμα και χωρίς κείμενο).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Αφαίρεση γεμίσματος και περιγράμματος ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Ορισμός μορφοποίησης κειμένου.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Ανάθεση του πραγματικού περιεχομένου κειμένου.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση:** Οποιοδήποτε `AutoShape` που περιέχει ένα μη κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε Πλαίσια Κειμένου κατά Περιεχόμενο**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη-κλειδί (π.χ. "Slide"), επαναλάβετε τα σχήματα και ελέγξτε το κείμενό τους:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Μόνο τα AutoShapes μπορούν να περιέχουν επεξεργάσιμο κείμενο.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Κάντε κάτι με το αντίστοιχο πλαίσιο κειμένου.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Πλαισίων Κειμένου κατά Περιεχόμενο**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη-κλειδί:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Συμβουλή:** Πάντα δημιουργείτε ένα αντίγραφο της συλλογής σ shapes πριν το τροποποιήσετε κατά την επανάληψη, ώστε να αποφύγετε σφάλματα τροποποίησης της συλλογής.