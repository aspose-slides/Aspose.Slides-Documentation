---
title: Aspose.Slides for .NET 15.1.0における公共APIと後方互換性のない変更
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.1.0 APIで追加された、または削除されたすべての[追加された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)または[削除された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)クラス、メソッド、プロパティなど、その他の変更を一覧表示しています。

{{% /alert %}} 
## **公共APIの変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体で、または一時的にレンダリングのためにフォントを置換する可能性が追加されました。

Presentationクラスの新しいプロパティ「FontsManager」が導入されました。FontsManagerクラスは次のメンバーを持っています：

**IFontSubstRuleCollection FontSubstRuleList** プロパティ

レンダリング中にフォントを置換するために使用されるIFontSubstRuleインスタンスのコレクションです。IFontSubstRuleは、IFontDataインターフェイスを実装するSourceFontとDestFontプロパティ、および置換条件（「WhenInaccessible」または「Always」）を選択できるReplaceFontConditionプロパティを持っています。

**IFontData[] GetFonts()** メソッド

現在のプレゼンテーションで使用されるすべてのフォントを取得するために使用されます。

**ReplaceFont** メソッド

プレゼンテーション内のフォントを永続的に置換するために使用されます。

次の例は、プレゼンテーション内のフォントを置換する方法を示しています：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

``` 

別の例では、アクセスできない場合のレンダリングのためのフォント置換を示しています：

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // 一時的にアクセスできない場合、ArialフォントがSomeRareFontの代わりに使用されます

            pres.Slides[0].GetThumbnail();

``` 