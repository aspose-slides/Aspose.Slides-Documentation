---
title: Simpan Presentasi dalam C++
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/cpp/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan terdefinisi
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- C++
- Aspose.Slides
description: "Temukan cara menyimpan presentasi dalam C++ menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Open Presentations in C++](/slides/id/cpp/open-presentation/) described how to use the [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) class to open a presentation. This article explains how to create and save presentations. The [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) class contains a presentation’s contents. Whether you’re creating a presentation from scratch or modifying an existing one, you’ll want to save it when you’re finished. With Aspose.Slides for C++, you can save to a **file** or **stream**. This article explains the different ways to save a presentation.

## **Simpan Presentasi ke File**

Save a presentation to a file by calling the [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) class’s `Save` method. Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Lakukan beberapa pekerjaan di sini...

// Simpan presentasi ke sebuah file.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Simpan Presentasi ke Stream**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) class’s `Save` method. A presentation can be written to many stream types. In the example below, we create a new presentation and save it to a file stream.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Simpan presentasi ke stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Simpan Presentasi dengan Tipe Tampilan yang Telah Ditetapkan**

Aspose.Slides lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) class. Use the [set_LastView](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/set_lastview/) method with a value from the [ViewType](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewtype/) enumeration.

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/) class and set its conformance property when saving. If you set `Conformance.Iso29500_2008_Strict`, the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Simpan presentasi dalam format Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

An Office Open XML file is a ZIP archive that imposes 4 GB (2^32 bytes) limits on the uncompressed size of any file, the compressed size of any file, and the total size of the archive, and it also limits the archive to 65,535 (2^16-1) files. ZIP64 format extensions raise these limits to 2^64.

The [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) method lets you choose when to use ZIP64 format extensions when saving an Office Open XML file.

This method can be used with the following modes:

- `IfNecessary` uses ZIP64 format extensions only if the presentation exceeds the limitations above. This is the default mode.
- `Never` never uses ZIP64 format extensions.
- `Always` always uses ZIP64 format extensions.

The following code demonstrates how to save a presentation as a PPTX file with ZIP64 format extensions enabled:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="CATATAN" color="warning" %}}
When you save with `Zip64Mode.Never`, a [PptxException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

When working with large presentations, you can adjust the compression level to balance file size and processing time. Depending on your requirements, you may prefer faster processing or smaller output files.

Aspose.Slides provides the [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) method, which allows you to specify the compression level used when saving a presentation in Office Open XML format.

The following compression levels are available:

- **None**: No compression is applied. Files are stored as-is.
- **Level1:** The fastest compression with the lowest compression ratio.
- **Level2:** Faster compression with a slightly better compression ratio than **Level1**.
- **Level3:** Provides better compression than **Level2** with a moderate impact on processing time.
- **Level4:** Provides better compression than **Level3**.
- **Level5:** Provides improved compression over **Level4** with additional processing time.
- **Level6:** Standard compression that offers a good balance between processing speed and file size. This is the *default compression level*.
- **Level7:** Provides better compression than **Level6** with slower processing.
- **Level8:** Provides better compression than **Level7**.
- **Level9:** Maximum compression. Produces the smallest file size at the cost of the longest processing time.

The following example demonstrates how to save a presentation as a PPTX file *without compression*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

This example shows how to save a presentation as a PPTX file with *maximum compression*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

The [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) method controls thumbnail generation when saving a presentation to PPTX:

- If set to `true`, the thumbnail is refreshed during save. This is the default.
- If set to `false`, the current thumbnail is preserved. If the presentation has no thumbnail, none is generated.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
This option helps reduce the time required to save a presentation in PPTX format.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

The [IProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/) interface is used via the `set_ProgressCallback` method exposed by the [ISaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isaveoptions/) interface and the abstract [SaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/) class. Assign an [IProgressCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iprogresscallback/) implementation with `set_ProgressCallback` to receive save-progress updates as a percentage.

The following code snippets show how to use `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Gunakan nilai persentase kemajuan di sini.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Kelas callback kemajuan yang didefinisikan di atas.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/id/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

No. Saving creates the full target file each time; incremental "fast save" isn’t supported.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

No. A [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) instance [isn’t thread-safe](/slides/id/cpp/multithreading/); save it from a single thread.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlinks](/slides/id/cpp/manage-hyperlinks/) are preserved. External linked files (e.g., videos via relative paths) aren’t copied automatically—ensure the referenced paths remain accessible.

**Apakah saya dapat mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Yes. Standard [document properties](/slides/id/cpp/presentation-properties/) are supported and will be written to the file on save.