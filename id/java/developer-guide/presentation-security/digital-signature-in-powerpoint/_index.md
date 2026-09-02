---
title: Menambahkan Tanda Tangan Digital ke Presentasi dalam Java
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Java untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- Sebuah **digital certificate** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang tepercaya dapat mengeluarkan sertifikat, atau sebuah organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- Sebuah **digital signature** dibuat dari konten presentasi dan kunci pribadi pemilik sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; ia tidak mengenkripsi presentasi.
- **Password protection** mengontrol apakah pengguna dapat membuka atau mengubah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Password-Protected Presentations](/java/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Perlindungan Presentasi PowerPoint dengan Tambah Tanda Tangan Digital disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), yang mengembalikan sebuah [IDigitalSignatureCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignaturecollection/) yang item‑nya mengimplementasikan [IDigitalSignature](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignature/). Sebuah presentasi dapat berisi beberapa tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, yang juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadinya, dan rantai sertifikat. Kunci pribadi adalah yang memungkinkan pemiliknya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Itu **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan meng-commit file PFX atau kata sandinya ke kontrol sumber. Di lingkungan produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari penyisipan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/java/com.aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```java
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

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai yang ditetapkan oleh [IDigitalSignature.setComments](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Ketika Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metode [IDigitalSignature.isValid](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignature/#isValid--) menunjukkan apakah tanda tangan yang tertanam valid untuk konten presentasi saat ini.

```java
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

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif keamanan harus juga memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp tepercaya. Nilai [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignature/#getSignTime--) sendiri bukan bukti dari otoritas timestamp tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignaturecollection/#clear--), dan menyimpan salinan yang tidak ditandatangani.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghapus hanya satu tanda tangan, panggil [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa yang asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Sebuah tanda tangan tidak membuat presentasi menjadi hanya-baca. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua pengeditan yang dimaksud sebelum menandatangani. Jika presentasi harus diubah, simpan revisi yang diperbarui dan tanda tangani revisi tersebut kembali.
- Pertahankan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemilik sertifikat tersebut.
- Simpan sumber yang belum ditandatangani atau salinan terkontrol lainnya bila kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/java/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Ia tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila menyertakan kunci pribadi yang dapat diakses. Penerima tidak akan otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang dikeluarkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan berisi tanda tangan yang tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak secara otomatis. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp tepercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah sebuah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah timestamp tepercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan bergantung pada waktu penandatangan yang ditampilkan saja sebagai timestamp tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid, jadi selesaikan presentasi terlebih dahulu dan tanda tangani revisi final.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan konfirmasi bahwa semua penandatangan yang diperlukan ada.

**Format presentasi mana yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format presentasi PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.