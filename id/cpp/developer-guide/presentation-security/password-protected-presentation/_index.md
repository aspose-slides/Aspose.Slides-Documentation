---
title: Amankan Presentasi dengan Kata Sandi di C++
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/cpp/password-protected-presentation/
keywords:
- Kunci PowerPoint
- Kunci presentasi
- Buka kunci PowerPoint
- Buka kunci presentasi
- Lindungi PowerPoint
- Lindungi presentasi
- Tetapkan kata sandi
- Tambahkan kata sandi
- Enkripsi PowerPoint
- Enkripsi presentasi
- Dekripsi PowerPoint
- Dekripsi presentasi
- Proteksi tulis
- Keamanan PowerPoint
- Keamanan presentasi
- Hapus kata sandi
- Hapus proteksi
- Hapus enkripsi
- Nonaktifkan kata sandi
- Nonaktifkan proteksi
- Hapus proteksi tulis
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi dengan Aspose.Slides untuk C++. Amankan presentasi Anda."
---
## **Pendahuluan**

Ketika Anda melindungi presentasi dengan kata sandi, artinya Anda menetapkan kata sandi yang memberlakukan batasan tertentu pada presentasi. Untuk menghapus batasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan batasan ini pada sebuah presentasi:

- **Modifikasi**

  Jika Anda ingin hanya pengguna tertentu yang dapat memodifikasi presentasi Anda, Anda dapat menetapkan batasan modifikasi. Batasan ini mencegah orang mengubah, memodifikasi, atau menyalin hal dalam presentasi Anda (kecuali mereka memasukkan kata sandi).

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode hanya-baca ini, pengguna dapat melihat isi atau hal—tautan hiperteks, animasi, efek, dan lainnya—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda ingin hanya pengguna tertentu yang dapat membuka presentasi Anda, Anda dapat menetapkan batasan pembukaan. Batasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memasukkan kata sandi).

  Secara teknis, batasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka sebuah presentasi, mereka tidak dapat mengubah atau membuat perubahan pada presentasi tersebut.

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda. 

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan. 

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.

6. Klik **PROTECT NOW.** 

7. Klik **DOWNLOAD NOW.**

## **Proteksi Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung proteksi kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT - Presentasi Microsoft PowerPoint
- ODP - Presentasi OpenDocument
- OTP - Template Presentasi OpenDocument

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan proteksi kata sandi pada presentasi untuk mencegah perubahan dengan cara berikut:

- Mengenkripsi sebuah presentasi
- Menetapkan proteksi tulis pada sebuah presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan proteksi kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan proteksi kata sandi
- Menghapus proteksi tulis dari sebuah presentasi
- Mendapatkan properti sebuah presentasi yang terenkripsi
- Memeriksa apakah sebuah presentasi dienkripsi
- Memeriksa apakah sebuah presentasi dilindungi kata sandi.

## **Enkripsi Presentasi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memasukkan kata sandi.

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager)) untuk menetapkan kata sandi pada presentasi. Anda memberikan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini sudah terenkripsi.

Kode contoh ini menunjukkan cara mengenkripsi sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Tetapkan Proteksi Tulis pada Presentasi** 

Anda dapat menambahkan tanda “Do not modify” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak mengizinkan mereka mengubah presentasi.  

**Catatan** bahwa proses proteksi tulis tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda. 

Untuk menetapkan proteksi tulis, Anda harus menggunakan metode setWriteProtection. Kode contoh ini menunjukkan cara menetapkan proteksi tulis pada sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Muat Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat berkas terenkripsi dengan memberikan kata sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) tanpa parameter. Selanjutnya Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.

Kode contoh ini menunjukkan cara mendekripsi sebuah presentasi: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// bekerja dengan presentasi terdekripsi
```

## **Hapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau proteksi kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa batasan. 

Untuk menghapus enkripsi atau proteksi kata sandi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Kode contoh ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Hapus Proteksi Tulis dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus proteksi tulis yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan tidak akan ada peringatan saat mereka melakukan tugas tersebut.

Anda dapat menghapus proteksi tulis dari sebuah presentasi dengan menggunakan metode [RemoveWriteProtection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Kode contoh ini menunjukkan cara menghapus proteksi tulis dari sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Dapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menyediakan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memungkinkan akses ke properti dokumennya.

**Catatan**: Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukan hal tersebut.

Jika Anda ingin pengguna tetap dapat mengakses properti sebuah presentasi yang terenkripsi, berikan `false` ke metode `set_EncryptDocumentProperties` pada [IProtectionManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/). Kode contoh ini menunjukkan cara mengenkripsi presentasi sambil tetap memberikan pengguna akses ke properti dokumennya:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata sebuah presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/) dan atur [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) ke `true`. Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses publik.

Contoh kode berikut membaca properti dokumen bawaan dan khusus melalui [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_documentproperties/):

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

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, mengatur `LoadOptions::set_OnlyLoadDocumentProperties` ke `true` akan menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat presentasi lengkap, termasuk slide dan konten lainnya, berikan kata sandi yang benar dengan `LoadOptions::set_Password` pada [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/).

## **Periksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tersebut tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode C++ ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Periksa Apakah Presentasi Dienkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dienkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsEncrypted()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), yang mengembalikan `true` jika presentasi dienkripsi atau `false` jika tidak dienkripsi. 

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi dienkripsi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Periksa Apakah Presentasi Dilindungi Tulis**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi tulisan. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsWriteProtected()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), yang mengembalikan `true` jika presentasi dilindungi tulisan atau `false` jika tidak. 

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi tulisan:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifikasi Penggunaan Kata Sandi Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi. 

Kode contoh ini menunjukkan cara memvalidasi sebuah kata sandi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// periksa apakah "pass" cocok dengan
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Itu mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, mengembalikan `false`. 

{{% alert color="primary" title="Lihat juga" %}} 
- [Digital Signature in PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Sebuah pengecualian akan dilemparkan jika kata sandi yang salah digunakan, memberi tahu bahwa akses ke presentasi ditolak. Hal ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit beban selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi Anda.