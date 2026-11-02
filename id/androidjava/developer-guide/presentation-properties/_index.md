---
title: Kelola Properti Presentasi di Android
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/androidjava/presentation-properties/
keywords:
- Properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti khusus
- properti lanjutan
- kelola properti
- ubah properti
- metadata dokumen
- edit metadata
- bahasa pemeriksaan
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kuasai properti presentasi dalam Aspose.Slides untuk Android via Java dan permudah pencarian, branding serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pengantar**

Aspose.Slides for Android via Java mendukung properti dokumen **built-in** dan **custom**. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) . Sebuah instance dari antarmuka ini dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh-contoh berikut menunjukkan cara membaca, mengubah, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang-bidang ini mengidentifikasi perangkat lunak yang membuat output.
{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersamaan dengan konten presentasi. Mereka terbagi menjadi dua kategori:

- **Built-in properties** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Custom properties** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides for Android via Java menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Summary**, **Statistics**, **Contents**, dan **Custom**. Gunakan tab **Custom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi yang Dienkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, properti dokumennya tetap publik. Aplikasi kemudian dapat memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` dan membaca metadata publik tanpa memberikan password pembuka.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mengontrol apa yang dimuat Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh ini memerlukan presentasi yang dienkripsi dengan properti dokumen yang dibiarkan publik. Ia memverifikasi mode pemuatan melalui [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) dan kemudian membaca properti built-in melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):
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

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan mereka publik hanya ketika sistem indeksasi, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan spesifik untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Dienkripsi**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true` ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek hanya-metadata tersebut karena properti publik harus tetap konsisten dengan data yang sesuai di dalam presentasi yang dienkripsi. Oleh karena itu, memperbarui mereka memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh ini memerlukan presentasi PPTX yang dienkripsi dengan properti dokumen publik dan password pembuka yang diketahui. Ia membuka presentasi lengkap dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:
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

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, aplikasi harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai read-only.

## **Akses Properti Built-in**

Antarmuka [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) menampilkan metadata built-in melalui metode getter, termasuk [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), dan [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpannya ke konsol. Nilai tergantung pada presentasi input; beberapa bidang mungkin kosong.
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

## **Ubah Properti Built-in**

Untuk memperbarui metadata built-in, gunakan metode setter pada objek yang dikembalikan oleh [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Contoh ini membuka presentasi yang ada, memanggil [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), dan [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), kemudian menyimpan presentasi yang diperbarui dengan [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). PPTX yang disimpan berisi metadata baru.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
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

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) mengembalikan base tingkat dokumen untuk hyperlink relatif. Gunakan [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) untuk mengubah atau mengosongkannya. Ini berguna saat memindahkan presentasi dan file terkaitnya ke lokasi lain. Ini terpisah dari [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) pada hyperlink individu: mengubah base tidak menulis ulang alamat tautan yang disimpan atau mengubah tujuan absolut.

Contoh ini memerlukan presentasi yang berisi baik tautan relatif, misalnya `target.html`, maupun tautan absolut, misalnya `https://example.org/absolute.html`. Ia membaca base yang ada, menetapkan alamat base baru, dan menyimpan serta membuka kembali presentasi untuk memeriksa nilai tersebut. Kemudian mengosongkan base dengan string kosong dan memverifikasi nilai kosong dalam file tersimpan terpisah. Ganti alamat base contoh dengan lokasi file terkait Anda.
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

Dua pesan verifikasi harus mencetak `true`. Mengosongkan base meninggalkan alamat hyperlink individu tetap utuh.

Tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika base menunjuk ke folder `old`. Setelah mengubah base ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut tetap membuka file yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan setelah memindahkan presentasi atau mengubah base-nya.

## **Tambahkan Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang built-in yang sesuai. Metode [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat sebuah presentasi, menambahkan dua nilai teks dan satu nilai versi integer, dan menyimpan presentasi dengan [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Menetapkan nilai ke nama yang sudah ada menggantikan nilai properti tersebut.
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

Contoh ini membuka sebuah presentasi yang berisi properti kustom dan menggunakan [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) untuk mengiterasi mereka. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) menerima indeks berbasis nol dan mengembalikan nama yang digunakan oleh [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Contoh mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string bernomor terlepas dari tipe aslinya, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak melakukan perubahan.
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

Coba aplikasi online [**Lihat & Edit Metadata PowerPoint**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana saya dapat menghapus properti built-in dari sebuah presentasi?**

Properti built-in adalah bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diperbolehkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) dan kemudian [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Lihat [Bangun Inventaris Presentasi Ringan](/slides/id/androidjava/examine-presentation/) untuk contoh pelaporan lengkap dan batasan format khusus.

**Apakah saya dapat membaca properti publik dari presentasi yang dienkripsi tanpa password pembukanya?**

Ya. Presentasi harus dienkripsi setelah memanggil [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) dengan `false`, dan harus dimuat setelah memanggil [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) dengan `true`.

**Apakah saya dapat memperbarui file PPTX yang dienkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan seluruh presentasi dengan password pembuka yang benar.