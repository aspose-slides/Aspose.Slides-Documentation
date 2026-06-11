---
title: Tabela
type: docs
weight: 120
url: /pl/net/examples/elements/table/
keywords:
- tabela
- dodaj tabelę
- uzyskaj dostęp do tabeli
- usuń tabelę
- scal komórki
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Praca z tabelami w Aspose.Slides for .NET: tworzenie, formatowanie, scalanie komórek, stosowanie stylów, import danych i eksport z przykładami C# dla PPT, PPTX i ODP."
---
Przykłady dodawania tabel, uzyskiwania do nich dostępu, usuwania ich oraz scalania komórek przy użyciu **Aspose.Slides for .NET**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwiema kolumnami.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Uzyskaj dostęp do tabeli**

Pobierz pierwszy kształt tabeli na slajdzie.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Uzyskaj dostęp do pierwszej tabeli na slajdzie.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Usuń tabelę**

Usuń tabelę ze slajdu.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Scal komórki tabeli**

Scal sąsiadujące komórki tabeli w jedną komórkę.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```