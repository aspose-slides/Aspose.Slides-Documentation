---
title: 将 PowerPoint 演示文稿转换为 C++ 的 Markdown
linktitle: PowerPoint 到 Markdown
type: docs
weight: 140
url: /zh/cpp/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 到 MD
- 演示文稿到 MD
- 幻灯片到 MD
- PPT 到 MD
- PPTX 到 MD
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
description: "使用 Aspose.Slides for C++ 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动生成文档并保留格式。"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 转换的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 markdown 的导出**不包含图像**。如果要导出包含图像的 PowerPoint 文档，需要将 `SaveOptions::MarkdownExportType::Visual)` 设置为相应值，并且还需设置 `BasePath`，用于保存 markdown 文档中引用的图像。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。  
2. 使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法将对象保存为 markdown 文件。

下面的 C++ 代码演示如何将 PowerPoint 转换为 markdown：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab，以及另外 17 种 markdown 变体。

以下 C++ 代码演示如何将 PowerPoint 转换为 CommonMark： 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


这 23 种支持的 markdown 变体列在 [Flavor 枚举](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，可从 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类获取。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，使您能够为生成的 markdown 文件使用特定的选项或设置。例如，枚举 [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 可设置为 `Sequential`、`TextOnly`、`Visual` 等值，以确定图像的呈现或处理方式。

### **顺序转换图像**

如果希望图像在生成的 markdown 中依次单独出现，需要选择顺序选项。以下 C++ 代码演示如何将包含图像的演示文稿转换为 markdown：
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

如果希望图像在生成的 markdown 中一起出现，需要选择视觉选项。此情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定自定义的路径和文件夹名称。

以下 C++ 代码演示该操作： 
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

**超链接在导出为 Markdown 时会保留吗？**

是的。文本[超链接](/slides/zh/cpp/manage-hyperlinks/)会保留为标准的 Markdown 链接。幻灯片[切换](/slides/zh/cpp/slide-transition/)和[动画](/slides/zh/cpp/powerpoint-animation/)不会被转换。

**我可以通过多线程运行来加速转换吗？**

您可以在文件之间并行处理，但不要在多个线程之间[共享](/slides/zh/cpp/multithreading/)同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例。每个文件使用单独的实例或进程，以避免竞争。

**图像会怎样——它们保存在哪里，路径是否为相对路径？**

[图像](/slides/zh/cpp/image/)会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。