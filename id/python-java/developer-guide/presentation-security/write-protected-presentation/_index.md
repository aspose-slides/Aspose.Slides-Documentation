---
title: Proteksi Penulisan Presentasi dalam Python
linktitle: Proteksi Penulisan
type: docs
weight: 25
url: /id/python-java/write-protected-presentation/
keywords:
- perlindungan penulisan
- Proteksi Penulisan PowerPoint
- kata sandi untuk memodifikasi
- batasi penyuntingan presentasi
- hapus perlindungan penulisan
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi perlindungan penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk Python melalui Java."
---
## **Pendahuluan**

Password perlindungan penulisan membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi tulis tanpa password. Tergantung pada aplikasi, mereka juga dapat mengedit konten dan menyimpannya dengan nama yang berbeda, sehingga perlindungan penulisan tidak boleh dianggap sebagai mekanisme kerahasiaan.

Password pembukaan berfungsi untuk tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi password pembukaan, lihat [Proteksi Kata Sandi pada Presentasi](/slides/id/python-java/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; saat menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Tetapkan Perlindungan Penulisan pada Presentasi**

Gunakan [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#setWriteProtection) untuk menetapkan password untuk memodifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan perlindungan.

Contoh berikut menetapkan perlindungan penulisan pada presentasi PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Muat Presentasi yang Dilindungi Penulisan**

Karena perlindungan penulisan tidak mengenkripsi konten presentasi, tidak diperlukan password untuk memuat presentasi. Password hanya relevan saat memvalidasi otorisasi untuk memodifikasi presentasi yang dilindungi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Jangan mengirimkan password perlindungan penulisan ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword). Metode tersebut menerima password pembukaan untuk konten terenkripsi. Jika sebuah presentasi memiliki kedua tipe perlindungan, berikan password pembukaan untuk memuatnya dan tangani password perlindungan penulisan secara terpisah.

## **Hapus Perlindungan Penulisan dari Presentasi**

Gunakan [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#removeWriteProtection) untuk menghapus pembatasan modifikasi, kemudian simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) lengkap, panggil [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) dan periksa [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#isWriteProtected). Metode ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/) dan mengembalikan `NullableBool.True_` ketika perlindungan penulisan terdeteksi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Overload stream dari [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) menyediakan informasi yang sama untuk presentasi yang diberikan sebagai aliran.

## **Validasi Password Perlindungan Penulisan**

Gunakan [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#checkWriteProtection) untuk memvalidasi password modifikasi tanpa memuat presentasi lengkap. Periksa [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#isWriteProtected) terlebih dahulu sehingga aplikasi hanya meminta atau memvalidasi password ketika perlindungan penulisan ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#checkWriteProtection) hanya memvalidasi password perlindungan penulisan. Ia tidak memvalidasi password pembukaan atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#checkPassword) hanya memvalidasi password pembukaan. Jika sebuah presentasi lengkap sudah dimuat, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#checkWriteProtection) menyediakan pemeriksaan perlindungan penulisan yang setara melalui manajer perlindungannya.

Dalam aplikasi produksi, jangan mencatat password atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi yang berulang tanpa kebutuhan, dan simpan password dalam memori hanya selama diperlukan.

{{% alert color="info" title="Lihat juga" %}}
- [Proteksi Kata Sandi pada Presentasi](/slides/id/python-java/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/python-java/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah perlindungan penulisan mengenkripsi sebuah presentasi?**

Tidak. Itu membatasi modifikasi tetapi tetap membuat konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah password perlindungan penulisan diperlukan untuk membuka sebuah presentasi?**

Tidak. Hanya password pembukaan yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki password pembukaan dan password perlindungan penulisan sekaligus?**

Ya. Berikan password pembukaan melalui opsi pemuatan untuk membuka presentasi yang terenkripsi, dan validasi password perlindungan penulisan secara terpisah ketika otorisasi modifikasi diperlukan.