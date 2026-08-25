---
title: Tambahkan Tanda Tangan Digital ke Presentasi dalam C++
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk C++ untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- Sebuah **digital certificate** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) tepercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- Sebuah **digital signature** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Password protection** mengontrol apakah pengguna dapat membuka atau memodifikasi sebuah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan dalam [Password-Protected Presentations](/slides/id/cpp/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Protect Presentation PowerPoint dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_digitalsignatures/), yang mengembalikan sebuah [IDigitalSignatureCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignaturecollection/), yang elemennya mengimplementasikan [IDigitalSignature](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignature/). Sebuah presentasi dapat berisi beberapa tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, yang juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadi, dan rantai sertifikat. Kunci pribadi adalah yang memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Itu **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan meng-commit file PFX atau kata sandinya ke kontrol sumber. Dalam produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari penyisipan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang sebenarnya, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/cpp/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignature/set_comments/) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Ketika Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Metode [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignature/get_isvalid/) menunjukkan apakah tanda tangan yang tertanam valid untuk konten presentasi saat ini.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Hasil tidak valid biasanya berarti bahwa konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, jadi memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif terhadap keamanan juga harus memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal validitas sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi cap waktu tepercaya. Nilai [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignature/get_signtime/) sendiri bukan bukti dari otoritas cap waktu tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk menghapus hanya satu tanda tangan, panggil [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/idigitalsignaturecollection/removeat/) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa file asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi hanya-baca. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid.
- Selesaikan semua edit yang dimaksud sebelum menandatangani. Jika presentasi harus diubah, simpan presentasi yang direvisi dan tanda tangani revisi tersebut lagi.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai sensitif. Siapa pun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkontrol lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital menyediakan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/slides/id/cpp/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila mencakup kunci pribadi yang dapat diakses. Namun, penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi umumnya menggunakan sertifikat yang diterbitkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Korupsi file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan file yang berisi tanda tangan tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi sebaiknya juga memeriksa rantai sertifikat, periode validitas, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan cap waktu tepercaya apa pun.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah cap waktu tepercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih valid. Jangan mengandalkan waktu penandatanganan yang ditampilkan saja sebagai cap waktu tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid, jadi selesaikan presentasi terlebih dahulu dan tanda tangani revisi final.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_digitalsignatures/) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi mana yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format presentasi PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Apakah saya dapat menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.