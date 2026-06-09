---
title: Σημείωση
type: docs
weight: 240
url: /el/cpp/examples/elements/note/
keywords:
- παράδειγμα κώδικα
- σημείωση
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δούλευμα με τις σημειώσεις διαφανειών στο Aspose.Slides για C++: προσθήκη, ανάγνωση, επεξεργασία και εξαγωγή σημειώσεων ομιλητή σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα C++."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να διαβάσετε, να καταργήσετε και να ενημερώσετε διαφάνειες σημειώσεων χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργήστε μια διαφάνεια σημειώσεων και αναθέστε κείμενο σε αυτήν.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε το κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **Αφαίρεση διαφάνειας σημειώσεων**

Αφαιρέστε τη διαφάνεια σημειώσεων που είναι συσχετισμένη με μια διαφάνεια.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```