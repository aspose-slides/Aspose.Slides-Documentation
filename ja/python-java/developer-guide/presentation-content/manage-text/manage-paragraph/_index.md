---
title: Python via Java で PowerPoint テキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - テキストの追加
  - 段落の追加
  - テキストの管理
  - 段落の管理
  - 箇条書きの管理
  - 段落インデント
  - ハンギングインデント
  - 段落箇条書き
  - 番号付きリスト
  - 箇条書きリスト
  - 段落プロパティ
  - HTML のインポート
  - テキストから HTML へ
  - 段落から HTML へ
  - 段落から画像へ
  - テキストから画像へ
  - 段落のエクスポート
  - PowerPoint
  - プレゼンテーション
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定の方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java は、テキストをテキストフレーム、段落、ポーションの階層として表現します：

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) はシェイプ内のテキストコンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) はテキストフレーム内の 1 つの段落を表し、ポーションおよび段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) は段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

シェイプのテキストフレーム内に段落を作成し、ポーションを使用して個々のテキストランに書式設定を適用します。このセクションでは、各段落内で複数のポーションを組み合わせ、異なる色、フォントサイズ、スタイルを適用する方法を示します。

### **複数のポーションで段落を作成する**

以下の Python サンプルは、[Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions) が返すコレクション内に 3 つの段落を作成し、各段落に 3 つのテキストランを含めます。デフォルトの段落と空のポーションを再利用し、残りの段落とポーションを追加します。書式設定は [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) を通じて適用されます。各段落の最初のポーションは赤、太字、15pt、2 番目は青、斜体、18pt、3 番目は既定の書式を保持します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()

    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())

    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)

    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")

            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **箇条書きおよび番号付きリストの作成**

シンボル、番号、またはカスタム画像で段落テキストをリスト化します。このセクションの例では、箇条書きの書式設定、多層リスト、カスタム開始番号を取り上げます。

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けにより、関連項目を簡単に把握できます。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) を介して定義します。

この Python サンプルは、同じテキストフレームにシンボル箇条書きと番号付き項目の両方を追加します。[BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) で箇条書きの種類を選択し、[BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) でシンボルを指定し、[BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) で番号付けスタイルを選択します。両方の項目は黒い箇条書きを使用し、高さは 100% に、段落インデントは 25pt に設定されています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)

    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **画像箇条書きの使用**

画像箇条書きを使用すると、シンボルや番号の代わりにカスタム画像を使用できます。

この Python サンプルは、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) として画像を追加し、段落の箇条書きとして使用します。[BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) で画像箇条書きを選択し、[BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) で画像を割り当てます。[BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) は 100% に設定され、段落テキストに対する相対サイズとなります：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **多層リストの作成**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) を設定して、リスト内の段落を異なるレベルに配置します。最上位レベルの深さは `0` です。

この Python サンプルは、[ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) の値を 0〜3 に設定し、1 つのテキストフレーム内に階層を作ります。各段落はシンボル箇条書きを使用し、[BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) で丸い箇条書きとハイフンを交互に設定して隣接レベルを区別します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)

    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)

    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)

    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **番号付きリスト項目をカスタム値で開始する**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) を使用して、番号付き段落の開始番号を設定できます。

この Python サンプルは、3 つの段落で [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) を番号付けに設定し、[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) の値をそれぞれ 2、3、7 に設定します。開始値は段落ごとに個別に構成され、表示番号がスキップされます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)

    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **段落のレイアウトと末尾プロパティの制御**

段落の余白とインデントを調整して、最初の行と折り返し行の位置を制御します。また、表示テキストのポーションとは別に段落末尾マークをフォーマットできます。

### **先頭行インデントの設定**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) メソッドを使用して、段落の先頭行インデントを制御します。この設定は段落左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動させたい場合は [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) を使用し、先頭行だけを移動させたい場合は [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) を使用します。

以下の例は、3 つの段落に同じ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 20pt と、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) をそれぞれ 0、20、40pt に設定します。先頭行は徐々に大きなオフセットで開始し、折り返し行は同じ左余白を保持します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)

    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落の先頭行インデント](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、先頭行が残りの行より左側に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) プロパティでこの効果を実現します。`Indent` に負の値を設定して、段落本文に対して先頭行を左に移動させます。

実際には、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) が段落本文の左位置を定義し、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) がその余白に対する先頭行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を組み合わせます。

この書式は、参考文献、引用、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある段落で便利です。

以下の Python サンプルは、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) を 40 と 60pt、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) をそれぞれ -20 と -30pt に設定します。各段落で先頭行は折り返し行の左側に開始し、2 番目の段落はより深いハンギングインデントになります：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落のハンギングインデント](hanging_indent.png)

### **段落末端ランプロパティの設定**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) メソッドは段落末端マークの書式設定を制御します。以下の例は、[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) を作成し、[BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) を 48pt、[BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) を Times New Roman に設定します。この書式を第2段落の末端マークに割り当て、表示テキストのポーションは変更しません：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)

    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)

    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **レンダリングされた行数のカウント**

