---
title: 使用 C++ 在演示文稿中管理标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/cpp/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---

## **演示文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项——存储在 PresentationML 格式中，它是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*slide*（幻灯片）是其中的一个元素，*slide part*（幻灯片部件）包含单个幻灯片的内容。幻灯片部件可以与许多部件建立显式关系——例如 ISO/IEC 29500 定义的用户定义标签（User Defined Tags）。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串‑键对值。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码演示如何使用 Aspose.Slides for C++ 获取 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 的标签值：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **向演示文稿添加标签**

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对一些演示文稿进行分类，那么向这些演示文稿添加标签可能会有所帮助。例如，如果您想将所有来自北美国家的演示文稿归类在一起，可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）设为其值。

以下示例代码演示如何使用 Aspose.Slides for C++ 向 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 添加标签：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


标签也可以针对 [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/) 设置：
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


或者针对任意单个 [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/)：
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

是的。[tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键‑值对。

**如何在不遍历整个集合的情况下，仅通过标签名称删除单个标签？**

在 [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) 操作即可通过键删除该标签。

**如何获取完整的标签名称列表以用于分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/)；它返回所有标签名称的数组。