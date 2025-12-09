---
title: Aspose.Slides for .NET 15.1.0 の公開 API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 15.1.0 APIで導入された、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)または削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)クラス、メソッド、プロパティ等、そしてその他の変更をすべて一覧表示します。

{{% /alert %}} 
## **Public API 変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置換する機能と、レンダリング時に一時的に置換する機能が追加されました。

Presentation クラスに新しいプロパティ「FontsManager」が導入されました。FontsManager クラスは以下のメンバーを持ちます。

**IFontSubstRuleCollection FontSubstRuleList** プロパティ  

このコレクションは、レンダリング時にフォントを置換するために使用される IFontSubstRule インスタンスの集合です。IFontSubstRule は SourceFont と DestFont プロパティ（IFontData インターフェイスを実装）と、置換条件（「WhenInaccessible」または「Always」）を指定する ReplaceFontCondition プロパティを持ちます。

**IFontData[] GetFonts()** メソッド  

現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用します。

**ReplaceFont** メソッド  

プレゼンテーション内のフォントを永続的に置換するために使用します。

以下の例は、プレゼンテーションでフォントを置換する方法を示しています。

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

別の例は、アクセスできない場合のレンダリング時にフォント置換を行う方法を示しています。

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

```