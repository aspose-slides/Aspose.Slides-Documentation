---
title: Aspose.Slides for .NET 15.1.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.1.0 API に導入された、追加された[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)や削除された[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)クラス、メソッド、プロパティ等、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置換する機能と、レンダリング時に一時的に置換する機能が追加されました。

Presentation クラスに新しいプロパティ「FontsManager」が導入されました。FontsManager クラスには以下のメンバーがあります。

**IFontSubstRuleCollection FontSubstRuleList** プロパティ

このコレクションは、レンダリング時にフォントを置換するために使用される IFontSubstRule インスタンスの集合です。IFontSubstRule には IFontData インターフェイスを実装した SourceFont と DestFont プロパティ、および置換条件（「WhenInaccessible」または「Always」）を選択できる ReplaceFontCondition プロパティがあります。

**IFontData[] GetFonts()** メソッド

現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用します。

**ReplaceFont** メソッド

プレゼンテーション内のフォントを永続的に置換するために使用します。

次の例は、プレゼンテーションでフォントを置換する方法を示しています：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

別の例では、アクセスできない場合のレンダリング用フォント置換を示しています：

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