---
title: Kelola Tag dan Data Kustom dalam Presentasi dengan Python
linktitle: Tag dan Data Kustom
type: docs
weight: 300
url: /id/python-net/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data kustom
- XML kustom
- bagian XML kustom
- metadata XML
- ItemId
- tambahkan tag
- pasangan nilai
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML kustom dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML kustom."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan muatan XML spesifik aplikasi.

Aspose.Slides menyediakan API untuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengidentifikasi manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—file dengan ekstensi `.pptx`—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi beberapa bagian yang terhubung oleh hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([TagCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/)) atau bagian XML khusus ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpartcollection/)). Keduanya tersedia melalui kelas [`CustomData`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tag menyimpan pasangan string kunci‑nilai sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Kustom**

Properti [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customdata/custom_xml_parts/) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Misalnya:

- `presentation.custom_data.custom_xml_parts` berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- `slide.custom_data.custom_xml_parts` berisi bagian XML khusus yang terkait dengan slide tertentu.
- `shape.custom_data.custom_xml_parts` berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/all_custom_xml_parts/) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi tanpa mempedulikan di mana mereka terkait.

### **Tambahkan Bagian XML Kustom ke Presentasi**

Gunakan [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpartcollection/add/) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data kustom tingkat presentasi:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add secara otomatis menetapkan sebuah pengidentifikasi. Tetapkan GUID tertentu hanya bila diperlukan.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Metode `add` juga dapat menerima XML sebagai array byte atau stream, yang berguna bila konten XML sudah tersedia dalam bentuk biner.

### **Tambahkan Bagian XML Kustom ke Slide atau Bentuk**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu alih‑alih seluruh presentasi. Ini berguna ketika metadata hanya menggambarkan satu objek, seperti kunci templat, pengidentifikasi catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke slide dan satu lagi ke shape:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Tingkat tempat bagian ditambahkan menentukan koleksi `custom_data.custom_xml_parts` objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang milik slide tertentu, dan data tingkat shape untuk metadata yang terikat pada satu shape.

### **Daftar dan Audit Semua Bagian XML Kustom**

Gunakan [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/all_custom_xml_parts/) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [`CustomXmlPart`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/) menampilkan pengidentifikasinya, konten XML, dan skema namespace yang terkait.

Contoh berikut mencantumkan semua bagian XML khusus beserta skema namespace‑nya:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/namespace_schemas/) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Baca dan Perbarui Konten XML serta ItemId**

Gunakan [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/xml_as_string/) untuk bekerja dengan XML sebagai string UTF‑8, atau [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/xml_data/) untuk bekerja dengan byte XML mentah. Kedua properti dapat dibaca dan diperbarui.

Properti [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/item_id/) berisi GUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Properti ini juga dapat diubah ketika integrasi memerlukan pengidentifikasi baru.

Contoh berikut memperbarui konten XML dan pengidentifikasinya:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Baca XML saat ini sebagai teks.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Perbarui XML sebagai string UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data menyediakan konten XML yang sama sebagai byte mentah.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Ganti pengidentifikasi bila diperlukan oleh integrasi.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Saat menetapkan `xml_as_string` atau `xml_data`, berikan XML yang valid dan tidak kosong. Gunakan salah satu representasi sesuai dengan apakah aplikasi bekerja terutama dengan string atau data byte.

### **Hapus Bagian XML Kustom**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpart/remove/) menghapus bagian XML khusus dari presentasi.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpartcollection/remove/) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpartcollection/remove_at/) menghapus bagian pada indeks koleksi yang ditentukan.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/id/python-net/aspose.slides/customxmlpartcollection/clear/) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi berdasarkan referensi:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda sudah memiliki `CustomXmlPart` dan ingin menghapus bagian tersebut dari presentasi alih‑alih menargetkan koleksi tertentu, panggil `custom_xml_part.remove()`.

Anda juga dapat menghapus item berdasarkan indeks:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Bersihkan Semua Bagian XML Kustom dari Koleksi**

Gunakan `clear` ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` hanya memengaruhi koleksi yang dipilih. Misalnya, membersihkan koleksi slide tidak menghapus koleksi tingkat presentasi atau tingkat shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasikan `all_custom_xml_parts` dan hapus setiap bagian:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Tangani Bagian XML Kustom yang Ditautkan atau Dibagikan**

Dalam presentasi Office Open XML, bagian XML khusus yang sama dapat direferensikan dari lebih dari satu objek presentasi. Misalnya, file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan beberapa referensi:

- Memperbarui `xml_as_string`, `xml_data`, atau `item_id` mengubah bagian XML khusus yang mendasari, sehingga perubahan berlaku di semua tempat bagian tersebut direferensikan.
- `item_id` dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi `custom_xml_parts` tertentu menghapusnya dari koleksi tersebut. Gunakan `CustomXmlPart.remove()` ketika bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi tingkat objek untuk menentukan apakah slide atau shape lain masih mereferensikannya.

Overload `add` membuat bagian XML khusus baru dari konten XML; mereka tidak menerima `CustomXmlPart` yang sudah ada. Oleh karena itu, hubungan yang dibagikan paling sering ditemui saat memuat presentasi yang sudah berisi mereka.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `item_id` serta melaporkan bagian yang direferensikan dari lebih dari satu tempat:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Audit jenis ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Dapatkan Nilai Tag**

Di Slides, sebuah tag berkorespondensi dengan properti `DocumentProperties.keywords`. Kode contoh berikut memperlihatkan cara mengambil nilai tag dengan Aspose.Slides for Python via .NET untuk [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Tambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, jika Anda ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara terkait sebagai nilainya.

Kode contoh berikut memperlihatkan cara menambahkan tag ke [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) menggunakan Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tag juga dapat disetel untuk sebuah [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) individu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Batasan**

Tag yang ditambahkan melalui koleksi `custom_data.tags` hanya disimpan dalam file PowerPoint. Mereka **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditandai.

**Solusi**: Anda dapat menyimpan pengidentifikasi khusus di **Alt Text** objek (misalnya, `shape.alternative_text = "MyId"`). Setelah diekspor ke PDF, Alt Text mungkin muncul dalam struktur tag PDF.

## **Tanya Jawab**

**Apakah saya dapat menghapus semua tag dari sebuah presentasi, slide, atau shape dalam satu operasi?**  
Ya. [Koleksi tag](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus iterasi seluruh koleksi?**  
Gunakan [remove(name)](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/remove/) pada [TagCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**  
Gunakan [get_names_of_tags](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/get_names_of_tags/) pada [koleksi tag](https://reference.aspose.com/slides/id/python-net/aspose.slides/tagcollection/); ia mengembalikan array semua nama tag.

**Bagaimana saya dapat menemukan semua bagian XML khusus tanpa memperhatikan di mana mereka disimpan?**  
Gunakan [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/all_custom_xml_parts/) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan `xml_as_string` atau `xml_data` untuk memperbarui bagian XML khusus?**  
Gunakan `xml_as_string` ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan `xml_data` ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua properti mewakili konten XML dari bagian XML khusus yang sama.