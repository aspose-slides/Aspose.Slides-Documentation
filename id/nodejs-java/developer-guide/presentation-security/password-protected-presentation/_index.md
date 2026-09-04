---
title: Proteksi Presentasi dengan Kata Sandi di JavaScript
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/nodejs-java/password-protected-presentation/
keywords:
- presentasi yang dilindungi kata sandi
- kata sandi pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi kata sandi presentasi
- periksa kata sandi presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi kata sandi di JavaScript dengan Aspose.Slides."
---
## **Gambaran Umum**

Kata sandi pembuka mengenkripsi presentasi. Kata sandi yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Kata sandi pembuka berbeda dari kata sandi proteksi penulisan. Proteksi penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola kata sandi untuk memodifikasi presentasi, lihat [Lindungi Presentasi dengan Penulisan](/slides/id/nodejs-java/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan kedua format di mana perilaku berbasis file dan aliran penting.

## **Enkripsi Presentasi dengan Kata Sandi Pembuka**

Gunakan [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#encrypt) untuk menetapkan kata sandi pembuka. Kemudian gunakan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk menyimpan presentasi terenkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Biarkan Properti Dokumen Publik**

Secara default, Aspose.Slides menyertakan properti dokumen dalam enkripsi presentasi. Metode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) mengontrol perilaku ini secara terpisah dari enkripsi konten slide. Berikan `false` sebelum memanggil [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#encrypt) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa kata sandi pembuka.

Contoh berikut membuat presentasi PPTX terenkripsi sambil membiarkan properti dokumen bawaannya publik:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memberikan `false` ke [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) tidak menjadikan slide, master, tata letak, bentuk, media, atau konten presentasi lainnya publik. Ini hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten terenkripsi, lihat [Kelola Properti Presentasi](/slides/id/nodejs-java/presentation-properties/).

## **Muat Presentasi yang Terenkripsi**

Setel [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword) ke kata sandi pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) saat memuat file. Pemuatan gagal ketika kata sandi pembuka diperlukan tetapi kata sandi yang diberikan hilang atau salah.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang didekripsi.
} finally {
    presentation.dispose();
}
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan kata sandi pembukanya, panggil [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#removeEncryption), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa kata sandi.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validasi Kata Sandi Pembuka Sebelum Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk memperoleh [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) sebelum meminta atau memvalidasi kata sandi. Ketika proteksi ada, validasikan nilai yang diberikan dengan [PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Alur Kerja Berbasis Path File**

Contoh berikut memvalidasi kata sandi pembuka untuk file PPTX, memberikan nilai yang telah divalidasi ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword), lalu memuat presentasi lengkap:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Alur Kerja Berbasis Stream**

Gunakan [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) untuk memeriksa aliran dapat dibaca Node.js. Setelah aliran inspeksi dikonsumsi, buat aliran baru sebelum memuat presentasi lengkap dengan [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Contoh berikut menggunakan file PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Nilai Kembalian checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkPassword) mengembalikan `true` hanya ketika presentasi memiliki kata sandi pembuka dan kata sandi yang diberikan benar. Ia mengembalikan `false` dalam masing‑masing kasus berikut:

- Kata sandi salah.
- Presentasi tidak memiliki kata sandi pembuka.
- Kata sandi yang diberikan `null` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Terenkripsi**

Setelah memuat presentasi dengan kata sandi yang benar, periksa [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) untuk mengonfirmasi bahwa sumber presentasi terenkripsi. Untuk mendeteksi proteksi kata sandi pembuka sebelum memuat, gunakan [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) seperti yang ditunjukkan di atas.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Keamanan" %}}
Jangan mencatat kata sandi pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan kata sandi dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika segera memuat presentasi.

Properti dokumen publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom meskipun konten presentasi terenkripsi. Enkripsilah metadata sensitif bersama dengan presentasi. Membiarkan properti publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasi, mencari, atau mengelola berkas tanpa kata sandi pembuka.
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
1. Pilih atau unggah presentasi.
1. Masukkan kata sandi untuk proteksi tampilan.
1. Opsional, masukkan kata sandi terpisah untuk proteksi pengeditan.
1. Terapkan proteksi dan unduh berkas hasil.

{{% alert color="info" title="Lihat juga" %}}
- [Lindungi Presentasi dengan Penulisan](/slides/id/nodejs-java/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara kata sandi pembuka dan kata sandi proteksi penulisan?**

Kata sandi pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Kata sandi proteksi penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi kata sandi pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah proteksi kata sandi pembuka ada, dan validasikan kata sandi sebelum membuat instance presentasi lengkap.

**Bisakah aplikasi membaca metadata tanpa kata sandi pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan enkripsi properti dokumen dinonaktifkan. Aplikasi harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan di [Kelola Properti Presentasi](/slides/id/nodejs-java/presentation-properties/).

**Apakah alur kerja pemeriksaan kata sandi mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi kata sandi berbasis path file maupun berbasis stream berperilaku sama untuk presentasi PPT dan PPTX.