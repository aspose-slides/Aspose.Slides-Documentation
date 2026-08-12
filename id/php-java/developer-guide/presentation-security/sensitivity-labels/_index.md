---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint di PHP
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/php-java/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- tata kelola dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- PHP
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PPTX PowerPoint di PHP."
---
## **Gambaran Umum**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui statusnya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides for PHP via Java memungkinkan akses metadata label sensitivitas modern melalui [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSensitivityLabels). Metode ini mengembalikan [SensitivityLabelCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/) yang dapat diperiksa dan dimodifikasi sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Note" %}}

Pengidentifikasi label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambah atau memigrasikan metadata. Nilai [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menggambarkan penandaan konten yang terkait dengan label; nilai tersebut tidak secara langsung menambahkan teks atau bentuk yang terlihat pada slide.

{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [SensitivityLabel](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/) berisi metadata berikut:

| Metode | Tujuan |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getId) dan [SensitivityLabel::setId](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setId) | Dapatkan atau tetapkan pengidentifikasi label sensitivitas dalam kebijakan Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getSiteId) dan [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Dapatkan atau tetapkan situs yang terkait dengan kebijakan label. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#isEnabled) dan [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Dapatkan atau tetapkan apakah label diaktifkan. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#isRemoved) dan [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Dapatkan atau tetapkan apakah label telah dihapus. Setel nilai ke `true` ketika status penghapusan harus dipertahankan dalam metadata. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) dan [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Dapatkan atau tetapkan apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Dapatkan jenis penandaan konten yang terkait dengan label. |

Kelas [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelassignmenttype/) mendefinisikan bagaimana label ditetapkan:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, yang direkomendasikan, dan yang wajib.

Kelas [SensitivityLabelContentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) mendefinisikan penandaan yang terkait dengan label:

| Nilai | Makna |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSensitivityLabels) dan enumerasi. Contoh berikut mencantumkan setiap properti dan penandaan konten yang disimpan untuk masing-masing label:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [SensitivityLabelCollection::add](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#add) dengan pengidentifikasi label, pengidentifikasi situs, status aktif, dan metode penetapan. Setelah metode mengembalikan [SensitivityLabel](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan melalui daftar yang dikembalikan oleh [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, kemudian menyimpan hasilnya sebagai PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Memperbarui Label Sensitivitas**

Nilai [SensitivityLabel](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/) dapat dibaca/diedit, kecuali daftar yang dikembalikan oleh [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) yang dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui pengidentifikasinya, pengidentifikasi situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menyimpan perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label dihapus, temukan label tersebut dan panggil [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `true`. Ini mempertahankan entri label sambil mencatat status penghapusannya. Jika Anda justru perlu menghapus entri dari koleksi modern, gunakan [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); gunakan [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#clear) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang diperbarui:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Membaca dan Memigrasikan Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP lama dapat menyimpan metadata label sensitivitas dalam properti dokumen khusus alih-alih koleksi label modern. Baca metadata tersebut dengan [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Metode ini mengurai properti khusus legacy dan mengembalikan array Java berisi objek [SensitivityLabel](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/).

Untuk memigrasikan metadata, tambahkan masing‑masing label yang dikembalikan ke [SensitivityLabelCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/) modern melalui [SensitivityLabelCollection::add](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#add). Karena menambahkan pengidentifikasi label duplikat memicu pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin setiap label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Migrasi menyalin objek label yang diurai ke dalam koleksi modern. Ini tidak memerlukan pengosongan semua properti dokumen khusus, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) dengan [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui daftar yang dikembalikan oleh [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menggambarkan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang sesuai secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Memanggil [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `true` mempertahankan entri label dan mencatat status penghapusannya. Memanggil [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan kebutuhan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern sekaligus?**

Ya. Label legacy dapat tetap berada dalam properti dokumen khusus sementara label modern tersedia melalui [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSensitivityLabels). Gunakan [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getSensitivityLabels) untuk membaca metadata legacy dan memigrasikan hanya label yang valid yang belum ada dalam koleksi modern.

**Apa yang terjadi ketika label dengan pengidentifikasi yang sama ditambahkan lebih dari satu kali?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabelcollection/#add) memicu pengecualian ketika koleksi sudah berisi label dengan pengidentifikasi yang sama. Periksa nilai yang ada dengan [SensitivityLabel::getId](https://reference.aspose.com/slides/id/php-java/aspose.slides/sensitivitylabel/#getId) sebelum menambah atau memigrasikan label.

**Format output mana yang harus digunakan untuk mempertahankan label sensitivitas yang diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) bersama [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/), seperti yang ditunjukkan pada contoh di atas.