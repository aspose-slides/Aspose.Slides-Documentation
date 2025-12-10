---
title: Aspose.Slides for .NET 15.1.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- マイグレーション
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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP のプレゼンテーション ソリューションをスムーズに移行できます。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.1.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティ等とその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントを置換したり、レンダリング時に一時的に置換したりする機能が追加されました。

Presentation クラスの新しいプロパティ「FontsManager」が導入されました。FontsManager クラスには以下のメンバーがあります。

**IFontSubstRuleCollection FontSubstRuleList** Property  
このコレクションは IFontSubstRule のインスタンスを保持し、レンダリング時にフォントを置換するために使用されます。IFontSubstRule は SourceFont と DestFont プロパティ（IFontData インターフェイスを実装）と ReplaceFontCondition プロパティ（置換条件「WhenInaccessible」または「Always」）を持ちます。

**IFontData[] GetFonts()** Method  
現在のプレゼンテーションで使用されているすべてのフォントを取得するために使用されます。

**ReplaceFont** Methods  
プレゼンテーション内のフォントを永続的に置換するために使用されます。

以下の例は、プレゼンテーションでフォントを置換する方法を示しています：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

別の例は、アクセスできない場合にレンダリング時のフォント置換を示しています：

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