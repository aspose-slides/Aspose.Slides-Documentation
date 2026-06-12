---
title: Kelola Kontrol ActiveX dalam Presentasi Menggunakan PHP
linktitle: ActiveX
type: docs
weight: 80
url: /id/php-java/activex/
keywords:
- ActiveX
- kontrol ActiveX
- mengelola ActiveX
- menambahkan ActiveX
- memodifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk PHP melalui Java memanfaatkan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberikan pengembang kontrol yang kuat atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk PHP via Java memungkinkan Anda menambahkan dan mengelola kontrol ActiveX, tetapi kontrol tersebut agak lebih sulit dikelola dibandingkan bentuk presentasi biasa. Kami telah menambahkan dukungan untuk menambahkan kontrol Active Media Player di Aspose.Slides. Perhatikan bahwa kontrol ActiveX bukan bentuk; mereka bukan bagian dari presentasi's [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/). Mereka adalah bagian dari [ControlCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/controlcollection/) terpisah. Dalam topik ini, kami akan menunjukkan cara bekerja dengan mereka.

## **Menambahkan Kontrol ActiveX Media Player ke Slide**
Untuk menambahkan kontrol Media Player ActiveX, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan buat instance presentasi kosong.
2. Akses slide target dalam [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
3. Tambahkan kontrol Media Player ActiveX menggunakan metode [addControl](https://reference.aspose.com/slides/id/php-java/aspose.slides/controlcollection/addcontrol/) yang disediakan oleh [ControlCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/controlcollection/).
4. Akses kontrol Media Player ActiveX dan atur jalur video dengan menggunakan propertinya.
5. Simpan presentasi sebagai file PPTX.

Kode contoh ini, berdasarkan langkah-langkah di atas, menunjukkan cara menambahkan Kontrol ActiveX Media Player ke slide:

```php
  # Buat instance presentasi kosong
  $pres = new Presentation();
  try {
    # Menambahkan kontrol ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Akses kontrol ActiveX Media Player dan atur jalur video
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Simpan Presentasi
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memodifikasi Kontrol ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides untuk PHP via Java 7.1.0 dan versi yang lebih baru dilengkapi dengan komponen untuk mengelola kontrol ActiveX. Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya melalui properti-propertinya.

{{% /alert %}} 

Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah sederhana pada slide, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi yang berisi kontrol ActiveX.
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Akses kontrol ActiveX pada slide dengan mengakses [ControlCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/controlcollection/).
4. Akses kontrol ActiveX TextBox1 menggunakan objek [Control](https://reference.aspose.com/slides/id/php-java/aspose.slides/control/).
5. Ubah properti kontrol ActiveX TextBox1 yang meliputi teks, font, tinggi font, dan posisi bingkai.
6. Akses kontrol akses kedua yang disebut CommandButton1.
7. Ubah keterangan tombol, font, dan posisinya.
8. Geser posisi bingkai kontrol ActiveX.
9. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode contoh ini, berdasarkan langkah-langkah di atas, menunjukkan cara mengelola kontrol ActiveX sederhana: 

```php
  # Mengakses presentasi dengan kontrol ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Mengakses slide pertama dalam presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # mengubah teks TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Mengubah gambar substitusi. PowerPoint akan mengganti gambar ini selama aktivasi ActiveX,
      # jadi kadang diperbolehkan membiarkan gambar tidak berubah.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Mengubah keterangan Tombol
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Mengubah substitusi
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # memindahkan 100 poin ke bawah
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # menghapus kontrol
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan kembali jika kontrol tersebut tidak dapat dijalankan di runtime Java?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/memodifikasi properti serta bingkai mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam sebuah presentasi?**

Kontrol ActiveX adalah kontrol interaktif yang dikelola (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/php-java/manage-ole/) mengacu pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

**Apakah peristiwa ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya dijalankan di dalam PowerPoint pada Windows ketika keamanan memperbolehkannya. Perpustakaan tidak mengeksekusi VBA.