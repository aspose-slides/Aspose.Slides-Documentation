---
title: Sesuaikan Area Plot Grafik Presentasi di Python
linktitle: Area Plot
type: docs
url: /id/python-net/chart-plot-area/
keywords:
- grafik
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot grafik dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Tingkatkan visual slide Anda dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan area plot grafik di Aspose.Slides. Ini menjelaskan cara mendapatkan posisi dan ukuran sebenarnya dari area plot dengan memvalidasi tata letak grafik dan kemudian membaca nilai X, Y, lebar, dan tinggi.

Ini juga menunjukkan cara mengkonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar, Tinggi Area Plot Grafik**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk .  

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tambahkan grafik dengan data default.
4. Panggil metode IChart.ValidateChartLayout() terlebih dahulu untuk mendapatkan nilai sebenarnya.
5. Dapatkan lokasi X aktual (kiri) elemen grafik relatif terhadap sudut kiri atas grafik.
6. Dapatkan posisi atas aktual elemen grafik relatif terhadap sudut kiri atas grafik.
7. Dapatkan lebar aktual elemen grafik.
8. Dapatkan tinggi aktual elemen grafik.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Simpan presentasi dengan grafik
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Mode Tata Letak Area Plot Grafik**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengatur mode tata letak area plot grafik. Properti **LayoutTargetType** telah ditambahkan ke kelas **ChartPlotArea** dan **IChartPlotArea**. Jika tata letak area plot didefinisikan secara manual, properti ini menentukan apakah menata area plot berdasarkan bagian dalamnya (tidak termasuk sumbu dan label sumbu) atau bagian luarnya (termasuk sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tidak termasuk tanda centang dan label sumbu.
- **LayoutTargetType.Outer** - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tanda centang, dan label sumbu.

Contoh kode diberikan di bawah.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Dalam satuan apa actual_x, actual_y, actual_width, dan actual_height dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana Area Plot berbeda dari Area Grafik dalam hal konten?**

Area Plot adalah wilayah menggambar data (seri, garis kisi, garis tren, dll.); Area Grafik mencakup elemen di sekitarnya (judul, legenda, dll.). Pada grafik 3D, Area Plot juga mencakup dinding/lantai dan sumbu.

**Bagaimana X, Y, Lebar, dan Tinggi Area Plot diinterpretasikan ketika tata letak manual?**

Mereka adalah pecahan (0–1) dari ukuran keseluruhan grafik; dalam mode ini, penempatan otomatis dinonaktifkan dan pecahan yang Anda atur digunakan.

**Mengapa posisi Area Plot berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di area grafik di luar Area Plot tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Area Plot dapat bergeser ketika penempatan otomatis berlaku. (Ini merupakan perilaku standar untuk grafik PowerPoint.)