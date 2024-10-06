---
title: フォールバックフォントの作成
type: docs
weight: 10
url: /ja/php-java/create-fallback-font/
---

Aspose.Slidesは、フォールバックフォントを適用するルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule)インターフェイスおよび[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)クラスは、欠落したグリフを検索するために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 複数の方法を使用してフォントリストを追加できます：
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

既存の[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)オブジェクトにフォールバックフォントを[削除](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-)したり、[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加することも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection)は、複数のUnicode範囲に対してフォールバックフォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションの作成](/slides/ja/php-java/create-fallback-fonts-collection/)
{{% /alert %}}