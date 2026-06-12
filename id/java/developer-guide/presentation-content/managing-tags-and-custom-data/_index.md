---
title: Kelola Tag dan Data Kustom dalam Presentasi Menggunakan Java
linktitle: Tag dan Data Kustom
type: docs
weight: 300
url: /id/java/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data kustom
- menambahkan tag
- pasangan nilai
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menambah, membaca, memperbarui, dan menghapus tag serta data kustom di Aspose.Slides untuk Java, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Secara singkat dijelaskan bagaimana data disimpan dalam file PPTX, bahwa data spesifik presentasi dapat berada sebagai tag dan bagian XML khusus, serta tag dijelaskan sebagai pasangan string kunci‑nilai.

Artikel ini juga menunjukkan cara membaca nilai tag dan cara menambahkan tag ke presentasi, slide individu, atau shape. Selain itu, artikel membahas tugas umum pengelolaan tag seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terdapat dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part dapat memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik presentasi) atau data pengguna dapat ada sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITagCollection)) dan CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Tag pada dasarnya adalah pasangan nilai string‑kunci. 

{{% /alert %}} 

## **Mengambil Nilai Tag**

Di Slides, sebuah tag berhubungan dengan metode [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IDocumentProperties#getKeywords--) dan [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Kode contoh berikut memperlihatkan cara mengambil nilai tag menggunakan Aspose.Slides for Java untuk [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation):

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

- nama properti khusus – `MyTag`
- nilai properti khusus – `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka Anda dapat memanfaatkan penambahan tag ke presentasi tersebut. Misalnya, jika Anda ingin mengelompokkan semua presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag “North American” dan kemudian menetapkan negara‑negara yang relevan (AS, Meksiko, dan Kanada) sebagai nilainya.

Kode contoh berikut memperlihatkan cara menambahkan tag ke [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) menggunakan Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Atau untuk [Shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) individu:

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

Tag yang ditambahkan melalui koleksi tag data khusus menggunakan `getCustomData().getTags()` disimpan hanya di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang telah ditag.

**Workaround**: Anda dapat menyimpan pengenal khusus di **Alt Text** objek (mis., `shape.setAlternativeText("MyId")`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [tag collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#clear--) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus iterasi seluruh koleksi?**

Gunakan operasi [Remove(name)](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) pada [tag collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#getNamesOfTags--) pada [tag collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/); metode ini mengembalikan array berisi semua nama tag.