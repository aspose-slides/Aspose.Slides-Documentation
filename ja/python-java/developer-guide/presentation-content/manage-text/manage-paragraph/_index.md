---
title: Python via Java で PowerPoint テキスト段落を管理する
linktitle: 段落を管理
type: docs
weight: 40
url: /ja/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - テキストを追加
  - 段落を追加
  - テキストを管理
  - 段落を管理
  - 箇条書きを管理
  - 段落インデント
  - ハンギングインデント
  - 段落箇条書き
  - 番号付きリスト
  - 箇条書きリスト
  - 段落プロパティ
  - HTML をインポート
  - テキストを HTML に変換
  - 段落を HTML に変換
  - 段落を画像に変換
  - テキストを画像に変換
  - 段落をエクスポート
  - PowerPoint
  - プレゼンテーション
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java はテキストをテキストフレーム、段落、ポーションの階層で表現します。

* [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) はシェイプ内のテキストコンテナを表し、その段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) はテキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) は段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のPortionで段落を作成**

次の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) オブジェクトを追加します。
6. 各段落に 3 つのポーションを含めるように十分な数の [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getPortionFormat) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この Python の例が手順を実装しています:

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

## **箇条書きリストと番号付きリストの作成**

### **箇条書きまたは番号付きリストを作成**

箇条書きや番号付けは、関連項目を視覚的に把握しやすくします。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/) を通じて定義します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. 記号箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を作成します。
7. [BulletFormat.setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bullettype/#Symbol) に設定し、箇条書き文字を指定します。
8. 段落テキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[BulletFormat.setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bullettype/#Numbered) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この Python の例は記号箇条書きと番号付き箇条書きを作成します:

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

画像箇条書きでは、記号や番号の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) として追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [BulletFormat.setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Picture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bullettype/#Picture) に設定します。
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#getPicture) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更したプレゼンテーションを保存します。

この Python の例は画像箇条書きを作成します:

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

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setDepth) を設定して、リスト内の段落のレベルを指定します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加し、テキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. それぞれの段落に対して [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setDepth) の値を `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Python の例は 4 レベルの箇条書きリストを作成します:

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

### **番号付きリスト項目の開始番号をカスタム値に設定**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) を使用して、番号付き段落の先頭番号を指定できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を作成し、スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Python の例は各段落にカスタム開始番号を割り当てます:

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

## **段落のレイアウトと終了プロパティの制御**

### **ファーストラインインデントを設定**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) を使用して段落の最初の行だけのインデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右へシフトし、残りの行は段落本体に揃ったままです。

全体の段落を移動したい場合は [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginLeft) を使用し、最初の行だけを移動したい場合は [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) を使用します。

下の例は複数の段落を作成し、異なる [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) の値を適用して、ファーストラインインデントが段落レイアウトに与える影響を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) の値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します:

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
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

![段落のファーストラインインデント](first_line_indent.png)

### **ハンギングインデントを設定**

ハンギングインデントは、最初の行が残りの行より左側に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) に負の値を指定して実現します。

実際には、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginLeft) が段落本体の左位置を定義し、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginLeft) に正の値を、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) に負の値を渡します。

この書式は、文献リスト、参考文献、用語集エントリなど、折り返し行が段落本体の下に揃う必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) のインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginLeft) に正の値を設定します。
6. ハンギングインデント効果を作るために [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setIndent) に負の値を渡します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落にハンギングインデントを設定する方法を示します:

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

### **段落終了プロパティを設定**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) は段落終了マークの書式設定を制御します。以下の例は 2 番目の段落の終了マークにフォントサイズとラテン文字フォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を読み込み、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落の終了マーク用に [PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を作成します。
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontHeight) と [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLatinFont) を設定します。
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) で書式を割り当て、プレゼンテーションを保存します。

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

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphcollection/#addFromHtml) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphcollection/#addFromHtml) に渡します。
6. 変更したプレゼンテーションを保存します。

この Python の例は HTML をテキストフレームにインポートします:

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

### **段落テキストを HTML にエクスポート**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphcollection/#exportToHtml) を使用して、選択した段落範囲を HTML としてエクスポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. スライドにアクセスし、テキストを含む [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を検索します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphcollection/#exportToHtml) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この Python の例は最初のテキストシェイプからすべての段落をエクスポートします:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **段落を画像としてレンダリング**

[Paragraph.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) は個々の段落を直接レンダリングし、画像オブジェクトを返します。`save` メソッドを使用してファイルまたはストリームに保存できます。親シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

段落が親コレクションに存在しない、または有効なレンダリング境界がない、もしくはレンダリングできない場合、[Paragraph.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) は `None` を返すことがあります。保存する前に結果を確認し、使用後は画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

サンプルとして `sample.pptx` というプレゼンテーションファイルがあり、1 枚のスライドに最初のシェイプが 3 つの段落を含むテキスト ボックスであるとします。

![3 段落を含むテキスト ボックス](paragraph_to_image_input.png)

以下の例は、通常のテキスト シェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で保存します。`finally` ブロックは画像が正しく破棄されることを保証します。

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

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`scale_x` と `scale_y` パラメータを受け取る [Paragraph.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) のオーバーロードを使用して、横方向と縦方向のスケール係数を設定します。以下の例はテーブルを作成し、最初のセル内の段落をデフォルト幅・高さの 2 倍でレンダリングし、PNG 画像として保存します。

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

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば両方を `2` にすると、幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力時にテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が失われた小さい画像を生成します。アスペクト比を保ちたい場合は同じ係数を使用し、違う係数を設定すると横方向と縦方向で別々に伸縮します。

シェイプ全体を画像化したい場合は、[Shape.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) が有用です。段落だけの画像が必要なときは、[Paragraph.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を使用してください。

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。`[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText)` を設定してラップを無効にすれば、テキストフレームの端で行が折り返されません。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

`[Paragraph.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getRect)` を使用して段落の境界矩形を取得します。個々のポーションの境界は `[Portion.getRect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getRect)` が提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

`[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment)` は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に対して校閲言語を設定できますか？**

はい。個々のポーションに対して `[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId)` を設定すれば、同じ段落内に複数の言語のテキストを含めることができます。