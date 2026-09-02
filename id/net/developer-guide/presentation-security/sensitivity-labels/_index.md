---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint di .NET
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/net/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- tata kelola dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- .NET
- C#
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PPTX PowerPoint dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui keadaannya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides mengekspos metadata label sensitivitas modern melalui [Presentation.SensitivityLabels](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sensitivitylabels/). Properti ini mengembalikan sebuah [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/) yang dapat diperiksa dan dimodifikasi sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Catatan" %}}

Pengidentifikasi label sensitivitas dan informasi kebijakan ditentukan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasikan metadata. Nilai ISensitivityLabel.ContentMarkTypes menjelaskan penandaan konten yang terkait dengan label; nilai tersebut tidak secara otomatis menambahkan teks atau bentuk yang terlihat pada slide.

{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [ISensitivityLabel](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/) berisi metadata berikut:

| Properti | Tujuan |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/id/) | Mengidentifikasi label sensitivitas dalam kebijakan Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/siteid/) | Mengidentifikasi situs yang terkait dengan kebijakan label. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/isenabled/) | Menunjukkan apakah label diaktifkan. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/isremoved/) | Menunjukkan bahwa label telah dihapus. Atur properti ini ke `true` bila status penghapusan harus dipertahankan dalam metadata. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Menentukan apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Mencantumkan jenis penandaan konten yang terkait dengan label. |

Enumerasi SensitivityLabelAssignmentType menjelaskan bagaimana sebuah label ditetapkan:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, direkomendasikan, dan wajib.

Enumerasi SensitivityLabelContentType mengidentifikasi penandaan yang terkait dengan sebuah label:

| Nilai | Makna |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/id/net/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [Presentation.SensitivityLabels](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sensitivitylabels/) dan lakukan enumerasi. Contoh berikut mencantumkan setiap properti dan penandaan konten yang disimpan untuk masing-masing label:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/add/) dengan pengidentifikasi label, pengidentifikasi situs, status aktif, dan metode penetapan. Setelah metode mengembalikan [ISensitivityLabel](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/), tambahkan nilai penandaan yang diperlukan melalui [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, lalu menyimpan hasilnya sebagai PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Memperbarui Label Sensitivitas**

Properti ISensitivityLabel dapat dibaca/ditulis, kecuali kumpulan yang dikembalikan oleh [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/contentmarktypes/) yang dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui pengidentifikasinya, pengidentifikasi situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menyimpan perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Tandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan atur [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/isremoved/) ke `true`. Ini mempertahankan entri label sambil mencatat status penghapusannya. Jika Anda malah perlu menghapus entri dari koleksi modern, gunakan [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/removeat/); gunakan [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/clear/) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang telah diperbarui:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Membaca dan Memigrasikan Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP yang lebih lama dapat menyimpan metadata label sensitivitas dalam properti dokumen kustom alih-alih koleksi label modern. Baca metadata tersebut dengan [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metode ini mengurai properti kustom legacy dan mengembalikan sebuah array objek [ISensitivityLabel](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/).

Untuk memigrasikan metadata, tambahkan setiap label yang dikembalikan ke [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/) modern melalui [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/add/). Karena menambahkan pengidentifikasi label duplikat akan memicu pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin setiap label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Migrasi menyalin objek label yang diurai ke dalam koleksi modern. Tidak diperlukan penghapusan semua properti dokumen kustom, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [IPresentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/contentmarktypes/) menggambarkan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang sesuai secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Mengatur [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/isremoved/) ke `true` mempertahankan entri label dan mencatat status penghapusannya. Memanggil [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/removeat/) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan persyaratan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern sekaligus?**

Ya. Label legacy dapat tetap berada di properti dokumen kustom sementara label modern tersedia melalui [Presentation.SensitivityLabels](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sensitivitylabels/). Gunakan [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/getsensitivitylabels/) untuk membaca metadata legacy dan memigrasikan hanya label yang valid yang belum ada di dalam koleksi modern.

**Apa yang terjadi ketika label dengan pengidentifikasi yang sama ditambahkan lebih dari sekali?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabelcollection/add/) melempar `ArgumentException` ketika koleksi sudah berisi label dengan pengidentifikasi yang sama. Periksa nilai [ISensitivityLabel.Id](https://reference.aspose.com/slides/id/net/aspose.slides/isensitivitylabel/id/) yang ada sebelum menambahkan atau memigrasikan label.

**Format output apa yang harus digunakan untuk mempertahankan label sensitivitas yang diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [IPresentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/) menggunakan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/), seperti yang ditunjukkan pada contoh di atas.