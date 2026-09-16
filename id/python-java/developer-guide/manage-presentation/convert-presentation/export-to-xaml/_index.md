---
title: Ekspor Presentasi ke XAML dalam Python via Java
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke XAML dengan Aspose.Slides untuk Python via Java. Gunakan opsi default atau sertakan slide tersembunyi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides untuk Python via Java. Artikel mencakup pengenalan singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Letakkan `pres.pptx` di direktori kerja saat ini. Setiap contoh memulai JVM hanya jika belum berjalan.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk menggambarkan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis serta mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh Python berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Secara default, slide yang diekspor disimpan dalam subfolder `pres` dari direktori kerja proses saat ini. Folder dibuat secara otomatis, dan gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output dinamai `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan jalur absolut ke presentasi masukan, folder output tetap dibuat relatif terhadap direktori kerja saat ini, bukan berdampingan dengan file masukan.

## **Ekspor Presentasi ke XAML dengan Opsi Khusus**

Gunakan kelas [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) untuk mengontrol cara Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyimpan output ke lokasi khusus, implementasikan `IXamlOutputSaver` dan berikan instance implementasi Anda ke metode [setOutputSaver](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setOutputSaver) milik [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan `True`, seperti pada contoh Python berikut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Tangkap Semua Artefak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor serta gambar terpisah dan sumber daya pendukung. Tetapkan `IXamlOutputSaver` khusus ke [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setOutputSaver) untuk menerima artefak-artefak ini alih-alih menggunakan penyimpan sistem berkas default. Mulai ekspor dengan overload [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) yang menerima opsi XAML.

Di Python, gunakan `jpype.JProxy` untuk mengimplementasikan antarmuka Java `IXamlOutputSaver`. Konversi jalur callback ke `str` dan salin array byte Java ke `bytes` Python sebelum mengembalikan nilai, seperti yang ditunjukkan di bawah.

### **Pahami Siklus Hidup Callback**

Ekspor memanggil `IXamlOutputSaver.save` secara terpisah untuk setiap artefak yang dihasilkan:

- `path` mengidentifikasi artefak dan dapat menyertakan direktori relatif. Simpan informasi ini karena XAML dapat merujuk sumber daya menggunakan jalur relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lainnya tidak boleh di-decode sebagai teks.
- Penyimpan bertanggung jawab untuk mempertahankan atau menyimpan data sebelum mengembalikan. Contoh menyalin setiap array byte ke memori milik aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi selesai dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak dipantau. Jika persistensi terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah itu juga berhasil.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) juga berlaku untuk penyimpan khusus. Pengaturan default, `False`, mengecualikan dokumen XAML slide tersembunyi. Menetapkan `True` menyertakan mereka serta semua sumber daya yang diperlukan untuk ekspor mereka. Jumlah sumber daya bergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `pres.pptx`, mengumpulkan setiap artefak dalam kamus Python berisi nama dan nilai `bytes` tak dapat diubah, lalu mencetak nama, tipe, dan jumlah byte. Nama disimpan persis sebagaimana diberikan. Nama duplikat menandai koleksi tidak valid alih-alih menimpa artefak secara diam-diam. Contoh memeriksa hal ini sebelum menggunakan hasilnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Dekode hanya XAML, dan hanya ketika inspeksi teks diperlukan.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Pemeriksaan ekstensi berguna untuk inspeksi; simpan semua artefak, termasuk tipe sumber daya yang tidak dikenali. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan `bytes.decode` dengan UTF-8 hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemas Artefak yang Dikumpulkan ke Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi nama-namanya, dan menulis byte asli ke dalam arsip ZIP. Nama arsip unik memisahkan pekerjaan ekspor yang bersamaan. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama tidak aman atau yang bertabrakan setelah normalisasi menolak seluruh paket sebelum ditulis.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Closing finalizes the ZIP directory before success is reported.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Contoh menggunakan `zipfile.ZipFile` Python untuk menulis satu arsip lokal; eksportor sendiri tidak menulis file XAML atau gambar terpisah. Untuk penyimpanan remote, gantikan tahap penulisan arsip dengan upload array byte yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artefak relatif lengkap sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua upload selesai atau transaksi basis data dikomit. Bersihkan output parsial jika persistensi gagal.

Untuk presentasi besar, penyimpan khusus dapat menyimpan setiap artefak langsung ke penyimpanan aplikasi untuk menghindari menyalin seluruh ekspor ke memori aplikasi. Jaga setiap callback sinkron dari perspektif eksportor: kembalikan hanya setelah tujuan menerima byte, dan izinkan kegagalan sampai pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur bila tujuan memerlukannya, namun pertahankan direktori relatif. Jangan gunakan hanya `pathlib.Path.name` kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama spesifik tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen traversal, selesaikan tujuan dengan `pathlib.Path.resolve`, dan verifikasi tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan containment. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengalihkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai aturan sensitivitas huruf tujuan.
- Sebelum dipublikasikan, parsing setiap dokumen XAML sebagai XML dan inspeksi referensi sumber daya berbasis berkas, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusi setiap URI relatif terhadap direktori artefak XAML yang bersangkutan, normalisasi nama penyimpanan yang dihasilkan, dan konfirmasi bahwa kunci peta, entri ZIP, atau objek yang disimpan ada. Tangani URI eksternal dan ekspresi markup XAML terpisah dari nama berkas relatif.

Sebagai contoh, bila `pres/Slide_1.xaml` merujuk ke `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutus hubungan tersebut. Untuk penyimpanan objek, pertahankan layout yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif dalam lingkungan XAML target untuk memastikan gambar ter-resolve dengan benar.

## **FAQ**

**Bagaimana cara memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Panggil [setDefaultRegularFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) pada [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) — font ini digunakan sebagai fallback selama ekspor ketika font asli tidak ada. Hal ini tidak menjamin XAML yang dihasilkan merujuk pada font fallback atau bahwa font tersebut tersedia di mesin target. Pastikan font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan pada stack XAML lainnya?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan stack XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) pada [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) — biarkan opsi ini tetap nonaktif jika Anda tidak perlu mengekspornya.