行折り返しや行末の句読点に影響を与える段落ルールについては、[Control Line Breaking](/slides/ja/python-java/text-formatting/#control-line-breaking) と [Control Hanging Punctuation](/slides/ja/python-java/text-formatting/#control-hanging-punctuation) を参照してください。

[Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) を使用して、テキストレイアウト後に段落が占める行数（自動折り返しを含む）を取得できます。これは、プレゼンテーションテンプレートでテキスト長とレイアウトを確認する際に便利です。

段落は [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) の項目であり、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字の数だけを数えてもレンダリング行数は分かりません。

以下の例はテキストシェイプを作成し、その行数をカウントし、シェイプを狭めてからテキストを短い文字列に置き換えます。例では [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) で折り返しを有効にし、[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) で自動フィットを無効にして、シェイプ幅が折り返しを制御するようにしています。各測定は [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) を使用します。シェイプのサイズはポイント単位です。最後に別の段落を追加し、テキストフレーム全体の行数を合計します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

このテキストとサイズでシェイプを狭めると行数が増え、短い文字列に置き換えると減少します。正確なカウントはフォントの可用性と置換、フォントサイズ、余白、インデント、折り返し、オートフィット設定に左右されます。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナをはみ出すかどうかは判断できません。利用可能な高さ、行の高さ、段落と行の間隔、オートフィットの動作も影響します。折り返しが無効な場合、1 行だけでも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

HTML を使用してテキストをプレゼンテーションに取り込んだり、既存の段落を外部で使用できるようにエクスポートしたりできます。このセクションでは、テーブルセル内の段落を含む、個々の段落を画像としてレンダリングする方法も示します。

### **HTMLテキストを段落にインポートする**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

この Python サンプルはファイルから HTML を読み取り、マークアップを [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) に渡します。テキストフレームのデフォルト段落をクリアし、フレームにインポートされたコンテンツのみが含まれるようにします。矩形シェイプはスライドの各側に 10pt の余白を残します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)

        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **段落テキストをHTMLにエクスポートする**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) を使用して、選択した段落範囲を HTML としてエクスポートします。プレゼンテーションのテキストを Web サイトで再利用する場合、フォント、サイズ、テキストボックスのスタイルを引き継がずにローカルの強調表示だけを保持したいことがあります。その際は、[TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) を設定して、エクスポート時の書式継承の深さを制御します。

サンプルプレゼンテーション（[the sample presentation](text-inheritance.pptx)）をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには「Inherited text; explicit red 18pt」というテキストを含む 1 つのテキストシェイプがあります。入力は意図的に複数の書式レベルを使用しています。

- プレゼンテーションのデフォルトテキストスタイルは Calibri と 28pt を供給します。
- テキストフレームの第1レベルテキストスタイルは青文字とイタリックを供給します。
- 段落は太字を明示的に設定しています。
- 第2ポーション「explicit red 18pt」は赤文字と 18pt を明示的に設定しています。

以下の完全な例は、同じ段落を 3 回エクスポートします。[TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) をエクスポートメソッドに渡し、各結果を個別の UTF-8 HTML ファイルとして書き出します：

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

生成された HTML には、最初のポーション「Inherited text; 」に対する以下の CSS が含まれます。表は関連する宣言を示し、他の生成プロパティは簡潔さのために省略しています。

| 出力 | 最初のポーションに対する関連CSS | 外観 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri が利用可能な場合、28pt の青色・太字・イタリックテキスト |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 青色・太字・イタリックテキスト。フォントファミリとサイズはページまたはブラウザが供給 |
| `ParagraphOnly.html` | `font-weight:bold` | 太字テキスト。フォントファミリ、サイズ、色、イタリックはページまたはブラウザが供給 |

2 番目のポーションはすべての出力で `color:#ff0000`、`font-size:18pt`、`font-weight:bold` を保持します。`All` と `TextBox` ではイタリックも保持されますが、`ParagraphOnly` では保持されません。継承制限を設定しても、段落やポーションに明示的に割り当てられた書式は削除されません。

同じブラウザでファイルを開いて比較してください。制限モードの 2 つでは、欠落した CSS プロパティが宛先ページのスタイルまたはブラウザのデフォルトで解決されるため、最終的な外観は HTML の使用場所に依存します。

### **段落を画像としてレンダリングする**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) は個々の段落を直接レンダリングし、画像オブジェクトを返します。`save` メソッドでファイルまたはストリームに保存できます。包含シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) は、段落が親コレクションに存在しない、または有効なレンダリング境界がない、あるいはレンダリングできない場合に `None` を返すことがあります。保存する前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリングする**

例では、1 枚のスライドに 3 段落を含むテキストボックスが配置されたプレゼンテーションを使用します。

![3つの段落があるテキストボックス](paragraph_to_image_input.png)

以下の例はインデックス 1 の第2段落を選択し、スケールパラメータなしで [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) を呼び出します。シェイプに必要な段落が含まれていることと、レンダリングが画像を返すことを確認した上で、`save` メソッドで PNG 形式で保存します。`finally` ブロックで画像を破棄します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()

            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

結果:

![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリングする**

`scale_x` と `scale_y` パラメータを受け取る [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) のオーバーロードを使用して、横方向と縦方向のスケール係数を設定します。以下の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])

    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")

    paragraph_image = paragraph.getImage(scale_x, scale_y)

    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

スケール係数が `1` の場合、その軸はデフォルトのピクセルサイズを保持します。例えば、両方の係数を `2` にすると、幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保つには同等の係数を使用し、横方向と縦方向で異なる係数を設定すると出力が個別に伸縮します。

シェイプの塗りつぶし、枠線、その他の視覚コンテキストを含める必要がある場合は、[Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) を使用してシェイプ全体をレンダリングするのが有用です。段落のみの画像の場合は、[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) を使用してください。

## **FAQ**

**テキストフレーム内で行折り返しを完全に無効にできますか？**

はい。[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) を設定して折り返しを無効にすれば、行はテキストフレームの端で改行しなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

[Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) を使用して段落のバウンディング矩形を取得できます。[Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、または両端揃え）はどこで制御されますか？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) は段落レベルの設定であり、個々のポーション書式設定に関係なく段落全体に適用されます。

各行内で異なるフォントサイズのポーションを縦方向に揃える方法については、[Align Fonts Within a Line](/slides/ja/python-java/text-formatting/#align-fonts-within-a-line) を参照してください。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) を設定すれば、1 つの段落内で複数の言語のテキストを含めることができます。