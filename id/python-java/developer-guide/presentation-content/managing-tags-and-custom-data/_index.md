---
title: Kelola Tag dan Data Khusus dalam Presentasi Menggunakan Python
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/python-java/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Pelajari cara mengelola tag dan data XML khusus dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java, termasuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara kerja Aspose.Slides dengan tag dan data khusus dalam presentasi PowerPoint. Data spesifik presentasi dapat disimpan sebagai tag atau bagian XML khusus. Tag adalah pasangan string kunci‑nilai sederhana, sedangkan bagian XML khusus dapat menyimpan metadata terstruktur dan muatan XML yang spesifik aplikasi.

Aspose.Slides menyediakan API untuk menambahkan, membaca, memperbarui, mengaudit, dan menghapus bagian XML khusus pada tingkat presentasi, slide, dan shape. Bagian XML khusus berguna untuk integrasi yang menyimpan informasi seperti pengidentifikasi manajemen dokumen, status alur kerja, metadata kepatuhan, data pengikatan templat, atau data aplikasi terstruktur lainnya di dalam presentasi.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—file dengan ekstensi `.pptx`—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Office Open XML mendefinisikan struktur paket dan hubungan yang digunakan untuk menyimpan konten presentasi serta data terkait.

Sebuah presentasi berisi beberapa bagian yang terhubung oleh hubungan. Misalnya, bagian slide berisi konten satu slide dan dapat memiliki hubungan eksplisit ke bagian lain yang didefinisikan oleh ISO/IEC 29500.

