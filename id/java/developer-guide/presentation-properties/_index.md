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
- Modifikasi properti
- Metadata dokumen
- Sunting metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola properti presentasi utama di Aspose.Slides untuk Java dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides untuk Java mendukung properti dokumen **bawaan** dan **kustom**. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) . Sebuah instance dari antarmuka ini dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang-bidang ini mengidentifikasi perangkat lunak yang membuat hasil.
{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersama konten presentasi. Mereka terbagi menjadi dua kategori:

- **Built-in properties** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Custom properties** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides untuk Java menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Summary**, **Statistics**, **Contents**, dan **Custom**. Gunakan tab **Custom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi Terenkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, properti dokumennya tetap publik. Sebuah aplikasi kemudian dapat memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` dan membaca metadata publik tanpa memasukkan password pembuka.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mengontrol apa yang dimuat oleh Aspose.Slides; itu tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password gagal. Jika presentasi tidak terenkripsi, opsi ini diabaikan dan presentasi lengkap dimuat.

Contoh ini memerlukan sebuah presentasi terenkripsi yang properti dokumennya dibiarkan publik. Ia memverifikasi mode pemuatan melalui [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) dan kemudian membaca properti bawaan melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):
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

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, bentuk, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan mereka publik hanya ketika proses pengindeksan, klasifikasi, pencarian, atau sistem manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi Terenkripsi**

Untuk file PPTX terenkripsi, sebuah presentasi yang dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek yang hanya berisi metadata karena properti publik harus tetap konsisten dengan data yang sesuai di dalam presentasi terenkripsi. Oleh karena itu, memperbarui mereka memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh ini memerlukan sebuah presentasi PPTX terenkripsi dengan properti dokumen publik dan password pembuka yang diketahui. Ia membuka presentasi lengkap dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), memperbarui properti bawaan publik, dan menyimpan hasilnya. Kemudian ia menggunakan [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:
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

Jika sebuah aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX terenkripsi sebagai baca-saja.

## **Akses Properti Bawaan**

Antarmuka [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) menampilkan metadata bawaan melalui metode getter, termasuk [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), dan [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpan ke konsol. Nilai tergantung pada presentasi input; beberapa bidang mungkin kosong.
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

## **Modifikasi Properti Bawaan**

Untuk memperbarui metadata bawaan, gunakan metode setter pada objek yang dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh ini membuka presentasi yang ada, memanggil [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), dan [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), kemudian menyimpan presentasi yang diperbarui dengan [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). PPTX yang disimpan berisi metadata baru.
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

## **Kelola Basis Hyperlink**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) mengembalikan basis level dokumen untuk hyperlink relatif. Gunakan [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) untuk mengubah atau mengosongkannya. Ini berguna saat memindahkan presentasi dan file terkait ke lokasi lain. Ini terpisah dari [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--): mengubah basis tidak menulis ulang alamat tautan yang disimpan atau mengubah tujuan absolut.

Contoh ini memerlukan presentasi yang berisi tautan relatif, misalnya `target.html`, dan tautan absolut, misalnya `https://example.org/absolute.html`. Ia membaca basis yang ada, menetapkan alamat basis baru, dan menyimpan serta membuka kembali presentasi untuk memeriksa nilai tersebut. Kemudian ia mengosongkan basis dengan string kosong dan memverifikasi nilai kosong dalam file yang disimpan terpisah. Ganti alamat basis contoh dengan lokasi file yang Anda tautkan.
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

Dua pesan verifikasi seharusnya mencetak `true`. Mengosongkan basis membiarkan alamat hyperlink individu tetap utuh.

Tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika basis menunjuk ke folder `old`. Setelah mengubah basis ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut tetap membuka file yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan sesudah memindahkan presentasi atau mengubah basenya.

## **Tambahkan Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang bawaan yang sesuai. Metode [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat sebuah presentasi, menambahkan dua nilai teks dan satu nilai versi integer, dan menyimpan presentasi dengan [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Menetapkan nilai ke nama yang sudah ada menggantikan nilai properti tersebut.
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

## **Akses dan Modifikasi Properti Kustom**

Contoh ini membuka sebuah presentasi yang berisi properti kustom dan menggunakan [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) untuk mengiterasi mereka. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) menerima indeks berbasis nol dan mengembalikan nama yang digunakan oleh [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Contoh mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string bernomor terlepas dari tipe aslinya, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak melakukan perubahan.
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

Coba aplikasi online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana cara menghapus properti bawaan dari sebuah presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diizinkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Bisakah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) dan kemudian [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Lihat [Bangun Inventaris Presentasi Ringan](/slides/id/java/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.

**Bisakah saya membaca properti publik dari presentasi terenkripsi tanpa password pembukanya?**

Ya. Presentasi harus dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, dan harus dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true`.

**Bisakah saya memperbarui file PPTX terenkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX terenkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.