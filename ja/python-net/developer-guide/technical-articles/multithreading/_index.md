---
title: Aspose.Slides for Python のマルチスレッド処理
linktitle: マルチスレッド
type: docs
weight: 200
url: /ja/python-net/multithreading/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のマルチスレッド化により、PowerPoint および OpenDocument の処理が向上します。効率的なプレゼンテーションワークフローのベストプラクティスをご確認ください。"
---

## **はじめに**

プレゼンテーションの並列処理は可能ですが（解析/ロード/クローン以外）、ほとんどの場合は問題なく動作しますが、複数スレッドでライブラリを使用すると結果が正しくないことがあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)インスタンスを使用しないことを**強く推奨**します。予期しないエラーや失敗が検出しにくくなる可能性があります。

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを複数スレッドでロード、保存、またはクローンすることは安全ではありません。このような操作は**サポートされていません**。同様のタスクが必要な場合は、複数のシングルスレッドプロセスで操作を並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用するようにしてください。

## **プレゼンテーションスライドを画像に並列変換する方法**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。単一の `Presentation` インスタンスを複数スレッドで使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドで個別のプレゼンテーションを使用して画像に変換します。以下のコード例はその実装方法を示しています。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extract slide i into a separate presentation.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Convert the slide to an image.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Wait for all tasks to complete.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**各スレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始される前にプロセス/アプリドメインごとに一度だけ行えば十分です。ライセンス設定が同時に呼び出される可能性がある場合（例：遅延初期化時）は、ライセンス設定メソッド自体がスレッドセーフでないため、呼び出しを同期させてください。

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に事前に別々のプレゼンテーション／スライドコンテナを作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な勧告に沿っています。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像などへのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと別々の出力パスを使用すれば、通常は正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でのグローバルフォント設定（フォルダー、代替フォント）はどうすべきですか？**

スレッドを開始する前にすべてのグローバルフォント設定を初期化し、並列作業中に変更しないでください。これにより、共有フォントリソースへの競合が排除されます。