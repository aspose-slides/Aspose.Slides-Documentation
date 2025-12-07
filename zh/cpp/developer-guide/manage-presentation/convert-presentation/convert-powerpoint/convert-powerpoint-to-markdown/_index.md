---
title: 将 PowerPoint 演示文稿转换为 C++ 的 Markdown
linktitle: PowerPoint 到 Markdown
type: docs
weight: 140
url: /zh/cpp/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将 演示文稿 保存为 Markdown
- 将 幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动化文档并保持格式。"
---

{{% alert color="info" %}} 

对 PowerPoint 到 markdown 转换的支持已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 markdown 的导出 **不包含图像**。如果要导出包含图像的 PowerPoint 文档，需要将 `SaveOptions::MarkdownExportType::Visual)` 设置为相应值，并且还需要设置 `BasePath`，以便在 markdown 文档中引用的图像能够保存到指定路径。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个表示演示文稿对象的 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类实例。  
2. 使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法将对象保存为 markdown 文件。

下面的 C++ 代码演示了如何将 PowerPoint 转换为 markdown：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **将 PowerPoint 转换为 Markdown Flavor**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格 markdown、Trello、XWiki、GitLab 以及其他 17 种 markdown 风格。

下面的 C++ 代码演示了如何将 PowerPoint 转换为 CommonMark：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


23 种受支持的 markdown 风格可在 [Flavor 枚举](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中查看，位于 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类下。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，`MarkdownExportType` 枚举可以设置为 `Sequential`、`TextOnly`、`Visual` 等值，以决定图像的渲染或处理方式。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个顺序出现，需要选择 `Sequential` 选项。以下 C++ 代码演示了如何将包含图像的演示文稿转换为 markdown：
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


### **可视化转换图像**

如果希望图像在生成的 markdown 中一起显示，需要选择 `Visual` 选项。此情况下，图像将保存到应用程序的当前目录（在 markdown 文档中会为其构建相对路径），也可以指定自定义的路径和文件夹名称。

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

**导出到 Markdown 时超链接会保留吗？**

会。文本 [hyperlinks](/slides/zh/cpp/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/cpp/slide-transition/) 和 [animations](/slides/zh/cpp/powerpoint-animation/) 不会被转换。

**能否通过多线程运行来加速转换？**

可以对文件进行并行处理，但请 **不要在多个线程之间共享** 同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例。每个文件使用单独的实例或进程以避免竞争。

**图像会怎样处理——保存在哪里，路径是相对的吗？**

[Images](/slides/zh/cpp/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持仓库结构的可预测性。