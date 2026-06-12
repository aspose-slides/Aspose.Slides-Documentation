---
title: Diagram
type: docs
weight: 60
url: /id/python-net/examples/elements/chart/
keywords:
- diagram
- tambahkan diagram
- akses diagram
- hapus diagram
- perbarui diagram
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat dan sesuaikan diagram di Python dengan Aspose.Slides: tambahkan data, format seri, sumbu dan label, ubah jenis, dan ekspor—bekerja dengan PPT, PPTX, dan ODP."
---
Contoh menambahkan, mengakses, menghapus, dan memperbarui berbagai jenis diagram dengan **Aspose.Slides for Python via .NET**. Potongan kode di bawah ini menunjukkan operasi dasar diagram.

## **Tambahkan Diagram**

Metode ini menambahkan diagram area sederhana ke slide pertama.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan diagram kolom sederhana ke slide pertama.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Diagram**

Kode berikut mengambil diagram dari koleksi bentuk.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses diagram pertama pada slide.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Hapus Diagram**

Kode berikut menghapus diagram dari sebuah slide.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah diagram.
        chart = slide.shapes[0]

        # Hapus diagram.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Perbarui Data Diagram**

Anda dapat mengubah properti diagram seperti judul.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah diagram.
        chart = slide.shapes[0]

        # Ubah judul diagram.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```