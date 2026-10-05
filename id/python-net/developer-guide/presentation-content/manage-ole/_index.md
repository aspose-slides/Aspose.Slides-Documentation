---  
title: Kelola OLE dalam Presentasi Menggunakan Python  
linktitle: Kelola OLE  
type: docs  
weight: 40  
url: /id/python-net/manage-ole/  
keywords:  
- objek OLE  
- Object Linking & Embedding  
- tambahkan OLE  
- sematkan OLE  
- tambahkan objek  
- sematkan objek  
- tambahkan file  
- sematkan file  
- objek tertaut  
- file tertaut  
- ubah OLE  
- ikon OLE  
- judul OLE  
- ekstrak OLE  
- ekstrak objek  
- ekstrak file  
- PowerPoint  
- presentasi  
- Python  
- Aspose.Slides  
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."  
---
## **Pendahuluan**

{{% alert color="info" title="Note" %}}
**OLE (Object Linking & Embedding)** adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditautkan atau disematkan di aplikasi lain.
{{% /alert %}}

Sebagai contoh, diagram yang dibuat di Microsoft Excel dan ditempatkan pada slide PowerPoint merupakan objek OLE.

- Sebuah objek OLE dapat muncul sebagai ikon. Mengklik ganda ikon tersebut membuka objek di aplikasi terkait (misalnya, Excel) atau meminta Anda memilih aplikasi untuk membuka atau mengeditnya.
- Sebuah objek OLE dapat menampilkan isinya (misalnya, diagram). Dalam hal ini, PowerPoint mengaktifkan objek yang disematkan, memuat antarmuka diagram, dan memungkinkan Anda mengedit data diagram di dalam PowerPoint.

Aspose.Slides for Python memungkinkan Anda menyisipkan objek OLE ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Menambahkan OLE Objects ke Slide**

Jika Anda sudah membuat diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Python, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Baca file Excel ke dalam array byte.
1. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ke slide, memberikan array byte dan detail objek OLE lainnya.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, diagram dari file Excel disematkan ke dalam slide sebagai [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Catatan:** Konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) menerima ekstensi file objek yang dapat disematkan sebagai parameter kedua. PowerPoint menggunakan ekstensi ini untuk mengidentifikasi tipe file dan memilih aplikasi yang sesuai untuk membuka objek OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Siapkan data untuk objek OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Tambahkan bingkai objek OLE ke slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Menambahkan OLE Objects Tertaut**

Aspose.Slides for Python memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) yang menautkan ke sebuah file alih‑alih menyematkan datanya.

Contoh Python berikut menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) yang tertaut ke file Excel pada slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan bingkai objek OLE dengan file Excel tertaut.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses OLE Objects**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat mengaksesnya sebagai berikut:

1. Muat presentasi yang berisi objek OLE yang disematkan dengan membuat instance dari kelas Presentation.
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Akses shape OleObjectFrame.
1. Setelah Anda memiliki bingkai objek OLE, lakukan operasi yang diperlukan padanya.

Contoh di bawah mengakses bingkai OLE object—sebuah diagram Excel yang disematkan—dan mengambil data berkasnya. Pada contoh ini, kami menggunakan PPTX yang memiliki satu shape pada slide pertama.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Dapatkan data file yang disematkan.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Dapatkan ekstensi file yang disematkan.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Mengakses Properti OLE Object Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai OLE object yang tertaut.

Contoh Python di bawah memeriksa apakah sebuah OLE object tertaut dan, bila ya, mengambil jalur ke file yang tertaut:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Periksa apakah objek OLE tertaut.
        if ole_frame.is_object_link:
            # Cetak jalur lengkap ke file yang tertaut.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Cetak jalur relatif ke file yang tertaut, jika ada.
            # Hanya presentasi .ppt yang dapat berisi jalur relatif.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Mengubah Data OLE Object**

