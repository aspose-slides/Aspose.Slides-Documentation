---
title: 在 .NET 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/net/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存以获得可靠的结果。"
---

## **创建 PowerPoint 演示文稿**
要在演示文稿的选定幻灯片上添加一条简单的直线，请按以下步骤操作：

1. 创建 Presentation 类的实例。  
2. 通过其 Index 获取幻灯片的引用。  
3. 使用 Shapes 对象提供的 AddAutoShape 方法添加 Line 类型的 AutoShape。  
4. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。  
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 添加类型为线的 AutoShape
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **创建并保存演示文稿**

<a name="csharp-create-save-presentation"><strong>步骤：在 C# 中创建并保存演示文稿</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。  
2. 将 _Presentation_ 保存为 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 支持的任意格式。  
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **打开并保存演示文稿**

<a name="csharp-open-save-presentation"><strong>步骤：在 C# 中打开并保存演示文稿</strong></a>

1. 使用任意格式（如 PPT、PPTX、ODP 等）创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。  
2. 将 _Presentation_ 保存为 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 支持的任意格式。  
```c#
 // 加载 Presentation 中的任何受支持文件，例如 ppt、pptx、odp 等。
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **常见问题**

**我可以将新演示文稿保存为何种格式？**

您可以保存为 [PPTX, PPT, and ODP](/slides/zh/net/save-presentation/)，并可导出为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)、[SVG](/slides/zh/net/convert-powerpoint-to-png/) 和 [images](/slides/zh/net/convert-powerpoint-to-png/)，等等。

**我可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？**

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等类似格式 [are supported](/slides/zh/net/supported-file-formats/)。

**创建演示文稿时，如何控制幻灯片尺寸/宽高比？**

通过设置 [slide size](/slides/zh/net/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用何种单位？**

使用点 (point)：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的大型演示文稿以降低内存使用？**

使用 [BLOB management strategies](/slides/zh/net/manage-blob/)，通过使用临时文件限制内存中的存储，并优先使用基于文件的工作流而非纯内存流。

**我可以并行创建/保存演示文稿吗？**

不能在 [multiple threads](/slides/zh/net/multithreading/) 中操作同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

**如何去除试用版水印和限制？**

在每个进程中 [Apply a license](/slides/zh/net/licensing/) 一次。许可证 XML 必须保持未修改，如果有多个线程，许可证设置应同步。

**我可以对创建的 PPTX 进行数字签名吗？**

可以。支持演示文稿的 [Digital signatures](/slides/zh/net/digital-signature-in-powerpoint/)（添加和验证）。

**在创建的演示文稿中是否支持宏 (VBA)？**

可以。您可以 [create/edit VBA projects](/slides/zh/net/presentation-via-vba/) 并保存为宏启用文件，如 PPTM/PPSM。