---
title: Управление ячейками таблицы в презентациях с использованием PHP
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/php-java/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удалить границу
- разделить ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Легко управляйте ячейками таблицы в PowerPoint с помощью Aspose.Slides для PHP. Овладейте быстрым доступом, изменением и стилизацией ячеек для бесшовной автоматизации слайдов."
---

## **Определить объединенную ячейку таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите таблицу с первого слайда.
3. Итерируйте строки и столбцы таблицы, чтобы найти объединённые ячейки.
4. Выведите сообщение, когда найдёте объединённые ячейки.

Этот PHP код показывает, как определить объединённые ячейки таблицы в презентации:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// предполагая, что Slide#0.Shape#0 является таблицей

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удалить границы ячеек таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable).
6. Итерируйте каждую ячейку, чтобы очистить верхнюю, нижнюю, правую и левую границы.
7. Сохраните изменённую презентацию в файле PPTX.

Этот PHP код показывает, как удалить границы из ячеек таблицы:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Добавляет форму таблицы на слайд
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Устанавливает формат границы для каждой ячейки
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Сохраняет PPTX на диск
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Нумерация в объединённых ячейках**
Если мы объединим 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), получившаяся таблица будет пронумерована. Этот PHP код демонстрирует процесс:
```php
  # Создаёт экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Добавляет форму таблицы на слайд
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Устанавливает формат границы для каждой ячейки
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Объединяет ячейки (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Объединяет ячейки (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Затем мы продолжаем объединять ячейки, объединяя (1, 1) и (1, 2). Результатом является таблица, содержащая большую объединённую ячейку в центре:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Добавляет форму таблицы на слайд
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Устанавливает формат границы для каждой ячейки
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Объединяет ячейки (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Объединяет ячейки (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Объединяет ячейки (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Записывает PPTX файл на диск
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Нумерация в разделённой ячейке**
В предыдущих примерах, когда ячейки таблицы объединялись, нумерация или система нумерации в остальных ячейках не менялась.  

В этот раз мы берём обычную таблицу (таблицу без объединённых ячеек) и пытаемся разделить ячейку (1,1), получая особую таблицу. Возможно, вам стоит обратить внимание на нумерацию этой таблицы, которая может показаться странной. Однако именно так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides делает то же самое.  

Этот PHP код демонстрирует описанный процесс:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Добавляет форму таблицы на слайд
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Устанавливает формат границы для каждой ячейки
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Объединяет ячейки (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Объединяет ячейки (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Разделяет ячейку (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Записывает файл PPTX на диск
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить цвет фона ячейки таблицы**
Этот PHP код показывает, как изменить цвет фона ячейки таблицы:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # создать новую таблицу
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # установить цвет фона для ячейки
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Добавить изображение внутрь ячейки таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable).
6. Создайте объект `Images` для хранения файла изображения.
7. Добавьте изображение `IImage` в объект `IPPImage`.
8. Установите `FillFormat` для ячейки таблицы в значение `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните изменённую презентацию в файле PPTX

Этот PHP код показывает, как разместить изображение внутри ячейки таблицы при её создании:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $islide = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Добавляет форму таблицы на слайд
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Создает объект IPPImage, используя файл изображения
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет изображение в первую ячейку таблицы
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Сохраняет файл PPTX на диск
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Можно ли задать разную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [верхняя](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[нижняя](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[левая](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[правая](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут отличаться. Это логически вытекает из управления границами по сторонам для ячейки, продемонстрированного в статье.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [режима заливки](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при замощении плитки пересчитываются. В статье упоминаются режимы отображения изображения в ячейке.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Гиперссылки](/slides/ru/php-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/объекта. На практике вы назначаете ссылку части или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [части](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) с независимым форматированием — семейство шрифта, стиль, размер и цвет.