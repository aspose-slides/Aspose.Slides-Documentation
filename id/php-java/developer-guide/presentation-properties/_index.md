---
title: Mengelola Properti Presentasi di PHP
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/php-java/presentation-properties/
keywords:
- properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti kustom
- properti lanjutan
- mengelola properti
- memodifikasi properti
- metadata dokumen
- mengedit metadata
- bahasa pemeriksaan
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk PHP via Java dan optimalkan pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pengantar**

Aspose.Slides for PHP via Java mendukung **built-in** dan **custom** properti dokumen. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . Sebuah instance kelas ini dikembalikan oleh [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini. Mereka mengasumsikan bahwa PHP/Java Bridge dan pembungkus Aspose.Slides PHP telah diinisialisasi.

{{% alert color="info" title="Note" %}}
Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang-bidang ini mengidentifikasi perangkat lunak yang membuat output.
{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersamaan dengan konten presentasi. Mereka terbagi menjadi dua kategori:

- **Built-in properties** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Custom properties** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides for PHP via Java menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Summary**, **Statistics**, **Contents**, dan **Custom**. Gunakan tab **Custom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi yang Dienkripsi**

Biasanya kata sandi pembuka melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi setelah memanggil [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) dengan `false`, properti dokumennya tetap publik. Aplikasi kemudian dapat memanggil [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) dengan `true` dan membaca metadata publik tanpa menyertakan kata sandi pembuka.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) mengontrol apa yang dimuat oleh Aspose.Slides; itu tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa kata sandi akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh ini membutuhkan presentasi yang dienkripsi di mana properti dokumennya dibiarkan publik. Ini memverifikasi mode pemuatan melalui [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) dan kemudian membaca properti built-in melalui [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan mereka publik hanya ketika proses pengindeksan, klasifikasi, pencarian, atau sistem manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa kata sandi.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Dienkripsi**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat setelah memanggil [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) dengan `true` ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek yang hanya berisi metadata ini karena properti publik harus tetap konsisten dengan data yang sesuai di dalam presentasi yang dienkripsi. Oleh karena itu, memperbarui mereka memerlukan kata sandi pembuka yang benar dan pemuatan lengkap.

Contoh ini membutuhkan presentasi PPTX yang dienkripsi dengan properti dokumen publik dan kata sandi pembuka yang diketahui. Ia membuka presentasi lengkap dengan [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian ia menggunakan [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) untuk memverifikasi bahwa enkripsi dipertahankan dan membuka kembali metadata publik tanpa kata sandi untuk memverifikasi nilai baru:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Jika aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai read-only.

## **Akses Properti Built-in**

Kelas [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) menampilkan metadata built-in melalui metode getter, termasuk [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/), dan [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpan ke konsol. Nilai tergantung pada presentasi input; beberapa bidang mungkin kosong.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Modifikasi Properti Built-in**

Untuk memperbarui metadata built-in, gunakan metode setter pada objek yang dikembalikan oleh [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Contoh ini membuka presentasi yang ada, memanggil [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/), dan [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), lalu menyimpan presentasi yang diperbarui dengan [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). PPTX yang disimpan berisi metadata baru.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kelola Hyperlink Base**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) mengembalikan basis tingkat dokumen untuk hyperlink relatif. Gunakan [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) untuk mengubah atau mengosongkannya. Ini berguna saat memindahkan presentasi dan file terkait ke lokasi lain. Ini terpisah dari [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) milik hyperlink individu: mengubah basis tidak menulis ulang alamat tautan yang disimpan atau mengubah tujuan absolut.

Contoh ini membutuhkan presentasi yang berisi tautan relatif, seperti `target.html`, dan tautan absolut, seperti `https://example.org/absolute.html`. Ia membaca basis yang ada, menetapkan alamat basis baru, dan menyimpan serta membuka kembali presentasi untuk memeriksa nilainya. Kemudian ia mengosongkan basis dengan string kosong dan memverifikasi nilai kosong dalam file tersimpan terpisah. Ganti alamat basis contoh dengan lokasi file terkait Anda.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Dua pesan verifikasi harus mencetak `true`. Mengosongkan basis tidak mengubah alamat hyperlink individu.

Tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika basis mengarah ke folder `old`. Setelah mengubah basis ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut tetap membuka file yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan sesudah memindahkan presentasi atau mengubah basisnya.

## **Tambahkan Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang built-in yang sesuai. Metode [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat presentasi, menambahkan dua nilai teks dan satu nilai versi integer, dan menyimpan presentasi dengan [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Menetapkan nilai ke nama yang sudah ada menggantikan nilai properti tersebut.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Akses dan Modifikasi Properti Kustom**

Contoh ini membuka presentasi yang berisi properti kustom dan menggunakan [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) untuk mengiterasinya. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) menerima indeks berbasis nol dan mengembalikan nama yang digunakan oleh [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Contoh ini mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string bernomor terlepas dari tipe aslinya, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak membuat perubahan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contoh Langsung**

Coba aplikasi daring [**Lihat & Edit Metadata PowerPoint**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana saya dapat menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilai mereka atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Bisakah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) dan kemudian [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/php-java/examine-presentation/) untuk contoh pelaporan lengkap dan keterbatasan format tertentu.

**Bisakah saya membaca properti publik dari presentasi yang dienkripsi tanpa kata sandi pembukanya?**

Ya. Presentasi harus dienkripsi setelah memanggil [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) dengan `false`, dan harus dimuat setelah memanggil [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) dengan `true`.

**Bisakah saya memperbarui file PPTX yang dienkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan lengkap presentasi dengan kata sandi pembuka yang benar.