---
title: デフォルトフォント - PowerPoint JavaScript API
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/nodejs-java/default-font/
description: PowerPoint JavaScript API を使用すると、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングする際のデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用する DefaultRegular Font と DefaultAsian Font の定義方法を示します。
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングする際のデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用する DefaultRegularFont と DefaultAsianFont の定義方法を示します。以下の手順に従って、Aspose.Slides for Node.js via Java API を使用し、外部ディレクトリからフォントをロードしてください：

1. [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions) のインスタンスを作成します。
2. [DefaultRegularFont を設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) します。以下の例では Wingdings を使用しています。
3. [DefaultAsianFont を設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) します。以下のサンプルでも Wingdings を使用しています。
4. Presentation を使用してプレゼンテーションをロードし、ロードオプションを設定します。
5. スライドのサムネイル、PDF、XPS を生成して結果を確認します。

上記の実装は以下に示します。
```javascript
// デフォルトのレギュラーおよびアジアフォントを定義するためにロードオプションを使用します
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Load the presentation
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // スライドサムネイルを生成
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // 画像をディスクに保存します。
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // PDF を生成
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // XPS を生成
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**DefaultRegularFont と DefaultAsianFont は正確に何に影響しますか—エクスポートのみですか、それともサムネイル、PDF、XPS、HTML、SVG も含まれますか？**

これらはすべてのサポート対象出力のレンダリング パイプラインに参加します。スライドのサムネイル、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)、および[SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲットで同じレイアウトとグリフ解決ロジックを使用しているためです。

**レンダリングせずに単に PPTX を読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストの測定と描画が必要なときにのみ意味があります。プレゼンテーションを単に開いて保存するだけでは、保存されたフォント ランやファイル構造は変更されません。デフォルトフォントはテキストをレンダリングまたは再フローする操作で使用されます。

**自分のフォントフォルダーを追加したり、メモリからフォントを提供したりした場合、デフォルトフォントの選択時に考慮されますか？**

はい。[カスタム フォント ソース](/slides/ja/nodejs-java/custom-font/)により、エンジンが使用できるフォント ファミリとグリフのカタログが拡張されます。デフォルトフォントおよびすべての [フォールバック ルール](/slides/ja/nodejs-java/fallback-font/) はまずそれらのソースに対して解決され、サーバーやコンテナ上でのカバレッジがより信頼できるものになります。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、行の改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフ メトリクスが変わり、レンダリング時の改行、折り返し、ページ割り当てが変わる可能性があります。レイアウトの安定性のために、[元のフォントを埋め込む](/slides/ja/nodejs-java/embedded-font/)か、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリを選択してください。

**プレゼンテーションで使用されているすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合必要ありません。なぜなら、[埋め込みフォント](/slides/ja/nodejs-java/embedded-font/) が既に一貫した外観を保証しているからです。ただし、埋め込みサブセットに含まれない文字や、埋め込みテキストと非埋め込みテキストが混在するファイルでは、デフォルトフォントが安全ネットとして役立ちます。