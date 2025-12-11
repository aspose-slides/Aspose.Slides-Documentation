---
title: C++ でデフォルトのプレゼンテーション フォントを指定する
linktitle: デフォルト フォント
type: docs
weight: 30
url: /ja/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）を PDF、XPS、画像へ正しく変換できるようにします。"
---

## **デフォルトフォントを設定する**
Aspose.Slides for C++ を使用すると、PowerPoint プレゼンテーションのデフォルトフォントを設定できます。新しいメソッド [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) が [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) クラスに追加されました。これにより、プレゼンテーションを再読み込みせずに、さまざまな形式で保存する際に、欠落しているフォントの代わりに使用されるデフォルトフォントを設定できます。

以下のコードスニペットは、異なるデフォルトレギュラーフォントでプレゼンテーションを [HTML](https://docs.fileformat.com/web/html/) と [PDF](https://docs.fileformat.com/pdf/) に保存する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides では、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングする際のデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用する DefaultRegular フォントと DefaultAsian フォントの定義方法を示します。以下の手順に従って、Aspose.Slides for C++ API を使用し、外部ディレクトリからフォントを読み込んでください。

1. LoadOptions のインスタンスを作成します。
1. DefaultRegularFont を希望のフォントに設定します。以下の例では Wingdings を使用しています。
1. DefaultAsianFont を希望のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
1. Presentation を使用し、ロードオプションを設定してプレゼンテーションを読み込みます。
1. これで、スライドのサムネイル、PDF、XPS を生成し、結果を確認します。

上記の実装は以下に示します。
```cpp
// ロードオプションを使用してデフォルトのレギュラーフォントとアジアフォントを指定する
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


## **FAQ**

**DefaultRegularFont と DefaultAsianFont は正確に何に影響しますか—エクスポートのみですか、それともサムネイル、PDF、XPS、HTML、SVG にも影響しますか？**

これらはサポートされているすべての出力に対するレンダリングパイプラインに参加します。これにはスライドサムネイル、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[raster images](/slides/ja/cpp/convert-powerpoint-to-png/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、および[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用しているためです。

**単に PPTX を読み取って保存するだけで、レンダリングを行わない場合でもデフォルトフォントは適用されますか？**

いいえ。テキストを測定して描画する必要がある場合にデフォルトフォントが重要になります。プレゼンテーションを単に開いて保存するだけでは、保存されたフォントランやファイル構造は変更されません。デフォルトフォントは、テキストをレンダリングまたは再配置する操作中に使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりした場合、デフォルトフォントの選択時に考慮されますか？**

はい。[カスタム フォント ソース](/slides/ja/cpp/custom-font/) は、エンジンが使用できるファミリとグリフのカタログを拡張します。デフォルトフォントおよび任意の [フォールバック ルール](/slides/ja/cpp/fallback-font/) は、まずこれらのソースに対して解決され、サーバーやコンテナ上でのカバレッジが向上します。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、結果として改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行、折り返し、ページ分割が変わる可能性があります。レイアウトの安定性を保つために、[埋め込みフォント](/slides/ja/cpp/embedded-font/) を使用するか、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリを選択してください。

**プレゼンテーションで使用されているすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合必要ありません。[埋め込みフォント](/slides/ja/cpp/embedded-font/) は外観の一貫性をすでに保証しています。ただし、埋め込みサブセットに含まれない文字や、埋め込みフォントと非埋め込みフォントが混在するファイルの場合、デフォルトフォントは安全策として役立ちます。