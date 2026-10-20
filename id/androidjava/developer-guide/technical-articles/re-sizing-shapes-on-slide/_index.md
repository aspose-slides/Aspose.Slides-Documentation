---
title: Ubah Ukuran Bentuk pada Slide Presentasi di Android
type: docs
weight: 130
url: /id/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /id/androidjava/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Android
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Ikhtisar**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara memperbesar bentuk secara manual dan cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi relatif dan ukuran setiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar asli. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide‑nya tidak mengandung tabel, mengubah ukuran slide ke A4, dan menyimpan hasilnya. Ia menggunakan [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) sehingga loop selanjutnya mengendalikan penskalaan. Rasio‑rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat merusak bentuk, dan mengubah dimensi bentuk tidak memperbesar ukuran fontnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Hitung faktor skala horizontal dan vertikal secara independen.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
Tabel memerlukan penanganan terpisah: skala lebar kolom dan tinggi barisnya alih‑alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris mungkin tetap lebih besar dari yang diminta jika isi sel memerlukan lebih banyak ruang.
{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantunya menangani setiap [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) dengan memperkecil lebar kolom menggunakan [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) dan tinggi minimum baris menggunakan [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Kemudian ia memperkecil posisi tabel tanpa memperkecil secara terpisah dimensi keseluruhan tabel.

```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individu.
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

**Mengapa bentuk terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa memperkecil bentuk, mereka akan mempertahankan posisi dan dimensi asli serta mungkin melampaui batas slide. Memperkecil lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak yang dihasilkan, terutama teks dan tabel, karena contoh‑contoh ini tidak memperkecil ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skala lebar kolom dengan rasio lebar dan tinggi minimum baris dengan rasio tinggi, lalu skalakan posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah pengubahan ukuran ini berlaku untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengiterasi melalui [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) dan setiap master’s [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuknya.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersamaan dengan pengubahan ukuran?**

Ya. Panggil [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor penskalaan mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya atur?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Dimensi yang didukung juga tergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor penskalaan yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi serta posisi. Ini mempertahankan proporsi tetapi mungkin menyisakan ruang kosong di salah satu tepi.