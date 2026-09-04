---
title: Lindungi Presentasi dengan Password di Android
linktitle: Proteksi Password
type: docs
weight: 20
url: /id/androidjava/password-protected-presentation/
keywords:
- presentasi yang dilindungi password
- password pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi password presentasi
- periksa password presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- Android
- Java
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi password dengan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Password pembuka mengenkripsi sebuah presentasi. Password yang benar diperlukan untuk memuat dan menampilkan konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Password pembuka berbeda dari password perlindungan penulisan. Perlindungan penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola password untuk memodifikasi presentasi, lihat [Lindungi Presentasi dengan Penulisan](/slides/id/androidjava/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan kedua format ketika perilaku berbasis berkas dan aliran penting.

## **Enkripsi Presentasi dengan Password Pembuka**

Gunakan [IProtectionManager.encrypt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) untuk menetapkan password pembuka. Kemudian gunakan [IPresentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) untuk menyimpan presentasi yang telah dienkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Biarkan Properti Dokumen Publik**

Secara default, Aspose.Slides menyertakan properti dokumen dalam enkripsi presentasi. Metode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) mengontrol perilaku ini secara independen dari enkripsi konten slide. Berikan `false` sebelum memanggil [IProtectionManager.encrypt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa password pembuka.

Contoh berikut membuat presentasi PPTX yang dienkripsi sambil membiarkan properti dokumen bawaan tetap publik:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memberikan `false` ke [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) tidak membuat slide, master, tata letak, bentuk, media, atau konten presentasi lainnya menjadi publik. Ini hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten yang dienkripsi, lihat [Kelola Properti Presentasi](/slides/id/androidjava/presentation-properties/).

## **Muat Presentasi yang Dienkripsi**

Setel [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ke password pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) saat memuat berkas. Pemuatan gagal ketika password pembuka diperlukan tetapi password yang diberikan hilang atau salah.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang sudah didekripsi.
} finally {
    presentation.dispose();
}
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan password pembukanya, panggil [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) , dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa password.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validasi Password Pembuka Sebelum Memuat**

Gunakan [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) untuk memperoleh [IPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) sebelum meminta atau memvalidasi password. Ketika perlindungan ada, validasi nilai yang diberikan dengan [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Alur Kerja Jalur Berkas**

Contoh berikut memvalidasi password pembuka untuk berkas PPTX, meneruskan nilai yang telah divalidasi ke [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), dan kemudian memuat presentasi lengkap:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Alur Kerja Aliran**

Overload aliran dari [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) menyediakan alur kerja yang sama. Atur ulang posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

Contoh berikut menggunakan berkas PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Nilai Kembali checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) mengembalikan `true` hanya ketika presentasi memiliki password pembuka dan password yang diberikan benar. Ia mengembalikan `false` dalam masing‑masing kasus berikut:

- Password salah.
- Presentasi tidak memiliki password pembuka.
- Password yang diberikan `null` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Dienkripsi**

Setelah memuat presentasi dengan password yang benar, periksa [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) untuk memastikan bahwa presentasi sumber memang dienkripsi. Untuk mendeteksi perlindungan password pembuka sebelum memuat, gunakan `IPresentationInfo.isPasswordProtected` seperti yang ditunjukkan di atas.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Keamanan" %}}
Jangan mencatat password pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan password dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil saat langsung memuat presentasi.

Properti dokumen publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom meskipun konten presentasi dienkripsi. Enkripsi metadata sensitif bersama presentasi. Membiarkan properti publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasi, mencari, atau mengelola berkas tanpa password pembuka.
{{% /alert %}}

## **Lindungi Presentasi dengan Password Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
2. Pilih atau unggah presentasi.
3. Masukkan password untuk perlindungan tampilan.
4. Opsional, masukkan password terpisah untuk perlindungan penyuntingan.
5. Terapkan perlindungan dan unduh berkas hasilnya.

{{% alert color="info" title="Lihat juga" %}}
- [Lindungi Presentasi dengan Penulisan](/slides/id/androidjava/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara password pembuka dan password perlindungan penulisan?**

Password pembuka mengenkripsi presentasi dan diperlukan untuk memuat isinya. Password perlindungan penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi password pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan password pembuka ada, dan validasi password sebelum membuat instance presentasi lengkap.

**Bisakah aplikasi membaca metadata tanpa password pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan enkripsi properti dokumen dinonaktifkan. Aplikasi harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan di [Kelola Properti Presentasi](/slides/id/androidjava/presentation-properties/).

**Apakah alur kerja pemeriksaan password mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi password berbasis jalur berkas atau aliran berperilaku sama untuk presentasi PPT dan PPTX.