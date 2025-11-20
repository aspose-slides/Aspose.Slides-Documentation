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
description: "Discover how to save presentations in C++ using Aspose.Slides—export to PowerPoint or OpenDocument while retaining layouts, fonts and effects."
---

## **Overview**

[Open Presentations in C++](/slides/cpp/open-presentation/) described how to use the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class to open a presentation. This article explains how to create and save presentations. The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class contains a presentation’s contents. Whether you’re creating a presentation from scratch or modifying an existing one, you’ll want to save it when you’re finished. With Aspose.Slides for C++, you can save to a **file** or **stream**. This article explains the different ways to save a presentation.

## **Save Presentations to Files**

Save a presentation to a file by calling the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class’s `Save` method. Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides.

```cpp
// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>();

// Do some work here...

// Save the presentation to a file.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Save Presentations to Streams**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class’s `Save` method. A presentation can be written to many stream types. In the example below, we create a new presentation and save it to a file stream.

```cpp
// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Save Presentations with a Predefined View Type**

Aspose.Slides lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) class. Use the [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) method with a value from the [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) enumeration.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) class and set its conformance property when saving. If you set `Conformance.Iso29500_2008_Strict`, the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>();

// Save the presentation in the Strict Office Open XML format.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

An Office Open XML file is a ZIP archive that imposes 4 GB (2^32 bytes) limits on the uncompressed size of any file, the compressed size of any file, and the total size of the archive, and it also limits the archive to 65,535 (2^16-1) files. ZIP64 format extensions raise these limits to 2^64.

The [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) method lets you choose when to use ZIP64 format extensions when saving an Office Open XML file.

This method can be used with the following modes:

- `IfNecessary` uses ZIP64 format extensions only if the presentation exceeds the limitations above. This is the default mode.
- `Never` never uses ZIP64 format extensions.
- `Always` always uses ZIP64 format extensions.

The following code demonstrates how to save a presentation as PPTX with ZIP64 format extensions enabled:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

When you save with `Zip64Mode.Never`, a [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.

{{% /alert %}}

## **Save Presentations without Refreshing the Thumbnail**

The [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) method controls thumbnail generation when saving a presentation to PPTX:

- If set to `true`, the thumbnail is refreshed during save. This is the default.
- If set to `false`, the current thumbnail is preserved. If the presentation has no thumbnail, none is generated.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

This option helps reduce the time required to save a presentation in PPTX format.

{{% /alert %}}

## **Save Progress Updates in Percentage**

The [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) interface is used via the `set_ProgressCallback` method exposed by the [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) interface and the abstract [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) class. Assign an [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) implementation with `set_ProgressCallback` to receive save-progress updates as a percentage.

The following code snippets show how to use `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Use the progress percentage value here.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.

{{% /alert %}}
