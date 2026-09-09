---
title: Python で AutoFit を使用してプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/python-java/manage-autofit-settings/
keywords:
- テキスト ボックス
- AutoFit
- AutoFit なし
- テキストのフィット
- テキストの縮小
- テキストの折り返し
- シェイプのサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト表示を最適化してコンテンツの可読性を向上させる方法を学びましょう。"
---
## **はじめに**

デフォルトでは、テキスト ボックスを追加すると Microsoft PowerPoint は **Resize shape to fit text** 設定を使用します。テキスト ボックスは自動的にサイズ変更され、テキストが常に収まるようになります。

![PowerPoint のテキスト ボックス](textbox-in-powerpoint.png)

* テキスト ボックス内のテキストが長くなるまたは大きくなると、PowerPoint はテキスト ボックスの高さを増やして拡大し、より多くのテキストを収められるようにします。
* テキスト ボックス内のテキストが短くなるまたは小さくなると、PowerPoint は余分なスペースを削除するためにテキスト ボックスの高さを減らして縮小します。

PowerPoint では、テキスト ボックスの自動フィット 動作を制御する 4 つの重要なパラメータまたはオプションがあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint の自動フィット オプション](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java は、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスのいくつかのプロパティとして、プレゼンテーション内のテキスト ボックスの自動フィット 動作を制御する同様のオプションを提供します。

## **Resize a Shape to Fit Text**

テキストが変更された後も常にボックスに収まるようにしたい場合は、**Resize shape to fit text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドに [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#Shape) を指定します。

![PowerPoint の常にフィット設定](alwaysfit-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テキストが長くなるまたは大きくなると、テキスト ボックスは自動的に高さが増えてサイズ変更され、すべてのテキストが収まります。テキストが短くなると、逆の動作が行われます。

## **Do Not Autofit**

テキスト ボックスまたはシェイプが、内部のテキストの変更にかかわらずサイズを保持するようにしたい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドに [None](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#None) を指定します。

![PowerPoint の自動フィット無効設定](donotautofit-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキスト ボックスが常にサイズを保持するように指定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テキストがボックスに対して長すぎると、テキストがはみ出します。

## **Shrink Text on Overflow**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドに [Normal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#Normal) を指定します。

![PowerPoint のオーバーフロー時縮小設定](shrinktextonoverflow-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでオーバーフロー時にテキストを縮小するように指定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}

**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなったときだけ設定が適用されます。

{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、そのシェイプ内でテキストを折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) メソッドに [NullableBool.True_](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#True) を指定します。

この Python コードは、PowerPoint プレゼンテーションでラップ テキスト設定を使用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 

シェイプに対して [setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) メソッドを [NullableBool.False](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#False) で使用すると、シェイプ内のテキストがシェイプの幅より長くなった場合に、テキストは単一行のままシェイプの境界を超えて表示されます。

{{% /alert %}}

## **FAQ**

**テキスト フレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit がより早く発動し、フォントが縮小されたりシェイプがサイズ変更されたりします。AutoFit を調整する前に余白を確認・調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する必要性が減少することがあります。

**テーマ フォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。字形メトリクスが異なるフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや折り返しが変化します。フォントを変更または置換した後は、スライドを再確認してください。