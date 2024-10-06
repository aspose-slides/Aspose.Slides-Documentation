---
title: プレゼンテーションプロパティ - C#でPowerPointプレゼンテーションプロパティにアクセスまたは変更
linktitle: プレゼンテーションプロパティ
type: docs
weight: 70
url: /ja/net/presentation-properties/
keywords: "PowerPointの最終更新者を削除する方法, PowerPointプロパティ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションプロパティ"
---


## **ライブ例**
オンラインアプリ[**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata)を試して、Aspose.Slides APIを介してドキュメントプロパティにどのようにアクセスするかを確認してください：

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **プレゼンテーションプロパティについて**
先に説明したように、Aspose.Slides for .NETは**組み込み**と**カスタム**の2種類のドキュメントプロパティをサポートしています。したがって、開発者はAspose.Slides for .NET APIを使用して両方の種類のプロパティにアクセスできます。Aspose.Slides for .NETは、プレゼンテーションファイルに関連付けられたドキュメントプロパティを表す[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties)クラスを提供します。開発者は、以下に説明するように、**Presentation**オブジェクトによって公開されている[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties)プロパティを使用してプレゼンテーションファイルのドキュメントプロパティにアクセスできます。



{{% alert color="primary" %}} 

**Application**および**Producer**フィールドに対して値を設定できないことに注意してください。なぜなら、Aspose Ltd.およびAspose.Slides for .NET x.x.xがこれらのフィールドに表示されるからです。

{{% /alert %}} 


## **プレゼンテーションプロパティの管理**
Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供します。これらのドキュメントプロパティは、ドキュメント（プレゼンテーションファイル）とともに役立つ情報を保存することを可能にします。ドキュメントプロパティには以下の2種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み**プロパティには、ドキュメントのタイトル、著者名、ドキュメント統計などの一般的な情報が含まれています。**カスタム**プロパティは、ユーザーによって**名/値**ペアとして定義されるプロパティであり、名前と値の両方がユーザーによって定義されます。Aspose.Slides for .NETを使用すると、開発者は組み込みプロパティおよびカスタムプロパティの値にアクセスして変更することができます。Microsoft PowerPoint 2007では、プレゼンテーションファイルのドキュメントプロパティを管理することができます。すべて行う必要があるのは、Officeアイコンをクリックし、次にMicrosoft PowerPoint 2007の**準備 | プロパティ | 高度なプロパティ**メニュー項目を選択することです。**高度なプロパティ**メニュー項目を選択すると、PowerPointファイルのドキュメントプロパティを管理するためのダイアログが表示されます。**プロパティダイアログ**では、**一般、概要、統計、内容、カスタム**のような多くのタブページがあることがわかります。これらのタブページはすべて、PowerPointファイルに関連するさまざまな種類の情報を構成することを可能にします。**カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。

## **組み込みプロパティにアクセス**
これらのプロパティは、**IDocumentProperties**オブジェクトによって公開されたもので、次のものが含まれます：**Creator(Author)**、**Description**、**Keywords**、**Created**（作成日）、**Modified**（最終更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**、および**Title**。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}

## **組み込みプロパティを変更**
プレゼンテーションファイルの組み込みプロパティを変更するのは、アクセスするのと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、そのプロパティの値が変更されます。以下の例では、プレゼンテーションファイルの組み込みドキュメントプロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **カスタムプレゼンテーションプロパティを追加**
Aspose.Slides for .NETは、開発者がプレゼンテーションのドキュメントプロパティにカスタム値を追加できることを許可します。以下に、プレゼンテーションにカスタムプロパティを設定する方法を示す例を示します。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **カスタムプロパティにアクセスおよび変更**
Aspose.Slides for .NETは、開発者がカスタムプロパティの値にアクセスできることも許可しています。以下に、プレゼンテーションのこれらのカスタムプロパティにアクセスして変更する方法を示す例を示します。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **プレゼンテーションが変更または作成されたかを確認**
Aspose.Slides for .NETは、プレゼンテーションが変更または作成されたかを確認する機能を提供します。以下に、プレゼンテーションが作成されたかまたは変更されたかを確認する方法を示す例を示します。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

デフォルト言語を設定

## **校正言語の設定**

Aspose.Slidesは、PowerPointドキュメントの校正言語を設定するために、[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)プロパティ（[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)クラスによって公開）を提供します。校正言語は、PowerPoint内のスペルと文法がチェックされる言語です。

次のC#コードは、PowerPoint用の校正言語を設定する方法を示しています：

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // 校正言語のIdを設定
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **デフォルト言語を設定**

次のC#コードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています：

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // テキスト付きの新しい矩形形状を追加
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "新しいテキスト";
    
    // 最初のポーションの言語を確認
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```