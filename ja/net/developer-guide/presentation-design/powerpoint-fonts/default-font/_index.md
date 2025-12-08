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
description: PowerPoint C# API を使用すると、PDF、XPS、またはサムネイルへのプレゼンテーションのレンダリング時にデフォルトフォントを設定できます。
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slidesでは、プレゼンテーションをPDF、XPS、またはサムネイルにレンダリングする際のデフォルトフォントを設定できます。本記事では、DefaultRegularFont と DefaultAsianFont をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for .NET API を使用して外部ディレクトリからフォントを読み込んでください：

1. LoadOptions のインスタンスを作成します。
2. DefaultRegularFont を希望のフォントに設定します。以下の例では Wingdings を使用しています。
3. DefaultAsianFont を希望のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
4. Presentation を使用してプレゼンテーションをロードし、ロードオプションを設定します。
5. スライドのサムネイル、PDF、XPS を生成して結果を確認します。

上記の実装例は以下の通りです。
```c#
// ロードオプションを使用してデフォルトのレギュラーフォントとアジアフォントを指定します
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


## **よくある質問**

**DefaultRegularFont と DefaultAsianFont は正確には何に影響しますか—エクスポートのみですか、それともサムネイル、PDF、XPS、HTML、SVG も対象ですか？**

これらはすべてのサポート対象出力のレンダリングパイプラインに参加します。スライドのサムネイル、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/net/convert-powerpoint-to-png/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、および[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slidesはこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用するためです。

**単に PPTX を読み込んで保存するだけで、レンダリングせずにデフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストを測定し描画する必要がある場合にのみ影響します。単純なオープン＆セーブではフォントランやファイル構造は変更されません。デフォルトフォントはレンダリングやテキストの再配置が発生する操作で使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを提供した場合、デフォルトフォント選択時に考慮されますか？**

はい。[カスタムフォント ソース](/slides/ja/net/custom-font/)により、利用可能なフォントファミリとグリフのカタログが拡張されます。DefaultRegularFont と任意の[フォールバック ルール](/slides/ja/net/fallback-font/)はまずそれらのソースを参照し、サーバーやコンテナ上でのカバレッジを向上させます。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、結果として改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行や折り返し、ページ分割に影響します。レイアウトの安定性を保つには、[元のフォントを埋め込む](/slides/ja/net/embedded-font/)か、メトリクス的に互換性のあるデフォルトおよびフォールバックファミリを選択してください。

**プレゼンテーションで使用されるすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合必須ではありません。なぜなら[埋め込みフォント](/slides/ja/net/embedded-font/)は一貫した表示を保証するからです。ただし、埋め込みサブセットに含まれない文字や、埋め込みと非埋め込みテキストが混在する場合の安全策として、デフォルトフォントは依然として有用です。