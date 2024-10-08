---
title: 在 .NET 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/net/create-presentation/
keywords: "创建 PowerPoint, PPTX, PPT, 创建演示文稿, 初始化演示文稿, C#, .NET"
description: "以编程方式在 C# 中创建 PowerPoint 演示文稿，例如 PPT, PPTX, ODP 等。"
---

## 创建 PowerPoint 演示文稿
要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

1. 创建一个 Presentation 类的实例。
1. 通过使用幻灯片的索引获取幻灯片的引用。
1. 使用 Shapes 对象公开的 AddAutoShape 方法添加一个线型的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 添加一个类型为线的自动形状
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## 创建并保存演示文稿

<a name="csharp-create-save-presentation"><strong>步骤：在 C# 中创建并保存演示文稿</strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将 _Presentation_ 保存为任何 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 支持的格式。

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## 打开并保存演示文稿

<a name="csharp-open-save-presentation"><strong>步骤：在 C# 中打开并保存演示文稿</strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例，使用任何格式，例如 PPT, PPTX, ODP 等。
2. 将 _Presentation_ 保存为任何 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 支持的格式。

```c#
// 在演示文稿中加载任何受支持的文件，例如 ppt, pptx, odp 等。
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```