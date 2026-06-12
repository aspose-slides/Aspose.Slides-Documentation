---
title: Kelola Tag dan Data Khusus dalam Presentasi Menggunakan C++
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/cpp/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan, membaca, memperbarui, dan menghapus tag & data khusus di Aspose.Slides untuk C++, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan bagaimana Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Secara singkat dijelaskan bagaimana data disimpan dalam file PPTX, dicatat bahwa data yang spesifik untuk presentasi dapat muncul sebagai tag dan bagian XML khusus, serta menjelaskan tag sebagai pasangan string kunci‑nilai.

Artikel ini juga menunjukkan cara membaca nilai tag dan cara menambahkan tag ke presentasi, slide individual, atau shape. Selain itu, artikel ini mencakup tugas umum manajemen tag seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terkandung dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part dapat memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik untuk sebuah presentasi) atau pengguna dapat muncul sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/itagcollection/)) dan CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Tag pada dasarnya adalah pasangan nilai string‑kunci. 
{{% /alert %}} 

## **Mendapatkan Nilai Tag**

Dalam slides, sebuah tag berkorespondensi dengan properti IDocumentProperties.Keywords. Kode contoh berikut menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk C++ untuk [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus – `MyTag`  
- nilai properti khusus – `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka Anda dapat memperoleh manfaat dari menambahkan tag ke presentasi tersebut. Misalnya, jika Anda ingin mengelompokkan semua presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag “North American” dan kemudian menetapkan negara terkait (AS, Meksiko, dan Kanada) sebagai nilai.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menggunakan Aspose.Slides untuk C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Atau untuk [Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/) individual:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Batasan**

Tag yang ditambahkan melalui koleksi tag data khusus menggunakan `get_CustomData()->get_Tags()` hanya disimpan di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF saat presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Solusi**: Anda dapat menyimpan pengenal khusus di **Alt Text** objek (misalnya, `shape->set_AlternativeText(u"MyId")`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus mengiterasi seluruh koleksi?**

Gunakan operasi [Remove(name)](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [GetNamesOfTags](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/getnamesoftags/) pada [koleksi tag](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/); metode ini mengembalikan array berisi semua nama tag.