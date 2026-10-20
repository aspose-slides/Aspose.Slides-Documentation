---
title: Membuat Diagram Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- menyematkan diagram
- objek OLE
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk Android via Java dan sematkan workbook‑nya dalam presentasi PowerPoint dengan Aspose.Slides untuk Android via Java, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells untuk Android via Java dan menyematkan workbook‑nya dalam presentasi PowerPoint dengan Aspose.Slides untuk Android via Java. Workbook yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint asli. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Tambahkan Aspose.Cells untuk Android via Java dan Aspose.Slides untuk Android via Java ke dependensi proyek Anda. Panggil `ExcelChartEmbedding.createPresentation(getFilesDir())` dari sebuah aktivitas Android. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan perpustakaan ini.

Tidak ada file masukan yang diperlukan: contoh membuat data dan diagram di memori, kemudian menulis `OutputChart.pptx` ke direktori file internal aplikasi. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar diagram.  
2. Jadikan lembar diagram aktif sehingga workbook dibuka pada diagram.  
3. Atur rentang tampilan OLE workbook dan render diagram ke PNG.  
4. Simpan workbook sebagai XLSX di memori dan sematkan byte‑byte tersebut dalam slide.  
5. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) menerima indeks baris dan kolom mulai/akhir berbasis nol. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) justru menerima baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai‑nilai ini merupakan pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan poin. Contoh ini menyesuaikannya agar muat dalam slide dan menempatkannya di tengah sambil mempertahankan rasio aspek PNG, alih‑alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

Workbook secara eksplisit disimpan sebagai XLSX, cocok dengan ekstensi `xlsx` yang diberikan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG dimuat langsung dari byte‑nya tanpa konversi bitmap menengah. Menetapkannya melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) menggantikan placeholder OLE bawaan.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // Render pratinjau diagram dan serialisasikan workbook yang dapat diedit secara terpisah.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // Sesuaikan pratinjau dalam slide tanpa mengubah rasio aspeknya.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau diagram. Workbook berisi data asli serta diagram kolom dengan empat seri. Pratinjau berada di tengah slide dan mempertahankan proporsinya.

![Diagram kolom Excel ditampilkan sebagai pratinjau workbook yang disematkan](excel-chart-ole-preview.png)

Di lingkungan PowerPoint desktop yang kompatibel dengan Excel tersedia, double‑klik objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan penyuntingan bergantung pada dukungan OLE serta pengaturan keamanan aplikasi host.

## **FAQ**

**Mengapa diperlukan gambar pratinjau?**

Workbook yang disematkan dan pratinjau slidennya adalah konten terpisah. Sediakan gambar diagram agar slide menampilkan diagram alih‑alih placeholder “EMBEDDED OLE OBJECT” default. Lihat [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau otomatis diperbarui ketika saya mengubah workbook di kode?**

Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatik, buat ulang gambar diagram dan gantikan pratinjau serta data workbook yang disematkan.

**Bisakah saya menggunakan XLS alih‑alih XLSX?**

Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus cocok dengan format workbook sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**

Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan workbook. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya berpengaruh. Lihat [Solusi yang Berhasil untuk Mengubah Ukuran Worksheet](/slides/id/androidjava/working-solution-for-worksheet-resizing/).

## **Bagian Terkait**

- [Solusi yang Berhasil untuk Mengubah Ukuran Worksheet](/slides/id/androidjava/working-solution-for-worksheet-resizing/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Kelola OLE](/slides/id/androidjava/manage-ole/)