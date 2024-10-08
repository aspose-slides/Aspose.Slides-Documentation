---
title: 将 PowerPoint 转换为 Markdown 在 C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, C++, CPP, Aspose.Slides for C++"
description: "将 PowerPoint 转换为 Markdown 在 C++"
---

{{% alert color="info" %}} 

支持将 PowerPoint 转换为 Markdown 的功能已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) 中实现。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 Markdown 导出 **不包含图像**。如果您想导出包含图像的 PowerPoint 文档，则需要设置 `SaveOptions::MarkdownExportType::Visual)`，并且还需要设置将保持在 Markdown 文档中的图像保存的 `BasePath`。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。
2. 使用 [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法将对象保存为 Markdown 文件。

以下 C++ 代码演示了如何将 PowerPoint 转换为 Markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## 将 PowerPoint 转换为 Markdown 风格

Aspose.Slides 允许您将 PowerPoint 转换为包含基本语法的 Markdown、CommonMark、GitHub 风格的 Markdown、Trello、XWiki、GitLab 和其他 17 种 Markdown 风格。

以下 C++ 代码演示了如何将 PowerPoint 转换为 CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

支持的 23 种 Markdown 风格 [在 Flavor 枚举下列出](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供了允许您为生成的 Markdown 文件使用某些选项或设置的属性和枚举。例如，[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为决定图像如何呈现或处理的值：`Sequential`，`TextOnly`，`Visual`。

### **顺序转换图像**

如果您希望图像在生成的 Markdown 中一个接一个地单独出现，则必须选择顺序选项。以下 C++ 代码演示了如何将包含图像的演示文稿转换为 Markdown:

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

如果您希望图像在生成的 Markdown 中一起出现，则必须选择视觉选项。在这种情况下，图像将保存到应用程序的当前目录（并将在 Markdown 文档中为它们构建相对路径），或者您可以指定首选路径和文件夹名称。

以下 C++ 代码演示了该操作: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```