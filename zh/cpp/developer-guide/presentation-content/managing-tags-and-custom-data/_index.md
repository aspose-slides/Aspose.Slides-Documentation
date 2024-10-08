---
title: 管理标签和自定义数据
type: docs
weight: 300
url: /cpp/managing-tags-and-custom-data

---

## 演示文件中的数据存储

PPTX 文件——以 .pptx 扩展名结尾的项目——以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中包含的数据的结构。

在演示文稿中，*幻灯片*是元素之一，*幻灯片部分*包含单个幻灯片的内容。幻灯片部分允许显式地与多个部分（例如用户定义的标签）建立关系，这些关系通过 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以作为标签 ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) 和 CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)) 存在。

{{% alert color="primary" %}} 

标签本质上是字符串键值对。

{{% /alert %}} 

## 获取标签的值

在幻灯片中，标签对应于 IDocumentProperties.Keywords 属性。以下示例代码展示了如何使用 Aspose.Slides for C++ 获取标签的值，适用于 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## 向演示文稿添加标签

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两个部分组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对某些演示文稿进行分类，那么通过向这些演示文稿添加标签可以获益。例如，如果您想对来自北美国家的所有演示文稿进行分类，您可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）分配为值。

以下示例代码展示了如何使用 Aspose.Slides for C++ 向 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 添加标签：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

标签也可以设置为 [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

或者任何单独的 [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```