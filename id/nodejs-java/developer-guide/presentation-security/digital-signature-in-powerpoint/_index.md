---
title: Tambahkan Tanda Tangan Digital ke Presentasi dalam JavaScript
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/nodejs-java/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PKCS#12
- validasi tanda tangan
- PowerPoint
- PPTX
- keamanan presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Node.js via Java untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Ikhtisar**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani sebuah presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- Sebuah **digital certificate** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang tepercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- Sebuah **digital signature** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Password protection** mengontrol apakah pengguna dapat membuka atau mengubah sebuah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Presentasi yang Dilindungi Kata Sandi](/slides/id/nodejs-java/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Proteksi Presentasi PowerPoint dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), yang mengembalikan sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignaturecollection/) yang berisi objek [DigitalSignature](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi banyak tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadi, dan rantai sertifikat. Kunci pribadi lah yang memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani sebuah presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Itu **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan meng-commit file PFX atau kata sandinya ke kontrol sumber. Di produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari menanamkan kata sandi di dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang sesungguhnya, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang tidak ditandatangani. Nilai yang diatur oleh [DigitalSignature.setComments](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignature/) menggambarkan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metode [DigitalSignature.isValid](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignature/) menunjukkan apakah tanda tangan yang tersemat valid untuk konten presentasi saat ini.

Contoh berikut juga menggunakan kelas Node.js `X509Certificate` untuk membaca nama subjek dari setiap sertifikat yang tersemat.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Hasil tidak valid biasanya berarti bahwa konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif terhadap keamanan harus juga memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Tergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp tepercaya. Nilai [DigitalSignature.getSignTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignature/) sendiri bukan bukti dari otoritas timestamp tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa yang asli yang ditandatangani adalah bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi hanya-baca. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua edit yang dimaksudkan sebelum menandatangani. Jika presentasi harus diubah, simpan presentasi yang direvisi dan tanda tangani revisi tersebut lagi.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai data sensitif. Siapa pun yang mendapatkan kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkontrol lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [Proteksi Kata Sandi](/slides/id/nodejs-java/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Apakah saya dapat menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan jika menyertakan kunci pribadi yang dapat diakses. Penerima tidak akan mempercayainya secara otomatis, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang diterbitkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Korupsi file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani bukan file yang berisi tanda tangan tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi sebaiknya juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp tepercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah ada timestamp tepercaya yang membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan bergantung pada waktu penandatangan yang ditampilkan saja sebagai timestamp tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani umumnya membuat tanda tangan yang ada menjadi tidak valid, jadi selesaikan presentasi terlebih dahulu dan tandatangani revisi final.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi mana yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Apakah saya dapat menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi dan kemudian menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.