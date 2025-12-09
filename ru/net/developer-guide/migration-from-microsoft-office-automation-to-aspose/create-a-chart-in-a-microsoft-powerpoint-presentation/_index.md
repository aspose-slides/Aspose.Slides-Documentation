---
title: Создание диаграмм с помощью VSTO и Aspose.Slides для .NET
linktitle: Создать диаграмму
type: docs
weight: 80
url: /ru/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- создать диаграмму
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как автоматизировать создание диаграмм PowerPoint в C#. Это пошаговое руководство показывает, почему Aspose.Slides для .NET является более быстрым и мощным альтернативой Microsoft.Office.Interop."
---

## **Обзор**

Эта статья демонстрирует, как программно создавать и настраивать диаграммы в презентациях Microsoft PowerPoint с помощью C#. С Aspose.Slides for .NET вы можете автоматизировать генерацию профессиональных диаграмм, основанных на данных, без необходимости использовать Microsoft Office или библиотеки Interop. API предоставляет обширный набор возможностей для построения столбчатых, круговых, линейных диаграмм и многих других — с полным контролем над внешним видом, данными и макетом. Независимо от того, создаёте ли вы отчёты, приборные панели или бизнес‑презентации, Aspose.Slides помогает вам получать высококачественные визуализации напрямую из ваших .NET‑приложений.

## **Пример VSTO**

В этом разделе показано, как создать диаграмму в презентации Microsoft PowerPoint с использованием **VSTO (Visual Studio Tools for Office)**. С помощью VSTO можно программно генерировать и настраивать диаграммы, комбинируя автоматизацию PowerPoint и Excel. Пример демонстрирует добавление **3D сгруппированной столбчатой диаграммы**, заполнение её данными из листа Excel, настройку формата и макета, а также сохранение готовой презентации — всё из .NET‑приложения.

1. Создать экземпляр презентации Microsoft PowerPoint.  
2. Добавить пустой слайд в презентацию.  
3. Добавить 3D сгруппированную столбчатую диаграмму и получить к ней доступ.  
4. Создать новый экземпляр книги Microsoft Excel и загрузить в него данные для диаграммы.  
5. Получить доступ к листу данных диаграммы, используя экземпляр книги Excel.  
6. Установить диапазон диаграммы в листе и удалить серии 2 и 3 из диаграммы.  
7. Изменить данные категорий диаграммы в листе данных.  
8. Изменить данные серии 1 в листе данных.  
9. Получить доступ к заголовку диаграммы и задать свойства шрифта.  
10. Получить доступ к оси значений диаграммы и задать основной и вспомогательный единицы, максимальное и минимальное значения.  
11. Получить доступ к оси глубины (серий) диаграммы и удалить её — в этом примере используется только одна серия.  
12. Задать углы поворота диаграммы по осям X и Y.  
13. Сохранить презентацию.  
14. Закрыть экземпляры Microsoft Excel и PowerPoint.  

```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // Значение Y
ppChart.Elevation = 15;  // Значение X
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Попробуйте получить свойство Name. Если будет выброшено исключение, запустите новый экземпляр PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation используется, чтобы гарантировать, что презентация загружена.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide используется, чтобы гарантировать, что в презентации есть хотя бы один слайд.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```


Результат:

![Диаграмма, созданная с помощью VSTO](chart-created-using-VSTO.png)

## **Пример Aspose.Slides for .NET**

Следующий пример показывает, как создать простую диаграмму в презентации PowerPoint с использованием Aspose.Slides for .NET. Этот код демонстрирует добавление **3D сгруппированной столбчатой диаграммы**, заполнение её примерными данными и настройку внешнего вида. Всего несколько строк кода позволяют динамически генерировать диаграммы и интегрировать их в презентации без использования Microsoft Office.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Получить ссылку на первый слайд.  
3. Добавить 3D сгруппированную столбчатую диаграмму и получить к ней доступ.  
4. Получить доступ к данным диаграммы.  
5. Удалить неиспользуемые Series 2 и Series 3.  
6. Изменить категории диаграммы, обновив подписи.  
7. Обновить значения Series 1.  
8. Получить доступ к заголовку диаграммы и задать свойства шрифта.  
9. Настроить ось значений диаграммы, задав основной и вспомогательный единицы, максимальное и минимальное значения.  
10. Задать углы поворота диаграммы по осям X и Y.  
11. Сохранить презентацию в формате PPTX.  

```cs
    // Создать пустую презентацию.
    using (Presentation presentation = new Presentation())
    {
        // Получить первый слайд.
        ISlide slide = presentation.Slides[0];

        // Добавить диаграмму по умолчанию.
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

        // Получить данные диаграммы.
        IChartData chartData = chart.ChartData;

        // Удалить лишние серии по умолчанию.
        chartData.Series.RemoveAt(1);
        chartData.Series.RemoveAt(1);

        // Изменить названия категорий диаграммы.
        chartData.Categories[0].AsCell.Value = "Bikes";
        chartData.Categories[1].AsCell.Value = "Accessories";
        chartData.Categories[2].AsCell.Value = "Repairs";
        chartData.Categories[3].AsCell.Value = "Clothing";

        // Установить индекс листа данных диаграммы.
        int worksheetIndex = 0;

        // Получить рабочую книгу данных диаграммы.
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Изменить значения рядов диаграммы.
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

        // Установить заголовок диаграммы.
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
        IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
        format.FontItalic = NullableBool.True;
        format.FontHeight = 18;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.Black;

        // Установить параметры осей.
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
        chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

        chart.Axes.VerticalAxis.MaxValue = 4000.0F;
        chart.Axes.VerticalAxis.MinValue = 0.0F;
        chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
        chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
        chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

        // Установить вращение диаграммы.
        chart.Rotation3D.RotationX = 15;
        chart.Rotation3D.RotationY = 20;

        // Сохранить презентацию в файл PPTX.
        presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
    }
```


Результат:

![Диаграмма, созданная с помощью Aspose.Slides for .NET](chart-created-using-aspose-slides.png)

## **Часто задаваемые вопросы**

**Могу ли я создавать другие типы диаграмм, такие как круговые, линейные или гистограммы, с помощью Aspose.Slides?**

Да. Aspose.Slides for .NET поддерживает широкий набор [типы диаграмм](https://docs.aspose.com/slides/net/create-chart/), включая круговые, линейные, столбчатые, точечные, пузырьковые диаграммы и многое другое. Требуемый тип диаграммы указывается через перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) при добавлении диаграммы.

**Можно ли применить пользовательские стили или темы к диаграмме?**

Да. Вы можете полностью настраивать внешний вид диаграммы, включая цвета, шрифты, заливки, контуры, сетку и макет. Однако точное применение тем Office, как в PowerPoint, требует ручной настройки отдельных стилей.

**Можно ли экспортировать диаграмму как отдельное изображение, отделённое от слайда?**

Да, Aspose.Slides позволяет экспортировать любой объект — в том числе диаграммы — в виде отдельного изображения (например PNG, JPEG) с помощью метода `GetImage` у соответствующего [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).