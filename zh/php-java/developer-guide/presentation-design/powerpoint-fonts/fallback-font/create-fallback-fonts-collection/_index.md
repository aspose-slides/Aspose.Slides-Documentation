---
title: 创建后备字体集合
type: docs
weight: 20
url: /php-java/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类的实例可以组织成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection)，该类实现了 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) 接口。可以向集合中添加或移除规则。

然后，可以将该集合分配给 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制演示文稿中的字体。阅读更多关于 [FontsManager 和 FontsLoader](/slides/php-java/about-fontsmanager-and-fontsloader/) 的信息。

每个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 都有一个带有自己 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类实例的 [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) 方法。

以下是如何创建后备字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) 的示例：  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

在使用后备字体集合初始化 FontsManager 后，后备字体将在演示文稿渲染时应用。

{{% alert color="primary" %}} 
阅读更多关于如何 [使用后备字体渲染演示文稿](/slides/php-java/render-presentation-with-fallback-font/) 的信息。
{{% /alert %}}