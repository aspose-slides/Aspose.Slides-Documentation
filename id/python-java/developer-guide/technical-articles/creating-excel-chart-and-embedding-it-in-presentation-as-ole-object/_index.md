---
title: Buat Diagram Excel dan Sematkan ke Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- menyematkan diagram
- objek OLE
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk Python via Java dan sematkan buku kerja ke dalam presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells untuk Python via Java dan menyematkan buku kerja ke dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java. Buku kerja yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint asli. Mengedit buku kerja melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Instal paket Python `aspose-cells` dan `aspose-slides-java` serta runtime Java yang kompatibel. Impor kedua paket sebelum memulai JVM sehingga pustaka Java mereka tersedia untuk JPype. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak diperlukan berkas masukan: contoh ini membuat data dan diagram dalam memori, kemudian menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat buku kerja dengan lembar kerja data dan lembar diagram.  
2. Aktifkan lembar diagram sehingga buku kerja terbuka pada diagram.  
3. Atur rentang tampilan OLE buku kerja dan render diagram ke PNG.  
4. Simpan buku kerja sebagai XLSX dalam memori dan sematkan byte tersebut ke dalam slide.  
5. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.  

Rentang tampilan buku kerja dan bingkai pada slide memiliki peran yang berbeda. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) menerima indeks baris dan kolom mulai/akhir yang berbasis nol. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) sebaliknya menerima baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan-bawah; nilai tersebut adalah pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan poin. Contoh ini menyesuaikannya agar muat dalam slide dan menengahkannya sambil mempertahankan rasio aspek PNG, alih-alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum buku kerja disimpan.

Buku kerja disimpan secara eksplisit sebagai XLSX, cocok dengan ekstensi `xlsx` yang diteruskan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Aliran byte-array Java mempertahankan buku kerja dan gambar dalam memori serta menyediakan byte array yang dibutuhkan oleh API Java. PNG dimuat langsung dari byte-nya tanpa konversi bitmap perantara. Menetapkannya melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) menggantikan placeholder OLE default.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpile.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Render pratinjau diagram dan serialisasikan buku kerja yang dapat diedit secara terpisah.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Sesuaikan pratinjau dalam slide tanpa mengubah rasio aspeknya.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan buku kerja Excel yang disematkan dan pratinjau diagram. Buku kerja berisi data asli dan diagram kolom dengan empat seri. Pratinjau tersebut ditempatkan di tengah slide dan mempertahankan proporsinya.

![Diagram kolom Excel ditampilkan sebagai pratinjau buku kerja yang disematkan](excel-chart-ole-preview.png)

Dalam lingkungan PowerPoint desktop yang kompatibel dengan Excel tersedia, klik ganda objek untuk mengaktifkan dan mengedit buku kerja yang disematkan. Aktivasi dan penyuntingan bergantung pada dukungan OLE aplikasi host serta pengaturan keamanannya.

## **FAQ**

**Mengapa diperlukan gambar pratinjau?**  
Buku kerja yang disematkan dan pratinjau slide-nya merupakan konten terpisah. Sediakan gambar diagram sehingga slide menampilkan diagram alih-alih placeholder default "EMBEDDED OLE OBJECT". Lihat [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau diperbarui secara otomatis ketika saya mengubah buku kerja dalam kode?**  
Anggap pratinjau sebagai snapshot. Saat memperbarui data buku kerja secara programatik, buat kembali gambar diagram dan ganti pratinjau serta data buku kerja yang disematkan.

**Apakah saya dapat menggunakan XLS alih-alih XLSX?**  
Ya. Simpan buku kerja dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus sesuai dengan format buku kerja yang sebenarnya; mengubah ekstensi saja tidak mengkonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**  
Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan buku kerja. Rentang tampilan OLE buku kerja dan dimensi bingkai slide keduanya penting. Lihat [Solusi Bekerja untuk Mengubah Ukuran Diagram dalam PPTX](/slides/id/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Diagram dalam PPTX](/slides/id/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/)