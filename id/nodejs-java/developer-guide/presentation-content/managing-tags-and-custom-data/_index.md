---
title: Kelola Tag dan Data Khusus dalam Presentasi Menggunakan JavaScript
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/nodejs-java/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- XML khusus
- bagian XML khusus
- metadata XML
- ItemId
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java, termasuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan payload XML khusus aplikasi.

Aspose.Slides menyediakan API untuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada level presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengidentifikasi manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam presentasi.

## **Penyimpanan Data dalam Berkas Presentasi**

Berkas PPTX—berkas dengan ekstensi `.pptx`—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi beberapa bagian yang terhubung melalui hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([TagCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/)) atau bagian XML khusus ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customxmlpartcollection/)). Keduanya tersedia melalui kelas [`CustomData`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Tag menyimpan pasangan kunci‑nilai string sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Metode `getCustomXmlParts()` dari [`CustomData`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customdata/) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Contohnya:

- `presentation.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `slide.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `shape.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi terlepas dari tempat mereka terkait.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan metode `add` dari [`CustomXmlPartCollection`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customxmlpartcollection/) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus tingkat presentasi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add secara otomatis menetapkan sebuah pengidentifikasi. Tetapkan UUID tertentu hanya bila diperlukan.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode `add` juga dapat menerima XML sebagai array byte, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu alih‑alih seluruh presentasi. Ini berguna ketika metadata hanya menggambarkan satu objek, seperti kunci templat, pengidentifikasi catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke sebuah slide dan satu lagi ke sebuah shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tingkat di mana sebuah bagian ditambahkan menentukan koleksi `getCustomData().getCustomXmlParts()` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang milik slide tertentu, dan data tingkat shape untuk metadata yang terkait dengan shape tunggal.

### **Daftar dan Audit Semua Bagian XML Khusus**

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`CustomXmlPart`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customxmlpart/) menampilkan identifiernya, konten XML, dan skema namespace yang terkait.

Contoh berikut menampilkan semua bagian XML khusus beserta skema namespace‑nya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`CustomXmlPart.getNamespaceSchemas()`(...) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Baca dan Perbarui Konten XML serta ItemId**

Gunakan `getXmlAsString()` dan `setXmlAsString()` dari [`CustomXmlPart`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/customxmlpart/) untuk bekerja dengan XML sebagai string UTF‑8, atau `getXmlData()` dan `setXmlData()` untuk bekerja dengan byte XML mentah.

Metode `getItemId()` mengembalikan UUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Gunakan `setItemId()` ketika integrasi memerlukan pengidentifikasi baru.

Contoh berikut memperbarui konten XML dan identifiernya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Baca XML saat ini sebagai teks.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Perbarui XML sebagai string UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData menyediakan konten XML yang sama sebagai byte mentah.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Ganti pengidentifikasi ketika diminta oleh integrasi.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saat memanggil `setXmlAsString` atau `setXmlData`, berikan XML yang valid dan tidak kosong. Gunakan salah satu representasi tergantung pada apakah aplikasi bekerja terutama dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- `CustomXmlPart.remove` menghapus bagian XML khusus dari presentasi.
- `CustomXmlPartCollection.remove` menghapus bagian tertentu dari koleksi bagian XML khusus.
- `CustomXmlPartCollection.removeAt` menghapus bagian pada indeks koleksi yang ditentukan.
- `CustomXmlPartCollection.clear` menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi dengan referensi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda sudah memiliki `CustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi alih‑alih mengakses koleksi tertentu, panggil `customXmlPart.remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bersihkan Semua Bagian XML Khusus dari Koleksi**

Gunakan `clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` hanya memengaruhi koleksi yang dipilih. Misalnya, membersihkan koleksi slide tidak membersihkan koleksi tingkat presentasi atau shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasi melalui `getAllCustomXmlParts()` dan hapus setiap bagian:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menangani Bagian XML Khusus yang Terhubung atau Dibagikan**

Dalam presentasi Office Open XML, bagian XML khusus yang sama dapat dirujuk oleh lebih dari satu objek presentasi. Misalnya, sebuah berkas yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbarui dengan `setXmlAsString`, `setXmlData`, atau `setItemId` mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di mana pun bagian tersebut dirujuk.
- `getItemId()` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `getCustomXmlParts()` tertentu menghapusnya dari koleksi tersebut. Gunakan `CustomXmlPart.remove()` ketika bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi tingkat objek untuk menentukan apakah slide atau shape lain masih merujuknya.

Overload `add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `CustomXmlPart` yang sudah ada. Oleh karena itu, hubungan berbagi paling sering ditemui saat memuat presentasi yang sudah berisi mereka.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` dan melaporkan bagian yang dirujuk dari lebih dari satu tempat:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Jenis audit ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mendapatkan Nilai Tag**

Di slides, sebuah tag berkorespondensi dengan metode `DocumentProperties.getKeywords()`. Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk Node.js via Java untuk [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, jika Anda ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara terkait sebagai nilainya.

Kode contoh ini menunjukkan cara menambahkan tag ke [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) menggunakan Aspose.Slides untuk Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tag juga dapat diatur untuk sebuah [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `getCustomData().getTags()` hanya disimpan dalam berkas PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF saat presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditandai.

**Solusi**: Anda dapat menyimpan pengidentifikasi khusus dalam **Alt Text** objek (misalnya, `shape.setAlternativeText("MyId")`). Setelah mengekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa iterasi seluruh koleksi?**

Gunakan `remove(name)` pada [koleksi tag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analitik atau penyaringan?**

Gunakan `getNamesOfTags()` pada [koleksi tag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tagcollection/); ini mengembalikan array semua nama tag.

**Bagaimana saya dapat menemukan semua bagian XML khusus tanpa mempedulikan tempat penyimpanannya?**

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan `getXmlAsString`/`setXmlAsString` atau `getXmlData`/`setXmlData` untuk memperbarui bagian XML khusus?**

Gunakan `getXmlAsString` dan `setXmlAsString` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `getXmlData` dan `setXmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua representasi merujuk pada konten XML dari bagian XML khusus yang sama.