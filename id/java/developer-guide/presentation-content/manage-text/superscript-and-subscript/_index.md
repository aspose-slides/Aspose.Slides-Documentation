---
title: Kelola Superskrip dan Subskrip dalam Presentasi Menggunakan Java
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/java/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambahkan superskrip
- tambahkan subskrip
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Menguasai superskrip dan subskrip di Aspose.Slides untuk Java dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyorot rumus kimia, persamaan matematika, atau memberi anotasi pada konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketelitian. Pada artikel ini, Anda akan mempelajari cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil yang profesional di setiap slide.

## **Kelola Teks Superskrip dan Subskrip**
Anda dapat menambahkan teks superskrip dan subskrip di dalam bagian paragraf apa saja. Untuk menambahkan teks Superskrip atau Subskrip dalam bingkai teks Aspose.Slides, harus menggunakan metode [**setEscapement**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) dari kelas [PortionFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/PortionFormat).

Properti ini mengembalikan atau mengatur teks superskrip atau subskrip (nilai dari -100% (subskrip) hingga 100% (superskrip)). Misalnya:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) bertipe [Rectangle](https://reference.aspose.com/slides/id/java/com.aspose.slides/ShapeType#Rectangle) ke slide.
- Akses [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrame) yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape).
- Bersihkan Paragraph yang ada
- Buat objek paragraf baru untuk menampung teks superskrip dan tambahkan ke [koleksi IParagraphs](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrame#getParagraphs--) milik [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrame).
- Buat objek portion baru
- Atur properti Escapement untuk portion antara 0 hingga 100 untuk menambahkan superskrip. (0 berarti tidak ada superskrip)
- Setel beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/Portion) dan kemudian tambahkan ke koleksi portion pada paragraf.
- Buat objek paragraf baru untuk menampung teks subskrip dan tambahkan ke koleksi IParagraphs pada ITextFrame.
- Buat objek portion baru
- Atur properti Escapement untuk portion antara 0 hingga -100 untuk menambahkan subskrip. (0 berarti tidak ada subskrip)
- Setel beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/Portion) dan kemudian tambahkan ke koleksi portion pada paragraf.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini.

```java
// Instansiasi kelas Presentation yang mewakili sebuah PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Buat kotak teks
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Buat paragraf untuk teks superskrip
    IParagraph superPar = new Paragraph();

    // Buat bagian dengan teks biasa
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Buat bagian dengan teks superskrip
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Buat paragraf untuk teks subskrip
    IParagraph paragraph2 = new Paragraph();

    // Buat bagian dengan teks biasa
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Buat bagian dengan teks subskrip
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

**Apakah superskrip dan subskrip akan dipertahankan saat mengekspor ke PDF atau format lain?**

Ya, Aspose.Slides dengan tepat mempertahankan pemformatan superskrip dan subskrip saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh dalam semua berkas output.

**Apakah superskrip dan subskrip dapat digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan sekaligus menerapkan superskrip atau subskrip dengan mengonfigurasi properti yang bersesuaian pada [PortionFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip berfungsi untuk teks di dalam tabel, bagan, atau SmartArt?**

Ya, Aspose.Slides mendukung pemformatan di dalam kebanyakan objek, termasuk tabel dan elemen bagan. Saat bekerja dengan SmartArt, Anda perlu mengakses elemen yang tepat (seperti [SmartArtNode](https://reference.aspose.com/slides/id/java/com.aspose.slides/smartartnode/)) dan kontainer teksnya, lalu mengonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/portionformat/) dengan cara yang serupa.