---
title: Μελάνη
type: docs
weight: 180
url: /el/cpp/examples/elements/ink/
keywords:
- παράδειγμα κώδικα
- μελάνη
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εργαστείτε με τη Μελάνη στο Aspose.Slides για C++: σχεδιάστε, εισάγετε και επεξεργαστείτε γραμμές, προσαρμόστε το χρώμα και το πλάτος, και εξάγετε σε PPT, PPTX και ODP χρησιμοποιώντας παραδείγματα C++."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες μορφές μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for C++**.

> ❗ **Σημείωση:** Οι μορφές μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέες γραμμές μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση στη Μελάνη**

Διαβάστε τις ετικέτες από την πρώτη μορφή μελάνης σε μια διαφάνεια.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Χρησιμοποιήστε το tagName όπως χρειάζεται.
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε μια μορφή μελάνης από τη διαφάνεια αν υπάρχει.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```