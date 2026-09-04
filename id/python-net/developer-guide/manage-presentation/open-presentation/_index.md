---
title: Membuka Presentasi di Python
linktitle: Membuka Presentasi
type: docs
weight: 20
url: /id/python-net/open-presentation/
keywords:
- buka PowerPoint
- buka presentasi
- buka PPTX
- buka PPT
- buka ODP
- muat presentasi
- muat PPTX
- muat PPT
- muat ODP
- presentasi terlindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Python
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di Python, menyediakan kata sandi pembuka, serta mengurangi penggunaan memori dengan Aspose.Slides for Python via .NET."
---
## **Pendahuluan**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/id/python-net/) dapat memuat presentasi PowerPoint dan OpenDocument dari berkas dan aliran. Setelah sebuah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori, atau mengabaikan data biner tersemat.

## **Buka Presentasi**

Untuk membuka presentasi yang ada, berikan jalur berkasnya ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Gunakan pernyataan `with` sehingga handle berkas, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh Python berikut menunjukkan cara membuka presentasi dan mendapatkan jumlah slide:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, tetapkan kata sandi yang benar ke [LoadOptions.password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/) dan berikan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Pemuatan gagal bila kata sandi tidak ada atau salah.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password-Protect Presentations](/slides/id/python-net/password-protected-presentation/). Jika sebuah presentasi terenkripsi sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/python-net/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/blob_management_options/) mengendalikan cara Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga berkas sumber tetap terkunci, mengizinkan berkas sementara, dan membatasi jumlah data BLOB yang disimpan dalam memori.

Kode Python berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Dengan `PresentationLockingBehavior.KEEP_LOCKED`, berkas sumber tetap terkunci hingga objek `Presentation` dibuang. Jangan memindahkan, menimpa, atau menghapus berkas sumber selama objek tersebut masih hidup.

Aspose.Slides mungkin menyalin isi aliran input saat memuatnya. Untuk presentasi besar, jalur berkas umumnya lebih efisien daripada aliran. Lihat [Manage BLOBs](/slides/id/python-net/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Muat Presentasi tanpa Objek Biner Tersemat**

Sebuah presentasi mungkin berisi data biner tersemat yang tidak dibutuhkan atau tidak diinginkan oleh aplikasi. Contohnya:

- Proyek VBA, tersedia melalui [Presentation.vba_project](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/vba_project/);
- Data OLE tersemat, tersedia melalui [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- Data kontrol ActiveX, tersedia melalui [Control.active_x_control_binary](https://reference.aspose.com/slides/id/python-net/aspose.slides/control/active_x_control_binary/).

Setel [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) ke `True` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang sudah disanitasi.

Opsi ini mengurangi paparan terhadap muatan tersemat yang tidak diinginkan, tetapi tidak merupakan sistem deteksi malware atau sanitasi konten yang lengkap.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah berkas rusak dan tidak dapat dibuka?**

Aspose.Slides mengeluarkan pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah sehingga aplikasi dapat melaporkan penyebabnya dengan akurat.

**Apa yang terjadi jika font yang diperlukan tidak ada?**

Presentasi masih dapat dimuat, tetapi rendering dan ekspor mungkin menggantikan font. Anda dapat [konfigurasi substitusi font](/slides/id/python-net/font-substitution/) atau [sediakan font kustom](/slides/id/python-net/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat sebuah presentasi juga memuat media tersematnya?**

Audio dan video tersemat menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya default dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.