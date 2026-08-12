---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint menggunakan JavaScript
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/nodejs-java/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- pengelolaan dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PowerPoint PPTX dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui statusnya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides untuk Node.js via Java menyediakan metadata label sensitivitas modern melalui [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Metode ini mengembalikan sebuah [SensitivityLabelCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/) yang dapat diperiksa dan dimodifikasi sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Catatan" %}}
Identifier label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasikan metadata. Nilai [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menjelaskan penandaan konten yang terkait dengan label; nilai tersebut tidak secara otomatis menambahkan teks atau bentuk yang terlihat ke slide.
{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [SensitivityLabel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/) berisi metadata berikut:

| Metode | Tujuan |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getId) dan [SensitivityLabel.setId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Dapatkan atau atur identifier label sensitivitas dalam kebijakan Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) dan [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Dapatkan atau atur situs yang terkait dengan kebijakan label. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) dan [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Dapatkan atau atur apakah label diaktifkan. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) dan [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Dapatkan atau atur apakah label telah dihapus. Atur nilai ke `true` ketika status penghapusan harus dipertahankan dalam metadata. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) dan [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Dapatkan atau atur apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Dapatkan jenis penandaan konten yang terkait dengan label. |

Kelas [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) menentukan bagaimana sebuah label ditetapkan:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, direkomendasikan, dan wajib.

Kelas [SensitivityLabelContentType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) menentukan penandaan yang terkait dengan sebuah label:

| Nilai | Makna |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) dan enumerasi. Contoh berikut mencantumkan setiap properti dan penandaan konten yang disimpan untuk setiap label:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) dengan identifier label, identifier situs, status aktif, dan metode penetapan. Setelah metode mengembalikan [SensitivityLabel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan melalui daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, kemudian menyimpan hasilnya sebagai PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memperbarui Label Sensitivitas**

Nilai [SensitivityLabel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/) dapat dibaca/ditulis, kecuali daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) yang dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui identifier, identifier situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menyimpan perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan panggil [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `true`. Ini mempertahankan entri label sekaligus mencatat status penghapusannya. Jika Anda ingin menghapus entri dari koleksi modern, gunakan [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); gunakan [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang diperbarui:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Membaca dan Memigrasikan Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP yang lebih lama dapat menyimpan metadata label sensitivitas dalam properti dokumen khusus alih-alih koleksi label modern. Baca metadata tersebut dengan [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Metode ini mengurai properti khusus legacy dan mengembalikan array objek [SensitivityLabel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/).

Untuk memigrasikan metadata, tambahkan setiap label yang dikembalikan ke [SensitivityLabelCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/) modern melalui [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Karena menambahkan identifier label duplikat akan memicu pengecualian, contoh ini memeriksa koleksi tujuan sebelum menyalin setiap label. Anda dapat menambahkan validasi tambahan untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Proses migrasi menyalin objek label yang diurai ke dalam koleksi modern. Tidak diperlukan pembersihan semua properti dokumen khusus, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menjelaskan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang sesuai secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Memanggil [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `true` mempertahankan entri label dan mencatat status penghapusannya. Memanggil [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan persyaratan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern sekaligus?**

Ya. Label legacy dapat tetap berada dalam properti dokumen khusus sementara label modern tersedia melalui [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Gunakan [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) untuk membaca metadata legacy dan memigrasikan hanya label yang valid yang belum ada dalam koleksi modern.

**Apa yang terjadi ketika sebuah label dengan identifier yang sama ditambahkan lebih dari satu kali?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) memicu pengecualian ketika koleksi sudah berisi label dengan identifier yang sama. Periksa nilai yang ada yang dikembalikan oleh [SensitivityLabel.getId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sensitivitylabel/#getId) sebelum menambahkan atau memigrasikan label.

**Format output apa yang harus digunakan untuk mempertahankan label sensitivitas yang diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) menggunakan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/), seperti yang ditunjukkan pada contoh di atas.