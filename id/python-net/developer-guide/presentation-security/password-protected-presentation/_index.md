---
title: "Amankan Presentasi dengan Kata Sandi Menggunakan Python"
linktitle: "Proteksi Kata Sandi"
type: docs
weight: 20
url: /id/python-net/password-protected-presentation/
keywords:
- "kunci PowerPoint"
- "kunci presentasi"
- "buka kunci PowerPoint"
- "buka kunci presentasi"
- "lindungi PowerPoint"
- "lindungi presentasi"
- "atur kata sandi"
- "tambahkan kata sandi"
- "enkripsi PowerPoint"
- "enkripsi presentasi"
- "dekripsi PowerPoint"
- "dekripsi presentasi"
- "perlindungan penulisan"
- "keamanan PowerPoint"
- "keamanan presentasi"
- "hapus kata sandi"
- "hapus perlindungan"
- "hapus enkripsi"
- "nonaktifkan kata sandi"
- "nonaktifkan perlindungan"
- "hapus perlindungan penulisan"
- "presentasi PowerPoint"
- "Python"
- "Aspose.Slides"
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint serta OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk Python via .NET. Tingkatkan produktivitas Anda dan amankan presentasi Anda dengan panduan langkah demi langkah kami."
---
## **Pendahuluan**

Ketika Anda melindungi presentasi dengan kata sandi, artinya Anda menetapkan kata sandi yang memberlakukan batasan tertentu pada presentasi. Untuk menghapus batasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan batasan-batasan ini pada presentasi:

- **Modifikasi**

  Jika Anda hanya ingin pengguna tertentu yang dapat memodifikasi presentasi Anda, Anda dapat menetapkan batasan modifikasi. Batasan ini mencegah orang memodifikasi, mengubah, atau menyalin isi presentasi Anda (kecuali mereka memasukkan kata sandi).  

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna masih dapat mengakses dokumen Anda dan membukanya. Dalam mode baca-saja ini, pengguna dapat melihat isi atau elemen—tautan, animasi, efek, dan lainnya—di dalam presentasi Anda, tetapi tidak dapat menyalin item atau menyimpan presentasi.  

- **Pembukaan**

  Jika Anda hanya ingin pengguna tertentu yang dapat membuka presentasi Anda, Anda dapat menetapkan batasan pembukaan. Batasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memasukkan kata sandi).  

  Secara teknis, batasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: ketika orang tidak dapat membuka presentasi, mereka tidak dapat melakukan modifikasi atau perubahan apa pun.  

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi akan menjadi terenkripsi.

## Cara Melindungi Presentasi dengan Kata Sandi Secara Online

1. Kunjungi halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami.  

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda.  

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan.  

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.  

6. Klik **PROTECT NOW.**  

7. Klik **DOWNLOAD NOW.**

## **Proteksi Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:  

- PPTX dan PPT - Presentasi Microsoft PowerPoint  
- ODP - Presentasi OpenDocument  
- OTP - Template Presentasi OpenDocument  

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:  

- Mengenkripsi presentasi  
- Menetapkan perlindungan penulisan pada presentasi  

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:  

- Mendekripsi presentasi; membuka presentasi yang dienkripsi  
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi  
- Menghapus perlindungan penulisan dari presentasi  
- Mendapatkan properti presentasi yang dienkripsi  
- Memeriksa apakah sebuah presentasi dienkripsi  
- Memeriksa apakah sebuah presentasi dilindungi kata sandi.  

## **Mengenkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memasukkan kata sandi.  

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/)) untuk menetapkan kata sandi pada presentasi. Anda memberikan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.  

Contoh kode berikut menunjukkan cara mengenkripsi sebuah presentasi:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Menetapkan Perlindungan Penulisan pada Presentasi** 

Anda dapat menambahkan tanda “Do not modify” pada presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak ingin mereka mengubah presentasi.  

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.  

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode setWriteProtection. Contoh kode berikut menunjukkan cara menetapkan perlindungan penulisan pada presentasi:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendekripsi Presentasi; Membuka Presentasi yang Dienkripsi**

Aspose.Slides memungkinkan Anda memuat file yang dienkripsi dengan memberikan kata sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [remove_encryption](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/) tanpa parameter. Kemudian Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.  

Contoh kode berikut menunjukkan cara mendekripsi sebuah presentasi:  

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Menghapus Enkripsi; Menonaktifkan Perlindungan Kata Sandi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa batasan.  

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [remove_encryption](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/). Contoh kode berikut menunjukkan cara menghapus enkripsi dari sebuah presentasi:  

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka mereka—dan tidak akan mendapatkan peringatan saat melakukan hal tersebut.  

Anda dapat menghapus perlindungan penulisan dari sebuah presentasi dengan menggunakan metode [remove_write_protection](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/). Contoh kode berikut menunjukkan cara menghapus perlindungan penulisan dari sebuah presentasi:  

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Properti Presentasi yang Dienkripsi**

Biasanya, pengguna kesulitan mendapatkan properti dokumen dari presentasi yang dienkripsi atau dilindungi kata sandi. Aspose.Slides, bagaimanapun, menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sekaligus mempertahankan cara bagi pengguna untuk mengakses properti presentasi tersebut.  

**Catatan** bahwa ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi tersebut juga dilindungi kata sandi secara default. Tetapi jika Anda perlu membuat properti presentasi dapat diakses (bahkan setelah presentasi dienkripsi), Aspose.Slides memungkinkan Anda melakukannya.  

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi yang Anda enkripsi, Anda dapat mengatur properti [EncryptDocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/) menjadi `True`. Contoh kode berikut menunjukkan cara mengenkripsi presentasi sambil memberikan cara bagi pengguna untuk mengakses properti dokumennya:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi Sebelum Memuatnya**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tersebut tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandi.  

Kode Python berikut menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):  

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Memeriksa Apakah Presentasi Dienkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dienkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan properti [is_encrypted](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/), yang mengembalikan `True` jika presentasi dienkripsi atau `False` jika tidak dienkripsi.  

Contoh kode berikut menunjukkan cara memeriksa apakah sebuah presentasi dienkripsi:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan properti [is_write_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/), yang mengembalikan `True` jika presentasi dilindungi penulisan atau `False` jika tidak.  

Contoh kode berikut menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:  

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Memvalidasi atau Mengonfirmasi bahwa Kata Sandi Tertentu Telah Digunakan untuk Melindungi Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi.  

Contoh kode berikut menunjukkan cara memvalidasi kata sandi:  

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # periksa apakah "pass" cocok dengan
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Ia mengembalikan `True` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `False`.  

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/id/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Sebuah pengecualian akan dilemparkan jika kata sandi yang salah digunakan, memberi peringatan bahwa akses ke presentasi ditolak. Hal ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada implikasi kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menimbulkan sedikit overhead selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi total waktu pemrosesan tugas presentasi Anda.