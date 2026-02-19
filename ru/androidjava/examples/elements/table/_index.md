---
title: Таблица
type: docs
weight: 120
url: /ru/androidjava/examples/elements/table/
keywords:
- пример кода
- таблица
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Работайте с таблицами в Aspose.Slides for Android: создавайте, форматируйте, объединяйте ячейки, применяйте стили, импортируйте данные и экспортируйте с примерами на Java для PPT, PPTX и ODP."
---
Примеры добавления таблиц, доступа к ним, удаления и объединения ячеек с помощью **Aspose.Slides for Android via Java**.

## **Добавить таблицу**

Создайте простую таблицу с двумя строками и двумя столбцами.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к таблице**

Получите первую форму таблицы на слайде.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Доступ к первой таблице на слайде.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить таблицу**

Удалите таблицу со слайда.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Объединить ячейки таблицы**

Объедините смежные ячейки таблицы в одну ячейку.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Объединить ячейки.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```