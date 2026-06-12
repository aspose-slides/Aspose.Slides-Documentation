---
title: Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan Python
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/python-net/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- tambah node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isi
- node render
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam PPT, PPTX, dan ODP dengan Aspose.Slides untuk Python via .NET. Dapatkan contoh kode yang jelas dan tip untuk menyederhanakan presentasi Anda."
---
## **Ringkasan**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan menentukan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatik: menambahkan node baru dan node anak, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, dan membaca teks, level, serta posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Artikel ini menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isi node, serta menghasilkan gambar miniatur untuk node anak SmartArt.

## **Tambah Node SmartArt**
Aspose.Slides for Python via .NET telah menyediakan API paling sederhana untuk mengelola bentuk SmartArt dengan cara termudah. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Tambahkan Node baru ke NodeCollection shape SmartArt dan atur teksnya di TextFrame.
- Sekarang, Tambahkan Node Anak ke Node SmartArt yang baru ditambahkan dan atur teksnya di TextFrame.
- Simpan Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Telusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:

        # Periksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Menambahkan Node SmartArt baru
            node1 = shape.all_nodes.add_node()
            # Menambahkan teks
            node1.text_frame.text = "Test"

            # Menambahkan node anak baru pada node induk. Node ini akan ditambahkan di akhir koleksi
            new_node = node1.child_nodes.add_node()

            # Menambahkan teks
            new_node.text_frame.text = "New Node Added"

    # Menyimpan Presentasi
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambah Node SmartArt pada Posisi Tertentu**
Pada contoh kode berikut kami menjelaskan cara menambahkan node anak yang menjadi milik masing‑masing node dari shape SmartArt pada posisi tertentu.

- Buat instance kelas `Presentation`.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Tambahkan shape SmartArt tipe StackedList pada slide yang diakses.
- Akses node pertama pada shape SmartArt yang ditambahkan.
- Sekarang, tambahkan Node Anak untuk Node yang dipilih pada posisi 2 dan atur teksnya.
- Simpan Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Membuat instance presentasi
with slides.Presentation() as pres:
    # Mengakses slide presentasi
    slide = pres.slides[0]

    # Menambahkan IShape Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Mengakses node SmartArt pada indeks 0
    node = smart.all_nodes[0]

    # Menambahkan node anak baru pada posisi 2 di node induk
    chNode = node.child_nodes.add_node_by_position(2)

    # Menambahkan teks
    chNode.text_frame.text = "Sample text Added"

    # menyimpan Presentasi
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Node SmartArt**
Kode contoh berikut akan membantu mengakses node di dalam shape SmartArt. Harap perhatikan bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan saat shape SmartArt ditambahkan.

- Buat instance kelas `Presentation` dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Telusuri semua Node di dalam Shape SmartArt.
- Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Telusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:
        # Periksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Telusuri semua node di dalam SmartArt
            for i in range(len(shape.all_nodes)):
                # Mengakses node SmartArt pada indeks i
                node = shape.all_nodes[i]

                # Mencetak parameter node SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

## **Akses Node Anak SmartArt**
Kode contoh berikut akan membantu mengakses node anak yang menjadi milik masing‑masing node dari shape SmartArt.

- Buat instance kelas PresentationEx dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArtEx jika memang SmartArt.
- Telusuri semua Node di dalam Shape SmartArt.
- Untuk setiap Node shape SmartArt yang dipilih, telusuri semua Node Anak di dalam node tertentu.
- Akses dan tampilkan informasi seperti posisi Node Anak, level, dan Teks.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Telusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:
        # Periksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Telusuri semua node di dalam SmartArt
            for node0 in shape.all_nodes:
                # Menelusuri node anak
                for j in range(len(node0.child_nodes)):
                    # Mengakses node anak dalam node SmartArt
                    node = node0.child_nodes[j]

                    # Mencetak parameter node anak SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **Akses Node Anak SmartArt pada Posisi Tertentu**
Pada contoh ini, kami akan mempelajari cara mengakses node anak pada posisi tertentu yang menjadi milik masing‑masing node dari shape SmartArt.

- Buat instance kelas `Presentation`.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Tambahkan shape SmartArt tipe StackedList.
- Akses shape SmartArt yang ditambahkan.
- Akses node pada indeks 0 untuk shape SmartArt yang diakses.
- Sekarang, akses Node Anak pada posisi 1 untuk node SmartArt yang diakses menggunakan metode GetNodeByPosition().
- Akses dan tampilkan informasi seperti posisi Node Anak, level, dan Teks.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Membuat instance presentasi
with slides.Presentation() as pres:
    # Mengakses slide pertama
    slide = pres.slides[0]
    # Menambahkan shape SmartArt di slide pertama
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Mengakses node SmartArt pada indeks 0
    node = smart.all_nodes[0]
    # Mengakses node anak pada posisi 1 di node induk
    position = 1
    chNode = node.child_nodes[position] 
    # Mencetak parameter node anak SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Hapus Node SmartArt**
Pada contoh ini, kami akan mempelajari cara menghapus node di dalam shape SmartArt.

