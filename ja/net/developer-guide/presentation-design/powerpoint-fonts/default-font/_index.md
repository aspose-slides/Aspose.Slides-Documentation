---
title: .NET でデフォルトのプレゼンテーションフォントを指定する
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/net/default-font/
keywords:
- デフォルトフォント
- 標準フォント
- 通常フォント
- アジアフォント
- PDF エクスポート
- XPS エクスポート
- 画像エクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）の PDF、XPS、画像への変換を正しく行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングする際のデフォルトフォントを設定できます。この記事では、DefaultRegularFont と DefaultAsianFont をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for .NET API を使用して外部ディレクトリからフォントをロードしてください。

1. LoadOptions のインスタンスを作成します。
1. DefaultRegularFont を目的のフォントに設定します。以下の例では Wingdings を使用しています。
1. DefaultAsianFont を目的のフォントに設定します。こちらのサンプルでも Wingdings を使用しています。
1. Presentation を使用してプレゼンテーションをロードし、ロードオプションを設定します。
1. スライドのサムネイル、PDF、XPS を生成し、結果を確認します。

上記の実装例は以下のとおりです。
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


## **FAQ**

**DefaultRegularFont と DefaultAsianFont は正確には何に影響しますか—エクスポートだけですか、サムネイル、PDF、XPS、HTML、SVG も対象ですか？**

これらはサポートされているすべての出力に対するレンダリング パイプラインに参加します。スライドのサムネイル、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/net/convert-powerpoint-to-png/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、および[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) が対象です。Aspose.Slides はこれらのターゲット間で同じレイアウトおよびグリフ解決ロジックを使用します。

**単に PPTX を読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストを測定・描画する必要があるときに意味を持ちます。プレゼンテーションを単に開いて保存するだけでは、フォント ランやファイル構造は変更されません。デフォルトフォントは、レンダリングやテキストの再フローが行われる操作時に作用します。

**独自のフォントフォルダーを追加したりメモリからフォントを供給したりすると、デフォルトフォントの選択に考慮されますか？**

はい。[カスタム フォント ソース](/slides/ja/net/custom-font/) を使用すると、エンジンが利用できるファミリとグリフのカタログが拡張されます。デフォルトフォントおよび任意の[フォールバック ルール](/slides/ja/net/fallback-font/) は、これらのソースを優先的に参照して解決され、サーバーやコンテナー上でのカバレッジが向上します。

**デフォルトフォントはテキスト メトリクス（カーニング、アドバンス）に影響し、行の折り返しや改行に影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の行の折り返し、ラッピング、ページ分割が変化する可能性があります。レイアウトの安定性を保つには、[元のフォントを埋め込む](/slides/ja/net/embedded-font/)か、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリを選択してください。

**プレゼンテーション内のすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合不要です。なぜなら[埋め込みフォント](/slides/ja/net/embedded-font/) が外観の一貫性を保証するからです。ただし、埋め込みサブセットに含まれない文字がある場合や、埋め込みフォントと非埋め込みテキストが混在するファイルでは、デフォルトフォントが安全ネットとして機能します。