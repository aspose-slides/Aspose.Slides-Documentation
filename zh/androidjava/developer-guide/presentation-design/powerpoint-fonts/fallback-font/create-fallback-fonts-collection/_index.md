---
title: 创建回退字体集合
type: docs
weight: 20
url: /androidjava/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 类的实例可以组织成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)，它实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) 接口。可以从集合中添加或移除规则。

然后，可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制演示文稿中的字体。了解更多信息请查看 [关于 FontsManager 和 FontsLoader](/slides/androidjava/about-fontsmanager-and-fontsloader/)。

每个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) 方法，拥有自己实例的 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类。

以下是如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) 的示例：  

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

在将 FontsManager 初始化为回退字体集合后，回退字体将在演示文稿呈现期间应用。

{{% alert color="primary" %}} 
了解更多关于 [使用回退字体呈现演示文稿](/slides/androidjava/render-presentation-with-fallback-font/) 的信息。
{{% /alert %}}