---
title: 在 PHP 中配置回退字体集合
linktitle: 回退字体集合
type: docs
weight: 20
url: /zh/php-java/create-fallback-fonts-collection/
keywords:
- 回退字体
- 回退规则
- 字体集合
- 配置字体
- 设置字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中设置回退字体集合，以保持 PowerPoint 和 OpenDocument 演示文稿中的文本一致且清晰。"
---

## **应用回退规则**

实例的[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)类可以组织到[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection)中，该集合实现[IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection)接口。可以从集合中添加或移除规则。

然后可以将此集合分配给[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)类的[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection)方法。FontsManager 控制整个演示文稿中的字体。了解更多[关于 FontsManager 和 FontsLoader](/slides/zh/php-java/about-fontsmanager-and-fontsloader/)。

每个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)都有一个[getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--)方法，返回其自己的[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)实例。

下面是创建回退字体规则集合并将其分配给特定演示文稿的[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--)的示例：  
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


在 FontsManager 使用回退字体集合初始化后，渲染演示文稿时会应用回退字体。

{{% alert color="primary" %}} 
阅读更多如何[Render Presentation with Fallback Font](/slides/zh/php-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **FAQ**

**我的回退规则会嵌入到 PPTX 文件中并在 PowerPoint 中保存后可见吗？**

不会。回退规则是运行时渲染设置，不会序列化到 PPTX 中，也不会出现在 PowerPoint 的 UI 中。

**回退是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。相同的字形替换机制用于这些对象中的所有文本。

**Aspose 是否随库分发任何字体？**

不会。您需要自行提供并使用字体，责任自行承担。

**缺失字体的替换/子stitution 与缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/php-java/font-replacement/)/[substitution](/slides/zh/php-java/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。