---
title: Pythonでプレゼンテーションビュアーを作成する
linktitle: プレゼンテーションビュアー
type: docs
weight: 50
url: /ja/python-net/presentation-viewer/
keywords:
- プレゼンテーションを見る
- プレゼンテーションビュアー
- プレゼンテーションビュアーを作成する
- PPTを見る
- PPTXを見る
- ODPを見る
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でカスタム プレゼンテーション ビューアーを作成する方法を学びます。Microsoft PowerPoint やその他のオフィス ソフトウェアなしで、PowerPoint（PPTX、PPT）および OpenDocument（ODP）ファイルを簡単に表示できます。"
---

## **概要**

Aspose.Slides for Python はスライドを含むプレゼンテーションファイルの作成に使用されます。これらのスライドはたとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。しかし、開発者はスライドを好みの画像ビューアで画像として表示したり、カスタム プレゼンテーション ビューアで使用したりしたい場合があります。そのようなケースでは、Aspose.Slides を使用して個々のスライドを画像としてエクスポートできます。本記事ではその手順を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. ファイルストリームを開きます。
4. スライドを SVG 画像としてファイルストリームに保存します。

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像の生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 目的のスケールで参照したスライドのサムネイル画像を作成します。
4. 好みの画像形式でサムネイル画像を保存します。

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

ユーザー定義サイズでスライドのサムネイル画像を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 指定したサイズで参照したスライドのサムネイル画像を生成します。
4. 好みの画像形式でサムネイル画像を保存します。

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

## **スピーカーノート付きのスライドサムネイルを作成する**

スピーカーノート付きのスライドサムネイルを生成するには、以下の手順に従います。

1. [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) クラスのインスタンスを作成します。
2. `RenderingOptions.slides_layout_options` プロパティを使用してスピーカーノートの位置を設定します。
3. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
4. インデックスでスライドへの参照を取得します。
5. レンダリング オプションを使用して参照したスライドのサムネイル画像を生成します。
6. 好みの画像形式でサムネイル画像を保存します。

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

Aspose.Slides API を使用して実装できることを確認するには、[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 無料アプリを試してください：

[![オンライン PowerPoint ビューアー](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **よくある質問**

**ASP.NET Web アプリケーションにプレゼンテーションビュアーを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを[画像](/slides/ja/python-net/convert-powerpoint-to-png/)や[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装してインタラクティブな体験を提供できます。

**カスタム .NET ビューアー内でスライドを表示する最適な方法は何ですか？**

推奨アプローチは、各スライドを[画像](/slides/ja/python-net/convert-powerpoint-to-png/)（例: PNG または SVG）としてレンダリングするか、Aspose.Slides を使用して[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドを含む大きなプレゼンテーションはどう扱いますか？**

大規模なデッキの場合、スライドの遅延読み込みまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドに移動したときにのみその内容を生成し、メモリ使用量とロード時間を削減します。