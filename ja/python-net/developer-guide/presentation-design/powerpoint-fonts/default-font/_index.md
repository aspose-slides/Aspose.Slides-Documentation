---
title: デフォルトフォント
type: docs
weight: 30
url: /python-net/default-font/
keywords: "フォント, デフォルトフォント, プレゼンテーションのレンダリング PowerPoint プレゼンテーション Python, Aspose.Slides for Python via .NET"
description: "Python における PowerPoint デフォルトフォント"
---

## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slides を使用すると、PDF、XPS またはサムネイルにプレゼンテーションをレンダリングする際のデフォルトフォントを設定できます。この資料では、デフォルトフォントとして使用するための DefaultRegular Font と DefaultAsian Font の定義方法を説明します。以下の手順に従って、Aspose.Slides for Python via .NET API を使用して外部ディレクトリからフォントを読み込んでください。

1. LoadOptions のインスタンスを作成します。
1. DefaultRegularFont を希望のフォントに設定します。以下の例では、Wingdings を使用しています。
1. DefaultAsianFont を希望のフォントに設定します。以下のサンプルでも Wingdings を使用しています。
1. プレゼンテーションを読み込むために、Presentation を使用し、読み込みオプションを設定します。
1. これで、スライドのサムネイル、PDF および XPS を生成して結果を確認します。

上記の実装は以下の通りです。

```py
import aspose.slides as slides

# デフォルトのレギュラーとアジアフォントを定義するために読み込みオプションを使用する
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# プレゼンテーションを読み込む
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # スライドのサムネイルを生成する
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF を生成する
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS を生成する
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```