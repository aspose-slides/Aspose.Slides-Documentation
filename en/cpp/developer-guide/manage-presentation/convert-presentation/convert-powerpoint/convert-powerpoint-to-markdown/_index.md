---
title: Convert PowerPoint Presentations to Markdown in C++
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to MD
- presentation to MD
- slide to MD
- PPT to MD
- PPTX to MD
- save PowerPoint as Markdown
- save presentation as Markdown
- save slide as Markdown
- save PPT as MD
- save PPTX as MD
- export PPT to MD
- export PPTX to MD
- Markdown image export
- CDN image links
- PowerPoint
- presentation
- Markdown
- C++
- Aspose.Slides
description: "Convert PPT and PPTX presentations to Markdown in C++ and control where exported bitmap, metafile, and SVG images are saved and referenced."
---

## **Overview**

Aspose.Slides for C++ can convert PPT and PPTX presentations to Markdown for documentation, static-site, content-migration, and version-control workflows. You can choose a Markdown flavor, control how slide content is rendered, and decide where exported images are stored and how the generated Markdown references them.

By default, Markdown export uses text-only output. To export visual content, set the [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) method to the `Sequential` or `Visual` value from the [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownexporttype/) enumeration. `Sequential` renders slide items separately and in order, whereas `Visual` keeps grouped items together to preserve their visual relationship. The `TextOnly` value does not emit image resources, so the image-saving events are not invoked in that mode.

## **Convert a Presentation to Markdown**

Load the source file with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class, and then call the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method with the `Md` value from the [SaveFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) enumeration.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Select a Markdown Flavor**

The [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) method controls the Markdown specification used for the output. The [Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.export/flavor/) enumeration includes CommonMark, GitHub Flavored Markdown, and other supported variants.

The following example exports a presentation as CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Control Repeated Spaces**

When preparing slide text for documentation, text processing, or publication, use [MarkdownSaveOptions::set_HandleRepeatedSpaces](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_handlerepeatedspaces/) to control consecutive regular spaces.

Single spaces remain regular spaces in all three modes. The following self-contained example creates text with one, two, and three consecutive spaces and exports the same slide using each mode.

```cpp
#include <DOM/AutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/Slide.h>
#include <DOM/TextFrame.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/HandleRepeatedSpaces.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 600, 100);
shape->get_TextFrame()->set_Text(u"One space; two  spaces; three   spaces.");

const HandleRepeatedSpaces modes[] =
{
    HandleRepeatedSpaces::None,
    HandleRepeatedSpaces::AlternateSpacesToNbsp,
    HandleRepeatedSpaces::MultipleSpacesToNbsp
};

const System::String outputPaths[] =
{
    u"spaces-None.md",
    u"spaces-AlternateSpacesToNbsp.md",
    u"spaces-MultipleSpacesToNbsp.md"
};

for (auto i = 0; i < 3; ++i)
{
    auto options = System::MakeObject<MarkdownSaveOptions>();
    options->set_Flavor(Flavor::CommonMark);
    options->set_HandleRepeatedSpaces(modes[i]);

    presentation->Save(outputPaths[i], SaveFormat::Md, options);
}
```

The exported text lines are shown below. These excerpts omit the slide separator and the two trailing spaces added by the exporter.

`None`:

```markdown
One space; two  spaces; three   spaces.
```

`AlternateSpacesToNbsp`:

```markdown
One space; two &nbsp;spaces; three &nbsp; spaces.
```

`MultipleSpacesToNbsp`:

```markdown
One space; two &nbsp;spaces; three &nbsp;&nbsp;spaces.
```

In a typical HTML-based Markdown viewer, consecutive regular spaces collapse visually even though they remain in the source. Both replacement modes preserve the visible spacing in this example; their source differs for the three-space sequence.

Choose `None` when downstream tools need ordinary space characters without HTML entities. Choose a replacement mode when visible spacing matters more. A text-processing pipeline consuming that output may need to decode `&nbsp;` and normalize the resulting nonbreaking spaces. Nonbreaking spaces also affect where a viewer can wrap text.

## **Remove Empty Lines**

The [MarkdownSaveOptions::set_RemoveEmptyLines](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_removeemptylines/) method controls whether empty or whitespace-only lines are removed during export. The default value is `false`. This controls vertical separation, independently of how repeated spaces within text are represented.

The following example creates two text paragraphs separated by an empty paragraph and a paragraph containing three regular spaces. It exports both settings. The `\r` characters create paragraph boundaries in the text frame; `HandleRepeatedSpaces::None` makes the treatment of ordinary spaces easier to inspect.

```cpp
#include <DOM/AutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/Slide.h>
#include <DOM/TextFrame.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/HandleRepeatedSpaces.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 600, 300);

// Include an empty paragraph and a paragraph containing three regular spaces.
shape->get_TextFrame()->set_Text(u"First paragraph.\r\r   \rSecond paragraph.");

auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);
options->set_HandleRepeatedSpaces(HandleRepeatedSpaces::None);
options->set_RemoveEmptyLines(false);

presentation->Save(u"empty-lines-kept.md", SaveFormat::Md, options);

options->set_RemoveEmptyLines(true);
presentation->Save(u"empty-lines-removed.md", SaveFormat::Md, options);
```

