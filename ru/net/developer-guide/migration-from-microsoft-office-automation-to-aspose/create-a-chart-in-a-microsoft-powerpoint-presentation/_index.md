---
title: Создание диаграмм с использованием VSTO и Aspose.Slides для .NET
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
description: "Узнайте, как автоматизировать создание диаграмм PowerPoint на C#. Это пошаговое руководство показывает, почему Aspose.Slides для .NET является более быстрым и мощным альтернативным решением по сравнению с Microsoft.Office.Interop."
---

## **Обзор**

В этой статье демонстрируется, как программно создавать и настраивать диаграммы в презентациях Microsoft PowerPoint с использованием C#. С помощью Aspose.Slides для .NET вы можете автоматизировать генерацию профессиональных диаграмм, основанных на данных, без необходимости использовать Microsoft Office или библиотеки Interop. API предоставляет богатый набор возможностей для построения столбчатых, круговых, линейных диаграмм и многого другого — с полным контролем над внешним видом, данными и макетом. Независимо от того, создаёте ли вы отчёты, информационные панели или деловые презентации, Aspose.Slides помогает создавать высококачественные визуализации непосредственно из ваших .NET‑приложений.

## **Пример VSTO**

В этом разделе показано, как создать диаграмму в презентации Microsoft PowerPoint с помощью **VSTO (Visual Studio Tools for Office)**. С помощью VSTO вы можете программно генерировать и настраивать диаграммы, комбинируя автоматизацию PowerPoint и Excel. Приведённый пример показывает, как добавить **3D сгруппированную столбчатую диаграмму**, заполнить её данными из листа Excel, настроить форматирование и макет, а затем сохранить готовую презентацию — всё из .NET‑приложения.

1. Создайте экземпляр презентации Microsoft PowerPoint.  
2. Добавьте пустой слайд в презентацию.  
3. Добавьте 3D сгруппированную столбчатую диаграмму и получите к ней доступ.  
4. Создайте новый экземпляр книги Microsoft Excel и загрузите в неё данные диаграммы.  
5. Получите доступ к листу данных диаграммы с помощью экземпляра книги Excel.  
6. Установите диапазон диаграммы в листе и удалите серии 2 и 3 из диаграммы.  
7. Измените данные категорий диаграммы в листе данных диаграммы.  
8. Измените данные серии 1 в листе данных диаграммы.  
9. Получите доступ к заголовку диаграммы и задайте свойства шрифта.  
10. Получите доступ к оси значений диаграммы и задайте основной шаг, дополнительный шаг, максимальное и минимальное значение.  
11. Получите доступ к оси глубины (серии) диаграммы и удалите её — в этом примере используется только одна серия.  
12. Установите углы вращения диаграммы по осям X и Y.  
13. Сохраните презентацию.  
14. Закройте экземпляры Microsoft Excel и PowerPoint.  
```c#
EnsurePowerPointIsRunning(true, true);

// Создайте объект слайда.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Получите доступ к первому слайду презентации.
objSlide = objPres.Slides[1];

// Выберите первый слайд и задайте его макет.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Добавьте диаграмму по умолчанию на слайд.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Получите доступ к добавленной диаграмме.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Получите доступ к данным диаграммы.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Создайте экземпляр книги Excel для работы с данными диаграммы.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Получите доступ к листу данных диаграммы.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Установите диапазон данных для диаграммы.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Примените указанный диапазон к таблице данных диаграммы.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Установите значения для категорий и соответствующих данных серий.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Установите заголовок диаграммы.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Получите доступ к оси значений диаграммы.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Установите значения для единиц оси.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Получите доступ к оси глубины диаграммы.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Установите поворот диаграммы.
ppChart.Rotation = 20;   // Значение Y
ppChart.Elevation = 15;  // Значение X
ppChart.RightAngleAxes = false;

// Сохраните презентацию в файле PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Закройте книгу и презентацию.
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

    // Попробуйте получить свойство Name. Если возникает исключение, запустите новый экземпляр PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation используется, чтобы убедиться, что презентация загружена.
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

    // blnAddSlide используется, чтобы убедиться, что в презентации есть хотя бы один слайд.
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

## **Пример Aspose.Slides для .NET**

Ниже приведён пример, показывающий, как создать простую диаграмму в презентации PowerPoint с помощью Aspose.Slides для .NET. Этот код демонстрирует, как добавить **3D сгруппированную столбчатую диаграмму**, заполнить её примерными данными и настроить её внешний вид. Всего несколькими строками кода вы можете динамически создавать диаграммы и интегрировать их в свои презентации без использования Microsoft Office.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Получите ссылку на первый слайд.  
3. Добавьте 3D сгруппированную столбчатую диаграмму и получите к ней доступ.  
4. Получите доступ к данным диаграммы.  
5. Удалите неиспользуемые Series 2 и Series 3.  
6. Измените категории диаграммы, обновив подписи.  
7. Обновите значения Series 1.  
8. Получите доступ к заголовку диаграммы и задайте свойства шрифта.  
9. Настройте ось значений диаграммы, включая основной шаг, дополнительный шаг, максимальное и минимальное значения.  
10. Установите углы вращения диаграммы по осям X и Y.  
11. Сохраните презентацию в формате PPTX.  
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

    // Изменить имена категорий диаграммы.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Установить индекс листа данных диаграммы.
    int worksheetIndex = 0;

    // Получить книгу данных диаграммы.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Изменить значения серий диаграммы.
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

    // Настроить параметры осей.
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

![Диаграмма, созданная с помощью Aspose.Slides для .NET](chart-created-using-aspose-slides.png)

## **ЧаВо**

**Могу ли я создавать другие типы диаграмм, например круговые, линейные или столбчатые, с помощью Aspose.Slides?**

Да. Aspose.Slides для .NET поддерживает широкий спектр [типов диаграмм](https://docs.aspose.com/slides/net/create-chart/), включая круговые, линейные, столбчатые, точечные, пузырьковые и многое другое. Вы можете указать нужный тип диаграммы, используя перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) при добавлении диаграммы.

**Можно ли применить пользовательские стили или темы к диаграмме?**

Да. Вы можете полностью настроить внешний вид диаграммы, включая цвета, шрифты, заливки, контуры, линии сетки и макет. Однако точное применение тем Office, как в PowerPoint, требует ручной настройки отдельных стилей.

**Можно ли экспортировать диаграмму как отдельное изображение, а не со слайдом?**

Да, Aspose.Slides позволяет экспортировать любую форму — включая диаграммы — в отдельное изображение (например, PNG, JPEG) с помощью метода `GetImage` у объекта [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).