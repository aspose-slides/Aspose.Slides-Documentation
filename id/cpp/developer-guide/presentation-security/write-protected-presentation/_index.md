---
title: Proteksi Penulisan Presentasi di C++
linktitle: Proteksi Penulisan
type: docs
weight: 25
url: /id/cpp/write-protected-presentation/
keywords:
- proteksi penulisan
- Proteksi penulisan PowerPoint
- sandi untuk mengubah
- batasi penyuntingan presentasi
- hapus proteksi penulisan
- validasi sandi modifikasi
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Atur, deteksi, validasi, dan hapus sandi proteksi penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk C++."
---
## **Pendahuluan**

Sandi proteksi penulisan membatasi modifikasi presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi penulisan tanpa sandi. Bergantung pada aplikasi, mereka juga dapat mengedit konten dan menyimpannya dengan nama berbeda, jadi proteksi penulisan tidak boleh dianggap sebagai mekanisme kerahasiaan.

Sandi pembuka berfungsi dengan tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi sandi pembuka, lihat [Presentasi yang Dilindungi Sandi](/slides/id/cpp/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; saat menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Proteksi Penulisan pada Presentasi**

Gunakan [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) untuk menetapkan sandi untuk memodifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan proteksi.

Contoh berikut mengatur proteksi penulisan pada presentasi PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Muat Presentasi yang Dilindungi Penulisan**

Karena proteksi penulisan tidak mengenkripsi konten presentasi, tidak diperlukan sandi untuk memuat presentasi. Sandi hanya relevan saat memvalidasi otorisasi untuk memodifikasi presentasi yang dilindungi.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Jangan mengirimkan sandi proteksi penulisan ke [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/). Properti tersebut menerima sandi pembuka untuk konten terenkripsi. Jika sebuah presentasi memiliki kedua jenis proteksi, berikan sandi pembuka untuk memuatnya dan tangani sandi proteksi penulisan secara terpisah.

## **Hapus Proteksi Penulisan dari Presentasi**

Gunakan [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) lengkap, panggil [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dan periksa [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Properti ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/cpp/aspose.slides/nullablebool/) dan mengembalikan `NullableBool::True` ketika proteksi penulisan terdeteksi.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Overload stream dari [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) memberikan informasi yang sama untuk presentasi yang disediakan sebagai stream.

## **Validasi Sandi Proteksi Penulisan**

Gunakan [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) untuk memvalidasi sandi modifikasi tanpa memuat presentasi lengkap. Periksa [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) terlebih dahulu sehingga aplikasi meminta atau memvalidasi sandi hanya ketika proteksi penulisan ada.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) memvalidasi hanya sandi proteksi penulisan. Ia tidak memvalidasi sandi pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkpassword/) memvalidasi hanya sandi pembuka. Jika presentasi lengkap sudah dimuat, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) menyediakan pemeriksaan proteksi penulisan yang setara melalui manajer proteksinya.

Dalam aplikasi produksi, jangan mencatat sandi atau memasukkannya ke dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, dan simpan sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="See also" %}}
- [Presentasi yang Dilindungi Sandi](/slides/id/cpp/password-protected-presentation/)
- [Presentasi Hanya Baca](/slides/id/cpp/read-only-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah proteksi penulisan mengenkripsi presentasi?**

Tidak. Ia membatasi modifikasi tetapi membiarkan konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah sandi proteksi penulisan diperlukan untuk membuka presentasi?**

Tidak. Hanya sandi pembuka yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki sandi pembuka dan sandi proteksi penulisan sekaligus?**

Ya. Berikan sandi pembuka melalui opsi pemuatan untuk membuka presentasi yang terenkripsi, dan validasi sandi proteksi penulisan secara terpisah ketika otorisasi modifikasi diperlukan.