With `false`, the generated Markdown is:

```markdown
---  

First paragraph.  

&nbsp;
  
     
Second paragraph.  
```

With `true`, it becomes:

```markdown
---  

First paragraph.  
Second paragraph.  
```

With `RemoveEmptyLines = false`, the exported Markdown preserves the empty and whitespace-only paragraphs. The `&nbsp;` line represents an empty paragraph.

With `RemoveEmptyLines = true`, these blank paragraphs are removed. The two text paragraphs become a single Markdown paragraph with a line break between them. This line break is preserved by two trailing spaces after `First paragraph.`—Markdown syntax for a hard line break.

The slide separator (`---`) remains in both outputs. Keep `RemoveEmptyLines = false` when you need to preserve paragraph separation. If your presentation contains lists or code blocks, check the exported result in your target Markdown viewer, since blank lines can affect how that content is interpreted.

## **Export Images Using the Default Local-Saving Behavior**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/) class provides two methods for configuring locally saved images:

- [set_BasePath](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) specifies the base directory for the Markdown document and its resources.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) specifies the image subdirectory. Its default value is `Images`.

The following example renders visual content, writes images to `output/assets`, and creates relative image references in the Markdown document:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

This behavior also serves as the fallback when a custom image-saving handler returns `false`.

## **Customize Image Saving and Markdown Links**

Use the `MarkdownSaveOptions::ImageSaving` event for non-SVG bitmap and metafile resources emitted during Markdown export. Its [MarkdownImageSavingHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) delegate receives the [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) object, its [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), and the generated Markdown link as a `System::String&` parameter. Save or upload the image with the supplied format, and replace `link` with the reference that must appear in the Markdown output.

Resources emitted in SVG format are handled separately. Subscribe to the `MarkdownSaveOptions::SvgImageSaving` event, whose [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) delegate receives an [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) object and the `System::String& link` parameter. An SVG has no `ImageFormat` argument; write or upload its XML data from the [ISvgImage::get_SvgData](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/get_svgdata/) method instead. Depending on the export mode and visual grouping, an SVG in the source presentation can be rasterized or combined with other content; the resulting non-SVG resource is then passed to `ImageSaving`. Subscribe to both events when every exported visual resource requires custom processing.

The handler return value determines who processes the image:

- Return `true` after the handler has saved, uploaded, transformed, or otherwise processed the image and assigned a valid value to `link`. Aspose.Slides writes that value to the Markdown document and does not perform its default local save.
- Return `false` to let Aspose.Slides save the image locally and generate its link according to [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) and [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}

A handler that returns `true` takes responsibility for the image. If it returns `true` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.

{{% /alert %}}

### **Save Images to a CDN Origin Directory and Use External URLs**

The following example treats `cdn-origin/presentations/quarterly-report` as a mounted or synchronized CDN origin directory. Each handler extracts the generated file name, saves the image to that custom directory, and replaces the generated local reference with a public CDN URL. The sample itself performs no network upload: the URL becomes valid only after the directory is mounted as the CDN origin or its files are published to the CDN. For object storage, replace the file-system write with the storage SDK's upload operation and assign `link` only after the upload succeeds.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

The bitmap handler deliberately returns `false` for images smaller than 128 × 128 pixels, so Aspose.Slides saves those images to `output/fallback-images` using the default behavior. Larger bitmap and metafile resources, as well as SVG resources, are handled by the custom code. For example, a generated local reference such as `fallback-images/image1.png` becomes `https://cdn.example.com/presentations/quarterly-report/image1.png`. The handlers use operating-system paths only when writing files; links written to Markdown use forward slashes and URL-escaped file names. Apply the same rule when building relative links: use `/`, not the platform-specific directory separator.

## **FAQ**

**Can one handler process both raster images and SVG images?**

No. Use `MarkdownSaveOptions::ImageSaving` for emitted bitmap and metafile resources and `MarkdownSaveOptions::SvgImageSaving` for resources emitted as SVG. The former provides an [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) object and an [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/); the latter provides an [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) object whose SVG data can be read with [ISvgImage::get_SvgData](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/get_svgdata/). A source SVG that is rasterized during export is processed by `ImageSaving` instead.

**What happens when an image-saving handler returns `false`?**

Aspose.Slides uses its default local-saving behavior. The image location and generated reference are controlled by [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) and [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Can a handler provide a URL without saving the image locally?**

Yes. The handler can upload the image to object storage or pass it to another service, assign the resulting URL to `link`, and return `true`. The handler must complete the processing itself; returning `true` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

This exception occurs when the handler returns `true` but does not provide a valid link. Assign the relative path or external URL that should be written to Markdown before returning `true`.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `Path::Combine` only for file-system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/cpp/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/cpp/slide-transition/) and [animations](/slides/cpp/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/cpp/multithreading/) and use a separate instance for each file.
