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
- Properti khusus
- Properti lanjutan
- Kelola properti
- Ubah properti
- Metadata dokumen
- Sunting metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk .NET dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides for .NET mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides for .NET.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/). Sebuah instance dari antarmuka ini dikembalikan oleh properti [Presentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/documentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti ini.

{{% alert color="info" %}} 
Harap dicatat bahwa bidang **Application** dan **Producer** tidak dapat diubah, karena bidang ini akan selalu menampilkan "Aspose Ltd." dan "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama file. Ada dua jenis properti dokumen:

- Properti yang didefinisikan sistem (built-in)
- Properti yang didefinisikan pengguna (custom)

Properti **Built-in** berisi informasi umum tentang dokumen, seperti judul dokumen, nama penulis, statistik dokumen, dan lainnya.

Properti **Custom** didefinisikan oleh pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna.

Dengan menggunakan Aspose.Slides for .NET, pengembang dapat mengakses dan memodifikasi baik properti built-in maupun custom.

Microsoft PowerPoint memungkinkan pengguna mengelola properti dokumen dengan mengklik ikon Office, kemudian memilih **File → Info → Properties**. Setelah memilih **Advanced Properties**, sebuah dialog muncul di mana Anda dapat mengelola semua properti dokumen file presentasi.

Di dialog **Properties**, terdapat beberapa tab, seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Setiap tab menyediakan opsi untuk mengkonfigurasi tipe informasi tertentu yang terkait dengan file PowerPoint. Tab **Custom** digunakan untuk mengelola properti yang ditentukan pengguna.

## **Akses Properti Built-in**

Properti ini, sebagaimana diekspose oleh antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/), meliputi: **Creator** (Penulis), **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **SharedDoc** (menunjukkan apakah dokumen dibagikan antara produsen yang berbeda), **PresentationFormat**, **Subject**, **Title**, dan lainnya.

```cs
using Aspose.Slides;

// Membuat instance kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Mendapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Menampilkan properti Built-in.
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

## **Ubah Properti Built-in**

Memodifikasi properti built-in dari file presentasi sama mudahnya dengan mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan, dan nilai properti tersebut akan diperbarui. Pada contoh di bawah, kami menunjukkan cara mengubah properti dokumen built-in dari sebuah file presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili sebuah file presentasi.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
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

## **Tambahkan Properti Presentasi Custom**

Properti presentasi custom memungkinkan pengembang menyimpan metadata tambahan atau informasi spesifik dalam file presentasi. Aspose.Slides memudahkan pembuatan dan pengelolaan properti custom ini secara programatik. Contoh-contoh berikut menunjukkan cara menambahkan properti custom ke presentasi Anda.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using Presentation presentation = new Presentation();

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Tambahkan properti khusus.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Simpan presentasi ke file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Akses dan Ubah Properti Custom**

Aspose.Slides juga memungkinkan pengembang mengakses properti custom yang ada dan mengubah nilainya dengan mudah. Fungsionalitas ini membantu menjaga metadata yang akurat dan mendukung pembaruan dinamis berdasarkan masukan pengguna atau logika bisnis. Contoh di bawah mengilustrasikan cara mengambil dan memperbarui nilai properti custom dalam sebuah presentasi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Dapatkan referensi ke objek tipe IDocumentProperties yang terkait dengan presentasi.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Akses dan ubah properti khusus.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Tampilkan nama dan nilai properti khusus.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ubah nilai properti khusus.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Simpan presentasi ke file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Contoh Langsung**

Coba aplikasi daring [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen menggunakan API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## ***FAQ**

### Bagaimana cara menghapus properti built-in dari presentasi?

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diperbolehkan oleh properti tersebut.

### Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan yang baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

### Bisakah saya mengakses properti presentasi tanpa memuat seluruh presentasi?

Ya, Anda dapat mengakses properti presentasi tanpa memuat seluruh presentasi dengan menggunakan metode `GetPresentationInfo` dari kelas [PresentationFactory](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/). Kemudian, manfaatkan metode `ReadDocumentProperties` yang disediakan oleh antarmuka [IPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/) untuk membaca properti secara efisien, menghemat memori dan meningkatkan kinerja.