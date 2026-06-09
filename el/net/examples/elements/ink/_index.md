---
title: Μελάνη
type: docs
weight: 180
url: /el/net/examples/elements/ink/
keywords:
- μελάνη
- πρόσβαση σε μελάνη
- αφαίρεση μελάνης
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εργασία με Μελάνη στο Aspose.Slides για .NET: σχεδίαση, εισαγωγή και επεξεργασία γραμμών, ρύθμιση χρώματος και πλάτους, και εξαγωγή σε PPT, PPTX και ODP χρησιμοποιώντας παραδείγματα C#."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for .NET**.

> ❗ **Note:** Τα σχήματα μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέες γραμμές μελάνης προγραμματικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε τις υπάρχουσες μελάνες.

## **Πρόσβαση σε Μελάνη**

Διαβάστε τις ετικέτες από το πρώτο σχήμα μελάνης σε μια διαφάνεια.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Χρησιμοποιήστε το tagName όπως απαιτείται.
        }
    }
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια εάν υπάρχει.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```