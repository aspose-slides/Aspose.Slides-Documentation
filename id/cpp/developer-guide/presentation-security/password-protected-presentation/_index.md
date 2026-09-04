---
title: Proteksi Presentasi dengan Password di C++
linktitle: Proteksi Password
type: docs
weight: 20
url: /id/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi password di C++ dengan Aspose.Slides."
---
## **Gambaran Umum**

Password pembuka mengenkripsi presentasi. Password yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Password pembuka berbeda dari password proteksi penulisan. Proteksi penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola password bagi modifikasi presentasi, lihat [Write-Protect Presentations](/slides/id/cpp/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh‑contoh menggunakan kedua format ketika perilaku berbasis file dan berbasis aliran penting.

## **Mengenkripsi Presentasi dengan Password Pembuka**

Gunakan [IProtectionManager::Encrypt](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/encrypt/) untuk menetapkan password pembuka. Kemudian gunakan [IPresentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/save/) untuk menyimpan presentasi yang telah dienkripsi.

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

## **Membuat Properti Dokumen Publik**

Secara default, Aspose.Slides menyertakan properti dokumen dalam enkripsi presentasi. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) mengontrol perilaku ini secara terpisah dari enkripsi konten slide. Berikan `false` ke metode ini sebelum memanggil [IProtectionManager::Encrypt](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/encrypt/) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa password pembuka.

Contoh berikut membuat presentasi PPTX yang dienkripsi sambil membiarkan properti dokumen bawaan tetap publik:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Memberikan `false` ke `set_EncryptDocumentProperties` tidak membuat slide, master, tata letak, shape, media, atau konten presentasi lainnya menjadi publik. Itu hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten yang dienkripsi, lihat [Manage Presentation Properties](/slides/id/cpp/presentation-properties/).

## **Memuat Presentasi yang Dienkripsi**

Atur [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) ke password pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) saat memuat file. Pemuatan gagal ketika password pembuka diperlukan tetapi password yang diberikan tidak ada atau salah.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Bekerja dengan presentasi yang telah didekripsi.
```

## **Menghapus Enkripsi dari Presentasi**

Muat presentasi dengan password pembukanya, panggil [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/removeencryption/), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa password.

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

## **Memvalidasi Password Pembuka Sebelum Memuat**

Gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memperoleh [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/) tanpa membuat instance presentasi lengkap. Periksa [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) sebelum meminta atau memvalidasi password. Ketika perlindungan ada, validasi nilai yang diberikan dengan [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Alur Kerja Berdasarkan Jalur File**

Contoh berikut memvalidasi password pembuka untuk file PPTX, memberikan nilai yang telah divalidasi ke [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/), dan kemudian memuat presentasi lengkap:

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

### **Alur Kerja Berbasis Aliran**

Overload aliran dari [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) menyediakan alur kerja yang sama. Atur ulang posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/checkpassword/) mengembalikan `true` hanya ketika presentasi memiliki password pembuka dan password yang diberikan benar. Ia mengembalikan `false` dalam setiap kasus berikut:

- Password salah.
- Presentasi tidak memiliki password pembuka.
- Password yang diberikan bernilai null atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Memeriksa Apakah Presentasi yang Dimuat Dienkripsi**

Setelah memuat presentasi dengan password yang benar, periksa [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) untuk memastikan bahwa sumber presentasi memang dienkripsi. Untuk mendeteksi perlindungan password pembuka sebelum memuat, gunakan `IPresentationInfo::get_IsPasswordProtected` seperti yang ditunjukkan di atas.

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

{{% alert color="warning" title="Security" %}}
Jangan mencatat password pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan password di memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika langsung memuat presentasi.

Properti dokumen publik dapat mengungkap nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai khusus meskipun konten presentasi dienkripsi. Enkripsi metadata sensitif bersama dengan presentasi. Membiarkan properti publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasikan, mencari, atau mengelola file tanpa password pembuka.
{{% /alert %}}

## **Melindungi Presentasi dengan Password Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
2. Pilih atau unggah presentasi.
3. Masukkan password untuk perlindungan tampilan.
4. Opsional, masukkan password terpisah untuk perlindungan edit.
5. Terapkan perlindungan dan unduh file yang dihasilkan.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/id/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara password pembuka dan password proteksi penulisan?**

Password pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Password proteksi penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Apakah saya dapat memvalidasi password pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan password pembuka ada, dan validasi password sebelum membuat instance presentasi lengkap.

**Apakah aplikasi dapat membaca metadata tanpa password pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan `set_EncryptDocumentProperties(false)`. Aplikasi kemudian harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan dalam [Manage Presentation Properties](/slides/id/cpp/presentation-properties/).

**Apakah alur kerja pemeriksaan password mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi password berbasis jalur file serta aliran berperilaku sama untuk presentasi PPT dan PPTX.