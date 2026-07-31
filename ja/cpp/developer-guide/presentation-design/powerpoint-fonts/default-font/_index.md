---
title: C++ でデフォルトのプレゼンテーション フォントを指定する
linktitle: デフォルト フォント
type: docs
weight: 30
url: /ja/cpp/default-font/
keywords:
- デフォルト フォント
- レギュラーフォント
- 標準フォント
- アジアフォント
- PDF エクスポート
- XPS エクスポート
- 画像エクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）の PDF、XPS、画像への変換を適切に行えるようにします。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーションがレンダリングされる際に使用される既定のフォントを指定できます。これは、スライドサムネイルの生成や、PDF や XPS などの形式へのエクスポート時に便利です。既定のフォントは、プレゼンテーションを読み込む前に `LoadOptions` を介して構成されます。

`set_DefaultRegularFont` メソッドは通常のテキスト用の既定フォントを定義し、`set_DefaultAsianFont` はアジア文字用の既定フォントを定義します。これらのオプションを設定した後、指定したフォントを使用してプレゼンテーションを読み込み、レンダリングできます。

## **プレゼンテーションのレンダリング時にデフォルトフォントを使用する**
Aspose.Slides では、PDF、XPS、サムネイルへのレンダリング時に既定フォントを設定できます。この記事では、DefaultRegularFont と DefaultAsianFont を既定フォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for C++ API を使用して外部ディレクトリからフォントを読み込みます。

1. LoadOptions のインスタンスを作成します。  
1. DefaultRegularFont を目的のフォントに設定します。以下の例では Wingdings を使用しています。  
1. DefaultAsianFont を目的のフォントに設定します。サンプルでも Wingdings を使用しています。  
1. Presentation を使用してプレゼンテーションを読み込み、ロードオプションを設定します。  
1. スライドサムネイル、PDF、XPS を生成して結果を確認します。

上記の実装例は以下に示されています。

```cpp
// ロード オプションを使用して、デフォルトのレギュラーフォントとアジアフォントを指定します
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **よくある質問**

**DefaultRegularFont と DefaultAsianFont は正確には何に影響しますか—エクスポートのみでしょうか、それともサムネイル、PDF、XPS、HTML、SVG にも影響しますか？**

これらはサポートされているすべての出力に対するレンダリングパイプラインに参加します。スライドサムネイル、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/cpp/convert-powerpoint-to-png/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、および [SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) が対象で、Aspose.Slides はこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用します。

**レンダリングを行わずに PPTX を単に読み込んで保存するだけの場合、既定フォントは適用されますか？**

いいえ。既定フォントはテキストを測定して描画する必要がある場合にのみ関係します。プレゼンテーションを単純にオープンして保存するだけでは、フォントランやファイル構造は変更されません。既定フォントは、テキストをレンダリングまたは再フローする操作中に適用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりした場合、既定フォントの選択に考慮されますか？**

はい。[カスタムフォント ソース](/slides/ja/cpp/custom-font/) を使用すると、エンジンが利用できるフォント ファミリーとグリフのカタログが拡張されます。既定フォントと任意の [フォールバック ルール](/slides/ja/cpp/fallback-font/) はこれらのソースを最初に参照し、サーバーやコンテナ上でのカバレッジが向上します。

**既定フォントはテキスト メトリクス（カーニング、アドバンス）に影響し、行の改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行・折り返し・ページ分割が変化する可能性があります。レイアウトの安定性を確保するには、[元のフォントを埋め込む](/slides/ja/cpp/embedded-font/) か、メトリック的に互換性のある既定およびフォールバック ファミリーを選択してください。

**プレゼンテーションで使用されているすべてのフォントが埋め込まれている場合、既定フォントを設定する意味はありますか？**

多くの場合必要ありません。埋め込まれたフォントは外観の一貫性を保証します。ただし、埋め込みサブセットに含まれない文字や、埋め込みフォントと非埋め込みテキストが混在するファイルに対しては、既定フォントが安全ネットとして機能します。