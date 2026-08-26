---
title: Proteksi Password pada Presentasi di JavaScript
linktitle: Proteksi Password
type: docs
weight: 20
url: /id/nodejs-java/password-protected-presentation/
keywords:
- presentasi terlindungi password
- password pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi password presentasi
- cek password presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, membuka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi password dalam JavaScript dengan Aspose.Slides."
---
## **Gambaran Umum**

Password pembuka mengenkripsi presentasi. Password yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Password pembuka berbeda dari password perlindungan tulis. Perlindungan tulis membatasi perubahan tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola password bagi modifikasi presentasi, lihat [Write-Protect Presentations](/slides/id/nodejs-java/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan kedua format ketika perilaku berbasis file dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Password Pembuka**

Gunakan [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#encrypt) untuk menetapkan password pembuka. Kemudian gunakan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk menyimpan presentasi yang telah dienkripsi.

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

## **Muat Presentasi yang Dienkripsi**

Setel [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword) ke password pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) saat memuat file. Pemuatan gagal ketika password pembuka diperlukan tetapi password yang diberikan tidak ada atau salah.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang telah didekripsi.
} finally {
    presentation.dispose();
}
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan password pembukanya, panggil [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#removeEncryption), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa password.

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

## **Validasi Password Pembuka Sebelum Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk memperoleh [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) sebelum meminta atau memvalidasi password. Ketika perlindungan ada, validasi nilai yang diberikan dengan [PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Alur Kerja Jalur File**

Contoh berikut memvalidasi password pembuka untuk file PPTX, meneruskan nilai yang sudah divalidasi ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword), dan kemudian memuat presentasi lengkap:

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

### **Alur Kerja Aliran**

Gunakan [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) untuk memeriksa aliran dapat baca Node.js. Setelah aliran inspeksi dikonsumsi, buat aliran baru sebelum memuat presentasi lengkap dengan [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkPassword) mengembalikan `true` hanya ketika presentasi memiliki password pembuka dan password yang diberikan benar. Ia mengembalikan `false` dalam masing‑mata kasus berikut:

- Password salah.
- Presentasi tidak memiliki password pembuka.
- Password yang diberikan `null` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Telah Dienkripsi**

Setelah memuat presentasi dengan password yang benar, periksa [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) untuk memastikan bahwa presentasi sumber telah dienkripsi. Untuk mendeteksi perlindungan password pembuka sebelum memuat, gunakan [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) seperti yang ditunjukkan di atas.

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
Jangan mencatat password pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan password dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil saat langsung memuat presentasi.
{{% /alert %}}

## **Lindungi Presentasi dengan Password Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
1. Pilih atau unggah presentasi.
1. Masukkan password untuk perlindungan tampilan.
1. Opsional, masukkan password terpisah untuk perlindungan edit.
1. Terapkan perlindungan dan unduh file hasilnya.

{{% alert color="info" title="Lihat juga" %}}
- [Write-Protect Presentations](/slides/id/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/id/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara password pembuka dan password perlindungan tulis?**

Password pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Password perlindungan tulis membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi password pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah ada perlindungan password pembuka, dan validasi password sebelum membuat instance presentasi lengkap.

**Apakah alur kerja pemeriksaan password mendukung baik PPT maupun PPTX?**

Ya. Deteksi dan validasi password berbasis jalur file maupun aliran berperilaku sama untuk presentasi PPT dan PPTX.