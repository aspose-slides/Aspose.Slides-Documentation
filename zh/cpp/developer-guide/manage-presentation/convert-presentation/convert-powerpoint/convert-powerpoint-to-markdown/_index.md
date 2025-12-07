---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/cpp/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 Markdown
- 演示文稿 转 Markdown
- 幻灯片 转 Markdown
- PPT 转 Markdown
- PPTX 转 Markdown
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 Markdown
- 将 PPTX 保存为 Markdown
- 导出 PPT 为 Markdown
- 导出 PPTX 为 Markdown
- PowerPoint
- 演示文稿
- Markdown
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 幻灯片（PPT、PPTX）转换为简洁的 Markdown，实现文档自动化并保持格式。"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 的转换支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 的导出默认 **不包含图像**。如果想导出包含图像的 PowerPoint 文档，需要将 `SaveOptions::MarkdownExportType::Visual)` 设置为相应值，并且还需设置 `BasePath`，以指定 markdown 文档中引用的图像保存位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。
2. 使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法将对象保存为 markdown 文件。

以下 C++ 代码演示了如何将 PowerPoint 转换为 markdown：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 等 17 种其他 markdown 变体。

以下 C++ 代码演示了如何将 Powerpoint 转换为 CommonMark： 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


这 23 种受支持的 markdown 变体列在 [Flavor 枚举](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，来源于 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定的选项或设置。例如，[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可设置为决定图像渲染或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果您希望图像在生成的 markdown 中一个接一个地单独出现，需要选择 sequential 选项。以下 C++ 代码演示了如何将包含图像的演示文稿转换为 markdown：
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


### **视觉转换图像**

如果您希望图像在生成的 markdown 中一起出现，需要选择 visual 选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），或者您可以指定所需的路径和文件夹名称。

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


## **常见问题**

**超链接在导出为 Markdown 时会保留吗？**

会。文本 [hyperlinks](/slides/zh/cpp/manage-hyperlinks/) 将保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/cpp/slide-transition/) 和 [animations](/slides/zh/cpp/powerpoint-animation/) 不会被转换。

**我可以通过多线程运行来加速转换吗？**

您可以在文件之间并行处理，但不要在多个线程中共享同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例（[don’t share](/slides/zh/cpp/multithreading/)）。请为每个文件使用独立的实例或进程，以避免竞争。

**图像会怎样处理——保存在哪里，路径是否为相对路径？**

[Images](/slides/zh/cpp/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。