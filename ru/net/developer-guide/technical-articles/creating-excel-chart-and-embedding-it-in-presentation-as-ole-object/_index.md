---
title: Создание графика Excel и встраивание его в презентацию как объект OLE
type: docs
weight: 50
url: /ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

В слайдах PowerPoint использование редактируемых графиков для графического отображения данных является обычным делом. Aspose предоставляет возможность создания графиков Excel с использованием Aspose.Cells для .NET, и впоследствии эти графики могут быть встроены как объект OLE в слайд PowerPoint через Aspose.Slides для .NET. Эта статья охватывает необходимые шаги, а также реализацию на C# и VB.NET для создания и встраивания графика MS Excel как объекта OLE в презентацию PowerPoint с использованием Aspose.Cells для .NET и Aspose.Slides для .NET.

{{% /alert %}} 
## **Необходимые шаги**
Следующая последовательность шагов требуется для создания и встраивания графика Excel как объекта OLE в слайд PowerPoint:

1. Создайте график Excel с использованием Aspose.Cells для .NET.
2. Установите размер OLE графика Excel с использованием Aspose.Cells для .NET.
3. Получите изображение графика Excel с помощью Aspose.Cells для .NET.
4. Встраивайте график Excel как объект OLE внутри презентации PPTX с помощью Aspose.Slides для .NET.
5. Замените изображение измененного объекта изображением, полученным на шаге 3, чтобы устранить проблему изменения объекта.
6. Запишите выходную презентацию на диск в формате PPTX.

## **Реализация необходимых шагов**
Реализация вышеуказанных шагов на C# и Visual Basic выглядит следующим образом:

```c#
//Шаг - 1: Создайте график Excel с использованием Aspose.Cells
//--------------------------------------------------
//Создайте книгу
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Добавьте график Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Шаг - 2: Установите размер OLE графика. с использованием Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Шаг - 3: Получите изображение графика с помощью Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Сохраните книгу в поток
MemoryStream wbStream = wb.SaveToStream();
//Шаг - 4 И 5
//-----------------------------------------------------------
//Шаг - 4: Встраивайте график как объект OLE внутри .ppt презентации с использованием Aspose.Slides
//-----------------------------------------------------------
//Шаг - 5: Замените изображение измененного объекта изображением, полученным на шаге 3, чтобы устранить проблему изменения объекта
//-----------------------------------------------------------
//Создайте презентацию
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Добавьте книгу на слайд
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Шаг - 6: Запишите выходную презентацию на диск
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Массив имен ячеек
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Массив значений ячеек
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Добавьте новый рабочий лист для заполнения ячеек данными
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Заполните DataSheet данными
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Добавьте графический лист
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Добавьте график в ChartSheet с серией данных из DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Установите ChartSheet как активный лист
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;
    int x = 0;
    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);
    
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = null;
    oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, dataInfo);
    oof.SubstitutePictureFormat.Picture.Image = pres.Images.AddImage((System.Drawing.Image)imgChart);
}
```





{{% alert color="primary" %}} 

Презентация, созданная указанным выше методом, будет содержать график Excel как объект OLE, который можно активировать, дважды щелкнув по рамке объекта OLE.

{{% /alert %}} 
## **Заключение**
{{% alert color="primary" %}} 

Используя Aspose.Cells для .NET вместе с Aspose.Slides для .NET, мы можем создавать любые графики Excel, поддерживаемые Aspose.Cells для .NET, и встраивать созданный график как объект OLE в слайд PowerPoint. Размер OLE графика Excel также может быть определен. Конечные пользователи могут дополнительно редактировать график Excel, как и любой другой объект OLE.

{{% /alert %}} 
## **Связанные разделы**
[Рабочее решение для изменения размера графика](/slides/ru/net/working-solution-for-chart-resizing-in-pptx/)[Проблема измененного объекта](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)