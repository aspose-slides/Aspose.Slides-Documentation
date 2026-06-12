---
title: Tabel
type: docs
weight: 120
url: /nl/cpp/examples/elements/table/
keywords:
- codevoorbeeld
- tabel
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werk met tabellen in Aspose.Slides voor C++: maak, formatteer, voeg cellen samen, pas stijlen toe, importeer gegevens en exporteer met C++-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, het benaderen ervan, het verwijderen ervan en het samenvoegen van cellen met behulp van **Aspose.Slides for C++**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

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

## **Tabel benaderen**

Haal de eerste tabelvorm op de dia op.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Toegang tot eerste tabel op dia.
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

## **Tabel verwijderen**

Verwijder een tabel van een dia.

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

## **Tabelcellen samenvoegen**

Voeg aangrenzende cellen van een tabel samen tot één enkele cel.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Cellen samenvoegen.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```