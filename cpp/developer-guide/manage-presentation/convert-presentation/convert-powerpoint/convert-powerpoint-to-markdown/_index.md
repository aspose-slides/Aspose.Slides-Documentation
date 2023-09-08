---
title: Convert PowerPoint to Markdown in C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "Convert PowerPoint to Markdown, Convert ppt to md, PowerPoint, PPT, PPTX, Presentation, Markdown, C++, CPP, Aspose.Slides for C++"
description: "Convert PowerPoint to Markdown in C++"
---

{{% alert color="info" %}} 

Support for PowerPoint to markdown conversion was implemented in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint to markdown export is **without images** by default. If you want to export a PowerPoint document containing images, you need to set `SaveOptions::MarkdownExportType::Visual)` and also set the `BasePath` where the images referenced in the markdown document will be saved.

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class to represent a presentation object.
2. Use the [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)method to save the object as a markdown file.

This C++ code shows you how to convert PowerPoint to markdown: xxx

```c++

```

## Convert PowerPoint to Markdown Flavor

Aspose.Slides allows you to convert PowerPoint to markdown (containing basic syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, and 17 other markdown flavors.

This C++ code shows you how to convert PowerPoint to CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

The 23 supported markdown flavors are [listed under the Flavor enumeration](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) from the [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class.

## **Convert Presentation Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class provides properties and enumerations that allow you to use certain options or settings for the resulting markdown file. The [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum, for example, can be set to values that determine how images are rendered or handled: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

If you want the images to appear individually one after the other in the resulting markdown, you have to choose the sequential option. This C++ code shows you how to convert a presentation containing images to markdown: xxx

```c++

```

### **Convert Images Visually**

If you want the images to appear together in the resulting markdown, you have to choose the visual option.   In this case, images will be saved to the current directory of the application (and a relative path will be built for them in the markdown document), or you can specify your preferred path and folder name.

This C++ code demonstrates the operation: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);

```

