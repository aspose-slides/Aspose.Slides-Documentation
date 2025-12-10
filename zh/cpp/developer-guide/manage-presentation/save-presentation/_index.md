---
title: 在 C++ 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/cpp/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿到文件
- 演示文稿到流
- 预定义视图类型
- Strict Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---

## **概述**

[在 C++ 中打开演示文稿](/slides/zh/cpp/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for C++，您可以保存到 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的 `Save` 方法并传入文件名和保存格式即可将演示文稿保存到文件。下面的示例演示了如何使用 Aspose.Slides 保存演示文稿。
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 在此执行一些操作...
// 将演示文稿保存到文件。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的 `Save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例创建一个新演示文稿并将其保存到文件流。
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// 将演示文稿保存到流。
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) 类设置 PowerPoint 打开生成的演示文稿时的初始视图。使用来自 [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) 枚举的值调用 `set_LastView` 方法。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **以 Strict Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) 类并在保存时设置其 `Conformance` 属性。如果将其设置为 `Conformance.Iso29500_2008_Strict`，输出文件将以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存。
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 将演示文稿以 Strict Office Open XML 格式保存。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 档案，对任何文件的未压缩大小、压缩大小以及整个档案的总大小都有 4 GB (2^32 字节) 的限制，并且档案中最多只能包含 65 535 (2^16‑1) 个文件。ZIP64 格式扩展将这些限制提升到 2^64。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 方法让您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

该方法可配合以下模式使用：

- `IfNecessary` 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- `Never` 从不使用 ZIP64 格式扩展。
- `Always` 始终使用 ZIP64 格式扩展。

下面的代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX：
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
当使用 `Zip64Mode.Never` 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **保存演示文稿时不刷新缩略图**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 方法控制将演示文稿保存为 PPTX 时是否生成缩略图：

- 设置为 `true` 时，保存过程中会刷新缩略图。这是默认设置。
- 设置为 `false` 时，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将演示文稿保存为 PPTX 并且不刷新其缩略图。
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
此选项有助于减少以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式更新保存进度**

[IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) 接口公开的 `set_ProgressCallback` 方法以及抽象的 [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) 类使用。使用 `set_ProgressCallback` 传入 [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) 实现即可在保存时以百分比形式接收进度更新。

下面的代码片段展示了如何使用 `IProgressCallback`。
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // 在此使用进度百分比值。
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
Aspose 开发了一个使用其 API 的 [免费 PowerPoint 拆分器应用](https://products.aspose.app/slides/splitter)。该应用可通过将选定的幻灯片另存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存），仅写入更改的部分？**

不支持。每次保存都会重新创建完整的目标文件，未实现增量“快速保存”。

**从多个线程同时保存同一 Presentation 实例是否安全？**

不安全。`Presentation` 实例 **不是线程安全**的；请在单个线程中进行保存。

**保存时超链接和外部链接文件会怎样处理？**

[超链接](/slides/zh/cpp/manage-hyperlinks/) 会被保留。外部链接的文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径仍然可访问。

**是否可以设置/保存文档元数据（作者、标题、公司、日期）？**

可以。标准的[文档属性](/slides/zh/cpp/presentation-properties/)受到支持，保存时会写入文件中。