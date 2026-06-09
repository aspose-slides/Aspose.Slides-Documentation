---
title: Excel Grafiklerini Oluşturun ve Sunumlara OLE Nesneleri Olarak Yerleştirin
type: docs
weight: 30
url: /tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafiği gömme
- OLE nesnesi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java ile Excel grafiklerini oluşturun ve bunları PowerPoint ve OpenDocument sunumlarında OLE nesneleri olarak gömün. Adım adım kod örnekli rehber."
---
## **Arka Plan**

PowerPoint’te, düzenlenebilir grafikler kullanarak verileri görsel olarak göstermek yaygın bir uygulamadır. Aspose, Aspose.Cells for Java ile Excel grafiklerinin oluşturulmasını destekler ve bu grafikler ardından Aspose.Slides for Java aracılığıyla PowerPoint slaytlarına OLE nesnesi olarak yerleştirilebilir. Bu makale, bir Excel grafiği oluşturmak ve Aspose.Cells ile Aspose.Slides kullanarak bunu OLE nesnesi olarak bir PowerPoint sunumuna yerleştirmek için gereken adımları ve Java kod örneklerini sunar.

## **Gerekli Adımlar**

Excel grafiğini OLE nesnesi olarak bir PowerPoint slaytına oluşturmak ve yerleştirmek için aşağıdaki adımlar sırasıyla uygulanmalıdır:

1. Aspose.Cells kullanarak bir Excel grafiği oluşturun.  
1. Aspose.Cells kullanarak Excel grafiğinin OLE boyutunu ayarlayın.  
1. Aspose.Cells ile Excel grafiğinin bir görüntüsünü alın.  
1. Aspose.Slides kullanarak Excel grafiğini PPTX sunumuna OLE nesnesi olarak gömün.  
1. “EMBEDDED OLE OBJECT” görüntüsünü adım 3’te elde edilen görüntü ile değiştirin, böylece [nesne önizleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) giderilir.  
1. Sunumu PPTX formatında diske kaydedin.

## **Gerekli Adımların Uygulanması**

Yukarıdaki adımların Java uygulaması aşağıda verilmiştir:

```java
// Bir çalışma kitabı oluştur.
Workbook workbook = new Workbook();

// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Grafiğin OLE boyutunu ayarla.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Grafik görüntüsünü al ve bir akışa kaydet.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Çalışma kitabını bir akışa kaydet.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Bir sunum oluştur.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Çalışma kitabını bir slayta ekle.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Sunumu diske kaydet.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // EXCEL_97_TO_2003 LoadOptions nesnesi oluştur.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Hücre adlarının dizisi.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Hücre verilerinin dizisi.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Verilerle hücreleri doldurmak için yeni bir çalışma sayfası ekle.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Veri sayfasını verilerle doldur.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Bir grafik sayfası ekle.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Veri sayfasından veri serileriyle grafik sayfasına bir grafik ekle.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Grafik sayfasını aktif sayfa olarak ayarla.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Yukarıdaki yöntemle oluşturulan sunum, OLE nesne çerçevesine çift tıklanarak etkinleştirilebilecek bir OLE nesnesi olarak Excel grafiğini içerecektir.

## **Sonuç**

Aspose.Cells for Java ile Aspose.Slides for Java’ı birleştirerek, Aspose.Cells tarafından desteklenen herhangi bir Excel grafiğini oluşturabilir ve bu grafiği PowerPoint slaytına OLE nesnesi olarak yerleştirebiliriz. Excel grafiğinin OLE boyutu da tanımlanabilir. Son kullanıcılar, Excel grafiğini diğer OLE nesneleri gibi düzenleyebilir.

## **İlgili Bölümler**

- [PPTX'de Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelle](/slides/tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)