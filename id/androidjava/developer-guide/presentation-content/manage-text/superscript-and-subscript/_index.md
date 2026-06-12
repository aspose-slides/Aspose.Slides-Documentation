---
title: Kelola Superskrip dan Subskrip dalam Presentasi di Android
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/androidjava/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambahkan superskrip
- tambahkan subskrip
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kuasi superskrip dan subskrip di Aspose.Slides untuk Android via Java dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Ringkasan**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti rumus kimia, persamaan matematika, atau memberi anotasi konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketelitian. Pada artikel ini, Anda akan belajar cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil profesional di setiap slide.

## **Kelola Teks Superskrip dan Subskrip**
Anda dapat menambahkan teks superskrip dan subskrip di dalam bagian paragraf apa pun. Untuk menambahkan teks Superskrip atau Subskrip dalam bingkai teks Aspose.Slides, harus menggunakan metode [**setEscapement**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) dari kelas [PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PortionFormat).

Properti ini mengembalikan atau mengatur teks superskrip atau subskrip (nilai dari -100% (subskrip) hingga 100% (superskrip). Misalnya:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) bertipe [Rectangle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeType#Rectangle) ke slide.
- Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame) yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape).
- Hapus Paragraph yang ada
- Buat objek paragraf baru untuk menampung teks superskrip dan tambahkan ke [IParagraphs collection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) dari [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame).
- Buat objek portion baru
- Set properti Escapement untuk portion antara 0 hingga 100 untuk menambahkan superskrip. (0 berarti tidak ada superskrip)
- Set beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Portion) dan kemudian tambahkan ke koleksi portion pada paragraf.
- Buat objek paragraf baru untuk menampung teks subskrip dan tambahkan ke IParagraphs collection dari ITextFrame.
- Buat objek portion baru
- Set properti Escapement untuk portion antara 0 hingga -100 untuk menambahkan subskrip. (0 berarti tidak ada subskrip)
- Set beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Portion) dan kemudian tambahkan ke koleksi portion pada paragraf.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah ini.

```java
// Membuat instance kelas Presentation yang mewakili sebuah PPTX
Presentation pres = new Presentation();
try {
    // Ambil slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Buat kotak teks
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Buat paragraf untuk teks superskrip
    IParagraph superPar = new Paragraph();

    // Buat portion dengan teks biasa
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Buat portion dengan teks superskrip
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Buat paragraf untuk teks subskrip
    IParagraph paragraph2 = new Paragraph();

    // Buat portion dengan teks biasa
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Buat portion dengan teks subskrip
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Tambahkan paragraf ke kotak teks
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah superskrip dan subskrip tetap dipertahankan saat diekspor ke PDF atau format lain?**

Ya, Aspose.Slides secara tepat mempertahankan pemformatan superskrip dan subskrip saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh di semua file output.

**Apakah superskrip dan subskrip dapat digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan sekaligus menerapkan superskrip atau subskrip dengan mengatur properti yang sesuai di [PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip bekerja untuk teks di dalam tabel, diagram, atau SmartArt?**

Ya, Aspose.Slides mendukung pemformatan di dalam kebanyakan objek, termasuk tabel dan elemen diagram. Saat bekerja dengan SmartArt, Anda perlu mengakses elemen yang tepat (seperti [SmartArtNode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/smartartnode/)) dan kontainer teksnya, kemudian mengatur properti [PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portionformat/) dengan cara yang serupa.