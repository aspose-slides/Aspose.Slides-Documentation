---
title: 创建备用字体
type: docs
weight: 10
url: /java/create-fallback-font/
---

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类来指定应用备用字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类表示用于搜索缺失字形的指定 Unicode 范围与可能包含适当字形的字体列表之间的关联：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多种方式可以添加字体列表：
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以 [移除](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 备用字体或 [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 添加到现有的 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 可用于组织多个 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 对象的列表，当需要为多个 Unicode 范围指定备用字体替换规则时。

{{% alert color="primary" title="另请参阅" %}} 
- [创建备用字体集合](/slides/java/create-fallback-fonts-collection/)
{{% /alert %}}