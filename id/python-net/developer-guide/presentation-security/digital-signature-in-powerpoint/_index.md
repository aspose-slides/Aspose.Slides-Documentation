---
title: Menambahkan Tanda Tangan Digital ke Presentasi dengan Python
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
- memvalidasi tanda tangan
- PowerPoint
- PPTX
- keamanan presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk Python melalui .NET untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- Sertifikat **digital certificate** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) yang terpercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat **self-signed** untuk alur kerja internal.
- **Digital signature** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Password protection** mengontrol apakah pengguna dapat membuka atau memodifikasi presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Presentasi yang Dilindungi Kata Sandi](/slides/id/python-net/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu Protect Presentation PowerPoint dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspose tanda tangan melalui [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/), sebuah [DigitalSignatureCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/) yang elemennya adalah objek [DigitalSignature](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/). Sebuah presentasi dapat berisi banyak tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, yang juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci pribadi, dan rantai sertifikat. Kunci pribadi memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci pribadi yang dapat diakses tidak dapat digunakan untuk menandatangani presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci pribadi. Itu **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan meng‑commit file PFX atau kata sandinya ke kontrol versi. Di produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi yang terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari menyematkan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang nyata, muat file PPTX yang ada, buat [DigitalSignature](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

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

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai [DigitalSignature.comments](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/comments/) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Validasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item di [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/). Properti [DigitalSignature.is_valid](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/is_valid/) menunjukkan apakah tanda tangan tertanam valid untuk konten presentasi saat ini.

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

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, sehingga memeriksa hanya keabsahan item tidak cukup: alur kerja yang sensitif terhadap keamanan juga harus memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Properti [DigitalSignature.certificate](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/certificate/) menyediakan data sertifikat sebagai array byte. Contoh menghitung sidik jari SHA‑256 sehingga aplikasi dapat membandingkannya dengan sidik jari sertifikat penandatangan yang diharapkan.

Hasil keabsahan ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Bergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi cap waktu terpercaya. Nilai [DigitalSignature.sign_time](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignature/sign_time/) sendiri bukan bukti dari otoritas cap waktu terpercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Untuk menghapus hanya satu tanda tangan, panggil [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/digitalsignaturecollection/remove_at/) dengan indeks berbasis nol. Simpan ke file baru kecuali menimpa file asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat presentasi menjadi baca‑saja. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua edit yang diinginkan sebelum menandatangani. Jika presentasi harus diubah, simpan presentasi yang direvisi dan tanda tangani revisi tersebut kembali.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci pribadi sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci pribadi dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang belum ditandatangani atau salinan terkontrol lainnya bila kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/slides/id/python-net/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci pribadi yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat self‑signed?**

Secara teknis, sertifikat self‑signed dapat digunakan bila termasuk kunci pribadi yang dapat diakses. Penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan terpercaya mereka. Alur kerja publik atau lintas organisasi biasanya menggunakan sertifikat yang dikeluarkan oleh CA yang terpercaya.

**Apa yang membuat tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan berisi tanda tangan yang tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak secara otomatis. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi harus juga memeriksa rantai sertifikat, masa berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan cap waktu terpercaya apa pun.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah tanda tangan tetap dapat diterima tergantung pada kebijakan Anda dan apakah cap waktu terpercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan mengandalkan waktu penandatangan yang ditampilkan saja sebagai cap waktu terpercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada tidak valid, jadi selesaikan presentasi dulu dan tanda tangani revisi akhir.

**Bisakah sebuah presentasi berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke [Presentation.digital_signatures](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/digital_signatures/) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan pastikan semua penandatangan yang diperlukan ada.

**Format presentasi apa yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Bisakah saya menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau mengosongkan seluruh koleksi, lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.