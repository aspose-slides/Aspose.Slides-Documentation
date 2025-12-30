---
title: PHP でデフォルトプレゼンテーションフォントを指定する
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides のデフォルトフォントを設定し、PowerPoint (PPT、PPTX) および OpenDocument (ODP) の PDF、XPS、画像への変換を適切に行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。この記事では、DefaultRegularFont と DefaultAsianFont をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Java API を介した PHP 用 Aspose.Slides を使用し、外部ディレクトリからフォントをロードしてください。

1. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) のインスタンスを作成します。
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) を希望するフォントに設定します。以下の例では Wingdings を使用しています。
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) を希望するフォントに設定します。以下のサンプルでは Wingdings を使用しています。
4. Presentation を使用し、ロードオプションを設定してプレゼンテーションをロードします。
5. これで、スライドのサムネイル、PDF、XPS を生成して結果を確認します。

上記の実装は以下に示します。
```php
  # ロードオプションを使用してデフォルトの通常フォントとアジアフォントを定義する
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # プレゼンテーションをロードする
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # スライドのサムネイルを生成する
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # 画像をディスクに保存する。
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDF を生成する
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPS を生成する
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**DefaultRegularFont と DefaultAsianFont は正確には何に影響しますか — エクスポートだけですか、それともサムネイル、PDF、XPS、HTML、SVG も対象ですか？**  
これらはすべてのサポート対象出力のレンダリング パイプラインに参加します。スライドのサムネイル、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/php-java/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/php-java/convert-powerpoint-to-png/)、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/)、および [SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用しているためです。

**レンダリングせずに PPTX を単に読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**  
いいえ。デフォルトフォントはテキストを測定し描画する必要がある場合にのみ関係します。プレゼンテーションを単純に開いて保存するだけでは、保存されたフォント情報やファイル構造は変更されません。デフォルトフォントは、テキストをレンダリングまたは再フローする操作で適用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりした場合、デフォルトフォントの選択時に考慮されますか？**  
はい。[Custom font sources](/slides/ja/php-java/custom-font/) により、エンジンが使用できるフォントファミリとグリフのカタログが拡張されます。デフォルトフォントおよび任意の [fallback rules](/slides/ja/php-java/fallback-font/) は、まずこれらのソースを参照して解決されるため、サーバーやコンテナ上でのフォントカバレッジがより信頼できるものになります。

**デフォルトフォントはテキストメトリクス（カーニング、進行幅）に影響し、結果として改行や折り返しに影響しますか？**  
はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行、折り返し、ページ割り当てに影響する可能性があります。レイアウトの安定性を保つために、[embed the original fonts](/slides/ja/php-java/embedded-font/) を使用するか、メトリクス的に互換性のあるデフォルトおよびフォールバックファミリを選択してください。

**プレゼンテーションで使用されるすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**  
多くの場合、必要ありません。なぜなら、[embedded fonts](/slides/ja/php-java/embedded-font/) が既に一貫した表示を保証するからです。ただし、埋め込みフォントのサブセットに含まれない文字や、埋め込みテキストと非埋め込みテキストが混在するファイルに対しては、デフォルトフォントが安全ネットとして機能します。