{{% alert color="info" title="Note" %}}
Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).
{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat mengaksesnya dan mengubah datanya sebagai berikut:

1. Muat presentasi dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Dapatkan slide target berdasarkan indeksnya.
1. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Setelah Anda memiliki bingkai objek OLE, lakukan operasi yang diperlukan padanya.
1. Buat objek `Workbook` dan baca data OLE.
1. Buka `Worksheet` yang diinginkan dan edit data.
1. Simpan `Workbook` yang telah diperbarui ke sebuah aliran (stream).
1. Ganti data objek OLE menggunakan aliran tersebut.

Pada contoh di bawah, sebuah bingkai OLE object (sebuah diagram Excel yang disematkan) diakses dan data berkasnya diubah untuk memperbarui diagram. Contoh ini menggunakan PPTX yang sebelumnya dibuat dan berisi satu shape pada slide pertama.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Baca data objek OLE sebagai objek Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Ubah data workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Ubah data objek bingkai OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyematkan File dalam Slide**

Selain diagram Excel, Aspose.Slides for Python memungkinkan Anda menyematkan tipe file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut terbuka secara otomatis di aplikasi terkait, atau pengguna diminta memilih program yang sesuai.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti OLE object lama dengan yang baru atau menukar OLE object yang tidak didukung dengan yang didukung. Aspose.Slides for Python memungkinkan Anda mengatur jenis file dari objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi file-nya.

Contoh Python berikut menunjukkan cara mengatur jenis file OLE object yang disematkan menjadi `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Ubah tipe file menjadi ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah Anda menyematkan sebuah OLE object, sebuah pratinjau berbasis ikon ditambahkan secara otomatis. Pratinjau inilah yang dilihat pengguna sebelum mereka mengakses atau membuka OLE object. Jika Anda ingin menggunakan gambar dan teks tertentu dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for Python.

Contoh Python berikut menunjukkan cara mengatur gambar ikon dan judul untuk sebuah objek yang disematkan:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Tambahkan gambar ke sumber daya presentasi.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Tetapkan judul dan gambar untuk pratinjau OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mencegah Bingkai OLE Object Diubah Ukuran dan Posisi**

Setelah Anda menambahkan OLE object yang tertaut ke slide, PowerPoint dapat meminta Anda memperbarui tautan saat membuka presentasi. Memilih *Update Links* dapat mengubah ukuran dan posisi bingkai OLE object karena PowerPoint menyegarkan pratinjau dengan data dari objek yang tertaut. Untuk mencegah PowerPoint meminta Anda memperbarui data objek, atur properti `update_automatic` dari kelas [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) menjadi `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for Python memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai OLE objects sebagai berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) yang berisi OLE objects yang ingin Anda ekstrak.
1. Iterasi semua shape dalam presentasi dan temukan shape OLEObjectFrame.
1. Ambil data file yang disematkan dari setiap [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) dan tulis ke disk.

Contoh Python berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai OLE objects:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE “live” tidak dijalankan selama proses render. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

Untuk juga mempertahankan file yang disematkan sebagai lampiran PDF, atur [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) ke `True`. Opsi ini dinonaktifkan secara default. Untuk contoh dan instruksi memeriksa lampiran, lihat [Pertahankan File OLE yang Disematkan sebagai Lampiran PDF](/slides/id/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bagaimana cara mengunci OLE object pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan [kunci pada level shape](/slides/id/python-net/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan yang tidak disengaja.

**Mengapa objek Excel yang tertaut “melompat” atau berubah ukuran saat saya membuka presentasi?**

PowerPoint dapat menyegarkan pratinjau OLE yang tertaut. Untuk tampilan yang stabil, ikuti praktik [Solusi Praktis untuk Mengubah Ukuran Worksheet](/slides/id/python-net/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskala rentang ke bingkai tetap dan mengatur gambar pengganti yang sesuai.

**Apakah jalur relatif untuk OLE object yang tertaut akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi “jalur relatif” tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, pilih jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.