---
title: Ekspor Diagram Presentasi dengan Python
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/python-net/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk Python via .NET, mendukung format PPT, PPTX, dan ODP, serta mempermudah pelaporan ke dalam alur kerja apa pun."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengekspor diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mendapatkan gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

## **Dapatkan Gambar Diagram**
Aspose.Slides untuk Python via .NET menyediakan dukungan untuk mengekstrak gambar dari diagram tertentu. Contoh sampel di bawah diberikan.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/write_as_svg/).

**Bagaimana cara mengatur ukuran tepat diagram yang diekspor dalam piksel?**

Gunakan overload rendering gambar yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung merender objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/python-net/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti pemformatan presentasi (tema, gaya, isi, efek), sehingga tampilan diagram dipertahankan.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat bagian ekspor dari [API](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/)/[dokumentasi](/slides/id/python-net/convert-powerpoint/) untuk target output ([PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/id/python-net/convert-powerpoint-to-xps/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.