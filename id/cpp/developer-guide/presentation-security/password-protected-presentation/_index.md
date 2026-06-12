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
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk C++. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, artinya Anda menetapkan kata sandi yang memberlakukan beberapa pembatasan pada presentasi. Untuk menghapus pembatasan, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi yang terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan pembatasan ini pada sebuah presentasi:

- **Modifikasi**

  Jika Anda hanya menginginkan pengguna tertentu untuk memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang mengubah, memodifikasi, atau menyalin hal‑hal dalam presentasi Anda (kecuali mereka memberikan kata sandi). 

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna dapat mengakses dokumen Anda dan membukanya. Dalam mode baca‑saja ini, pengguna dapat melihat konten atau hal—tautan, animasi, efek, dan lain‑lain—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi. 

- **Pembukaan**

  Jika Anda hanya menginginkan pengguna tertentu untuk membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memberikan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka presentasi, mereka tidak dapat melakukan modifikasi atau perubahan apapun pada presentasi tersebut. 
  
  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Seret atau unggah file Anda**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda. 

4. Masukkan kata sandi pilihan Anda untuk perlindungan penyuntingan; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan. 

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.

6. Klik **PROTECT NOW.** 

7. Klik **DOWNLOAD NOW.**

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut: 

- PPTX dan PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi presentasi
- Menetapkan perlindungan penulisan pada presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi sebagai berikut:

- Mendekripsi presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi
- Menghapus perlindungan penulisan dari presentasi
- Mendapatkan properti presentasi yang terenkripsi
- Memeriksa apakah presentasi terenkripsi
- Memeriksa apakah presentasi dilindungi kata sandi.

## **Mengenkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memberikan kata sandi. 

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager)) untuk menetapkan kata sandi pada presentasi. Anda memberikan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi. 

Kode contoh ini menunjukkan cara mengenkripsi sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Menetapkan Perlindungan Penulisan pada Presentasi** 

Anda dapat menambahkan tanda “Do not modify” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.  

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang menginginkannya—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda. 

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode setWriteProtection. Kode contoh ini menunjukkan cara menetapkan perlindungan penulisan pada sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Muat Presentasi yang Ditenkripsi**

Aspose.Slides memungkinkan Anda memuat file terenkripsi dengan memberikan kata sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) tanpa parameter. Anda kemudian harus memasukkan kata sandi yang benar untuk memuat presentasi. 

Kode contoh ini menunjukkan cara mendekripsi sebuah presentasi:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// bekerja dengan presentasi yang didekripsi
```

## **Menghapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan. 

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Kode contoh ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan tidak menerima peringatan saat melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari sebuah presentasi dengan menggunakan metode [RemoveWriteProtection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Kode contoh ini menunjukkan cara menghapus perlindungan penulisan dari sebuah presentasi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Dapatkan Properti Presentasi yang Ditenkripsi**

Biasanya, pengguna kesulitan mendapatkan properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Aspose.Slides, bagaimanapun, menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memberi cara bagi pengguna untuk mengakses properti presentasi tersebut.

**Catatan** bahwa ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi tersebut juga dilindungi kata sandi secara default. Tetapi jika Anda perlu membuat properti presentasi dapat diakses (bahkan setelah presentasi terenkripsi), Aspose.Slides memungkinkan Anda melakukan hal tersebut. 

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi yang Anda enkripsi, Anda dapat melewatkan `true` ke metode [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Kode contoh ini menunjukkan cara mengenkripsi presentasi sambil menyediakan cara bagi pengguna untuk mengakses properti dokumennya:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Periksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi dengan kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode C++ ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Periksa Apakah Presentasi Ditenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsEncrypted()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak terenkripsi. 

Kode contoh ini menunjukkan cara memeriksa apakah presentasi terenkripsi:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan metode [get_IsWriteProtected()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak. 

Kode contoh ini menunjukkan cara memeriksa apakah presentasi dilindungi penulisan:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifikasi Penggunaan Kata Sandi pada Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi kata sandi. 

Kode contoh ini menunjukkan cara memvalidasi kata sandi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// periksa apakah "pass" cocok dengan
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/id/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka presentasi?**

Sebuah pengecualian dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambahkan sedikit overhead selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan mempengaruhi waktu proses keseluruhan tugas presentasi Anda.