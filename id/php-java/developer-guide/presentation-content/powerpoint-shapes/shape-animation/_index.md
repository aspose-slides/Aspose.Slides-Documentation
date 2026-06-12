---
title: Terapkan Animasi Bentuk dalam Presentasi Menggunakan PHP
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/php-java/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk teranimasi
- teks teranimasi
- tambahkan animasi
- dapatkan animasi
- ekstrak animasi
- tambahkan efek
- dapatkan efek
- ekstrak efek
- suara efek
- terapkan animasi
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Tampil menonjol!"
---
## **Pengenalan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [bagan](https://docs.aspose.com/slides/id/php-java/animated-charts/). Mereka memberi kehidupan pada presentasi atau komponennya.

## **Mengapa Menggunakan Animasi dalam Presentasi?**

* mengontrol alur informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi audiens Anda
* mempermudah konten untuk dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton ke bagian penting dalam presentasi

PowerPoint menyediakan banyak opsi dan alat untuk animasi serta efek animasi di kategori **entrance**, **exit**, **emphasis**, dan **motion paths**.

## **Animasi di Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda butuhkan untuk bekerja dengan animasi di bawah namespace `Aspose.Slides.Animation`,
* Aspose.Slides menyediakan lebih dari **150 efek animasi** di bawah enumerasi [EffectType](https://reference.aspose.com/slides/id/php-java/aspose.slides/effecttype). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Menerapkan Animasi ke TextBox**

Aspose.Slides untuk PHP via Java memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang.
4. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#getTextFrame) milik `AutoShape`.
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
7. Gunakan metode `TextAnimation.setBuildType` dan nilai dari enumerasi `BuildType`.
8. Tulis presentasi ke disk sebagai file PPTX.

Kode PHP ini menunjukkan cara menerapkan efek `Fade` ke AutoShape dan mengatur animasi teks ke nilai *By 1st Level Paragraphs*:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Menambahkan AutoShape baru dengan teks
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Mendapatkan urutan utama slide.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Menambahkan efek animasi Fade ke shape
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Menganimasi teks shape berdasarkan paragraf tingkat pertama
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Menyimpan file PPTX ke disk
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Selain menerapkan animasi pada teks, Anda juga dapat menerapkan animasi pada sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/). Lihat [**Animated Text**](/slides/id/php-java/animated-text/).

{{% /alert %}} 

## **Menerapkan Animasi ke PictureFrame**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe) pada slide.
4. Dapatkan urutan utama efek.
5. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe).
6. Tulis presentasi ke disk sebagai file PPTX.

