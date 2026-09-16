---
title: Ekspor Presentasi ke XAML dengan Python
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/python-net/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- Python
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dengan Python menggunakan Aspose.Slides—solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengenalan singkat tentang XAML, memperlihatkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas tumpukan XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk mendeskripsikan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis serta mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh Python berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Secara default, slide yang diekspor disimpan dalam subfolder `pres` dari direktori kerja saat ini proses, seperti yang dikembalikan oleh [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Folder tersebut dibuat secara otomatis, dan gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output dinamai `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan path absolut ke presentasi input, folder output dibuat relatif terhadap direktori kerja saat ini, bukan di samping file input.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan kelas [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) untuk mengontrol cara Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyertakan slide tersembunyi dalam output XAML, atur properti [export_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) menjadi `True`, seperti yang ditunjukkan dalam contoh Python berikut:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Tangkap Semua Artifak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor plus gambar terpisah dan sumber daya pendukung. Simpan semua file ini saat menyimpan atau mentransmisikan ekspor.

Contoh di bawah ini menggunakan penyimpan sistem file default di direktori sementara, kemudian mengumpulkan file yang dihasilkan.

### **Pahami Siklus Hidup Ekspor**

- Mulai ekspor dengan overload khusus XAML dari [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) yang menerima opsi XAML. Baca file yang dihasilkan hanya setelah metode tersebut kembali berhasil.
- Pertahankan jalur relatif setiap artifak karena XAML mungkin merujuk sumber daya menggunakan jalur relatif.
- Baca artifak sebagai byte. Gambar dan sumber daya biner lainnya tidak boleh didekode sebagai teks.
- Laporkan keberhasilan keseluruhan hanya setelah pengumpulan dan operasi penyimpanan lanjutan selesai. Biarkan kesalahan penyimpanan menjangkau pemanggil, dan bersihkan output parsial jika penyimpanan gagal.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) defaultnya `False`, yang mengecualikan dokumen XAML slide tersembunyi. Mengaturnya ke `True` menyertakan mereka serta semua sumber daya yang diperlukan untuk ekspor mereka. Jumlah sumber daya tergantung pada presentasi; jangan mengasumsikan satu file per slide.

{{% alert color="warning" title="Warning" %}}
Contoh-contoh sementara mengubah direktori kerja saat ini proses, yang memengaruhi semua thread. Jalankan setiap ekspor dalam proses pekerja khusus, atau pastikan tidak ada pekerjaan lain dalam proses yang bergantung pada direktori saat ini selama ekspor. Direktori sementara yang unik saja tidak membuat ekspor bersamaan dalam proses yang sama aman.
{{% /alert %}}

### **Ekspor ke Memori dan Periksa Artifak**

Contoh lengkap ini memuat `pres.pptx`, mengekspornya ke direktori sementara, mengumpulkan setiap artifak dalam kamus nama relatif dan byte, serta mencetak nama, tipe, dan jumlah byte. Ini mempertahankan struktur direktori yang dihasilkan dan menghapus file sementara setelah pengumpulan. Jalur input diselesaikan sebelum mengubah direktori kerja.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Dekode hanya XAML, dan hanya ketika inspeksi teks diperlukan.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Pemeriksaan ekstensi berguna untuk inspeksi; simpan semua artifak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Dekode hanya XAML yang memerlukan pemrosesan teks. Pendekatan ini menggunakan ruang disk sementara serta memori untuk ekspor yang dikumpulkan.

### **Kemasi Artifak yang Dikumpulkan dalam Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP. Nama arsip yang unik memisahkan pekerjaan ekspor. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama yang tidak aman atau yang bertabrakan setelah normalisasi menolak seluruh paket sebelum ditulis.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Direktori ZIP telah selesai disusun sebelum melaporkan keberhasilan.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Contoh ini menggunakan [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) untuk menulis satu arsip lokal setelah mengumpulkan ekspor sementara. Untuk penyimpanan jarak jauh, ganti tahap penulisan arsip dengan mengunggah byte yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artifak relatif lengkap sebagai kunci objek, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika penyimpanan gagal.

Untuk presentasi besar, proses file sementara satu per satu setelah ekspor alih-alih mengumpulkan semua byte mereka dalam kamus. Ini menghindari salinan memori tambahan dari seluruh ekspor, tetapi tidak menghilangkan kebutuhan memori pengekspor itu sendiri.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur ketika tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan hanya menyimpan nama file akhir kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama spesifik tujuan. Saat menulis file terpisah, tolak jalur absolut dan segmen traversal, selesaikan tujuan, dan verifikasi bahwa itu tetap berada di bawah direktori ekspor yang dimaksud. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengarahkan penulisan.
- Gunakan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai dengan aturan sensitivitas huruf tujuan.
- Sebelum dipublikasikan, parsing setiap dokumen XAML sebagai XML dan inspeksi referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusi setiap URI relatif terhadap direktori artifak XAML yang memuatnya, normalisasi nama penyimpanan yang dihasilkan, dan pastikan kunci kamus yang bersangkutan, entri ZIP, atau objek yang disimpan ada. Perlakukan URI eksternal dan ekspresi markup XAML secara terpisah dari nama file relatif.

Sebagai contoh, jika `pres/Slide_1.xaml` merujuk `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutuskan hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, dan muat slide representatif di lingkungan XAML target untuk memastikan gambar terresolusi dengan benar.

## **FAQ**

**Bagaimana cara memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Atur [default_regular_font](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) dalam [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) — font ini digunakan sebagai font cadangan selama ekspor ketika font asli tidak ada. Ini tidak menjamin bahwa XAML yang dihasilkan merujuk font cadangan atau bahwa font tersebut tersedia di mesin target. Pastikan font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan dalam tumpukan XAML lain juga?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan tumpukan XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [export_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) dalam [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) — biarkan opsi ini nonaktif jika Anda tidak perlu mengekspornya.