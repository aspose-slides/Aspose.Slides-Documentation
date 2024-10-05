---
title: Aspose.Slides for PHP via Java 15.1.0における公開APIと後方互換性のない変更
type: docs
weight: 100
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.1.0 APIで追加されたすべての[追加された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)クラス、メソッド、プロパティ、その他の制約や[変更](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)のリストを示します。

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 15.2.0で修正される、いくつかの画像バレットとWordArtオブジェクトに関する既知の問題があります。

{{% /alert %}} 
## **公開APIの変更**
### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置換する機能と、レンダリング用の一時的な置換機能が追加されました。

Presentationクラスの新しいメソッドgetFontsManager()が導入されました。FontsManagerクラスには以下のメンバーがあります。

**IFontSubstRuleCollection getFontSubstRuleList**()メソッド

これは、レンダリング中にフォントを置換するために使用されるIFontSubstRuleインスタンスのコレクションです。 IFontSubstRuleには、IFontDataインターフェースを実装するgetSourceFont()およびgetDestFont()メソッドと、置換条件を選択するためのgetReplaceFontCondition()メソッドがあります（"WhenInaccessible"または"Always"）。

**IFontData[] getFonts()**メソッドは、現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用できます。

**replaceFont(...)**メソッドは、プレゼンテーション内のフォントを永続的に置き換えるために使用できます。 

以下の例は、プレゼンテーション内のフォントを置き換える方法を示しています：

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);

```

別の例は、アクセスできないときのレンダリングのためのフォント置換を示しています：

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # SomeRareFontがアクセスできない場合、Arialフォントが使用されます
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);

```