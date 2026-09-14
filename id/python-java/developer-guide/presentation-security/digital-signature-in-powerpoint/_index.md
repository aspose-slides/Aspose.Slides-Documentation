---
title: Menambahkan Tanda Tangan Digital ke Presentasi dengan Python
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/python-java/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PKCS#12
- memvalidasi tanda tangan
- PowerPoint
- PPTX
- keamanan presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Python melalui Java untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait yang penting di sini:

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang tepercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Proteksi kata sandi** mengontrol apakah pengguna dapat membuka atau memodifikasi presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan dalam [Presentasi dengan Perlindungan Kata Sandi](/slides/id/python-java/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDigitalSignatures), yang mengembalikan sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignaturecollection/) yang elemennya merupakan instance dari [DigitalSignature](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi banyak tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci privatnya, dan rantai sertifikat. Kunci privatlah yang memungkinkan pemiliknya membuat tanda tangan. Sertifikat tanpa kunci privat yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci privat. Ini **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan mengkomit file PFX atau kata sandinya ke kontrol sumber. Di produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah menggunakan variabel lingkungan hanya untuk menghindari penyisipan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai yang diatur oleh [DigitalSignature.setComments](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignature/#setComments) menjelaskan tujuan tanda tangan; ini bukan kontrol keamanan.

## **Memvalidasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item yang dikembalikan oleh [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDigitalSignatures). Metode [DigitalSignature.isValid](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignature/#isValid) menunjukkan apakah tanda tangan tersemat valid untuk konten presentasi saat ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, jadi memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif keamanan harus juga memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh dianggap sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp tepercaya. Nilai [DigitalSignature.getSignTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignature/#getSignTime) sendiri bukan bukti dari otoritas timestamp tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignaturecollection/#clear), dan menyimpan salinan yang tidak ditandatangani.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/digitalsignaturecollection/#removeAt) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa yang asli ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi baca-saja. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua pengeditan yang dimaksudkan sebelum menandatangani. Jika presentasi harus diubah, simpan presentasi yang direvisi dan tandatangani revisi tersebut lagi.
- Pertahankan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci privat sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci privat dan kata sandinya dapat membuat tanda tangan yang tampaknya berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang belum ditandatangani atau salinan terkontrol lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [presentasi dengan perlindungan kata sandi](/slides/id/python-java/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci privat yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila mencakup kunci privat yang dapat diakses. Penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang dikeluarkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan file yang berisi tanda tangan tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, masa berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp tepercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsaan sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah timestamp tepercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan hanya mengandalkan waktu penandatanganan yang ditampilkan sebagai timestamp tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani umumnya membuat tanda tangan yang ada tidak valid, jadi selesaikan presentasi terlebih dahulu dan tandatangani revisi final.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke koleksi yang dikembalikan oleh [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDigitalSignatures) sebelum menyimpan. Selama validasi, inspeksi setiap tanda tangan dan pastikan semua penandatangan yang diperlukan hadir.

**Format presentasi apa yang mendukung operasi ini?**

Aspose.Slides hanya mendukung operasi tanda tangan digital yang dijelaskan di sini untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi, lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.