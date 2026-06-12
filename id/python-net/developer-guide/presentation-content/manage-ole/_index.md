---
title: Mengelola OLE dalam Presentasi Menggunakan Python
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/python-net/manage-ole/
keywords:
- objek OLE
- Pengaitan & Penyematan Objek
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

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditautkan atau disematkan ke dalam aplikasi lain.

{{% /alert %}}

Sebagai contoh, diagram yang dibuat di Microsoft Excel dan ditempatkan pada slide PowerPoint merupakan objek OLE.

- Sebuah objek OLE dapat muncul sebagai ikon. Mengklik ganda ikon tersebut membuka objek di aplikasi terkait (misalnya, Excel) atau meminta Anda memilih aplikasi untuk membuka atau mengeditnya.
- Sebuah objek OLE dapat menampilkan isinya (misalnya, diagram). Dalam hal ini, PowerPoint mengaktifkan objek yang disematkan, memuat antarmuka diagram, dan memungkinkan Anda mengedit data diagram langsung di PowerPoint.

Aspose.Slides for Python memungkinkan Anda menyisipkan objek OLE ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/)).

## **Menambahkan Obyek OLE ke Slide**

Jika Anda telah membuat diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for Python, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Baca file Excel ke dalam array byte.
1. Tambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) ke slide, dengan menyertakan array byte dan detail objek OLE lainnya.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

**Catatan:** Konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) menerima ekstensi file objek yang dapat disematkan sebagai parameter kedua. PowerPoint menggunakan ekstensi ini untuk mengidentifikasi jenis file dan memilih aplikasi yang sesuai untuk membuka objek OLE.

```py
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

### **Menambahkan Obyek OLE Tertaut**

Aspose.Slides for Python memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) yang menautkan ke file alih‑alih menyematkan datanya.

Contoh Python berikut menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) yang tertaut ke file Excel pada slide:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Obyek OLE**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat mengaksesnya sebagai berikut:

1. Muat presentasi yang berisi objek OLE yang disematkan dengan membuat sebuah instance dari kelas Presentation.
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Akses shape OleObjectFrame.
1. Setelah Anda memiliki bingkai objek OLE, lakukan operasi yang diperlukan padanya.

Contoh di bawah mengakses bingkai objek OLE—sebuah diagram Excel yang disematkan—dan mengambil data file-nya. Dalam contoh ini, kami menggunakan PPTX yang memiliki satu shape pada slide pertama.

```py
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

### **Mengakses Properti Obyek OLE Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang tertaut.

Contoh Python di bawah memeriksa apakah sebuah objek OLE tertaut dan, jika iya, mengambil jalur ke file yang ditautkan:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Periksa apakah objek OLE ditautkan.
        if ole_frame.is_object_link:
            # Cetak jalur lengkap ke file yang ditautkan.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Cetak jalur relatif ke file yang ditautkan, jika ada.
            # Hanya presentasi .ppt yang dapat berisi jalur relatif.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Mengubah Data Obyek OLE**

{{% alert color="primary" %}}

Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat mengaksesnya dan memodifikasi datanya sebagai berikut:

1. Muat presentasi dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide target berdasarkan indeksnya.
1. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/).
1. Setelah Anda memiliki bingkai objek OLE, lakukan operasi yang diperlukan padanya.
1. Buat objek `Workbook` dan baca data OLE.
1. Buka `Worksheet` yang diinginkan dan edit data.
1. Simpan `Workbook` yang telah diperbarui ke dalam stream.
1. Ganti data objek OLE menggunakan stream tersebut.

Pada contoh di bawah, sebuah bingkai objek OLE (sebuah diagram Excel yang disematkan) diakses dan data file-nya dimodifikasi untuk memperbarui diagram. Contoh ini menggunakan PPTX yang sebelumnya dibuat yang berisi satu shape pada slide pertama.

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
            # Modifikasi data workbook.
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

Selain diagram Excel, Aspose.Slides for Python memungkinkan Anda menyematkan tipe file lain dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Saat pengguna mengklik ganda objek yang disisipkan, secara otomatis terbuka di aplikasi terkait, atau pengguna diminta memilih program yang sesuai.

Kode Python berikut menunjukkan cara menyematkan file HTML dan ZIP dalam slide:

```py
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

## **Menetapkan Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau menukar objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for Python memungkinkan Anda menetapkan tipe file objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi file-nya.

Kode Python berikut menunjukkan cara menetapkan tipe file objek OLE yang disematkan menjadi `zip`:

```py
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

## **Menetapkan Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah Anda menyematkan sebuah objek OLE, pratinjau berbasis ikon secara otomatis ditambahkan. Pratinjau inilah yang dilihat pengguna sebelum mereka mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu dalam pratinjau, Anda dapat menetapkan gambar ikon dan judul menggunakan Aspose.Slides for Python.

Kode Python berikut menunjukkan cara menetapkan gambar ikon dan judul untuk sebuah objek yang disematkan:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Tambahkan gambar ke sumber daya presentasi.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Atur judul dan gambar untuk pratinjau OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mencegah Bingkai Obyek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang tertaut ke slide, PowerPoint dapat meminta Anda memperbarui tautan saat membuka presentasi. Memilih 'Update Links' dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint menyegarkan pratinjau dengan data dari objek yang tertaut. Untuk mencegah PowerPoint meminta Anda memperbarui data objek, set properti `update_automatic` dari kelas [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) menjadi `False`:

```py
ole_frame.update_automatic = False
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for Python memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE sebagai berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang berisi objek OLE yang ingin Anda ekstrak.
1. Iterasi semua shape dalam presentasi dan temukan shape OLEObjectFrame.
1. Ambil data file yang disematkan dari setiap [OLEObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) dan tulis ke disk.

Kode Python berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```py
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

Yang terlihat pada slide yang akan dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dijalankan selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan [kunci level shape](/slides/id/python-net/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan yang tidak disengaja.

**Mengapa objek Excel yang tertaut "melompat" atau mengubah ukuran saat saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang tertaut. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/python-net/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan menetapkan gambar pengganti yang sesuai.

**Apakah jalur relatif untuk objek OLE yang tertaut akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif terdapat pada format PPT yang lebih lama. Untuk portabilitas, sebaiknya gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyematkan.