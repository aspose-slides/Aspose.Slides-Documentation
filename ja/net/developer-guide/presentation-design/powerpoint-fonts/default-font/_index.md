---
title: デフォルトフォント - PowerPoint C# API
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/net/default-font/
keywords: 
- フォント
- デフォルトフォント
- プレゼンテーションのレンダリング
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: PowerPoint C# APIでは、プレゼンテーションをPDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。
---

## **プレゼンテーションのレンダリングにおけるデフォルトフォントの使用**
Aspose.Slidesでは、プレゼンテーションをPDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontを定義する方法を示します。以下の手順に従って、Aspose.Slides for .NET APIを使用して外部ディレクトリからフォントを読み込む方法を説明します。

1. LoadOptionsのインスタンスを作成します。
1. DefaultRegularFontを希望のフォントに設定します。以下の例では、Wingdingsを使用しました。
1. DefaultAsianFontを希望のフォントに設定します。次のサンプルでもWingdingsを使用しています。
1. Presentationを使用してプレゼンテーションを読み込み、読み込みオプションを設定します。
1. 結果を検証するために、スライドのサムネイル、PDF、およびXPSを生成します。

上記の実装は以下の通りです。

```c#
// デフォルトのレギュラーおよびアジアフォントを指定するためにロードオプションを使用
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```