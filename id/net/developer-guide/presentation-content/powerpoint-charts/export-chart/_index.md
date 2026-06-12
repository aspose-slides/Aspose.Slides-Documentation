---
title: Ekspor Diagram Presentasi di .NET
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/net/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk .NET, mendukung format PPT dan PPTX, serta mempermudah pelaporan dalam alur kerja apa pun."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengekspor diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mendapatkan gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

Selain alur kerja ekspor gambar dasar, artikel ini juga menjawab pertanyaan umum terkait ekspor, termasuk menyimpan konten diagram ke SVG, mengontrol ukuran output melalui opsi rendering, memuat font untuk mempertahankan tampilan label dan legenda, serta menjaga pemformatan presentasi asli seperti tema, gaya, isi, dan efek selama rendering.

## **Dapatkan Gambar Diagram**
Aspose.Slides for .NET menyediakan dukungan untuk mengekstrak gambar dari diagram tertentu. Contoh sampel di bawah diberikan.  

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/).

**Bagaimana cara menetapkan ukuran tepat diagram yang diekspor dalam piksel?**

Gunakan overload rendering gambar yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung rendering objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/net/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti pemformatan presentasi (tema, gaya, isi, efek), sehingga tampilan diagram tetap terjaga.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat bagian ekspor pada [API](https://reference.aspose.com/slides/id/net/aspose.slides.export/)/[dokumentasi](/slides/id/net/convert-powerpoint/) untuk target output ([PDF](/slides/id/net/convert-powerpoint-to-pdf/), [SVG](/slides/id/net/render-a-slide-as-an-svg-image/), [XPS](/slides/id/net/convert-powerpoint-to-xps/), [HTML](/slides/id/net/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.