- Buat instance kelas `Presentation` dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Periksa apakah SmartArt memiliki lebih dari 0 node.
- Pilih node SmartArt yang akan dihapus.
- Sekarang, hapus node yang dipilih menggunakan metode RemoveNode() * Simpan Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Telusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:
        # Periksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Lakukan Typecast shape menjadi SmartArtEx
            if len(shape.all_nodes) > 0:
                # Mengakses node SmartArt pada indeks 0
                node = shape.all_nodes[0]

                # Menghapus node yang dipilih
                shape.all_nodes.remove_node(node)

    # simpan Presentasi
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Node SmartArt pada Posisi Tertentu**
Pada contoh ini, kami akan mempelajari cara menghapus node di dalam shape SmartArt pada posisi tertentu.

- Buat instance kelas `Presentation` dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Pilih node shape SmartArt pada indeks 0.
- Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 node anak.
- Sekarang, hapus node pada Posisi 1 menggunakan metode RemoveNodeByPosition().
- Simpan Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Telusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:
        # Periksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Lakukan Typecast shape menjadi SmartArt
            if len(shape.all_nodes) > 0:
                # Mengakses node SmartArt pada indeks 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Menghapus node anak pada posisi 1
                    node.child_nodes.remove_node(1)

    # simpan Presentasi
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Posisi Kustom untuk Node Anak dalam SmartArt**
Sekarang Aspose.Slides for Python via .NET mendukung pengaturan properti X dan Y SmartArtShape. Potongan kode di bawah ini menunjukkan cara mengatur posisi, ukuran, dan rotasi SmartArtShape secara kustom, serta harap perhatikan bahwa penambahan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Muat presentasi yang diinginkan
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Pindahkan shape SmartArt ke posisi baru
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Ubah lebar shape SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Ubah tinggi shape SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Ubah rotasi shape SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Periksa Node Asisten**
Pada contoh kode berikut kami akan menyelidiki cara mengidentifikasi Node Asisten dalam koleksi node SmartArt dan mengubahnya.

- Buat instance kelas PresentationEx dan muat presentasi dengan Shape SmartArt.
- Dapatkan referensi slide kedua dengan menggunakan Indeksnya.
- Telusuri setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArtEx jika memang SmartArt.
- Telusuri semua node di dalam shape SmartArt dan periksa apakah mereka adalah Node Asisten.
- Ubah status Node Asisten menjadi node normal.
- Simpan Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Membuat instance presentasi
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Menelusuri semua shape di dalam slide pertama
    for shape in pres.slides[0].shapes:
        # Memeriksa apakah shape bertipe SmartArt
        if type(shape) is art.SmartArt:
            # Menelusuri semua node pada shape SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Memeriksa apakah node adalah node Assitant
                if node.is_assistant:
                    # Mengatur node Assitant menjadi false dan menjadikannya node normal
                    node.is_assistant = False
    # simpan Presentasi
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Format Isi Node**
Aspose.Slides for Python via .NET memungkinkan penambahan bentuk SmartArt kustom dan pengaturan format isi mereka. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta mengatur format isi mereka menggunakan Aspose.Slides for Python via .NET.

Silakan ikuti langkah‑langkah di bawah ini:

- Buat instance kelas `Presentation`.
- Dapatkan referensi slide menggunakan indeksnya.
- Tambahkan bentuk SmartArt dengan mengatur LayoutType-nya.
- Atur FillFormat untuk node bentuk SmartArt.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Mengakses slide
    slide = presentation.slides[0]

    # Menambahkan shape SmartArt dan node
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Mengatur warna isi node
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Menyimpan Presentasi
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Miniatur Node Anak SmartArt**
Pengembang dapat membuat miniatur node anak SmartArt dengan mengikuti langkah‑langkah di bawah ini:

1. Buat instance kelas `Presentation` yang merepresentasikan file PPTX.
1. Tambahkan SmartArt.
1. Dapatkan referensi node dengan menggunakan Indeksnya.
1. Dapatkan gambar miniatur.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

Contoh di bawah ini menghasilkan miniatur node anak SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Membuat instance kelas Presentation yang mewakili file PPTX
with slides.Presentation() as presentation: 
    # Tambahkan SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Dapatkan referensi node dengan menggunakan Indeksnya
    node = smart.nodes[1]

    # Dapatkan thumbnail
    with node.shapes[0].get_image() as bmp:
        # simpan thumbnail
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai shape biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/python-net/shape-animation/) (masuk, keluar, penekanan, jalur gerakan) dan menyesuaikan waktu. Anda juga dapat memberi animasi pada shape di dalam node SmartArt bila diperlukan.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide secara dapat diandalkan jika ID internalnya tidak diketahui?**

Berikan dan cari menggunakan [teks alternatif](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/alternative_text/). Mengatur AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatik tanpa bergantung pada pengidentifikasi internal.

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan keakuratan visual tinggi selama [ekspor PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Bisakah saya mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender shape SmartArt ke [format raster](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/get_image/) atau ke [SVG](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/write_as_svg/) untuk output vektor yang dapat diskalakan, menjadikannya cocok untuk miniatur, laporan, atau penggunaan web.