---
title: Kelola Tema Presentasi dalam PHP
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
description: "Kelola tema presentasi utama di Aspose.Slides untuk PHP melalui Java untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan branding yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan satu set warna, font, gaya latar belakang, isian, garis, dan efek yang terkoordinasi. Objek yang menyadari tema merujuk ke definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Sebuah presentasi juga dapat berisi penimpaan tema pada tingkat yang lebih rendah. Master dapat menimpa tema presentasi melalui [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), sementara tata letak atau slide individual dapat menimpa tema yang diwarisinya melalui [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Dalam praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) menampilkan skema warna, skema font, dan skema format tema melalui [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), dan [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

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

Jika sebuah file menggunakan beberapa master, jangan mengasumsikan bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditampilkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk ke warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersesuaian dalam [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), semua objek yang masih merujuk ke warna tema tersebut diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak diubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat sebuah bentuk yang menggunakan `Accent4`, mengubah warna `Accent4` tema menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isian efektif:

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

Karena persegi panjang tetap terhubung ke `Accent4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak akan lagi memengaruhi isian tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian yang lebih terang dan lebih gelap dari sebuah warna tema dengan menerapkan transformasi warna. Aspose.Slides menampilkan transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Warna tema utama serta warna yang lebih terang dan lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.  
**2** - Varian yang lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi panjang berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

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

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah nanti, warna yang ditransformasi dihitung ulang dari nilai `Accent4` yang baru.

### **Petakan Nilai `SchemeColor` ke Slot `ColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sedangkan [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) menampilkan slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; mereka bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lainnya.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk judul dan satu set font minor untuk teks tubuh. Metode [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) dan [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) menampilkan set tersebut.

Identifier font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Tubuh Latin (Font Latin Minor)
* `+mj-lt` - Font Judul Latin (Font Latin Mayor)
* `+mn-ea` - Font Tubuh Asia Timur (Font Asia Timur Minor)
* `+mj-ea` - Font Judul Asia Timur (Font Asia Timur Mayor)
* `+mn-cs` - Font Tubuh Skrip Kompleks (Font Skrip Kompleks Minor)
* `+mj-cs` - Font Judul Skrip Kompleks (Font Skrip Kompleks Mayor)

Contoh berikut membuat satu judul yang menggunakan font tema Latin mayor dan satu baris tubuh yang menggunakan font tema Latin minor. Kemudian mengubah font tema dan menyimpan hasilnya:

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

Judul mengikuti font mayor dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih identifier tema tidak akan otomatis berubah ketika skema font tema berubah.

