---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นอ็อบเจ็กต์ OLE
type: docs
weight: 30
url: /th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- อ็อบเจ็กต์ OLE
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Java คู่มือขั้นตอนต่อขั้นตอนพร้อมตัวอย่างโค้ด."
---
## **พื้นหลัง**

ใน PowerPoint การใช้แผนภูมิที่สามารถแก้ไขได้เพื่อแสดงข้อมูลในรูปแบบกราฟิกเป็นการปฏิบัติบ่อย Aspose รองรับการสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Java และแผนภูมิเหล่านี้สามารถฝังเป็นอ็อบเจ็กต์ OLE ลงในสไลด์ PowerPoint ผ่าน Aspose.Slides for Java บทความนี้ครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ด Java สำหรับสร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในการนำเสนอ PowerPoint ด้วย Aspose.Cells และ Aspose.Slides.

## **ขั้นตอนที่จำเป็น**

ขั้นตอนต่อไปนี้จำเป็นต้องทำเพื่อสร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint:

1. สร้างแผนภูมิ Excel ด้วย Aspose.Cells.
1. ตั้งค่าขนาด OLE ของแผนภูมิ Excel ด้วย Aspose.Cells.
1. รับภาพของแผนภูมิ Excel ด้วย Aspose.Cells.
1. ฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PPTX ด้วย Aspose.Slides.
1. แทนที่ภาพ "EMBEDDED OLE OBJECT" ด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/).
1. บันทึกการนำเสนอลงดิสก์ในรูปแบบ PPTX.

## **การดำเนินการตามขั้นตอนที่จำเป็น**

การทำงานของ Java สำหรับขั้นตอนข้างต้นมีดังต่อไปนี้:

```java
// สร้างเวิร์กบุ๊ก.
Workbook workbook = new Workbook();

// เพิ่มแผนภูมิ Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// ตั้งค่าขนาด OLE ของแผนภูมิ.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// ดึงภาพแผนภูมิและบันทึกลงสตรีม.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// บันทึกเวิร์กบุ๊กลงสตรีม.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// สร้างงานนำเสนอ.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มเวิร์กบุ๊กลงสไลด์.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// บันทึกงานนำเสนอลงดิสก์.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // สร้างวัตถุ LoadOptions สำหรับ EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // อาเรย์ของชื่อเซลล์.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // อาเรย์ของข้อมูลเซลล์.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // เพิ่มเวิร์กชีทใหม่เพื่อใส่ข้อมูลลงในเซลล์.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // เติมข้อมูลในแผ่นงานข้อมูล.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // เพิ่มแผ่นงานแผนภูมิ.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // เพิ่มแผนภูมิลงในแผ่นงานแผนภูมิด้วยชุดข้อมูลจากแผ่นงานข้อมูล.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // ตั้งค่าแผ่นงานแผนภูมิเป็นแผ่นงานที่ทำงานอยู่.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

การนำเสนอที่สร้างด้วยวิธีข้างต้นจะมีแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ที่สามารถเปิดใช้งานได้โดยการดับเบิลคลิกที่กรอบอ็อบเจ็กต์ OLE.

## **สรุป**

โดยการใช้ Aspose.Cells for Java ร่วมกับ Aspose.Slides for Java เราสามารถสร้างแผนภูมิ Excel ใด ๆ ที่ Aspose.Cells รองรับและฝังแผนภูมินั้นเป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint ได้ ขนาด OLE ของแผนภูมิ Excel ยังสามารถกำหนดได้ ผู้ใช้ขั้นสุดท้ายสามารถแก้ไขแผนภูมิ Excel เช่นเดียวกับอ็อบเจ็กต์ OLE อื่น ๆ.

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์เมื่อเพิ่ม OleObjectFrame](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/)
- [อัปเดตอ็อบเจ็กต์ OLE อัตโนมัติด้วย PowerPoint Add-In](/slides/th/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)