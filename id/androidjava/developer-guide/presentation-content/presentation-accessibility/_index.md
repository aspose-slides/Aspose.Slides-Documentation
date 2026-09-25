---
title: Kelola Aksesibilitas Presentasi di Android
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/androidjava/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- teks alternatif
- judul teks alternatif
- deskripsi teks alternatif
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Android melalui Java membantu mengotomatiskan pemeriksaan aksesibilitas presentasi dalam file PPT, PPTX, dan ODP—meningkatkan pengalaman pembaca layar dan meningkatkan kepatuhan."
---
## **Pendahuluan**

Teks alternatif membantu orang yang menggunakan teknologi bantu memahami makna gambar, diagram, dan bentuk informatif lainnya. Artikel ini menjelaskan cara membaca dan memperbarui judul serta deskripsi teks alternatif dengan Aspose.Slides for Android melalui Java, membedakan deskripsi aksesibilitas dari nama bentuk yang digunakan dalam kode, dan memeriksa apakah sebuah bentuk ditandai sebagai dekoratif.

Fitur-fitur ini mendukung aksesibilitas presentasi, namun tidak menjaminkannya. Urutan membaca, kontras warna, keterbacaan teks, dan persyaratan aksesibilitas lainnya juga perlu ditinjau.

## **Kelola Judul dan Deskripsi Teks Alternatif**

Gunakan teks alternatif untuk menjelaskan makna gambar, diagram, dan bentuk informatif lainnya kepada orang yang tidak dapat melihatnya. Metode dan konten berikut memiliki tujuan yang berbeda:

| Metode atau konten | Tujuan |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Judul singkat untuk deskripsi alternatif. |
| [getAlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Deskripsi bermakna tentang konten atau tujuan bentuk dalam konteks slide. |
| [getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) | Nama bentuk, yang dapat digunakan kode untuk menemukan bentuk tertentu dalam presentasi. |
| Teks terlihat | Konten yang ditampilkan pada slide, seperti teks pada bentuk atau judul dan label pada diagram. Memperbarui teks alternatif tidak mengubah konten ini. |

Ketika sebuah presentasi digunakan kembali sebagai templat, kode dapat menemukan sebuah bentuk berdasarkan nama yang dikembalikan oleh [getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) sebelum memperbaruinya. Nama ini memiliki tujuan yang berbeda dari teks alternatif, yang menjelaskan apa yang disampaikan visual kepada pembaca. Pencarian berdasarkan nama memungkinkan penulis memperbaiki atau menerjemahkan deskripsi tanpa mengubah cara kode menemukan bentuk. Nama dapat diedit dan tidak dijamin unik, jadi pastikan nama tersebut cocok dengan bentuk yang dimaksud; lihat [Identify and Find Shapes](/slides/id/androidjava/shape-manipulations/#identify-and-find-shapes).

Contoh berikut memerlukan `input.pptx` dengan gambar pintu masuk kantor sebagai bentuk pertama pada slide pertama. Gambar tersebut tidak boleh ditandai sebagai dekoratif. Contoh ini membaca dan mencetak judul serta deskripsi teks alternatifnya saat ini, memperbarui kedua nilai tersebut, dan menyimpan presentasi sebagai `output.pptx`. Sesuaikan kata-katanya dengan gambar sebenarnya dan informasi yang disampaikannya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menambahkan teks alternatif saja tidak menjamin aksesibilitas presentasi atau kepatuhan terhadap standar aksesibilitas. Tinjau deskripsi untuk akurasi dan relevansi, dan juga periksa urutan membaca, kontras warna, teks yang dapat dibaca, serta persyaratan aksesibilitas lainnya. Visual informatif tidak boleh ditandai sebagai dekoratif; bagian berikutnya menunjukkan cara memeriksa [isDecorative](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Tandai sebagai Dekoratif**

Tandai sebagai dekoratif menandai visual yang semata-mata bersifat ornamental sehingga pembaca layar melewatinya, mengurangi kebisingan dan menjaga fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan spacer—tidak pernah pada diagram, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan flag ini untuk deteksi dan validasi, memungkinkan pemeriksaan serta pembersihan aksesibilitas secara otomatis.

![Mark as Decorative](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **Tanya Jawab**

**Apa yang harus saya masukkan dalam judul dan deskripsi teks alternatif?**

Gunakan judul singkat untuk mengidentifikasi subjek dan deskripsi untuk menjelaskan informasi yang disampaikan visual dalam konteks slide. Untuk diagram, jelaskan tren atau perbandingan yang relevan daripada hanya menyebut "diagram."

**Haruskah saya menggunakan teks alternatif untuk menemukan bentuk dalam templat?**

Lebih disarankan menemukan bentuk berdasarkan nama yang dikembalikan oleh [getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) dan memastikan bahwa itu adalah bentuk yang diharapkan. Teks alternatif dapat diedit atau diterjemahkan, yang dapat memutus kode yang mencari deskripsi tepat; lihat [Identify and Find Shapes](/slides/id/androidjava/shape-manipulations/).

**Kapan sebuah bentuk harus ditandai sebagai dekoratif?**

Gunakan flag dekoratif untuk visual yang tidak menambah informasi, seperti hiasan ornamental. Gambar dan diagram yang menyampaikan makna memerlukan deskripsi yang sesuai.

**Apakah menambahkan teks alternatif membuat sebuah presentasi sepenuhnya dapat diakses?**

Tidak. Teks alternatif hanya mencakup sebagian dari aksesibilitas. Selain itu, tinjau urutan membaca, kontras warna, keterbacaan teks, dan persyaratan lain yang berlaku; mengatur properti ini saja tidak memastikan kepatuhan.