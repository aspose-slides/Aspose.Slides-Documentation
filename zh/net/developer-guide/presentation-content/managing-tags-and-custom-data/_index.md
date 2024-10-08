---
title: 管理标签和自定义数据
type: docs
weight: 300
url: /zh/net/managing-tags-and-custom-data
keywords: "标签, 自定义数据, 标签值, 添加标签, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿添加标签和自定义数据"
---

## 演示文稿文件中的数据存储

PPTX 文件——具有 .pptx 扩展名的项目——以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中包含的数据的结构。

*幻灯片* 是演示文稿中的元素之一，*幻灯片部分* 包含单个幻灯片的内容。幻灯片部分可以与多个部分（例如用户定义的标签）具有明确的关系，按 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以作为标签（[ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)）存在。

{{% alert color="primary" %}} 

标签本质上是字符串键值对。 

{{% /alert %}} 

## 获取标签的值

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码展示了如何使用 Aspose.Slides for .NET 获取标签的值，针对 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## 向演示文稿添加标签

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两个项目组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对某些演示文稿进行分类，则可以通过向这些演示文稿添加标签来受益。例如，如果您想将所有来自北美国家的演示文稿分类或放在一起，您可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）作为值分配。

以下示例代码展示了如何使用 Aspose.Slides for .NET 向 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 添加标签：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

标签也可以为 [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) 设置：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

或者任何单独的 [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape)：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "我的文本";
    shape.CustomData.Tags["tag"] = "value";
}
```