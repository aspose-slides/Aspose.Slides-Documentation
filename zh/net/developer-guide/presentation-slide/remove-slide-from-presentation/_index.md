---
title: 从演示文稿中删除幻灯片
type: docs
weight: 30
url: /zh/net/remove-slide-from-presentation/
keywords: "删除幻灯片, 删除幻灯片, PowerPoint, 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "通过引用或索引在 C# 或 .NET 中从 PowerPoint 中删除幻灯片"

---

如果幻灯片（或其内容）变得多余，您可以将其删除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，该类封装了 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)，这是演示文稿中所有幻灯片的存储库。使用已知的 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 对象的指针（引用或索引），您可以指定要删除的幻灯片。

## **通过引用删除幻灯片**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其 ID 或索引获取要删除的幻灯片的引用。
1. 从演示文稿中删除引用的幻灯片。
1. 保存修改后的演示文稿。

以下 C# 代码演示了如何通过引用删除幻灯片：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // 通过其在幻灯片集合中的索引访问幻灯片
    ISlide slide = pres.Slides[0];

    // 通过其引用删除幻灯片
    pres.Slides.Remove(slide);

    // 保存修改后的演示文稿
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **通过索引删除幻灯片**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其索引位置从演示文稿中删除幻灯片。
1. 保存修改后的演示文稿。

以下 C# 代码演示了如何通过索引删除幻灯片：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // 通过其幻灯片索引删除幻灯片
    pres.Slides.RemoveAt(0);

    // 保存修改后的演示文稿
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **删除未使用的布局幻灯片**

Aspose.Slides 提供了 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类）允许您删除不需要和未使用的布局幻灯片。以下 C# 代码演示了如何从 PowerPoint 演示文稿中删除布局幻灯片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **删除未使用的母版幻灯片**

Aspose.Slides 提供了 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类）允许您删除不需要和未使用的母版幻灯片。以下 C# 代码演示了如何从 PowerPoint 演示文稿中删除母版幻灯片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```