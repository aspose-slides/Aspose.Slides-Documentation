---
title: Kelola Tag dan Data Kustom dalam Presentasi Menggunakan C++
linktitle: Tag dan Data Kustom
type: docs
weight: 300
url: /id/cpp/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data kustom
- XML kustom
- bagian XML kustom
- metadata XML
- ItemId
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML kustom dalam presentasi PowerPoint dengan Aspose.Slides untuk C++, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML kustom."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara kerja Aspose.Slides dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan muatan XML yang spesifik untuk aplikasi.

Aspose.Slides menyediakan API untuk menambah, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengenal manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam sebuah presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX — file dengan ekstensi `.pptx` — disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi banyak bagian yang terhubung oleh hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([ITagCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/itagcollection/)) atau bagian XML khusus ([ICustomXmlPartCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/)). Keduanya tersedia melalui antarmuka [`ICustomData`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Tag menyimpan pasangan kunci‑nilai string sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Metode [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomdata/get_customxmlparts/) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Contohnya:

- `presentation->get_CustomData()->get_CustomXmlParts()` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `slide->get_CustomData()->get_CustomXmlParts()` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `shape->get_CustomData()->get_CustomXmlParts()` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_allcustomxmlparts/) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi tanpa memperhatikan lokasi kaitannya.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/add/) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus tingkat presentasi:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add secara otomatis menetapkan pengenal. Tetapkan GUID spesifik hanya bila diperlukan.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Metode `Add` juga dapat menerima XML sebagai array byte atau aliran, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu alih‑alih seluruh presentasi. Ini berguna ketika metadata hanya menjelaskan satu objek, seperti kunci templat, pengenal catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke sebuah slide dan satu lagi ke sebuah shape:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Tingkat di mana bagian ditambahkan menentukan koleksi `get_CustomData()->get_CustomXmlParts()` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang merupakan milik slide tertentu, dan data tingkat shape untuk metadata yang terkait dengan shape individu.

### **Mencantumkan dan Mengaudit Semua Bagian XML Khusus**

Gunakan [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_allcustomxmlparts/) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`ICustomXmlPart`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/) menampilkan pengenal, konten XML, dan skema namespace yang terkait.

Contoh berikut mencantumkan semua bagian XML khusus beserta skema namespace‑nya:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) dan `set_XmlAsString` untuk bekerja dengan XML sebagai string UTF‑8, atau [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/get_xmldata/) dan `set_XmlData` untuk bekerja dengan byte XML mentah. Kedua representasi dapat dibaca dan diperbarui.

Metode [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/get_itemid/) mengembalikan GUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Pengenal tersebut juga dapat diubah dengan `set_ItemId` ketika integrasi memerlukan pengenal baru.

Contoh berikut memperbarui konten XML dan pengenal:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Baca XML saat ini sebagai teks.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Perbarui XML sebagai string UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData menyediakan konten XML yang sama sebagai byte mentah.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Ganti pengenal ketika diperlukan oleh integrasi.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Saat menetapkan XML dengan `set_XmlAsString` atau `set_XmlData`, pastikan XML valid dan tidak kosong. Gunakan salah satu representasi sesuai dengan apakah aplikasi Anda bekerja terutama dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpart/remove/) menghapus bagian XML khusus dari presentasi.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/remove/) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/removeat/) menghapus bagian pada indeks koleksi yang ditentukan.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/id/cpp/aspose.slides/icustomxmlpartcollection/clear/) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi melalui referensi:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Jika Anda sudah memiliki `ICustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi alih‑alih mengakses koleksi tertentu, panggil `customXmlPart->Remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Mengosongkan Semua Bagian XML Khusus dari Sebuah Koleksi**

Gunakan `Clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` hanya memengaruhi koleksi yang dipilih. Misalnya, mengosongkan koleksi slide tidak mengosongkan koleksi tingkat presentasi atau tingkat shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasikan melalui `get_AllCustomXmlParts()` dan hapus masing‑masing bagian:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Menangani Bagian XML Khusus yang Tertaut atau Dibagikan**

Dalam presentasi Office Open XML, bagian XML khusus yang sama dapat dirujuk dari lebih dari satu objek presentasi. Misalnya, sebuah file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbaruinya dengan `set_XmlAsString`, `set_XmlData`, atau `set_ItemId` mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di mana pun bagian tersebut dirujuk.
- `get_ItemId()` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `get_CustomXmlParts()` tertentu menghapusnya hanya dari koleksi itu. Gunakan `ICustomXmlPart::Remove()` ketika bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi tingkat objek untuk memastikan apakah slide atau shape lain masih merujuknya.

Overload `Add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `ICustomXmlPart` yang sudah ada. Oleh sebab itu, hubungan berbagi paling sering ditemui saat memuat presentasi yang sudah berisi hubungan tersebut.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` dan melaporkan bagian yang dirujuk dari lebih dari satu tempat:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Jenis audit ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mendapatkan Nilai Tag**

Di slides, sebuah tag berkorespondensi dengan properti `IDocumentProperties::get_Keywords`. Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk C++ untuk [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua elemen:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, bila ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara yang relevan sebagai nilainya.

Kode contoh berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menggunakan Aspose.Slides untuk C++ :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tag juga dapat disetel untuk sebuah [Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/) :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/) individu :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `get_CustomData()->get_Tags()` hanya disimpan dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditag.

**Solusi**: Anda dapat menyimpan pengenal khusus dalam **Alt Text** objek (misalnya, `shape->set_AlternativeText(u"MyId")`). Setelah diekspor ke PDF, Alt Text mungkin muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/) mendukung operasi [Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus mengiterasi seluruh koleksi?**

Gunakan [Remove(name)](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [GetNamesOfTags](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/getnamesoftags/) pada [koleksi tag](https://reference.aspose.com/slides/id/cpp/aspose.slides/tagcollection/); ia mengembalikan array semua nama tag.

**Bagaimana cara menemukan semua bagian XML khusus terlepas dari tempat penyimpanannya?**

Gunakan [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_allcustomxmlparts/) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan `get_XmlAsString`/`set_XmlAsString` atau `get_XmlData`/`set_XmlData` untuk memperbarui bagian XML khusus?**

Gunakan `get_XmlAsString` dan `set_XmlAsString` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `get_XmlData` dan `set_XmlData` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua representasi merujuk pada konten XML bagian XML khusus yang sama.