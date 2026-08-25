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

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang terpercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat self‑signed untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemilik sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Proteksi password** mengontrol apakah pengguna dapat membuka atau mengubah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Password‑Protected Presentations](/slides/id/php-java/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures), yang mengembalikan sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignaturecollection/) dengan item‑item yang direpresentasikan oleh objek [DigitalSignature](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi banyak tanda tangan.

## **Memahami Sertifikat PFX dan Password**

File PFX, yang juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci privatnya, serta rantai sertifikat. Kunci privatlah yang memungkinkan pemiliknya membuat tanda tangan. Sertifikat tanpa kunci privat yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Password PFX melindungi paket sertifikat dan kunci privat. Ini **bukan** password untuk membuka atau mengedit presentasi. Jangan commit file PFX atau passwordnya ke kontrol sumber. Di lingkungan produksi, batasi akses ke file sertifikat dan dapatkan passwordnya dari penyimpanan rahasia atau sumber konfigurasi yang dilindungi lainnya. Contoh di bawah menggunakan variabel lingkungan hanya untuk menghindari menanamkan password dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/) dari sertifikat PFX dan passwordnya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

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

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai yang diatur melalui [DigitalSignature::setComments](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/setcomments/) menjelaskan tujuan tanda tangan; bukan kontrol keamanan.

## **Memvalidasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures). Metode [DigitalSignature::isValid](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/isvalid/) menunjukkan apakah tanda tangan tersemat valid untuk konten presentasi saat ini.

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
                $signerName = java_values($certificate->getSubjectX5

00Principal()->getName());
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

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga hanya memeriksa validitas item tidak cukup: alur kerja yang sensitif terhadap keamanan harus juga memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh dianggap sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat serta status pencabutan, mengonfirmasi subjek atau thumbprint yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp yang terpercaya. Nilai [DigitalSignature::getSignTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignature/getsigntime/) sendiri bukan bukti dari otoritas timestamp terpercaya.

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

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/digitalsignaturecollection/removeat/) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa yang asli merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi hanya‑baca. Pengguna dan aplikasi masih dapat mengedit file, namun perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua edit yang diinginkan sebelum menandatangani. Jika presentasi harus diubah, simpan revisi yang diperbarui dan tanda tangani revisi tersebut lagi.
- Pertahankan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci privat sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci privat dan passwordnya dapat membuat tanda tangan yang tampak berasal dari pemilik sertifikat tersebut.
- Simpan sumber yang belum ditandatangani atau salinan terkendali lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/slides/id/php-java/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah password PFX sama dengan password presentasi?**

Tidak. Password PFX membuka kunci privat yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat self‑signed?**

Secara teknis, sertifikat self‑signed dapat digunakan bila menyertakan kunci privat yang dapat diakses. Penerima tidak otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan terpercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang diterbitkan oleh CA terpercaya.

**Apa yang membuat tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani bukan berisi tanda tangan yang tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp terpercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah sebuah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah timestamp terpercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih valid. Jangan bergantung pada waktu penandatangan yang ditampilkan saja sebagai timestamp terpercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid, jadi selesaikan presentasi terlebih dahulu dan tanda tangani revisi final.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDigitalSignatures) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi apa yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi, lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.