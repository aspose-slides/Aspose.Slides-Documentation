---
title: Sesuaikan Batang Kesalahan dalam Diagram Presentasi Menggunakan Python
linktitle: Batang Kesalahan
type: docs
url: /id/python-java/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang kesalahan pada diagram dengan Aspose.Slides untuk Python melalui Java—optimalkan visualisasi data dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan pada diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan batang kesalahan ke serangkaian diagram, mengkonfigurasi pengaturan batang kesalahan X dan Y, serta menerapkan berbagai jenis nilai seperti nilai tetap, persentase, dan nilai khusus.

Artikel ini juga mendemonstrasikan cara menetapkan nilai batang kesalahan khusus untuk titik data individu dalam sebuah seri dengan menggunakan koleksi titik data yang bersangkutan. Selain itu, artikel ini mencakup catatan singkat tentang bagaimana batang kesalahan berperilaku selama proses ekspor, kompatibilitasnya dengan penanda dan label data, serta dimana menemukan kelas dan enum referensi API terkait.

## **Menambahkan Batang Kesalahan**

Aspose.Slides untuk Python via Java menyediakan API sederhana untuk mengelola nilai batang kesalahan. Kode contoh berikut menggunakan jenis nilai tetap dan persentase.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Tambahkan diagram gelembung ke slide yang diinginkan.
3. Akses seri diagram pertama dan atur format batang kesalahan X.
4. Akses seri diagram pertama dan atur format batang kesalahan Y.
5. Atur nilai dan pemformatan batang kesalahan.
6. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    # Buat diagram gelembung.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Tambahkan batang kesalahan dan atur pemformatannya.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Simpan presentasi.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Nilai Batang Kesalahan Khusus**

Aspose.Slides untuk Python via Java menyediakan API sederhana untuk mengelola nilai batang kesalahan khusus. Kode contoh berikut berlaku ketika [getValueType](https://reference.aspose.com/slides/id/python-java/aspose.slides/errorbarsformat/#getValueType) mengembalikan [ErrorBarValueType.Custom](https://reference.aspose.com/slides/id/python-java/aspose.slides/errorbarvaluetype/#Custom). Untuk menentukan nilai, gunakan [getErrorBarsCustomValues](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) untuk titik data tertentu dalam koleksi yang dikembalikan oleh metode seri [getDataPoints](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getDataPoints).

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Tambahkan diagram gelembung ke slide yang diinginkan.
3. Akses seri diagram pertama dan atur format batang kesalahan X.
4. Akses seri diagram pertama dan atur format batang kesalahan Y.
5. Akses titik data individual dalam seri diagram dan atur nilai batang kesalahan mereka.
6. Atur nilai dan pemformatan batang kesalahan.
7. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    # Buat diagram gelembung.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Tambahkan batang kesalahan khusus dan atur pemformatannya.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Akses titik data seri diagram dan konfigurasikan sumber nilai batang kesalahannya.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Atur nilai batang kesalahan untuk titik data seri diagram.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Simpan presentasi.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa yang terjadi pada batang kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan sisa pemformatan diagram, dengan asumsi versi atau renderer yang kompatibel.

**Apakah batang kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Batang kesalahan adalah elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan pemformatannya.

**Di mana saya dapat menemukan daftar properti dan kelas untuk bekerja dengan batang kesalahan dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/errorbarsformat/) dan kelas terkait [ErrorBarType](https://reference.aspose.com/slides/id/python-java/aspose.slides/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/python-java/aspose.slides/errorbarvaluetype/).