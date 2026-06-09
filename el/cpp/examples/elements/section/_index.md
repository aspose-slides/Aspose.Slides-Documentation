---
title: Ενότητα
type: docs
weight: 90
url: /el/cpp/examples/elements/section/
keywords:
- παράδειγμα κώδικα
- ενότητα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφάνειας στο Aspose.Slides για C++: δημιουργήστε, μετονομάστε, αναδιατάξτε και ομαδοποιήστε διαφάνειες με παραδείγματα C++ για PPT, PPTX και ODP."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, αφαίρεση και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη ενοότητας**

Δημιουργήστε μια ενότητα που αρχίζει σε μια συγκεκριμένη διαφάνεια.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Πρόσβαση σε ενότητα**

Διαβάστε πληροφορίες ενοότητας από μια παρουσίαση.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Πρόσβαση σε ενότητα με βάση το δείκτη.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Αφαίρεση ενοότητας**

Διαγράψτε μια προηγουμένως προστεθείσα ενότητα.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Αφαιρέστε την πρώτη ενότητα.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Μετονομασία ενοότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενοότητας.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```