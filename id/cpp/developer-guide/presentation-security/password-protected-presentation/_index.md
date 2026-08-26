---
title: Lindungi Presentasi dengan Kata Sandi di C++
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/cpp/password-protected-presentation/
keywords:
- presentasi dengan proteksi kata sandi
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
- C++
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi kata sandi di C++ dengan Aspose.Slides."
---
## **Gambaran Umum**

Kata sandi pembuka mengenkripsi presentasi. Kata sandi yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Kata sandi pembuka berbeda dari kata sandi proteksi penulisan. Proteksi penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola kata sandi dalam memodifikasi presentasi, lihat [Proteksi Penulisan Presentasi](/slides/id/cpp/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh-contoh menggunakan kedua format di mana perilaku berbasis file dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Kata Sandi Pembuka**

Gunakan [IProtectionManager::Encrypt](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/encrypt/) untuk menetapkan kata sandi pembuka. Kemudian gunakan [IPresentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/save/) untuk menyimpan presentasi yang dienkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Muat Presentasi yang Dienkripsi**

Setel [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) ke kata sandi pembuka dan terapkan opsi ke [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) saat memuat file. Memuat akan gagal ketika kata sandi pembuka diperlukan tetapi kata sandi yang diberikan tidak ada atau salah.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Bekerja dengan presentasi yang telah didekripsi.
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan kata sandi pembukanya, panggil [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/removeencryption/), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa kata sandi.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Validasi Kata Sandi Pembuka Sebelum Memuat**

Gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memperoleh [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) sebelum meminta atau memvalidasi kata sandi. Ketika perlindungan ada, validasi nilai yang diberikan dengan [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Alur Kerja Berbasis Jalur File**

Contoh berikut memvalidasi kata sandi pembuka untuk file PPTX, meneruskan nilai yang telah divalidasi ke [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/), dan kemudian memuat presentasi lengkap:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Alur Kerja Aliran**

Versi overload aliran dari [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) menyediakan alur kerja yang sama. Atur ulang posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

Contoh berikut menggunakan file PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Nilai Kembalian CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkpassword/) mengembalikan `true` hanya ketika presentasi memiliki kata sandi pembuka dan kata sandi yang diberikan benar. Itu mengembalikan `false` dalam masing-masing kasus berikut:

- Kata sandi tidak benar.
- Presentasi tidak memiliki kata sandi pembuka.
- Kata sandi yang diberikan null atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Dienkripsi**

Setelah memuat presentasi dengan kata sandi yang benar, periksa [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) untuk memastikan bahwa presentasi sumber dienkripsi. Untuk mendeteksi perlindungan kata sandi pembuka sebelum memuat, gunakan `IPresentationInfo::get_IsPasswordProtected` seperti yang ditunjukkan di atas.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Keamanan" %}}
Jangan mencatat kata sandi pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak diperlukan, simpan kata sandi di memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika langsung memuat presentasi.
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
1. Pilih atau unggah presentasi.
1. Masukkan kata sandi untuk perlindungan tampilan.
1. Opsional, masukkan kata sandi terpisah untuk perlindungan edit.
1. Terapkan perlindungan dan unduh file yang dihasilkan.

{{% alert color="info" title="Lihat juga" %}}
- [Proteksi Penulisan Presentasi](/slides/id/cpp/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Tanya Jawab**

**Apa perbedaan antara kata sandi pembuka dan kata sandi proteksi penulisan?**

Kata sandi pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Kata sandi proteksi penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Apakah saya dapat memvalidasi kata sandi pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan kata sandi pembuka ada, dan validasi kata sandi sebelum membuat instance presentasi lengkap.

**Apakah alur kerja pemeriksaan kata sandi mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi kata sandi berbasis jalur file maupun aliran berperilaku sama untuk presentasi PPT dan PPTX.