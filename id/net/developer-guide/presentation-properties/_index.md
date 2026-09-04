---
title: Kelola Properti Presentasi di .NET
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/net/presentation-properties/
keywords:
- Properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti kustom
- properti lanjutan
- kelola properti
- modifikasi properti
- metadata dokumen
- sunting metadata
- bahasa pengecekan
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk .NET dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides for .NET mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides for .NET.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/) . Sebuah instance dari antarmuka ini dikembalikan oleh [IPresentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/documentproperties/) . Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" title="Catatan" %}}
Harap dicatat bahwa bidang **Application** dan **Producer** tidak dapat diubah, karena bidang tersebut akan selalu menampilkan "Aspose Ltd." dan "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama file. Ada dua tipe properti dokumen:

- Properti yang ditentukan sistem (built-in)
- Properti yang ditentukan pengguna (custom)

**Built-in** properti berisi informasi umum tentang dokumen, seperti judul dokumen, nama penulis, statistik dokumen, dan lain‑lain.

**Custom** properti didefinisikan oleh pengguna sebagai pasangan **Nama/Nilai**, di mana baik nama maupun nilai ditentukan pengguna.

Dengan menggunakan Aspose.Slides for .NET, pengembang dapat mengakses dan memodifikasi baik properti built-in maupun custom.

Microsoft PowerPoint memungkinkan pengguna mengelola properti dokumen dengan mengklik ikon Office, lalu memilih **File → Info → Properties**. Setelah memilih **Advanced Properties**, sebuah dialog muncul di mana Anda dapat mengelola semua properti dokumen file presentasi.

Di dalam dialog **Properties**, terdapat beberapa tab, seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Setiap tab menyediakan opsi untuk mengonfigurasi tipe informasi spesifik terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti yang ditentukan pengguna.

## **Baca Properti Publik dari Presentasi Terenkripsi**

Kata sandi pembuka biasanya melindungi konten presentasi dan properti dokumen. Ketika sebuah presentasi dienkripsi dengan [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) disetel ke `false`, properti dokumennya tetap publik. Aplikasi kemudian dapat menyetel [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ke `true` dan membaca metadata publik tanpa menyediakan kata sandi pembuka.

`OnlyLoadDocumentProperties` mengontrol apa yang dimuat oleh Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa kata sandi akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan keseluruhan presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) dan kemudian membaca properti built-in melalui [IPresentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/documentproperties/) :

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, tata letak, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa `IsOnlyDocumentPropertiesLoaded` sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Keamanan" %}}
Metadata publik dapat mengekspos nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai kustom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan tetap publik hanya ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa kata sandi.
{{% /alert %}}

## **Perbarui Properti Presentasi Terenkripsi**

Untuk file PPTX yang terenkripsi, presentasi yang dimuat dengan `OnlyLoadDocumentProperties` dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang diubah dari objek yang hanya memuat metadata karena properti publik harus tetap konsisten dengan data yang ada di dalam presentasi terenkripsi. Oleh karena itu, memperbaruinya memerlukan kata sandi pembuka yang benar dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/isencrypted/) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa kata sandi untuk memeriksa nilai baru:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

Jika sebuah aplikasi tidak diizinkan mendekripsi atau memuat konten presentasi, ia harus memperlakukan properti publik dari file PPTX terenkripsi sebagai read‑only.

## **Akses Properti Built-in**

Properti‑properti ini, seperti yang diekspos oleh antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/) , meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (menunjukkan apakah dokumen dibagikan antara produsen yang berbeda), **PresentationFormat**, **Subject**, **Title**, dan lainnya.

```cs
using Aspose.Slides;

// Instansiasi kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Dapatkan referensi ke objek bertipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Tampilkan properti Built-in.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in dari file presentasi sama mudahnya dengan mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan, dan nilai properti tersebut akan diperbarui. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in dari sebuah file presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Dapatkan referensi ke objek bertipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Atur properti Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Simpan presentasi ke file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Tambahkan Properti Presentasi Kustom**

Properti presentasi kustom memungkinkan pengembang menyimpan metadata tambahan atau informasi spesifik di dalam file presentasi. Aspose.Slides memudahkan pembuatan dan pengelolaan properti kustom ini secara programatis. Contoh-contoh berikut menunjukkan cara menambahkan properti kustom ke presentasi Anda.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation.
using Presentation presentation = new Presentation();

// Dapatkan referensi ke objek bertipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Tambahkan properti kustom.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Simpan presentasi ke file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides juga memungkinkan pengembang mengakses properti kustom yang ada dan memodifikasi nilainya dengan mudah. Fungsionalitas ini membantu menjaga metadata yang akurat dan mendukung pembaruan dinamis berdasarkan input pengguna atau logika bisnis. Contoh-contoh di bawah mengilustrasikan cara mengambil dan memperbarui nilai properti kustom dalam sebuah presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Dapatkan referensi ke objek bertipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Akses dan modifikasi properti kustom.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Tampilkan nama dan nilai properti kustom.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ubah nilai properti kustom.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Simpan presentasi ke file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Contoh Langsung**

Coba aplikasi online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau menyetelnya menjadi kosong bila diperbolehkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) lalu [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Lihat [Membuat Inventaris Presentasi Ringan](/slides/id/net/examine-presentation/) untuk contoh pelaporan lengkap dan keterbatasan khusus format.

**Bisakah saya membaca properti publik dari presentasi terenkripsi tanpa kata sandi pembukanya?**

Ya. Presentasi harus dienkripsi dengan `EncryptDocumentProperties` disetel ke `false`, dan harus dimuat dengan `OnlyLoadDocumentProperties` disetel ke `true`.

**Bisakah saya memperbarui file PPTX terenkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX terenkripsi memerlukan pemuatan lengkap presentasi dengan kata sandi pembuka yang benar.