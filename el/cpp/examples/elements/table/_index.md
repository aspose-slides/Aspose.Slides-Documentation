---
title: Πίνακας
type: docs
weight: 120
url: /el/cpp/examples/elements/table/
keywords:
- παράδειγμα κώδικα
- πίνακας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εργαστείτε με πίνακες στο Aspose.Slides for C++: δημιουργήστε, μορφοποιήστε, συγχωνεύστε κελιά, εφαρμόστε στυλ, εισάγετε δεδομένα και εξάγετε με παραδείγματα C++ για PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, αφαίρεσης και συγχώνευσης κελιών χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη πίνακα**

Δημιουργήστε έναν απλό πίνακα με δύο σειρές και δύο στήλες.

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **Πρόσβαση σε πίνακα**

Ανακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση πίνακα**

Διαγράψτε έναν πίνακα από μια διαφάνεια.

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **Συγχώνευση κελιών πίνακα**

Συγχωνεύστε τα διπλασιαζόμενα κελιά ενός πίνακα σε ένα ενιαίο κελί.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Συγχώνευση κελιών.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```