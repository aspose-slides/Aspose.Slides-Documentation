---
title: Kelola Tag dan Data Khusus dalam Presentasi di .NET
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/net/managing-tags-and-custom-data/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET, termasuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan payload XML aplikasi‑spesifik.

Aspose.Slides menyediakan API untuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengenal manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam sebuah presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX — file dengan ekstensi `.pptx` — disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi banyak bagian yang terhubung melalui hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/net/aspose.slides/itagcollection)) atau bagian XML khusus ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection)). Keduanya tersedia melalui antarmuka [`ICustomData`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Tag menyimpan pasangan string kunci‑nilai sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Properti [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomdata/customxmlparts/) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Contohnya:

- `presentation.CustomData.CustomXmlParts` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `slide.CustomData.CustomXmlParts` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `shape.CustomData.CustomXmlParts` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/allcustomxmlparts/) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi tanpa memandang di mana mereka terkait.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection/add/) untuk menambah data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus tingkat presentasi:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add menetapkan pengidentifikasi secara otomatis. Tetapkan GUID khusus hanya bila diperlukan.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Metode `Add` juga dapat menerima XML sebagai array byte atau stream, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu alih‑alih seluruh presentasi. Ini berguna ketika metadata hanya menjelaskan satu objek, misalnya kunci templat, pengenal catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke slide dan satu lagi ke shape:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Tingkat di mana bagian ditambahkan menentukan koleksi `CustomData.CustomXmlParts` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang milik slide tertentu, dan data tingkat shape untuk metadata yang terikat pada shape individu.

### **Daftar dan Audit Semua Bagian XML Khusus**

Gunakan [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/allcustomxmlparts/) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`ICustomXmlPart`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/) menampilkan pengenal, konten XML, dan skema namespace yang terkait.

Contoh berikut menampilkan semua bagian XML khusus beserta skema namespace‑nya:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/namespaceschemas/) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang memuat XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/xmlasstring/) untuk bekerja dengan XML sebagai string UTF‑8, atau [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/xmldata/) untuk bekerja dengan byte XML mentah. Kedua properti dapat dibaca dan diperbarui.

Properti [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/itemid/) berisi GUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. GUID ini juga dapat diubah bila integrasi memerlukan pengenal baru.

Contoh berikut memperbarui konten XML serta pengenal:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Baca XML saat ini sebagai teks.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Perbarui XML sebagai string UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData menyediakan konten XML yang sama dalam bentuk byte mentah.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Ganti pengidentifikasi bila diperlukan oleh integrasi.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Saat menetapkan `XmlAsString` atau `XmlData`, berikan XML yang valid dan tidak kosong. Gunakan satu representasi atau yang lain tergantung apakah aplikasi Anda lebih banyak bekerja dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpart/remove/) menghapus bagian XML khusus dari presentasi.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection/remove/) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection/removeat/) menghapus bagian pada indeks koleksi yang ditentukan.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/id/net/aspose.slides/icustomxmlpartcollection/clear/) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi melalui referensi:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Jika Anda sudah memiliki objek `ICustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi tanpa menyasar koleksi tertentu, panggil `customXmlPart.Remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Mengosongkan Semua Bagian XML Khusus dari Sebuah Koleksi**

Gunakan `Clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` hanya memengaruhi koleksi yang dipilih. Misalnya, mengosongkan koleksi slide tidak mengosongkan koleksi tingkat presentasi atau tingkat shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasi melalui `AllCustomXmlParts` dan hapus masing‑masing:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Menangani Bagian XML Khusus yang Ditautkan atau Dibagi**

Dalam sebuah presentasi Office Open XML, bagian XML khusus yang sama dapat dirujuk dari lebih dari satu objek presentasi. Misalnya, sebuah file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagi harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbarui `XmlAsString`, `XmlData`, atau `ItemId` mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di semua tempat bagian tersebut dirujuk.
- `ItemId` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `CustomXmlParts` tertentu hanya menghapusnya dari koleksi itu. Gunakan `ICustomXmlPart.Remove()` ketika bagian itu sendiri harus dihapus dari seluruh presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagi, periksa koleksi tingkat objek untuk memastikan apakah slide atau shape lain masih merujuknya.

Overload `Add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `ICustomXmlPart` yang sudah ada. Oleh karena itu, hubungan yang dibagi paling sering ditemui saat memuat presentasi yang sudah berisi mereka.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` serta melaporkan bagian yang dirujuk dari lebih dari satu tempat:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Audit jenis ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama mungkin berpartisipasi dalam lebih dari satu hubungan.

## **Mendapatkan Nilai Tag**

Dalam slide, sebuah tag berhubungan dengan properti `IDocumentProperties.Keywords`. Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk .NET untuk [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, jika ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag “NorthAmerican” dan menetapkan negara terkait sebagai nilainya.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) menggunakan Aspose.Slides untuk .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tag juga dapat diatur untuk sebuah [Slide](https://reference.aspose.com/slides/id/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/net/aspose.slides/shape) individu:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `CustomData.Tags` hanya disimpan di file PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ber‑tag.

**Solusi**: Anda dapat menyimpan pengenal khusus di **Alt Text** objek (misalnya, `shape.AlternativeText = "MyId"`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Tag collection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/) mendukung operasi [Clear](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus iterasi seluruh koleksi?**

Gunakan [Remove(name)](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara memperoleh daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [GetNamesOfTags](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/getnamesoftags/) pada [tag collection](https://reference.aspose.com/slides/id/net/aspose.slides/tagcollection/); metode ini mengembalikan array semua nama tag.

**Bagaimana cara menemukan semua bagian XML khusus terlepas dari lokasi penyimpanannya?**

Gunakan [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/allcustomxmlparts/) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan `XmlAsString` atau `XmlData` untuk memperbarui bagian XML khusus?**

Gunakan `XmlAsString` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `XmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua properti mewakili konten XML dari bagian XML khusus yang sama.