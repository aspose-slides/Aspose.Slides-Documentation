---
title: 配置 C++ 中的后备字体集合
linktitle: 后备字体集合
type: docs
weight: 20
url: /zh/cpp/create-fallback-fonts-collection/
keywords:
- 后备字体
- 后备规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中设置后备字体集合，以在 PowerPoint 和 OpenDocument 演示文稿中保持文本的一致性和清晰度。"
---
## **概述**

Aspose.Slides 允许您为演示文稿配置后备字体规则集合。每个后备规则由 `FontFallBackRule` 类表示，并且可以添加到 `FontFallBackRulesCollection` 中，该集合实现了 `IFontFallBackRulesCollection` 接口。

创建集合后，您可以使用演示文稿的 `FontsManager` 的 `set_FontFallBackRulesCollection` 方法进行分配。`FontsManager` 控制整个演示文稿的字体，并且每个 `Presentation` 实例都有自己的 `FontsManager`。

一旦 `FontsManager` 使用后备字体集合初始化，在演示文稿渲染期间将应用指定的后备字体。

## **应用后备规则**

FontFallBackRule 类的实例可以组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrulescollection/) 中，该集合实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontfallbackrulescollection/) 接口。可以向集合中添加或删除规则。

然后可以将此集合传递给 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法的 [FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/) 类。FontsManager 控制演示文稿中的字体。

每个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 都有一个 [get_FontsManager()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/) 方法，用于获取其自己的 FontsManager 实例。

以下示例展示如何创建后备字体规则集合并将其分配到特定演示文稿的 FontsManager 中：

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

在使用后备字体集合初始化 FontsManager 后，渲染演示文稿时会应用后备字体。

{{% alert color="info" %}} 
了解更多如何[使用后备字体呈现演示文稿](/slides/zh/cpp/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

### 我的后备规则会被嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？

否。后备规则是运行时渲染设置；它们不会序列化到 PPTX 中，也不会出现在 PowerPoint 的 UI 中。

### 后备规则会应用于 SmartArt、WordArt、图表和表格中的文本吗？

是的。相同的字形替换机制用于这些对象中的所有文本。

### Aspose 是否随库一起分发任何字体？

否。您需要自行添加和使用字体，责任由您自行承担。

### 缺失字体的替换/替代和缺失字形的后备可以一起使用吗？

是的。它们是同一字体解析管道的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/cpp/font-replacement/)/[substitution](/slides/zh/cpp/font-substitution/)），然后后备为可用字体中缺失的字形填补空缺。