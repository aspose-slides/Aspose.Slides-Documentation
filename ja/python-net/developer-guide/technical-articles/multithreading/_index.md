---
title: Aspose.Slides for Python のマルチスレッド
linktitle: マルチスレッド
type: docs
weight: 200
url: /ja/python-net/multithreading/
keywords:
- マルチスレッド
- 複数スレッド
- 並列処理
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のマルチスレッドは PowerPoint と OpenDocument の処理を向上させます。効率的なプレゼンテーション ワークフローのベストプラクティスをご確認ください。"
---

## **導入**

プレゼンテーションの並列処理は（解析/ロード/クローンを除いて）可能で、ほとんどの場合うまくいきますが、ライブラリを複数スレッドで使用すると結果が正しくない可能性が僅かにあります。

マルチスレッド環境で単一の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを使用しないことを強く推奨します。予測不可能なエラーや検出が難しい障害が発生する可能性があるためです。

複数スレッドで [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスをロード、保存、またはクローンすることは安全ではありません。そのような操作はサポートされていません。もしこれらのタスクが必要な場合は、複数のシングルスレッドプロセスで並列に実行し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションのスライドを画像に並列変換**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列変換したいとします。単一の `Presentation` インスタンスを複数スレッドで使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドで画像に変換します。以下のコード例がその方法を示しています。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # スライド i を別個のプレゼンテーションに抽出します。
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

# すべてのタスクが完了するまで待機します。
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始される前に、プロセス/アプリドメインごとに一度実行すれば十分です。[license setup](/slides/ja/python-net/licensing/) が同時に呼び出される可能性がある場合（例えば遅延初期化時）、その呼び出しはスレッドセーフでないため、同期させてください。

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に別々のプレゼンテーション/スライドコンテナを事前に作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿ったものです。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像など異なる形式へのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと別々の出力パスを使用すれば、通常は正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でグローバルなフォント設定（フォルダー、置換など）をどう扱えばよいですか？**

スレッドを開始する前にすべてのグローバルフォント設定を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合が防止されます。