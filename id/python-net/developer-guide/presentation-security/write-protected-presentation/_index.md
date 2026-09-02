---
title: Proteksi Penulisan Presentasi dalam Python
linktitle: Proteksi Penulisan
type: docs
weight: 25
url: /id/python-net/write-protected-presentation/
keywords:
- proteksi penulisan
- Proteksi Penulisan PowerPoint
- kata sandi untuk memodifikasi
- batasi penyuntingan presentasi
- hapus proteksi penulisan
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi proteksi penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk Python."
---
## **Introduction**

Password proteksi penulisan membatasi modifikasi sebuah presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi penulisan tanpa password. Tergantung pada aplikasi, mereka juga mungkin dapat mengedit konten dan menyimpannya dengan nama berbeda, sehingga proteksi penulisan tidak boleh dianggap sebagai mekanisme kerahasiaan.

Password pembuka memiliki tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi sebuah presentasi atau memvalidasi password pembuka, lihat [Password-Protect Presentations](/slides/id/python-net/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; ketika menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Proteksi Penulisan pada Presentasi**

Gunakan [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/set_write_protection/) untuk menetapkan password untuk memodifikasi sebuah presentasi. Menyimpan presentasi akan mempertahankan pengaturan proteksi.

Contoh berikut mengatur proteksi penulisan pada presentasi PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Muat Presentasi yang Dilindungi Penulisan**

Karena proteksi penulisan tidak mengenkripsi konten presentasi, tidak diperlukan password untuk memuat presentasi. Password hanya relevan saat memvalidasi izin untuk memodifikasi presentasi yang dilindungi.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Jangan mengirim password proteksi penulisan ke [LoadOptions.password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/). Properti tersebut menerima password pembuka untuk konten yang terenkripsi. Jika sebuah presentasi memiliki kedua jenis proteksi, berikan password pembuka untuk memuatnya dan tangani password proteksi penulisan secara terpisah.

## **Hapus Proteksi Penulisan dari Presentasi**

Gunakan [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/remove_write_protection/) untuk menghapus pembatasan modifikasi, kemudian simpan presentasi.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang lengkap, panggil [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) dan periksa [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/is_write_protected/). Properti ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/python-net/aspose.slides/nullablebool/) dan mengembalikan `NullableBool.TRUE` ketika proteksi penulisan terdeteksi.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Overload stream dari [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) memberikan informasi yang sama untuk presentasi yang disediakan sebagai stream.

## **Validasi Password Proteksi Penulisan**

Gunakan [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/check_write_protection/) untuk memvalidasi password modifikasi tanpa memuat presentasi secara lengkap. Periksa [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/is_write_protected/) terlebih dahulu agar aplikasi meminta atau memvalidasi password hanya ketika proteksi penulisan ada.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/check_write_protection/) memvalidasi hanya password proteksi penulisan. Ia tidak memvalidasi password pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [PresentationInfo.check_password](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/check_password/) memvalidasi hanya password pembuka. Jika seluruh presentasi sudah dimuat, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/check_write_protection/) menyediakan pemeriksaan proteksi penulisan yang setara melalui manajer proteksinya.

Dalam aplikasi produksi, jangan mencatat password atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, dan simpan password dalam memori hanya selama diperlukan.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/id/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/id/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/id/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah proteksi penulisan mengenkripsi sebuah presentasi?**

Tidak. Ia membatasi modifikasi tetapi membiarkan konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah password proteksi penulisan diperlukan untuk membuka presentasi?**

Tidak. Hanya password pembuka yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki sekaligus password pembuka dan password proteksi penulisan?**

Ya. Berikan password pembuka melalui opsi pemuatan untuk membuka presentasi yang terenkripsi, dan validasi password proteksi penulisan secara terpisah ketika otorisasi modifikasi diperlukan.