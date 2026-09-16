---
title: Ekspor Presentasi ke XAML di .NET
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML di .NET menggunakan Aspose.Slides—solusi cepat tanpa Office yang mempertahankan tata letak Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas tumpukan XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk menggambarkan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh C# berikut menunjukkan cara mengekspor sebuah presentasi ke XAML dengan pengaturan default:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Secara default, slide yang diekspor disimpan dalam subfolder `pres` dari direktori kerja saat ini proses, sebagaimana dikembalikan oleh [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Folder ini dibuat secara otomatis, dan setiap gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output dinamai `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan jalur absolut ke presentasi input, folder output dibuat relatif terhadap direktori kerja saat ini, bukan di samping file input.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/ixamloptions/) untuk mengendalikan bagaimana Aspose.Slides mengekspor sebuah presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, implementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/ixamloutputsaver/) dan tetapkan sebuah instance dari implementasi Anda ke properti [OutputSaver](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/outputsaver/) pada [XamlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, set properti [ExportHiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) ke `true`, seperti yang ditunjukkan pada contoh C# berikut:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Tangkap Semua Artefak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor ditambah gambar terpisah dan sumber daya pendukung. Tetapkan [IXamlOutputSaver](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/ixamloutputsaver/) kustom ke [XamlOptions.OutputSaver](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/outputsaver/) untuk menerima artefak-artefak ini alih-alih menggunakan penyimpan sistem file default. Mulai ekspor dengan overload [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) spesifik XAML yang menerima opsi XAML.

### **Pahami Siklus Hidup Callback**

Eksporer memanggil [IXamlOutputSaver.Save](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/ixamloutputsaver/save/) secara terpisah untuk setiap artefak yang dihasilkan:

- `path` mengidentifikasi artefak dan dapat mencakup direktori relatif. Simpan informasi ini karena XAML dapat merujuk sumber daya menggunakan jalur relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lainnya tidak boleh didekode sebagai teks.
- Penyimpan bertanggung jawab untuk menyimpan atau mempersistensikan data sebelum mengembalikan. Contoh-contoh menyalin setiap array byte ke memori milik aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi kembali dan setiap callback selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak dipantau. Jika persistensi terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah itu juga berhasil.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) juga berlaku untuk penyimpan kustom. Nilai defaultnya, `false`, mengecualikan dokumen XAML slide tersembunyi. Menetapkannya ke `true` akan menyertakan mereka serta sumber daya apa pun yang diperlukan untuk ekspor mereka. Jumlah sumber daya tergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `pres.pptx`, mengumpulkan setiap artefak dalam [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2), dan mencetak nama, tipe, serta jumlah byte-nya. Ia mempertahankan nama yang diberikan persis. Nama duplikat menyebabkan pengumpulan gagal alih-alih menimpa artefak secara diam-diam.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Dekode hanya XAML, dan hanya ketika inspeksi teks diperlukan.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Panggil `InMemoryXamlExample.Run` dari aplikasi Anda. Pemeriksaan ekstensi berguna untuk inspeksi; simpan semua artefak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemasi Artefak yang Dikumpulkan dalam Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP. Nama arsip yang unik memisahkan pekerjaan ekspor bersamaan. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama yang tidak aman atau nama yang bertabrakan setelah normalisasi menolak seluruh paket sebelum ditulis.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Direktori ZIP telah difinalisasi melalui disposisi sebelum melaporkan keberhasilan.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Panggil `ZipXamlExample.Run` dari aplikasi Anda. Contoh ini menggunakan [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) untuk menulis satu arsip lokal; eksportor sendiri tidak menulis file XAML atau gambar terpisah. Untuk penyimpanan remote, ganti tahap penulisan arsip dengan mengunggah array byte yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artefak relatif lengkap sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika persistensi gagal.

Untuk presentasi besar, penyimpan kustom dapat menyimpan setiap artefak langsung ke penyimpanan aplikasi untuk menghindari menyimpan salinan tambahan seluruh ekspor di memori aplikasi. Exporter tetap mengumpulkan semua artefak yang dihasilkan di memori sebelum memanggil penyimpan. Jaga setiap callback tetap sinkron dari perspektif eksportor: kembalikan hanya setelah tujuan menerima byte, dan izinkan kegagalan sampai ke pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur ketika tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan hanya menggunakan [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama yang spesifik untuk tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen traversal, selesaikan tujuan dengan [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath), dan verifikasi tetap di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam cek kepemilikan. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengarahkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai dengan aturan sensitivitas huruf dari tujuan.
- Sebelum dipublikasikan, parsing setiap dokumen XAML sebagai XML dan periksa referensi sumber daya berbasis file, seperti atribut image `Source` atau `ImageSource`. Resolusi setiap URI relatif terhadap direktori artefak XAML yang memuatnya, normalisasi nama penyimpanan yang dihasilkan, dan pastikan kunci kamus, entri ZIP, atau objek yang disimpan yang bersesuaian ada. Perlakukan URI eksternal dan ekspresi markup XAML secara terpisah dari nama file relatif.

Misalnya, jika `pres/Slide_1.xaml` merujuk ke `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutuskan hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah awalan pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar terresolve dengan benar.

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Setel [DefaultRegularFont](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/defaultregularfont/) di [XamlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/) — font ini digunakan sebagai font cadangan selama ekspor ketika font asli tidak ada. Ini tidak menjamin bahwa XAML yang dihasilkan merujuk ke font cadangan atau bahwa font tersebut tersedia di mesin target. Pastikan bahwa font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat juga digunakan di tumpukan XAML lain?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan tumpukan XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegah mereka diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengendalikan perilaku ini melalui [ExportHiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) di [XamlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export.xaml/xamloptions/) — biarkan dinonaktifkan jika Anda tidak perlu mengekspornya.