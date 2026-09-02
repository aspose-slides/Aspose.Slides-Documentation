---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint dengan C++
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/cpp/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- pengelolaan dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- C++
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PowerPoint PPTX menggunakan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui statusnya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides mengekspos metadata label sensitivitas modern melalui [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Metode ini mengembalikan sebuah [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/) yang dapat diperiksa dan dimodifikasi sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Catatan" %}}
Identifier label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasikan metadata. Nilai [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) menjelaskan penandaan konten yang terkait dengan sebuah label; nilai tersebut tidak secara otomatis menambahkan teks atau bentuk yang terlihat pada slide.
{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [ISensitivityLabel](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/) berisi metadata berikut:

| Pengakses | Tujuan |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_id/) | Mengidentifikasi label sensitivitas dalam kebijakan Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Mengidentifikasi situs yang terkait dengan kebijakan label. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Menunjukkan apakah label diaktifkan. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Menunjukkan bahwa label telah dihapus. Tetapkan nilai ke `true` ketika status penghapusan harus dipertahankan dalam metadata. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Menentukan apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Menampilkan jenis penandaan konten yang terkait dengan label. |

Enum **SensitivityLabelAssignmentType** menggambarkan bagaimana sebuah label ditetapkan:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, direkomendasikan, dan wajib.

Enum **SensitivityLabelContentType** mengidentifikasi penandaan yang terkait dengan sebuah label:

| Nilai | Arti |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/id/cpp/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat dikaitkan dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) dan iterasi. Contoh berikut mencantumkan setiap properti dan penandaan konten yang disimpan untuk setiap label:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/add/) dengan identifier label, identifier situs, status aktif, dan metode penetapan. Setelah metode mengembalikan [ISensitivityLabel](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan melalui [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Contoh berikut menambahkan label yang dipilih secara manual yang terkait dengan penandaan footer dan watermark, lalu menyimpan hasilnya sebagai PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Memperbarui Label Sensitivitas**

Nilai [ISensitivityLabel](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/) dapat dibaca/ditulis melalui metode getter dan setter mereka, kecuali koleksi yang dikembalikan oleh [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui identifier, identifier situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk mempersist perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan panggil [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_isremoved/) dengan `true`. Ini mempertahankan entri label sambil mencatat status dihapusnya. Jika Anda justru perlu menghapus entri dari koleksi modern, gunakan [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/removeat/); gunakan [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/clear/) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang telah diperbarui:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Membaca dan Memigrasi Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP lama dapat menyimpan metadata label sensitivitas dalam properti dokumen khusus alih‑alih koleksi label modern. Baca metadata tersebut dengan [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Metode ini mengurai properti khusus legacy dan mengembalikan array objek [ISensitivityLabel](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/).

Untuk memigrasikan metadata, tambahkan setiap label yang dikembalikan ke [ISensitivityLabelCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/) modern melalui [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/add/). Karena menambahkan identifier label duplikat akan memicu pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin setiap label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Migrasi menyalin objek label yang diurai ke dalam koleksi modern. Tidak diperlukan pembersihan semua properti dokumen khusus, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [IPresentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/save/) dengan [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **Tanya Jawab**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) menjelaskan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang bersesuaian secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Memanggil [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/set_isremoved/) dengan `true` mempertahankan entri label dan mencatat status penghapusannya. Memanggil [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/removeat/) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan kebutuhan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern secara bersamaan?**

Ya. Label legacy dapat tetap berada di properti dokumen khusus sementara label modern tersedia melalui [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Gunakan [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) untuk membaca metadata legacy dan memigrasi hanya label yang valid yang belum ada di koleksi modern.

**Apa yang terjadi ketika sebuah label dengan identifier yang sama ditambahkan lebih dari satu kali?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabelcollection/add/) melempar pengecualian argument ketika koleksi sudah berisi label dengan identifier yang sama. Periksa nilai [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/id/cpp/aspose.slides/isensitivitylabel/get_id/) yang ada sebelum menambah atau memigrasi label.

**Format output mana yang harus digunakan untuk mempertahankan label sensitivitas yang telah diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [IPresentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/save/) bersama [SaveFormat::Pptx](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/), seperti yang ditunjukkan dalam contoh di atas.