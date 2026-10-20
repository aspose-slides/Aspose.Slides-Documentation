---
title: Solusi Praktis untuk Mengubah Ukuran Bagan di PPTX
type: docs
weight: 60
url: /id/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- pengubahan ukuran bagan
- bagan Excel
- objek OLE
- menyematkan bagan
- PowerPoint
- presentasi
- Python via .NET
- Python
- Aspose.Slides
description: "Perbaiki perubahan ukuran bagan yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Python via .NET. Tetapkan dimensi bagan tetap untuk menjaga konsistensi ukuran bagan dan bingkai OLE."
---
## **Gambaran Umum**

Bagan Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang mencolok pada tampilan bagan sebelum dan setelah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi bagan tetap dengan bingkai OLE.

Di [Buat Bagan Excel dan Sematkan Sebagai OLE Object dalam Presentasi](/slides/id/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat bagan Excel dengan Aspose.Cells untuk Python via .NET dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET. Untuk mengatasi [object preview issue](/slides/id/python-net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar bagan ke bingkai objek OLE bagan. Dalam presentasi output, saat Anda mengklik ganda bingkai objek OLE yang menampilkan gambar bagan, bagan Excel diaktifkan. Pengguna dapat mengedit workbook Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar workbook yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Workbook Excel yang disematkan memiliki dimensi jendela tersendiri, yang coba dipertahankan Excel saat objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang ditentukan secara independen. Ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela workbook dan bingkai OLE dapat menyebabkan objek diubah ukurannya.

## **Solusi yang Berfungsi**

Cocokkan ukuran bagan dengan bingkai OLE pada slide dan pertahankan dimensi bagan terpisah dari jendela workbook. Solusi ini bekerja pada presentasi baru maupun templat yang sudah ada.

Contoh ini memerlukan Aspose.Cells untuk Python via .NET dan Aspose.Slides untuk Python via .NET. Ia membuat bagan kolom sederhana pada lembar bagan aktif dan menyematkan workbook dalam format XLS. Tidak ada gambar pratinjau bagan yang ditetapkan; bagan muncul ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9,5 × 4 inci yang ditempatkan 0,5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide menggunakan poin (72 poin per inci). Untuk presentasi yang sudah ada, lihat [Gunakan Template](#use-a-template).

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Koordinat dan dimensi slide berada dalam poin (72 poin per inci).
    width = 684.0  # 9,5 inci.
    height = 288.0  # 4 inci.

    chart.size_with_window = False
    # Konversi poin ke piksel bagan menggunakan 96 piksel per inci.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Ukuran Bagan Tetap**

Atur [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) ke false sehingga dimensi bagan terpisah dari jendela workbook. Atur dimensi [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) melalui [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) dan [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), mengonversi poin ke piksel dengan menggunakan 96 piksel per inci: sebuah bingkai berukuran 684 × 288 poin berkorespondensi dengan bagan berukuran 912 × 384 piksel. Atur [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) ke nilai CUSTOM dari [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Contoh ini menyematkan workbook dengan [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) dan menyimpan presentasi dengan bingkai OLE berukuran 9,5 × 4 inci.

## **Gunakan Template**

Logika pengukuran ukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi templat alih-alih membuat presentasi kosong.
1. Periksa bahwa slide pertama berisi setidaknya tiga shape, lalu gunakan shape pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi bingkai dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Pertahankan perhitungan ukuran tanpa perubahan.
1. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **FAQ**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**  
Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**How can I keep the chart and OLE frame sizes consistent?**  
Atur dimensi bagan tetap yang sesuai dengan bingkai OLE dan gunakan ukuran cetak bagan khusus sebelum menyematkan workbook. Contoh di atas menunjukkan pengaturan yang diperlukan dan konversi satuan.

**Is matching the workbook window size sufficient?**  
Mencocokkan ukuran jendela workbook saja tidak secara andal mencegah bingkai OLE berubah ukuran setelah aktivasi. Gunakan dimensi bagan tetap seperti yang ditunjukkan dalam contoh.

**Does this solution work with both template-based presentations and new presentations?**  
Ya. Untuk templat, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Can I use this example with charts created in other spreadsheet programs?**  
Contoh ini menggunakan workbook Excel yang dibuat dengan Aspose.Cells. Ia tidak menunjukkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Bagan Excel dan Sematkan Sebagai OLE Object dalam Presentasi](/slides/id/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Perbarui OLE Object Secara Otomatis Menggunakan Add-In PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)