---
title: Aspose.Slides for .NET 15.1.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 移行
- レガシー コード
- モダン コード
- レガシー アプローチ
- モダン アプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行してください。"
---

{{% alert color="primary" %}} 

このページには、Aspose.Slides for .NET 15.1.0 APIで導入された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)クラス、メソッド、プロパティ等、そしてその他の変更が一覧表示されます。

{{% /alert %}} 
## **パブリック API の変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置換する機能と、レンダリング時に一時的に置換する機能が追加されました。

Presentation クラスに新しいプロパティ「FontsManager」が導入されました。FontsManager クラスには以下のメンバーがあります。

**IFontSubstRuleCollection FontSubstRuleList** プロパティ

これは、レンダリング中にフォントを置換するために使用される IFontSubstRule インスタンスのコレクションです。IFontSubstRule には、IFontData インターフェイスを実装する SourceFont および DestFont プロパティと、置換条件（「WhenInaccessible」または「Always」）を選択できる ReplaceFontCondition プロパティがあります。

**IFontData[] GetFonts()** メソッド

現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用します。

**ReplaceFont** メソッド

プレゼンテーション内のフォントを永続的に置換するために使用します。

以下の例は、プレゼンテーション内のフォントを置換する方法を示しています：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

別の例では、アクセスできない場合のレンダリング時にフォント置換を実演します：

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