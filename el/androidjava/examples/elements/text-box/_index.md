---
title: Πλαίσιο Κειμένου
type: docs
weight: 40
url: /el/androidjava/examples/elements/text-box/
keywords:
- παράδειγμα κώδικα
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εργαστείτε με πλαίσια κειμένου στο Aspose.Slides για Android: προσθέστε, μορφοποιήστε, ευθυγραμμίστε, αναδιπλώστε, αυτόματη προσαρμογή και στιλιζάρετε κείμενο χρησιμοποιώντας Java για παρουσιάσεις PPT, PPTX και ODP."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέτετε, να έχετε πρόσβαση και να αφαιρείτε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη Πλαισίου Κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με κάποιο μορφοποιημένο κείμενο. Ακολουθεί η δημιουργία ενός:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Δημιουργήστε ένα σχήμα ορθογωνίου (προεπιλεγμένα είναι γεμάτο με περίγραμμα και χωρίς κείμενο).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Αφαιρέστε το γέμισμα και το περίγραμμα για να μοιάζει με τυπικό πλαίσιο κειμένου.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Ορίστε τη μορφοποίηση του κειμένου.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Ορίστε το πραγματικό περιεχόμενο κειμένου.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση:** Οποιοδήποτε `AutoShape` που περιέχει ένα μη κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε Πλαίσια Κειμένου κατά Περιεχόμενο**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη-κλειδί (π.χ. "Slide"), επαναλάβετε τις μορφές και ελέγξτε το κείμενό τους:

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

> 💡 **Συμβουλή:** Πάντα δημιουργήστε ένα αντίγραφο της συλλογής σχήματος πριν το τροποποιήσετε κατά την επανάληψη, ώστε να αποφύγετε σφάλματα τροποποίησης συλλογής.