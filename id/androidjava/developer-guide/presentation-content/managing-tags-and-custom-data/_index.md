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
- XML khusus
- bagian XML khusus
- metadata XML
- ItemId
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk Android via Java, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan payload XML khusus aplikasi.

Aspose.Slides menyediakan API untuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengenal manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam sebuah presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX — file dengan ekstensi `.pptx` — disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi banyak bagian yang terhubung oleh hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITagCollection)) atau bagian XML khusus ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Kedua‑nya tersedia melalui antarmuka [`ICustomData`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Tag menyimpan pasangan string kunci‑nilai sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Metode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Contohnya:

- `presentation.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `slide.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `shape.getCustomData().getCustomXmlParts()` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi terlepas dari lokasi kaitannya.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus tingkat presentasi:

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

    // add secara otomatis memberikan pengenal. Tetapkan UUID khusus hanya bila diperlukan.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode `add` juga dapat menerima XML sebagai array byte atau aliran masukan, yang berguna bila konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu alih‑alih seluruh presentasi. Ini berguna ketika metadata hanya menjelaskan satu objek, seperti kunci templat, pengenal catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke slide dan satu lagi ke shape:

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

Tingkat di mana sebuah bagian ditambahkan menentukan koleksi `getCustomData().getCustomXmlParts()` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang dimiliki slide tertentu, dan data tingkat shape untuk metadata yang terikat pada shape individual.

### **Mendaftar dan Mengaudit Semua Bagian XML Khusus**

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`ICustomXmlPart`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart/) menampilkan pengenal, konten XML, dan skema namespace yang terkait.

Contoh berikut mendaftar semua bagian XML khusus beserta skema namespace‑nya:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) dan [`setXmlAsString()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) untuk bekerja dengan XML sebagai string UTF‑8, atau [`getXmlData()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) dan [`setXmlData()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) untuk bekerja dengan byte XML mentah.

Metode [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) mengembalikan UUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Gunakan [`setItemId()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) ketika sebuah integrasi memerlukan pengenal baru.

Contoh berikut memperbarui konten XML dan pengenal:

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

    // Ganti pengenal ketika diperlukan oleh integrasi.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saat memanggil `setXmlAsString` atau `setXmlData`, berikan XML yang valid dan tidak kosong. Gunakan salah satu representasi tergantung apakah aplikasi bekerja terutama dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPart#remove--) menghapus bagian XML khusus dari presentasi.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) menghapus bagian pada indeks koleksi yang ditentukan.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi dengan referensi:

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

Jika Anda sudah memiliki sebuah `ICustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi daripada menargetkan koleksi tertentu, panggil `customXmlPart.remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Mengosongkan Semua Bagian XML Khusus dari Sebuah Koleksi**

Gunakan `clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

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

`clear` memengaruhi hanya koleksi yang dipilih. Misalnya, mengosongkan koleksi slide tidak mengosongkan koleksi tingkat presentasi atau shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasi melalui `getAllCustomXmlParts()` dan hapus setiap bagian:

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

### **Menangani Bagian XML Khusus yang Ditautkan atau Dibagi**

Dalam presentasi Office Open XML, bagian XML khusus yang sama dapat dirujuk dari lebih dari satu objek presentasi. Misalnya, sebuah file yang ada dapat berisi hubungan dari banyak slide atau shape ke bagian XML khusus yang mendasarinya.

Bagian yang dibagi harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbaruinya dengan `setXmlAsString`, `setXmlData`, atau `setItemId` mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di mana pun bagian itu dirujuk.
- `getItemId()` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `getCustomXmlParts()` tertentu menghapusnya dari koleksi itu. Gunakan `ICustomXmlPart.remove()` ketika bagian itu sendiri harus dihapus dari seluruh presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagi, periksa koleksi tingkat objek untuk menentukan apakah slide atau shape lain masih merujuknya.

Overload `add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `ICustomXmlPart` yang sudah ada. Karena itu, hubungan yang dibagi paling sering ditemui saat memuat presentasi yang sudah mengandungnya.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` serta melaporkan bagian yang dirujuk dari lebih dari satu tempat:

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

Audit semacam ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mengambil Nilai Tag**

Di Slides, sebuah tag berkorespondensi dengan metode `IDocumentProperties.getKeywords()`. Kode contoh berikut menunjukkan cara mengambil nilai tag dengan Aspose.Slides untuk Android via Java untuk [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation):

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

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk keperluan tersebut. Misalnya, bila ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara terkait sebagai nilainya.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) menggunakan Aspose.Slides untuk Android via Java:

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

Tag juga dapat diatur untuk sebuah [Slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide):

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

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) individual:

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

Tag yang ditambahkan melalui koleksi `getCustomData().getTags()` hanya disimpan dalam file PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Solusi**: Anda dapat menyimpan pengenal khusus di **Alt Text** objek (misalnya, `shape.setAlternativeText("MyId")`). Setelah mengekspor ke PDF, Alt Text mungkin muncul di struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#clear--) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa mengiterasi seluruh koleksi?**

Gunakan [remove(name)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) pada [koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analitik atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) pada [koleksi tag](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tagcollection/); itu mengembalikan array semua nama tag.

**Bagaimana saya dapat menemukan semua bagian XML khusus tanpa mempedulikan tempat penyimpanannya?**

Gunakan [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan `getXmlAsString`/`setXmlAsString` atau `getXmlData`/`setXmlData` untuk memperbarui bagian XML khusus?**

Gunakan `getXmlAsString` dan `setXmlAsString` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `getXmlData` dan `setXmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua representasi merujuk pada konten XML dari bagian XML khusus yang sama.