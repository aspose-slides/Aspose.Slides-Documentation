---
title: Javaでデフォルトのプレゼンテーションフォントを指定する
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/java/default-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でデフォルトフォントを設定し、PowerPoint (PPT、PPTX) および OpenDocument (ODP) の PDF、XPS、画像への変換を適切に行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、PDF、XPS、サムネイルへのプレゼンテーションのレンダリング時にデフォルトフォントを設定できます。この記事では、DefaultRegular Font と DefaultAsian Font をデフォルトフォントとして定義する方法を示します。Aspose.Slides for Java API を使用して外部ディレクトリからフォントをロードする手順は以下の通りです。

1. [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) のインスタンスを作成します。
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) を使用して、目的のフォントを設定します。以下の例では Wingdings を使用しています。
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) を使用して、目的のフォントを設定します。サンプルでも Wingdings を使用しています。
1. Presentation を使用してプレゼンテーションをロードし、ロードオプションを設定します。
1. スライドのサムネイル、PDF、XPS を生成して結果を確認します。

```java
// デフォルトの通常フォントとアジアフォントを定義するためにロードオプションを使用します
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// プレゼンテーションをロードします
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // スライドのサムネイルを生成
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // ディスクに画像を保存します。
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

**DefaultRegularFont と DefaultAsianFont は正確には何に影響しますか——エクスポートのみですか、サムネイル、PDF、XPS、HTML、SVG にも影響しますか？**

それらはすべてのサポート対象出力のレンダリング パイプラインに参加します。これにはスライド サムネイル、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/java/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/java/convert-powerpoint-to-png/)、[HTML](/slides/ja/java/convert-powerpoint-to-html/)、および [SVG](/slides/ja/java/render-a-slide-as-an-svg-image/) が含まれ、Aspose.Slides はこれらのターゲット間で同一のレイアウトとグリフ解決ロジックを使用します。

**単に PPTX を読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストを測定・描画する必要がある場合にのみ影響します。プレゼンテーションをそのまま開いて保存するだけでは、フォント ランやファイル構造は変更されません。デフォルトフォントは、レンダリングやテキストの再配置が行われる操作で使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給した場合、デフォルトフォントの選択時に考慮されますか？**

はい。[カスタム フォント ソース](/slides/ja/java/custom-font/) を使用すると、エンジンが利用できるフォント ファミリーとグリフのカタログが拡張されます。デフォルトフォントおよび任意の [フォールバック ルール](/slides/ja/java/fallback-font/) は、まずこれらのソースを参照して解決され、サーバーやコンテナー環境でのカバレッジが向上します。

**デフォルトフォントはテキスト メトリクス（カーニング、アドバンス）に影響し、行の折り返しや改行に影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の行折り返しや改行、ページ割り当てが変化する可能性があります。レイアウトの安定性を確保するには、[埋め込みフォント](/slides/ja/java/embedded-font/) を使用するか、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリーを選択してください。

**プレゼンテーション内のすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合必要ありません。[埋め込みフォント](/slides/ja/java/embedded-font/) が既に外観を一貫させます。ただし、埋め込みサブセットに含まれない文字や、埋め込みと非埋め込みテキストが混在するファイルでは、デフォルトフォントが安全策として役立ちます。