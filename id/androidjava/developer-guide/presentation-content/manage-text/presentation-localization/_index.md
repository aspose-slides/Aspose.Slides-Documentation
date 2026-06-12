---
title: Otomatisasi Lokalisasi Presentasi di Android
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/androidjava/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- ID bahasa
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Otomatisasi lokalisasi slide PowerPoint dan OpenDocument dalam Java dengan Aspose.Slides untuk Android, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menetapkan `LanguageId` untuk teks dalam presentasi dengan menggunakan Aspose.Slides. Ini menunjukkan cara membuka presentasi, menambahkan bentuk dengan teks, menetapkan pengenal bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Teks Presentasi dan Bentuk**

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) tipe [Rectangle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeType#Rectangle) ke slide.
- Tambahkan beberapa teks ke TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) pada teks.
- Tulis presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas ditunjukkan di bawah dalam contoh.

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

**Apakah ID bahasa memicu terjemahan teks otomatis?**

Tidak. [Language ID](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan tata bahasa, tetapi tidak menerjemahkan atau mengubah isi teks. Itu adalah metadata yang dipahami PowerPoint untuk pemeriksaan.

**Apakah ID bahasa memengaruhi hyphenation dan pemenggalan baris saat rendering?**

Di Aspose.Slides, [language ID](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) untuk pemeriksaan. Kualitas pemenggalan kata dan pembungkus baris terutama bergantung pada ketersediaan [proper fonts](/slides/id/androidjava/powerpoint-fonts/) dan pengaturan tata letak/pemenggalan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [font substitution rules](/slides/id/androidjava/font-substitution/), dan/atau [embed fonts](/slides/id/androidjava/embedded-font/) ke dalam presentasi.

**Apakah saya dapat mengatur bahasa berbeda dalam satu paragraf?**

Ya. [Language ID](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan pemeriksaan yang berbeda.