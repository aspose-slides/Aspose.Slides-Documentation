---
title: Kelola Objek Tinta Presentasi di Java
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/java/manage-ink/
keywords:
  - tinta
  - objek tinta
  - jejak tinta
  - kelola tinta
  - gambar tinta
  - menggambar
  - ekspor tinta
  - rendering tinta
  - sembunyikan tinta
  - IInkOptions
  - PowerPoint
  - presentasi
  - Java
  - Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol tampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk Java."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan koneksi dan proses, serta menarik perhatian ke item tertentu pada slide.

Aspose.Slides menyediakan tipe yang diperlukan untuk bekerja dengan objek tinta. Misalnya, antarmuka [IInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iink/) mewakili sebuah objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek bentuk. Dalam bentuk paling sederhana, sebuah bentuk adalah wadah yang mendefinisikan area objek itu sendiri (bingkainya) bersama properti seperti ukuran wadah, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh metode standar [IShape.getWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getWidth--) dan [IShape.getHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Sebuah jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding yang paling sederhana menentukan koordinat X dan Y setiap titik sampel. Saat semua titik terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik‑titik jejak tinta. Kuas memiliki warna dan ukuran sendiri, yang direpresentasikan oleh metode [IInkBrush.getColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkbrush/#getColor--) dan [IInkBrush.getSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Setel Warna Kuas Tinta**

Kode Java ini menunjukkan cara menyetel warna kuas tinta:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Setel Ukuran Kuas Tinta**

Kode Java ini menunjukkan cara menyetel ukuran kuas tinta:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Secara umum, lebar dan tinggi kuas tidak sama, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu‑abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (bingkai) tidak memperhitungkan ukuran kuas—ia selalu mengasumsikan ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas jejak‑jejaknya harus dipertimbangkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (bingkai). Ketika ukuran wadah berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrol Penampilan Tinta Saat Ekspor dan Rendering**

Aspose.Slides menyediakan antarmuka [IInkOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/) untuk mengontrol cara objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi topeng kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk beberapa tipe output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Gambar slide | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Metode [IInkOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/) berikut mengekspos dua pengaturan yang sama:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#getHideInk--) menentukan apakah objek tinta disertakan dalam output. Nilai defaultnya adalah `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) menentukan apakah operasi topeng diinterpretasikan sebagai opasitas saat merender kuas tinta. Nilai defaultnya adalah `true`; panggil [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) dengan `false` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta pada Output PDF**

Secara default, objek tinta tetap terlihat saat ekspor. Untuk membuat output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya, panggil [IInkOptions.setHideInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) dengan `true`.

Contoh Java berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Sembunyikan Objek Tinta Saat Rendering Slide menjadi Gambar**

Untuk menyembunyikan objek tinta saat merender slide menjadi gambar bitmap, konfigurasikan [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/#getInkOptions--) dan berikan opsi rendering ke [ISlide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) .

Contoh Java berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kontrol Rendering Topeng Tinta**

Pengaturan [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) mengontrol cara operasi topeng diinterpretasikan saat merender kuas tinta. Nilai defaultnya adalah `true`, yang menggunakan opasitas. Untuk menggunakan operasi ROP sebagai gantinya, panggil [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) dengan `false`.

Contoh Java berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi topeng tinta:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/#getInkOptions--) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih Apakah Menyembunyikan atau Mempertahankan Tinta**

Ketika Anda memerlukan versi bersih dari presentasi beranotasi untuk distribusi tanpa tanda tinjauan, panggil [IInkOptions.setHideInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) dengan `true` saat ekspor.

Biarkan [IInkOptions.getHideInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#getHideInk--) pada nilai default `false` ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar tinjauan, catatan tulisan tangan, sorotan, atau gambar yang harus tetap terlihat dalam hasil yang diekspor. Ini memungkinkan aplikasi menghasilkan output tinjauan dan final yang terpisah dari presentasi yang sama tanpa memodifikasi objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang sudah ada?**

Ya. Dapatkan jejaknya dari [IInk.getTraces](https://reference.aspose.com/slides/id/java/com.aspose.slides/iink/#getTraces--), lalu ubah [IInkTrace.getBrush](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinktrace/#getBrush--). Panggil [IInkBrush.setColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) atau [IInkBrush.setSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) untuk mengubah kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. Memanggil [IInkOptions.setHideInk](https://reference.aspose.com/slides/id/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) hanya memengaruhi hasil yang dirender atau diekspor; ia tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang ditunjukkan di atas.

**Bacaan lebih lanjut**

* Untuk membaca tentang bentuk secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/java/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail tentang ekspor PDF, lihat [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/id/java/convert-powerpoint-to-pdf/).
* Untuk detail tentang ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/id/java/convert-powerpoint-to-html/).
* Untuk detail tentang ekspor SVG, lihat [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/id/java/render-a-slide-as-an-svg-image/).
* Untuk detail tentang ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/id/java/convert-powerpoint-to-tiff/).
* Untuk detail tentang rendering slide ke gambar, lihat [Convert Presentation Slides to Images](https://docs.aspose.com/slides/id/java/convert-slide/).