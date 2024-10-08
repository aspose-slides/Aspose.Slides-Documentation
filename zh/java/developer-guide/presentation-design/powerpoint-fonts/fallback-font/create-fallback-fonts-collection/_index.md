---
title: 创建备用字体集合
type: docs
weight: 20
url: /zh/java/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)类的实例可以组织成[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection)，它实现了[IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection)接口。可以从集合中添加或删除规则。

然后，将这个集合分配给[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)类的[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection)方法。FontsManager控制演示文稿中的字体。更多信息，请阅读[关于 FontsManager 和 FontsLoader](/slides/zh/java/about-fontsmanager-and-fontsloader/)。

每个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)都有一个带有自己[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)类实例的[getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)方法。

以下是如何创建备用字体规则集合并将其分配给特定演示文稿的[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--)的示例：  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

在FontsManager初始化备用字体集合后，备用字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
了解更多如何[渲染带备用字体的演示文稿](/slides/zh/java/render-presentation-with-fallback-font/)。
{{% /alert %}}