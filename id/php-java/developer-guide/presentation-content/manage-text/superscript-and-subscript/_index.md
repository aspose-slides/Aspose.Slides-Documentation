---
title: Mengelola Superscript dan Subscript dalam Presentasi Menggunakan PHP
linktitle: Superscript dan Subscript
type: docs
weight: 80
url: /id/php-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- menambahkan superscript
- menambahkan subscript
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Menguasai superscript dan subscript di Aspose.Slides untuk PHP melalui Java dan meningkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superscript dan subscript ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti rumus kimia, persamaan matematika, atau memberi anotasi konten dengan catatan kaki, opsi format khusus ini membantu menjaga kejelasan dan presisi. Dalam artikel ini, Anda akan mempelajari cara menerapkan gaya superscript dan subscript secara mulus serta memastikan hasil profesional di setiap slide.

## **Mengelola Teks Superscript dan Subscript**
Anda dapat menambahkan teks superscript dan subscript di dalam bagian paragraf mana pun. Untuk menambahkan teks Superscript atau Subscript dalam bingkai teks Aspose.Slides, harus menggunakan metode [**setEscapement**](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setEscapement) dari kelas [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/PortionFormat).

Properti ini mengembalikan atau mengatur teks superscript atau subscript (nilai dari -100% (subscript) hingga 100% (superscript)). Sebagai contoh:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) bertipe [Rectangle](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeType#Rectangle) ke slide.
- Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
- Bersihkan Paragraphs yang ada
- Buat objek paragraf baru untuk menampung teks superscript dan tambahkan ke koleksi IParagraphs dari [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).
- Buat objek portion baru
- Set properti Escapement untuk portion antara 0 hingga 100 untuk menambahkan superscript. (0 berarti tidak ada superscript)
- Set beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/Portion) lalu tambahkan ke koleksi portion pada paragraf.
- Buat objek paragraf baru untuk menampung teks subscript dan tambahkan ke koleksi IParagraphs dari ITextFrame.
- Buat objek portion baru
- Set properti Escapement untuk portion antara 0 hingga -100 untuk menambahkan subscript. (0 berarti tidak ada subscript)
- Set beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/Portion) lalu tambahkan ke koleksi portion pada paragraf.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini.

```php
  # Membuat instance kelas Presentation yang merepresentasikan PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide
    $slide = $pres->getSlides()->get_Item(0);
    # Buat kotak teks
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Buat paragraf untuk teks superscript
    $superPar = new Paragraph();
    # Buat portion dengan teks biasa
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Buat portion dengan teks superscript
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Buat paragraf untuk teks subscript
    $paragraph2 = new Paragraph();
    # Buat portion dengan teks biasa
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Buat portion dengan teks subscript
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Tambahkan paragraf ke kotak teks
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah superscript dan subscript akan dipertahankan saat mengekspor ke PDF atau format lainnya?**

Ya, Aspose.Slides secara tepat mempertahankan format superscript dan subscript saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Format khusus tetap utuh di semua file output.

**Apakah superscript dan subscript dapat digabungkan dengan gaya format lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu portion teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan sekaligus menerapkan superscript atau subscript dengan mengonfigurasi properti terkait di [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/).

**Apakah format superscript dan subscript berfungsi untuk teks di dalam tabel, diagram, atau SmartArt?**

Ya, Aspose.Slides mendukung format di dalam sebagian besar objek, termasuk tabel dan elemen diagram. Saat bekerja dengan SmartArt, Anda perlu mengakses elemen yang sesuai (seperti [SmartArtNode](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnode/)) dan kontainer teksnya, lalu mengonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/) dengan cara serupa.