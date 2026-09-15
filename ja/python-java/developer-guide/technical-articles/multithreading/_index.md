---
title: Aspose.Slides for Python via Java のマルチスレッド
linktitle: マルチスレッド
type: docs
weight: 310
url: /ja/python-java/multithreading/
keywords:
- マルチスレッド
- 複数スレッド
- 並列作業
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のマルチスレッドは PowerPoint と OpenDocument の処理を向上させます。効率的なプレゼンテーション ワークフローのベストプラクティスをご覧ください。"
---
## **Introduction**

プレゼンテーションの並列処理は（パース、ロード、クローンを除く）可能であり、通常はうまく機能しますが、ライブラリを複数スレッドで使用する際に結果が正しくない可能性が若干あります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)インスタンスを使用**しない**ことを強く推奨します。これは、予測できないエラーや検出しにくい失敗を引き起こす可能性があるためです。

複数スレッドで[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)インスタンスをロード、保存、またはクローンすることは**安全ではありません**。このような操作は**サポートされていません**。これらのタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して操作を並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列で画像に変換**

PowerPoint プレゼンテーションのすべてのスライドを並列で PNG 画像に変換したいとします。複数スレッドで単一の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)インスタンスを使用するのは安全ではないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドでそれぞれのプレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例はその方法を示しています。

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # スライドを別のプレゼンテーションに抽出します。
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # スライドを別タスクで画像に変換します。
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # すべてのタスクが完了するまで待機します。
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **よくある質問**

**各スレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始する前にプロセス単位で一度だけ実行すれば十分です。[license setup](/slides/ja/python-java/licensing/) が同時に呼び出される可能性がある場合（例: 遅延初期化時）、その呼び出しを同期してください。ライセンス設定メソッド自体はスレッドセーフではありません。

**スレッド間で[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)または[Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/)オブジェクトを渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、事前に各スレッド用の別々のプレゼンテーションまたはスライドコンテナを作成してください。この方法は、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿っています。

**各スレッドが独自の[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)インスタンスを持っている場合、PDF、HTML、画像など異なるフォーマットへのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと別々の出力パスを使用すれば、通常このようなタスクは正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でグローバルフォント設定（フォルダー、置換など）はどうすべきですか？**

スレッドを開始する前にすべてのグローバル[font settings](/slides/ja/python-java/powerpoint-fonts/)を初期化し、並列作業中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合が防止されます。