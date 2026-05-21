---
title: 使用 C++ 管理演示文稿中的标签和自定义数据
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
description: "了解如何在 Aspose.Slides for C++ 中添加、读取、更新和删除标签及自定义数据，示例针对 PowerPoint 和 OpenDocument 演示文稿。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。简要概述了数据在 PPTX 文件中的存储方式，指出演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

它还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。此外，本文还涵盖了常见的标签管理任务，如清除所有标签、按名称删除标签以及检索标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件——即扩展名为 .pptx 的文件——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式地与许多部件建立关系——例如用户定义的标签——这些关系由 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itagcollection/)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在 Slides 中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码演示了如何使用 Aspose.Slides for C++ 获取 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 中标签的值：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **向演示文稿添加标签**

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag`  
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对某些演示文稿进行分类，则可以通过添加标签来实现。例如，若想将所有北美国家的演示文稿归为一类，可以创建一个 “North American” 标签，并将相关国家（美国、墨西哥和加拿大）设为其值。

以下示例代码展示了如何使用 Aspose.Slides for C++ 向 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 添加标签：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

标签也可以针对 [Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/) 设置：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

或针对任意单个 [Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/)：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **限制**

通过 `get_CustomData()->get_Tags()` 的自定义数据标签集合添加的标签仅存储在 PowerPoint 文件内部。导出为 PDF 时，这些标签 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如，`shape->set_AlternativeText(u"MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。 [标签集合](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅凭名称删除单个标签？**

使用 [TagCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 的 [Remove(name)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/remove/) 操作即可按键删除标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

在 [标签集合](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 上调用 [GetNamesOfTags](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/getnamesoftags/)，它会返回所有标签名称的数组。