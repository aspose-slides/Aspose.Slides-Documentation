---
title: Ενότητα
type: docs
weight: 90
url: /el/net/examples/elements/section/
keywords:
- ενότητα
- ενότητα διαφάνειας
- προσθήκη ενότητας
- πρόσβαση σε ενότητα
- διαγραφή ενότητας
- μετονομασία ενότητας
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών στο Aspose.Slides for .NET: δημιουργία, μετονομασία, αναδιάταξη και ομαδοποίηση διαφανειών με παραδείγματα C# για PPT, PPTX και ODP."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, διαγραφή και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη Ενότητας**

Δημιουργήστε μια ενότητα που ξεκινά σε μια συγκεκριμένη διαφάνεια.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Πρόσβαση σε Ενότητα**

Διαβάστε τις πληροφορίες της ενότητας από μια παρουσίαση.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Πρόσβαση σε ενότητα κατά δείκτη.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Διαγραφή Ενότητας**

Διαγράψτε μια ενότητα που προστέθηκε προηγουμένως.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Αφαιρέστε την πρώτη ενότητα.
    presentation.Sections.RemoveSection(section);
}
```

## **Μετονομασία Ενότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενότητας.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```