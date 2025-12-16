---
title: Androidでデフォルトのプレゼンテーションフォントを指定
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/androidjava/default-font/
keywords:
- デフォルトフォント
- 標準フォント
- 通常フォント
- アジアフォント
- PDFエクスポート
- XPSエクスポート
- 画像エクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）の PDF、XPS、画像への変換を正しく行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides では、PDF、XPS、サムネイルへのプレゼンテーションのレンダリング時にデフォルトフォントを設定できます。この記事では、DefaultRegularFont と DefaultAsianFont をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for Android via Java API を使用して外部ディレクトリからフォントを読み込んでください。

1. [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions) のインスタンスを作成します。
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) を希望のフォントに設定します。次の例では Wingdings を使用しています。
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) を希望のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
1. `Presentation` を使用し、ロードオプションを設定してプレゼンテーションを読み込みます。
1. スライドサムネイル、PDF、XPS を生成し、結果を確認します。

```java
// デフォルトの通常フォントとアジアフォントを定義するためにロードオプションを使用
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// プレゼンテーションをロード
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // スライドのサムネイルを生成
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // 画像をディスクに保存します。
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF を生成
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS を生成
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**DefaultRegularFont と DefaultAsianFont は正確に何に影響しますか—エクスポートだけですか、それともサムネイル、PDF、XPS、HTML、SVG も含まれますか？**

これらはすべてのサポート対象出力のレンダリング パイプラインに参加します。スライドサムネイル、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/androidjava/convert-powerpoint-to-png/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、および [SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) も対象です。Aspose.Slides はこれらのターゲット間で同じレイアウトおよびグリフ解決ロジックを使用します。

**単に PPTX を読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストを測定して描画する必要があるときにのみ意味があります。プレゼンテーションをそのまま開いて保存するだけでは、フォント ランやファイル構造は変更されません。デフォルトフォントは、レンダリングやテキストの再配置が行われる操作で使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりした場合、デフォルトフォントの選択に考慮されますか？**

はい。[カスタム フォント ソース](/slides/ja/androidjava/custom-font/) により、エンジンが使用できるフォント ファミリとグリフのカタログが拡張されます。デフォルト フォントおよび任意の [フォールバック ルール](/slides/ja/androidjava/fallback-font/) は、まずこれらのソースに対して解決され、サーバーやコンテナー上でのカバレッジが向上します。

**デフォルトフォントはテキスト メトリクス（カーニング、アドバンス）に影響し、行の折り返しやラップに影響しますか？**

はい。フォントを変更するとグリフ メトリクスが変わり、レンダリング時の改行や折り返し、ページ割り当ても変わる可能性があります。レイアウトの安定性を保つには、[埋め込みフォント](/slides/ja/androidjava/embedded-font/) を使用するか、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリを選択してください。

**プレゼンテーション内のすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合不要です。なぜなら、[埋め込みフォント](/slides/ja/androidjava/embedded-font/) が既に一貫した外観を保証するからです。ただし、埋め込みサブセットに含まれない文字や、埋め込みフォントと非埋め込みフォントが混在する場合の安全策として、デフォルトフォントは依然として有用です。