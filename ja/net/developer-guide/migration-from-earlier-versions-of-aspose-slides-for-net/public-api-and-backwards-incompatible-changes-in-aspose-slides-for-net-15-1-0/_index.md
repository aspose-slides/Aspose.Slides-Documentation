---
title: Aspose.Slides for .NET 15.1.0 におけるパブリック API と下位互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と重大な変更を確認し、PowerPoint PPT、PPTX、ODP のプレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 15.1.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)されたクラス、メソッド、プロパティ等、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **フォント置換機能が追加されました**
プレゼンテーション全体でフォントをグローバルに置換する機能と、レンダリング時に一時的に置換する機能が追加されました。

Presentation クラスに新しいプロパティ「FontsManager」が導入されました。FontsManager クラスには以下のメンバーがあります：

**IFontSubstRuleCollection FontSubstRuleList** プロパティ  
このコレクションは IFontSubstRule インスタンスを保持し、レンダリング中にフォントを置換するために使用されます。IFontSubstRule には IFontData インターフェイスを実装した SourceFont と DestFont プロパティ、および置換条件（「WhenInaccessible」または「Always」）を選択できる ReplaceFontCondition プロパティがあります。

**IFontData[] GetFonts()** メソッド  
現在のプレゼンテーションで使用されているすべてのフォントを取得します。

**ReplaceFont** メソッド  
プレゼンテーション内のフォントを永続的に置換します。

次の例は、プレゼンテーション内でフォントを置換する方法を示しています：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

別の例は、アクセスできない場合のレンダリング時にフォント置換を行う方法を示しています：

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arialフォントは、SomeRareFontにアクセスできない場合に代わりに使用されます

            pres.Slides[0].GetImage();

```