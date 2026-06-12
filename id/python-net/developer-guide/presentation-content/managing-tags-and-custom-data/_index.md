---
title: Kelola Tag dan Data Khusus dalam Presentasi dengan Python
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/python-net/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- tambahkan tag
- pasangan nilai
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan, membaca, memperbarui, dan menghapus tag & data khusus di Aspose.Slides untuk Python via .NET, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Secara singkat dijelaskan bagaimana data disimpan dalam file PPTX, dicatat bahwa data spesifik presentasi dapat berupa tag dan bagian XML khusus, serta tag dijelaskan sebagai pasangan string kunci‑nilai.

Artikel juga menunjukkan cara membaca nilai tag dan cara menambahkan tag ke sebuah presentasi, slide individu, atau shape. Selain itu, artikel membahas tugas umum pengelolaan tag seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terdapat dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part dapat memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik untuk sebuah presentasi) atau data pengguna dapat berupa tag ([ITagCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/itagcollection/)) dan CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

Tag pada dasarnya adalah pasangan nilai string‑kunci. 

{{% /alert %}} 

## **Mendapatkan Nilai Tag**

Di Slides, sebuah tag terkait dengan properti IDocumentProperties.Keywords. Contoh kode berikut menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk Python via .NET untuk [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua elemen:

- nama properti khusus - `MyTag` 
- nilai properti khusus - `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka menambahkan tag ke presentasi tersebut dapat berguna. Misalnya, jika Anda ingin mengkategorikan atau mengelompokkan semua presentasi dari negara-negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan kemudian menetapkan negara yang relevan (AS, Meksiko, dan Kanada) sebagai nilai.

Contoh kode berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) menggunakan Aspose.Slides untuk Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Atau untuk setiap [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) individu:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `custom_data.tags` hanya disimpan di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang telah ditandai.

**Solusi**: Anda dapat menyimpan pengenal khusus dalam **Alt Text** objek (misalnya, `shape.alternative_text = "MyId"`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Tag collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus iterasi seluruh koleksi?**

Gunakan operasi [remove(name)](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [get_names_of_tags](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/get_names_of_tags/) pada [tag collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/); metode ini mengembalikan array berisi semua nama tag.