---
title: Aspose.Slides for Python のマルチスレッディング
linktitle: マルチスレッディング
type: docs
weight: 200
url: /ja/python-net/multithreading/
keywords:
- マルチスレッディング
- 複数スレッド
- 並列処理
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）でのマルチスレッディングにより、PowerPoint および OpenDocument の処理が向上します。効率的なプレゼンテーション ワークフローのベストプラクティスをご確認ください。"
---

## **はじめに**

プレゼンテーションを使用した並列処理は（解析/ロード/クローンを除いて）可能で、ほとんどの場合はうまく動作しますが、複数スレッドでライブラリを使用すると結果が正しくない可能性がわずかにあります。

マルチスレッド環境で単一の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを使用しないことを**強く推奨**します。そうしないと、予測できないエラーや検出が難しい失敗が発生する可能性があります。

複数スレッドで [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスをロード、保存、またはクローンすることは **安全ではありません**。このような操作は **サポートされていません**。このようなタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して操作を並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーション スライドを並列で画像に変換**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。複数スレッドで単一の `Presentation` インスタンスを使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドで個別のプレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例はその方法を示しています。
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


## **よくある質問**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始される前に、プロセス/アプリドメインごとに一度だけ実行すれば十分です。もし [license setup](/slides/ja/python-net/licensing/) が同時に呼び出される可能性がある場合（例: 遅延初期化時）、その呼び出しを同期してください。ライセンス設定メソッド自体はスレッドセーフではありません。

**スレッド間で `Presentation` または `Slide` オブジェクトを受け渡すことはできますか？**

スレッド間で「ライブ」なプレゼンテーションオブジェクトを渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に別々のプレゼンテーション/スライドコンテナを事前に作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿ったものです。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像などの異なる形式へのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、このようなタスクは通常正しく並列化されます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でのグローバルフォント設定（フォルダー、置換など）にはどう対処すべきですか？**

スレッドを開始する前にすべてのグローバルフォント設定を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへのアクセス競合が解消されます。