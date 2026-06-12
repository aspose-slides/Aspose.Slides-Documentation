---
title: Kelola Tag dan Data Kustom dalam Presentasi di .NET
linktitle: Tag dan Data Kustom
type: docs
weight: 300
url: /id/net/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data kustom
- menambahkan tag
- pasangan nilai
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan, membaca, memperbarui, dan menghapus tag & data kustom di Aspose.Slides untuk .NET, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Artikel ini secara singkat menguraikan bagaimana data disimpan dalam file PPTX, mencatat bahwa data khusus presentasi dapat ada sebagai tag dan bagian XML khusus, serta menjelaskan tag sebagai pasangan string kunci‑nilai.

Artikel ini juga menunjukkan cara membaca nilai tag serta cara menambahkan tag ke presentasi, slide individu, atau shape. Selain itu, artikel ini membahas tugas umum pengelolaan tag seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terdapat dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part diizinkan memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik untuk sebuah presentasi) atau data pengguna dapat ada sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/net/aspose.slides/itagcollection)) dan CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
Tag pada dasarnya adalah nilai pasangan kunci‑string. 
{{% /alert %}} 

## **Dapatkan Nilai Tag**

Dalam Slides, sebuah tag berkorespondensi dengan properti IDocumentProperties.Keywords. Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk .NET untuk [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti kustom - `MyTag`
- nilai properti kustom - `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka Anda dapat memperoleh manfaat dari menambahkan tag ke presentasi tersebut. Misalnya, jika Anda ingin mengelompokkan semua presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan kemudian menetapkan negara‑negara yang relevan (AS, Meksiko, dan Kanada) sebagai nilai.

Kode contoh ini menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) menggunakan Aspose.Slides untuk .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Atau shape individu mana pun [Shape](https://reference.aspose.com/slides/id/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `CustomData.Tags` hanya disimpan di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Workaround**: Anda dapat menyimpan pengidentifikasi khusus dalam **Alt Text** objek (misalnya, `shape.AlternativeText = "MyId"`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari sebuah presentasi, slide, atau shape dalam satu operasi?**

Ya. [tag collection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa iterasi seluruh koleksi?**

Gunakan operasi [Remove(name)](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [GetNamesOfTags](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/getnamesoftags/) pada [tag collection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/); metode ini mengembalikan array semua nama tag.