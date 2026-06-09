---
title: Ομαδικό Σχήμα
type: docs
weight: 170
url: /el/cpp/examples/elements/group-shape/
keywords:
- παράδειγμα κώδικα
- ομαδικό σχήμα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε ομαδικά σχήματα στο Aspose.Slides for C++: δημιουργήστε, ενσωματώστε, ευθυγραμμίστε, αλλάξτε σειρά και μορφοποιήστε ομαδικά σχήματα με παραδείγματα C++ σε παρουσιάσεις PPT, PPTX και ODP."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτά, αποομαδοποίησης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη Ομαδικού Σχήματος**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **Πρόσβαση σε Ομαδικό Σχήμα**

Ανακτήστε το πρώτο ομαδικό σχήμα από μια διαφάνεια.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση Ομαδικού Σχήματος**

Διαγράψτε ένα ομαδικό σχήμα από τη διαφάνεια.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **Απομαδοποίηση Σχημάτων**

Μετακινήστε τα σχήματα εκτός του ομαδικού δοχείου.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Μετακινήστε το σχήμα έξω από την ομάδα.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```