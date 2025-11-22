---
title: 在演示文稿中访问幻灯片
type: docs
weight: 20
url: /zh/net/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿, 访问幻灯片, 编辑幻灯片属性, 更改幻灯片位置, 设置幻灯片编号, 索引, ID, 位置, C#, Csharp, .NET, Aspose.Slides"
description: "通过 C# 或 .NET 按索引、ID 或位置访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您以两种方式访问幻灯片：按索引和按 ID。

## **按索引访问幻灯片**

演示文稿中的所有幻灯片按幻灯片位置从 0 开始以数字顺序排列。第一张幻灯片可通过索引 0 访问；第二张幻灯片可通过索引 1 访问；等等。

代表演示文稿文件的 Presentation 类将所有幻灯片公开为 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 集合（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 对象的集合）。下面的 C# 代码展示了如何通过索引访问幻灯片：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("AccessSlides.pptx");

// 通过索引获取幻灯片的引用
ISlide slide = presentation.Slides[0];
```


## **按 ID 访问幻灯片**

演示文稿中的每张幻灯片都有唯一的 ID 关联。您可以使用 [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) 方法（由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类公开）来定位该 ID。下面的 C# 代码展示了如何提供有效的幻灯片 ID 并通过 [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) 方法访问该幻灯片：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("AccessSlides.pptx");

// 获取幻灯片 ID
uint id = presentation.Slides[0].SlideId;

// 通过 ID 访问幻灯片
IBaseSlide slide = presentation.GetSlideById(id);
```


## **更改幻灯片位置**

Aspose.Slides 允许您更改幻灯片的位置。例如，您可以指定将第一张幻灯片变为第二张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取要更改位置的幻灯片引用。
3. 通过 [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) 属性为幻灯片设置新位置。
4. 保存修改后的演示文稿。

下面的 C# 代码演示了将位置 1 的幻灯片移动到位置 2 的操作：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 获取将要更改位置的幻灯片
    ISlide sld = pres.Slides[0];

    // 设置幻灯片的新位置
    sld.SlideNumber = 2;

    // 保存修改后的演示文稿
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


第一张幻灯片变成了第二张；第二张幻灯片变成了第一张。当您更改幻灯片的位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

使用由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类公开的 [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) 属性，您可以为演示文稿的第一张幻灯片指定新的编号。此操作会重新计算其他幻灯片的编号。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 获取幻灯片编号。
3. 设置幻灯片编号。
4. 保存修改后的演示文稿。

下面的 C# 代码展示了将第一张幻灯片编号设置为 10 的操作：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
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


如果您想跳过第一张幻灯片，可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号），方式如下：
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 为演示文稿的第一张幻灯片设置编号
    presentation.FirstSlideNumber = 0;

    // 显示所有幻灯片的幻灯片编号
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // 隐藏第一张幻灯片的编号
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // 保存修改后的演示文稿
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**用户看到的幻灯片编号是否与集合的零基索引匹配？**

幻灯片上显示的编号可以从任意值（例如 10）开始，并且不必与索引匹配；其关系由演示文稿的 [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) 设置控制。

**隐藏的幻灯片会影响索引吗？**

是的。隐藏的幻灯片仍然保留在集合中并计入索引；“隐藏”指的是显示状态，而不是它在集合中的位置。

**当添加或删除其他幻灯片时，幻灯片的索引会改变吗？**

是的。索引始终反映幻灯片的当前顺序，并在插入、删除和移动操作后重新计算。