---
title: Proteksi Tulis Presentasi dalam JavaScript
linktitle: Proteksi Tulis
type: docs
weight: 25
url: /id/nodejs-java/write-protected-presentation/
keywords:
- proteksi tulis
- Proteksi Tulis PowerPoint
- kata sandi untuk mengubah
- batasi penyuntingan presentasi
- hapus proteksi tulis
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi proteksi tulis pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk Node.js via Java."
---
## **Pendahuluan**

Kata sandi proteksi tulis membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi tulisan tanpa kata sandi. Tergantung pada aplikasi, mereka juga dapat mengedit konten dan menyimpannya dengan nama yang berbeda, sehingga proteksi tulis tidak boleh dianggap sebagai mekanisme kerahasiaan.

Kata sandi pembukaan berfungsi dengan tujuan berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi kata sandi pembukaan, lihat [Password-Protect Presentations](/slides/id/nodejs-java/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; ketika menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Proteksi Tulis pada Presentasi**

Gunakan [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) untuk menetapkan kata sandi bagi modifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan proteksi.

Contoh berikut mengatur proteksi tulis pada presentasi PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Muat Presentasi yang Diproteksi Tulis**

Karena proteksi tulis tidak mengenkripsi konten presentasi, tidak diperlukan kata sandi untuk memuat presentasi. Kata sandi hanya relevan ketika memvalidasi otorisasi untuk mengubah presentasi yang dilindungi.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Jangan mengirimkan kata sandi proteksi tulisan ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword). Metode tersebut menerima kata sandi pembukaan untuk konten yang dienkripsi. Jika sebuah presentasi memiliki kedua jenis proteksi, berikan kata sandi pembukaan untuk memuatnya dan tangani kata sandi proteksi tulisan secara terpisah.

## **Hapus Proteksi Tulis dari Presentasi**

Gunakan [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Periksa Apakah Presentasi Diproteksi Tulis**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) secara lengkap, panggil [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) dan periksa [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Metode ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/nullablebool/) dan mengembalikan `NullableBool.True` ketika proteksi tulis terdeteksi.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Metode berbasis stream [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) memberikan informasi yang sama untuk presentasi yang disediakan sebagai stream dapat dibaca Node.js.

## **Validasi Kata Sandi Proteksi Tulis**

Gunakan [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) untuk memvalidasi kata sandi modifikasi tanpa memuat presentasi secara lengkap. Periksa [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) terlebih dahulu agar aplikasi meminta atau memvalidasi kata sandi hanya ketika proteksi tulis ada.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) hanya memvalidasi kata sandi proteksi tulis. Ia tidak memvalidasi kata sandi pembukaan atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#checkPassword) hanya memvalidasi kata sandi pembukaan. Jika sebuah presentasi lengkap sudah dimuat, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) menyediakan pemeriksaan proteksi tulis yang setara melalui manajer proteksinya.

Dalam aplikasi produksi, jangan mencatat kata sandi atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, dan simpan kata sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="Lihat Juga" %}}
- [Proteksi Kata Sandi pada Presentasi](/slides/id/nodejs-java/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/nodejs-java/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Tanya Jawab**

**Apakah proteksi tulis mengenkripsi sebuah presentasi?**

Tidak. Ini membatasi modifikasi tetapi membiarkan konten presentasi tetap dapat dimuat dan dilihat.

**Apakah kata sandi proteksi tulis diperlukan untuk membuka presentasi?**

Tidak. Hanya kata sandi pembukaan yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki kata sandi pembukaan dan kata sandi proteksi tulis sekaligus?**

Ya. Berikan kata sandi pembukaan melalui opsi muat untuk membuka presentasi yang terenkripsi, dan validasi kata sandi proteksi tulis secara terpisah ketika otorisasi modifikasi diperlukan.