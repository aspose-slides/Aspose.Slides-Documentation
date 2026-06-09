---
title: Tabela
type: docs
weight: 120
url: /pt/cpp/examples/elements/table/
keywords:
- exemplo de código
- tabela
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com tabelas em Aspose.Slides for C++: crie, formate, mescle células, aplique estilos, importe dados e exporte com exemplos C++ para PPT, PPTX e ODP."
---
Exemplos de como adicionar tabelas, acessá-las, removê-las e mesclar células usando **Aspose.Slides for C++**.

## **Adicionar uma Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

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

## **Acessar uma Tabela**

Recupere a primeira forma de tabela no slide.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Acesse a primeira tabela no slide.
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

## **Remover uma Tabela**

Remova uma tabela de um slide.

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

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Mesclar células.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```