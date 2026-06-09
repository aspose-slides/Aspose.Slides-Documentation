---
title: Σημείωση
type: docs
weight: 240
url: /el/net/examples/elements/note/
keywords:
- σημείωση
- προσθήκη διαφάνειας σημειώσεων
- πρόσβαση σε διαφάνεια σημειώσεων
- κατάργηση διαφάνειας σημειώσεων
- ενημέρωση κειμένου σημειώσεων
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δουλέψτε με τις σημειώσεις διαφάνειας στο Aspose.Slides για .NET: προσθέστε, διαβάστε, επεξεργαστείτε και εξάγετε τις σημειώσεις ομιλητή σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα C#."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να διαβάσετε, να καταργήσετε και να ενημερώσετε διαφάνειες σημειώσεων χρησιμοποιώντας το **Aspose.Slides for .NET**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργήστε μια διαφάνεια σημειώσεων και αντιστοιχίστε κείμενο σε αυτήν.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε το κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Κατάργηση διαφάνειας σημειώσεων**

Καταργήστε τη διαφάνεια σημειώσεων που σχετίζεται με μια διαφάνεια.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```