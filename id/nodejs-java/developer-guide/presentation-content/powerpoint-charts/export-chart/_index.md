---
title: Ekspor Diagram Presentasi dalam JavaScript
linktitle: Ekspor Diagram
type: docs
weight: 90
url: /id/nodejs-java/export-chart/
keywords:
- diagram
- diagram ke gambar
- diagram sebagai gambar
- ekstrak gambar diagram
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengekspor diagram presentasi dengan Aspose.Slides untuk Node.js via Java, mendukung format PPT dan PPTX, serta menyederhanakan pelaporan ke dalam alur kerja apa pun."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengekspor sebuah diagram dari presentasi sebagai gambar. Artikel ini menunjukkan cara mendapatkan gambar dari diagram dan menyimpannya, yang berguna ketika Anda perlu menggunakan kembali visual diagram di luar presentasi PowerPoint.

## **Dapatkan Gambar Diagram**
Aspose.Slides for Node.js via Java menyediakan dukungan untuk mengekstrak gambar diagram tertentu. Contoh sampel di bawah ini diberikan.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengekspor diagram sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Diagram adalah sebuah shape, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-to-SVG](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/).

**Bagaimana saya dapat mengatur ukuran tepat diagram yang diekspor dalam piksel?**

Gunakan overload image‑rendering yang memungkinkan Anda menentukan ukuran atau skala—perpustakaan mendukung merender objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/nodejs-java/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/) sehingga rendering diagram mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides' mengikuti format presentasi (tema, gaya, isian, efek), sehingga tampilan diagram tetap terjaga.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar diagram?**

Lihat [API](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/)/[dokumentasi](/slides/id/nodejs-java/convert-powerpoint/) untuk target output ([PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.