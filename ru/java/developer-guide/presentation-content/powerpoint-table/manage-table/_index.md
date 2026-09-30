---
title: Управление таблицами презентаций в Java
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/java/manage-table/
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
- Java
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для Java. Откройте простые примеры кода для оптимизации вашей работы с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию в строки и столбцы, облегчая чтение и сравнение значений.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , класс [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) , а также другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создание таблицы с нуля**

Создайте таблицу, указав её позицию, ширину столбцов и высоту строк. После добавления её на слайд вы можете форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Определите массив ширин столбцов в пунктах.
4. Определите массив высот строк в пунктах.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Пройдите по каждому [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её метод [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) .
9. Установите текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя столбцами и пятью строками в точке (100, 50) пунктов. Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки первой строки и сохраняет результат как `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Нумерация в стандартной таблице**

В стандартной таблице индексы ячеек начинаются с нуля и используют порядок (столбец, строка). Первая ячейка имеет индекс (0, 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт таблицу 4 × 4, показанную выше, с шириной столбцов и высотой строк по 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты иллюстрируют индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Пройдите по фигурам, чтобы найти таблицу, а затем используйте интерфейс [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , чтобы читать или обновлять её ячейки.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройдите по объектам [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) , останавливаясь, когда найдёте таблицу. Если на слайде несколько таблиц, используйте [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) , чтобы определить нужную.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он устанавливает значение `New` в ячейку столбца 0, строки 1 и сохраняет результат как `table1_out.pptx`. Входной файл должен содержать как минимум один слайд, и первая таблица на этом слайде должна иметь как минимум один столбец и две строки.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Чтобы изменить высоту строки в существующей таблице и понять, почему её фактическая высота может превышать запрошенный минимум, см. [Control Row Height](/slides/ru/java/manage-rows-and-columns/#control-row-height).

## **Найти ячейку, владеющую текстовым фреймом**

Когда обобщённый код обработки текста получает [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) из таблицы, используйте метод [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) , чтобы получить владеющую [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) . Для текстового фрейма ячейки таблицы [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) возвращает владельца, а [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) возвращает `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через доступные только для чтения методы [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) и [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) также предоставляет навигацию только для чтения: он возвращает владельца, но не изменяет владения. Всегда проверяйте возвращённую ячейку на `null` перед её использованием.

Для полного примера, определяющего владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/java/search-and-replace-text/) .

## **Выравнивание текста в таблице**

Вы можете управлять вертикальным привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) из таблицы.
5. Получите первый [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) и задайте его текст и цвет.
6. Установите вертикальное привязывание ячейки и направление текста с помощью [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) и [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 с шириной столбцов 120 пунктов и высотой строк 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в остальные ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка форматирования текста на уровне таблицы**

Используйте [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) , чтобы применить форматирование текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому можно задать эти свойства без обхода отдельных ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) слайда.
4. Установите размер шрифта с помощью [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Задайте выравнивание абзаца и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Установите направление текста с помощью [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Сохраните изменённую презентацию.

Пример ниже открывает `table.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Отформатированная презентация сохраняется как `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получение свойств стиля таблицы**

Используйте [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) , чтобы прочитать предустановленный стиль таблицы, и [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) , чтобы задать его. Этот пример применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) к одной таблице, выводит значение предустановки и назначает тот же предустановленный стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) , чтобы зафиксировать это соотношение для таблицы.

Пример ниже открывает `pres.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включает блокировку соотношения сторон, выводит обновлённое состояние (`true`) и сохраняет результат как `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) , а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Использование обоих гарантирует правильный порядок RTL и отображение внутри ячеек.

**Как я могу предотвратить перемещение или изменение размеров таблицы в конечном файле?**

Используйте [shape locks](/slides/ru/java/applying-protection-to-presentation/) , чтобы отключить перемещение, изменение размеров, выделение и т.д. Эти блокировки также применимы к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в соответствии с выбранным режимом (растягивание или замощение).