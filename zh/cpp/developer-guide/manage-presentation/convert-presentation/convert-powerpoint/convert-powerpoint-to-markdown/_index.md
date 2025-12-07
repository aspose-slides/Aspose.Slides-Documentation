---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/cpp/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿转 MD
- 幻灯片转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动化文档编写并保持格式。"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现对 PowerPoint 转 markdown 的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 转 markdown 导出 **不包含图片**。如果要导出包含图片的 PowerPoint 文档，需要将 `SaveOptions::MarkdownExportType::Visual)` 设置为相应值，并且还要设置保存 markdown 文档中引用图片的 `BasePath`。

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。
2. 使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法将对象保存为 markdown 文件。

以下 C++ 代码演示了如何将 PowerPoint 转换为 markdown：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides 允许将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格 markdown、Trello、XWiki、GitLab 等 17 种其他 markdown 风格。

以下 C++ 代码演示了如何将 PowerPoint 转换为 CommonMark：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


受支持的 23 种 markdown 风格列在 [Flavor 枚举](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，可通过 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类使用。

## **Convert a Presentation Containing Images to Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许为生成的 markdown 文件使用特定选项或设置。例如，可将 [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举设置为决定图片呈现或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **Convert Images Sequentially**

如果希望图片在生成的 markdown 中逐个依次出现，需要选择 sequential 选项。以下 C++ 代码演示了如何将包含图片的演示文稿转换为 markdown：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```


### **Convert Images Visually**

如果希望图片在生成的 markdown 中一起出现，需要选择 visual 选项。在这种情况下，图片将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），或者您可以指定首选的路径和文件夹名称。

以下 C++ 代码演示了该操作：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **FAQ**

**Do hyperlinks survive the export to Markdown?**

是的。文本 [hyperlinks](/slides/zh/cpp/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/cpp/slide-transition/) 和 [animations](/slides/zh/cpp/powerpoint-animation/) 不会被转换。

**Can I speed up conversion by running it in multiple threads?**

您可以对文件进行并行处理，但请勿在多个线程间共享同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例。每个文件使用单独的实例或进程，以避免争用。

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/zh/cpp/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。