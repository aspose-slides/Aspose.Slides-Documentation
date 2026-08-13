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
## **Ikhtisar**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides for Java adalah bagaimana mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak sejajar ketika ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk sehingga sesuai dengan tata letak slide yang baru.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 
Tabel tidak memerlukan perlakuan khusus: mengatur lebar dan tinggi tabel akan mengubah skala kolom dan baris secara proporsional, jadi mengubah skala tinggi baris dan lebar kolom lagi akan menerapkan rasio dua kali.
{{% /alert %}} 

Kode di atas hanya mengubah bentuk pada slide. Slide master dan slide tata letak mempertahankan bentuk mereka sendiri, jadi skala mereka juga ketika Anda ingin seluruh presentasi mengikuti ukuran slide yang baru:

```java
import com.aspose.slides.*;

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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran asalnya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak sejajar.

### Apakah kode yang diberikan berfungsi untuk semua jenis bentuk?

Ya. Mengatur tinggi dan lebar bekerja untuk kotak teks, gambar, diagram, dan tabel sekaligus.

### Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?

Skala bentuk tabel itu sendiri, persis seperti bentuk lainnya. Baris dan kolomnya mengikuti secara proporsional, jadi jangan skala mereka lagi setelahnya.

### Apakah pengubahan ukuran ini akan berfungsi untuk slide master dan slide tata letak?

Ya, tetapi Anda juga harus mengulangi melalui [Master](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getMasters--) dan [Slide tata letak](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getLayoutSlides--) serta menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

### Bisakah saya mengubah orientasi slide (potret/lanskap) bersama dengan pengubahan ukuran?

Ya. Anda dapat menggunakan [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidesize/#setOrientation-int-) untuk mengubah orientasi. Pastikan Anda mengatur logika skala dengan tepat untuk mempertahankan tata letak.

### Apakah ada batasan ukuran slide yang dapat saya atur?

Aspose.Slides mendukung ukuran kustom, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

### Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?

Anda dapat memeriksa metode `getAspectRatioLocked` pada bentuk sebelum melakukan skala. Jika dikunci, sesuaikan lebar atau tinggi secara proporsional daripada men-skalanya secara terpisah.