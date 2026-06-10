---
title: Táblázat
type: docs
weight: 120
url: /hu/cpp/examples/elements/table/
keywords:
- kódpélda
- táblázat
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ táblákkal való munkavégzése: létrehozás, formázás, cellák egyesítése, stílusok alkalmazása, adatok importálása, és exportálás C++ példákkal PPT, PPTX és ODP formátumokra."
---
Példák táblák hozzáadására, elérésére, eltávolítására és a cellák egyesítésére az **Aspose.Slides for C++** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblát két sorral és két oszloppal.

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

## **Táblához hozzáférés**

Szerezze meg az első táblázat alakzatot a dián.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Az első táblázat elérése a dián.
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

## **Táblázat eltávolítása**

Törölje a táblázatot a diáról.

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

## **Táblázat celláinak egyesítése**

Egyesítsen szomszédos táblázatcellákat egyetlen cellává.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Cellák egyesítése.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```