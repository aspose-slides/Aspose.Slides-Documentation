---
title: Kelola Hyperlink Presentasi dalam PHP
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/php-java/manage-hyperlinks/
keywords:
- tambahkan URL
- tambahkan hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink yang dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java — tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Sebuah hyperlink adalah referensi ke sebuah objek, data, atau tempat dalam sesuatu. Berikut ini adalah hyperlink umum dalam Presentasi PowerPoint:

* Tautan ke situs web di dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides untuk PHP via Java memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi.

{{% alert color="primary" %}} 
Anda mungkin ingin mencoba editor PowerPoint online gratis dari Aspose, [editor PowerPoint online gratis.](https://products.aspose.app/slides/id/editor)
{{% /alert %}} 

## **Menambahkan Hyperlink URL**

### **Menambahkan Hyperlink URL ke Teks**

Kode PHP ini menunjukkan cara menambahkan hyperlink situs web ke teks:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Menambahkan Hyperlink URL ke Bentuk atau Bingkai**

Contoh kode ini menunjukkan cara menambahkan hyperlink situs web ke bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Menambahkan Hyperlink URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video.

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **gambar**:

```php
  $pres = new Presentation();
  try {
    # Menambahkan gambar ke presentasi
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Membuat bingkai gambar pada slide 1 berdasarkan gambar yang sebelumnya ditambahkan
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **file audio**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **video**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}} 
Anda mungkin ingin melihat *[Kelola OLE](/slides/id/php-java/manage-ole/)*.
{{% /alert %}}

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi.

Contoh kode ini menunjukkan cara membuat daftar isi dengan hyperlink:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memformat Hyperlink**

### **Warna**

Dengan metode [setColorSource](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/setcolorsource/) dalam kelas [Hyperlink](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/), Anda dapat mengatur warna untuk hyperlink dan juga mendapatkan informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan pada properti ini tidak berlaku untuk versi PowerPoint yang lebih lama.

Contoh kode ini mendemonstrasikan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Hyperlink dari Presentasi**

### **Menghapus Hyperlink dari Teks**

Kode PHP ini menunjukkan cara menghapus hyperlink dari teks dalam slide presentasi:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Menghapus Hyperlink dari Bentuk atau Bingkai**

Kode PHP ini menunjukkan cara menghapus hyperlink dari bentuk dalam slide presentasi:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hyperlink yang Dapat Diubah**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti-properti berikut:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke slide dan mengedit tooltip‑nya nanti:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Properti yang Didukung dalam IHyperlinkQueries**

Anda dapat mengakses [HyperlinkQueries](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/) dari presentasi, slide, atau teks yang memiliki hyperlink yang didefinisikan.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/) mendukung metode dan properti berikut:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal tidak hanya ke slide, tetapi ke “bagian” atau slide pertama dari sebuah bagian?**

Bagian dalam PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk “menavigasi ke sebuah bagian”, biasanya Anda menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan tersebut muncul pada slide anak dan dapat diklik selama presentasi.

**Apakah hyperlink akan tetap dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Pada [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/php-java/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [gambar](/slides/id/php-java/convert-powerpoint-to-png/) dan [video](/slides/id/php-java/convert-powerpoint-to-video/), kemampuan mengklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).