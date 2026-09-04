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
- Properti khusus
- Properti lanjutan
- Kelola properti
- Modifikasi properti
- Metadata dokumen
- Sunting metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk Python via .NET dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint Anda."
---
## **Introduction**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/). Sebuah instance kelas ini dikembalikan oleh properti [Presentation.document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/document_properties/). Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Harap dicatat bahwa Anda tidak dapat mengatur nilai pada bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for Python via .NET x.x.x akan ditampilkan pada bidang tersebut.
{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut:

- Properti yang Didefinisikan Sistem (Built-in)
- Properti yang Didefinisikan Pengguna (Custom)

Properti **Built-in** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Custom** adalah pasangan **Nama/Nilai** yang didefinisikan oleh pengguna, di mana baik nama maupun nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for Python via .NET, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun custom. Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Anda hanya perlu mengklik ikon Office lalu menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Pada **Properties Dialog**, Anda dapat melihat banyak tab seperti **General, Summary, Statistics, Contents, and Custom**. Semua tab ini memungkinkan konfigurasi berbagai informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Read Public Properties from an Encrypted Presentation**

Sebuah kata sandi pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi dengan [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) yang disetel ke `False`, properti dokumennya tetap bersifat publik. Aplikasi kemudian dapat mengatur [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/only_load_document_properties/) ke `True` dan membaca metadata publik tanpa harus menyediakan kata sandi pembuka.

`only_load_document_properties` mengontrol apa yang dimuat Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa kata sandi akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/id/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) dan kemudian membaca properti built-in melalui [Presentation.document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa `is_only_document_properties_loaded` sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Security" %}}
Metadata publik dapat mengekspos nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai custom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan tetap publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa kata sandi.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat dengan `only_load_document_properties` dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan perubahan properti dari objek yang hanya berisi metadata karena properti publik harus tetap konsisten dengan data yang bersesuaian di dalam presentasi yang terenkripsi. Oleh karena itu, memperbaruinya memerlukan kata sandi pembuka yang benar dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions.password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/is_encrypted/) untuk memverifikasi bahwa enkripsi tetap dipertahankan dan membuka kembali metadata publik tanpa kata sandi untuk memverifikasi nilai baru:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Jika sebuah aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik file PPTX yang terenkripsi sebagai read-only.

## **Access Built-in Properties**
Properti yang diekspos oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antara produsen berbeda?), **PresentationFormat**, **Subject**, dan **Title**
```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili presentasi
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

## **Modify Built-in Properties**

Memodifikasi properti built-in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti akan berubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in file presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Membuat referensi ke objek yang terkait dengan Presentation
    documentProperties = presentation.document_properties

    # Atur properti bawaan
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Simpan presentasi Anda ke file
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Custom Presentation Properties**

Aspose.Slides for Python via .NET juga memungkinkan pengembang menambahkan nilai custom untuk properti dokumen presentasi. Contoh berikut memperlihatkan cara mengatur properti custom untuk sebuah presentasi.

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

## **Access and Modify Custom Properties**

Aspose.Slides for Python via .NET juga memungkinkan pengembang mengakses nilai properti custom. Contoh berikut memperlihatkan cara Anda dapat mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili PPTX
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
    # Simpan presentasi Anda ke file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` mengembalikan nilai melalui daftar satu elemen yang diberikan sebagai argumen kedua, dan nilai yang disimpan dikast ke tipe elemen yang sudah ada dalam daftar tersebut. Contoh di atas menggunakan `[""]`, sehingga membaca properti string; untuk membaca properti yang disimpan sebagai angka, berikan placeholder numerik seperti `[0]`—jika tidak, pemanggilan akan menghasilkan `InvalidCastException`.

## **Set Proofing Language**

Aspose.Slides menyediakan properti `Language_Id` (diekspos oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/)) untuk memungkinkan Anda mengatur bahasa proofing bagi dokumen PowerPoint. Bahasa proofing adalah bahasa di mana ejaan dan tata bahasa pada PowerPoint diperiksa.

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

    # atur Id bahasa proofing
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Set Default Language**

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

## **Live Example**

Coba aplikasi online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus seluruhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya bila properti tersebut memperbolehkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) lalu [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/python-net/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.

**Bisakah saya membaca properti publik dari presentasi yang dienkripsi tanpa kata sandi pembukanya?**

Ya. Presentasi harus dienkripsi dengan `encrypt_document_properties` disetel ke `False`, dan harus dimuat dengan `only_load_document_properties` disetel ke `True`.

**Bisakah saya memperbarui file PPTX terenkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX terenkripsi memerlukan pemuatan lengkap presentasi dengan kata sandi pembuka yang benar.