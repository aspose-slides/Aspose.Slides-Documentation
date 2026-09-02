---
title: Mengelola Tema Presentasi dalam PHP
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/php-java/presentation-theme/
keywords:
- Tema PowerPoint
- tema presentasi
- tema slide
- atur tema
- ubah tema
- kelola tema
- tema eksternal
- THMX
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola tema presentasi master di Aspose.Slides untuk PHP via Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan branding yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan kumpulan terkoordinasi warna, font, gaya latar belakang, isian, garis, dan efek. Objek yang sadar tema merujuk ke definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Sebuah presentasi juga dapat berisi penimpaan tema pada tingkatan yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterthememanager/), sementara layout atau slide individu dapat menimpa tema yang diwariskan melalui [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseoverridethememanager/). Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan layout, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian-bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/mastertheme/) mengekspos skema warna, skema font, dan skema format tema melalui [MasterTheme.getColorScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/mastertheme/) , dan [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/mastertheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang disimpan dalam tema:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Jika sebuah file menggunakan beberapa master, jangan menganggap bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan layout atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang sadar tema dapat merujuk ke warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang sesuai dalam [ColorScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/colorscheme/), semua objek yang masih merujuk ke warna tema tersebut diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak berubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat bentuk yang menggunakan `Accent4`, mengubah warna `Accent4` tema menjadi merah, menyimpan presentasi, membuka kembali, dan mencetak warna isian efektif:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Karena persegi tetap terhubung ke `Accent4`, warnanya menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak akan memengaruhi isian tersebut lagi.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/php-java/aspose.slides/colortransformoperation/).

![Warna tema utama dan warna lebih terang serta lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.

**2** - Varian lebih terang dan lebih gelap yang diproduksi dari warna tema utama.

Contoh berikut membuat enam persegi berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah nanti, warna yang telah ditransformasi akan dihitung ulang dari nilai `Accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `ColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [ColorScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/colorscheme/) mengekspose slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk judul dan satu set font minor untuk teks isi. Metode [FontScheme.getMajor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontscheme/) dan [FontScheme.getMinor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontscheme/) mengekspos set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Tubuh Latin (Minor Latin Font)
* `+mj-lt` - Font Judul Latin (Major Latin Font)
* `+mn-ea` - Font Tubuh Asia Timur (Minor East Asian Font)
* `+mj-ea` - Font Judul Asia Timur (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font Latin utama tema dan satu baris isi yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Judul mengikuti font utama dan teks isi mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font utama dan minor juga dapat berisi pemetaan font untuk sistem penulisan individual, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambahkan, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan masalah berbeda terkait tema.

### **Terapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya semua slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation::getMasters](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), yang direpresentasikan oleh [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/), dan berikan path file tema ke metode tersebut.

Metode melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master yang dipilih.
1. Menerapkan tema eksternal ke master baru.
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.
1. Mengembalikan [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide yang bergantung pada master pertama dan menyimpan presentasi:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxReadException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxreadexception/). Validasi path yang diberikan pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master yang dipilih yang akan dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar belakang, dan efek yang sadar tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan tingkat layout dan tingkat slide juga dapat mengambil prioritas atas nilai yang diwariskan dari master baru.

Tema dapat merujuk ke font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/php-java/custom-font/), atau konfigurasikan [font substitution](/slides/id/php-java/font-substitution/).

Ini adalah alur kerja tingkat master langsung: metode menerima path file `.thmx` dan tidak memerlukan pembuatan manual penimpaan tema tingkat slide atau layout.

### **Terapkan Tema Eksternal Berbeda dalam Presentasi Multi-Master**

Ketika master yang relevan tidak diketahui sebelumnya, dapatkan dari slide perwakilan melalui [Slide::getLayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/) dan [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap pemanggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke setiap grup:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Pemanggilan pertama memengaruhi hanya slide yang bergantung pada `$firstGroupMaster`, dan pemanggilan kedua memengaruhi hanya slide yang bergantung pada `$secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gaya.

### **Pertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke presentasi target dengan [MasterSlideCollection.addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/), lalu kloning slide dengan [SlideCollection.addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/) dan master yang dikloning. Ini membawa master, layout-nya, dan tema terkait bersama-sama.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Hanya mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang didorong tema.

### **Terapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan layoutnya saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/overridetheme/) , dan [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/overridetheme/) menyalin tiga komponen utama tema ke penimpaan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Ini mengubah tema yang digunakan oleh slide itu tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwariskan, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/overridetheme/).

### **Terapkan Penimpaan Tema ke Layout**

Penimpaan tingkat layout diterapkan ke slide yang menggunakan layout tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Gunakan tema tingkat master atau presentasi ketika banyak layout dan slide harus berbagi desain dasar yang sama, penimpaan layout ketika satu keluarga layout membutuhkan gaya berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/formatscheme/). PowerPoint dapat menyajikan lebih banyak pilihan latar belakang di UI-nya daripada jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat mengombinasikan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.getStyleIndex](https://reference.aspose.com/slides/id/php-java/aspose.slides/background/) saat ini. Indeks gaya `0` berarti tidak ada isian bertema; nilai positif adalah referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi PHP secara langsung, di mana `get_Item(0)` berarti item pertama yang disimpan. Jangan menganggap bahwa setiap presentasi berisi jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil yang terlihat bergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat layout atau slide. Jika slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/background/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Selain itu hindari mengkodekan nomor gaya dari satu file dan mengasumsikan tampilannya sama di file lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/php-java/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi isian, garis, dan efek terpisah yang diekspos melalui [FormatScheme.getFillStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/formatscheme/), dan [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/id/php-java/aspose.slides/formatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual sesuai dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih-alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Saat mengakses koleksi ini di PHP, indeks koleksi berbasis nol: `get_Item(0)` adalah gaya pertama yang disimpan dan `get_Item(2)` adalah gaya ketiga. Indeks referensi gaya pada bentuk adalah konsep terpisah, diekspos melalui [ShapeStyle](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapestyle/). Mengubah gaya tema memengaruhi bentuk yang merujuk ke gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa keberadaan entri gaya yang diperlukan, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk bentuk yang merujuk ke slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan padat, dan gaya efek ketiga mendapatkan bayangan luar dengan jarak 10 poin. Hasil visual tepat tetap bergantung pada slot gaya mana yang dirujuk masing-masing bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isian, dan bayangan](presentation-design_11.png)

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu Anda apa yang didefinisikan pada tingkat tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseoverridethememanager/). Untuk latar belakang, gunakan [Background.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/background/), dan untuk isian, gunakan [FillFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/).

Contoh berikut membaca tema efektif, latar belakang, dan isian bentuk pertama dari sebuah slide:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), Anda dapat melewatkan penimpaan master, layout, slide, atau bentuk yang mengubah penampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) hanya menugaskan kembali slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Dapatkah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidethememanager/) slide dan inisialisasi tema penimpaan-nya. Perubahan tetap lokal untuk slide tersebut; slide lain terus mewarisi tema yang ada.

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master tersebut menggunakan [MasterSlideCollection.addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/) serta [SlideCollection.addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/). Ini menjaga master, layout, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseoverridethememanager/) untuk tema slide atau layout serta metode data-efektif yang bersangkutan untuk objek format seperti [Background.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/background/) dan [FillFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/). API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.