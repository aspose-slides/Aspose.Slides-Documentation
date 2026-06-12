---
title: "Kelola Tag dan Data Kustom dalam Presentasi Menggunakan JavaScript"
linktitle: "Tag dan Data Kustom"
type: docs
weight: 300
url: /id/nodejs-java/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan, membaca, memperbarui, dan menghapus tag & data khusus di Aspose.Slides untuk Node.js, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Ringkasan**

Artikel ini menjelaskan bagaimana Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Artikel ini secara singkat menjelaskan bagaimana data disimpan dalam file PPTX, mencatat bahwa data khusus presentasi dapat berupa tag dan bagian XML khusus, serta mendeskripsikan tag sebagai pasangan string kunci‑nilai.

Selain itu, artikel ini menunjukkan cara membaca nilai tag dan cara menambahkan tag ke sebuah presentasi, slide individu, atau shape. Selain itu, artikel ini mencakup tugas umum manajemen tag seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terdapat dalam presentasi.

Dengan *slide* menjadi salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part dapat memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik untuk sebuah presentasi) atau pengguna dapat berupa tag ([TagCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TagCollection)) dan CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Tag pada dasarnya adalah nilai pasangan string‑kunci. 

{{% /alert %}} 

## **Mendapatkan Nilai Tag**

Dalam slides, sebuah tag berkorespondensi dengan metode [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) dan [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Kode contoh berikut menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk Node.js via Java untuk [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus - `MyTag`
- nilai properti khusus - `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, Anda dapat memperoleh manfaat dengan menambahkan tag ke presentasi tersebut. Misalnya, jika Anda ingin mengkategorikan atau mengelompokkan semua presentasi dari negara-negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan kemudian menetapkan negara yang relevan (AS, Meksiko, dan Kanada) sebagai nilai.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) menggunakan Aspose.Slides untuk Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Atau untuk [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) individual:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi tag data khusus menggunakan `getCustomData().getTags()` hanya disimpan dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditandai.

**Solusi sementara**: Anda dapat menyimpan pengidentifikasi khusus dalam **Alt Text** objek (misalnya, `shape.setAlternativeText("MyId")`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Bisakah saya menghapus semua tag dari sebuah presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa melakukan iterasi atas seluruh koleksi?**

Gunakan operasi [remove(name)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) pada [koleksi tag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/); metode ini mengembalikan array berisi semua nama tag.