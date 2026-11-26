---
title: Kelola Properti Presentasi di .NET
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/net/presentation-properties/
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
- Edit metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk .NET dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides untuk .NET mendukung properti dokumen **bawaan** dan **kustom**. Gunakan properti ini untuk membaca dan memperbarui metadata presentasi, seperti penulis, judul, dan nilai yang ditentukan pengguna.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . Sebuah instance dari antarmuka ini dikembalikan oleh [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" title="Note" %}}
Aspose.Slides mengelola metadata aplikasi dan produsen saat menyimpan presentasi; bidang-bidang ini mengidentifikasi perangkat lunak yang membuat output.
{{% /alert %}}

## **Kelola Properti Presentasi**

Properti dokumen menyimpan informasi deskriptif bersamaan dengan konten presentasi. Mereka terbagi menjadi dua kategori:

- **Properti bawaan** berisi metadata standar, seperti judul, penulis, dan statistik dokumen.
- **Properti kustom** menyimpan pasangan nama/nilai yang ditentukan pengguna.

Aspose.Slides untuk .NET menyediakan akses ke kedua kategori. Di PowerPoint, pilih **File → Info → Properties → Advanced Properties** untuk memeriksa metadata dokumen. Dialog mengelompokkan informasi ke dalam tab seperti **Summary**, **Statistics**, **Contents**, dan **Custom**. Gunakan tab **Custom** untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi yang Ditenkripsi**

Password pembuka biasanya melindungi konten presentasi dan properti dokumen. Ketika sebuah presentasi dienkripsi dengan [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) disetel ke `false`, properti dokumennya tetap publik. Sebuah aplikasi kemudian dapat mengatur [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ke `true` dan membaca metadata publik tanpa menyediakan password pembuka.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) mengontrol apa yang dimuat Aspose.Slides; itu tidak mendekripsi apa pun. Jika properti tersebut termasuk dalam enkripsi, memuatnya tanpa password gagal. Jika presentasi tidak dienkripsi, opsi diabaikan dan presentasi lengkap dimuat.

Contoh ini memerlukan presentasi yang dienkripsi dimana properti dokumennya dibiarkan publik. Itu memverifikasi mode pemuatan melalui [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) dan kemudian membaca properti bawaan melalui [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, bentuk, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Security" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan mereka publik hanya ketika pengindeksan, klasifikasi, pencarian, atau sistem manajemen dokumen memiliki persyaratan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Ditenkripsi**

Untuk file PPTX yang dienkripsi, sebuah presentasi yang dimuat dengan [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek yang hanya berisi metadata tersebut karena properti publik harus tetap konsisten dengan data yang sesuai di dalam presentasi yang terenkripsi. Memperbarui mereka oleh karena itu memerlukan password pembuka yang benar dan pemuatan lengkap.

Contoh ini memerlukan presentasi PPTX yang dienkripsi dengan properti dokumen publik dan password pembuka yang diketahui. Ia membuka presentasi lengkap dengan [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), memperbarui properti bawaan publik, dan menyimpan hasilnya. Kemudian ia menggunakan [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, aplikasi harus memperlakukan properti publik dari file PPTX yang terenkripsi sebagai hanya-baca.

## **Akses Properti Bawaan**

Antarmuka [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) menampilkan metadata bawaan melalui properti bertipe, termasuk [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), dan [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Contoh ini membuka presentasi yang ada dan mencetak metadata yang disimpan ke konsol. Nilai tergantung pada presentasi input; beberapa bidang mungkin kosong.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Laporkan Nomor Revisi dan Waktu Penyuntingan**

Untuk melaporkan satu baris untuk setiap file PPTX di folder `presentations`, panggil [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk mengambil [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)‑nya tanpa memuat slide untuk penyuntingan. Format standar `c` untuk `TimeSpan` menyertakan jumlah hari ketika durasi mencapai 24 jam.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Contoh output untuk sebuah presentasi dengan 1 hari, 2 jam, dan 5 menit waktu penyuntingan yang tercatat:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) adalah metadata yang dapat ditulis. Nilainya saja tidak dapat menentukan berapa kali presentasi disimpan atau merekonstruksi riwayat versinya.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) adalah durasi penyuntingan yang tercatat dalam file. Nilai `00:00:00` berarti durasi yang disimpan adalah nol. Itu tidak membuktikan bahwa tidak ada yang menyunting presentasi.

## **Modifikasi Properti Bawaan**

Untuk memperbarui metadata bawaan, tetapkan nilai ke properti yang dapat ditulis yang ditampilkan oleh [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Contoh ini membuka presentasi yang ada, mengatur [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), dan [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), kemudian menyimpan presentasi yang diperbarui dengan [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). PPTX yang disimpan berisi metadata baru.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Kelola Basis Hyperlink**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) menyimpan basis level-dokumen untuk hyperlink relatif. Ini berguna saat memindahkan sebuah presentasi dan file yang ditautkan ke lokasi lain. Ini terpisah dari [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) pada hyperlink individual: mengubah basis tidak menulis ulang alamat tautan yang disimpan atau mengubah tujuan absolut.

Contoh ini memerlukan presentasi yang berisi baik tautan relatif, seperti `target.html`, dan tautan absolut, seperti `https://example.org/absolute.html`. Ia membaca basis yang ada, menetapkan alamat basis baru, dan menyimpan serta membuka kembali presentasi untuk memeriksa nilai tersebut. Kemudian ia mengosongkan basis dengan `string.Empty` dan memverifikasi nilai kosong di file tersimpan terpisah. Ganti alamat basis contoh dengan lokasi file yang Anda tautkan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Dua pesan verifikasi harus mencetak `True`. Mengosongkan basis membiarkan alamat hyperlink individual tetap utuh.

Sebuah tautan relatif ke `target.pptx` membuka `old/target.pptx` ketika basis mengarah ke folder `old`. Setelah mengubah basis ke folder `new`, menyimpan, dan membuka kembali presentasi, tautan yang sama membuka `new/target.pptx`. Tautan absolut terus membuka file yang sama. Uji tautan relatif Anda di PowerPoint sebelum dan sesudah memindahkan presentasi atau mengubah basismya.

## **Tambah Properti Presentasi Kustom**

Properti kustom menyimpan metadata yang tidak memiliki bidang bawaan yang sesuai. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) memungkinkan Anda menetapkan nilai berdasarkan nama properti. Contoh ini membuat sebuah presentasi, menambahkan dua nilai teks dan nilai versi integer, dan menyimpan presentasi dengan [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Menetapkan nilai ke nama yang sudah ada menggantikan nilai properti tersebut.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Akses dan Modifikasi Properti Kustom**

Contoh ini membuka sebuah presentasi yang berisi properti kustom dan menggunakan [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) untuk mengiterasi mereka. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) menerima indeks berbasis nol dan mengembalikan nama yang digunakan oleh [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Contoh mencetak setiap nama dan nilai asli, mengganti setiap nilai dengan string berangka terlepas dari tipe aslinya, dan menyimpan perubahan. Jika tidak ada properti kustom, loop tidak membuat perubahan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Contoh Langsung**

Coba aplikasi daring [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Bagaimana cara menghapus properti bawaan dari sebuah presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diizinkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan yang baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Bisakah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) dan kemudian [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Lihat [Membuat Inventaris Presentasi Ringan](/slides/id/net/examine-presentation/) untuk contoh pelaporan lengkap dan keterbatasan khusus format.

**Bisakah saya membaca properti publik dari presentasi yang dienkripsi tanpa password pembukanya?**

Ya. Presentasi harus dienkripsi dengan [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) disetel ke `false`, dan harus dimuat dengan [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) disetel ke `true`.

**Bisakah saya memperbarui file PPTX yang dienkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang terenkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.