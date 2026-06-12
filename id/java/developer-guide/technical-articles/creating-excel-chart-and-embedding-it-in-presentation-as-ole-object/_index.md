---
title: Buat Diagram Excel dan Sematkan ke Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- sematkan diagram
- objek OLE
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Buat diagram Excel dan sematkan sebagai objek OLE dalam presentasi PowerPoint dan OpenDocument menggunakan Java. Panduan langkah demi langkah dengan contoh kode."
---
## **Latar Belakang**

Di PowerPoint, menggunakan diagram yang dapat diedit untuk menampilkan data secara grafis merupakan praktik yang umum. Aspose mendukung pembuatan diagram Excel dengan Aspose.Cells untuk Java, dan diagram ini kemudian dapat disematkan sebagai objek OLE dalam slide PowerPoint melalui Aspose.Slides untuk Java. Artikel ini mencakup langkah‑langkah yang diperlukan dan menyediakan contoh kode Java untuk membuat diagram Excel serta menyematkannya sebagai objek OLE dalam presentasi PowerPoint menggunakan Aspose.Cells dan Aspose.Slides.

## **Langkah yang Diperlukan**

1. Buat diagram Excel menggunakan Aspose.Cells.
1. Atur ukuran OLE diagram Excel menggunakan Aspose.Cells.
1. Dapatkan gambar diagram Excel dengan Aspose.Cells.
1. Sematkan diagram Excel sebagai objek OLE dalam presentasi PPTX menggunakan Aspose.Slides.
1. Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi [masalah tampilan objek](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/).
1. Simpan presentasi ke disk dalam format PPTX.

## **Implementasi Langkah yang Diperlukan**

Implementasi Java dari langkah‑langkah di atas adalah sebagai berikut:

```java
// Buat workbook.
Workbook workbook = new Workbook();

// Tambahkan diagram Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Atur ukuran OLE diagram.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Dapatkan gambar diagram dan simpan ke aliran.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Simpan workbook ke aliran.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Buat presentasi.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan workbook ke slide.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Simpan presentasi ke disk.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Buat objek LoadOptions EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Array nama sel.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Array data sel.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Tambahkan lembar kerja baru untuk mengisi sel dengan data.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Isi lembar data dengan data.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Tambahkan lembar grafik.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Tambahkan grafik ke lembar grafik dengan seri data dari lembar data.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Setel lembar grafik sebagai lembar aktif.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Presentasi yang dibuat dengan metode di atas akan berisi diagram Excel sebagai objek OLE yang dapat diaktifkan dengan mengklik ganda bingkai objek OLE.

## **Kesimpulan**

Dengan menggunakan Aspose.Cells untuk Java bersama dengan Aspose.Slides untuk Java, kita dapat membuat diagram Excel apa pun yang didukung oleh Aspose.Cells dan menyematkan diagram tersebut sebagai objek OLE dalam slide PowerPoint. Ukuran OLE diagram Excel juga dapat ditentukan. Pengguna akhir kemudian dapat mengedit diagram Excel seperti objek OLE lainnya.

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Tampilan Objek saat Menambahkan OleObjectFrame](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/)
- [Perbarui Objek OLE Secara Otomatis dengan Add-In PowerPoint](/slides/id/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)