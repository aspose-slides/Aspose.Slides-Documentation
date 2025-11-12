---
title: Pythonでプレゼンテーションのデフォルトフォントをカスタマイズ
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/python-net/default-font/
keywords:
- デフォルトフォント
- レギュラーフォント
- 標準フォント
- アジアフォント
- PDF エクスポート
- XPS エクスポート
- 画像エクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python のデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）から PDF、XPS、画像への変換を適切に行えるようにします。"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、PDF、XPS、またはサムネイルへのプレゼンテーションのレンダリング時にデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用する DefaultRegular Font と DefaultAsian Font の定義方法を示します。以下の手順に従って、.NET API 経由で Aspose.Slides for Python を使用し、外部ディレクトリからフォントをロードしてください。

1. LoadOptions のインスタンスを作成します。  
2. DefaultRegularFont を目的のフォントに設定します。以下の例では Wingdings を使用しています。  
3. DefaultAsianFont を目的のフォントに設定します。このサンプルでも Wingdings を使用しています。  
4. Presentation を使用してプレゼンテーションをロードし、ロードオプションを設定します。  
5. スライドのサムネイル、PDF、XPS を生成して結果を確認します。

上記の実装例を以下に示します。

```py
import aspose.slides as slides

# デフォルトのレギュラーフォントとアジアフォントを定義するためにロードオプションを使用する # デフォルトのレギュラーフォントとアジアフォントを定義するためにロードオプションを使用する
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# プレゼンテーションをロード
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # スライドサムネイルを生成
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF を生成
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS を生成
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**default_regular_font と default_asian_font は正確には何に影響しますか？エクスポートだけですか、サムネイル、PDF、XPS、HTML、SVG にも影響しますか？**

これらはすべてのサポート対象出力のレンダリング パイプラインに参加します。スライドサムネイル、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/python-net/convert-powerpoint-to-png/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、および [SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) が対象です。Aspose.Slides はこれらのターゲットで同じレイアウトとグリフ解決ロジックを使用します。

**単に PPTX を読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

適用されません。デフォルトフォントはテキストの測定と描画が必要なときにのみ影響します。プレゼンテーションをそのまま開いて保存するだけでは、保存されているフォントランやファイル構造は変更されません。デフォルトフォントは、テキストをレンダリングまたは再フローする操作時に使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりすると、デフォルトフォントの選択に考慮されますか？**

考慮されます。[カスタムフォント ソース](/slides/ja/python-net/custom-font/) により、エンジンが使用できるフォント ファミリとグリフのカタログが拡張されます。デフォルトフォントおよび任意の [フォールバック ルール](/slides/ja/python-net/fallback-font/) はまずこれらのソースに対して解決され、サーバーやコンテナ上でのカバレッジが向上します。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、結果として改行や折り返しが変わりますか？**

影響します。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行、折り返し、ページ分割が変化する可能性があります。レイアウトの安定性を保つために、[元のフォントを埋め込む](/slides/ja/python-net/embedded-font/) か、メトリック的に互換性のあるデフォルトおよびフォールバック ファミリを選択してください。

**プレゼンテーション内のすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合不要です。[埋め込みフォント](/slides/ja/python-net/embedded-font/) がすでに一貫した外観を保証します。ただし、埋め込まれたサブセットに含まれない文字や、埋め込みフォントと非埋め込みテキストが混在するファイルに対しては、デフォルトフォントが安全策として機能します。