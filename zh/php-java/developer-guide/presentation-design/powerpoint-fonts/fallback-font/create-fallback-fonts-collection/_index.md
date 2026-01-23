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

可以将 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类的实例组织到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) 中。可以向集合中添加或删除规则。

然后可以将此集合分配给 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类的 [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) 方法。FontsManager 控制演示文稿中的字体。

每个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 都有一个 [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) 方法，该方法返回其自己的 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) 类实例。

下面是一个示例，展示如何创建回退字体规则集合并将其分配给特定演示文稿的 [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager)：
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


FontsManager 使用回退字体集合初始化后，回退字体将在演示文稿渲染期间应用。

{{% alert color="primary" %}} 
了解更多关于如何 [渲染演示文稿并使用回退字体](/slides/zh/php-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常见问题**

**我的回退规则会被嵌入到 PPTX 文件中并在保存后在 PowerPoint 中可见吗？**

不会。回退规则是运行时渲染设置，它们不会被序列化到 PPTX 中，也不会出现在 PowerPoint 的用户界面中。

**回退规则是否适用于 SmartArt、WordArt、图表和表格中的文本？**

是的。这些对象中的任何文本都使用相同的字形替换机制。

**Aspose 是否随库分发任何字体？**

不会。您需要自行添加和使用字体，责任由您自行承担。

**缺失字体的替换/替代与缺失字形的回退可以一起使用吗？**

可以。它们是同一字体解析管线的独立阶段：首先引擎解析字体可用性（[replacement](/slides/zh/php-java/font-replacement/)/[substitution](/slides/zh/php-java/font-substitution/)），然后回退为可用字体中缺失的字形填补空缺。