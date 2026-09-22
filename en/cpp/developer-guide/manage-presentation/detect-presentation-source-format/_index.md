---
title: Determine the Original Presentation Format in C++
linktitle: Source Format
type: docs
weight: 35
url: /cpp/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Read the original format of a loaded presentation in C++ with Aspose.Slides for C++, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, call [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sourceformat/) to determine its original format. The method is also available through [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_sourceformat/). Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sourceformat/), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/sourceformat/) enumeration distinguishes the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Read the Source Format of a Stream**

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) constructor receives only the stream.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat::Ppt`; the PPS example above reports `Ppt`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) and [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_loadformat/) when you need to inspect a file before loading its complete presentation object model. Use [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sourceformat/) when the instance already exists.

This example requires `sample.pptx` and prints `Pptx` for both checks. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

The results have different enumeration types: [LoadFormat](https://reference.aspose.com/slides/cpp/aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/sourceformat/). Do not compare them by casting their numeric values or assume that every format has identical detection results. PowerPoint XML can be reported as `LoadFormat::Unknown` before loading and `SourceFormat::Xml` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints `Pptx` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

A presentation created from scratch with `MakeObject<Presentation>()` reports `SourceFormat::Pptx`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `Pps`, while loading the same bytes without a filename reports `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

The following table summarizes source-format identification for presentations with matching extensions:

| Saved format | SourceFormat from a file path | SourceFormat from a nameless stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Legacy PPS/POT content is normalized to `Ppt` for nameless streams. The table describes format identification, not preservation of every presentation feature during conversion.

## **FAQ**

**Does saving to ODP change the source format of a presentation loaded from PPTX?**

No. The existing instance still reports `Pptx`. An instance loaded from the saved ODP file reports `Odp`.

**Can a stream always distinguish a legacy presentation, slide show, and template?**

No. PPT, PPS, and POT share the binary format. Keep filename or subtype metadata separately when that distinction is required.

**Which API should I use if the presentation is already loaded?**

Read [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sourceformat/). Use [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) for inspection before loading.
