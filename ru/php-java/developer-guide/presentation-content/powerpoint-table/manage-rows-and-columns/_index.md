---
title: Управление строками и столбцами
type: docs
weight: 20
url: /php-java/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Управление строками и столбцами таблицы в презентациях PowerPoint"
---

Чтобы управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и многие другие типы.

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и установите его в null.
4. Пройдите через все объекты [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) для поиска соответствующей таблицы.
5. Установите первую строку таблицы в качестве ее заголовка.

Этот PHP код показывает, как установить первую строку таблицы в качестве ее заголовка:

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Инициализация null TableEx
    $tbl = null;
    # Итерация по формам и установка ссылки на таблицу
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Устанавливает первую строку таблицы в качестве заголовка
        $tbl->setFirstRow(true);
      }
    }
    # Сохранение презентации на диск
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Клонирование строки или столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Клонируйте строку таблицы.
7. Клонируйте столбец таблицы.
8. Сохраните измененную презентацию.

Этот PHP код показывает, как клонировать строку или столбец таблицы PowerPoint:

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Определение столбцов с ширинами и строк с высотами
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Добавление таблицы на слайд
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Добавляем текст в ячейку строки 1 ячейка 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Ячейка 1 Строки 1");
    # Добавляем текст в ячейку строки 1 ячейка 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Ячейка 2 Строки 1");
    # Клонируем строку 1 в конце таблицы
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Добавляем текст в ячейку строки 2 ячейка 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Ячейка 1 Строки 2");
    # Добавляем текст в ячейку строки 2 ячейка 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Ячейка 2 Строки 2");
    # Клонируем строку 2 как 4-ю строку таблицы
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Клонируем первый столбец в конец
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Клонируем 2-й столбец по индексу 4-го столбца
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Сохранение презентации на диск
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Удалите строку таблицы.
7. Удалите столбец таблицы.
8. Сохраните измененную презентацию. 

Этот PHP код показывает, как удалить строку или столбец из таблицы:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить текстовое форматирование на уровне строки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) из слайда.
4. Установите высоту шрифта для ячеек первой строки с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Установите выравнивание текста и правый отступ для ячеек первой строки с помощью [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Установите вертикальный тип текста для ячеек второй строки с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните измененную презентацию.

Этот PHP код демонстрирует операцию.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation();
  try {
    # Предположим, что первым объектом на первом слайде является таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Установите высоту шрифта ячеек первой строки
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Установите выравнивание текста и правый отступ для ячеек первой строки
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Установите вертикальный тип текста для ячеек второй строки
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Сохранение презентации на диск
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить текстовое форматирование на уровне столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) из слайда.
4. Установите высоту шрифта для ячеек первого столбца с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Установите выравнивание текста и правый отступ для ячеек первого столбца в одном вызове с помощью [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Установите вертикальный тип текста для ячеек второго столбца с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните измененную презентацию. 

Этот PHP код демонстрирует операцию:

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation();
  try {
    # Предположим, что первым объектом на первом слайде является таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Установите высоту шрифта ячеек первого столбца
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Установите выравнивание текста и правый отступ для ячеек первого столбца в одном вызове
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Установите вертикальный тип текста для ячеек второго столбца
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет вам извлекать свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот PHP код показывает, как получить свойства стиля из предустановленного стиля таблицы:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// изменить предустановленный стиль по умолчанию

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```