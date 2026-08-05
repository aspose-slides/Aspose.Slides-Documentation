---
title: Tambahkan Tanda Tangan Digital ke Presentasi di PHP
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk PHP via Java untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) tepercaya dapat menerbitkan sertifikat, atau sebuah organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Proteksi kata sandi** mengontrol apakah pengguna dapat membuka atau memodifikasi presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Presentasi Dilindungi Kata Sandi](/php-java/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Lindungi Presentasi PowerPoint dengan Tambah Tanda Tangan Digital disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures), yang mengembalikan sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignaturecollection/) yang item‑nya direpresentasikan oleh objek [DigitalSignature](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi banyak tanda tangan.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang tidak ditandatangani. Nilai yang ditetapkan oleh [DigitalSignature::setComments](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/setcomments/) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures). Metode [DigitalSignature::isValid](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/isvalid/) menunjukkan apakah tanda tangan yang tertanam valid untuk konten presentasi saat ini.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya keabsahan item tidak cukup: alur kerja yang sensitif keamanan juga harus memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan tersedia.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Tergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp terpercaya. Nilai [DigitalSignature::getSignTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/getsigntime/) sendiri bukan bukti dari otoritas timestamp terpercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignaturecollection/removeat/) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa file asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi hanya‑baca. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid.
- Selesaikan semua pengeditan yang dimaksudkan sebelum menandatangani. Jika presentasi harus diubah, simpan revisi yang diperbarui dan tandatangani revisi tersebut kembali.
- Pertahankan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Anggap kunci pribadi sertifikat sebagai informasi sensitif. Siapa pun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkontrol lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **Tanya Jawab**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [proteksi kata sandi](/php-java/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila menyertakan kunci pribadi yang dapat diakses. Penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang dikeluarkan oleh CA tepercaya.

**Apa yang membuat tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Korupsi file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan berisi tanda tangan yang tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp terpercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima bergantung pada kebijakan Anda dan apakah timestamp terpercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan mengandalkan waktu penandatangan yang ditampilkan saja sebagai timestamp terpercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid, sehingga selesaikan presentasi terlebih dahulu dan tandatangani revisi akhir.

**Dapatkah sebuah presentasi berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan hadir.

**Format presentasi mana yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi lalu menyimpan presentasi. Konten slide tetap ada, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.