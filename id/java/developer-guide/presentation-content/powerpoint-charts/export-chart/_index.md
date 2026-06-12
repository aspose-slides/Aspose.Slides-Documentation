---
title: Ekspor Diagram Presentasi di Java
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/java/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk Java, mendukung format PPT dan PPTX, serta menyederhanakan pelaporan ke dalam alur kerja apa pun."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengekspor diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mendapatkan gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

Selain alur kerja dasar ekspor gambar, artikel ini juga membahas pertanyaan umum terkait ekspor, termasuk menyimpan konten diagram ke SVG, mengontrol ukuran output melalui opsi rendering, memuat font untuk mempertahankan tampilan label dan legenda, serta menjaga format presentasi asli seperti tema, gaya, isian, dan efek selama proses rendering.

## **Dapatkan Gambar Diagram**
Aspose.Slides untuk Java menyediakan dukungan untuk mengekstrak gambar dari diagram tertentu. Contoh sampel di bawah ini diberikan.  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah sebuah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Bagaimana cara mengatur ukuran tepat diagram yang diekspor dalam piksel?**

Gunakan overload rendering-gambar yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung rendering objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/java/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti format presentasi (tema, gaya, isian, efek), sehingga tampilan diagram tetap terjaga.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat [API](https://reference.aspose.com/slides/id/java/com.aspose.slides/)/[dokumentasi](/slides/id/java/convert-powerpoint/) untuk target output ([PDF](/slides/id/java/convert-powerpoint-to-pdf/), [SVG](/slides/id/java/render-a-slide-as-an-svg-image/), [XPS](/slides/id/java/convert-powerpoint-to-xps/), [HTML](/slides/id/java/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.