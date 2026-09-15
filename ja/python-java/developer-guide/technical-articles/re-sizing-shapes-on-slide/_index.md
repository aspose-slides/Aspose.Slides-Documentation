---
title: Python via Java でプレゼンテーションスライドのシェイプをリサイズ
type: docs
weight: 110
url: /ja/python-java/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument スライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

Aspose.Slides for Python via Java のお客様から最もよくある質問のひとつは、スライドサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、その方法を示します。

## **シェイプのサイズ変更**

スライドサイズが変更されたときにシェイプがずれないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# プレゼンテーションファイルを読み込みます。
presentation = Presentation("sample.ppt")
try:
    # 元のスライドサイズを取得します。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 既存のシェイプをスケーリングせずにスライドサイズを変更します。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # 新しいスライドサイズを取得します。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # すべてのスライドのシェイプをリサイズおよび再配置します。
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # シェイプのサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # シェイプの位置をスケーリングします。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
テーブルは特別な処理は不要です。テーブルの幅と高さを設定すると、列と行が比例的にリスケールされるため、行の高さや列の幅を再度スケーリングすると比率が二重に適用されます。
{{% /alert %}} 

上記のコードはスライド上のシェイプのみを変更します。マスタースライドやレイアウトスライドはそれぞれ固有のシェイプを持っているため、プレゼンテーション全体を新しいスライドサイズに合わせたい場合は、それらも同様にスケールしてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # 元のスライドサイズを取得します。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 既存のシェイプをスケーリングせずにスライドサイズを変更します。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # 新しいスライドサイズを取得します。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # シェイプのサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # シェイプの位置をスケーリングします。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # シェイプのサイズをスケーリングします。
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # シェイプの位置をスケーリングします。
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # シェイプのサイズをスケーリングします。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # シェイプの位置をスケーリングします。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドのサイズを変更すると、スケールが明示的に変更されない限り、シェイプは元の位置とサイズのまま残ります。そのため、コンテンツが切り取られたりシェイプがずれたりすることがあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**

はい。高さと幅を設定することは、テキストボックス、画像、チャート、テーブルなどすべてのシェイプに対して機能します。

**スライドのサイズ変更時にテーブルをリサイズするにはどうすればよいですか？**

テーブル自体のシェイプを他のシェイプと同様にスケールします。行と列は比例的に調整されるため、後から再度スケーリングしないでください。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。ただし、[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) と [Presentation.getLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getLayoutSlides) をループして、同じスケーリングロジックをそれらのシェイプにも適用し、プレゼンテーション全体の一貫性を保つ必要があります。

**リサイズと同時にスライドの向き（縦/横）を変更できますか？**

はい。[SlideSize.setOrientation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#setOrientation) を使用して向きを変更できます。レイアウトを保つために、スケーリングロジックも適切に設定してください。

**設定できるスライドサイズに制限はありますか？**

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を与える可能性があります。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

スケーリングする前に、シェイプのロックの [getAspectRatioLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) メソッドでロック状態を確認できます。ロックされている場合は、幅や高さを個別にスケーリングするのではなく、比例的に調整してください。