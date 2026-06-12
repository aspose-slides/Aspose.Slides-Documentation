---
title: Tabella
type: docs
weight: 120
url: /it/cpp/examples/elements/table/
keywords:
- esempio di codice
- tabella
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavorare con le tabelle in Aspose.Slides per C++: creare, formattare, unire le celle, applicare stili, importare dati e esportare con esempi C++ per PPT, PPTX e ODP."
---
Esempi per aggiungere tabelle, accedervi, rimuoverle e unire le celle usando **Aspose.Slides for C++**.

## **Aggiungi una Tabella**

Crea una tabella semplice con due righe e due colonne.

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

## **Accedi a una Tabella**

Recupera la prima forma tabella nella diapositiva.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Accedi alla prima tabella nella diapositiva.
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

## **Rimuovi una Tabella**

Elimina una tabella da una diapositiva.

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

## **Unisci le Celle della Tabella**

Unisci le celle adiacenti di una tabella in un'unica cella.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Unisci le celle.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```