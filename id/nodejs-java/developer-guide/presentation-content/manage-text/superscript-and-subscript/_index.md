---
title: Kelola Superskrip dan Subskrip dalam Presentasi Menggunakan JavaScript
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/nodejs-java/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambah superskrip
- tambah subskrip
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai superskrip dan subskrip di Aspose.Slides untuk Node.js via Java dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti formula kimia, persamaan matematika, atau memberi anotasi konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketepatan. Dalam artikel ini, Anda akan mempelajari cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil profesional pada setiap slide.

## **Mengelola Teks Superskrip dan Subskrip**

Anda dapat menambahkan teks superskrip dan subskrip di dalam bagian paragraf mana pun. Untuk menambahkan teks Superskrip atau Subskrip dalam frame teks Aspose.Slides, harus menggunakan metode [**setEscapement**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) dari kelas [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PortionFormat).

Properti ini mengembalikan atau mengatur teks superskrip atau subskrip (nilai dari -100 % (subskrip) hingga 100 % (superskrip)). Misalnya:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) dengan tipe [Rectangle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeType#Rectangle) ke slide.
- Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame) yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape).
- Hapus Paragraph yang ada.
- Buat objek paragraf baru untuk menampung teks superskrip dan tambahkan ke koleksi [Paragraphs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame#getParagraphs--) pada [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame).
- Buat objek portion baru.
- Atur properti Escapement untuk portion antara 0 hingga 100 untuk menambahkan superskrip. (0 berarti tidak ada superskrip)
- Tetapkan teks untuk [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion) lalu tambahkan ke koleksi portion paragraf.
- Buat objek paragraf baru untuk menampung teks subskrip dan tambahkan ke koleksi IParagraphs pada ITextFrame.
- Buat objek portion baru.
- Atur properti Escapement untuk portion antara 0 hingga -100 untuk menambahkan subskrip. (0 berarti tidak ada subskrip)
- Tetapkan teks untuk [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion) lalu tambahkan ke koleksi portion paragraf.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah ini.

```javascript
// Instansiasi kelas Presentation yang merepresentasikan sebuah PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ambil slide
    var slide = pres.getSlides().get_Item(0);
    // Buat kotak teks
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Buat paragraf untuk teks superskrip
    var superPar = new aspose.slides.Paragraph();
    // Buat portion dengan teks biasa
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Buat portion dengan teks superskrip
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Buat paragraf untuk teks subskrip
    var paragraph2 = new aspose.slides.Paragraph();
    // Buat portion dengan teks biasa
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Buat portion dengan teks subskrip
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Tambahkan paragraf ke kotak teks
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah superskrip dan subskrip akan dipertahankan saat mengekspor ke PDF atau format lain?**

Ya, Aspose.Slides secara tepat mempertahankan pemformatan superskrip dan subskrip saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh dalam semua file output.

**Apakah superskrip dan subskrip dapat digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan sekaligus menerapkan superskrip atau subskrip dengan mengonfigurasi properti yang sesuai pada [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip bekerja untuk teks di dalam tabel, grafik, atau SmartArt?**

Ya, Aspose.Slides mendukung pemformatan di dalam sebagian besar objek, termasuk elemen tabel dan grafik. Saat bekerja dengan SmartArt, Anda perlu mengakses elemen yang tepat (seperti [SmartArtNode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartnode/)) dan kontainer teksnya, kemudian mengonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/) dengan cara yang serupa.