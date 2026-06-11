---
title: Tabela
type: docs
weight: 120
url: /pl/cpp/examples/elements/table/
keywords:
- przykład kodu
- tabela
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj z tabelami w Aspose.Slides for C++: twórz, formatuj, łącz komórki, stosuj style, importuj dane i eksportuj przy użyciu przykładów C++ dla PPT, PPTX i ODP."
---
Przykłady dodawania tabel, uzyskiwania do nich dostępu, usuwania ich oraz scalania komórek przy użyciu **Aspose.Slides for C++**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwiema kolumnami.

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

## **Uzyskaj dostęp do tabeli**

Pobierz pierwszy kształt tabeli na slajdzie.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Uzyskaj dostęp do pierwszej tabeli na slajdzie.
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

## **Usuń tabelę**

Usuń tabelę ze slajdu.

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

## **Scal komórki tabeli**

Scal przyległe komórki tabeli w jedną komórkę.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Scal komórki.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```