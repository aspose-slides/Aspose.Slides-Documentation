---
title: Solusi Praktis untuk Mengatasi Perubahan Ukuran Diagram di PPTX
type: docs
weight: 40
url: /id/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- perubahan ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Python via Java. Tetapkan dimensi diagram tetap untuk menjaga konsistensi ukuran diagram dan bingkai OLE."
---
## **Latar Belakang**

Diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang terlihat pada tampilan diagram sebelum dan sesudah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan bingkai OLE.

Dalam [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk Python via Java dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram. Dalam presentasi keluaran, ketika Anda mengklik ganda bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat menyunting buku kerja Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar buku kerja yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Buku kerja Excel yang disematkan memiliki dimensi jendela tersendiri, yang berusaha dipertahankan oleh Excel saat objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang didefinisikan secara independen. Ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela buku kerja dan bingkai OLE dapat menyebabkan objek diubah ukurannya.

## **Solusi yang Berfungsi**

Sesuaikan ukuran diagram dengan bingkai OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela buku kerja. Solusi ini bekerja dengan presentasi baru atau templat yang sudah ada.

Contoh ini memerlukan Aspose.Cells untuk Python via Java dan Aspose.Slides untuk Python via Java. Contoh ini membuat diagram kolom sederhana pada lembar diagram aktif dan menyematkan buku kerja dalam format XLS. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9.5 × 4‑inch yang ditempatkan 0.5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide dalam satuan poin (72 poin per inci). Untuk presentasi yang sudah ada, lihat [Gunakan Templat](#use-a-template).

## **Atur Ukuran Diagram Tetap**

Setel [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) ke false sehingga dimensi diagram terpisah dari jendela buku kerja. Setel dimensi [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) melalui [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) dan [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), mengonversi poin ke piksel menggunakan 96 piksel per inci: sebuah bingkai dengan ukuran 684 × 288 poin sesuai dengan diagram berukuran 912 × 384 piksel. Setel [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) ke nilai CUSTOM dari [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Contoh ini menyematkan buku kerja dengan [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) dan menyimpan presentasi dengan bingkai OLE berukuran 9.5 × 4‑inch.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Koordinat dan dimensi slide dalam satuan poin (72 poin per inci).
        width = 684.0  # 9,5 inci.
        height = 288.0  # 4 inci.

        chart.setSizeWithWindow(False)
        # Konversi poin ke piksel diagram menggunakan 96 piksel per inci.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Gunakan Templat**

Logika pengukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi templat alih-alih membuat presentasi kosong.
1. Periksa bahwa slide pertama berisi setidaknya tiga bentuk, lalu gunakan bentuk pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi bingkai dari bentuk tersebut alih-alih menggunakan nilai tetap 684 dan 288. Pertahankan perhitungan ukuran tetap.
1. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sedangkan bingkai objek OLE di PowerPoint memiliki dimensinya sendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana saya dapat menjaga konsistensi ukuran diagram dan bingkai OLE?**

Atur dimensi diagram tetap yang cocok dengan bingkai OLE dan gunakan ukuran cetak diagram khusus sebelum menyematkan buku kerja. Contoh di atas menunjukkan pengaturan yang diperlukan serta konversi satuan.

**Apakah mencocokkan ukuran jendela buku kerja sudah cukup?**

Mencocokkan ukuran jendela buku kerja saja tidak dapat diandalkan untuk mencegah bingkai OLE berubah ukuran setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan dalam contoh.

**Apakah solusi ini bekerja dengan presentasi berbasis templat maupun presentasi baru?**

Ya. Untuk templat, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Bisakah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan buku kerja Excel yang dibuat dengan Aspose.Cells. Contoh ini tidak memperlihatkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)