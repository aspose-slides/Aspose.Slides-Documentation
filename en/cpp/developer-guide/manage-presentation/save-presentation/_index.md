---
title: Save Presentations in C++
linktitle: Save Presentation
type: docs
weight: 80
url: /cpp/save-presentation/
keywords:
- save PowerPoint
- save OpenDocument
- save presentation
- save slide
- save PPT
- save PPTX
- save ODP
- presentation to file
- presentation to stream
- predefined view type
- Strict Office Open XML Format
- Zip64 mode
- refreshing thumbnail
- saving progress
- C++
- Aspose.Slides
description: "Save PowerPoint and OpenDocument presentations to files or streams in C++ with Aspose.Slides, and configure PPTX output and progress reporting."
---

## **Overview**

After you create a presentation or [open an existing one](/slides/cpp/open-presentation/), use the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method to write the result. Aspose.Slides for C++ can save a presentation to a file or stream in PowerPoint, OpenDocument, PDF, and other formats. The following sections cover the standard save operations and the options available for PPTX output.

## **Save Presentations to Files**

To save a presentation to a file, pass the output path and a [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) value to the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method. The format value determines the type of file that Aspose.Slides creates.

The following example creates a presentation and saves it as a PPTX file:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Add or modify presentation content here.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Save Presentations in Their Original Format**

In a batch-processing application, the input format may not be known in advance. After loading a file, read its original format with [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_sourceformat/). Pass the resulting [SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/sourceformat/) value to [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/tosaveformat/) to obtain the corresponding [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) value, and then use [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) to write the modified presentation.

The following complete example processes every file in an input directory, updates its title, and saves it to an output directory in the format from which it was loaded:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/tosaveformat/) maps PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, and PowerPoint XML to their corresponding presentation save formats. It maps presentation source formats only; it is not intended to select export formats such as PDF, HTML, TIFF, or images. Passing an unsupported or invalid [SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/sourceformat/) value results in an [ArgumentException](https://reference.aspose.com/slides/cpp/system/argumentexception/).

Legacy PPT, PPS, and POT files use the same binary container. When such a presentation is loaded from a stream without a file extension, a PPS or POT file may therefore be identified as PPT. If preserving these legacy subtypes is required, retain the original filename or format metadata separately and use it when choosing the output filename and format.

## **Save Presentations to Streams**

To write a presentation without relying on a final file path, pass a writable [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) and a [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) value to the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method. This approach is useful when the output must be returned from a web service, stored in a database, or processed in memory.

The following example saves a new presentation to a file stream:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Save Presentations with a Predefined View Type**

You can specify the view in which PowerPoint initially opens a saved presentation. Call [ViewProperties::set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) with a [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) value before saving.

The following example configures Slide Master view as the initial view:

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

## **Save Presentations in the Strict Office Open XML Format**

To create a PPTX file that conforms to the Strict profile of Office Open XML, create a [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) instance and call [PptxOptions::set_Conformance](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_conformance/) with `Conformance::Iso29500_2008_Strict`. Then pass the options to the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method.

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

A standard ZIP archive limits the compressed and uncompressed size of each entry, the total archive size, and the number of entries. Because a PPTX file is a ZIP archive, a very large presentation can exceed those limits. ZIP64 extensions raise the applicable size and entry-count limits.

Use [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) to control whether Aspose.Slides writes ZIP64 extensions:

- `IfNecessary` uses ZIP64 only when the presentation exceeds standard ZIP limits. This is the default mode.
- `Never` disables ZIP64 extensions.
- `Always` always writes ZIP64 extensions.

The following example always enables ZIP64 extensions for the output presentation:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}

If `Zip64Mode` is set to `Never` and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/).

{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

For PPTX output, you can balance saving speed against file size by calling [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). The [CompressionLevel](https://reference.aspose.com/slides/cpp/aspose.slides.export/compressionlevel/) enumeration provides these values:

- `None` stores data without compression.
- `Level1` provides the fastest compression and the largest compressed output.
- `Level2` through `Level5` progressively favor smaller output over saving speed.
- `Level6` balances saving speed and file size. This is the default level.
- `Level7` and `Level8` further favor smaller output over saving speed.
- `Level9` provides the strongest compression and requires the most processing time.

The following example saves a presentation without compression:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

The following example uses the maximum compression level:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Save Presentations without Refreshing the Thumbnail**

When a presentation is saved as PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controls its document thumbnail:

- `true` regenerates the thumbnail during the save operation. This is the default value.
- `false` preserves the existing thumbnail. If the presentation has no thumbnail, Aspose.Slides does not generate one.

The following example saves a presentation without refreshing its thumbnail:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Disabling thumbnail refresh can reduce the time required to save a PPTX file.

{{% /alert %}}

## **Save Progress Updates in Percentage**

To monitor a save operation, implement the [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) interface and pass the implementation to [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides then calls [IProgressCallback::Reporting](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/reporting/) with progress values during the export.

The following example reports the progress of a PDF export to the console:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.

{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support incremental or “fast save”?**

No. Each save operation writes a complete output file rather than updating only the changed parts.

**Can multiple threads save the same Presentation instance?**

No. A [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance [is not thread-safe](/slides/cpp/multithreading/). Access and save each instance from only one thread at a time.

**What happens to hyperlinks and externally linked files when I save a presentation?**

[Hyperlinks](/slides/cpp/manage-hyperlinks/) remain in the presentation. Aspose.Slides does not copy externally linked files, so the saved presentation must still be able to access their locations.

**Can I save document metadata such as the author, title, company, and creation date?**

Yes. Set the appropriate [document properties](/slides/cpp/presentation-properties/) before saving, and Aspose.Slides writes them to the output file.
