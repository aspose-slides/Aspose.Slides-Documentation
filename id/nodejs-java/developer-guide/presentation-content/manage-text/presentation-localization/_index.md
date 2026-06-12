---
title: Automasi Lokalisasi Presentasi di JavaScript
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/nodejs-java/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Automasi lokalisasi slide PowerPoint dan OpenDocument di JavaScript dengan Aspose.Slides, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menetapkan `LanguageId` untuk teks dalam sebuah presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan bentuk dengan teks, menetapkan pengenal bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Teks Presentasi dan Bentuk**

- Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) bertipe [Rectangle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeType#Rectangle) ke slide.
- Tambahkan teks ke TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) pada teks.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas ditunjukkan di bawah dalam contoh.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah Language ID memicu penerjemahan teks otomatis?**

Tidak. [setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan bukti tata bahasa, tetapi tidak menerjemahkan atau mengubah isi teks. Itu adalah metadata yang dipahami PowerPoint untuk proses bukti.

**Apakah Language ID memengaruhi pemenggalan kata dan pemutusan baris selama proses rendering?**

Di Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) digunakan untuk bukti. Kualitas hyphenation dan pembungkusan baris terutama bergantung pada ketersediaan [proper fonts](/slides/id/nodejs-java/powerpoint-fonts/) serta pengaturan tata letak/pemutusan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [font substitution rules](/slides/id/nodejs-java/font-substitution/), dan/atau [embed fonts](/slides/id/nodejs-java/embedded-font/) ke dalam presentasi.

**Bisakah saya mengatur bahasa yang berbeda dalam satu paragraf?**

Ya. [setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan bukti yang berbeda.