---
title: Java 経由で Python 用のノートページサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/python-java/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- 配布資料サイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Java 経由で Python 用 Aspose.Slides のノートページ寸法を読み取り、変更し、向きを切り替え、保存されたサイズを検証し、ノートまたは配布資料を PDF や画像にエクスポートします。"
---
## **概要**

Presentation.getNotesSize を使用して、プレゼンテーションのノートページ設定にアクセスします。これは、ページの寸法を設定する [setSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notessize/#setSize) メソッドを持つ [NotesSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notessize/) オブジェクトを返します。設定オブジェクト自体は置き換えられませんが、このメソッドを使用して新しい寸法を割り当てることができます。

幅と高さは **points**（ポイント）で指定され、1インチ＝72ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチに相当します。これらの設定は個々のスライドのノートではなく、プレゼンテーション全体に適用されます。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getNotesSize) | ノートページの寸法と配布資料エクスポート時に使用されるページ寸法を制御します。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlideSize) | [SlideSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/) を介して通常のプレゼンテーションスライドの寸法を制御します。 |

いずれかの設定を変更しても、もう一方は自動的には変更されません。ノートページの向きを変更しても通常のスライドは回転しません。通常のスライドをサイズ変更するには、[スライド サイズ](/slides/ja/python-java/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポート例では、スピーカーノートを含むスライドが少なくとも 1 枚あるプレゼンテーションを使用してください。各例は個別に実行できます。

## **ノートページのサイズと向きの取得**

幅と高さを読み取り、比較して向きを判定します。幅が大きいページは横向き、縦が大きいページは縦向き、サイズが等しい場合は正方形です。この例は標準用紙サイズを想定せず、ポイント単位で実際の寸法を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **用紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、既存の幅と高さを入れ替えます。これによりカスタム用紙サイズの両側の長さが保持されます。以下の条件は、すでに横向きのページが縦向きに戻されることを防ぎ、正方形のページは変更しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

縦向きの場合は、`size.getWidth() > size.getHeight()` のときに同様の代入を行います。A4 や Letter のサイズを代入しない限り、用紙サイズは変更されません。

## **カスタムノートページサイズの設定と検証**

両方の寸法を同時に割り当て、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) でプレゼンテーションを書き出します。この例は 900 × 600 ポイントの横向きページを設定し、PPTX として保存した後、再度開いて永続化された値を確認します。比較は浮動小数点の誤差を考慮し 0.01 ポイントの許容範囲を設けていますが、すべてのファイル形式での精度を保証するものではありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

期待される結果は `900.0 x 600.0 points` および `Size preserved: True` です。新しく開いたプレゼンテーションを確認することで、保存されたファイルが正しく反映されているかを検証します。

## **ノートとハンドアウトのエクスポート**

ページ寸法はノートや配布資料レイアウトで使用できる領域を定義しますが、これだけでレイアウトが有効になるわけではありません。エクスポートオプションも設定してください。通常のスライドのエクスポートはスライド寸法を使用し続けます。

### **ノートを PDF および PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) を [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) に割り当てると、PDF にノートが含まれます。この例では、[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) と [RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングしています。

[BottomTruncated](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/) モードはノートを 1 ページに収め、収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。以下で使用した 1 × 1 の画像スケールの場合、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何学的寸法を表し、ピクセルはレンダリングスケールに依存するラスター出力を表します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

長いノートを含む PDF エクスポートでは、[BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/) を使用すると必要に応じて追加ページが生成されます。このモードは、上記の単一スライド画像呼び出しではサポートされていないため使用しないでください。サイズ変更後は、クリッピングされたノートや既存の notes‑master オブジェクトの配置を確認してください。ページ寸法だけを変更しても、すべてのコンテンツが収まることは保証されません。ノートのエクスポートに関する詳細は、[Convert PowerPoint to PDF with Notes](/slides/ja/python-java/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **ハンドアウトを PDF にエクスポート**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handoutlayoutingoptions/) を使用すると、1 ページに複数のスライドサムネイルを配置できます。以下の例は 900 × 600 ポイントのページを設定し、[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handouttype/) を使用して最大 4 枚のスライドを横方向に配置します。水平方向のプリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

ページサイズを変更すると、ハンドアウトグリッドが利用できる領域が変わりますが、元のスライドの寸法は変わりません。ハンドアウト画像を取得する場合は、個々のスライドの画像メソッドではなく、ハンドアウトレイアウトで [Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) を使用してください。Aspose.Slides では、プレゼンテーションレベルのハンドアウトレンダリングがノートページ寸法を使用し、個別スライドの画像呼び出しはハンドアウトページを生成しません。レイアウトオプションについては、[Handout Mode](/slides/ja/python-java/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されているプレゼンテーションサイズ、エクスポートされたページサイズ、印刷時の用紙サイズはそれぞれ別々に扱います。

- **プレゼンテーションビューア:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。別のアプリケーションでファイルを保存した場合は、再度開いて寸法を確認してください。そのアプリケーションの形式変換が寸法を正規化することがあります。
- **エクスポート形式:** 上記のノートおよびハンドアウト PDF の例は設定されたページ寸法を使用します。ラスター画像は整数ピクセル寸法とレンダリングスケールを使用するため、端数のポイント値は画像出力時に丸められることがあります。通常のスライドをエクスポートするときはノートページサイズは適用されません。
- **プリンタードライバ:** 用紙の選択、自動回転、ページに合わせてサイズ調整する設定により、実際の印刷結果が変わりますが、プレゼンテーションや PDF に保存されている寸法は変わりません。特定の用紙サイズで印刷する場合は、プリンター設定を合わせ、印刷プレビューで確認してください。

## **FAQ**

**ノートサイズを特定のスライドだけに設定できますか？**

ノートページサイズはプレゼンテーションレベルの設定です。個々のスライドは異なるノートコンテンツを持てますが、このプロパティでスライドごとに別々のページサイズを指定することはできません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果がサイズ違いになるのはなぜですか？**

まず保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。変更があった場合は、別のアプリケーションで保存または変換した際にページ設定が変わった可能性があります。変更がなければ、エクスポートレイアウト、画像スケール、ビューア設定、プリンターの用紙選択を確認してください。