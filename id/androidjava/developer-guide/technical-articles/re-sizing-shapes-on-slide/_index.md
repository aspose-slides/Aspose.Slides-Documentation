---
title: Ubah Ukuran Bentuk pada Slide Presentasi di Android
type: docs
weight: 130
url: /id/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
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
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuk-bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara mengubah skala bentuk secara manual dan cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif setiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar asli. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide-nya tidak berisi tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Ini menggunakan [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) sehingga loop berikutnya mengendalikan skala. Rasio-rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat mendistorsi bentuk, dan mengubah dimensi bentuk tidak mengubah skala ukuran fontnya.

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
Tabel memerlukan penanganan terpisah: skala lebar kolom dan tinggi baris alih-alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris mungkin tetap lebih besar daripada yang diminta jika konten sel memerlukan lebih banyak ruang.
{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang diubah ukurannya. Pembantuannya menangani setiap [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) dengan mengubah skala lebar kolom menggunakan [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) dan tinggi baris minimum dengan [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Kemudian ia mengubah skala posisi tabel tanpa mengubah skala dimensi keseluruhan secara terpisah.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Dimensi tabel dikontrol oleh lebar kolom dan tinggi baris.
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

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa mengubah skala bentuk, bentuk tersebut tetap pada posisi dan dimensi aslinya dan dapat melampaui batas slide. Mengubah skala lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak hasil, terutama teks dan tabel, karena contoh-contoh ini tidak mengubah skala ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skala lebar kolom menggunakan rasio lebar dan tinggi baris minimum menggunakan rasio tinggi, kemudian skala posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah perubahan ukuran ini akan berfungsi untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengulangi melalui [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) dan setiap master [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) serta menerapkan logika pengubahan ukuran yang sama pada bentuk mereka.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersamaan dengan pengubahan ukuran?**

Ya. Panggil [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya tentukan?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Dimensi yang didukung juga tergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi dan posisi. Ini mempertahankan proporsi tetapi dapat meninggalkan ruang kosong di salah satu sisi.