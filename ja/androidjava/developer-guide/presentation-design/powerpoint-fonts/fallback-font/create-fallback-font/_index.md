---
title: フォールバックフォントの作成
type: docs
weight: 10
url: /androidjava/create-fallback-font/
---

Aspose.Slides は、フォールバックフォントを適用するためのルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule)インターフェースと [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)クラスは、欠落したグリフを検索するために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//複数の方法を使用してフォントのリストを追加できます：
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) オブジェクトにフォールバックフォントを [削除](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)したり、[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加することも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) を使用して、複数のUnicode範囲に対してフォールバックフォントの置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) オブジェクトのリストを整理することができます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションを作成](/slides/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}