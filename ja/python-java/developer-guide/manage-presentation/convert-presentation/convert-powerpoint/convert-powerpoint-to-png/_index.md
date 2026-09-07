---
title: Python で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- Python
- Java
- Aspose.Slides
description: "Python (via Java) で PowerPoint スライドを PNG 画像に変換します。カスタムスケールまたは正確な画像サイズで PPT、PPTX、ODP プレゼンテーションをエクスポートします。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP ファイルを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

例では、スケール係数または正確な幅と高さを使用して出力寸法を制御する方法も示しています。各例は必要に応じて Java 仮想マシンを起動し、使用後にプレゼンテーションと画像のリソースを解放します。

## **PowerPoint を PNG に変換**

1. 入力ファイルを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスで読み込みます。  
2. [Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) を使用してスライドを取得します。  
3. [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) を使用して各スライドをレンダリングします。  
4. [ImageFormat.Png](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/#Png) で各レンダリング画像を保存し、リソースを解放します。

以下の Python の例は、すべてのスライドをデフォルトサイズでエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **カスタム スケールで PowerPoint を PNG に変換**

出力寸法を拡大または縮小するには、[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に水平および垂直のスケール係数を渡します。例えば、720 × 540 ポイントのスライドを両軸でスケール係数 2 でレンダリングすると、1440 × 1080 ピクセルの画像が生成されます。

等しいスケール係数を使用すると、スライドのアスペクト比を維持できます。異なる係数を使用すると、スライドが水平または垂直に伸びます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **カスタム サイズで PowerPoint を PNG に変換**

正確なピクセル寸法を指定するには、希望の幅と高さを持つ Java の `Dimension` オブジェクトを [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に渡します。元のスライドと同じアスペクト比の寸法を選択して、歪みを防ぎます。

以下の例は、各スライドを 960 × 720 ピクセルの PNG 画像として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **よくある質問**

**スライド全体ではなく、チャートや画像などの個々のシェイプをエクスポートできますか？**  
はい。Aspose.Slides は個々のシェイプのサムネイル生成をサポートしており、[generating thumbnails for individual shapes](/slides/ja/python-java/create-shape-thumbnails/) を使用して PNG 画像として保存できます。

**サーバー上でプレゼンテーションを並列に変換できますか？**  
各スレッドまたはプロセスごとに個別の Presentation インスタンスを使用し、ファイルが上書きされないようにユニークな出力パスを使用してください。スレッド間で Presentation インスタンスを共有しないでください。詳細は [Multithreading](/slides/ja/python-java/multithreading/) を参照してください。

**PNG へエクスポートする際の評価版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、[other restrictions](/slides/ja/python-java/licensing/) が適用されます。ライセンスを適用するとこれらの制限を解除できます。