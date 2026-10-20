---
title: Buat Diagram Excel dan Sematkan ke dalam Presentasi sebagai Objek OLE
type: docs
weight: 50
url: /id/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- sematkan diagram
- objek OLE
- PowerPoint
- presentasi
- Python
- Python via .NET
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk Python via .NET dan sematkan buku kerja ke dalam presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells untuk Python melalui .NET dan menyematkan buku kerja ke dalam presentasi PowerPoint dengan Aspose.Slides untuk Python melalui .NET. Buku kerja yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint asli. Mengedit buku kerja melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Instal paket `aspose-cells-python` dan `aspose-slides` di lingkungan Python Anda. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak ada file input yang diperlukan: contoh ini membuat data dan diagram di memori, kemudian menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk ketika menjalankan di luar mode evaluasi.

## **Cara Penyematan Bekerja**

1. Buat buku kerja dengan lembar kerja data dan lembar diagram.  
1. Aktifkan lembar diagram sehingga buku kerja terbuka pada diagram.  
1. Atur rentang tampilan OLE buku kerja dan render diagram ke PNG.  
1. Simpan buku kerja sebagai XLSX di memori dan sematkan byte tersebut ke dalam slide.  
1. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan buku kerja dan bingkai pada slide memiliki peran yang berbeda. **[set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)** mengambil indeks baris dan kolom mulai/akhir berbasis nol. **[ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/)** malah mengambil baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan-bawah; nilai ini merupakan pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan poin. Contoh ini menyesuaikannya dalam slide dan memusatkannya sambil mempertahankan rasio aspek PNG, alih-alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum buku kerja disimpan.

Buku kerja secara eksplisit disimpan sebagai XLSX, cocok dengan ekstensi `xlsx` yang diberikan ke **[OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/)**. PNG dimuat langsung dari stream-nya tanpa konversi bitmap perantara. Menetapkannya melalui **[substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/)** menggantikan placeholder OLE default.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Render pratinjau diagram dan serialisasikan buku kerja yang dapat diedit secara terpisah.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Sesuaikan pratinjau dalam slide tanpa mengubah rasio aspeknya.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan buku kerja Excel yang disematkan dan pratinjau diagram. Buku kerja berisi data asli dan diagram kolom dengan empat seri. Pratinjau dipusatkan pada slide dan mempertahankan proporsinya.

![Diagram kolom Excel yang ditampilkan sebagai pratinjau buku kerja yang disematkan](excel-chart-ole-preview.png)

Di lingkungan PowerPoint desktop yang kompatibel dengan Excel, klik ganda objek untuk mengaktifkan dan mengedit buku kerja yang disematkan. Aktivasi dan penyuntingan bergantung pada dukungan OLE aplikasi host serta pengaturan keamanannya.

## **FAQ**

**Mengapa gambar pratinjau diperlukan?**

Buku kerja yang disematkan dan pratinjau slide-nya adalah konten terpisah. Sediakan gambar diagram sehingga slide menampilkan diagram alih-alih placeholder default “EMBEDDED OLE OBJECT”. Lihat **[Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/python-net/object-preview-issue-when-adding-oleobjectframe/)**.

**Apakah pratinjau diperbarui secara otomatis ketika saya mengubah buku kerja dalam kode?**

Anggap pratinjau sebagai snapshot. Saat memperbarui data buku kerja secara programatis, buat ulang gambar diagram dan ganti pratinjau serta data buku kerja yang disematkan.

**Bisakah saya menggunakan XLS alih-alih XLSX?**

Ya. Simpan buku kerja dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus cocok dengan format buku kerja sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah diaktifkan?**

Aplikasi host dapat memperbarui tampilan objek OLE ketika ia mengaktifkan buku kerja. Rentang tampilan OLE buku kerja dan dimensi bingkai slide keduanya berpengaruh. Lihat **[Ubah Ukuran OLE Otomatis dalam Presentasi PowerPoint](/slides/id/python-net/working-solution-for-worksheet-resizing/)**.

## **Bagian Terkait**

- **[Ubah Ukuran OLE Otomatis dalam Presentasi PowerPoint](/slides/id/python-net/working-solution-for-worksheet-resizing/)**
- **[Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/python-net/object-preview-issue-when-adding-oleobjectframe/)**
- **[Kelola OLE Objects](/slides/id/python-net/manage-ole/)**