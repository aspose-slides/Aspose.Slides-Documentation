---
title: Aspose.Slides for Java 15.1.0における公開APIと後方互換性のない変更
type: docs
weight: 100
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.1.0 APIで追加されたすべての[クラス](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)、メソッド、プロパティ、および新たな制約やその他の[変更](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)を一覧表示しています。

{{% /alert %}} {{% alert color="primary" %}} 

一部の画像のバレットやWordArtオブジェクトに既知の問題があり、これはAspose.Slides for Java 15.2.0で修正される予定です。

{{% /alert %}} 
## **公開APIの変更**
### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置き換え、一時的にレンダリング用に置き換える機能が追加されました。

Presentationクラスの新しいメソッドgetFontsManager()が導入されました。FontsManagerクラスには以下のメンバーがあります：

**IFontSubstRuleCollection getFontSubstRuleList**()メソッド

これは、レンダリング中にフォントを置き換えるために使用されるIFontSubstRuleインスタンスのコレクションです。IFontSubstRuleには、IFontDataインターフェースを実装するgetSourceFont()およびgetDestFont()メソッドと、置き換えの条件を選択することを可能にするgetReplaceFontCondition()メソッドがあります（"WhenInaccessible"または"Always"）。

**IFontData[] getFonts()**メソッドを使用して、現在のプレゼンテーションで使用されているすべてのフォントを取得できます。

**replaceFont(...)**メソッドを使用して、プレゼンテーション内のフォントを永続的に置き換えることができます。

以下の例は、プレゼンテーション内のフォントを置き換える方法を示しています：

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

別の例では、アクセスできない場合のレンダリングのためのフォント置換を示しています：

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// アクセスできない場合、SomeRareFontの代わりにArialフォントが使用されます

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```