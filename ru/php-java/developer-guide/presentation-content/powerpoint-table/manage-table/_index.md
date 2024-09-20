---
title: Управление Таблицей
type: docs
weight: 10
url: /php-java/manage-table/
keywords: "Таблица, создать таблицу, доступ к таблице, соотношение сторон таблицы, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Создание и управление таблицей в презентациях PowerPoint"
---

Таблица в PowerPoint - это эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных по строкам и столбцам) проста и легка для понимания.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), интерфейс [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable), класс [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) и другие типы, которые позволяют вам создавать, обновлять и управлять таблицами в любых презентациях.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд через метод [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/), чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Сохраните измененную презентацию.

Этот код PHP показывает, как создать таблицу в презентации:

```php
  # Создает экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с шириной и строки с высотой
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Добавляет форму таблицы на слайд
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
    # Добавляет текст в объединенную ячейку
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Объединенные ячейки");
    # Сохраняет презентацию на диск
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Нумерация в стандартной таблице**

В стандартной таблице номер ячеек прост и начинается с нуля. Первая ячейка в таблице индексируется как 0,0 (столбец 0, строка 0).

Например, ячейки в таблице с 4 столбцами и 4 строками пронумерованы следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код PHP показывает, как задать нумерацию для ячеек в таблице:

```php
  # Создает экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с шириной и строки с высотой
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

3. Создайте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и установите его в null.

4. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/), пока не найдете таблицу.

   Если вы подозреваете, что слайд, с которым вы имеете дело, содержит единственную таблицу, вы можете просто проверить все фигуры, которые он содержит. Когда фигура определена как таблица, вы можете преобразовать ее в объект [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Но если слайд, с которым вы имеете дело, содержит несколько таблиц, вам лучше искать таблицу, которая вам нужна, по [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Используйте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) для работы с таблицей. В приведенном ниже примере мы добавили новую строку в таблицу.

6. Сохраните измененную презентацию.

Этот код PHP показывает, как получить доступ и работать с существующей таблицей:

```php
  # Создает экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Инициализирует null TableEx
    $tbl = null;
    # Проходит по фигурам и устанавливает ссылку на найденную таблицу
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Устанавливает текст для первого столбца второй строки
        $tbl->get_Item(0, 1)->getTextFrame()->setText("Новый");
      }
    }
    # Сохраняет измененную презентацию на диск
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
5. Получите [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Выравните текст по вертикали.
7. Сохраните измененную презентацию.

Этот код PHP показывает, как выровнять текст в таблице:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с шириной и строки с высотой
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Добавляет форму таблицы на слайд
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Получает текстовый фрейм
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Создает объект Paragraph для текстового фрейма
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Создает объект Portion для параграфа
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Текст здесь");
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
7. Сохраните измененную презентацию.

Этот код PHP показывает, как применить ваши предпочтительные параметры форматирования к тексту в таблице:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Предположим, что первая фигура на первом слайде - это таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает высоту шрифта ячеек таблицы
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Устанавливает выравнивание текста ячеек таблицы и правый отступ за один вызов
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Устанавливает вертикальный тип текста ячеек таблицы
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

Aspose.Slides позволяет получить свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код PHP показывает, как получить свойства стиля из предустановленного стиля таблицы:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// изменяет предустановленный стиль по умолчанию

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры - это соотношение ее размеров в разных измерениях. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , чтобы вы могли заблокировать настройку соотношения сторон для таблиц и других фигуры.

Этот код PHP показывает, как заблокировать соотношение сторон для таблицы:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Установлено блокирование соотношения сторон: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// инвертировать

    echo("Установлено блокирование соотношения сторон: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```