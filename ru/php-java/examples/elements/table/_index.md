---
title: Таблица
type: docs
weight: 120
url: /ru/php-java/examples/elements/table/
keywords:
- таблица
- добавить таблицу
- доступ к таблице
- удалить таблицу
- объединить ячейки
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и форматируйте таблицы в PHP с помощью Aspose.Slides: вставляйте данные, объединяйте ячейки, оформляйте границы, выравнивайте содержимое и импортируйте/экспортируйте файлы PPT, PPTX и ODP."
---
Примеры добавления таблиц, их доступа, удаления и объединения ячеек с использованием **Aspose.Slides for PHP via Java**.

## **Add a Table**
Создайте простую таблицу с двумя строками и двумя столбцами.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Table**
Получите первую форму таблицы на слайде.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить первую таблицу на слайде.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Table**
Удалите таблицу со слайда.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что таблица является первой фигурой на слайде.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Merge Table Cells**
Объедините соседние ячейки таблицы в одну ячейку.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что таблица является первой фигурой на слайде.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```