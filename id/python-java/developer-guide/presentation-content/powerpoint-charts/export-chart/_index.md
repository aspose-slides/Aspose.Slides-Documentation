---
title: Ekspor Diagram Presentasi dengan Python via Java
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/python-java/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk Python via Java, mendukung format PPT dan PPTX, serta mempermudah pelaporan ke dalam alur kerja apa pun."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengekspor diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mengambil gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

Selain alur kerja dasar ekspor gambar, artikel ini juga membahas pertanyaan umum terkait ekspor, termasuk menyimpan konten diagram ke SVG, mengontrol ukuran output melalui opsi rendering, memuat font untuk mempertahankan tampilan label dan legenda, serta menjaga pemformatan presentasi asli seperti tema, gaya, isian, dan efek selama proses rendering.

## **Dapatkan Gambar Diagram**
Aspose.Slides for Python via Java mendukung ekstraksi gambar dari diagram tertentu. Contoh berikut menunjukkan cara melakukannya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah sebuah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Bagaimana cara menentukan ukuran tepat diagram yang diekspor dalam piksel?**

Gunakan overload rendering gambar yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung rendering objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat tidak benar setelah ekspor?**

[Muat font yang diperlukan](/slides/id/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti pemformatan presentasi (tema, gaya, isian, efek), sehingga tampilan diagram dipertahankan.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat [API](https://reference.aspose.com/slides/id/python-java/aspose.slides/)/[dokumentasi](/slides/id/python-java/convert-powerpoint/) untuk target output ([PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/id/python-java/convert-powerpoint-to-xps/), [HTML](/slides/id/python-java/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.