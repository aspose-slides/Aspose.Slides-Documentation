---
title: Kelola Tag dan Data Khusus dalam Presentasi Menggunakan PHP
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/php-java/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- XML khusus
- bagian XML khusus
- metadata XML
- ItemId
- tambahkan tag
- pasangan nilai
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara kerja Aspose.Slides dengan tag dan data khusus di presentasi PowerPoint. Data khusus pada presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan payload XML aplikasi tertentu.

Aspose.Slides menyediakan API untuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengidentifikasi manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan template, atau data aplikasi terstruktur lainnya di dalam presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX — file dengan ekstensi `.pptx` — disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi banyak bagian yang terhubung melalui hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([TagCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/)) atau bagian XML khusus ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/)). Kedua‑nya tersedia melalui kelas [`CustomData`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}

Tag menyimpan pasangan string kunci‑nilai sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.

{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Metode [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customdata/#getCustomXmlParts) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Contoh:

- `$presentation->getCustomData()->getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `$slide->getCustomData()->getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `$shape->getCustomData()->getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getAllCustomXmlParts) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi tanpa mempedulikan tempat keterkaitannya.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/#add) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus pada tingkat presentasi:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add menetapkan sebuah pengidentifikasi secara otomatis. Tetapkan UUID spesifik hanya bila diperlukan.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metode `add` juga dapat menerima XML sebagai array byte atau stream input, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu daripada seluruh presentasi. Hal ini berguna ketika metadata hanya menggambarkan satu objek, seperti kunci template, pengidentifikasi rekaman eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke slide dan satu lagi ke shape:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tingkat di mana bagian ditambahkan menentukan koleksi `getCustomData()->getCustomXmlParts()` objek mana yang berisi hubungan ke bagian tersebut. Data pada tingkat presentasi cocok untuk metadata seluruh dokumen, data pada tingkat slide untuk informasi yang milik slide tertentu, dan data pada tingkat shape untuk metadata yang terikat pada shape individu.

### **Mendaftar dan Mengaudit Semua Bagian XML Khusus**

Gunakan [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getAllCustomXmlParts) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`CustomXmlPart`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/) menampilkan pengidentifikasi, konten XML, dan skema namespace yang terkait.

Contoh berikut menampilkan semua bagian XML khusus beserta skema namespace‑nya:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#getXmlAsString) dan [`setXmlAsString()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#setXmlAsString) untuk bekerja dengan XML sebagai string UTF‑8, atau [`getXmlData()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#getXmlData) dan [`setXmlData()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#setXmlData) untuk bekerja dengan byte XML mentah.

Metode [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#getItemId) mengembalikan UUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Gunakan [`setItemId()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#setItemId) ketika integrasi memerlukan pengidentifikasi baru.

Contoh berikut memperbarui konten XML dan pengidentifikasinya:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Baca XML saat ini sebagai teks.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Perbarui XML sebagai string UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData menyediakan konten XML yang sama sebagai byte mentah.
    $customXmlData = $customXmlPart->getXmlData();

    // Ganti pengidentifikasi ketika diperlukan oleh integrasi.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Saat memanggil `setXmlAsString` atau `setXmlData`, berikan XML yang valid dan tidak kosong. Pilih satu representasi atau yang lain tergantung apakah aplikasi bekerja lebih banyak dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpart/#remove) menghapus bagian XML khusus dari presentasi.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/#remove) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/#removeAt) menghapus bagian pada indeks koleksi yang ditentukan.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/#clear) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus pada tingkat presentasi melalui referensi:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda sudah memiliki objek `CustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi alih‑alih menargetkan koleksi tertentu, panggil `$customXmlPart->remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Mengosongkan Semua Bagian XML Khusus dari Sebuah Koleksi**

Gunakan `clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` hanya memengaruhi koleksi yang dipilih. Misalnya, mengosongkan koleksi slide tidak mengosongkan koleksi pada tingkat presentasi atau shape.

Untuk menghapus semua bagian XML khusus dalam presentasi, iterasikan melalui `getAllCustomXmlParts()` dan hapus setiap bagian:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Menangani Bagian XML Khusus yang Ditautkan atau Dibagikan**

Dalam sebuah presentasi Office Open XML, bagian XML khusus yang sama dapat direferensikan dari lebih dari satu objek presentasi. Misalnya, sebuah file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbaruinya dengan `setXmlAsString`, `setXmlData`, atau `setItemId` mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di mana pun bagian itu direferensikan.
- `getItemId()` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi pada tingkat objek.
- Menghapus bagian dari koleksi `getCustomXmlParts()` tertentu hanya menghapusnya dari koleksi itu. Gunakan `CustomXmlPart::remove()` bila bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi pada tingkat objek untuk menentukan apakah slide atau shape lain masih merujuknya.

Overload `add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `CustomXmlPart` yang sudah ada. Oleh karena itu, hubungan yang dibagikan paling sering ditemui saat memuat presentasi yang sudah berisi bagian tersebut.

Contoh berikut mengaudit koleksi pada tingkat presentasi, slide, dan shape berdasarkan `ItemId` serta melaporkan bagian yang direferensikan dari lebih dari satu tempat:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Audit semacam ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mengambil Nilai Tag**

Di slides, sebuah tag berkorespondensi dengan metode `DocumentProperties::getKeywords()`. Kode contoh berikut menunjukkan cara mengambil nilai tag dengan Aspose.Slides untuk PHP via Java untuk [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua elemen:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Contoh, bila ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara yang relevan sebagai nilai tag tersebut.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) menggunakan Aspose.Slides untuk PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tag juga dapat diatur untuk sebuah [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) individu:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `getCustomData()->getTags()` hanya disimpan dalam berkas PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Solusi**: Anda dapat menyimpan pengidentifikasi khusus di **Alt Text** objek (contoh, `$shape->setAlternativeText("MyId")`). Setelah diekspor ke PDF, Alt Text mungkin muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/#clear) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa mengiterasi seluruh koleksi?**

Gunakan [remove(name)](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/#remove) pada [koleksi tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara mendapatkan daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/#getNamesOfTags) pada [koleksi tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/); ia mengembalikan array semua nama tag.

**Bagaimana cara menemukan semua bagian XML khusus terlepas dari tempat penyimpanannya?**

Gunakan [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getAllCustomXmlParts) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya memakai `getXmlAsString`/`setXmlAsString` atau `getXmlData`/`setXmlData` untuk memperbarui bagian XML khusus?**

Gunakan `getXmlAsString` dan `setXmlAsString` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `getXmlData` dan `setXmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih praktis. Kedua representasi merujuk pada konten XML dari bagian XML khusus yang sama.