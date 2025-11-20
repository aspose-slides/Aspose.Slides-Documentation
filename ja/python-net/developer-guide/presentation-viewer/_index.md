---
title: Pythonでプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/python-net/presentation-viewer/
keywords:
- プレゼンテーションの表示
- プレゼンテーションビューア
- プレゼンテーションビューアの作成
- PPTの表示
- PPTXの表示
- ODPの表示
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でカスタム プレゼンテーション ビューアを作成する方法を学びます。Microsoft PowerPoint やその他のオフィス ソフトウェアを使用せずに、PowerPoint (PPTX、PPT) および OpenDocument (ODP) ファイルを簡単に表示できます。"
---

## **概要**

Aspose.Slides for Python はスライド付きのプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者がスライドを好みの画像ビューアで画像として表示したり、カスタム プレゼンテーション ビューアで使用したりする必要がある場合があります。そのようなケースでは、Aspose.Slides を使用して個々のスライドを画像としてエクスポートできます。本記事では、その方法を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. ファイル ストリームを開きます。
4. スライドを SVG 画像としてファイル ストリームに保存します。
```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```


## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 参照したスライドのサムネイル画像を希望のスケールで作成します。
4. サムネイル画像を希望の画像形式で保存します。
```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **ユーザー定義サイズでスライドのサムネイルを作成する**

ユーザー定義のサイズでスライドのサムネイル画像を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 参照したスライドのサムネイル画像を指定されたサイズで生成します。
4. サムネイル画像を希望の画像形式で保存します。
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **スライドのサムネイルにスピーカーノートを含める**

Aspose.Slides を使用してスピーカーノート付きのスライドサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) クラスのインスタンスを作成します。
2. `RenderingOptions.slides_layout_options` プロパティを使用してスピーカーノートの位置を設定します。
3. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
4. インデックスでスライドへの参照を取得します。
5. レンダリング オプションを使用して、参照したスライドのサムネイル画像を生成します。
6. サムネイル画像を希望の画像形式で保存します。
```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```


## **ライブ例**

Aspose.Slides API で実装できることを確認するには、無料アプリの[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) を試してください。

[![オンライン PowerPoint ビューア](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **よくある質問**

**ASP.NET Web アプリケーションにプレゼンテーションビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを [画像](/slides/ja/python-net/convert-powerpoint-to-png/) または [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装してインタラクティブな体験を提供できます。

**カスタム .NET ビューア内でスライドを表示する最適な方法は何ですか？**

推奨される方法は、Aspose.Slides を使用して各スライドを [画像](/slides/ja/python-net/convert-powerpoint-to-png/)（例: PNG または SVG）としてレンダリングするか、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドがある大規模なプレゼンテーションはどのように扱いますか？**

大規模なデッキの場合、スライドの遅延読み込みやオンデマンドレンダリングを検討してください。つまり、ユーザーがスライドに移動したときにのみコンテンツを生成し、メモリ使用量とロード時間を削減します。