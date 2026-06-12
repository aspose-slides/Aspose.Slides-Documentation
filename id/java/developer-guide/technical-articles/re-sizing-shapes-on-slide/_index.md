---
title: Ubah Ukuran Bentuk pada Slide Presentasi
type: docs
weight: 110
url: /id/java/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides untuk Java adalah bagaimana mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak selaras saat ukuran slide berubah, perbarui posisi dan dimensi tiap bentuk agar sesuai dengan tata letak slide yang baru.

```java
// Muat file presentasi.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Dapatkan ukuran slide asli.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Dapatkan ukuran slide baru.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ubah ukuran dan posisikan kembali bentuk pada setiap slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala posisi bentuk.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam kasus tersebut, setiap sel dalam tabel harus diubah ukurannya. 
{{% /alert %}} 

Gunakan kode berikut di sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, mengatur lebar atau tinggi merupakan kasus khusus: Anda harus menyesuaikan tinggi baris dan lebar kolom secara individual untuk mengubah ukuran keseluruhan tabel.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Dapatkan ukuran slide asli.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Dapatkan ukuran slide baru.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala posisi bentuk.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Skala ukuran bentuk.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Skala posisi bentuk.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala posisi bentuk.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Pertanyaan yang Sering Diajukan**

**Mengapa bentuk terdistorsi atau terpotong setelah mengubah ukuran slide?**

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak selaras.

**Apakah kode yang diberikan berfungsi untuk semua jenis bentuk?**

Contoh dasar berfungsi untuk kebanyakan jenis bentuk (kotak teks, gambar, diagram, dll.). Namun, untuk tabel, Anda harus menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel individual.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Anda perlu melakukan iterasi melalui semua baris dan kolom tabel serta mengubah tinggi dan lebar mereka secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

**Apakah pengubahan ukuran ini berfungsi untuk master slide dan layout slide?**

Ya, tetapi Anda juga harus melakukan iterasi melalui [Masters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getMasters--) dan [Layout slides](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getLayoutSlides--) serta menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersama dengan pengubahan ukuran?**

Ya. Anda dapat menggunakan [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidesize/#setOrientation-int-) untuk mengubah orientasi. Pastikan Anda menyesuaikan logika skala agar tata letak tetap terjaga.

**Apakah ada batasan ukuran slide yang dapat saya tetapkan?**

Aspose.Slides mendukung ukuran kustom, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Anda dapat memeriksa metode `getAspectRatioLocked` pada bentuk sebelum melakukan skala. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional daripada menskalakan keduanya secara terpisah.