---
title: "Форматирование диаграмм презентаций на Java"
linktitle: "Форматирование диаграмм"
type: docs
weight: 60
url: /ru/java/chart-formatting/
keywords:
- "формат диаграммы"
- "форматирование диаграмм"
- "элемент диаграммы"
- "свойства диаграммы"
- "настройки диаграммы"
- "параметры диаграммы"
- "свойства шрифта"
- "закруглённые границы"
- "PowerPoint"
- "презентация"
- "Java"
- "Aspose.Slides"
description: "Изучите форматирование диаграмм в Aspose.Slides для Java и улучшите свою презентацию PowerPoint с помощью настраиваемых осей, шрифтов, числовых форматов и закруглённых границ диаграмм."
---
## **Обзор**

В этой статье объясняется, как форматировать диаграммы в презентациях PowerPoint с использованием Aspose.Slides. Показано, как настраивать основные элементы диаграммы, такие как оси, линии сетки, заголовки, легенды, область построения и заливки стен, чтобы улучшить внешний вид и читаемость данных диаграммы.

Также демонстрируется, как задать свойства шрифта для текста диаграммы, применить предустановленные числовые форматы к данным диаграммы и включить закруглённые углы области диаграммы. Вместе эти примеры показывают, как управлять как визуальным стилем, так и представлением данных диаграмм в презентации.

Для отдельных заливок и контуру на растущих и падающих интервалах, см. [пример диаграммы акций](/slides/ru/java/create-chart/#create-stock-charts).

## **Форматирование элементов диаграммы**

Используйте [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) для форматирования заголовков диаграмм, осей, линий сетки, легенд и области построения. Этот пример создает линейную диаграмму с маркерами и данными по умолчанию, затем применяет отдельные стили текста и линий к её оси значений и оси категорий. Размеры шрифтов и толщины линий указаны в пунктах; подписи категорий повернуты на 45 градусов.

Ось значений использует [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) независимо от исходных ячеек. Её шкала охватывает диапазон от -2 до 15 с основными интервалами 2 и второстепенными интервалами 0,5. Пример также комбинирует процентное форматирование с [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) установленным в тысячи, поэтому адаптируйте эти настройки к смыслу и масштабу ваших данных. Легенда остаётся вне области построения, поскольку [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) вызывается с `false`. Заливки задней стенки и пола настраиваются через [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) и [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), но эти поверхности видимы только в 3‑D диаграммах.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка свойств шрифта для диаграммы**

Установите размер шрифта по умолчанию для текста диаграммы через [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Пример создает сгруппированную столбчатую диаграмму с шрифтом 20 пунктов и включает подписи значений для первой серии через [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Текстовые элементы с собственными явными настройками шрифта могут переопределять значение по умолчанию диаграммы.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Повторное использование форматирования текстового фрейма для легенды диаграммы**

Чтобы согласовать легенду с заголовком слайда, задайте шрифт заголовка через [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) в первом абзаце. Вызовите [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) у формата, возвращаемого [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) легенды. Это копирует настройки текстового кадра, форматирование первого абзаца и свойства шрифта по умолчанию этого абзаца. Форматирование, применённое напрямую к отдельным частям или к последующим абзацам, остаётся локальным для источника.

В примере используется полужирный заголовок Calibri 26 пунктов темно-синего цвета в качестве шаблона. После стилизации легенды вызывается [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) , чтобы применить то же форматирование к отдельной подписи.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В сохранённой презентации легенда и подпись соответствуют заголовку по размеру, насыщенности и цвету. Легенда по‑прежнему отображает имена рядов, а подпись сохраняет свой собственный текст. Если часть подписи уже имеет явно заданный размер шрифта, этот размер имеет приоритет над скопированным значением по умолчанию абзаца.

| До копирования | После копирования |
| --- | --- |
| ![Квартальная диаграмма продаж с обычными чёрными метками легенды и чёрной подписью](legend-formatting-before.png) | ![Та же диаграмма с более крупными, полужирными темно‑синими метками легенды и соответствующей подписью](legend-formatting.png) |

## **Установка числового формата**

Используйте [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) для применения встроенного числового формата к ячейкам рабочей книги диаграммы. Этот пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, привязанными к ячейкам, и применяет индекс формата 10 (`0.00%`) к ячейкам значений каждого ряда. Это изменяет отображение значений в рабочей книге без изменения самих чисел; например, 0,25 отображается как 25,00 %. Форматы оси и подписей данных могут быть настроены отдельно.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В следующей таблице перечислены встроенные индексы числовых форматов с типичными форматами Excel для локали English (United States). Точные строковые представления форматов и их отображение могут различаться в зависимости от приложения и локали, особенно для валют и дат. Некоторые форматы Excel также отличаются от значений по умолчанию в стандарте OOXML, как описано в [заметках Microsoft о реализации числовых форматов](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Индекс | Формат |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Установка закруглённых границ области диаграммы**

Вызовите [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) с `true`, чтобы закруглить углы области диаграммы. Пример создаёт сгруппированную столбчатую диаграмму и использует [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) , чтобы задать её контуру сплошной серый цвет и стиль одной линии перед сохранением презентации.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Редактирование существующих аннотаций диаграммы**

Диаграмма может содержать пользовательские формы, такие как текстовая аннотация, объясняющая статус отчёта. Доступ к этим формам осуществляется через [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), также упомянутый в [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) в справочнике API диаграмм. Коллекция, возвращаемая [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) , содержит формы, принадлежащие диаграмме.

Обычный текстовый блок, размещённый поверх диаграммы, принадлежит слайду, даже если выглядит как часть диаграммы. Перебор через [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) находит диаграмму и обычные формы слайда, но не перечисляет отдельные формы внутри диаграммы. Заголовки диаграмм и подписи данных являются отдельными элементами диаграммы, а не пользовательскими аннотациями в этой коллекции.

Скачайте [chart-annotations.pptx](chart-annotations.pptx) и разместите его в рабочем каталоге приложения. Его первый слайд содержит диаграмму с не сгруппированной аннотацией «Preliminary results», линией, принадлежащей диаграмме, и обычным текстовым блоком слайда «Slide overlay». Пример находит первую диаграмму на этом слайде и меняет аннотацию на «Final results», когда отчёт готов к публикации. Он проверяет, что коллекция не пуста, и редактирует только [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) с ненулевым текстовым фреймом, возвращаемым [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) , содержащим ожидаемый текст.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Линия и текстовый блок слайда остаются без изменений. На следующих изображениях показан исходный и сохранённый, повторно открытый результат:

| До редактирования | После редактирования |
| --- | --- |
| ![Аннотация диаграммы с надписью Preliminary results](chart-annotations-before.png) | ![Аннотация диаграммы с надписью Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
В примере проверяются только формы верхнего уровня, принадлежащие диаграмме. Если аннотация находится внутри [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), проверьте также коллекцию [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) этой группы. Повторяйте рекурсивно для вложенных групп, применяя те же проверки текста к их дочерним формам. Сама группа является контейнером; не рассматривайте её как текстовый блок.
{{% /alert %}}

## **FAQ**

**Могу ли я установить полупрозрачные заливки для столбцов/областей, сохранив границу непрозрачной?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как справиться с метками данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите несущественные компоненты меток (например, категории), отрегулируйте положение метки, при необходимости показывайте метки только для выбранных точек или переключите формат на «значение + легенда».

**Могу ли я применять градиентные или шаблонные заливки к рядам?**

Да. Ряды поддерживают сплошные, градиентные и шаблонные заливки. На практике используйте градиенты умеренно и избегайте сочетаний, снижающих контраст с сеткой и текстом.