Koleksi font mayor dan minor juga dapat berisi pemetaan font untuk sistem penulisan individu, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Font Tema Spesifik Skrip](/slides/id/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [Font PowerPoint](/slides/id/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Menyelesaikan Referensi Font Tema**

Saat memeriksa teks, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) dapat mengembalikan referensi tema seperti `+mn-lt` alih-alih nama keluarga font. Panggil [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) dengan data tema efektif yang tepat untuk menyelesaikan referensi tersebut. Prefiks `+mj` dan `+mn` memilih set font mayor dan minor; sufiks `-lt`, `-ea`, dan `-cs` memilih font Latin, Asia Timur, dan Skrip Kompleks masing-masing.

Dapatkan tema efektif melalui [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) pada objek yang temanya berlaku untuk teks yang diperiksa. Untuk teks biasa pada slide, panggil metode ini pada slide sehingga konteks mencakup tema yang diwariskan slide tersebut dan penimpaan lokal. Saat memeriksa tata letak atau master itu sendiri, gunakan tema efektifnya sendiri. Jangan mengasumsikan bahwa tema master pertama berlaku untuk setiap slide.

Contoh berikut membuat sebuah bagian teks yang secara eksplisit merujuk ke font Latin minor. Ia menginisialisasi skema font slide melalui [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) dan mengatur keluarga Latin mayor dan minor menjadi `Arial` dan `Calibri`, sehingga hasil dapat direproduksi tanpa file input.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Outputnya adalah `+mn-lt -> Calibri` diikuti oleh `Verdana -> Verdana`. Referensi yang disimpan tetap tidak berubah, sementara nama keluarga yang eksplisit dikembalikan apa adanya. Jika bagian tersebut menggunakan `+mj-lt`, maka akan menyelesaikan ke `Arial` dalam tema ini.

Menyelesaikan referensi tema mengidentifikasi keluarga font yang ditentukan oleh tema. Itu tidak memeriksa ketersediaan font atau menentukan file font yang pada akhirnya digunakan setelah substitusi atau fallback glyph selama rendering. Lihat [Urutan Seleksi Font](/slides/id/php-java/font-selection-sequence/) dan [Substitusi Font](/slides/id/php-java/font-substitution/) untuk langkah-langkah terpisah tersebut.

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini memecahkan berbagai masalah terkait tema.

### **Menerapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya setiap slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), yang direpresentasikan oleh [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat slide master baru berdasarkan master yang dipilih.  
2. Menerapkan tema eksternal ke master baru.  
3. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.  
4. Mengembalikan [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) yang baru dibuat.

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

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Validasi jalur yang diberikan oleh pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master yang dipilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema yang ada. Warna, font, isian, garis, latar belakang, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan pada tingkat tata letak dan slide juga dapat memiliki prioritas lebih tinggi daripada nilai yang diwariskan dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan lewat [sumber font khusus](/slides/id/php-java/custom-font/), atau konfigurasikan [substitusi font](/slides/id/php-java/font-substitution/).

Ini adalah alur kerja tingkat master langsung: metode menerima jalur file ke file `.thmx` dan tidak memerlukan pembuatan manual penimpaan tema pada tingkat slide atau tata letak.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi-Master**

Ketika master yang relevan tidak diketahui sebelumnya, peroleh dari slide representatif melalui [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) dan [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap panggilan membuat master tambahan dalam presentasi.

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

Panggilan pertama memengaruhi hanya slide yang bergantung pada `$firstGroupMaster`, dan panggilan kedua memengaruhi hanya slide yang bergantung pada `$secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gaya.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, klon master sumber ke dalam presentasi target dengan [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), lalu klon slide dengan [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) dan master yang diklon. Ini membawa master, tata letaknya, dan tema terkait bersamaan.

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

Ini adalah alur kerja yang disarankan ketika slide sumber harus terlihat sama di tujuan. Hanya mengklon konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipengaruhi tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), dan [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) menyalin tiga komponen utama tema ke dalam penimpaan.

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

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwariskan oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwariskan, panggil [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Menerapkan Penimpaan Tema ke Tata Letak**

Penimpaan tingkat tata letak berlaku untuk slide yang menggunakan tata letak tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

Gunakan tema master atau tingkat presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak membutuhkan gaya berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari lebih sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI-nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Indeks gaya `0` berarti tidak ada isian tema; nilai positif merupakan referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi PHP secara langsung, di mana `get_Item(0)` berarti item pertama yang disimpan. Jangan mengasumsikan bahwa setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang tema ke master pertama, dan menyimpan presentasi:

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

Hasil yang terlihat tergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat tata letak atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan indeks gaya sebagai indeks koleksi berbasis nol. Juga hindari pengkodean keras nomor gaya dari satu file dan mengasumsikan tampilannya sama di file lain; definisi gaya tema bersifat spesifik untuk presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Latar Belakang Presentasi](/slides/id/php-java/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi gaya isian, garis, dan efek terpisah yang ditampilkan melalui [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), dan [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual sesuai dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa masing-masing koleksi alih-alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Saat Anda mengakses koleksi ini di PHP, indeks koleksi berbasis nol: `get_Item(0)` adalah gaya pertama yang disimpan dan `get_Item(2)` adalah yang ketiga. Indeks referensi gaya sebuah bentuk adalah konsep terpisah, ditampilkan melalui [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk ke gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa bahwa entri gaya yang dibutuhkan ada, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

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

Untuk bentuk yang merujuk ke slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga mendapatkan bayangan luar dengan jarak 10 poin. Hasil visual tepat masih tergantung pada slot gaya mana yang dirujuk tiap bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isian, dan bayangan](presentation-design_11.png)

## **Memilih Gaya Isian dan Garis Tema untuk Bentuk**

Sebuah bentuk dapat memilih isian dan garis luarnya secara independen melalui [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) dan [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Untuk masing-masing metode, indeks `1` memilih entri pertama dalam koleksi tema yang bersangkutan (`get_Item(0)`), dan indeks `2` memilih yang kedua (`get_Item(1)`).

Contoh berikut menyiapkan dua gaya isian (emas dan biru langit) dan dua gaya garis (biru tua 6 pt dan merah tua 12 pt) dalam tema default presentasi baru. Ia menyimpan slide dalam tiga tahap sehingga Anda dapat membandingkan hasilnya di PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Gaya Awal | Ubah Garis Luar Kanan | Sunting Isian Tema Pertama |
|:---:|:---:|:---:|
| ![Persegi panjang emas dan biru langit dengan garis luar tipis biru tua yang cocok](theme-style-initial.png) | ![Persegi panjang biru langit kini memiliki garis luar tebal merah tua](theme-style-line-changed.png) | ![Persegi panjang kiri kini hijau dan kedua garis luar tidak berubah](theme-style-fill-changed.png) |

Memilih gaya garis yang berbeda hanya mengubah garis luar persegi kanan. Menyunting isian tema pertama memperbarui setiap bentuk yang menggunakannya. Di sini, hanya persegi kiri yang menjadi hijau.

Pada bentuk yang sudah ada, warna isian lokal, warna garis, atau lebar garis dapat menimpa bagian gaya tema tersebut. Jika mengubah indeks gaya tidak menghasilkan efek yang terlihat, periksa [pemformatan langsung](/slides/id/php-java/shape-formatting/).

## **Menentukan Apakah Isian Solid Efektif Menggunakan Warna Tema**

Isian dapat disimpan secara langsung pada objek atau diwariskan dari paragraf, tata letak, master, gaya tema, atau level pemformatan lain. Panggil [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) untuk menyelesaikan hierarki itu menjadi data isian efektif yang tidak dapat diubah. Pertama periksa hasil `getFillType`. Hanya ketika nilainya `FillType::Solid` Anda harus membaca properti isian solid.

Untuk isian solid, `getSolidFillColor` mengembalikan nilai RGB akhir setelah pewarisan, pencarian tema, dan transformasi warna diterapkan. Metode `getSolidFillSchemeColor` mengembalikan slot [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) logis yang bersesuaian, seperti `Text1` atau `Accent6`. Nilai `SchemeColor::NotDefined` berarti isian solid efektif tidak didasarkan pada warna skema. Dalam alur kerja di mana isian berupa warna tema atau warna RGB langsung, nilai ini mengidentifikasi isian RGB langsung.

Jangan gunakan nilai lokal [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) saja untuk mengklasifikasikan isian. Misalnya, sebuah bagian teks dapat tidak memiliki warna skema yang didefinisikan secara lokal, sehingga nilai lokalnya `NotDefined`, sementara isian efektifnya mewarisi warna tema dan menyelesaikan ke `Text1` atau `Accent6`. Sebaliknya, `getSolidFillSchemeColor` memberi tahu slot tema logis mana yang menghasilkan warna efektif, tetapi tidak memberi tahu apakah slot tersebut berasal dari objek, paragraf, tata letak, master, atau level lain dalam hierarki pemformatan.

Contoh berikut memuat sebuah presentasi, mengaudit isian bentuk dan isian bagian teks, mencetak setiap nilai RGB akhir dan warna skema terkait, serta menandai isian solid yang tidak akan mengikuti perubahan warna tema:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Cabang `NotDefined` menyediakan daftar audit isian solid yang tidak akan merespon perubahan pada slot warna tema. Tinjau objek-objek tersebut ketika sebuah presentasi harus mengikuti palet merek baru. Nilai RGB yang dilaporkan masih menunjukkan tampilan saat ini, sementara nilai skema menjelaskan apakah tampilan itu terhubung ke tema.

Objek format-efektif adalah snapshot. Setelah mengubah tema presentasi, penimpaan tema, atau pemformatan yang diwariskan, panggil `getEffective` lagi dan baca data isian efektif baru sebelum membandingkan atau melaporkan warna.

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu apa yang didefinisikan pada tingkat tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Untuk latar belakang, gunakan [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), dan untuk isian, gunakan [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

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

Gunakan data efektif untuk diagnosa rendering, validasi, dan perbandingan. Jika Anda memeriksa hanya [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), Anda dapat melewatkan penimpaan master, tata letak, slide, atau bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) hanya memindahkan slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) slide dan inisialisasi tema penimpaanannya. Perubahan tetap lokal untuk slide tersebut; slide lain terus mewarisi tema yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, klon master sumber ke tujuan dan klon slide dengan master tersebut menggunakan [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) dan [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Ini menjaga master, tata letak, dan tema bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) untuk tema slide atau tata letak dan metode data-efektif yang sesuai untuk objek format seperti [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) dan [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). API ini mengembalikan nilai yang diselesaikan setelah pewarisan dan penimpaan diterapkan.