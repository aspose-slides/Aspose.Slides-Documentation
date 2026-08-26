---
title: Proteksi Penulisan Presentasi di .NET
linktitle: Proteksi Penulisan
type: docs
weight: 25
url: /id/net/write-protected-presentation/
keywords:
- proteksi penulisan
- proteksi penulisan PowerPoint
- kata sandi untuk mengubah
- batasi penyuntingan presentasi
- hapus proteksi penulisan
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus kata sandi proteksi penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk .NET."
---
## **Introduction**

Kata sandi proteksi penulisan membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi penulisan tanpa kata sandi. Tergantung pada aplikasi, mereka juga dapat mengedit konten dan menyimpannya dengan nama yang berbeda, sehingga proteksi penulisan tidak boleh dianggap sebagai mekanisme kerahasiaan.

Kata sandi pembuka memiliki tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi kata sandi pembuka, lihat [Password-Protect Presentations](/slides/id/net/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; saat menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang bersesuaian.

## **Mengatur Proteksi Penulisan pada Presentasi**

Gunakan [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/setwriteprotection/) untuk menetapkan kata sandi yang mengizinkan modifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan proteksi.

Contoh berikut mengatur proteksi penulisan pada presentasi PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Muat Presentasi yang Dilindungi Penulisan**

Karena proteksi penulisan tidak mengenkripsi konten presentasi, tidak diperlukan kata sandi untuk memuat presentasi. Kata sandi hanya relevan saat memvalidasi otorisasi untuk memodifikasi presentasi yang dilindungi.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Jangan memberi kata sandi proteksi penulisan ke [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/). Properti tersebut menerima kata sandi pembuka untuk konten yang terenkripsi. Jika sebuah presentasi memiliki kedua jenis proteksi, berikan kata sandi pembuka untuk memuatnya dan tangani kata sandi proteksi penulisan secara terpisah.

## **Menghapus Proteksi Penulisan dari Presentasi**

Gunakan [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/removewriteprotection/) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) lengkap, panggil [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationfactory/getpresentationinfo/) dan periksa [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/iswriteprotected/). Properti tersebut menggunakan [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/) dan mengembalikan `NullableBool.True` ketika proteksi penulisan terdeteksi.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Overload stream dari [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationfactory/getpresentationinfo/) memberikan informasi yang sama untuk presentasi yang disediakan sebagai aliran.

## **Memvalidasi Kata Sandi Proteksi Penulisan**

Gunakan [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/checkwriteprotection/) untuk memvalidasi kata sandi modifikasi tanpa memuat presentasi lengkap. Periksa [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/iswriteprotected/) terlebih dahulu sehingga aplikasi meminta atau memvalidasi kata sandi hanya ketika proteksi penulisan ada.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/checkwriteprotection/) memvalidasi hanya kata sandi proteksi penulisan. Ia tidak memvalidasi kata sandi pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/checkpassword/) memvalidasi hanya kata sandi pembuka. Jika sebuah presentasi lengkap sudah dimuat, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/checkwriteprotection/) menyediakan pemeriksaan proteksi penulisan yang setara melalui manajer proteksinya.

Dalam aplikasi produksi, jangan mencatat kata sandi atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak diperlukan, dan simpan kata sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="See also" %}}
- [Presentasi dengan Proteksi Kata Sandi](/slides/id/net/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/net/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah proteksi penulisan mengenkripsi presentasi?**

Tidak. Ini membatasi modifikasi tetapi tetap membuat konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah kata sandi proteksi penulisan diperlukan untuk membuka presentasi?**

Tidak. Hanya kata sandi pembuka yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki sekaligus kata sandi pembuka dan kata sandi proteksi penulisan?**

Ya. Berikan kata sandi pembuka melalui opsi pemuatan untuk membuka presentasi yang terenkripsi, dan validasi kata sandi proteksi penulisan secara terpisah ketika otorisasi modifikasi diperlukan.