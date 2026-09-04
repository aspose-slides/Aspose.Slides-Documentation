---
title: Presentasi Proteksi Password di Python
linktitle: Proteksi Password
type: docs
weight: 20
url: /id/python-net/password-protected-presentation/
keywords:
- presentasi terlindungi password
- password pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi password presentasi
- periksa password presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- Python
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi password di Python dengan Aspose.Slides."
---
## **Ringkasan**

Password pembuka mengenkripsi presentasi. Password yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Password pembuka berbeda dari password perlindungan tulis. Perlindungan tulis membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola password untuk memodifikasi presentasi, lihat [Write-Protect Presentations](/slides/id/python-net/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh-contoh menggunakan kedua format tersebut ketika perilaku berbasis file dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Password Pembuka**

Gunakan [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/encrypt/) untuk menetapkan password pembuka. Kemudian gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) untuk menyimpan presentasi yang terenkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Biarkan Properti Dokumen Publik**

Secara default, Aspose.Slides menyertakan properti dokumen dalam enkripsi presentasi. Properti [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) mengontrol perilaku ini secara terpisah dari enkripsi konten slide. Atur ke `False` sebelum memanggil [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/encrypt/) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa password pembuka.

Contoh berikut membuat presentasi PPTX terenkripsi sambil membiarkan properti dokumen bawaan tetap publik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Menetapkan `encrypt_document_properties` ke `False` tidak membuat slide, master, layout, shape, media, atau konten presentasi lainnya menjadi publik. Ini hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten terenkripsi, lihat [Manage Presentation Properties](/slides/id/python-net/presentation-properties/).

## **Muat Presentasi yang Terenkripsi**

Atur [LoadOptions.password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/) ke password pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) saat memuat file. Proses pemuatan gagal bila password pembuka diperlukan tetapi password yang diberikan hilang atau salah.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Bekerja dengan presentasi yang didekripsi.
    pass
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan password pembukanya, panggil [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/remove_encryption/), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa password.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Validasi Password Pembuka Sebelum Memuat**

Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) untuk memperoleh [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/is_password_protected/) sebelum meminta atau memvalidasi password. Ketika perlindungan ada, validasi nilai yang diberikan dengan [PresentationInfo.check_password](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/check_password/).

### **Alur Kerja Jalur Berkas**

Contoh berikut memvalidasi password pembuka untuk file PPTX, meneruskan nilai yang telah divalidasi ke [LoadOptions.password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/), dan kemudian memuat presentasi lengkap:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Alur Kerja Aliran**

Overload aliran dari [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) menyediakan alur kerja yang sama. Atur ulang posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

Contoh berikut menggunakan file PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Nilai Kembalian CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/check_password/) mengembalikan `True` hanya ketika presentasi memiliki password pembuka dan password yang diberikan benar. Ini mengembalikan `False` pada masing-masing kasus berikut:

- Password salah.
- Presentasi tidak memiliki password pembuka.
- Password yang diberikan adalah `None` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Terenkripsi**

Setelah memuat presentasi dengan password yang benar, periksa [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/is_encrypted/) untuk mengonfirmasi bahwa presentasi sumber terenkripsi. Untuk mendeteksi perlindungan password pembuka sebelum memuat, gunakan `PresentationInfo.is_password_protected` seperti yang ditunjukkan di atas.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Security" %}}
Jangan mencatat password pembuka atau menyertakannya dalam pesan diagnostik. Hindari percobaan validasi berulang yang tidak perlu, simpan password dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika langsung memuat presentasi.

Properti dokumen publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai khusus meskipun konten presentasi terenkripsi. Enkripsi metadata sensitif bersama dengan presentasi. Membiarkan properti tetap publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasikan, mencari, atau mengelola file tanpa password pembuka.
{{% /alert %}}

## **Lindungi Presentasi dengan Password Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
1. Pilih atau unggah presentasi.
1. Masukkan password untuk perlindungan tampilan.
1. Opsional, masukkan password terpisah untuk perlindungan edit.
1. Terapkan perlindungan dan unduh file yang dihasilkan.

{{% alert color="info" title="See also" %}}
- [Proteksi Tulis Presentasi](/slides/id/python-net/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara password pembuka dan password perlindungan tulis?**

Password pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Password perlindungan tulis membatasi modifikasi tanpa mengenkripsi konten.

**Apakah saya dapat memvalidasi password pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan password pembuka ada, dan validasi password sebelum membuat instance presentasi lengkap.

**Apakah aplikasi dapat membaca metadata tanpa password pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan `encrypt_document_properties` diatur ke `False`. Aplikasi kemudian harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan di [Manage Presentation Properties](/slides/id/python-net/presentation-properties/).

**Apakah alur kerja pemeriksaan password mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi password berbasis jalur berkas maupun aliran berperilaku sama untuk presentasi PPT dan PPTX.