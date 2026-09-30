---
title: Управление таблицами презентаций на Android
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для Android. Откройте простые примеры Java-кода, упрощающие работу с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию в строки и столбцы, облегчая чтение и сравнение значений.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , класс [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) , и другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создание таблицы с нуля**

Создайте таблицу, указав её позицию, ширины столбцов и высоты строк. После добавления её на слайд вы можете задавать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Определите массив ширин столбцов в пунктах.
4. Определите массив высот строк в пунктах.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её метод [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Задайте текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя столбцами и пятью строками в точке (100, 50) пунктов. Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки в первой строке и сохраняет результат как `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт таблицу 4 × 4, показанную выше, со шириной столбцов и высотой строк по 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты показывают индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Таблицы хранятся в коллекции фигур слайда. Пройдитесь по фигурам, чтобы найти таблицу, затем используйте интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) для чтения или обновления её ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройдитесь по объектам [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) , останавливаясь, когда найдёте таблицу. Если на слайде несколько таблиц, используйте [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) для идентификации нужной.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он задаёт ячейке в столбце 0, строке 1 значение `New` и сохраняет результат как `table1_out.pptx`. Входной файл должен содержать как минимум один слайд, а первая таблица на этом слайде должна иметь как минимум один столбец и две строки.

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

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Управление высотой строки](/slides/ru/androidjava/manage-rows-and-columns/#control-row-height).

## **Найти ячейку, владеющую текстовым фреймом**

Когда универсальный код обработки текста получает [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) из таблицы, используйте метод [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) для получения владеющей [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) . Для текстового фрейма ячейки таблицы [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) возвращает владельца, а [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) возвращает `null`, несмотря на то, что сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) и [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) . Метод [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) также предоставляет только для чтения навигацию: он возвращает владельца, но не меняет владельца. Всегда проверяйте возвращённую ячейку на `null` перед использованием.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Поиск и замена текста](/slides/ru/androidjava/search-and-replace-text/).

## **Выравнивание текста в таблице**

Вы можете управлять вертикальной привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и поворачивает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) из таблицы.
5. Получите первую [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) и задайте её текст и цвет.
6. Задайте вертикальную привязку ячейки и направление текста с помощью [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) и [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 со шириной столбцов 120 пунктов и высотой строк 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в оставшиеся ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Установить форматирование текста на уровне таблицы**

Используйте [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) для применения форматирования текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому вы можете задавать эти свойства без перебора отдельных ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) со слайда.
4. Задайте размер шрифта с помощью [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Задайте выравнивание абзаца и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Задайте направление текста с помощью [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
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

## **Получить свойства стиля таблицы**

Используйте [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) для чтения предустановленного стиля таблицы и [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) для его назначения. Этот пример применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) к одной таблице, выводит значение предустановки и назначает тот же предустановленный стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

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

## **Блокировать соотношение сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) для блокировки этого соотношения у таблицы.

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

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , а абзацы имеют [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Использование обоих гарантирует правильный RTL‑порядок и отображение внутри ячеек.

**Как можно предотвратить перемещение или изменение размеров таблицы в конечном файле?**

Используйте [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) , чтобы отключить перемещение, изменение размера, выделение и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или заливка плиткой).