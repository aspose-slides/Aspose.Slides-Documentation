---
title: Таблица
type: docs
weight: 120
url: /ru/cpp/examples/elements/table/
keywords:
- пример кода
- таблица
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Работа с таблицами в Aspose.Slides for C++: создание, форматирование, объединение ячеек, применение стилей, импорт данных и экспорт с примерами C++ для PPT, PPTX и ODP."
---
Примеры добавления таблиц, доступа к ним, удаления их и объединения ячеек с использованием **Aspose.Slides for C++**.

## **Добавить таблицу**

Создайте простую таблицу с двумя строками и двумя столбцами.

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

## **Доступ к таблице**

Получите первую форму таблицы на слайде.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Получить первую таблицу на слайде.
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

## **Удалить таблицу**

Удалите таблицу со слайда.

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

## **Объединить ячейки таблицы**

Объедините соседние ячейки таблицы в одну ячейку.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Объединить ячейки.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```