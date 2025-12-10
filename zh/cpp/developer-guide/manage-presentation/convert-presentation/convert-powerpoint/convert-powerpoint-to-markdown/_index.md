---
title: 使用 C++ 将 PowerPoint 演示文稿转换为 Markdown
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
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
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
已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 转换的支持。
{{% /alert %}} 

{{% alert color="warning" %}} 
默认情况下，PowerPoint 到 markdown 的导出 **不包含图像**。如果需要导出包含图像的 PowerPoint 文档，必须将 `SaveOptions::MarkdownExportType::Visual)` 设置为相应值，并且还要设置 `BasePath`，用于保存 markdown 文档中引用的图像。
{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。
2. 使用 [保存 ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)方法 将对象保存为 markdown 文件。

此 C++ 代码演示如何将 PowerPoint 转换为 markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 以及其他 17 种 markdown 变体。

此 C++ 代码演示如何将 PowerPoint 转换为 CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


这 23 种受支持的 markdown 变体列在 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类的 [Flavor 枚举](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 下。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为决定图像渲染或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个依次出现，则必须选择顺序选项。此 C++ 代码演示如何将包含图像的演示文稿转换为 markdown:
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

如果希望图像在生成的 markdown 中一起出现，则必须选择视觉选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定首选的路径和文件夹名称。

此 C++ 代码演示该操作: 
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

**超链接在导出为 Markdown 时会保留下来吗？**

是。文本 [超链接](/slides/zh/cpp/manage-hyperlinks/) 会被保留为标准的 Markdown 链接。幻灯片 [切换](/slides/zh/cpp/slide-transition/) 和 [动画](/slides/zh/cpp/powerpoint-animation/) 则不会被转换。

**我能通过多线程运行来加速转换吗？**

您可以对文件进行并行处理，但 [不要共享](/slides/zh/cpp/multithreading/) 同一 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例跨线程使用。每个文件使用单独的实例/进程以避免竞争。

**图像会怎样——它们保存在哪里，路径是否为相对路径？**

[图像](/slides/zh/cpp/image/) 会导出到专用文件夹，默认情况下，Markdown 文件会使用相对路径引用它们。您可以配置基础输出路径和资产文件夹名称，以保持可预测的仓库结构。