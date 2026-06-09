---
title: Πλαίσιο κειμένου
type: docs
weight: 40
url: /el/net/examples/elements/text-box/
keywords:
- πλαίσιο κειμένου
- προσθήκη πλαισίου κειμένου
- πρόσβαση πλαισίου κειμένου
- αφαίρεση πλαισίου κειμένου
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εργασία με πλαίσια κειμένου στο Aspose.Slides για .NET: προσθήκη, μορφοποίηση, στοίχιση, αναδίπλωση, αυτόματη προσαρμογή και μορφοποίηση κειμένου χρησιμοποιώντας C# για παρουσιάσεις PPT, PPTX και ODP."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να καταργήσετε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη πλαισίου κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με μορφοποιημένο κείμενο. Ακολουθεί ο τρόπος δημιουργίας του:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Δημιουργία σχήματος ορθογωνίου (προεπιλογή: γεμισμένο με περίγραμμα και χωρίς κείμενο).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Αφαίρεση γεμίσματος και περιγράμματος ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Ορισμός μορφοποίησης κειμένου.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Ανάθεση του πραγματικού περιεχομένου κειμένου.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Σημείωση:** Κάθε `AutoShape` που περιέχει ένα μη‑κενό `TextFrame` μπορεί να λειτουργεί ως πλαίσιο κειμένου.

## **Πρόσβαση σε πλαίσια κειμένου κατά περιεχόμενο**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη‑κλειδί (π.χ. "Slide"), επαναλάβετε μέσω των σχημάτων και ελέγξτε το κείμενό τους:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Μόνο τα AutoShapes μπορούν να περιέχουν επεξεργάσιμο κείμενο.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Κάντε κάτι με το αντιστοιχούμενο πλαίσιο κειμένου.
            }
        }
    }
}
```

## **Κατάργηση πλαισίων κειμένου κατά περιεχόμενο**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη‑κλειδί:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Συμβουλή:** Πάντα δημιουργήστε ένα αντίγραφο της συλλογής σχημάτων πριν την τροποποιήσετε κατά την επανάληψη, ώστε να αποφύγετε σφάλματα τροποποίησης συλλογής.