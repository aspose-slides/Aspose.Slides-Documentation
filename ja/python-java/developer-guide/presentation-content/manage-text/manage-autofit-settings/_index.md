---
title: Python で AutoFit を使用してプレゼンテーションを強化
linktitle: Autofit 設定
type: docs
weight: 30
url: /ja/python-java/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- AutoFit なし
- テキストに合わせる
- テキストを縮小
- テキストを折り返す
- シェイプのサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションでテキスト表示を最適化し、コンテンツの可読性を向上させる方法を学びます。"
---
## **はじめに**

デフォルトでは、テキスト ボックスを追加すると、Microsoft PowerPoint はテキスト ボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるようにテキスト ボックスのサイズが自動的に調整されます。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキスト ボックス内のテキストが長くまたは大きくなると、PowerPoint はテキスト ボックスを自動的に拡大（高さを増加）し、より多くのテキストを収められるようにします。  
* テキスト ボックス内のテキストが短くまたは小さくなると、PowerPoint はテキスト ボックスを自動的に縮小（高さを減少）し、余分なスペースを除去します。  

PowerPoint では、テキスト ボックスの AutoFit 動作を制御する重要な 4 つのパラメーターまたはオプションがあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java は、同様のオプション（[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスのプロパティ）を提供し、プレゼンテーション内のテキスト ボックスの AutoFit 動作を制御できます。

## **テキストに合わせてシェイプのサイズを変更**

テキストが変更された後でも常にボックスに収まるようにするには、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドを [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#Shape) とともに使用します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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

テキストが長くまたは大きくなると、テキスト ボックスは自動的にサイズが変更され（高さが増加）テキスト全体が収まります。テキストが短くなると、逆の処理が行われます。

## **Do Not Autofit**

テキストの変更に関係なくテキスト ボックスやシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドを [None](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#None) とともに使用します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テキストがボックスに対して長すぎる場合、テキストははみ出します。

## **Shrink Text on Overflow**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用してテキストのサイズと間隔を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) メソッドを [Normal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/#Normal) とともに使用します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキストがオーバーフローした際に縮小されるように指定する方法を示しています。

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
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなった場合にのみ設定が適用されます。
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、そのシェイプ内でテキストを折り返したい場合は、**Wrap text in shape** パラメーターを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) クラスの [setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) メソッドを [NullableBool.True](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#True) とともに使用します。

この Python コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています。

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
シェイプに対して [setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) メソッドを [NullableBool.False](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#False) で使用すると、シェイプ内のテキストがシェイプの幅を超えた場合、テキストは単一行でシェイプの境界を超えて伸びます。 
{{% /alert %}}

## **FAQ**

**テキスト フレームの内部余白は AutoFit に影響しますか？**  
はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit がより早く発動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認・調整してください。

**AutoFit は手動改行とソフト改行にどのように作用しますか？**  
強制改行はそのまま保持され、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不必要な改行を削除すると、AutoFit がテキストを縮小する頻度が減少します。

**テーマ フォントの変更やフォント置換は AutoFit の結果に影響しますか？**  
はい。字形メトリクスが異なるフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行が変わることがあります。フォントを変更または置換した後は、スライドを再確認してください。