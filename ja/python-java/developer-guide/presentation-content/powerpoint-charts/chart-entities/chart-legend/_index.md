---
title: Python を使用してプレゼンテーションのチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/python-java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してチャート凡例をカスタマイズし、調整された凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides は、PowerPoint プレゼンテーションのチャート凡例をカスタマイズするオプションを提供します。この記事では、凡例の位置とサイズの設定、凡例全体のフォントサイズの設定、個々の凡例項目への書式設定の適用方法を示します。

また、FAQ では、プロット領域が凡例のためにスペースを確保できるように非オーバーレイモードを使用すること、長い凡例ラベルを自動で折り返すまたは改行を使用できること、明示的なテキストや塗りつぶし設定が行われていない場合に凡例の書式設定がプレゼンテーションのテーマから継承されることなど、関連するいくつかの動作についても取り上げています。

## **凡例の位置指定**

凡例のプロパティを設定するには、次の手順に従います。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドにチャートを追加します。
4. 凡例のプロパティを設定します。
5. プレゼンテーションを PPTX ファイルとして保存します。

以下の例は、チャート凡例の位置とサイズを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    # スライドへの参照を取得します。
    slide = presentation.getSlides().get_Item(0)

    # スライドにクラスター化された縦棒チャートを追加します。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 凡例のプロパティを設定します。
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # プレゼンテーションをディスクに保存します。
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **凡例のフォントサイズの設定**

Aspose.Slides for Python via Java を使用すると、凡例のフォントサイズを設定できます。次の手順に従ってください：

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. デフォルトのチャートを作成します。
3. フォントサイズを設定します。
4. 軸の最小値を設定します。
5. 軸の最大値を設定します。
6. プレゼンテーションをディスクに保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **個別の凡例項目のフォントサイズの設定**

Aspose.Slides for Python via Java を使用すると、個々の凡例項目のフォントサイズを設定できます。次の手順に従ってください：

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. デフォルトのチャートを作成します。
3. 凡例項目にアクセスします。
4. フォントサイズを設定します。
5. プレゼンテーションをディスクに保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保させることはできますか？**

はい。`False` を指定して [setOverlay](https://reference.aspose.com/slides/ja/python-java/aspose.slides/legend/#setOverlay) を使用すると、非オーバーレイモードが有効になり、この場合プロット領域が縮小して凡例を収容します。

**複数行の凡例ラベルを作成できますか？**

はい。スペースが不足している場合、長いラベルは自動的に折り返されます。シリーズ名に改行文字を含めることで、強制的な改行もサポートされます。

**凡例をプレゼンテーションテーマの配色に従わせるにはどうすればよいですか？**

凡例やそのテキストに対して明示的な色、塗りつぶし、フォントを設定しないでください。そうするとテーマから継承され、デザインが変更された際に正しく更新されます。