---
title: Presentasi dengan Proteksi Kata Sandi di Python
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/python-java/password-protected-presentation/
keywords:
- presentasi terlindungi kata sandi
- kata sandi pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi kata sandi presentasi
- periksa kata sandi presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- Python
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, membuka, dan mendekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi kata sandi dengan Aspose.Slides untuk Python melalui Java."
---
## **Gambaran Umum**

Kata sandi pembuka mengenkripsi presentasi. Kata sandi yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Kata sandi pembuka berbeda dari kata sandi perlindungan penulisan. Perlindungan penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola kata sandi bagi modifikasi presentasi, lihat [Presentasi yang Dilindungi Penulisan](/slides/id/python-java/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh-contoh menggunakan kedua format tersebut dimana perilaku berbasis file dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Kata Sandi Pembuka**

Gunakan [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#encrypt) untuk menetapkan kata sandi pembuka. Kemudian gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menyimpan presentasi yang terenkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Biarkan Properti Dokumen Publik**

Secara default, Aspose.Slides memasukkan properti dokumen dalam enkripsi presentasi. Metode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) mengontrol perilaku ini secara terpisah dari enkripsi konten slide. Berikan `False` sebelum memanggil [ProtectionManager.encrypt](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#encrypt) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa kata sandi pembuka.

Contoh berikut membuat presentasi PPTX terenkripsi sambil membiarkan properti dokumen bawaannya tetap publik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Memberikan `False` ke [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) tidak membuat slide, master, tata letak, bentuk, media, atau konten presentasi lainnya menjadi publik. Ini hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten terenkripsi, lihat [Kelola Properti Presentasi](/slides/id/python-java/presentation-properties/).

## **Muat Presentasi yang Terenkripsi**

Setel [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword) ke kata sandi pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) saat memuat file. Memuat akan gagal bila kata sandi pembuka diperlukan tetapi kata sandi yang diberikan hilang atau salah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Bekerja dengan presentasi yang telah didekripsi.
    pass
finally:
    presentation.dispose()
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan kata sandi pembukanya, panggil [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#removeEncryption), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa kata sandi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Validasi Kata Sandi Pembuka Sebelum Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk mendapatkan [PresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#isPasswordProtected) sebelum meminta atau memvalidasi kata sandi. Ketika perlindungan ada, validasi nilai yang diberikan dengan [PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Alur Kerja Jalur Berkas**

Contoh berikut memvalidasi kata sandi pembuka untuk file PPTX, mengirimkan nilai yang telah divalidasi ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword), dan kemudian memuat presentasi lengkap:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Alur Kerja Aliran**

Versi overload aliran dari [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) menyediakan alur kerja yang sama. Atur ulang posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

Contoh berikut menggunakan file PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Nilai Kembali checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#checkPassword) mengembalikan `True` hanya ketika presentasi memiliki kata sandi pembuka dan kata sandi yang diberikan benar. Ini mengembalikan `False` dalam masing‑masing kasus berikut:

- Kata sandi tidak tepat.
- Presentasi tidak memiliki kata sandi pembuka.
- Kata sandi yang diberikan adalah `None` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Terenkripsi**

Setelah memuat presentasi dengan kata sandi yang benar, periksa [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isEncrypted) untuk memastikan bahwa presentasi sumber telah dienkripsi. Untuk mendeteksi perlindungan kata sandi pembuka sebelum memuat, gunakan [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#isPasswordProtected) seperti yang ditunjukkan di atas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Keamanan" %}}
Jangan mencatat kata sandi pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan kata sandi dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil saat langsung memuat presentasi.

Properti dokumen publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai khusus meskipun konten presentasi dienkripsi. Enkripsi metadata sensitif bersama dengan presentasi. Membiarkan properti publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasi, mencari, atau mengelola file tanpa kata sandi pembuka.
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi secara Online**

1. Buka aplikasi Aspose.Slides Lock.
1. Pilih atau unggah presentasi.
1. Masukkan kata sandi untuk perlindungan tampilan.
1. Opsional, masukkan kata sandi terpisah untuk perlindungan pengeditan.
1. Terapkan perlindungan dan unduh file hasilnya.

{{% alert color="info" title="Lihat juga" %}}
- [Presentasi yang Dilindungi Penulisan](/slides/id/python-java/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Tanya Jawab**

**Apa perbedaan antara kata sandi pembuka dan kata sandi perlindungan penulisan?**

Kata sandi pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Kata sandi perlindungan penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi kata sandi pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan kata sandi pembuka ada, dan validasi kata sandi sebelum membuat instance presentasi lengkap.

**Apakah aplikasi dapat membaca metadata tanpa kata sandi pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan enkripsi properti dokumen dinonaktifkan. Aplikasi kemudian harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan dalam [Kelola Properti Presentasi](/slides/id/python-java/presentation-properties/).

**Apakah alur kerja pemeriksaan kata sandi mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi kata sandi berbasis jalur berkas maupun aliran berperilaku sama untuk presentasi PPT dan PPTX.