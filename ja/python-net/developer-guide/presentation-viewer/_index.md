---
title: Pythonでプレゼンテーションビューアーを作成する
linktitle: プレゼンテーションビューアー
type: docs
weight: 50
url: /ja/python-net/developer-guide/presentation-viewer/
keywords:
- プレゼンテーションの表示
- プレゼンテーションビューアー
- プレゼンテーションビューアーの作成
- PPTの表示
- PPTXの表示
- ODPの表示
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でカスタムプレゼンテーションビューアーを作成する方法を学びます。Microsoft PowerPoint や他のオフィスソフトウェアなしで、PowerPoint（PPTX、PPT）および OpenDocument（ODP）ファイルを簡単に表示できます。"
---

## **概要**

Aspose.Slides for Python は、スライドを含むプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者がスライドを画像として好みの画像ビューアーで表示したり、カスタム プレゼンテーションビューアーで使用したりする必要がある場合があります。そのようなケースでは、Aspose.Slides を使用して個々のスライドを画像としてエクスポートできます。本記事では、その手順を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従います。

1. `Presentation` クラスのインスタンスを作成します。  
   <https://reference.aspose.com/slides/python-net/aspose.slides/presentation/>
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

Aspose.Slides は、スライドのサムネイル画像を生成する機能を提供します。スライドのサムネイルを生成するには、以下の手順に従います。

1. `Presentation` クラスのインスタンスを作成します。  
   <https://reference.aspose.com/slides/python-net/aspose.slides/presentation/>
2. インデックスでスライドへの参照を取得します。
3. 必要なスケールで参照したスライドのサムネイル画像を作成します。
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

ユーザーが指定したサイズでスライドのサムネイル画像を作成するには、以下の手順に従います。

1. `Presentation` クラスのインスタンスを作成します。  
   <https://reference.aspose.com/slides/python-net/aspose.slides/presentation/>
2. インデックスでスライドへの参照を取得します。
3. 指定した寸法で参照したスライドのサムネイル画像を生成します。
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

## **スピーカーノート付きサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きのスライドサムネイルを生成するには、以下の手順に従います。

1. `RenderingOptions` クラスのインスタンスを作成します。  
   <https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/>
2. `RenderingOptions.slides_layout_options` プロパティを使用して、スピーカーノートの位置を設定します。
3. `Presentation` クラスのインスタンスを作成します。  
   <https://reference.aspose.com/slides/python-net/aspose.slides/presentation/>
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

[Aspose.Slides Viewer](https://products.aspose.app/slides/viewer/) の無料アプリを試して、Aspose.Slides API で実装できることをご確認ください。

[![オンライン PowerPoint ビューアー](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**ASP.NET Web アプリケーションにプレゼンテーションビューアーを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを [images](/slides/ja/python-net/convert-powerpoint-to-png/) や [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装でき、インタラクティブな体験を提供できます。

**カスタム .NET ビューアー内でスライドを表示する最適な方法は何ですか？**

推奨アプローチは、各スライドを [image](/slides/ja/python-net/convert-powerpoint-to-png/)（例: PNG または SVG）としてレンダリングするか、Aspose.Slides を使用して [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナ内に表示することです。

**多数のスライドを含む大規模なプレゼンテーションはどのように処理すべきですか？**

大規模なデッキの場合は、スライドの遅延ロードまたはオンデマンドレンダリングを検討してください。ユーザーがスライドに移動したときにそのスライドのコンテンツだけを生成することで、メモリ使用量と読み込み時間を削減できます。