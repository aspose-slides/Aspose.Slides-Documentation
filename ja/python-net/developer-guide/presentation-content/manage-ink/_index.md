---
title: Python でプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/python-net/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- インクのエクスポート
- インクのレンダリング
- インクの非表示
- InkOptions
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint のインクオブジェクトを管理し、トレースやブラシ プロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインクの外観を制御します。"
---
## **はじめに**

PowerPoint には自由な線を描くことができるインク機能が提供されています。インクは他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

[aspose.slides.ink](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/) 名前空間にはインクオブジェクトを扱うために必要なクラスが含まれています。例えば、[Ink](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/ink/) クラスはスライド上のインクオブジェクトを表します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプオブジェクトで表されます。最も単純な形では、シェイプはオブジェクト自体の領域（フレーム）と、コンテナサイズ、形状、背景などのプロパティを定義するコンテナです。詳しくは[Shape Layout Format](https://docs.aspose.com/slides/ja/python-net/shape-manipulations/#access-layout-formats-for-shape)をご覧ください。

しかし、PowerPoint がインクオブジェクトを処理する際は、コンテナ（フレーム）のサイズ以外のすべてのプロパティを無視します。コンテナ領域のサイズは標準の[Ink.width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/ink/width/) と[Ink.height](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/ink/height/) プロパティで決定されます。

![ink_powerpoint1](ink_powerpoint1.png)

## **インクトレース**

インクトレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素です。トレースは接続されたポイントのシーケンスを保持します。

最も単純なエンコード形式は各サンプル点の X および Y 座標を指定します。すべての接続されたポイントが描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

ブラシはインクトレースのポイントを結ぶ線を描くために使用されます。その[InkBrush.color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/inkbrush/color/) と[InkBrush.size](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ink/inkbrush/size/) プロパティが色とサイズを制御します。

### **インクブラシの色を設定**

この Python コードはインクブラシの色を設定する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **インクブラシのサイズを設定**

この Python コードはインクブラシのサイズを設定する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

一般に、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（対応するデータ セクションはグレー表示になります）。幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インクオブジェクトの高さを増やして重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると仮定します（前の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレース）がコンテナ（フレーム）のサイズに合わせてスケーリングされています。コンテナのサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストオブジェクトでも同様の動作を使用します：

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートとレンダリング時のインクの外観制御**

Aspose.Slides は[InkOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/) クラスを提供し、エクスポートまたはレンダリングされた出力でインクオブジェクトの表示方法を制御できます。プロパティを使用してインクを完全に非表示にしたり、インクブラシのマスク操作の解釈方法を変更したりできます。

インクオプションは、以下の出力タイプに対するエクスポートまたはレンダリング オプションを通じて利用可能です：

| 出力 | Ink オプション プロパティ |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/ink_options/) |

これらのプロパティで利用できる同じ 2 つの設定は次のとおりです。

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/hide_ink/) はインクオブジェクトを出力に含めるかどうかを決定します。既定値は `False` です。
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) はインクブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。既定値は `True` で、`False` に設定すると ROP 操作が使用されます。

### **PDF 出力でインクオブジェクトを非表示にする**

既定では、インクオブジェクトはエクスポート時に表示され続けます。手書き注釈やその他のインク コンテンツなしでクリーンな出力が必要な場合は、[InkOptions.hide_ink](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/hide_ink/) を `True` に設定します。

次の Python サンプルは、すべてのインクオブジェクトを非表示にしながらプレゼンテーションを PDF にエクスポートします：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **スライドを画像としてレンダリングする際にインクオブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際にインクオブジェクトを非表示にするには、[RenderingOptions.ink_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/ink_options/) を構成し、レンダリング オプションを[Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) メソッドに渡します。

次の Python サンプルは、インクオブジェクトを除いた PNG 画像として最初のスライドをレンダリングします：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **インクマスクのレンダリングを制御**

[`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) プロパティは、インクブラシをレンダリングする際にマスク操作がどのように解釈されるかを制御します。既定値は `True` で不透明度が使用されます。`False` に設定すると ROP 操作が使用されます。

次の Python サンプルは、SVG にスライドをエクスポートし、インクマスク操作に ROP ベースのレンダリングを使用します：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

同じ設定は、プレゼンテーションをエクスポートまたはスライドを TIFF にレンダリングする際に[TiffOptions.ink_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/ink_options/) を通じても適用できます。

### **インクを非表示にするか保持するか選択**

注釈付きプレゼンテーションのクリーンなバージョン（例: 配布用の最終コピー）としてエクスポートファイルを作成する場合は、[InkOptions.hide_ink](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/hide_ink/) を `True` に設定します。

インク注釈が意図したコンテンツの一部（レビュー コメント、手書きメモ、ハイライト、描画など）である場合は、[InkOptions.hide_ink](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/inkoptions/hide_ink/) を既定値の `False` のままにしておきます。これにより、同じプレゼンテーションからソースのインクオブジェクトを変更せずに、レビュー用と最終用の別々の出力を生成できます。

## **よくある質問**

**既存のインクストロークの色やサイズを変更できますか？**

はい。`Ink.traces` からトレースを取得し、`InkTrace.brush` を変更します。ブラシの `InkBrush.color` と `InkBrush.size` プロパティを設定できます。

**インクを非表示にしても元のプレゼンテーションは変わりますか？**

いいえ。`InkOptions.hide_ink` はレンダリングまたはエクスポートされた結果にのみ影響し、ソースのプレゼンテーション内のインクオブジェクトを削除したり変更したりしません。

**どのエクスポート形式がインクオプションに対応していますか？**

PDF、HTML、SVG、TIFF、およびビットマップスライド画像のエクスポートまたはレンダリング オプションでインクオプションを構成できます。

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes] セクションをご覧ください。
* 有効な値に関する詳細は、[Shape Effective Properties] を参照してください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF] をご覧ください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML] をご覧ください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images] をご覧ください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF] をご覧ください。
* スライドを画像にレンダリングする詳細は、[Convert Presentation Slides to Images] をご覧ください。