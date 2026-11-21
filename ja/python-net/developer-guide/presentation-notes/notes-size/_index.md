---
title: Python でノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/python-net/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- ハンドアウトサイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Python
- Aspose.Slides
description: ".NET 経由で Python 用 Aspose.Slides のノートページの寸法を読み取り変更し、向きを切り替えて保存されたサイズを検証し、ノートやハンドアウトを PDF と画像にエクスポートします。"
---
## **概要**

[Presentation.notes_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/notes_size/) を使用してプレゼンテーションのノートページ設定にアクセスします。これは [NotesSize](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notessize/) オブジェクトを返し、その [size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notessize/size/) プロパティは書き込み可能です。設定オブジェクト自体は読み取り専用ですが、size プロパティに新しい寸法を割り当てることができます。

幅と高さは **ポイント** で指定され、1インチは 72 ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチに相当します。これらの設定は個々のスライドのノートではなく、プレゼンテーション全体に適用されます。

| 設定 | 目的 |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/notes_size/) | ノートページのサイズとハンドアウトエクスポートで使用されるページサイズを制御します。 |
| [Presentation.slide_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slide_size/) | 通常のプレゼンテーションスライドのサイズを [SlideSize](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesize/) を介して制御します。 |

どちらかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。通常のスライドのサイズ変更については、[Slide Size](/slides/ja/python-net/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポートの例では、スピーカーノートを含むスライドが少なくとも1枚あるプレゼンテーションを使用してください。各例は個別に実行可能です。

## **ノートページのサイズと向きの取得**

幅と高さを読み取り、比較して向きを判断します。幅が大きいページは横向き（ランドスケープ）、高さが大きいページは縦向き（ポートレート）、寸法が同じ場合は正方形です。この例では標準用紙サイズを前提せず、実際の寸法（ポイント）を出力します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **用紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、現在の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両辺の長さが保持されます。下記の条件は、すでに横向きのページが縦向きに戻されることを防ぎ、正方形のページは変更しません。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

縦向きの場合は、`size.width > size.height` のときに同様の代入を使用します。用紙サイズも変更したい場合以外は、A4 や Letter の寸法を置き換えないでください。

## **カスタムノートページサイズの設定と検証**

幅と高さを同時に割り当て、次に [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) でプレゼンテーションを書き出します。この例では 900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存したファイルを再度開いて永続化された値を確認します。比較では浮動小数点値に対し 0.01 ポイントの許容誤差を許容しますが、すべてのファイル形式での精度を保証するものではありません。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

期待される結果は `900 x 600 points` および `Size preserved: True` です。新たに開いたプレゼンテーションを確認することで、保存されたファイルが検証され、メモリ上の設定だけではありません。

## **ノートとハンドアウトのエクスポート**

ページ寸法はノートやハンドアウトレイアウトの利用可能領域を定義しますが、それだけでレイアウトが有効になるわけではありません。エクスポートオプションも設定してください。通常のスライドのエクスポートはスライドの寸法を引き続き使用します。

### **ノートを PDF と PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notescommentslayoutingoptions/) を [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) に割り当てて、PDF にノートを含めます。この例では、[Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) と [RenderingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notespositions/) モードはノートを 1 ページに収めます。収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。以下で使用する 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を表し、ピクセルはラスタ出力を表し、寸法はレンダリングスケールにも依存します。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

長いノートを含む PDF エクスポートでは、[BOTTOM_FULL](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notespositions/) を使用すると必要に応じて追加ページが作成されます。上記の単一スライド画像呼び出しではこのモードはサポートされていないため使用しないでください。サイズ変更後は、ノートが切り取られていないか、既存の notes‑master オブジェクトの配置を確認してください。ページ寸法だけを変更するだけでは、すべてのコンテンツが収まる保証にはなりません。ノートのエクスポートの詳細については、[Convert PowerPoint to PDF with Notes](/slides/ja/python-net/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **ハンドアウトを PDF にエクスポート**

1 ページに複数のスライドサムネイルを配置するには [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handoutlayoutingoptions/) を使用します。次の例では 900 × 600 ポイントのページを設定し、[HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handouttype/) を使用してページあたり最大 4 枚のスライドを配置します。水平プリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

ページサイズを変更すると、ハンドアウトグリッドの利用可能領域が変わりますが、元のスライドの寸法は変わりません。ハンドアウト画像を取得するには、個々のスライドの画像メソッドではなく、ハンドアウトレイアウトで [Presentation.get_images](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/) を使用してください。Aspose.Slides では、プレゼンテーションレベルのハンドアウトレンダリングはノートページの寸法を使用し、個別スライドの画像呼び出しはハンドアウトページを生成しません。レイアウトオプションについては、[Handout Mode](/slides/ja/python-net/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷された用紙サイズを区別して管理してください：

- **Presentation viewers:** ビューアは独自のレイアウトルールでノートを表示または印刷できます。他のアプリケーションがファイルを保存した場合は、再度開いて寸法を確認してください。そのアプリケーションの形式変換が寸法を正規化する可能性があります。
- **Export formats:** 上記のノートおよびハンドアウト PDF の例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、ポイントの小数値は画像出力時に丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **Printer drivers:** 用紙選択、 自動回転、 ページに合わせる設定により、プレゼンテーションや PDF に保存された寸法を変更せずに実際の出力が変わることがあります。特定の用紙サイズの場合は、プリンタ設定を合わせ、印刷プレビューを確認してください。

## **FAQ**

**特定のスライドだけのノートサイズを設定できますか？**

ノートページのサイズはプレゼンテーションレベルの設定です。個々のスライドは異なるノート内容を持つことができますが、このプロパティではスライドごとに別々のページサイズを指定できません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果が異なるサイズになるのはなぜですか？**

まず、保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。サイズが変わっている場合は、他のアプリケーションで保存または変換した際にページ設定が変更されたか確認します。変更がなければ、エクスポートレイアウト、画像スケール、ビューア設定、プリンタ用紙の選択を確認してください。