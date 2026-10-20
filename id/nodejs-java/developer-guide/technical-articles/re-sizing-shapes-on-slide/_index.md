---
title: "Ubah Ukuran Bentuk pada Slide Presentasi di Node.js"
type: docs
weight: 130
url: /id/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/mengubah-ukuran-bentuk-pada-slide/
  - /id/nodejs-java/re-sizing-shapes-on-slide/
keywords:
  - ubah ukuran bentuk
  - ubah ukuran bentuk
  - PowerPoint
  - OpenDocument
  - presentasi
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Dengan mudah ubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuk‑bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara memperbesar bentuk secara manual dan cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif tiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar asal. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide‑nya tidak memiliki tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Contoh ini menggunakan [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) sehingga loop selanjutnya mengendalikan skala. Rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat mendistorsi bentuk, dan mengubah dimensi bentuk tidak mengubah ukuran font.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Hitung faktor skala horizontal dan vertikal yang independen.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Tabel memerlukan penanganan terpisah: skalakan lebar kolom dan tinggi baris alih‑alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris mungkin tetap lebih besar dari yang diminta jika konten sel membutuhkan lebih banyak ruang.

{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantu dalam contoh ini menangani setiap [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) dengan memperbesar lebar kolom menggunakan [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) dan tinggi minimal baris menggunakan [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Kemudian tabel diposisikan kembali tanpa memperbesar dimensi keseluruhannya secara terpisah.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Dimensi tabel dikendalikan oleh lebar kolom dan tinggi baris.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Hitung faktor skala horizontal dan vertikal yang independen.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individu.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa menskala bentuk, bentuk akan mempertahankan posisi dan dimensi aslinya serta dapat melampaui batas slide. Menskala lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak hasil, terutama teks dan tabel, karena contoh ini tidak menskala ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skalakan lebar kolom dengan rasio lebar dan tinggi minimal baris dengan rasio tinggi, kemudian skalakan posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah perubahan ukuran ini berlaku untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengiterasi melalui [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) dan setiap master melalui [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuk mereka.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersamaan dengan mengubah ukuran?**

Ya. Panggil [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya tetapkan?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Dimensi yang didukung juga tergantung pada format presentasi dan aplikasi yang digunakan untuk membuka berkas.

**Bagaimana cara mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi dan posisi. Ini mempertahankan proporsi tetapi mungkin meninggalkan ruang kosong di salah satu sisi.