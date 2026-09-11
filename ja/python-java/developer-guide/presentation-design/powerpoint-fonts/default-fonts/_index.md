---
title: Python via Javaでデフォルトプレゼンテーションフォントを指定する
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/python-java/default-font/
keywords:
- デフォルトフォント
- 通常フォント
- 標準フォント
- アジアフォント
- PDF エクスポート
- XPS エクスポート
- 画像エクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides でデフォルトフォントを設定し、PowerPoint (PPT、PPTX) および OpenDocument (ODP) の PDF、XPS、画像への正しい変換を保証します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションがレンダリングされる際に使用されるデフォルトフォントを指定できます。これは、スライドサムネイルを生成したり、PDF や XPS などの形式にプレゼンテーションをエクスポートしたりする場合に便利です。デフォルトフォントは、プレゼンテーションがロードされる前に [LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) を介して構成されます。

[setDefaultRegularFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) メソッドは通常テキストのデフォルトフォントを定義し、[setDefaultAsianFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) はアジアテキストのデフォルトフォントを定義します。これらのオプションが設定された後、指定されたフォントを使用してプレゼンテーションをロードおよびレンダリングできます。

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**

Aspose.Slides は、プレゼンテーションを PDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。このセクションでは、Python via Java 用の Aspose.Slides を使用して、通常テキストとアジアテキストのデフォルトフォントを定義する方法を示します:

1. [LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) のインスタンスを作成します。
1. [setDefaultRegularFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) を使用して希望のフォントを指定します。以下の例では Wingdings を使用しています。
1. [setDefaultAsianFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) を使用して希望のフォントを指定します。以下の例でも Wingdings を使用しています。
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を使用し、ロードオプションとともにプレゼンテーションをロードします。
1. スライドサムネイル、PDF、XPS を生成して結果を確認します。

以下の例はこれらの手順を実装しています：

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# デフォルトの通常フォントとアジアフォントを定義するためにロードオプションを使用します。
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# プレゼンテーションをロードします。
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # スライドのサムネイルを生成します。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 画像をディスクに保存します。
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # PDF を生成します。
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # XPS ドキュメントを生成します。
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **よくある質問**

**デフォルトの通常フォントとアジアフォントは正確には何に影響しますか—エクスポートのみですか、それともサムネイル、PDF、XPS、HTML、SVG にも影響しますか？**

デフォルトフォントはサポートされているすべての出力に対するレンダリングパイプラインに参加します。これにはスライドサムネイル、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-java/convert-powerpoint-to-xps/)、[ラスタ画像](/slides/ja/python-java/convert-powerpoint-to-png/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)、および [SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/) が含まれます。Aspose.Slides はこれらのターゲット全体で同じレイアウトとグリフ解決ロジックを使用しているためです。

**単に PPTX を読み込んで保存するだけで、レンダリングせずにデフォルトフォントは適用されますか？**

いいえ。デフォルトフォントはテキストの測定と描画が必要な場合にのみ影響します。プレゼンテーションを単に開いて保存するだけでは、保存されているフォントランやファイル構造は変更されません。デフォルトフォントはテキストをレンダリングまたは再フローする操作時に使用されます。

**独自のフォントフォルダを追加したり、メモリからフォントを提供したりした場合、それらはデフォルトフォントの選択時に考慮されますか？**

はい。[Custom font sources](/slides/ja/python-java/custom-font/) は利用可能なファミリとグリフのカタログを拡張します。デフォルトフォントとすべての [fallback rules](/slides/ja/python-java/fallback-font/) はまずこれらのソースを参照して解決され、サーバーやコンテナ上でのカバレッジがより信頼性の高いものになります。

**デフォルトフォントはテキストのメトリクス（カーニング、字幅）に影響し、行間や折り返しに影響しますか？**

はい。フォントを変更するとグリフのメトリクスが変わり、レンダリング時の改行、折り返し、ページ割り付けに影響を与える可能性があります。レイアウトの安定性を保つために、[embed the original fonts](/slides/ja/python-java/embedded-font/) を使用するか、メトリクス的に互換性のあるデフォルトおよびフォールバックファミリを選択してください。

**プレゼンテーションで使用されているすべてのフォントが埋め込まれている場合、デフォルトフォントを設定する意味はありますか？**

多くの場合必要ありません。なぜなら、[embedded fonts](/slides/ja/python-java/embedded-font/) はすでに一貫した外観を保証しているからです。ただし、埋め込みサブセットでカバーされていない文字や、埋め込みテキストと非埋め込みテキストが混在しているファイルに対しては、デフォルトフォントが安全策として役立ちます。