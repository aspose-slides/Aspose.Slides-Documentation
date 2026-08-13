---
title: Mengelola Tag dan Data Khusus dalam Presentasi Menggunakan Java
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk Java, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML kustom. Tag adalah pasangan string kunci-nilai sederhana, sedangkan bagian XML kustom dapat menyimpan metadata terstruktur dan payload XML spesifik aplikasi.

Aspose.Slides menyediakan API untuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML kustom pada tingkat presentasi, slide, dan shape. Bagian XML kustom berguna untuk integrasi yang menyimpan informasi seperti pengidentifikasi manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya dalam sebuah presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—file dengan ekstensi `.pptx`—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi dan data terkait.

Sebuah presentasi berisi beberapa bagian yang terhubung oleh hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITagCollection)) atau bagian XML kustom ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection)). Keduaannya tersedia melalui antarmuka [`ICustomData`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Tag menyimpan pasangan string kunci-nilai sederhana. Bagian XML kustom menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Kustom**

Metode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomData#getCustomXmlParts--) mengembalikan koleksi bagian XML kustom yang terkait dengan objek presentasi tertentu. Misalnya:

- `presentation.getCustomData().getCustomXmlParts()` berisi bagian XML kustom yang terkait dengan presentasi itu sendiri.
- `slide.getCustomData().getCustomXmlParts()` berisi bagian XML kustom yang terkait dengan slide tertentu.
- `shape.getCustomData().getCustomXmlParts()` berisi bagian XML kustom yang terkait dengan shape tertentu.

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) ketika Anda perlu memeriksa semua bagian XML kustom dalam presentasi terlepas dari tempat mereka terkait.

### **Menambahkan Bagian XML Kustom ke Presentasi**

Gunakan [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) untuk menambahkan data XML ke koleksi bagian XML kustom. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data kustom tingkat presentasi:
```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add secara otomatis menetapkan identifier. Tetapkan UUID khusus hanya bila diperlukan.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode `add` juga dapat menerima XML sebagai array byte atau aliran input, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Kustom ke Slide atau Shape**

Data XML kustom dapat dikaitkan dengan slide atau shape tertentu alih-alih seluruh presentasi. Ini berguna ketika metadata hanya menggambarkan satu objek, seperti kunci templat, identifier record eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML kustom ke slide dan satu lagi ke shape:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tingkat di mana sebuah bagian ditambahkan menentukan koleksi `getCustomData().getCustomXmlParts()` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang milik slide tertentu, dan data tingkat shape untuk metadata yang terikat pada shape individual.

### **Mencantumkan dan Mengaudit Semua Bagian XML Kustom**

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) untuk mengambil semua bagian XML kustom dari sebuah presentasi. Setiap [`ICustomXmlPart`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart/) menampilkan identifier, konten XML, dan skema namespace yang terkait.

Contoh berikut mencantumkan semua bagian XML kustom dan skema namespace mereka:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

`ICustomXmlPart.getNamespaceSchemas()` mengembalikan skema XML yang terkait dengan bagian XML kustom. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) dan [`setXmlAsString()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) untuk bekerja dengan XML sebagai string UTF-8, atau [`getXmlData()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#getXmlData--) dan [`setXmlData()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) untuk bekerja dengan byte XML mentah.

