---
title: Kelola Properti Presentasi dalam C++
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/cpp/presentation-properties/
keywords:
- Properti PowerPoint
- Properti presentasi
- Properti dokumen
- Properti bawaan
- Properti khusus
- Properti lanjutan
- Kelola properti
- Modifikasi properti
- Metadata dokumen
- Sunting metadata
- Bahasa proofing
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides untuk C++ dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua tipe properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_document_properties). Sebuah instance dari antarmuka ini dikembalikan oleh metode [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_documentproperties/) . Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti ini.

{{% alert color="info" title="Note" %}}
Harap dicatat bahwa Anda tidak dapat mengatur nilai pada bidang **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for C++ x.x.x akan ditampilkan pada bidang tersebut.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dengan dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Ditetapkan Sistem (Built-in)
- Properti yang Ditentukan Pengguna (Custom)

**Built-in** properti berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. **Custom** properti adalah yang didefinisikan oleh pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for C++, pengembang dapat mengakses dan memodifikasi nilai properti built‑in maupun properti custom. Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office dan selanjutnya menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Di **Properties Dialog**, Anda dapat melihat banyak halaman tab seperti **General, Summary, Statistics, Contents and Custom**. Semua halaman tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Akses Properti Built-in**

Properti-properti ini yang diekspos oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antar produsen?), **PresentationFormat**, **Subject**, dan **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modifikasi Properti Built-in**

Memodifikasi properti built‑in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan diubah. Pada contoh di bawah ini, kami memperlihatkan cara memodifikasi properti dokumen built‑in dari file presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Tambahkan Properti Presentasi Kustom**

Aspose.Slides for C++ juga memungkinkan pengembang menambahkan nilai kustom untuk properti Dokumen presentasi. Contoh diberikan di bawah yang menunjukkan cara mengatur properti kustom untuk sebuah presentasi.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation
auto presentation = System::MakeObject<Presentation>();

// Mengambil Properti Dokumen
auto documentProperties = presentation->get_DocumentProperties();

// Menambahkan properti Kustom
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Mengambil nama properti pada indeks tertentu
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Menghapus properti yang dipilih
documentProperties->RemoveCustomProperty(getPropertyName);

// Menyimpan presentasi
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides for C++ juga memungkinkan pengembang mengakses nilai properti kustom. Contoh diberikan di bawah yang menunjukkan cara mengakses dan memodifikasi semua properti kustom untuk sebuah presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan properti [LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides.baseportionformat/set_languageid/) (diekspos oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/portionformat/)) untuk memungkinkan Anda mengatur bahasa proofing untuk dokumen PowerPoint. Bahasa proofing adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa dalam PowerPoint.

Kode C++ ini menunjukkan cara mengatur bahasa proofing untuk PowerPoint:

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

Kode C++ ini menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

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

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti built-in dari presentasi?**

Properti built‑in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya bila diperbolehkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dan kemudian [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Lihat [Build a Lightweight Presentation Inventory](/slides/id/cpp/examine-presentation/) untuk contoh pelaporan lengkap dan keterbatasan spesifik format.