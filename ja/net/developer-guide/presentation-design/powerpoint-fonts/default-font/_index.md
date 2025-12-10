---
title: ".NET でデフォルトのプレゼンテーション フォントを指定する"
linktitle: "デフォルト フォント"
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
description: "Aspose.Slides for .NET のデフォルトフォントを設定し、PowerPoint (PPT, PPTX) および OpenDocument (ODP) の PDF、XPS、画像への変換を適切に行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides では、プレゼンテーションを PDF、XPS、サムネイルにレンダリングする際のデフォルトフォントを設定できます。本稿では、DefaultRegularFont と DefaultAsianFont をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for .NET API を使用して外部ディレクトリからフォントをロードしてください。

1. LoadOptions のインスタンスを作成します。
1. DefaultRegularFont を希望のフォントに設定します。以下の例では Wingdings を使用しています。
1. DefaultAsianFont を希望のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
1. Presentation を使用し、ロードオプションを設定してプレゼンテーションを読み込みます。
1. これで、スライドのサムネイル、PDF、XPS を生成し、結果を確認できます。

上記の実装例は以下です。
```c#
// デフォルトのレギュラーフォントとアジアフォントを指定するためにロードオプションを使用します
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

**DefaultRegularFont と DefaultAsianFont は正確に何に影響しますか — エクスポートのみに影響するのか、サムネイル、PDF、XPS、HTML、SVG にも影響するのか？**

それらはすべてのサポートされている出力のレンダリング パイプラインに参加します。これにはスライドサムネイル、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/net/convert-powerpoint-to-png/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/) および[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用しているためです。

**単に PPTX を読み込んで保存するだけで、レンダリングせずにデフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストの測定や描画が必要なときにのみ意味があります。プレゼンテーションを単に開いて保存するだけでは、保存されたフォントランやファイル構造は変更されません。デフォルトフォントはテキストをレンダリングしたり再配置したりする操作で使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを提供したりした場合、デフォルトフォントの選択時に考慮されますか？**

はい。[Custom font sources](/slides/ja/net/custom-font/) により、エンジンが使用できるフォントファミリーとグリフのカタログが拡張されます。デフォルトフォントおよび任意の[fallback rules](/slides/ja/net/fallback-font/) は、まずこれらのソースを参照して解決されるため、サーバーやコンテナ内でのカバレッジがより信頼性の高いものになります。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、結果として改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行、折り返し、ページングが変化する可能性があります。レイアウトの安定性を保つためには、[embed the original fonts](/slides/ja/net/embedded-font/) を使用するか、メトリック的に互換性のあるデフォルトおよびフォールバックファミリーを選択してください。

**プレゼンテーションで使用されているすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合、必要ありません。[embedded fonts](/slides/ja/net/embedded-font/) が既に一貫した外観を保証しているためです。ただし、埋め込みサブセットに含まれない文字や、ファイルが埋め込みテキストと非埋め込みテキストを混在させている場合の安全策として、デフォルトフォントは依然として有用です。