---
title: Aspose.Slides におけるマルチスレッド処理
type: docs
weight: 200
url: /ja/python-net/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並列作業
- スライドを変換
- スライドを画像に
- Python
- Aspose.Slides for Python
---

## **はじめに**

プレゼンテーションに対する並列作業は可能ですが（解析/ロード/クローンを除いて）、すべてがうまくいくわけではなく（ほとんどの場合）、ライブラリを複数のスレッドで使用する際に不正確な結果が得られる可能性があります。

**絶対に**マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)インスタンスを使用しないことを強くお勧めします。これにより、予測不可能なエラーや簡単には検出できない障害が発生する可能性があります。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスをロード、保存、および/またはクローンすることは**安全ではありません**。そのような操作は**サポートされていません**。そのようなタスクを実行する必要がある場合は、複数の単一スレッドプロセスを使用して操作を並列化する必要があります。そして、これらの各プロセスは独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列に画像に変換する**

すべてのスライドをPowerPointプレゼンテーションからPNG画像に並列で変換したいとします。複数のスレッドで単一の`Presentation`インスタンスを使用することが安全でないため、プレゼンテーションスライドを別々のプレゼンテーションに分割し、それぞれのプレゼンテーションを使用してスライドを並列に画像に変換します。以下のコード例では、これをどのように行うかを示しています。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # スライド i を別々のプレゼンテーションに抽出します。
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # スライドを画像に変換します。
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# すべてのタスクが完了するのを待ちます。
for task in conversion_tasks:
    task.result()

del presentation
```