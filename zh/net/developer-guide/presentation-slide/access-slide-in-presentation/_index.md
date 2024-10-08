---
title: 在演示文稿中访问幻灯片
type: docs
weight: 20
url: /zh/net/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿，访问幻灯片，编辑幻灯片属性，改变幻灯片位置，设置幻灯片编号，索引，ID，位置 C#，Csharp，.NET，Aspose.Slides"
description: "通过索引、ID 或位置在 C# 或 .NET 中访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您通过索引和 ID 以两种方式访问幻灯片。

## **通过索引访问幻灯片**

演示文稿中的所有幻灯片按幻灯片位置的数字顺序排列，从 0 开始。第一张幻灯片通过索引 0 访问；第二张幻灯片通过索引 1 访问；以此类推。

表示演示文稿文件的 Presentation 类将所有幻灯片公开为 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 集合（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 对象的集合）。以下 C# 代码向您展示了如何通过索引访问幻灯片：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("AccessSlides.pptx");

// 通过索引获取幻灯片的引用
ISlide slide = presentation.Slides[0];
```

## **通过 ID 访问幻灯片**

演示文稿中的每个幻灯片都有一个唯一的 ID 与之关联。您可以使用 [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) 方法（由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类公开）来定位该 ID。以下 C# 代码向您展示了如何提供有效的幻灯片 ID，并通过 [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) 方法访问该幻灯片：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("AccessSlides.pptx");

// 获取幻灯片 ID
uint id = presentation.Slides[0].SlideId;

// 通过 ID 访问幻灯片
IBaseSlide slide = presentation.GetSlideById(id);
```

## **改变幻灯片位置**
Aspose.Slides 允许您改变幻灯片位置。例如，您可以指定第一张幻灯片变成第二张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取要改变位置的幻灯片的引用。
1. 通过 [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) 属性为幻灯片设置新位置。
1. 保存修改后的演示文稿。

以下 C# 代码演示了将位置为 1 的幻灯片移动到位置 2 的操作：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 获取将被改变位置的幻灯片
    ISlide sld = pres.Slides[0];

    // 为幻灯片设置新位置
    sld.SlideNumber = 2;

    // 保存修改后的演示文稿
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

第一张幻灯片变成了第二张；第二张幻灯片变成了第一张。当您改变幻灯片的位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**
使用 [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) 属性（由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类公开），您可以为演示文稿中的第一张幻灯片指定一个新编号。此操作会导致其他幻灯片编号被重新计算。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 获取幻灯片编号。
1. 设置幻灯片编号。
1. 保存修改后的演示文稿。

以下 C# 代码演示了将第一张幻灯片编号设置为 10 的操作：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // 获取幻灯片编号
    int firstSlideNumber = presentation.FirstSlideNumber;

    // 设置幻灯片编号
    presentation.FirstSlideNumber=10;
    
    // 保存修改后的演示文稿
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

如果您希望跳过第一张幻灯片，可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号），可以这样做：

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 设置第一张演示文稿幻灯片的编号
    presentation.FirstSlideNumber = 0;

    // 显示所有幻灯片的编号
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // 隐藏第一张幻灯片的编号
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // 保存修改后的演示文稿
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```