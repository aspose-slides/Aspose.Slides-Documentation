---
title: Управление таблицами презентаций в PHP
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/php-java/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java. Откройте простые примеры кода, упрощающие работу с таблицами."
---

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), интерфейс [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable), класс [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в самых разных презентациях.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Задайте массив `columnWidth`.  
4. Задайте массив `rowHeight`.  
5. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).  
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) чтобы применить форматирование к верхней, нижней, правой и левой границам.  
7. Объедините две первые ячейки первой строки таблицы.  
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ячейки [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).  
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).  
10. Сохраните изменённую презентацию.

Этот PHP‑код демонстрирует, как создать таблицу в презентации:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Добавляет объект таблицы на слайд
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Устанавливает формат границы для каждой ячейки
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Объединяет ячейки 1 и 2 первой строки
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Добавляет текст в объединённую ячейку
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Сохраняет презентацию на диск
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка таблицы имеет индекс 0,0 (столбец 0, строка 0).

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот PHP‑код показывает, как задать нумерацию ячеек в таблице:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Добавляет объект таблицы на слайд
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
    # Сохраняет презентацию на диск
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  

2. Получите ссылку на слайд, содержащий таблицу, по его индексу.  

3. Создайте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и присвойте ему `null`.  

4. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) пока не найдёте таблицу.  

   Если вы подозреваете, что на слайде только одна таблица, можно просто проверить все его фигуры. Когда фигура определена как таблица, её можно привести к объекту [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Если же на слайде несколько таблиц, лучше искать нужную таблицу через её [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).  

5. Используйте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) для работы с таблицей. В примере ниже мы добавили новую строку в таблицу.  

6. Сохраните изменённую презентацию.

Этот PHP‑код демонстрирует, как получить доступ к существующей таблице и работать с ней:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Инициализирует null TableEx
    $tbl = null;
    # Проходит по фигурам и сохраняет ссылку на найденную таблицу
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Устанавливает текст для первой колонки второй строки
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Сохраняет изменённую презентацию на диск
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд.  
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) из таблицы.  
5. Получите [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) из [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).  
6. Выравнивайте текст по вертикали.  
7. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как выровнять текст в таблице:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Добавляет объект таблицы на слайд
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Получает текстовый кадр
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Создает объект Paragraph для TextFrame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Создает объект Portion для Paragraph
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Выравнивает текст по вертикали
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Сохраняет презентацию на диск
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Получите объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) со слайда.  
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) для текста.  
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как применить выбранные параметры форматирования к тексту в таблице:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Предположим, что первая фигура на первом слайде — это таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Задает высоту шрифта ячеек таблицы
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Задает выравнивание текста ячеек таблицы и правый отступ одним вызовом
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Задает вертикальный тип текста ячеек таблицы
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать их для другой таблицы или в другом месте. Этот PHP‑код демонстрирует, как получить свойства стиля из предустановленного стиля таблицы:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// изменить тему предустановленного стиля по умолчанию

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-), позволяющее зафиксировать соотношение сторон для таблиц и других фигур.

Этот PHP‑код показывает, как заблокировать соотношение сторон таблицы:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Использование обоих обеспечивает правильный порядок RTL и корректный рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размеров таблицы в конечном файле?**

Используйте [блокировки фигур](/slides/ru/php-java/applying-protection-to-presentation/) для отключения перемещения, изменения размеров, выделения и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [заполнение изображением](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или повтор).