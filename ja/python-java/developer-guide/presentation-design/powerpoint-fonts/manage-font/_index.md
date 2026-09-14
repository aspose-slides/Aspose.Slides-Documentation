---
title: Python via Java を使用してプレゼンテーションのフォントを管理する
linktitle: フォント管理
type: docs
weight: 10
url: /ja/python-java/manage-fonts/
keywords:
- フォント管理
- フォントプロパティ
- 段落
- テキスト書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用した Python via Java におけるフォント制御：フォントを埋め込み、代替し、カスタムフォントをロードして、PPT、PPTX、ODP プレゼンテーションを明確かつブランド安全で一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、コードから直接プレゼンテーションのテキストのフォントプロパティを管理できます。スライド内のテキストはシェイプ、テキストフレーム、段落、ポーションを介してアクセスでき、選択したテキストに書式設定を適用できます。

この記事では、プレゼンテーション内の既存テキストに対してフォントファミリ、太字・斜体スタイル、段落配置、フォントカラーなどのフォント関連プロパティを構成する方法を説明します。また、テキストボックスを作成し、テキストを追加し、フォントファミリ、太字、斜体、下線、フォントサイズ、カラーなどのフォントプロパティを設定して結果を PPTX ファイルとして保存する方法も示します。

## **フォント関連プロパティの管理**
{{% alert color="info" title="注" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは特定のセクションや単語を強調したり、企業スタイルに合わせたりするためにさまざまな方法で書式設定できます。テキストの書式設定は、プレゼンテーション コンテンツの外観を多様化するのに役立ちます。本記事では、Aspose.Slides for Python via Java を使用してスライド上の段落テキストのフォントプロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for Python via Java を使用して段落のフォントプロパティを管理する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の [Placeholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/) シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) として取得します。
1. [AutoShape] が提供する [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を取得します。
1. 段落を左右揃えにします。
1. [Paragraph] のテキスト [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) にアクセスします。
1. [FontData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) の **Font** を設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion] オブジェクトが提供する [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/) を使用してフォントの色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。装飾されていないプレゼンテーションを取得し、スライドのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコード スニペットがそれをどのように変更するかを示しています。コードはフォント、色、フォントスタイルを変更します。

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式の同じテキスト**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# プレゼンテーションをロードする。
presentation = Presentation("FontProperties.pptx")
try:
    # 最初のスライドと、最初の2つのプレースホルダーのテキストフレームにアクセスする。
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # 各テキストフレームの最初の段落にアクセスする。
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # 各段落の最初のポーションにアクセスする。
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # 新しいフォントを定義して割り当てる。
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # フォントを太字と斜体に設定する。
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # フォントの色を設定する。
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # プレゼンテーションを保存する。
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テキストフォントプロパティの設定**
{{% alert color="info" title="注" %}} 

**フォント関連プロパティの管理** で述べたように、[Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) は段落内で同様の書式スタイルのテキストを保持するために使用されます。本記事では、Aspose.Slides for Python via Java を使用してテキスト ボックスを作成し、テキストを追加し、特定のフォントとその他のフォントプロパティを定義する方法を示します。

{{% /alert %}} 

テキスト ボックスを作成し、その中のテキストにフォントプロパティを設定する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにタイプ **Rectangle** の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. [AutoShape] に関連付けられた塗りつぶしスタイルを削除します。
1. [AutoShape] の [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
1. [TextFrame] にテキストを追加します。
1. [TextFrame] に関連付けられた [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion] に使用するフォントを定義します。
1. [Portion] オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォントプロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例は以下のとおりです。

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Python via Java によって設定されたフォントプロパティを持つテキスト**|

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # 最初のスライドを取得し、長方形を追加する。
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # シェイプの塗りつぶしを削除する。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # シェイプのテキストフレームにテキストを追加する。
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # フォントファミリを設定する。
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # 太字、斜体、下線、およびフォントサイズを設定する。
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # フォントの色を設定する。
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # プレゼンテーションを保存する。
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```