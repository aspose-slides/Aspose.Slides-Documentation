---
title: Tabell
type: docs
weight: 120
url: /sv/cpp/examples/elements/table/
keywords:
- kodexempel
- tabell
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med tabeller i Aspose.Slides for C++: skapa, formatera, slå ihop celler, tillämpa stilar, importera data och exportera med C++-exempel för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå ihop celler med hjälp av **Aspose.Slides for C++**.

## **Lägg till en tabell**

Skapa en enkel tabell med två rader och två kolumner.

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

## **Komma åt en tabell**

Hämta den första tabellformen på bilden.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Åtkomst till den första tabellen på bilden.
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

## **Ta bort en tabell**

Ta bort en tabell från en bild.

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

## **Slå ihop tabellceller**

Slå ihop intilliggande celler i en tabell till en enda cell.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Slå ihop celler.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```