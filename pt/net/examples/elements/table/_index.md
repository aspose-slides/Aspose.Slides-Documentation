---
title: Tabela
type: docs
weight: 120
url: /pt/net/examples/elements/table/
keywords:
- tabela
- adicionar tabela
- acessar tabela
- remover tabela
- mesclar células
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com tabelas no Aspose.Slides for .NET: crie, formate, mescle células, aplique estilos, importe dados e exporte com exemplos em C# para PPT, PPTX e ODP."
---
Exemplos de como adicionar tabelas, acessá‑las, removê‑las e mesclar células usando **Aspose.Slides for .NET**.

## **Adicionar uma Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

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

## **Acessar uma Tabela**

Recupere a primeira forma de tabela no slide.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Acesse a primeira tabela no slide.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Remover uma Tabela**

Exclua uma tabela de um slide.

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

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

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