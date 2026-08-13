---
title: Kelola Properti Presentasi di C++
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
- Edit metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasai properti presentasi dalam Aspose.Slides untuk C++ dan permudah pencarian, penjenamaan, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pengantar**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui antarmuka [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_document_properties). Sebuah instance dari antarmuka ini dikembalikan oleh metode [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_documentproperties/). Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti ini.

{{% alert color="info" %}} 
Harap dicatat bahwa Anda tidak dapat mengatur nilai untuk field **Application** dan **Producer**, karena Aspose Ltd. dan Aspose.Slides for C++ x.x.x akan ditampilkan pada field tersebut.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dengan dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Didefinisikan Sistem (Built-in)
- Properti yang Didefinisikan Pengguna (Custom)

**Built-in** properti berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. **Custom** properti adalah properti yang didefinisikan pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for C++, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun custom. Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office kemudian pilih menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007. Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint. Pada **Properties Dialog**, Anda dapat melihat banyak tab seperti **General, Summary, Statistics, Contents and Custom**. Semua tab tersebut memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom file PowerPoint.

## **Akses Properti Built-in**

Properti-properti yang diekspos oleh objek **IDocumentProperties** meliputi: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antara produsen yang berbeda?), **PresentationFormat**, **Subject**, dan **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan berubah. Pada contoh di bawah ini, kami menunjukkan cara memodifikasi properti dokumen built-in file presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Tambah Properti Presentasi Custom**

Aspose.Slides for C++ juga memungkinkan pengembang menambahkan nilai custom untuk properti Dokumen presentasi. Contoh di bawah ini menunjukkan cara mengatur properti custom untuk sebuah presentasi.

``` cpp
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

Aspose.Slides for C++ juga memungkinkan pengembang mengakses nilai properti custom. Contoh di bawah ini menunjukkan cara Anda dapat mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan properti [LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) (yang diekspos oleh kelas [PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/portionformat/)) untuk memungkinkan Anda mengatur bahasa proofing untuk dokumen PowerPoint. Bahasa proofing adalah bahasa yang ejaan dan tata bahasanya akan diperiksa dalam PowerPoint.

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
// atur Id bahasa pemeriksaan

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

// Memeriksa bahasa potongan pertama
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Contoh Langsung**

Coba aplikasi daring [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## ***FAQ**

### Bagaimana saya dapat menghapus properti built-in dari sebuah presentasi?

Properti built-in merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika properti tersebut memperbolehkan.

### Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

### Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?

Ya, Anda dapat mengakses properti presentasi tanpa memuat seluruh presentasi dengan menggunakan metode `GetPresentationInfo` dari kelas [PresentationFactory](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/). Selanjutnya, gunakan metode `ReadDocumentProperties` yang disediakan oleh antarmuka [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/) untuk membaca properti secara efisien, menghemat memori, dan meningkatkan kinerja.