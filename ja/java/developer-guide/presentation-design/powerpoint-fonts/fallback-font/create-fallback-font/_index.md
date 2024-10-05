---
title: フォールバックフォントの作成
type: docs
weight: 10
url: /java/create-fallback-font/
---

Aspose.Slidesは、フォールバックフォントを適用するためのルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule)インターフェースおよび[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)クラスは、検索された欠落グリフのために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//複数の方法を使用してフォントのリストを追加できます：
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

既存の[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)オブジェクトにフォールバックフォントを[削除](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)したり、[addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection)は、複数のUnicode範囲のためにフォールバックフォント置き換えルールを指定する必要があるときに、[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule)オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションの作成](/slides/java/create-fallback-fonts-collection/)
{{% /alert %}}