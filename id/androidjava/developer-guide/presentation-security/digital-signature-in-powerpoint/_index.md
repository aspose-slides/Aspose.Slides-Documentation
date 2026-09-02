---
title: Menambahkan Tanda Tangan Digital ke Presentasi di Android
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Android via Java untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Ringkasan**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) tepercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; ia tidak mengenkripsi presentasi.
- **Proteksi kata sandi** mengontrol apakah pengguna dapat membuka atau mengubah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan dalam [Password-Protected Presentations](/androidjava/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), yang mengembalikan sebuah [IDigitalSignatureCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignaturecollection/) yang elemennya mengimplementasikan [IDigitalSignature](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignature/). Sebuah presentasi dapat berisi beberapa tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadi, dan rantai sertifikat. Kunci pribadi adalah apa yang memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Itu **bukan** kata sandi untuk membuka atau menyunting presentasi. Jangan meng-commit file PFX atau kata sandinya ke kontrol sumber. Dalam produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini hanya menggunakan variabel lingkungan untuk menghindari menanamkan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai yang ditetapkan oleh [IDigitalSignature.setComments](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Memvalidasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, inspeksi setiap item yang dikembalikan oleh [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metode [IDigitalSignature.isValid](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignature/#isValid--) menunjukkan apakah tanda tangan yang tertanam valid untuk konten presentasi saat ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Hasil tidak valid biasanya berarti bahwa konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif keamanan juga harus memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi stempel waktu tepercaya. Nilai [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) sendiri bukan bukti dari otoritas stempel waktu tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), dan menyimpan salinan yang tidak ditandatangani.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghapus hanya satu tanda tangan, panggil [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa yang asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak menjadikan presentasi hanya-baca. Pengguna dan aplikasi masih dapat menyunting file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid.
- Selesaikan semua penyuntingan yang dimaksudkan sebelum menandatangani. Jika presentasi harus diubah, simpan presentasi yang direvisi dan tanda tangani revisi tersebut kembali.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai data sensitif. Siapapun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkendali lain ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/androidjava/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau menyunting file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila menyertakan kunci pribadi yang dapat diakses. Penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang diterbitkan oleh CA tepercaya.

**Apa yang membuat tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan file yang berisi tanda tangan tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan stempel waktu tepercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah stempel waktu tepercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan mengandalkan waktu penandatanganan yang ditampilkan saja sebagai stempel waktu tepercaya.

**Apakah presentasi yang ditandatangani masih dapat disunting?**

Ya. Penandatanganan tidak mengunci file. Menyunting konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid, jadi selesaikan presentasi terlebih dahulu dan tanda tangani revisi final.

**Bisakah sebuah presentasi berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) sebelum menyimpan. Selama validasi, inspeksi setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi mana yang mendukung operasi ini?**

Aspose.Slides hanya mendukung operasi tanda tangan digital yang dijelaskan di sini untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi, lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.