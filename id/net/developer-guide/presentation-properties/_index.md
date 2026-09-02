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
description: "Kuasai properti presentasi di Aspose.Slides untuk .NET dan tingkatkan pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides for .NET mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides for .NET.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/). Sebuah instance antarmuka ini dikembalikan oleh properti [Presentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/documentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti ini.

{{% alert color="info" title="Note" %}}
Harap perhatikan bahwa bidang **Application** dan **Producer** tidak dapat diubah, karena bidang tersebut akan selalu menampilkan "Aspose Ltd." dan "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama file. Ada dua tipe properti dokumen:

- Properti yang didefinisikan sistem (built-in)
- Properti yang didefinisikan pengguna (custom)

Properti **Built-in** berisi informasi umum tentang dokumen, seperti judul dokumen, nama penulis, statistik dokumen, dan lainnya.

Properti **Custom** didefinisikan oleh pengguna sebagai pasangan **Nama/Nilai**, di mana baik nama maupun nilai ditentukan oleh pengguna.

Dengan Aspose.Slides for .NET, pengembang dapat mengakses dan memodifikasi baik properti built-in maupun custom.

Microsoft PowerPoint memungkinkan pengguna mengelola properti dokumen dengan mengklik ikon Office, lalu memilih **File → Info → Properties**. Setelah memilih **Advanced Properties**, sebuah dialog muncul yang memungkinkan Anda mengelola semua properti dokumen dari file presentasi.

Dalam dialog **Properties**, terdapat beberapa tab, seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Setiap tab menyediakan opsi untuk mengonfigurasi tipe informasi tertentu terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti yang didefinisikan pengguna.

## **Akses Properti Built-in**

Properti-properti ini, yang disediakan oleh antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/), meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (menunjukkan apakah dokumen dibagikan antara produsen yang berbeda), **PresentationFormat**, **Subject**, **Title**, dan lainnya.

```cs
using Aspose.Slides;

// Buat instance kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
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

Memodifikasi properti built-in dari file presentasi sama mudahnya dengan mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan, dan nilai properti tersebut akan diperbarui. Pada contoh di bawah ini, kami menunjukkan cara memodifikasi properti dokumen built-in sebuah file presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Setel properti Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Tambahkan Properti Presentasi Custom**

Properti presentasi custom memungkinkan pengembang menyimpan metadata tambahan atau informasi spesifik dalam file presentasi. Aspose.Slides memudahkan pembuatan dan pengelolaan properti custom secara programatis. Contoh-contoh berikut memperlihatkan cara menambahkan properti custom ke presentasi Anda.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using Presentation presentation = new Presentation();

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Tambahkan properti kustom.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Simpan presentasi ke file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides juga memungkinkan pengembang mengakses properti custom yang ada dan memodifikasi nilai mereka dengan mudah. Fungsionalitas ini membantu menjaga metadata yang akurat dan mendukung pembaruan dinamis berdasarkan input pengguna atau logika bisnis. Contoh-contoh di bawah ini memperlihatkan cara mengambil dan memperbarui nilai properti custom dalam sebuah presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Akses dan modifikasi properti kustom.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Tampilkan nama dan nilai properti kustom.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifikasi nilai properti kustom.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Simpan presentasi ke file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Contoh Langsung**

Coba aplikasi daring [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut memperbolehkan.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) lalu [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/net/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.