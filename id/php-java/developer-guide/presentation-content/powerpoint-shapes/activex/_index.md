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
description: "Sunting kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, serta gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

Kontrol ActiveX memberi slide PowerPoint elemen interaktif seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk PHP via Java mengekspos kontrol slide melalui [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Gunakan koleksi ini untuk menyunting kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, bukalah untuk membaca dan iterasi melalui kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), dan setiap pasangan kunci-nilai dalam [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil event atau makro, mengubah nilai, atau menyimpan file.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Output terpilih dari `ActiveX.pptm` menunjukkan sebuah kotak teks dan sebuah tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) dapat mengembalikan `null`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya membutuhkan nama-nama, gunakan [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) setelah pemeriksaan null. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol dapat mendukung properti tambahan pada waktu berjalan.

## **Ubah Kontrol ActiveX**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) untuk mengubah nilai kotak teks dan keterangan tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menampilkan teks dan tampilan yang diperbarui. Contoh menetapkan gambar-gambar ini melalui [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengatur bingkainya menggunakan [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Ia menyimpan presentasi yang disunting dalam format PPTM, kemudian menggunakan [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Tambahkan Kontrol Pemutar Media ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang telah dikonfigurasi, mulailah dengan templat yang slide pertamanya mengandung pemutar bernama `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) menyalin seluruh slide ke dalam presentasi baru. Contoh mengatur `URL` pemutar pada [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/)nya dan menyimpan slide yang dikloning sebagai satu-satunya slide dalam output. Video tetap eksternal, jadi pilihlah jalur yang dapat diakses pemutar selama pemutaran.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [OLE object](/slides/id/php-java/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada ketika pengaturan keamanannya mengizinkan kontrol ActiveX dan makro.