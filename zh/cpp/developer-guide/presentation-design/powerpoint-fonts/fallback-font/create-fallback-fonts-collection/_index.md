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
description: "在 Aspose.Slides for C++ 中设置回退字体集合，以确保 PowerPoint 和 OpenDocument 演示文稿中的文本保持一致且清晰。"
---
## **概述**

Aspose.Slides 允许您为演示文稿配置一组后备字体规则。每个后备规则由 `FontFallBackRule` 类表示，并可以添加到实现 `IFontFallBackRulesCollection` 接口的 `FontFallBackRulesCollection` 中。

创建集合后，您可以使用演示文稿的 `FontsManager` 的 `set_FontFallBackRulesCollection` 方法进行分配。`FontsManager` 控制整个演示文稿的字体，每个 `Presentation` 实例都有其独立的 `FontsManager`。

当 `FontsManager` 使用后备字体集合初始化后，指定的后备字体将在演示文稿渲染期间生效。

## **应用后备规则**

可以将 [FontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/) 类的实例组织到实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontfallbackrulescollection/) 接口的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrulescollection/) 中。可以向集合中添加或移除规则。

然后可以将该集合传递给 [FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/) 类的 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法。FontsManager 控制整个演示文稿的字体。

每个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 都有一个返回其自身 FontsManager 实例的 [get_FontsManager()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/) 方法。

以下示例演示了如何创建后备字体规则集合并将其分配给特定演示文稿的 FontsManager：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

在 FontsManager 使用后备字体集合初始化后，后备字体将在演示文稿渲染期间生效。

{{% alert color="primary" %}} 
阅读更多关于[Render Presentation with Fallback Font](/slides/zh/cpp/render-presentation-with-fallback-font/)的信息。
{{% /alert %}}

## **常见问题**

**我的后备规则会嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。后备规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的界面中。

**后备规则是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。相同的字形替换机制用于这些对象中的所有文本。

**Aspose 是否随库分发任何字体？**

不会。您需要自行添加和使用字体，且需自行承担责任。

**缺失字体的替换/替代与缺失字形的后备可以一起使用吗？**

可以。它们是同一字体解析流水线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/cpp/font-replacement/)/[substitution](/slides/zh/cpp/font-substitution/)），然后后备在可用字体中为缺失字形填补空缺。