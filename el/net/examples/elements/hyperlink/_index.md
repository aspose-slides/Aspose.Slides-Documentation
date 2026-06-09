---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/net/examples/elements/hyperlink/
keywords:
- υπερσύνδεσμος
- προσθήκη υπερσυνδέσμου
- πρόσβαση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθέστε και διαχειριστείτε υπερσυνδέσμους στο Aspose.Slides for .NET: κείμενο συνδέσμου, σχήματα και εικόνες, ορίστε προορισμούς και ενέργειες για PPT, PPTX και ODP με παραδείγματα C#."
---
Αυτό το άρθρο παρουσιάζει την προσθήκη, την πρόσβαση, την αφαίρεση και την ενημέρωση υπερσυνδέσμων σε σχήματα χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη υπερσύνδεσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε έναν εξωτερικό ιστότοπο.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Πρόσβαση σε υπερσύνδεσμο**

Αναγνώστε τις πληροφορίες του υπερσυνδέσμου από το κείμενο ενός σχήματος.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Αφαίρεση υπερσύνδεσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο του σχήματος.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Ενημέρωση υπερσύνδεσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που περιέχει ήδη έναν υπερσύνδεσμο, προσομοιώνοντας τον ασφαλή τρόπο με τον οποίο το PowerPoint ενημερώνει τους υπερσυνδέσμους.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
    // HyperlinkManager αντί για την άμεση ρύθμιση της ιδιότητας.
    // Αυτό μιμείται τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```