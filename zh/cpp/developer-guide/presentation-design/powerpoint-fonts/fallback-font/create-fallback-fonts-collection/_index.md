---
title: 创建备用字体集合
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)类的实例可以组织成[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)，该集合实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection)接口。可以向集合中添加或删除规则。

然后，可以将此集合传递给[set_FontFallBackRulesCollection() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)方法，该方法属于[FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager)类。FontsManager 控制演示文稿中的字体。了解更多内容请查看[关于 FontsManager 和 FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/)。

每个[Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)都有一个[get_FontsManager() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)方法，返回其自己的 FontsManager 类实例。

以下是如何创建备用字体规则集合并将其分配给特定演示文稿的 FontsManager 的示例：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

在 FontsManager 初始化了备用字体集合之后，在演示文稿渲染期间将应用备用字体。

{{% alert color="primary" %}} 
了解更多如何[使用备用字体渲染演示文稿](/slides/cpp/render-presentation-with-fallback-font/)。
{{% /alert %}}