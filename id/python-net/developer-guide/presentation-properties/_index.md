---
title: Kelola Properti Presentasi dengan Python
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/python-net/presentation-properties/
keywords:
  - properti PowerPoint
  - properti presentasi
  - properti dokumen
  - properti bawaan
  - properti khusus
  - properti lanjutan
  - mengelola properti
  - memodifikasi properti
  - metadata dokumen
  - mengedit metadata
  - bahasa pemeriksaan
  - bahasa default
  - PowerPoint
  - OpenDocument
  - presentasi
  - Python
  - Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk Python via .NET dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint Anda."
---
## **Pengantar**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/). Sebuah instance dari kelas ini dikembalikan oleh properti [Presentation.document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/document_properties/). Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="primary" %}} 
Harap dicatat bahwa Anda tidak dapat mengatur nilai pada bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for Python via .NET x.x.x akan ditampilkan pada bidang tersebut.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Ditentukan Sistem (Built-in)
- Properti yang Ditentukan Pengguna (Custom)

Properti **Built-in** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Custom** adalah yang didefinisikan pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Dengan menggunakan Aspose.Slides for Python via .NET, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun properti custom. Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office dan kemudian menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Di **Properties Dialog**, Anda dapat melihat banyak halaman tab seperti **General, Summary, Statistics, Contents and Custom**. Semua halaman tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Akses Properti Built-in**

Properti ini yang diekspor oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **SharedDoc** (Apakah dibagikan antar produsen?), **PresentationFormat**, **Subject**, dan **Title**
```py
import aspose.slides as slides

# Instansiasi kelas Presentation yang mewakili presentasi
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Buat referensi ke objek yang terkait dengan Presentation
    documentProperties = pres.document_properties

    # Tampilkan properti bawaan
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

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti akan diubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in file presentasi.
```py
import aspose.slides as slides

# Instansiasi kelas Presentation yang mewakili Presentasi
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Buat referensi ke objek yang terkait dengan Presentation
    documentProperties = presentation.document_properties

    # Set properti bawaan
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # simpan presentasi Anda ke file
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Properti Presentasi Custom**

Aspose.Slides for Python via .NET juga memungkinkan pengembang menambahkan nilai custom untuk properti Dokumen presentasi. Contoh diberikan di bawah yang menunjukkan cara mengatur properti custom untuk sebuah presentasi.
```py
import aspose.slides as slides

# Instansiasi kelas Presentation
with slides.Presentation() as presentation:
    # Mendapatkan Properti Dokumen
    documentProperties = presentation.document_properties

    # Menambahkan properti Kustom
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

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides for Python via .NET juga memungkinkan pengembang mengakses nilai properti custom. Contoh diberikan di bawah yang menunjukkan cara Anda dapat mengakses dan memodifikasi semua properti custom tersebut untuk sebuah presentasi.
```py
import aspose.slides as slides

# Instansiasi kelas Presentation yang mewakili PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Buat referensi ke objek document_properties yang terkait dengan presentasi
    documentProperties = presentation.document_properties

    # Akses dan modifikasi properti kustom
    for i in range(documentProperties.count_of_custom_properties):
        # Tampilkan nama dan nilai properti kustom
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modifikasi nilai properti kustom
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # simpan presentasi Anda ke file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan properti `Language_Id` (dipublikasikan oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/)) untuk memungkinkan Anda mengatur bahasa proofing untuk dokumen PowerPoint. Bahasa proofing adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa dalam PowerPoint.

Kode Python berikut menunjukkan cara mengatur bahasa proofing untuk PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
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

## **Atur Bahasa Default**

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

## **FAQ**

**Bagaimana saya dapat menghapus properti built-in dari presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut memperbolehkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya, Anda dapat mengakses properti presentasi tanpa memuat seluruh presentasi dengan menggunakan metode [get_presentation_info](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/get_presentation_info/) dari kelas [PresentationFactory](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/). Selanjutnya, gunakan metode [read_document_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/read_document_properties/) yang disediakan oleh kelas [PresentationInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationinfo/) untuk membaca properti secara efisien, menghemat memori, dan meningkatkan kinerja.