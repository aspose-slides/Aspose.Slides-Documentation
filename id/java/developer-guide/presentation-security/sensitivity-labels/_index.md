---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint di Java
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PowerPoint PPTX dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui statusnya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides mengekspos metadata label sensitivitas modern melalui [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Metode ini mengembalikan sebuah [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/) yang dapat diperiksa dan diubah sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Catatan" %}}
Identifier label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasikan metadata. Nilai [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) menggambarkan penandaan konten yang terkait dengan label; nilai tersebut tidak secara otomatis menambahkan teks atau bentuk yang terlihat pada slide.
{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [ISensitivityLabel](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/) berisi metadata berikut:

| Metode | Tujuan |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getId--) dan [ISensitivityLabel.setId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Mendapatkan atau mengatur identifier label sensitivitas dalam kebijakan Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getSiteId--) dan [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Mendapatkan atau mengatur situs yang terkait dengan kebijakan label. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#isEnabled--) dan [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Mendapatkan atau mengatur apakah label diaktifkan. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#isRemoved--) dan [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Mendapatkan atau mengatur apakah label telah dihapus. Atur nilai menjadi `true` ketika status penghapusan harus dipertahankan dalam metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) dan [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Mendapatkan atau mengatur apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Mendapatkan jenis penandaan konten yang terkait dengan label. |

Kelas [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelassignmenttype/) mendefinisikan bagaimana sebuah label ditetapkan:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, yang direkomendasikan, dan yang wajib.

Kelas [SensitivityLabelContentType](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) mendefinisikan penandaan yang terkait dengan sebuah label:

| Nilai | Makna |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/id/java/com.aspose.slides/sensitivitylabelcontenttype/) | Proteksi enkripsi terkait dengan label. |

Beberapa tipe penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) dan enumerate. Contoh berikut menampilkan setiap properti dan penandaan konten yang disimpan untuk setiap label:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) dengan identifier label, identifier situs, status aktif, dan metode penetapan. Setelah metode mengembalikan [ISensitivityLabel](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan melalui daftar yang dikembalikan oleh [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, lalu menyimpan hasilnya sebagai PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memperbarui Label Sensitivitas**

Nilai [ISensitivityLabel](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/) dapat dibaca/ditulis, kecuali daftar yang dikembalikan oleh [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui identifier, identifier situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menerapkan perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan panggil [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) dengan `true`. Ini mempertahankan entri label sambil mencatat status terhapusnya. Jika Anda malah perlu menghapus entri dari koleksi modern, gunakan [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); gunakan [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#clear--) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang telah diperbarui:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Membaca dan Mentransfer Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP lama dapat menyimpan metadata label sensitivitas dalam properti dokumen khusus alih-alih koleksi label modern. Baca metadata tersebut dengan [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metode ini menguraikan properti khusus legacy dan mengembalikan array objek [ISensitivityLabel](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/).

Untuk memigrasikan metadata, tambahkan setiap label yang dikembalikan ke [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/) modern melalui [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Karena menambahkan identifier label duplikat akan menghasilkan pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin masing‑masing label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Migrasi menyalin objek label yang diuraikan ke dalam koleksi modern. Ini tidak memerlukan pengosongan semua properti dokumen khusus, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [IPresentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan tipe penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui daftar yang dikembalikan oleh [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) menggambarkan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang bersesuaian secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Memanggil [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) dengan `true` mempertahankan entri label dan mencatat status terhapusnya. Memanggil [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan persyaratan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern sekaligus?**

Ya. Label legacy dapat tetap berada dalam properti dokumen khusus sementara label modern tersedia melalui [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Gunakan [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) untuk membaca metadata legacy dan memigrasikan hanya label yang valid yang belum ada dalam koleksi modern.

**Apa yang terjadi ketika label dengan identifier yang sama ditambahkan lebih dari satu kali?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) menghasilkan pengecualian bila koleksi sudah berisi label dengan identifier yang sama. Periksa nilai yang ada dengan [ISensitivityLabel.getId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isensitivitylabel/#getId--) sebelum menambahkan atau memigrasikan label.

**Format output mana yang harus digunakan untuk mempertahankan label sensitivitas yang telah diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [IPresentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) menggunakan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/), sebagaimana ditunjukkan pada contoh di atas.