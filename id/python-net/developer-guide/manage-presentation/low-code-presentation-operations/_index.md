---
title: Operasi Presentasi Low-Code dalam Python
linktitle: API Low-Code
type: docs
weight: 50
url: /id/python-net/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- kumpulkan shape
- kompres presentasi
- hapus master slide yang tidak terpakai
- hapus layout slide yang tidak terpakai
- kompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides dalam Python untuk mengonversi dan menggabungkan presentasi, mengumpulkan shape, serta mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Modul [aspose.slides.lowcode](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/) menyediakan kelas pembantu untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan dalam metode terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default cocok dengan kebutuhan Anda. Gunakan [Aspose.Slides object model](https://reference.aspose.com/slides/id/python-net/aspose.slides/) secara penuh ketika Anda memerlukan kontrol detail atas slide individual, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Gunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/convert/) | Mengonversi presentasi ke format lain dengan panggilan file-ke-file langsung. |
| [Merger](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [Collect](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang disematkan. |

## **Mengonversi Presentasi**

Gunakan [Convert.auto_by_extension](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/convert/auto_by_extension/) ketika ekstensi file keluaran cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur keluaran, dan menulis hasilnya.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Kelas [Convert](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/convert/) juga menyediakan metode khusus untuk keluaran PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek penuh ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/slides/id/python-net/convert-presentation/) untuk alur kerja dan opsi khusus format.

## **Menggabungkan Presentasi**

Gunakan [Merger.process](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/merger/process/) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi input harus memiliki format file yang sama.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek penuh ketika Anda perlu menggabungkan slide yang dipilih, menerapkan master atau layout tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/slides/id/python-net/merge-presentation/) untuk skenario tersebut.

## **Mengumpulkan Shape**

Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan kumpulan semua shape dalam sebuah presentasi. Ini berguna ketika kumpulan yang sama akan difilter, dihitung, atau diproses lebih dari satu kali.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Gunakan loop koleksi langsung ketika urutan penelusuran, penghentian awal, penyaringan sebelum pemrosesan, atau kontrol detail orangtua‑anak penting.

## **Mengompresi Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang disematkan:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) menghapus slide layout yang tidak dirujuk oleh slide normal.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) menghapus slide master yang tidak lagi digunakan.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) menghapus karakter yang tidak terpakai dari font yang disematkan.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak terreferensi setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin memerlukan master, layout, atau data font yang disematkan lengkap secara asli nanti. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/python-net/slide-master/) dan [Embedded Font](/slides/id/python-net/embedded-font/).

## **Tanya Jawab**

**Kapan saya harus menggunakan API low-code alih-alih model objek penuh?**

Gunakan pembantu low-code ketika operasi standar berlaku pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek penuh ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan pembantu.

**Apakah Merger dapat menggabungkan presentasi dalam format file yang berbeda?**

Tidak. [Merger.process](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/merger/process/) mengharuskan presentasi input memiliki format yang sama. Konversi file input ke format umum terlebih dahulu, misalnya dengan [Convert.auto_by_extension](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/convert/auto_by_extension/), lalu gabungkan file yang telah dikonversi.

**Apa yang termasuk dalam Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/collect/shapes/) mengambil shape dari presentasi sehingga dapat dipertahankan, difilter, dihitung, atau ditelusuri beberapa kali. Gunakan loop koleksi langsung ketika Anda memerlukan kontrol tepat atas jenis slide atau objek bersarang yang dikunjungi.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font yang disematkan dengan karakter yang tidak terpakai. Jika tidak ada yang tersebut, operasi [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang dimuat di memori. Setelah menjalankan [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/), panggil [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) untuk menulis hasilnya.

## **Artikel Terkait**

- [Konversi Presentasi](/slides/id/python-net/convert-presentation/)
- [Gabungkan Presentasi](/slides/id/python-net/merge-presentation/)
- [Slide Master](/slides/id/python-net/slide-master/)
- [Kelola Kotak Teks](/slides/id/python-net/manage-textbox/)
- [Font yang Disematkan](/slides/id/python-net/embedded-font/)