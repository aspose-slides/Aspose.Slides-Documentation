---
title: Buat Diagram Excel dan Sematkan ke Dalam Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- sematkan diagram
- objek OLE
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells for Java dan sematkan workbook ke dalam presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau diagram."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells for Java dan menyematkan workbook‑nya ke dalam presentasi PowerPoint dengan Aspose.Slides for Java. Workbook yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint asli. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Tambahkan Aspose.Cells for Java dan Aspose.Slides for Java ke dependensi proyek Anda. Jalankan contoh di dalam metode Java. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak dibutuhkan file input: contoh ini membuat data dan diagram dalam memori, kemudian menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk ketika dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar chart.  
2. Aktifkan lembar chart sehingga workbook terbuka pada diagram.  
3. Atur rentang tampilan OLE workbook dan render diagram ke PNG.  
4. Simpan workbook sebagai XLSX dalam memori dan sematkan byte‑byte tersebut ke dalam slide.  
5. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) menerima indeks baris dan kolom mulai/akhir berbasis nol. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) menerima baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai‑nilai ini merupakan pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan satuan poin. Contoh ini menyesuaikannya dalam slide dan memusatkannya sambil mempertahankan rasio aspek PNG, alih‑alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi sebuah seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

Workbook secara eksplisit disimpan sebagai XLSX, sesuai dengan ekstensi `xlsx` yang diberikan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG dimuat langsung dari byte‑nya tanpa konversi bitmap menengah. Menetapkannya melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) menggantikan placeholder OLE default.

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

        // Render pratinjau diagram dan serialisasi workbook yang dapat diedit secara terpisah.
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

                // Sesuaikan pratinjau agar muat dalam slide tanpa mengubah rasio aspeknya.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
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
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau diagram. Workbook berisi data asli dan diagram kolom dengan empat seri. Pratinjau diposisikan di tengah slide dan mempertahankan proporsinya.

![Diagram kolom Excel yang ditampilkan sebagai pratinjau workbook yang disematkan](excel-chart-ole-preview.png)

Di lingkungan PowerPoint desktop yang kompatibel dengan Excel tersedia, klik ganda objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan pengeditan bergantung pada dukungan OLE aplikasi host serta pengaturan keamanannya.

## **Tanya Jawab**

**Mengapa gambar pratinjau diperlukan?**  
Workbook yang disematkan dan pratinjau slidennya merupakan konten terpisah. Sediakan gambar diagram supaya slide menampilkan diagram alih‑alih placeholder default "EMBEDDED OLE OBJECT". Lihat [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau memperbarui secara otomatis ketika saya mengubah workbook melalui kode?**  
Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatik, buat ulang gambar diagram dan gantikan pratinjau serta data workbook yang disematkan.

**Apakah saya dapat menggunakan XLS alih‑alih XLSX?**  
Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus cocok dengan format workbook yang sebenarnya; mengubah ekstensi saja tidak mengkonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**  
Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan workbook. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya berpengaruh. Lihat [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/)
- [Perbarui Objek OLE Secara Otomatis Menggunakan Add‑In PowerPoint](/slides/id/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)