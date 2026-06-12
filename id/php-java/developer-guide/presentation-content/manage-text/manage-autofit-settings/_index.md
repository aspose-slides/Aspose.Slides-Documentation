---
title: Tingkatkan Presentasi Anda dengan AutoFit di PHP
linktitle: Pengaturan Autofit
type: docs
weight: 30
url: /id/php-java/manage-autofit-settings/
keywords:
- kotak teks
- autofit
- tidak autofit
- sesuaikan teks
- perkecil teks
- bungkus teks
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola pengaturan AutoFit di Aspose.Slides untuk PHP guna mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, ketika Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fix text** untuk kotak teks—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya. 

![kotakteks-di-powerpoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—meningkatkan tinggi—untuk memungkinkan menampung lebih banyak teks. 
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—mengurangi tinggi—untuk menghilangkan ruang berlebih. 

Di PowerPoint, terdapat 4 parameter atau opsi penting yang mengontrol perilaku autofit untuk kotak teks: 

* **Nonaktifkan Autofit**
* **Kecilkan teks saat meluap**
* **Ubah ukuran bentuk agar sesuai teks**
* **Bungkus teks dalam bentuk.**

![opsi-autofit-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java menyediakan opsi serupa—beberapa properti di bawah kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi.

## **Ubah Bentuk agar Sesuai Teks**

Jika Anda ingin teks dalam kotak selalu muat dalam kotak tersebut setelah perubahan teks, Anda harus menggunakan opsi **Resize shape to fix text**. Untuk menentukan pengaturan ini, setel properti [AutofitType](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat)) ke `Shape`.

![pengaturan-selalu-muat-powerpoint](alwaysfit-setting-powerpoint.png)

Kode PHP berikut menunjukkan cara menentukan bahwa teks harus selalu muat dalam kotaknya di presentasi PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (meningkatkan tinggi) untuk memastikan semua teks muat di dalamnya. Jika teks menjadi lebih pendek, hal sebaliknya terjadi. 

## **Tidak Autofit**

Jika Anda ingin kotak teks atau bentuk mempertahankan dimensinya apa pun perubahan teks yang terjadi, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, setel properti [AutofitType](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat)) ke `None`.

![pengaturan-tidak-autofit-powerpoint](donotautofit-setting-powerpoint.png)

Kode PHP berikut menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya di presentasi PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluap keluar. 

## **Kecilkan Teks saat Meluap**

Jika teks menjadi terlalu panjang untuk kotaknya, melalui opsi **Shrink text on overflow**, Anda dapat menentukan bahwa ukuran dan spasi teks harus dikurangi agar muat dalam kotak. Untuk menentukan pengaturan ini, setel properti [AutofitType](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat)) ke `Normal`.

![pengaturan-kecilkanteks-meluap-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Kode PHP berikut menunjukkan cara menentukan bahwa teks harus diperkecil saat meluap di presentasi PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Ketika opsi **Shrink text on overflow** digunakan, pengaturan hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya. 
{{% /alert %}}

## **Bungkus Teks**

Jika Anda ingin teks dalam bentuk dibungkus di dalam bentuk tersebut saat teks melewati batas bentuk (hanya lebar), Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, Anda harus menyetel properti [WrapText](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat#getWrapText--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/TextFrameFormat)) menjadi `true`.

Kode PHP berikut menunjukkan cara menggunakan pengaturan Wrap Text di presentasi PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Jika Anda menyetel properti `WrapText` menjadi `False` untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas melampaui batas bentuk dalam satu baris. 
{{% /alert %}}

## **FAQ**

**Apakah margin internal frame teks memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan diterapkan lebih awal—mengecilkan font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum menyesuaikan AutoFit.

**Bagaimana AutoFit berinteraksi dengan break baris manual dan lunak?**

Break paksa tetap berada di tempatnya, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus break yang tidak diperlukan sering mengurangi seberapa agresif AutoFit harus mengecilkan teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti ke font dengan metrik glif yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir dan pembungkusan baris. Setelah melakukan perubahan atau substitusi font apa pun, periksa kembali slide.