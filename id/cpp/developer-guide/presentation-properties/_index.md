---
title: Kelola Properti Presentasi dalam C++
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/cpp/presentation-properties/
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
- edit metadata
- bahasa proofing
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi properti presentasi di Aspose.Slides untuk C++ dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua tipe properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/) . Sebuah instance dari antarmuka ini dikembalikan oleh [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_documentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Harap perhatikan bahwa Anda tidak dapat menetapkan nilai pada bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for C++ x.x.x akan ditampilkan pada bidang tersebut.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Ditetapkan Sistem (Built-in) 
- Properti yang Ditetapkan Pengguna (Custom) 

Properti **Built-in** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Custom** adalah yang didefinisikan pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Dengan menggunakan Aspose.Slides for C++, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun properti custom. Microsoft PowerPoint 2007 memungkinkan mengelola properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office dan kemudian menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Pada **Properties Dialog**, Anda dapat melihat banyak halaman tab seperti **General, Summary, Statistics, Contents, dan Custom**. Semua halaman tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Baca Properti Publik dari Presentasi yang Dienkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi dengan mengirim `false` ke [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), properti dokumennya tetap publik. Aplikasi kemudian dapat mengirim `true` ke [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) , dan membaca metadata publik tanpa memberikan password pembuka.

`set_OnlyLoadDocumentProperties` mengontrol apa yang dimuat oleh Aspose.Slides; ia tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) , dan kemudian membaca properti built-in melalui [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_documentproperties/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa `get_IsOnlyDocumentPropertiesLoaded` sebelum melakukan operasi yang membutuhkan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai custom. Enkripsi properti sensitif bersama dengan presentasi. Biarkan publik hanya ketika sistem indeksasi, klasifikasi, pencarian, atau manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti Presentasi yang Dienkripsi**

Untuk file PPTX yang dienkripsi, presentasi yang dimuat setelah memanggil `set_OnlyLoadDocumentProperties(true)` dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang berubah dari objek yang hanya berisi metadata tersebut karena properti publik harus tetap konsisten dengan data yang bersesuaian di dalam presentasi yang dienkripsi. Oleh karena itu, memperbaruinya memerlukan password pembuka yang tepat dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, maka harus memperlakukan properti publik dari file PPTX yang dienkripsi sebagai read-only.

## **Akses Properti Built-in**

Properti-properti yang ditampilkan oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antar produsen?), **PresentationFormat**, **Subject**, dan **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in dari file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan diubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in dari file presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Tambahkan Properti Presentasi Custom**

Aspose.Slides for C++ juga memungkinkan pengembang menambahkan nilai custom untuk properti Dokumen presentasi. Contoh di bawah menunjukkan cara mengatur properti custom untuk sebuah presentasi.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();

// Mendapatkan Properti Dokumen
auto documentProperties = presentation->get_DocumentProperties();

// Menambahkan properti Kustom
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Mendapatkan nama properti pada indeks tertentu
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Menghapus properti yang dipilih
documentProperties->RemoveCustomProperty(getPropertyName);

// Menyimpan presentasi
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides for C++ juga memungkinkan pengembang mengakses nilai properti custom. Contoh di bawah menunjukkan cara Anda dapat mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan properti [LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) (ditampilkan oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/portionformat/) ) untuk memungkinkan Anda mengatur bahasa proofing untuk dokumen PowerPoint. Bahasa proofing adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa di PowerPoint.

Kode C++ berikut menunjukkan cara mengatur bahasa proofing untuk PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// tetapkan Id bahasa proofing

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Atur Bahasa Default**

Kode C++ berikut menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Menambahkan bentuk persegi panjang baru dengan teks
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Memeriksa bahasa bagian pertama
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Contoh Langsung**

Coba aplikasi online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana saya dapat menghapus properti built-in dari sebuah presentasi?**

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diperbolehkan oleh properti tersebut.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dan kemudian [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/cpp/examine-presentation/) untuk contoh pelaporan lengkap dan batasan spesifik format.

**Apakah saya dapat membaca properti publik dari presentasi yang dienkripsi tanpa password pembukanya?**

Ya. Presentasi harus telah dienkripsi dengan mengirim `false` ke `set_EncryptDocumentProperties`, dan harus dimuat dengan mengirim `true` ke `set_OnlyLoadDocumentProperties`.

**Apakah saya dapat memperbarui file PPTX yang dienkripsi dalam mode hanya properti dokumen?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang dienkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.