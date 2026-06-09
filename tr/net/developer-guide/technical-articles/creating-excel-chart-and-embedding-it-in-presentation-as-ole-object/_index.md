---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Yerleştirin
type: docs
weight: 50
url: /tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafiği yerleştir
- OLE nesnesi
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Excel grafiklerini oluşturun ve C#/.NET ile PowerPoint ve OpenDocument sunumlarına OLE nesneleri olarak yerleştirin. Adım adım kılavuz ve kod örnekleri."
---
## **Arka Plan**

PowerPoint’te, düzenlenebilir grafikler kullanarak verileri görsel olarak göstermek yaygın bir uygulamadır. Aspose, Aspose.Cells for .NET ile Excel grafikleri oluşturmayı destekler ve bu grafikler daha sonra Aspose.Slides for .NET aracılığıyla PowerPoint slaytlarına OLE nesneleri olarak yerleştirilebilir. Bu makale gerekli adımları kapsar ve Aspose.Cells ve Aspose.Slides kullanarak bir Excel grafiği oluşturup bunu PowerPoint sunumuna OLE nesnesi olarak yerleştirmek için C# kod örnekleri sağlar.

## **Gerekli Adımlar**

Aşağıdaki adım sırası, bir Excel grafiğini OLE nesnesi olarak bir PowerPoint slaydına oluşturmak ve yerleştirmek için gereklidir:

1. Aspose.Cells kullanarak bir Excel grafiği oluşturun.
1. Aspose.Cells kullanarak Excel grafiğinin OLE boyutunu ayarlayın.
1. Aspose.Cells ile Excel grafiğinin bir görüntüsünü alın.
1. Aspose.Slides kullanarak Excel grafiğini bir PPTX sunumunda OLE nesnesi olarak yerleştirin.
1. Adım 3'te elde edilen görüntüyle "EMBEDDED OLE OBJECT" görüntüsünü değiştirerek [nesne önizleme sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/) sorununu giderin.
1. Sunumu PPTX formatında diske kaydedin.

## **Gerekli Adımların Uygulanması**

Yukarıdaki adımların C# uygulaması aşağıdaki gibidir:

```cs
// Adım - 1: Aspose.Cells kullanarak bir Excel grafiği oluşturun.
// ---------------------------------------------------
// Bir çalışma kitabı oluşturun.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Bir Excel grafiği ekleyin.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Adım - 2: Aspose.Cells kullanarak grafiğin OLE boyutunu ayarlayın.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Adım - 3: Aspose.Cells ile grafiğin görüntüsünü alın.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Çalışma kitabını bir akışa kaydedin.
MemoryStream workbookStream = workbook.SaveToStream();

// Adım - 4 VE 5
// ==============
 // Adım - 4: Grafiği Aspose.Slides kullanarak bir .ppt sunumuna OLE nesnesi olarak yerleştirin.
// ------------------------------------------------------------------------------------------
 // Adım - 5: "EMBEDDED OLE OBJECT" görüntüsünü adım 3'te elde edilen görüntü ile değiştirerek Nesne Önizleme Sorununu giderin.
// --------------------------------------------------------------------------------------------------------------------
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Çalışma kitabını slayta ekleyin.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Adım - 6: Çıktı sunumunu diske kaydedin.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Hücre adlarının bir dizisi.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Hücre verilerinin bir dizisi.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Hücreleri veriyle doldurmak için yeni bir çalışma sayfası ekleyin.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Veri sayfasını veriyle doldurun.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Bir grafik sayfası ekleyin.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Veri sayfasından veri serileriyle grafik sayfasına bir grafik ekleyin.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Grafik sayfasını etkin sayfa olarak ayarlayın.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

Yukarıdaki yöntemle oluşturulan sunum, OLE nesne çerçevesine çift tıklanarak etkinleştirilebilen bir OLE nesnesi olarak Excel grafiğini içerir.

## **Sonuç**

Aspose.Cells for .NET ile Aspose.Slides for .NET’i birleştirerek Aspose.Cells tarafından desteklenen herhangi bir Excel grafiği oluşturabilir ve grafiği bir PowerPoint slaydına OLE nesnesi olarak yerleştirebiliriz. Excel grafiğinin OLE boyutu da tanımlanabilir. Son kullanıcılar, Excel grafiğini diğer OLE nesneleri gibi düzenleyebilir.

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)