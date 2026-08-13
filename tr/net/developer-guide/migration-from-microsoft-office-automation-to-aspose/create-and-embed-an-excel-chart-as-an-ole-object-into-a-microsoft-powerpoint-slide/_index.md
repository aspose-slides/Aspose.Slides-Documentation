---
title: VSTO ve Aspose.Slides for .NET Kullanarak Excel Grafiklerini OLE Nesneleri Olarak Oluşturma ve Gömme
linktitle: Excel Grafiklerini OLE Nesneleri Olarak Oluşturma ve Gömme
type: docs
weight: 70
url: /tr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- grafik oluştur
- Excel grafiği göm
- OLE nesnesi
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçiş yapın ve Excel grafiklerini C# ile PowerPoint (PPT, PPTX) slaytlarına OLE nesneleri olarak gömün."
---
{{% alert color="info" %}} 
Grafikler, verilerinizin görsel temsilleridir ve sunum slaytlarında yaygın olarak kullanılır. Bu makale, [VSTO](/slides/tr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) ve [Aspose.Slides for .NET](/slides/tr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) kullanarak bir Excel Grafikini OLE Nesnesi olarak PowerPoint Slaytına programlı bir şekilde oluşturma ve gömme kodunu gösterecek.
{{% /alert %}} 
## **Excel Grafiği Oluşturma ve Gömme**
Aşağıdaki iki kod örneği uzun ve ayrıntılıdır çünkü anlatılan görev karmaşıktır. Bir Microsoft Excel çalışma kitabı oluşturur, bir grafik oluşturur ve ardından grafiği gömeceğiniz Microsoft PowerPoint sunumunu oluşturursunuz. OLE nesneleri, orijinal belgeye bağlantılar içerir, bu nedenle gömülü dosyaya çift tıklayan bir kullanıcı dosyayı ve uygulamasını başlatır.
## **VSTO Örneği**
1. Microsoft Excel ApplicationClass nesnesinin bir örneğini oluşturun.
1. Bir sayfa içeren yeni bir çalışma kitabı oluşturun.
1. Sayfaya bir grafik ekleyin.
1. Çalışma kitabını kaydedin.
1. Grafik verilerini içeren çalışma sayfasını içeren Excel çalışma kitabını açın.
1. Sayfa için ChartObjects koleksiyonunu alın.
1. Kopyalanacak grafiği alın.
1. Microsoft PowerPoint sunumu oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Grafiği Excel çalışma sayfasından panoya kopyalayın.
1. Grafiği PowerPoint sunumuna yapıştırın.
1. Grafiği slayt üzerinde konumlandırın.
1. Sunumu kaydedin.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Excel ApplicationClass örneği için bir değişken bildir.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Workbooks.Open yöntemi parametreleri için değişkenler bildir.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Chart.ChartWizard yöntemi için değişkenler bildir.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Excel ApplicationClass nesnesinin bir örneğini oluştur.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // 1 sayfa içeren yeni bir çalışma kitabı oluştur.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Sayfanın adını değiştir.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Grafik için bazı verileri sayfaya ekle.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. America  1.5     2       1.5     2.5
        //     3    S. America  2       1.75    2       2
        //     4    Europe      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Grafik verilerini tutan aralığı al.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Sayfa için ChartObjects koleksiyonunu al.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Koleksiyona bir Grafik ekle.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Verilerin yeni bir grafiğini oluştur.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Çalışma kitabını kaydet.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Excel'i kapat.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // PowerPoint nesnelerine referans tutacak değişkenleri bildir.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Excel nesnelerine referans tutacak değişkenleri bildir.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // PowerPoint'in bir örneğini oluştur.
        powerpointApplication = new pptNS.ApplicationClass();

        // Excel'in bir örneğini oluştur.
        excelApplication = new xlNS.ApplicationClass();

        // Grafik verilerini içeren çalışma sayfasını içeren Excel çalışma kitabını aç.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Grafiği içeren çalışma sayfasını al.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Sayfa için ChartObjects koleksiyonunu al.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Kopyalanacak grafiği al.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // PowerPoint sunumu oluştur.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Sunuma boş bir slayt ekle.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Grafiği Excel çalışma sayfasından panoya kopyala.
        existingChartObject.Copy();

        // Grafiği PowerPoint sunumuna yapıştır.
        shapeRange = pptSlide.Shapes.Paste();

        // Grafiği slayt üzerinde konumlandır.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Sunumu kaydet.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // PowerPoint slayt nesnesini serbest bırak.
        shapeRange = null;
        pptSlide = null;

        // Presentation nesnesini kapat ve serbest bırak.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // PowerPoint'i kapat ve ApplicationClass nesnesini serbest bırak.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Excel nesnelerini serbest bırak.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Excel Workbook nesnesini kapat ve serbest bırak.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Excel'i kapat ve ApplicationClass nesnesini serbest bırak.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```

## **Aspose.Slides for .NET Örneği**
1. Aspose.Cells for .NET kullanarak bir çalışma kitabı oluşturun.
1. Microsoft Excel grafiği oluşturun.
1. Excel Grafiğinin OLE boyutunu ayarlayın.
1. Grafiğin bir görüntüsünü alın.
1. Aspose.Slides for .NET kullanarak Excel grafiğini PPTX sunumuna OLE Nesnesi olarak gömün.
1. Nesne değişikliği sorununu gidermek için 3. adımda elde edilen görüntü ile nesne değişikliği görüntüsünü değiştirin.
1. Çıktı sunumunu PPTX formatında diske yazın.

```c#
using System.Drawing;
using Aspose.Slides;

//Step - 1: Aspose.Cells kullanarak bir Excel grafiği oluştur
//--------------------------------------------------
//Create a workbook
//Bir çalışma kitabı oluştur
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
//Bir Excel grafiği ekle
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Grafiğin OLE boyutunu Aspose.Cells ile ayarla
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Grafiğin görüntüsünü Aspose.Cells ile al
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Save the workbook to stream
//Çalışma kitabını akıma kaydet
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: Grafiği Aspose.Slides kullanarak .ppt sunumuna OLE nesnesi olarak göm
//-----------------------------------------------------------
//Step - 5: Nesne değişikliği sorununu çözmek için adım 3'te elde edilen görüntüyü nesne değişikliği görüntüsüyle değiştir
//-----------------------------------------------------------
//Create a presentation
//Bir sunum oluştur
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Add the workbook on slide
//Çalışma kitabını slayta ekle
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: Çıktı sunumunu diske yaz
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Hücre isimlerinin dizisi
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Hücre verilerinin dizisi
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Verileri hücrelere doldurmak için yeni bir çalışma sayfası ekle
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //DataSheet'i veriyle doldur
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Bir grafik sayfası ekle
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //DataSheet'ten veri serileriyle ChartSheet'e bir grafik ekle
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ChartSheet'i aktif sayfa olarak ayarla
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```