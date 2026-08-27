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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java. Откройте простые примеры кода для оптимизации работы с таблицами."
---
## **Введение**

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в виде сетки ячеек (расположенных в строках и столбцах) проста и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table) класс [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/) а также другие типы, позволяющие создавать, обновлять и управлять таблицами во всех типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addtable/).
6. Пройдите по каждой [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/) чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) ячейки [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/).
9. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
10. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как создать таблицу в презентации:

```php
  # Создаёт объект класса Presentation, представляющего файл PPTX
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

## **Нумерация в обычной таблице**

В обычной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка таблицы имеет индекс 0,0 (столбец 0, строка 0).

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот PHP‑код показывает, как указать нумерацию ячеек в таблице:

```php
  # Создаёт объект класса Presentation, представляющий файл PPTX
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
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Создайте объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table) и присвойте ему null.
4. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) пока не найдёте таблицу.

Если вы подозреваете, что рассматриваемый слайд содержит одну единственную таблицу, можно просто проверить все содержащиеся в нём фигуры. Когда фигура определяется как таблица, её можно привести к типу [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table). Но если слайд содержит несколько таблиц, лучше искать нужную таблицу по её методу [setAlternativeText(String value)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/setalternativetext/).

5. Используйте объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table) для работы с таблицей. В примере ниже мы добавили новую строку в таблицу.
6. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как получить доступ к существующей таблице и работать с ней:

```php
  # Создаёт объект класса Presentation, представляющего файл PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Инициализирует TableEx как null
    $tbl = null;
    # Перебирает фигуры и устанавливает ссылку на найденную таблицу
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Устанавливает текст для первого столбца второй строки
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
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

## **Найти ячейку, владеющую TextFrame**

Когда общий код обработки текста получает [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) для получения принадлежащей [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/). Для TextFrame ячейки таблицы [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) возвращает владельца, а [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape) возвращает `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/#getFirstColumnIndex) и [Cell::getFirstRowIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) также предоставляет навигацию только для чтения: он возвращает владельца, но не меняет владения. Всегда проверяйте возвращённую ячейку с помощью `java_is_null` перед её использованием.

Для полного примера, определяющего владельцев ячеек таблиц и фигур, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/php-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) из таблицы.
5. Получите объект [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/).
6. Выровняйте текст по вертикали.
7. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как выровнять текст в таблице:

```php
  # Создаёт экземпляр класса Presentation
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
    # Получает доступ к текстовому фрейму
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Создаёт объект Paragraph для текстового фрейма
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Создаёт объект Portion для абзаца
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Выравнивает текст вертикально
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Table) со слайда.
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setFontHeight) для текста.
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setalignment/) и [setMarginRight(float value)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как применить предпочтительные параметры форматирования к тексту в таблице:

```php
  # Создаёт экземпляр класса Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Предположим, что первая фигура на первом слайде является таблицей
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает высоту шрифта ячеек таблицы
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
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

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать эти данные для другой таблицы или в другом месте. Этот PHP‑код показывает, как получить свойства стиля из предустановленного стиля таблицы:

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

Соотношение сторон геометрической фигуры — это отношение её размеров в разных измерениях. Aspose.Slides предоставил метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) для блокировки настройки соотношения сторон таблиц и других фигур.

Этот PHP‑код показывает, как заблокировать соотношение сторон для таблицы:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// инвертировать

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**  
Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/setrighttoleft/) , а абзацы имеют [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setrighttoleft/). Использование обоих гарантирует корректный порядок RTL и рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размеров таблицы пользователями в окончательном файле?**  
Используйте блокировки фигур, чтобы отключить перемещение, изменение размеров, выделение и т.д. Эти блокировки применяются и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**  
Да. Вы можете установить [picture fill](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) для ячейки; изображение покроет область ячейки в выбранном режиме (растягивание или плитка).