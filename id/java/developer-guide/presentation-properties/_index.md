---
title: Kelola Properti Presentasi di Java
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/java/presentation-properties/
keywords:
- Properti PowerPoint
- Properti presentasi
- Properti dokumen
- Properti bawaan
- Properti kustom
- Properti lanjutan
- Kelola properti
- Ubah properti
- Metadata dokumen
- Edit metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk Java dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pengantar**

Aspose.Slides for Java mendukung properti dokumen **bawaan** dan **kustom**. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/). Instance antarmuka ini dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh berikut menunjukkan cara membaca, mengubah, dan mengelola properti tersebut.

{{% alert color="info" title="Catatan" %}}

Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang ini mengidentifikasi perangkat lunak yang membuat output.

{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersamaan dengan konten presentasi. Mereka terbagi menjadi dua kategori:

- **Properti bawaan** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Properti kustom** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides for Java menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Summary**, **Statistics**, **Contents**, dan **Custom**. Gunakan tab **Custom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi yang Terenkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika presentasi dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, properti dokumennya tetap publik. Aplikasi kemudian dapat memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` dan membaca metadata publik tanpa menyediakan password pembuka.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mengendalikan apa yang dimuat Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh ini memerlukan presentasi terenkripsi yang properti dokumennya dibiarkan publik. Ia memverifikasi mode pemuatan melalui [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) dan kemudian membaca properti bawaan melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Peringatan" %}}
Metadata publik dapat mengekspos nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersamaan dengan presentasi. Biarkan mereka publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Terenkripsi**

Untuk file PPTX terenkripsi, presentasi yang dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek hanya-metadata tersebut karena properti publik harus tetap konsisten dengan data yang bersangkutan di dalam presentasi yang terenkripsi. Oleh karena itu, memperbaruinya memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh ini memerlukan presentasi PPTX terenkripsi dengan properti dokumen publik dan password pembuka yang diketahui. Ia membuka seluruh presentasi dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), memperbarui properti bawaan publik, dan menyimpan hasilnya. Kemudian menggunakan [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) untuk memverifikasi bahwa enkripsi tetap dipertahankan dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Jika aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX terenkripsi sebagai read‑only.

## **Akses Properti Bawaan**

Antarmuka [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) menampilkan metadata bawaan melalui metode getter, termasuk [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), dan [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpannya ke konsol. Nilai tergantung pada presentasi input; beberapa bidang mungkin kosong.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Laporkan Nomor Revisi dan Waktu Penyuntingan**

Untuk melaporkan satu baris bagi setiap file PPTX di folder `presentations`, panggil [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) tanpa memuat slide untuk penyuntingan. API Java mengembalikan durasi penyuntingan dalam milidetik. Contoh memformatnya sebagai jam, menit, dan detik, dengan hitungan hari untuk durasi 24 jam atau lebih.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

Untuk presentasi dengan waktu penyuntingan tercatat 1 hari, 2 jam, dan 5 menit, laporan menunjukkan output berikut.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) membaca nilai yang dapat diubah aplikasi dengan [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-). Nomor revisi saja tidak dapat menunjukkan berapa kali presentasi disimpan atau merekonstruksi riwayat versinya.

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) membaca durasi penyuntingan yang tercatat dalam file. Nilai `00:00:00` berarti durasi yang disimpan nol, meskipun ada yang menyunting presentasi.

## **Ubah Properti Bawaan**

Untuk memperbarui metadata bawaan, gunakan metode setter pada objek yang dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh ini membuka presentasi yang ada, memanggil [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), dan [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), lalu menyimpan presentasi yang diperbarui dengan [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). PPTX yang disimpan berisi metadata baru.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelola Hyperlink Base**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) mengembalikan basis tingkat dokumen untuk hyperlink relatif. Gunakan [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) untuk mengubah atau mengosongkannya. Hal ini berguna ketika memindahkan presentasi dan berkas terkait ke lokasi lain. Ini terpisah dari [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) pada hyperlink individu: mengubah basis tidak menulis ulang alamat link yang disimpan maupun mengubah tujuan absolut.

Contoh ini memerlukan presentasi yang berisi kedua jenis tautan: tautan relatif, misalnya `target.html`, dan tautan absolut, misalnya `https://example.org/absolute.html`. Ia membaca basis yang ada, menetapkan basis baru, lalu menyimpan dan membuka kembali presentasi untuk memeriksa nilai tersebut. Selanjutnya ia mengosongkan basis dengan string kosong dan memverifikasi nilai kosong dalam berkas yang disimpan terpisah. Ganti basis contoh dengan lokasi berkas tautan Anda.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kedua pesan verifikasi harus mencetak `true`. Mengosongkan basis tidak mengubah alamat hyperlink individu.

Tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika basis mengarah ke folder `old`. Setelah mengubah basis ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut tetap membuka berkas yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan sesudah memindahkan presentasi atau mengubah basenya.

## **Tambahkan Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang bawaan yang bersesuaian. Metode [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat presentasi, menambahkan dua nilai teks dan satu nilai versi bertipe integer, lalu menyimpan presentasi dengan [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Menetapkan nilai ke nama yang sudah ada akan menggantikan nilai properti tersebut.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Akses dan Ubah Properti Kustom**

Contoh ini membuka presentasi yang berisi properti kustom dan menggunakan [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) untuk mengiterasinya. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) menerima indeks berbasis nol dan mengembalikan nama yang dipakai oleh [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Contoh mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string berangka terlepas dari tipe aslinya, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak melakukan apa‑apa.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contoh Langsung**

Coba aplikasi daring [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana cara menghapus properti bawaan dari presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkannya.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) lalu [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/java/examine-presentation/) untuk contoh laporan lengkap dan batasan spesifik format.

**Bisakah saya membaca properti publik dari presentasi terenkripsi tanpa password pembukanya?**

Ya. Presentasi harus dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, dan harus dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true`.

**Bisakah saya memperbarui file PPTX terenkripsi dalam mode hanya‑properti‑dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX terenkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.