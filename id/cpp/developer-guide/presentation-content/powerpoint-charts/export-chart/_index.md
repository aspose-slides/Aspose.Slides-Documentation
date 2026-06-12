---
title: Ekspor Bagan Presentasi dalam C++
linktitle: Ekspor Bagan
type: docs
weight: 90
url: /id/cpp/export-chart/
keywords:
- bagan
- bagan ke gambar
- bagan sebagai gambar
- ekstrak gambar bagan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengekspor bagan presentasi dengan Aspose.Slides untuk C++, mendukung format PPT dan PPTX, serta mempermudah pelaporan ke dalam alur kerja apa pun."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengekspor bagan dari presentasi sebagai gambar. Artikel ini menunjukkan cara mendapatkan gambar dari bagan dan menyimpannya, yang berguna ketika Anda perlu menggunakan visual bagan di luar presentasi PowerPoint.

## **Dapatkan Gambar Bagan**
Aspose.Slides untuk C++ menyediakan dukungan untuk mengekstrak gambar bagan tertentu. Contoh sampel di bawah diberikan.  

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Apakah saya dapat mengekspor bagan sebagai vektor (SVG) alih-alih gambar raster?**

Ya. Bagan adalah bentuk, dan isinya dapat disimpan ke SVG menggunakan [metode penyimpanan shape-ke-SVG](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/).

**Bagaimana cara mengatur ukuran pasti bagan yang diekspor dalam piksel?**

Gunakan overload rendering gambar yang memungkinkan Anda menentukan ukuran atau skala — perpustakaan mendukung rendering objek dengan dimensi/skala yang diberikan.

**Apa yang harus saya lakukan jika font pada label dan legenda terlihat salah setelah ekspor?**

[Muat font yang diperlukan](/slides/id/cpp/custom-font/) melalui [FontsLoader](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/) sehingga rendering bagan mempertahankan metrik dan tampilan teks.

**Apakah ekspor menghormati tema, gaya, dan efek PowerPoint?**

Ya. Renderer Aspose.Slides mengikuti pemformatan presentasi (tema, gaya, isi, efek), sehingga tampilan bagan tetap terjaga.

**Di mana saya dapat menemukan kemampuan rendering/ekspor yang tersedia selain gambar bagan?**

Lihat bagian ekspor pada [API](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/)/[dokumentasi](/slides/id/cpp/convert-powerpoint/) untuk target keluaran ([PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/id/cpp/convert-powerpoint-to-xps/), [HTML](/slides/id/cpp/convert-powerpoint-to-html/), dll.) dan opsi rendering terkait.