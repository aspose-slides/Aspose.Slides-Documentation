---
title: テキストボックスの管理
type: docs
weight: 20
url: /python-net/manage-textbox/
keywords: "テキストボックス, テキストフレーム, テキストボックスを追加, ハイパーリンク付きテキストボックス, Python, Aspose.Slides for Python via .NET"
description: "Pythonまたは.NETを使用してPowerPointプレゼンテーションにテキストボックスまたはテキストフレームを追加します"
---

スライド上のテキストは通常、テキストボックスまたは図形に存在します。したがって、スライドにテキストを追加するには、テキストボックスを追加し、その中にテキストを入れる必要があります。Aspose.Slides for Python via .NETは、テキストを含む図形を追加するための[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)インターフェイスを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slidesは、スライドに図形を追加するための[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)インターフェイスも提供しています。ただし、`IShape`インターフェイスを介して追加されたすべての図形がテキストを保持できるわけではありません。しかし、[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)インターフェイスを介して追加された図形は、テキストを含むことができます。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

したがって、テキストを追加したい図形を扱う場合、その図形が`IAutoShape`インターフェイスを介してキャストされたことを確認することをお勧めします。その場合のみ、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を操作できます。このページの[テキストの更新](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text)セクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

スライドにテキストボックスを作成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。
3. スライド上の指定位置に`ShapeType`を`RECTANGLE`に設定した[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)オブジェクトを追加し、新たに追加された`IAutoShape`オブジェクトへの参照を取得します。
4. テキストを含む`text_frame`プロパティを`IAutoShape`オブジェクトに追加します。以下の例では、*Aspose TextBox*というテキストを追加しました。
5. 最後に、`Presentation`オブジェクトを通じてPPTXファイルを書き込みます。

このPythonコードは、上記の手順を実装したもので、スライドにテキストを追加する方法を示しています：

```py
import aspose.slides as slides

# PresentationExをインスタンス化
with slides.Presentation() as pres:

    # プレゼンテーションの最初のスライドを取得
    sld = pres.slides[0]

    # 自動図形を追加し、タイプを矩形に設定
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 矩形にTextFrameを追加
    ashp.add_text_frame(" ")

    # テキストフレームにアクセス
    txtFrame = ashp.text_frame

    # テキストフレーム用の段落オブジェクトを作成
    para = txtFrame.paragraphs[0]

    # 段落用のポーションオブジェクトを作成
    portion = para.portions[0]

    # テキストを設定
    portion.text = "Aspose TextBox"

    # プレゼンテーションをディスクに保存
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストボックス図形の確認**

Aspose.Slidesは、図形を調べ、テキストボックスを見つけるための`is_text_box`プロパティ（[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)クラスから）を提供します。

![テキストボックスと図形](istextbox.png)

このPythonコードは、図形がテキストボックスとして作成されたかを確認する方法を示しています：xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("図形はテキストボックスです" if shape.is_text_box else "図形はテキストボックスではありません")
```

## **テキストボックスに列を追加**

Aspose.Slidesは、テキストボックスに列を追加するための[column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)および[column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)インターフェイスおよび[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスから）を提供します。テキストボックス内の列数を指定し、列間の間隔をポイントで設定できます。

このPythonコードは、説明した操作を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	# プレゼンテーションの最初のスライドを取得
	slide = presentation.slides[0]

	# 自動図形を矩形として追加
	aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 矩形にTextFrameを追加
	aShape.add_text_frame("これらのすべての列は単一のテキストコンテナ内に制限され、" +
	"テキストを追加または削除でき、新しいテキストまたは残りのテキストが自動的に調整されます。" +
	"ただし、テキストが一つのコンテナから他のコンテナに流れることはありません。" +
	"私たちはPowerPointのテキストの列オプションが限られていることをお伝えしました！")

	# TextFrameのテキストフォーマットを取得
	format = aShape.text_frame.text_frame_format

	# TextFrameの列数を指定
	format.column_count = 3

	# 列間の間隔を指定
	format.column_spacing = 10

	# プレゼンテーションを保存
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストフレームに列を追加**

Aspose.Slides for Python via .NETは、テキストフレームに列を追加するための[ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)プロパティを（[ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)インターフェイスから）提供します。このプロパティを使用して、テキストフレーム内の好ましい列数を指定できます。

このPythonコードは、テキストフレーム内に列を追加する方法を示しています：

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """これらのすべての列は単一のテキストコンテナ内に強制されており --
        テキストを追加したり削除したりできます - 新しいテキストまたは残りのテキストが自動的に調整されます
        コンテナ内に留まるために。このため、テキストが一つのコンテナから他のコンテナにあふれることはありません --
        PowerPointのテキストの列オプションが限られているためです！"""
    
    pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **テキストの更新**

Aspose.Slidesを使用すると、テキストボックス内のテキストやプレゼンテーション内のすべてのテキストを変更または更新できます。

このPythonコードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # 修正されたプレゼンテーションを保存
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンク付きテキストボックスを追加**

テキストボックス内にリンクを挿入することができます。テキストボックスがクリックされると、ユーザーはそのリンクを開くように導かれます。

ハイパーリンクを含むテキストボックスを追加するには、以下の手順を実行します：

1. `Presentation`クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。
3. スライド上の指定位置に`ShapeType`を`RECTANGLE`に設定した`AutoShape`オブジェクトを追加し、新たに追加されたAutoShapeオブジェクトへの参照を取得します。
4. `AutoShape`オブジェクトに*Aspose TextBox*をデフォルトテキストとして含む`text_frame`を追加します。
5. `hyperlink_manager`クラスをインスタンス化します。
6. `text_frame`の所望のポーションに関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)プロパティに`hyperlink_manager`オブジェクトを割り当てます。
7. 最後に、`Presentation`オブジェクトを介してPPTXファイルを書き込みます。

このPythonコードは、ハイパーリンク付きのテキストボックスをスライドに追加する方法を示しています：

```py
import aspose.slides as slides

# PPTXを表すPresentationクラスをインスタンス化
with slides.Presentation() as pptxPresentation:
    # プレゼンテーションの最初のスライドを取得
    slide = pptxPresentation.slides[0]

    # 自動図形オブジェクトを矩形として追加
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # 自動図形に関連するITextFrameプロパティにアクセス
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # フレームにテキストを追加
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # ポーションテキストのハイパーリンクを設定
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # PPTXプレゼンテーションを保存
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```