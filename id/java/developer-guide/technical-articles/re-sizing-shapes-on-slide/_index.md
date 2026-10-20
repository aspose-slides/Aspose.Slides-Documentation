---
title: Mengubah Ukuran Bentuk pada Slide Presentasi di Java
type: docs
weight: 130
url: /id/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /id/java/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ganti ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java—otomatisasi penyesuaian tata letak slide dan meningkatkan produktivitas."
---
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan ulang bentuk‑bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara memperkecil atau memperbesar bentuk secara manual dan cara menangani tabel pada slide, master, serta tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif tiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar asli. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat sebuah presentasi yang slide‑nya tidak berisi tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Contoh ini menggunakan [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) sehingga loop berikutnya mengendalikan penskalaan. Rasio‑rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam point. Rasio lebar dan tinggi yang berbeda dapat mengubah bentuk, dan mengubah dimensi sebuah bentuk tidak memperbesar ukuran fontnya.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Hitung faktor skala horizontal dan vertikal secara independen.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabel memerlukan penanganan terpisah: skalakan lebar kolom dan tinggi baris alih‑alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris dapat tetap lebih besar dari yang diminta jika konten sel memerlukan lebih banyak ruang.
{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantuannya menangani setiap [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) dengan memperkecil lebar kolom menggunakan [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) dan tinggi minimal baris dengan [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Kemudian ia memperkecil posisi tabel tanpa memperkecil dimensi keseluruhan secara terpisah.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Dimensi tabel dikendalikan oleh lebar kolom dan tinggi baris.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Hitung faktor skala horizontal dan vertikal secara independen.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individual.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa menskalakan bentuk‑bentuk, mereka akan mempertahankan posisi dan dimensi aslinya serta dapat melampaui batas slide. Menskalakan lebar dan tinggi dengan rasio yang berbeda juga dapat menyebabkan bentuk terdistorsi.

**Apakah kode yang disediakan bekerja untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak hasil, terutama teks dan tabel, karena contoh ini tidak memperbesar ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skalakan lebar kolom dengan rasio lebar dan tinggi minimal baris dengan rasio tinggi, lalu skalakan posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah pengubahan ukuran ini bekerja untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengiterasi melalui [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) dan setiap master melalui [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuk mereka.

**Apakah saya dapat mengubah orientasi slide (potret/lanskap) bersamaan dengan pengubahan ukuran?**

Ya. Panggil [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya tetapkan?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Dimensi yang didukung juga bergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi dan posisi. Ini mempertahankan proporsi tetapi dapat meninggalkan ruang kosong di salah satu sisi.