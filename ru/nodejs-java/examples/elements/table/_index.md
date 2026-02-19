---
title: Таблица
type: docs
weight: 120
url: /ru/nodejs-java/examples/elements/table/
keywords:
- пример кода
- таблица
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Работайте с таблицами в Aspose.Slides for Node.js: создавайте, форматируйте, объединяйте ячейки, применяйте стили, импортируйте данные и экспортируйте с примерами для PPT, PPTX и ODP."
---
Примеры добавления таблиц, доступа к ним, удаления их и объединения ячеек с использованием **Aspose.Slides for Node.js via Java**.

## **Добавить таблицу**

Создайте простую таблицу с двумя строками и двумя столбцами.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к таблице**

Получите первую форму таблицы со слайда.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Получить первую таблицу на слайде.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
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

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагаем, что первая фигура является таблицей.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Объединить ячейки таблицы**

Объедините соседние ячейки таблицы в одну ячейку.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагаем, что первая фигура является таблицей.
        let table = slide.getShapes().get_Item(0);

        // Объединить ячейки.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```