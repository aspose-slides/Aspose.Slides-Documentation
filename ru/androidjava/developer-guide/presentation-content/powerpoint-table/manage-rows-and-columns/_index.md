---
title: Управление строками и столбцами в таблицах PowerPoint на Android
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides for Android via Java и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for Android via Java позволяет управлять структурой таблицы и её форматированием в презентациях PowerPoint с помощью класса [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) и интерфейса [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Вы можете обозначить строку заголовка, клонировать или удалять строки и столбцы, а также применять форматирование текста к целой строке или столбцу.

Эта статья объясняет эти операции с примерами на Java. Она также демонстрирует, как получить предустановку стиля таблицы, чтобы её можно было повторно использовать. Индексы строк и столбцов в таблице начинаются с нуля.

## **Управление высотой строки**

Используйте [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) для задания минимальной высоты строки в пунктах. Это нижняя граница, а не фиксированная высота. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) возвращает фактическую высоту. Получить строку можно через [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

В примере загружается файл [row-height-input.pptx](row-height-input.pptx), в котором первая фигура на первом слайде – таблица. Первая её строка начинается с 70 пунктов. Ячейки используют 18‑пунктовый шрифт Arial, перенос текста и отступы 6 пунктов сверху и снизу; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит фактическую высоту после каждого изменения и сохраняет оба результата.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При работе с предоставленной презентацией увеличение минимума добавляет пространство к строке. Уменьшение избавляет от этого дополнительного пространства, но фактическая высота остаётся больше 20 пунктов, потому что текст и отступы ячеек требуют больше места. Снижение только минимального значения не может заставить строку стать меньше требуемого её содержимым пространства.

Несколько факторов влияют на фактическую высоту:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или больший шрифт могут требовать больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе уменьшение ширины столбца с помощью [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) может добавить строк. Широкий столбец может уменьшить требуемое вертикальное пространство.
- **Отступы ячеек:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) и [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) добавляют вертикальное пространство. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) и [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) уменьшают ширину, доступную для текста, и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшее вертикальное пространство, определяет нижний предел, задаваемый содержимым, для всей строки. Чтобы сделать строку короче, возможно, придётся сократить текст, уменьшить размер шрифта или отступы, либо расширить столбец.

Ниже представлены изображения той же таблицы в одинаковом масштабе. На иллюстрированных результатах фактическая высота составляла 70, 100 и 55,2 пункта: последняя строка осталась выше своего минимума в 20 пунктов. Точные измерения текста могут различаться в зависимости от шрифтов, доступных в вашей среде. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Оригинал: минимум 70 пт, фактический 70 пт | Увеличено: минимум 100 пт, фактический 100 пт | Уменьшено: минимум 20 пт, фактический 55.2 пт |
| --- | --- | --- |
| ![Исходная таблица с первой строкой высотой 70 пунктов.](row-height-before.png) | ![Таблица после увеличения минимального значения первой строки до 100 пунктов.](row-height-increased.png) | ![Таблица после уменьшения минимального значения первой строки до 20 пунктов; перенос текста сохраняет строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку как заголовок**

Используйте метод [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) для пометки первой строки как заголовка. Её внешний вид зависит от стиля таблицы, применённого к таблице.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Получите доступ к таблице, хранящейся как первая фигура на слайде.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

В примере требуется файл `table.pptx` с таблицей в качестве первой фигуры на первом слайде. Пример включает форматирование заголовка для первой строки и сохраняет файл `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Клонировать строку или столбец таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

В примере требуется файл `Test.pptx` с как минимум одним слайдом. Пример создаёт таблицу из трёх столбцов и пяти строк с размерами, заданными в пунктах. Затем он добавляет копии первой строки и первого столбца, после чего вставляет копии второй строки и второго столбца в позицию с индексом 3 (четвёртая позиция). В результате таблица содержит семь строк и пять столбцов. Параметр `false` отключает клонирование в смежные объединённые строки или столбцы; в этой таблице объединённых ячеек нет.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Удалить строку или столбец из таблицы**

Удаляйте строки или столбцы, которые больше не нужны в таблице. Удаление элемента смещает индексы последующих строк или столбцов.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 3 × 3 и удаляет строку и столбец с индексом 1, оставляя таблицу 2 × 2 в файле `TestTable_out.pptx`. Размеры указаны в пунктах. Параметр `false` отключает удаление смежных объединённых строк или столбцов; в этой таблице объединённых ячеек нет.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Применить форматирование текста на уровне строк таблицы**

Применяйте форматирование текста к целой строке, чтобы её ячейки выглядели согласованно. Вы можете задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к таблице на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для первой строки.
4. Используйте [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) для первой строки.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) для второй строки.
6. Сохраните изменённую презентацию.

В примере требуется файл `table.pptx` с таблицей в качестве первой фигуры на первом слайде и как минимум двумя строками. Пример применяет 25‑пунктовый текст, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первой строке, а затем задаёт вертикальное направление текста во второй строке.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Применить форматирование текста на уровне столбцов таблицы**

Применяйте форматирование текста к целому столбцу, чтобы его ячейки выглядели согласованно. Вы можете задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
22. Получите доступ к таблице на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для первого столбца.
4. Используйте [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) для первого столбца.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) для второго столбца.
6. Сохраните изменённую презентацию.

В примере требуется файл `table.pptx` с таблицей в качестве первой фигуры на первом слайде и как минимум двумя столбцами. Пример применяет 25‑пунктовый текст, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первому столбцу, а затем задаёт вертикальное направление текста во втором столбце.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить свойства стиля таблицы**

Используйте метод [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) для получения предустановки, применённой к таблице, и её повторного использования в другой таблице. Это позволяет идентифицировать предустановку, а не отдельные переопределения форматирования ячеек.

В примере создаётся таблица, применяется [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1), после чего предустановка считывается обратно. Пример выводит целочисленное значение, соответствующее `DarkStyle1`, и сохраняет таблицу в файле `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Могу ли я применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/основного шаблона, и вы всё‑равно можете переопределять заливки, рамки и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в нужном порядке.

**Можно ли использовать полосатые (заштрихованные) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите полосатые столбцы, затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.