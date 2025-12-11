---
title: 在 C++ 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/cpp/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides 的 C++ 中设置回退字体集合，以在 PowerPoint 和 OpenDocument 演示文稿中保持文本一致且清晰。"
---

## **应用回退规则**

可以将[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)类的实例组织到[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)中，该集合实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection)接口。可以向集合中添加或删除规则。

然后可以将此集合传递给[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)方法，该方法属于[FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager)类。FontsManager 控制整个演示文稿中的字体。了解更多[关于 FontsManager 和 FontsLoader](/slides/zh/cpp/about-fontsmanager-and-fontsloader/)。

每个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)都有一个[get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)方法，它拥有自己的 FontsManager 类实例。

下面是一个示例，说明如何创建回退字体规则集合并将其分配给特定演示文稿的 FontsManager：
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


在使用回退字体集合初始化 FontsManager 后，回退字体将在演示文稿渲染期间生效。

{{% alert color="primary" %}} 
了解更多如何[使用回退字体渲染演示文稿](/slides/zh/cpp/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。相同的字形替换机制适用于这些对象中的所有文本。

**Aspose 是否随库分发任何字体？**

不会。您需要自行添加和使用字体，需自行承担责任。

**可以同时使用缺失字体的替换/替代和缺失字形的回退吗？**

是的。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/cpp/font-replacement/)/[substitution](/slides/zh/cpp/font-substitution/)），然后回退为可用字体中缺失的字形填补空白。