Metode [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#getItemId--) mengembalikan UUID yang mengidentifikasi bagian XML kustom dalam dokumen Office Open XML. Gunakan [`setItemId()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) ketika sebuah integrasi memerlukan identifier baru.

Contoh berikut memperbarui konten XML dan identifier:
```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Baca XML saat ini sebagai teks.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Perbarui XML sebagai string UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData menyediakan konten XML yang sama sebagai byte mentah.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Ganti identifier ketika diperlukan oleh integrasi.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saat memanggil `setXmlAsString` atau `setXmlData`, berikan XML yang valid dan tidak kosong. Gunakan salah satu representasi tergantung apakah aplikasi bekerja terutama dengan string atau data byte.

### **Menghapus Bagian XML Kustom**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML kustom:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPart#remove--) menghapus bagian XML kustom dari presentasi.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) menghapus bagian tertentu dari koleksi bagian XML kustom.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) menghapus bagian pada indeks koleksi yang ditentukan.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICustomXmlPartCollection#clear--) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML kustom tingkat presentasi berdasarkan referensi:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda sudah memiliki `ICustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi alih-alih menargetkan koleksi tertentu, panggil `customXmlPart.remove()`.

Anda juga dapat menghapus item berdasarkan indeks:
```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Menghapus Semua Bagian XML Kustom dari Koleksi**

Gunakan `clear` ketika semua bagian XML kustom yang terkait dengan objek presentasi tertentu harus dihapus.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` memengaruhi hanya koleksi yang dipilih. Misalnya, menghapus koleksi slide tidak menghapus koleksi tingkat presentasi atau tingkat shape.

Untuk menghapus semua bagian XML kustom dalam presentasi, iterasi melalui `getAllCustomXmlParts()` dan hapus setiap bagian:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menangani Bagian XML Kustom yang Tertaut atau Dibagikan**

Dalam presentasi Office Open XML, bagian XML kustom yang sama dapat dirujuk dari lebih dari satu objek presentasi. Misalnya, file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML kustom yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan beberapa referensi:

- Memperbarui dengan `setXmlAsString`, `setXmlData`, atau `setItemId` mengubah bagian XML kustom yang mendasari, sehingga perubahan berlaku di mana pun bagian tersebut dirujuk.
- `getItemId()` dapat digunakan untuk mengidentifikasi bagian XML kustom yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `getCustomXmlParts()` tertentu menghapusnya dari koleksi tersebut. Gunakan `ICustomXmlPart.remove()` ketika bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi tingkat objek untuk menentukan apakah slide atau shape lain masih merujuknya.

Overload `add` membuat bagian XML kustom baru dari konten XML; mereka tidak menerima `ICustomXmlPart` yang sudah ada. Oleh karena itu, hubungan berbagi paling umum ditemui saat memuat presentasi yang sudah berisi mereka.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` dan melaporkan bagian yang dirujuk dari lebih dari satu tempat:
```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Audit jenis ini berguna sebelum memodifikasi atau menghapus data XML kustom dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mendapatkan Nilai Tag**

Dalam slide, tag berkorespondensi dengan metode `IDocumentProperties.getKeywords()`. Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk Java untuk [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation):
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti kustom, misalnya `MyTag`;
- nilai properti kustom, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, jika Anda ingin mengkategorikan presentasi dari negara-negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara yang relevan sebagai nilainya.

Kode contoh ini menunjukkan cara menambahkan tag ke [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) menggunakan Aspose.Slides untuk Java:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide):
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Atau untuk [Shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) individual:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `getCustomData().getTags()` hanya disimpan dalam file PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, identifier kustom yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditag.

**Solusi**: Anda dapat menyimpan identifier kustom dalam **Alt Text** objek (misalnya, `shape.setAlternativeText("MyId")`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**  
Ya. [Koleksi tag](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#clear--) yang menghapus semua pasangan kunci-nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa mengiterasi seluruh koleksi?**  
Gunakan [remove(name)](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) pada [koleksi tag](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**  
Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/#getNamesOfTags--) pada [koleksi tag](https://reference.aspose.com/slides/id/java/com.aspose.slides/tagcollection/); ia mengembalikan array semua nama tag.

**Bagaimana saya dapat menemukan semua bagian XML kustom terlepas dari tempat penyimpanannya?**  
Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) untuk mengambil semua bagian XML kustom dalam presentasi.

**Haruskah saya menggunakan `getXmlAsString`/`setXmlAsString` atau `getXmlData`/`setXmlData` untuk memperbarui bagian XML kustom?**  
Gunakan `getXmlAsString` dan `setXmlAsString` ketika aplikasi bekerja dengan teks XML UTF-8. Gunakan `getXmlData` dan `setXmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua representasi merujuk pada konten XML dari bagian XML kustom yang sama.