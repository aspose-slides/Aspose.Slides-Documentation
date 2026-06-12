---
title: Kelola Placeholder Presentasi di PHP
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/php-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder bagan
- teks prompt
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola placeholder dengan mudah di Aspose.Slides untuk PHP via Java: ganti teks, sesuaikan prompt, dan atur transparansi gambar dalam PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola placeholder presentasi secara programatis. Artikel ini menjelaskan cara menemukan placeholder pada slide dan mengubah teksnya, menetapkan teks prompt khusus untuk tata letak placeholder, serta menyesuaikan transparansi gambar yang digunakan sebagai latar belakang placeholder. Artikel ini juga menyertakan FAQ singkat yang menjelaskan perbedaan antara placeholder dasar dan bentuk lokal, menjelaskan bagaimana perubahan placeholder dapat diterapkan melalui tata letak atau master, serta mengarahkan ke pengelolaan placeholder header dan footer.

## **Ubah Teks dalam Placeholder**
Dengan menggunakan [Aspose.Slides for PHP via Java](/slides/id/php-java/), Anda dapat menemukan dan memodifikasi placeholder pada slide dalam presentasi. Aspose.Slides memungkinkan Anda melakukan perubahan pada teks dalam sebuah placeholder.

**Prasyarat**: Anda memerlukan sebuah presentasi yang berisi placeholder. Anda dapat membuat presentasi semacam itu menggunakan aplikasi Microsoft PowerPoint standar.

1. Buat instance dari kelas [`Presentation`](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation). dan berikan presentasi sebagai argumen.
2. Dapatkan referensi slide melalui indeksnya.
3. Iterasi melalui shape untuk menemukan placeholder.
4. Lakukan typecast pada shape placeholder menjadi [`AutoShape`](https://reference.aspose.com/slides/id/php-java/aspose.slides/AutoShape) dan ubah teks menggunakan [`TextFrame`](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrame) yang terkait dengan [`AutoShape`](https://reference.aspose.com/slides/id/php-java/aspose.slides/AutoShape).
5. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara mengubah teks dalam placeholder:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Iterasi melalui shape untuk menemukan placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Mengubah teks pada setiap placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Menyimpan presentasi ke disk
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Teks Prompt dalam Placeholder**
Tata letak standar dan pra-bangun berisi teks prompt placeholder seperti ***Click to add a title*** atau ***Click to add a subtitle***. Dengan menggunakan Aspose.Slides, Anda dapat menyisipkan teks prompt pilihan Anda ke dalam tata letak placeholder.

Kode PHP ini menunjukkan cara mengatur teks prompt dalam placeholder:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Mengiterasi slide
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint menampilkan "Click to add title"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Menambahkan subtitle
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Transparansi Gambar Placeholder**

Aspose.Slides memungkinkan Anda mengatur transparansi gambar latar belakang dalam placeholder teks. Dengan menyesuaikan transparansi gambar dalam bingkai tersebut, Anda dapat membuat teks atau gambar lebih menonjol (tergantung pada warna teks dan gambar).

Kode PHP ini menunjukkan cara mengatur transparansi untuk latar belakang gambar (di dalam shape):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apa itu placeholder dasar, dan bagaimana perbedaannya dengan shape lokal pada slide?**

Placeholder dasar adalah shape asli pada tata letak atau master yang diwarisi oleh shape slide—tipe, posisi, dan sebagian formatnya berasal dari placeholder tersebut. Shape lokal bersifat independen; jika tidak ada placeholder dasar, pewarisan tidak berlaku.

**Bagaimana saya dapat memperbarui semua judul atau keterangan di seluruh presentasi tanpa harus iterasi pada setiap slide?**

Edit placeholder yang bersangkutan pada tata letak atau master. Slide yang berbasis pada tata letak/master tersebut secara otomatis akan mewarisi perubahan.

**Bagaimana saya mengontrol placeholder header/footer standar—tanggal & waktu, nomor slide, dan teks footer?**

Gunakan pengelola HeaderFooter pada ruang lingkup yang sesuai (slide normal, tata letak, master, catatan/handout) untuk mengaktifkan atau menonaktifkan placeholder tersebut serta mengatur isinya.