Kode PHP ini menunjukkan cara menerapkan efek `Fly` ke sebuah picture frame:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi.
  $pres = new Presentation();
  try {
    # Muat Gambar yang akan ditambahkan ke koleksi gambar presentasi
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan frame gambar ke slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Mendapatkan urutan utama slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Menambahkan efek animasi Fly dari Kiri ke frame gambar
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Menyimpan file PPTX ke disk
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menerapkan Animasi ke Shape**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang.
4. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk bevel (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada shape bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Tulis presentasi ke disk sebagai file PPTX.

Kode PHP ini menunjukkan cara menerapkan efek `PathFootball` (path football) ke sebuah shape:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Membuat efek PathFootball untuk shape yang ada dari awal.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Menambahkan efek animasi PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Membuat semacam "button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Membuat urutan efek untuk tombol ini.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Membuat path pengguna khusus. Objek kita akan dipindahkan hanya setelah tombol diklik.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Menambahkan perintah pergerakan karena path yang dibuat kosong.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Menulis file PPTX ke disk
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mendapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh-contoh berikut menunjukkan cara menggunakan metode `getEffectsByShape` dari kelas [Sequence](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Mendapatkan efek animasi yang diterapkan pada shape pada slide normal**

Sebelumnya, Anda mempelajari cara menambahkan efek animasi ke shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama pada slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Mendapatkan urutan animasi utama slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Mendapatkan shape pertama pada slide pertama.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Mendapatkan efek animasi yang diterapkan pada shape.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Contoh 2: Mendapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada slide tata letak dan/atau slide master, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek shape akan diputar selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Misalkan kita memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Slide shape animation effect](slide-shape-animation.png)

Anggap juga bahwa efek **Split** diterapkan pada placeholder footer pada slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer pada slide **master**.

![Master shape animation effect](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `getBasePlaceholder` dari kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder yang berada pada slide layout dan master.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Dapatkan efek animasi dari shape pada slide normal.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Dapatkan efek animasi dari placeholder pada slide tata letak.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Dapatkan efek animasi dari placeholder pada slide master.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Bawah
Type: 134, subtype: 45            // Split, VertikalMasuk
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Mengubah Metode Penjadwalan Efek Animasi**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengubah properti Timing dari sebuah efek animasi.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Berikut adalah korespondensi antara Timing PowerPoint dan properti [Effect Timing](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#getTiming):

- Daftar drop-down **Start** pada PowerPoint Timing sesuai dengan metode [Timing::getTriggerType](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/#getTriggerType).
- **Duration** pada PowerPoint Timing sesuai dengan metode [Timing::getDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/#getDuration). Durasi sebuah animasi (dalam detik) adalah total waktu yang dibutuhkan animasi untuk menyelesaikan satu siklus.
- **Delay** pada PowerPoint Timing sesuai dengan metode [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/#getTriggerDelayTime).

Berikut cara mengubah properti Effect Timing:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Tetapkan nilai baru yang Anda butuhkan menggunakan metode [Effect::getTiming](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#getTiming).
3. Simpan file PPTX yang telah dimodifikasi.

Kode PHP ini mendemonstrasikan operasi tersebut:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Mendapatkan urutan utama slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Mendapatkan efek pertama dari urutan utama.
    $effect = $sequence->get_Item(0);
    # Mengubah TriggerType efek menjadi mulai saat diklik
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Mengubah Durasi efek
    $effect->getTiming()->setDuration(3.0);
    # Mengubah TriggerDelayTime efek
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Menyimpan file PPTX ke disk
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan metode-metode ini untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Menambahkan Suara Efek Animasi**

Kode PHP ini menunjukkan cara menambahkan suara efek animasi dan menghentikannya ketika efek berikutnya dimulai:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Menambahkan audio ke koleksi audio presentasi
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Mendapatkan urutan utama slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Mendapatkan efek pertama dari urutan utama
    $firstEffect = $sequence->get_Item(0);
    # Memeriksa efek untuk "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Menambahkan suara untuk efek pertama
      $firstEffect->setSound($effectSound);
    }
    # Mendapatkan urutan interaktif pertama slide.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Mengatur flag "Stop previous sound" pada efek
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Menulis file PPTX ke disk
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Mengekstrak Suara Efek Animasi**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Dapatkan urutan utama efek.
4. Ekstrak [setSound(IAudio value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) yang tertanam pada setiap efek animasi.

Kode PHP ini menunjukkan cara mengekstrak suara yang tertanam dalam sebuah efek animasi:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Mendapatkan urutan utama slide.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Mengekstrak suara efek dalam array byte
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Setelah Animasi**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Daftar drop-down **After animation** pada PowerPoint Effect sesuai dengan metode-metode berikut:

- Metode [setAfterAnimationType(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setAfterAnimationType) yang menjelaskan tipe After animation:
  * PowerPoint **More Colors** sesuai dengan tipe [AfterAnimationType::Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** sesuai dengan tipe [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipe after animation default);
  * PowerPoint **Hide After Animation** sesuai dengan tipe [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** sesuai dengan tipe [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Metode [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setAfterAnimationColor) yang menentukan format warna after animation. Metode ini bekerja bersama dengan tipe [AfterAnimationType::Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/#Color). Jika Anda mengubah tipe ke yang lain, warna after animation akan dihapus.

Kode PHP ini menunjukkan cara mengubah efek after animation:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Mendapatkan efek pertama dari urutan utama
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Mengubah tipe after animation menjadi Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Menetapkan warna after animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Menulis file PPTX ke disk
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animasi Teks**

Aspose.Slides menyediakan metode-metode ini untuk memungkinkan Anda bekerja dengan blok *Animate text* dari sebuah efek animasi:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setAnimateTextType) yang menjelaskan tipe animate text dari efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/id/php-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  - Per kata ([AnimateTextType::ByWord](https://reference.aspose.com/slides/id/php-java/aspose.slides/animatetexttype/#ByWord) type)
  - Per huruf ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/id/php-java/aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setDelayBetweenTextParts) mengatur jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara Anda dapat mengubah properti Effect Animate text:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Gunakan metode [setBuildType(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/textanimation/#setBuildType) dan nilai [BuildType::AsOneObject](https://reference.aspose.com/slides/id/php-java/aspose.slides/buildtype/#AsOneObject) untuk mematikan mode animasi *By Paragraphs*.
3. Tetapkan nilai baru menggunakan metode [setAnimateTextType(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setAnimateTextType) dan [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Simpan file PPTX yang telah dimodifikasi.

Kode PHP ini mendemonstrasikan operasi tersebut:

```php
  # Membuat instance kelas presentasi yang mewakili sebuah file presentasi.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Mendapatkan efek pertama dari urutan utama
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Mengubah tipe animasi teks efek menjadi "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Mengubah tipe animasi teks efek menjadi "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Mengatur jeda antar kata menjadi 20% dari durasi efek
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Menulis file PPTX ke disk
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat memastikan animasi tetap terjaga saat mempublikasikan presentasi ke web?**

[Export ke HTML5](/slides/id/php-java/export-to-html5/) dan aktifkan [opsi](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/) yang mengatur animasi [shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/setanimateshapes/) dan [transition](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/setanimatetransitions/). HTML biasa tidak memutar animasi slide, sedangkan HTML5 melakukannya.

**Bagaimana mengubah z-order (urutan lapisan) shape memengaruhi animasi?**

Urutan animasi dan urutan gambar bersifat independen: sebuah efek mengontrol penjadwalan dan tipe muncul/hilang, sementara [z-order](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getzorderposition/) menentukan apa yang menutupi apa. Hasil visual ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model efek-dan-shape Aspose.Slides mengikuti logika yang sama.)

**Apakah ada batasan saat mengonversi animasi ke video untuk efek tertentu?**

Secara umum, [animasi didukung](/slides/id/php-java/convert-powerpoint-to-video/), namun kasus yang jarang atau efek tertentu mungkin ditampilkan secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan serta dengan versi library.