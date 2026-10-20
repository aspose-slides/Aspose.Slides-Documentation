---
title: Solusi yang Berfungsi untuk Mengubah Ukuran Diagram di PPTX
type: docs
weight: 40
url: /id/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- mengubah ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Android via Java. Tetapkan dimensi diagram tetap agar ukuran diagram dan bingkai OLE tetap konsisten."
---
## **Ikhtisar**

Diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang terlihat pada tampilan diagram sebelum dan sesudah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan bingkai OLE.

Dalam [Buat Diagram Excel dan Sematkan Sebagai OLE Objects dalam Presentasi](/slides/id/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk Android via Java dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram. Dalam presentasi output, ketika Anda mengklik ganda bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat mengedit workbook Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar workbook yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Workbook Excel yang disematkan memiliki dimensi jendela sendiri, yang berusaha dipertahankan oleh Excel saat objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang ditentukan secara independen. Ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela workbook dan bingkai OLE dapat menyebabkan objek mengubah ukuran.

## **Solusi yang Berjalan**

Cocokkan ukuran diagram dengan bingkai OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela workbook. Solusi ini bekerja dengan presentasi baru atau templat yang sudah ada.

Contoh ini membutuhkan Aspose.Cells untuk Android via Java dan Aspose.Slides untuk Android via Java. Ia membuat diagram kolom sederhana pada lembar diagram aktif dan menyematkan workbook dalam format XLS. Panggil `FixedChartSize.createPresentation(getFilesDir())` dari sebuah aktivitas Android untuk menyimpan output ke direktori berkas internal aplikasi. Aktivasi OLE memerlukan PowerPoint desktop dan instalasi Excel yang kompatibel. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9.5 × 4 inci yang ditempatkan 0.5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide dalam poin (72 poin per inci). Untuk presentasi yang sudah ada, lihat [Gunakan Template](#use-a-template).

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // Koordinat slide dan dimensi dalam poin (72 poin per inci).
                    float width = 684f; // 9,5 inci.
                    float height = 288f; // 4 inci.

                    chart.setSizeWithWindow(false);
                    // Konversi poin ke piksel diagram menggunakan 96 piksel per inci.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Atur Ukuran Diagram Tetap**

Setel [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) ke false sehingga dimensi diagram tidak tergantung pada jendela workbook. Atur dimensi [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) melalui [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) dan [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), mengonversi poin ke piksel menggunakan 96 piksel per inci: sebuah bingkai berukuran 684 × 288 poin berkorespondensi dengan diagram berukuran 912 × 384 piksel. Setel [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) ke nilai CUSTOM dari [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Contoh ini menyematkan workbook dengan [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) dan menyimpan presentasi dengan bingkai OLE berukuran 9.5 × 4 inci.

## **Gunakan Template**

Logika pengukuran ukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi templat alih-alih membuat presentasi kosong.  
2. Periksa bahwa slide pertama berisi setidaknya tiga shape, lalu gunakan shape pada indeks 2 sebagai placeholder.  
3. Ambil lebar dan tinggi bingkai dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Pertahankan perhitungan ukuran tetap tidak berubah.  
4. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.  
5. Hapus placeholder sebelum menyimpan presentasi.

## **Tanya Jawab**

**Mengapa diagram Excel yang disematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sedangkan bingkai objek OLE di PowerPoint memiliki dimensi sendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana cara menjaga konsistensi ukuran diagram dan bingkai OLE?**

Tetapkan dimensi diagram tetap yang cocok dengan bingkai OLE dan gunakan ukuran cetak diagram khusus sebelum menyematkan workbook. Contoh di atas menunjukkan pengaturan yang diperlukan serta konversi satuan.

**Apakah mencocokkan ukuran jendela workbook saja sudah cukup?**

Mencocokkan ukuran jendela workbook saja tidak secara andal mencegah perubahan ukuran bingkai OLE setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan dalam contoh.

**Apakah solusi ini bekerja untuk presentasi berbasis templat maupun presentasi baru?**

Ya. Untuk templat, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Dapatkah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan workbook Excel yang dibuat dengan Aspose.Cells. Ia tidak memperlihatkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai OLE Objects dalam Presentasi](/slides/id/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)