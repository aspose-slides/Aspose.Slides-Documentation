---
title: Создать график в презентации Microsoft PowerPoint
type: docs
weight: 80
url: /ru/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Графики — это визуальные представления данных, которые широко используются в презентациях. В этой статье представлен код для создания графика в Microsoft PowerPoint программным образом, используя [VSTO](/slides/ru/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) и [Aspose.Slides для .NET](/slides/ru/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Создание графика**
Примеры кода ниже описывают процесс добавления простого 3D кластерного столбикового графика с использованием VSTO. Вы создаете экземпляр презентации, добавляете к ней график по умолчанию. Затем используйте рабочую книгу Microsoft Excel для доступа к данным графика и их изменения, а также для настройки свойств графика. В конце сохраните презентацию.
## **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте **3D кластерный столбиковый** график и получите к нему доступ.
1. Создайте новый экземпляр рабочей книги Microsoft Excel и загрузите данные графика.
1. Получите доступ к рабочему листу данных графика, используя экземпляр рабочей книги Microsoft Excel из рабочей книги.
1. Установите диапазон графика на рабочем листе и удалите ряд 2 и 3 из графика.
1. Измените данные категорий графика на рабочем листе данных графика.
1. Измените данные ряда 1 графика на рабочем листе данных графика.
1. Теперь получите доступ к заголовку графика и установите связанные с ним свойства шрифта.
1. Получите доступ к оси значений графика и установите основные единицы, второстепенные единицы, максимальное значение и минимальные значения.
1. Получите доступ к глубине графика или оси ряда и удалите её, так как в этом примере используется только один ряд.
1. Теперь установите углы вращения графика в направлениях X и Y.
1. Сохраните презентацию.
1. Закройте экземпляры Microsoft Excel и PowerPoint.

**Выходная презентация, созданная с помощью VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

```c#
EnsurePowerPointIsRunning(true, true);

//Создание объекта слайда
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Получение доступа к первому слайду презентации
objSlide = objPres.Slides[1];

//Выбор первого слайда и установка его макета
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Добавление графика по умолчанию на слайд
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Получение доступа к добавленному графику
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Получение доступа к данным графика
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Создание экземпляра рабочей книги Excel для работы с данными графика
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Получение доступа к рабочему листу данных графика
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Установка диапазона графика
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Применение установленного диапазона к таблице данных графика
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Установка значений для категорий и соответствующих данных ряда

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Велосипеды";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Аксессуары";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Ремонт";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Одежда";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Установка заголовка графика
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "Продажи 2007 года";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Получение доступа к оси значений графика
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Установка единиц значений оси
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Получение доступа к оси глубины графика
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Установка вращения графика
ppChart.Rotation = 20; //Y-Значение
ppChart.Elevation = 15; //X-Значение
ppChart.RightAngleAxes = false;

// Сохранение презентации как PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Закрытие Рабочей книги и презентации
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
    //
    //Попробуйте получить доступ к свойству имени. Если это вызывает исключение, то
    //запустите новый экземпляр PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation используется для обеспечения загрузки презентации
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
    //
    //BlnAddSlide используется для обеспечения наличия хотя бы одного слайда в
    //презентации
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

## **Пример Aspose.Slides для .NET**
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте **3D кластерный столбиковый** график и получите к нему доступ.
1. Получите доступ к рабочему листу данных графика, используя экземпляр рабочей книги Microsoft Excel из рабочей книги.
1. Удалите неиспользуемые ряды 2 и 3.
1. Получите доступ к категориям графика и измените метки.
1. Получите доступ к ряду 1 и измените значения ряда.
1. Теперь получите доступ к заголовку графика и установите свойства шрифта.
1. Получите доступ к оси значений графика и установите основные единицы, второстепенные единицы, максимальное значение и минимальные значения.
1. Теперь установите углы вращения графика в направлениях X и Y.
1. Сохраните презентацию в формате PPTX.

**Выходная презентация, созданная с помощью Aspose.Slides**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Создание пустой презентации
using (Presentation pres = new Presentation())
{

    //Получение доступа к первому слайду
    ISlide slide = pres.Slides[0];

    //Добавление графика по умолчанию
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Получение данных графика
    IChartData chartData = ppChart.ChartData;

    //Удаление лишних графиков по умолчанию
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Изменение названий категорий графика
    chartData.Categories[0].AsCell.Value = "Велосипеды";
    chartData.Categories[1].AsCell.Value = "Аксессуары";
    chartData.Categories[2].AsCell.Value = "Ремонт";
    chartData.Categories[3].AsCell.Value = "Одежда";

    //Установка индекса листа данных графика
    int defaultWorksheetIndex = 0;

    //Получение рабочего листа данных графика
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Изменение значений ряда графика для первой категории
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Установка заголовка графика
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("Продажи 2007 года");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    ////Установка значений осей
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Установка вращения графика
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Сохранение презентации
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

## **Ресурсы**
Проекты и файлы, используемые в этой статье, можно скачать с нашего сайта:

- [Скачать сгенерированную презентацию VSTO](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [Скачать пример графика, сгенерированного Aspose.Slides](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}