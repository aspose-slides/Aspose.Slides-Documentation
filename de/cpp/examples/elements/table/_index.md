---
title: Tabelle
type: docs
weight: 120
url: /de/cpp/examples/elements/table/
keywords:
- Codebeispiel
- Tabelle
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Tabellen in Aspose.Slides for C++: Erstellen, formatieren, Zellen zusammenführen, Stile anwenden, Daten importieren und mit C++-Beispielen für PPT, PPTX und ODP exportieren."
---
Beispiele zum Hinzufügen von Tabellen, zum Zugriff darauf, zum Entfernen und zum Zusammenführen von Zellen mit **Aspose.Slides for C++**.

## **Tabelle hinzufügen**

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

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

## **Zugriff auf eine Tabelle**

Rufen Sie die erste Tabellengrafik auf der Folie ab.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Zugriff auf die erste Tabelle auf der Folie.
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

## **Tabelle entfernen**

Löschen Sie eine Tabelle von einer Folie.

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

## **Tabellenzellen zusammenführen**

Führen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Zellen zusammenführen.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```