---
title: 创建后备字体
type: docs
weight: 10
url: /php-java/create-fallback-font/
---

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类来指定应用后备字体的规则。 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类表示指定的 Unicode 范围与可能包含正确字形的字体列表之间的关联：

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 使用多种方式可以添加字体列表：
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

还可以 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 后备字体或 [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) 可用于组织 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 对象的列表，当需要为多个 Unicode 范围指定后备字体替换规则时。

{{% alert color="primary" title="另见" %}} 
- [创建后备字体集合](/slides/php-java/create-fallback-fonts-collection/)
{{% /alert %}}