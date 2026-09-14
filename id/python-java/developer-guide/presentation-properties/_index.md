---
title: Kelola Properti Presentasi dengan Python
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/python-java/presentation-properties/
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
description: "Kuasai properti presentasi di Aspose.Slides untuk Python via Java dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/). Sebuah instance kelas ini dikembalikan oleh [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDocumentProperties). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" title="Note" %}}
Harap catat bahwa bidang **Application** dan **AppVersion** tidak dapat diubah. Aspose.Slides menulis ulang mereka pada setiap penyimpanan, sehingga presentasi yang disimpan selalu melaporkan "Aspose.Slides for Java" dan versi perpustakaan yang menghasilkannya. Setiap nilai yang diberikan ke [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#setNameOfApplication) akan diabaikan saat presentasi ditulis.
{{% /alert %}}

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan Anda mengelola properti dokumen file presentasi. Klik ikon Office dan pilih **Prepare | Properties | Advanced Properties**, seperti ditunjukkan di bawah:

|**Memilih item menu Advanced Properties**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

Setelah Anda memilih **Advanced Properties**, sebuah dialog muncul di mana Anda dapat mengelola properti dokumen file PowerPoint:

|**Dialog Properti**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

Dialog **Properties** berisi tab-tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Tab-tab ini memungkinkan Anda mengkonfigurasi berbagai jenis informasi tentang file PowerPoint. Gunakan tab **Custom** untuk mengelola properti khusus.

## **Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides untuk Python via Java**

Seperti dijelaskan sebelumnya, Aspose.Slides untuk Python via Java mendukung properti dokumen **Built-in** dan **Custom**. Kelas [DocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/) mewakili properti dokumen yang terkait dengan file presentasi.

Gunakan [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDocumentProperties) untuk mengakses properti ini seperti dijelaskan di bawah.

## **Baca Properti Publik dari Presentasi yang Terenkripsi**

Password pembuka biasanya melindungi konten presentasi dan properti dokumen. Ketika sebuah presentasi dienkripsi dengan mengirimkan `false` ke [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), properti dokumennya tetap publik. Aplikasi kemudian dapat mengirimkan `true` ke [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) dan membaca metadata publik tanpa memberikan password pembuka.

Opsi hanya properti-dokumen mengontrol apa yang dimuat oleh Aspose.Slides; opsi ini tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password akan gagal. Jika presentasi tidak dienkripsi, opsi diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode muat melalui [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) dan kemudian membaca properti built-in melalui [Presentation.getDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai khusus. Enkripsi properti sensitif bersama dengan presentasi. Biarkan publik hanya ketika proses pengindeksan, klasifikasi, pencarian, atau sistem manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti dari Presentasi yang Terenkripsi**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat dalam mode hanya properti-dokumen dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek hanya-metadata tersebut karena properti publik harus tetap konsisten dengan data yang sesuai di dalam presentasi yang dienkripsi. Oleh karena itu, memperbarui mereka memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#isEncrypted) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai hanya-baca.

## **Akses Properti Built-in**

Properti built-in yang disediakan oleh [DocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/) meliputi: **Creator** (Penulis), **Description**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antara produsen yang berbeda?), **PresentationFormat**, **Subject**, dan **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instansiasi kelas Presentation yang mewakili presentasi
presentation = Presentation("Presentation.pptx")
try:
    # Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    properties = presentation.getDocumentProperties()

    # Tampilkan properti bawaan
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in semudah mengaksesnya. Gunakan setter yang sesuai untuk menetapkan nilai baru. Contoh berikut memodifikasi properti dokumen built-in menggunakan Aspose.Slides untuk Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    properties = presentation.getDocumentProperties()

    # Atur properti bawaan
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Simpan presentasi Anda ke sebuah file
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Contoh ini memodifikasi properti built-in dari presentasi yang dapat dilihat seperti di bawah ini:

|**Properti dokumen built-in setelah modifikasi**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Tambah Properti Dokumen Kustom**

Aspose.Slides untuk Python via Java juga memungkinkan pengembang menambahkan properti dokumen kustom ke presentasi. Contoh di bawah menambahkan tiga properti kustom, kemudian mencari nama yang disimpan pada indeks 2 dan menghapus properti tersebut, sehingga presentasi yang disimpan menyimpan dua di antaranya. Properti kustom diindeks secara alfabetik, bukan dalam urutan penambahannya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Mendapatkan Properti Dokumen
    properties = presentation.getDocumentProperties()

    # Menambahkan properti Kustom
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Mendapatkan nama properti pada indeks tertentu
    property_name = properties.getCustomPropertyName(2)

    # Menghapus properti yang dipilih
    properties.removeCustomProperty(property_name)

    # Menyimpan presentasi
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Properti Dokumen Kustom Ditambahkan**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides untuk Python via Java juga memungkinkan pengembang mengakses nilai properti kustom. Contoh berikut menunjukkan cara mengakses dan memodifikasi semua properti kustom dalam sebuah presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    properties = presentation.getDocumentProperties()

    # Akses dan modifikasi properti kustom
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Tampilkan nama dan nilai properti kustom
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modifikasi nilai properti kustom
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Simpan presentasi Anda ke sebuah file
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Contoh ini memodifikasi properti kustom dari presentasi [PPTX](https://docs.fileformat.com/presentation/pptx/). Gambar berikut menunjukkan properti kustom presentasi sebelum dan setelah modifikasi:

|**Properti Kustom sebelum Modifikasi**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Properti Kustom setelah Modifikasi**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Properti Dokumen Lanjutan**

{{% alert color="info" title="Note" %}}
Metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), dan [writeBindedPresentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/), dan perilaku metode [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#setLastSavedTime) telah berubah.
{{% /alert %}}

Dua metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties) dan [updateDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/). Mereka menyediakan akses cepat ke properti dokumen dan memungkinkan Anda mengubah serta memperbarui properti tanpa memuat seluruh presentasi.

Alur kerja umum memuat properti, mengubah nilai mereka, dan memperbarui dokumen dapat diimplementasikan sebagai berikut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Baca informasi presentasi
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Dapatkan properti saat ini
properties = presentation_info.readDocumentProperties()

# Tetapkan nilai baru untuk bidang Author dan Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Perbarui presentasi dengan nilai baru
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Ada cara lain untuk menggunakan properti dari sebuah presentasi tertentu sebagai templat untuk memperbarui properti dalam presentasi lain:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Template baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui beberapa presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan metode [PortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#setLanguageId) untuk memungkinkan Anda mengatur bahasa pemeriksaan untuk dokumen PowerPoint. Bahasa pemeriksaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa dalam presentasi.

Kode Python berikut menunjukkan cara mengatur bahasa pemeriksaan untuk PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # tentukan Id bahasa pemeriksaan

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Atur Bahasa Default**

Kode Python berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Menambahkan bentuk persegi panjang dengan teks
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Memeriksa bahasa bagian pertama
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Contoh Langsung**

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diperbolehkan oleh properti tersebut.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Bisakah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationfactory/#getPresentationInfo) dan kemudian [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationinfo/#readDocumentProperties) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/python-java/examine-presentation/) untuk contoh pelaporan lengkap dan keterbatasan spesifik format.

**Bisakah saya membaca properti publik dari presentasi yang terenkripsi tanpa password pembukanya?**

Ya. Enkripsi properti dokumen harus telah dinonaktifkan sebelum presentasi dienkripsi, dan presentasi harus dimuat dalam mode hanya properti-dokumen.

**Bisakah saya memperbarui file PPTX yang terenkripsi dalam mode hanya properti-dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.