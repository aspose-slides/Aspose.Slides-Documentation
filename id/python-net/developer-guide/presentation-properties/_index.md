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
description: "Kuasi properti presentasi dalam Aspose.Slides untuk Python via .NET dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint Anda."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET mendukung properti dokumen **bawaan** dan **kustom**. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Sebuah instance kelas ini dikembalikan oleh [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" title="Note" %}}
Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang‑bidang ini mengidentifikasi perangkat lunak yang membuat output.
{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersama konten presentasi. Mereka terbagi menjadi dua kategori:

- **Properti bawaan** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Properti kustom** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides for Python via .NET menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Ringkasan**, **Statistik**, **Konten**, dan **Kustom**. Gunakan tab **Kustom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi yang Di‑enkripsi**

Password pembuka biasanya melindungi konten presentasi dan properti dokumen. Ketika sebuah presentasi dienkripsi dengan [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) diatur ke `False`, properti dokumennya tetap publik. Sebuah aplikasi kemudian dapat mengatur [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ke `True` dan membaca metadata publik tanpa memberikan password pembuka.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) mengontrol apa yang dimuat Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh memerlukan sebuah presentasi yang dienkripsi dengan properti dokumen dibiarkan publik. Ia memverifikasi mode pemuatan melalui [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) dan kemudian membaca properti bawaan melalui [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi sebaiknya selalu memeriksa [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Security" %}}
Metadata publik dapat mengekspos nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama presentasi. Biarkan publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Di‑enkripsi**

Untuk file PPTX yang dienkripsi, sebuah presentasi yang dimuat dengan [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ditujukan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang berubah dari objek hanya‑metadata tersebut karena properti publik harus tetap konsisten dengan data yang bersesuaian di dalam presentasi yang dienkripsi. Oleh karena itu memperbarui mereka memerlukan password pembuka yang benar serta pemuatan lengkap.

Contoh memerlukan sebuah presentasi PPTX yang dienkripsi dengan properti dokumen publik dan password pembuka yang diketahui. Ia membuka presentasi lengkap dengan [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), memperbarui properti bawaan publik, dan menyimpan hasilnya. Kemudian ia menggunakan [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Jika sebuah aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai read‑only.

## **Akses Properti Bawaan**

Kelas [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) menampilkan metadata bawaan melalui properti ber‑tipe, termasuk [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), dan [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpan ke konsol. Nilai bergantung pada presentasi input; beberapa bidang mungkin kosong.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **Laporan Nomor Revisi dan Waktu Pengeditan**

Untuk melaporkan nomor revisi dan total waktu pengeditan untuk setiap file PPTX dalam folder `presentations`, gunakan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) untuk mengambil [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)‑nya tanpa memuat slide untuk pengeditan. Python menampilkan durasi sebagai `timedelta`, termasuk jumlah hari ketika waktu tercatat mencapai 24 jam.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Untuk sebuah presentasi dengan 1 hari, 2 jam, dan 5 menit waktu pengeditan tercatat, laporan berisi baris berikut.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) adalah metadata yang dapat ditulis. Nilainya sendiri tidak dapat menunjukkan berapa kali presentasi disimpan atau merekonstruksi riwayat versinya.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) melaporkan durasi pengeditan yang disimpan dalam file. Nilai `0:00:00` berarti durasi tercatat nol, meskipun seseorang mengedit presentasi.

## **Modifikasi Properti Bawaan**

Untuk memperbarui metadata bawaan, berikan nilai kepada properti yang dapat ditulis yang ditampilkan oleh [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Contoh ini membuka presentasi yang ada, mengatur [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), dan [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), lalu menyimpan presentasi yang diperbarui dengan [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). PPTX yang disimpan berisi metadata baru.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelola Basis Hyperlink**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) menyimpan basis tingkat dokumen untuk hyperlink relatif. Ini berguna saat memindahkan presentasi dan file‑file terkait ke lokasi lain. Ini terpisah dari [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) pada hyperlink individu: mengubah basis tidak menulis ulang alamat link yang disimpan atau mengubah tujuan absolut.

Contoh memerlukan sebuah presentasi yang berisi baik tautan relatif, seperti `target.html`, maupun tautan absolut ke file atau situs web. Ia membaca basis yang ada, menetapkan alamat basis baru, lalu menyimpan dan membuka kembali presentasi untuk memeriksa nilai tersebut. Kemudian ia mengosongkan basis dengan `""` dan memverifikasi nilai kosong dalam file yang disimpan terpisah. Ganti alamat basis contoh dengan lokasi file‑file terkait Anda.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Dua pesan verifikasi harus mencetak `True`. Mengosongkan basis tidak mengubah alamat hyperlink individu.

Tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika basis mengarah ke folder `old`. Setelah mengubah basis ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut tetap membuka file yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan sesudah memindahkan presentasi atau mengubah basismu.

## **Tambahkan Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang bawaan yang bersesuaian. Metode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat sebuah presentasi, menambahkan dua nilai teks dan sebuah nilai versi integer, lalu menyimpan presentasi dengan [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Menetapkan nilai ke nama yang sudah ada menggantikan nilai properti tersebut.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses dan Modifikasi Properti Kustom**

Contoh ini membuka sebuah presentasi yang berisi properti kustom dan menggunakan [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) untuk mengiterasi mereka. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) menerima indeks berbasis nol dan mengembalikan nama yang digunakan oleh [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Contoh memerlukan sebuah presentasi yang semua properti kustomnya berupa string. Ia mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string bernomor, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak melakukan perubahan.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) mengembalikan nilai melalui daftar satu‑elemen yang diberikan sebagai argumen kedua. Placeholder harus cocok dengan tipe properti yang disimpan: gunakan `[""]` untuk string atau `[0]` untuk integer. Tipe yang tidak cocok akan menimbulkan `InvalidCastException`; pilih placeholder sesuai skema properti‑kustom Anda.

## **Contoh Langsung**

Coba aplikasi online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana saya dapat menghapus properti bawaan dari sebuah presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut memperbolehkan.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Dapatkah saya mengakses properti presentasi tanpa memuat penuh presentasi?**

Ya. Gunakan [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) dan kemudian [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Lihat [Bangun Inventaris Presentasi Ringan](/slides/id/python-net/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.

**Dapatkah saya membaca properti publik dari presentasi yang dienkripsi tanpa password pembuka?**

Ya. Presentasi harus telah dienkripsi dengan [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) yang diatur ke `False`, dan harus dimuat dengan [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) yang diatur ke `True`.

**Dapatkah saya memperbarui file PPTX yang dienkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan yang dienkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.