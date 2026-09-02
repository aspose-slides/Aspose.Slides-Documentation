---
title: Kelola Properti Presentasi dengan Python
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/python-net/presentation-properties/
keywords:
- Properti PowerPoint
- Properti presentasi
- Properti dokumen
- Properti bawaan
- Properti kustom
- Properti lanjutan
- Mengelola properti
- Memodifikasi properti
- Metadata dokumen
- Mengedit metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk Python via .NET dan sederhanakan pencarian, branding, serta alur kerja dalam file PowerPoint Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/) . Sebuah instance kelas ini dikembalikan oleh properti [Presentation.document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/document_properties/) . Contoh berikut menunjukkan cara membaca, mengubah, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Harap dicatat bahwa Anda tidak dapat menetapkan nilai pada bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for Python via .NET x.x.x akan ditampilkan pada bidang tersebut.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Ditetapkan Sistem (Built-in)
- Properti yang Didefinisikan Pengguna (Custom)

**Built-in** properti berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. **Custom** properti adalah properti yang didefinisikan oleh pengguna sebagai pasangan **Nama/Nilai**, dimana baik nama maupun nilai ditentukan oleh pengguna. Dengan menggunakan Aspose.Slides for Python via .NET, pengembang dapat mengakses dan mengubah nilai properti built-in maupun custom. Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Semua yang perlu Anda lakukan adalah mengklik ikon Office dan selanjutnya menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Di **Properties Dialog**, Anda dapat melihat bahwa terdapat banyak tab seperti **General, Summary, Statistics, Contents and Custom**. Semua tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Akses Properti Built-in**
Properti‑properti yang diekspos oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antar produsen?), **PresentationFormat**, **Subject**, dan **Title**
```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang merepresentasikan presentasi
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Membuat referensi ke objek yang terkait dengan Presentation
    documentProperties = pres.document_properties

    # Menampilkan properti bawaan
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Ubah Properti Built-in**

Memodifikasi properti built-in dari file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan diubah. Pada contoh di bawah ini, kami menunjukkan cara mengubah properti dokumen built-in dari file presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang merepresentasikan Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Membuat referensi ke objek yang terkait dengan Presentation
    documentProperties = presentation.document_properties

    # Menyetel properti bawaan
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # simpan presentasi Anda ke file
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Properti Presentasi Custom**

Aspose.Slides for Python via .NET juga memungkinkan pengembang menambahkan nilai custom untuk properti Dokumen presentasi. Contoh diberikan di bawah yang menunjukkan cara menyetel properti custom untuk sebuah presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation
with slides.Presentation() as presentation:
    # Mendapatkan Properti Dokumen
    documentProperties = presentation.document_properties

    # Menambahkan properti Custom
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Mendapatkan nama properti pada indeks tertentu
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Menghapus properti yang dipilih
    documentProperties.remove_custom_property(getPropertyName)

    # Menyimpan presentasi
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses dan Ubah Properti Custom**

Aspose.Slides for Python via .NET juga memungkinkan pengembang mengakses nilai properti custom. Contoh diberikan di bawah yang menunjukkan cara Anda dapat mengakses dan mengubah semua properti custom untuk sebuah presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang merepresentasikan PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Membuat referensi ke objek document_properties yang terkait dengan Presentation
    documentProperties = presentation.document_properties

    # Mengakses dan memodifikasi properti custom
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Menampilkan nama dan nilai properti custom
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Memodifikasi nilai properti custom
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # menyimpan presentasi Anda ke file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` mengembalikan nilai melalui list satu elemen yang diberikan sebagai argumen kedua, dan nilai yang disimpan di‑cast ke tipe elemen yang sudah ada di list tersebut. Contoh di atas menggunakan `[""]`, sehingga membaca properti string; untuk membaca properti yang disimpan sebagai angka, berikan placeholder numerik seperti `[0]`—jika tidak, pemanggilan akan menghasilkan `InvalidCastException`.

## **Setel Bahasa Proofing**

Aspose.Slides menyediakan properti `Language_Id` (dipaparkan oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/)) untuk memungkinkan Anda mengatur bahasa proofing pada dokumen PowerPoint. Bahasa proofing adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa di PowerPoint.

Kode Python berikut menunjukkan cara mengatur bahasa proofing untuk PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # set Id bahasa proofing
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Setel Bahasa Default**

Kode Python berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Contoh Langsung**

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **Tanya Jawab**

**Bagaimana cara menghapus properti built-in dari presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut mengizinkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) dan kemudian [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) untuk membaca metadata dokumen yang tersimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/python-net/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.