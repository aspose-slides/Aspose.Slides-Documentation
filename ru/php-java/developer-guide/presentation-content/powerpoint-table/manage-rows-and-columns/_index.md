---
title: Управление строками и столбцами в таблицах PowerPoint с использованием PHP
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/php-java/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- копировать строку
- копировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides для PHP через Java, ускоряя редактирование презентаций и обновление данных."
---

Чтобы управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и многие другие типы.

## **Установить первую строку как заголовок**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию.  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) и присвойте ему null.  
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) в поиске нужной таблицы.  
5. Установите первую строку таблицы как её заголовок.  

Этот PHP‑код показывает, как установить первую строку таблицы как её заголовок:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Инициализирует null TableEx
    $tbl = null;
    # Итерирует формы и задаёт ссылку на таблицу
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Устанавливает первую строку таблицы как её заголовок
        $tbl->setFirstRow(true);
      }
    }
    # Сохраняет презентацию на диск
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Определите массив `columnWidth`.  
4. Определите массив `rowHeight`.  
5. Добавьте объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Клонируйте строку таблицы.  
7. Клонируйте столбец таблицы.  
8. Сохраните изменённую презентацию.  

Этот PHP‑код показывает, как клонировать строку или столбец таблицы PowerPoint:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Определяет столбцы с ширинами и строки с высотами
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Добавляет форму таблицы на слайд
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Добавляет текст в ячейку 1 строки 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Добавляет текст в ячейку 2 строки 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Клонирует строку 1 в конец таблицы
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Добавляет текст в ячейку 1 строки 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Добавляет текст в ячейку 2 строки 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Клонирует строку 2 как 4‑ю строку таблицы
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Клонирует первый столбец в конец
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Клонирует второй столбец на позицию 4‑го столбца
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Сохраняет презентацию на диск
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
8. Сохраните изменённую презентацию.  

Этот PHP‑код показывает, как удалить строку или столбец из таблицы:
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


## **Установить форматирование текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Получите нужный объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) со слайда.  
4. Установите высоту шрифта для ячеек первой строки с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Установите выравнивание и отступ справа для ячеек первой строки с помощью [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Установите вертикальный тип текста для ячеек второй строки с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.  

Этот PHP‑код демонстрирует операцию.
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Предположим, что первая фигура на первом слайде — таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает высоту шрифта ячеек первой строки
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Устанавливает выравнивание текста и правый отступ ячеек первой строки
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Устанавливает вертикальный тип текста ячеек второй строки
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Сохраняет презентацию на диск
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Установить форматирование текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Получите нужный объект [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) со слайда.  
4. Установите высоту шрифта для ячеек первого столбца с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Установите выравнивание и отступ справа для ячеек первого столбца с помощью [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Установите вертикальный тип текста для ячеек второго столбца с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.  

Этот PHP‑код демонстрирует операцию:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Предположим, что первая фигура на первом слайде — таблица
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Устанавливает высоту шрифта ячеек первого столбца
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Устанавливает выравнивание текста и правый отступ ячеек первого столбца одним вызовом
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Устанавливает вертикальный тип текста ячеек второго столбца
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

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать их для другой таблицы или в другом месте. Этот PHP‑код показывает, как получить свойства стиля из предустановленного стиля таблицы:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// изменить предустановленную тему стиля по умолчанию

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/мастера, и при необходимости вы можете переопределить заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в нужном порядке.

**Можно ли иметь чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередующиеся столбцы, а затем переопределите конкретные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет перед стилем таблицы.