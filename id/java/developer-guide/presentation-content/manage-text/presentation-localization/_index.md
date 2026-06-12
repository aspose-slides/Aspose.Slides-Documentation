---
title: Otomatisasi Lokalisasi Presentasi dalam Java
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/java/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Otomatisasi lokalisasi slide PowerPoint dan OpenDocument dalam Java dengan Aspose.Slides, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengatur `LanguageId` untuk teks dalam presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan bentuk dengan teks, menetapkan pengenal bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Presentasi dan Teks Bentuk**
- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeks-nya.
- Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) tipe [Rectangle](https://reference.aspose.com/slides/id/java/com.aspose.slides/ShapeType#Rectangle) ke slide.
- Tambahkan beberapa teks ke TextFrame.
- [Menetapkan Language Id](https://reference.aspose.com/slides/id/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ke teks.
- Tuliskan presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas ditunjukkan di bawah ini dalam contoh.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah ID bahasa memicu terjemahan otomatis teks?**

Tidak. [Language ID](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan tata bahasa, tetapi tidak menerjemahkan atau mengubah isi teks. Itu adalah metadata yang dipahami PowerPoint untuk proofing.

**Apakah ID bahasa memengaruhi hyphenation dan pemenggalan baris selama rendering?**

Di Aspose.Slides, [language ID](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) digunakan untuk proofing. Kualitas hyphenation dan pembungkus baris terutama bergantung pada ketersediaan [font yang tepat](/slides/id/java/powerpoint-fonts/) serta pengaturan tata letak/pemenggalan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [aturan substitusi font](/slides/id/java/font-substitution/), dan/atau [embed font](/slides/id/java/embedded-font/) ke dalam presentasi.

**Apakah saya dapat menyetel bahasa yang berbeda dalam satu paragraf?**

Ya. [Language ID](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan proofing yang berbeda.