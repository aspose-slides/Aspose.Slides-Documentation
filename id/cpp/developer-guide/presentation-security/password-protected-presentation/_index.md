---
title: Presentasi Aman dengan Kata Sandi di C++
linktitle: Perlindungan Kata Sandi
type: docs
weight: 20
url: /id/cpp/password-protected-presentation/
keywords:
- kunci PowerPoint
- kunci presentasi
- buka kunci PowerPoint
- buka kunci presentasi
- lindungi PowerPoint
- lindungi presentasi
- atur kata sandi
- tambahkan kata sandi
- enkripsi PowerPoint
- enkripsi presentasi
- dekripsi PowerPoint
- dekripsi presentasi
- perlindungan penulisan
- keamanan PowerPoint
- keamanan presentasi
- hapus kata sandi
- hapus perlindungan
- hapus enkripsi
- nonaktifkan kata sandi
- nonaktifkan perlindungan
- hapus perlindungan penulisan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi dengan Aspose.Slides untuk C++. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, berarti Anda menetapkan kata sandi yang memberlakukan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan pembatasan ini pada presentasi:

- **Modifikasi**

  Jika Anda hanya ingin pengguna tertentu dapat memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan di sini mencegah orang mengubah, mengubah, atau menyalin hal‑hal dalam presentasi Anda (kecuali mereka memberikan kata sandi).

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode baca‑saja, pengguna dapat melihat isi atau hal‑hal—tautan hiper, animasi, efek, dan lainnya—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda hanya ingin pengguna tertentu dapat membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan di sini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memberikan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka presentasi, mereka tidak dapat melakukan modifikasi atau membuat perubahan padanya.

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, berkas presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih berkas yang ingin Anda lindungi dengan kata sandi di komputer Anda. 

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan. 

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan akhir, centang kotak **Mark as final**.

6. Klik **PROTECT NOW.** 

7. Klik **DOWNLOAD NOW.**

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi presentasi  
- Menetapkan perlindungan penulisan pada presentasi  

**Operasi Lain**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi presentasi; membuka presentasi terenkripsi  
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi  
- Menghapus perlindungan penulisan dari presentasi  
- Mendapatkan properti presentasi terenkripsi  
- Memeriksa apakah presentasi terenkripsi  
- Memeriksa apakah presentasi dilindungi kata sandi.

## **Mengenkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memberikan kata sandi.

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager)) untuk menetapkan kata sandi pada presentasi. Anda melewatkan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode ini menunjukkan cara mengenkripsi presentasi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Menetapkan Perlindungan Penulisan pada Presentasi**

Anda dapat menambahkan tanda “Jangan ubah” pada presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode setWriteProtection. Contoh kode ini menunjukkan cara menetapkan perlindungan penulisan pada presentasi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Membuka Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda membuka berkas terenkripsi dengan memasukkan kata sandinya. Untuk mendekripsi presentasi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) tanpa parameter. Anda kemudian harus memasukkan kata sandi yang benar untuk membuka presentasi.

Contoh kode ini menunjukkan cara mendekripsi presentasi:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// kerja dengan presentasi yang didekripsi
```

## **Menghapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan.

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Contoh kode ini menunjukkan cara menghapus enkripsi dari presentasi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang digunakan pada berkas presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan mereka tidak akan menerima peringatan saat melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari presentasi dengan menggunakan metode [RemoveWriteProtection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Contoh kode ini menunjukkan cara menghapus perlindungan penulisan dari presentasi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menyediakan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sekaligus tetap mengakses properti dokumennya.

**Catatan:** Secara bawaan, ketika Aspose.Slides mengenkripsi presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukannya.

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi terenkripsi, berikan nilai `false` ke metode `set_EncryptDocumentProperties` pada [IProtectionManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/). Contoh kode ini menunjukkan cara mengenkripsi presentasi sekaligus tetap memberi pengguna akses ke properti dokumennya:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/) dan tetapkan [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) ke `true`. Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses secara publik.

Contoh kode berikut membaca properti dokumen bawaan dan kustom melalui [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, menetapkan `LoadOptions::set_OnlyLoadDocumentProperties` ke `true` akan menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat seluruh presentasi, termasuk slide dan konten lainnya, berikan kata sandi yang benar dengan `LoadOptions::set_Password` pada [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/).

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi dengan kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode C++ ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Memeriksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsEncrypted()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak terenkripsi.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsWriteProtected()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak terenkripsi.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Memverifikasi Penggunaan Kata Sandi pada Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi kata sandi.

Contoh kode ini menunjukkan cara memvalidasi kata sandi:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// periksa apakah "pass" cocok dengan
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `false`.

{{% alert color="info" title="Lihat juga" %}} 
- [Tanda Tangan Digital di PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka presentasi?**

Sebuah pengecualian dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada implikasi kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambahkan sedikit overhead selama operasi pembukaan dan penyimpanan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu proses total tugas presentasi Anda.