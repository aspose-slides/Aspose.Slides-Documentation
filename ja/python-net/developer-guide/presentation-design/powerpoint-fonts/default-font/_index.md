---
title: Python でプレゼンテーションのデフォルトフォントをカスタマイズする
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/python-net/default-font/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python でデフォルトフォントを設定し、PowerPoint（PPT、PPTX）および OpenDocument（ODP）から PDF、XPS、画像への正しい変換を実現します。"
---

## **プレゼンテーションのレンダリングのためのデフォルトフォントの使用**
Aspose.Slides を使用すると、プレゼンテーションを PDF、XPS、サムネイルにレンダリングする際のデフォルトフォントを設定できます。本記事では、DefaultRegular Font と DefaultAsian Font をデフォルトフォントとして定義する方法を示します。以下の手順に従って、Aspose.Slides for Python via .NET API を使用して外部ディレクトリからフォントをロードしてください：

1. LoadOptions のインスタンスを作成します。
2. DefaultRegularFont を目的のフォントに設定します。以下の例では Wingdings を使用しています。
3. DefaultAsianFont を目的のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
4. Presentation を使用し、ロードオプションを設定してプレゼンテーションをロードします。
5. 現在、スライドのサムネイル、PDF、XPS を生成して結果を確認します。

```py
import aspose.slides as slides

# デフォルトのレギュラルフォントとアジアフォントを定義するためにロードオプションを使用する# デフォルトのレギュラルフォントとアジアフォントを定義するためにロードオプションを使用する
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# プレゼンテーションをロードする
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # スライドのサムネイルを生成する
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF を生成する
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS を生成する
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **よくある質問**

**default_regular_font と default_asian_font は正確に何に影響しますか—エクスポートだけですか、それともサムネイル、PDF、XPS、HTML、SVG も影響しますか？**

それらはすべてのサポート対象出力のレンダリングパイプラインに参加します。これにはスライドのサムネイル、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/python-net/convert-powerpoint-to-png/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、および[SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲット間で同じレイアウトとグリフ解決ロジックを使用しているためです。

**レンダリングせずに PPTX を単に読み込んで保存するだけの場合、デフォルトフォントは適用されますか？**

いいえ。テキストを測定し描画する必要がある場合にのみデフォルトフォントが重要です。プレゼンテーションを単純にオープンして保存するだけでは、保存されたフォントランやファイルの構造は変更されません。デフォルトフォントは、テキストをレンダリングまたは再フローする操作時に使用されます。

**独自のフォントフォルダーを追加したり、メモリからフォントを供給したりすると、デフォルトフォントを選択する際に考慮されますか？**

はい。[カスタムフォントソース](/slides/ja/python-net/custom-font/) により、エンジンが使用できる利用可能なフォントファミリーとグリフのカタログが拡張されます。デフォルトフォントおよび任意の[fallback ルール](/slides/ja/python-net/fallback-font/) はこれらのソースを優先して解決され、サーバーやコンテナ上でのカバレッジがより信頼性の高いものになります。

**デフォルトフォントはテキストメトリクス（カーニング、アドバンス）に影響し、結果として改行や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング中の改行、折り返し、ページ割り付けが変わる可能性があります。レイアウトの安定性を保つには、[元のフォントを埋め込む](/slides/ja/python-net/embedded-font/)か、メトリック的に互換性のあるデフォルトおよびフォールバックファミリーを選択してください。

**プレゼンテーションで使用されるすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合不要です。なぜなら[埋め込みフォント](/slides/ja/python-net/embedded-font/) が既に一貫した外観を保証するからです。ただし、埋め込みサブセットに含まれない文字や、埋め込みテキストと非埋め込みテキストが混在するファイルに対しては、デフォルトフォントが安全策として役立ちます。