---
title: Tambahkan Tanda Tangan Digital ke Presentasi dalam Python
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Python via .NET untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani sebuah presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang tepercaya dapat mengeluarkan sertifikat, atau suatu organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Proteksi kata sandi** mengontrol apakah pengguna dapat membuka atau mengubah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan dalam [Presentasi Dilindungi Kata Sandi](/python-net/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Proteksi Presentasi PowerPoint dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah sebuah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides menampilkan tanda tangan melalui [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/), sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/) yang elemennya adalah objek [DigitalSignature](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi beberapa tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, yang juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadi, dan rantai sertifikat. Kunci pribadi memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Ini **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan mengunggah file PFX atau kata sandinya ke kontrol sumber. Di lingkungan produksi, batasi akses ke file sertifikat dan peroleh kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari penyematan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang tidak ditandatangani. Nilai [DigitalSignature.comments](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/comments/) menjelaskan tujuan tanda tangan; ini bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item dalam [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/). Properti [DigitalSignature.is_valid](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/is_valid/) menunjukkan apakah tanda tangan yang tertanam valid untuk konten presentasi saat ini.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Hasil tidak valid biasanya berarti bahwa konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya keabsahan item tidak cukup: alur kerja yang sensitif keamanan juga harus memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Properti [DigitalSignature.certificate](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/certificate/) menyediakan data sertifikat sebagai array byte. Contoh menghitung sidik jari SHA‑256 sehingga aplikasi dapat membandingkannya dengan sidik jari sertifikat penandatangan yang diharapkan.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Tergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku dan status pencabutan sertifikat, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp yang tepercaya. Nilai [DigitalSignature.sign_time](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/sign_time/) sendiri bukan bukti dari otoritas timestamp yang tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/remove_at/) dengan indeks berbasis nolnya. Simpan ke file baru kecuali menimpa file asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Penyuntingan dan Format**

- Sebuah tanda tangan tidak membuat presentasi menjadi read‑only. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid.
- Selesaikan semua penyuntingan yang dimaksudkan sebelum menandatangani. Jika sebuah presentasi harus diubah, simpan presentasi yang direvisi dan tandatangani revisi tersebut lagi.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkendali lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [proteksi kata sandi](/python-net/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila menyertakan kunci pribadi yang dapat diakses. Penerima tidak akan otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang dikeluarkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan berisi tanda tangan yang tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak secara otomatis. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp tepercaya.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah sebuah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah ada timestamp tepercaya yang membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan mengandalkan waktu penandatanganan yang ditampilkan saja sebagai timestamp tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid, jadi selesaikan presentasi terlebih dahulu dan tandatangani revisi akhir.

**Dapatkah sebuah presentasi berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi apa yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau membersihkan seluruh koleksi kemudian menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.