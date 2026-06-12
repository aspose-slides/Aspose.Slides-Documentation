---
title: "Kelola Tema Presentasi di PHP"
linktitle: "Tema Presentasi"
type: docs
weight: 10
url: /id/php-java/presentation-theme/
keywords:
- "Tema PowerPoint"
- "Tema presentasi"
- "Tema slide"
- "Atur tema"
- "Ubah tema"
- "Kelola tema"
- "Warna tema"
- "Palet tambahan"
- "Font tema"
- "Gaya tema"
- "Efek tema"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "PHP"
- "Aspose.Slides"
description: "Kelola tema presentasi utama di Aspose.Slides untuk PHP melalui Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih sekumpulan elemen visual tertentu beserta propertinya.

Di PowerPoint, sebuah tema terdiri dari warna, [font](/slides/id/php-java/powerpoint-fonts/), [gaya latar belakang](/slides/id/php-java/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan sekumpulan warna tertentu untuk elemen yang berbeda pada slide. Jika Anda tidak menyukai warna-warna tersebut, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai-nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/SchemeColor).

Kode PHP berikut menunjukkan cara mengubah warna aksen untuk sebuah tema:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Anda dapat menentukan nilai efektif warna yang dihasilkan dengan cara ini:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Untuk lebih menunjukkan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) kepadanya. Kemudian kami mengubah warna dalam tema:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Warna baru diterapkan secara otomatis pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Saat Anda menerapkan transformasi luminansi pada warna tema utama(1), warna-warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mendapatkan warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1** - Warna tema utama  

**2** - Warna dari palet tambahan.

Kode PHP berikut mendemonstrasikan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan dalam bentuk:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Aksen 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Aksen 4, Lebih Terang 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Aksen 4, Lebih Terang 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Aksen 4, Lebih Terang 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Aksen 4, Lebih Gelap 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Aksen 4, Lebih Gelap 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Pemetaan `SchemeColor` ke Warna `ColorScheme`**

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai-nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation::getMasterTheme()::getColorScheme()` mengembalikan [ColorScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/colorscheme/), yang menampilkan warna yang sesuai sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai ini merujuk ke slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanya nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office yang lebih lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI yang lebih baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lain, Aspose.Slides menggunakan pengenal khusus ini (mirip dengan yang digunakan dalam PowerPoint):

* **+mn-lt** - Font Tubuh Latin (Minor Latin Font)
* **+mj-lt** - Font Judul Latin (Major Latin Font)
* **+mn-ea** - Font Tubuh Asia Timur (Minor East Asian Font)
* **+mj-ea** - Font Tubuh Asia Timur (Major East Asian Font)

Kode PHP berikut menunjukkan cara menetapkan font Latin ke elemen tema:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Kode PHP berikut menunjukkan cara mengubah font tema presentasi:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Font di semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [font PowerPoint](/slides/id/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 dari 12 latar belakang tersebut yang disimpan dalam presentasi tipikal. 

![todo:image_alt_text](presentation-design_8.png)

Misalnya, setelah Anda menyimpan sebuah presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode PHP berikut untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Dengan menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme), Anda dapat menambahkan atau mengakses gaya latar belakang dalam tema PowerPoint.
{{% /alert %}} 

Kode PHP berikut menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Panduan Indeks**: 0 digunakan untuk tanpa isian. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [Latar Belakang PowerPoint](/slides/id/php-java/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap array gaya. Array tersebut digabung menjadi 3 efek ini: halus, sedang, dan intens. Misalnya, inilah hasil ketika efek diterapkan pada bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme#getEffectStyles--)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/FormatScheme), Anda dapat mengubah elemen dalam tema (lebih fleksibel dibandingkan opsi di PowerPoint).

Kode PHP berikut menunjukkan cara mengubah efek tema dengan mengubah bagian-bagian elemen:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Perubahan yang dihasilkan pada warna isi, tipe isi, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Apakah saya dapat menerapkan tema pada satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema pada tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sementara tetap mempertahankan tema master tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidethememanager/)).

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/php-java/clone-slides/) bersama dengan master-nya ke presentasi target. Ini mempertahankan master asli, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

**Bagaimana cara melihat nilai "effective" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan ["effective"](/slides/id/php-java/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti akhir yang telah diselesaikan setelah menerapkan master ditambah penimpaan lokal apa pun.