Data khusus dapat disimpan sebagai tag ([TagCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/)) atau bagian XML khusus ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/)). Kedua‑nya tersedia melalui kelas [CustomData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Tag menyimpan pasangan kunci‑nilai string sederhana. Bagian XML khusus menyimpan data XML terstruktur dan dapat dikaitkan dengan presentasi, slide, atau shape.
{{% /alert %}}

## **Bekerja dengan Bagian XML Khusus**

Metode [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) mengembalikan koleksi bagian XML khusus yang terkait dengan objek presentasi tertentu. Misalnya:

- Koleksi [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) pada presentasi berisi bagian XML khusus yang terkait dengan presentasi itu sendiri.
- Koleksi [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) pada slide berisi bagian XML khusus yang terkait dengan slide tertentu.
- Koleksi [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) pada shape berisi bagian XML khusus yang terkait dengan shape tertentu.

Gunakan [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAllCustomXmlParts) ketika Anda perlu memeriksa semua bagian XML khusus dalam presentasi terlepas dari tempat mereka terkait.

### **Menambahkan Bagian XML Khusus ke Presentasi**

Gunakan [CustomXmlPartCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#add) untuk menambahkan data XML ke koleksi bagian XML khusus. XML harus valid dan tidak kosong.

Contoh berikut menambahkan metadata terstruktur ke koleksi data khusus tingkat presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add secara otomatis menetapkan pengidentifikasi. Tetapkan UUID tertentu hanya bila diperlukan.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metode [add](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#add) juga dapat menerima XML dalam bentuk array byte atau aliran masukan, yang berguna ketika konten XML sudah tersedia dalam bentuk biner.

### **Menambahkan Bagian XML Khusus ke Slide atau Shape**

Data XML khusus dapat dikaitkan dengan slide atau shape tertentu, bukan seluruh presentasi. Ini berguna ketika metadata hanya menggambarkan satu objek, seperti kunci templat, pengidentifikasi catatan eksternal, atau informasi pengikatan.

Contoh berikut menambahkan satu bagian XML khusus ke slide dan satu lagi ke shape:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tingkat di mana bagian ditambahkan menentukan koleksi [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) objek mana yang berisi hubungan ke bagian tersebut. Data tingkat presentasi cocok untuk metadata seluruh dokumen, data tingkat slide untuk informasi yang melekat pada slide tertentu, dan data tingkat shape untuk metadata yang terikat pada shape individu.

### **Mendaftar dan Mengaudit Semua Bagian XML Khusus**

Gunakan [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAllCustomXmlParts) untuk mengambil semua bagian XML khusus dari sebuah presentasi. Setiap [CustomXmlPart](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/) menampilkan pengidentifikasi, konten XML, dan skema namespace yang terkait.

Contoh berikut menampilkan semua bagian XML khusus beserta skema namespace‑nya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) mengembalikan skema XML yang terkait dengan bagian XML khusus. Informasi ini dapat berguna saat mengaudit presentasi yang berisi XML yang dihasilkan oleh sistem eksternal.

### **Membaca dan Memperbarui Konten XML serta ItemId**

Gunakan [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlAsString) dan [setXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlAsString) untuk bekerja dengan XML sebagai string UTF‑8, atau [getXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlData) dan [setXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlData) untuk bekerja dengan byte XML mentah.

Metode [CustomXmlPart.getItemId](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getItemId) mengembalikan UUID yang mengidentifikasi bagian XML khusus dalam dokumen Office Open XML. Gunakan [setItemId](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setItemId) ketika sebuah integrasi memerlukan pengidentifikasi baru.

Contoh berikut memperbarui konten XML dan pengidentifikasinya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

            # Baca XML saat ini sebagai teks.
            current_xml_content = custom_xml_part.getXmlAsString()
            print(current_xml_content)

            # Perbarui XML sebagai string UTF-8.
            custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
            custom_xml_part.setXmlAsString(custom_xml_content)

            # getXmlData menyediakan konten XML yang sama sebagai byte mentah.
            custom_xml_data = custom_xml_part.getXmlData()
            print(bytes(custom_xml_data).decode("utf-8"))

            # Ganti pengidentifikasi ketika diperlukan oleh integrasi.
            item_id = UUID.randomUUID()
            custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Saat memanggil [setXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlAsString) atau [setXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlData), berikan XML yang valid dan tidak kosong. Gunakan satu representasi atau yang lain tergantung apakah aplikasi Anda bekerja terutama dengan string atau data byte.

### **Menghapus Bagian XML Khusus**

Aspose.Slides menyediakan beberapa cara untuk menghapus data XML khusus:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#remove) menghapus bagian XML khusus dari presentasi.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#remove) menghapus bagian tertentu dari koleksi bagian XML khusus.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#removeAt) menghapus bagian pada indeks koleksi yang ditentukan.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#clear) menghapus semua bagian dari koleksi tertentu.

Contoh berikut menghapus satu bagian XML khusus tingkat presentasi berdasarkan referensi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jika Anda sudah memiliki [CustomXmlPart](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/) dan ingin menghapus bagian tersebut dari presentasi alih‑alih menargetkan koleksi tertentu, panggil [CustomXmlPart.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#remove).

Anda juga dapat menghapus item berdasarkan indeks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Mengosongkan Semua Bagian XML Khusus dari Sebuah Koleksi**

Gunakan [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#clear) ketika semua bagian XML khusus yang terkait dengan objek presentasi tertentu harus dihapus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#clear) memengaruhi hanya koleksi yang dipilih. Misalnya, mengosongkan koleksi slide tidak mengosongkan koleksi tingkat presentasi atau shape.

Untuk menghapus setiap bagian XML khusus dalam presentasi, iterasikan melalui [getAllCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAllCustomXmlParts) dan hapus masing‑masing bagian:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menangani Bagian XML Khusus yang Ditautkan atau Dibagikan**

Dalam sebuah presentasi Office Open XML, bagian XML khusus yang sama dapat dirujuk dari lebih dari satu objek presentasi. Misalnya, sebuah file yang ada dapat berisi hubungan dari beberapa slide atau shape ke bagian XML khusus yang sama.

Bagian yang dibagikan harus diperlakukan sebagai satu objek data dengan banyak referensi:

- Memperbaruinya dengan [setXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlData), atau [setItemId](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setItemId) mengubah bagian XML khusus yang mendasarinya, sehingga perubahan berlaku di mana pun bagian tersebut dirujuk.
- [getItemId](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getItemId) dapat digunakan untuk mengidentifikasi bagian XML khusus yang sama saat mengaudit koleksi tingkat objek.
- Menghapus bagian dari koleksi [getCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getCustomXmlParts) tertentu menghapusnya dari koleksi itu. Gunakan [CustomXmlPart.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#remove) ketika bagian itu sendiri harus dihapus dari presentasi.
- Sebelum menghapus atau mengganti bagian yang dibagikan, periksa koleksi tingkat objek untuk menentukan apakah slide atau shape lain masih merujuknya.

Overload [add](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpartcollection/#add) membuat bagian XML khusus baru dari konten XML; mereka tidak menerima [CustomXmlPart](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/) yang sudah ada. Oleh karena itu, hubungan yang dibagikan paling sering ditemui saat memuat presentasi yang sudah berisi hubungan tersebut.

Contoh berikut mengaudit koleksi tingkat presentasi, slide, dan shape berdasarkan `ItemId` serta melaporkan bagian yang dirujuk dari lebih dari satu tempat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Audit jenis ini berguna sebelum memodifikasi atau menghapus data XML khusus dalam presentasi yang dibuat oleh sistem eksternal, karena bagian metadata yang sama dapat berpartisipasi dalam lebih dari satu hubungan.

## **Mendapatkan Nilai Tag**

Di Slides, sebuah tag sesuai dengan metode [DocumentProperties.getKeywords](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getKeywords). Contoh kode berikut menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides for Python via Java untuk [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus, misalnya `MyTag`;
- nilai properti khusus, misalnya `My Tag Value`.

Jika Anda perlu mengklasifikasikan presentasi berdasarkan aturan atau properti tertentu, Anda dapat menambahkan tag untuk tujuan tersebut. Misalnya, jika Anda ingin mengkategorikan presentasi dari negara‑negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan menetapkan negara yang relevan sebagai nilainya.

Contoh kode berikut menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) menggunakan Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Tag juga dapat diatur untuk sebuah [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Atau untuk sebuah [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) individual:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Batasan**

Tag yang ditambahkan melalui koleksi [CustomData.getTags](https://reference.aspose.com/slides/id/python-java/aspose.slides/customdata/#getTags) disimpan hanya dalam file PowerPoint. Tag tersebut **tidak** ditransfer ke struktur tag PDF saat presentasi diekspor ke PDF. Akibatnya, pengidentifikasi khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang sudah ditandai.

**Solusi**: Anda dapat menyimpan pengidentifikasi khusus dalam **Alt Text** objek (misalnya, [Shape.setAlternativeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setAlternativeText) dengan nilai `"MyId"`). Setelah diekspor ke PDF, Alt Text dapat muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari sebuah presentasi, slide, atau shape dalam satu operasi?**

Ya. Koleksi [tag](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/#clear) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa harus iterasi seluruh koleksi?**

Gunakan [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/#remove) pada koleksi [tag](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana cara memperoleh daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/#getNamesOfTags) pada koleksi [tag](https://reference.aspose.com/slides/id/python-java/aspose.slides/tagcollection/); metode ini mengembalikan array semua nama tag.

**Bagaimana cara menemukan semua bagian XML khusus terlepas dari tempat penyimpanannya?**

Gunakan [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAllCustomXmlParts) untuk mengambil semua bagian XML khusus dalam presentasi.

**Haruskah saya menggunakan [getXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlAsString) atau [getXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlData) untuk memperbarui bagian XML khusus?**

Gunakan [getXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlAsString) dan [setXmlAsString](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlAsString) ketika aplikasi bekerja dengan teks XML UTF‑8. Gunakan [getXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#getXmlData) dan [setXmlData](https://reference.aspose.com/slides/id/python-java/aspose.slides/customxmlpart/#setXmlData) ketika XML sudah tersedia sebagai array byte atau ketika pemrosesan berbasis biner lebih nyaman. Kedua representasi merujuk pada konten XML dari bagian XML khusus yang sama.