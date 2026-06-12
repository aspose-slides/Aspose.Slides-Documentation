---
title: Kelola Tag dan Data Khusus dalam Presentasi di Android
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/androidjava/managing-tags-and-custom-data
keywords:
- properti dokumen
- tag
- data khusus
- menambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Menambahkan, membaca, memperbarui, dan menghapus tag & data khusus di Aspose.Slides untuk Android, dengan contoh Java untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Secara singkat dijelaskan bagaimana data disimpan dalam file PPTX, disebutkan bahwa data khusus presentasi dapat ada sebagai tag dan bagian XML khusus, serta menjelaskan tag sebagai pasangan string kunci‑nilai.

Artikel ini juga menunjukkan cara membaca nilai tag dan cara menambahkan tag ke presentasi, slide individual, atau shape. Selain itu, artikel ini mencakup tugas manajemen tag umum seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terkandung dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part diizinkan memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik presentasi) atau pengguna dapat ada sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITagCollection)) dan CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Tag pada dasarnya adalah pasangan nilai string‑kunci. 
{{% /alert %}} 

## **Mengambil Nilai Tag**

Dalam slides, sebuah tag berhubungan dengan metode [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) dan [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Kode contoh ini menunjukkan cara memperoleh nilai tag dengan Aspose.Slides untuk Android via Java untuk [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus - `MyTag`
- nilai properti khusus - `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka Anda dapat memanfaatkan penambahan tag ke presentasi tersebut. Misalnya, jika Anda ingin mengelompokkan semua presentasi dari negara-negara Amerika Utara, Anda dapat membuat tag “North American” dan kemudian menetapkan negara‑negara terkait (AS, Meksiko, dan Kanada) sebagai nilainya.

Kode contoh ini menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) menggunakan Aspose.Slides untuk Android via Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Atau untuk setiap [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) individual:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi data khusus menggunakan `getCustomData().getTags()` disimpan hanya di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF saat presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Workaround**: Anda dapat menyimpan pengidentifikasi khusus di **Alt Text** objek (misalnya, `shape.setAlternativeText("MyId")`). Setelah mengekspor ke PDF, Alt Text mungkin muncul dalam struktur tag PDF.

## **Tanya Jawab**

**Apakah saya dapat menghapus semua tag dari sebuah presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#clear--) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa iterasi seluruh koleksi?**

Gunakan operasi [remove(name)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) pada [koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) pada [koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/); metode ini mengembalikan array berisi semua nama tag.