---
title: PythonでPowerPointプレゼンテーションをWord文書に変換
linktitle: PowerPointからWordへ
type: docs
weight: 110
url: /ja/python-net/convert-powerpoint-to-word/
keywords:
- PowerPointからDOCXへ
- OpenDocumentからDOCXへ
- プレゼンテーションからDOCXへ
- スライドからDOCXへ
- PPTからDOCXへ
- PPTXからDOCXへ
- ODPからDOCXへ
- PowerPointからDOCへ
- OpenDocumentからDOCへ
- プレゼンテーションからDOCへ
- スライドからDOCへ
- PPTからDOCへ
- PPTXからDOCへ
- ODPからDOCへ
- PowerPointからWordへ
- OpenDocumentからWordへ
- プレゼンテーションからWordへ
- スライドからWordへ
- PPTからWordへ
- PPTXからWordへ
- ODPからWordへ
- PowerPointを変換
- OpenDocumentを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- ODPを変換
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを Word 文書に簡単に変換する方法を学びます。サンプル Python コード付きのステップバイステップガイドは、ドキュメントワークフローを効率化したい開発者向けのソリューションを提供します。"
---

## **概要**

本記事では、開発者向けに Aspose.Slides for Python via .NET と Aspose.Words for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するソリューションを提供します。ステップバイステップのガイドで、変換プロセスのすべての段階を案内します。

## **プレゼンテーションを Word 文書に変換する**

以下の手順に従って、PowerPoint または OpenDocument プレゼンテーションを Word 文書に変換します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーション ファイルを読み込みます。
2. [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) と [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) クラスのインスタンスを作成して、Word 文書を生成します。
3. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) プロパティを使用して、Word 文書のページサイズをプレゼンテーションのサイズに合わせます。
4. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) プロパティを使用して、Word 文書の余白を設定します。
5. [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) プロパティを使用して、すべてのプレゼンテーション スライドを処理します。
   - [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) クラスの `get_image` メソッドを使用してスライド画像を生成し、メモリ ストリームに保存します。
   - [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) クラスの `insert_image` メソッドを使用して、スライド画像を Word 文書に追加します。
6. Word 文書をファイルに保存します。

たとえば、次のようなプレゼンテーション "sample.pptx" があるとします。

![PowerPoint プレゼンテーション](PowerPoint.png)

以下の Python コード例は、PowerPoint プレゼンテーションを Word 文書に変換する方法を示しています。
```py
import aspose.slides as slides
import aspose.words as words

# プレゼンテーション ファイルを読み込みます。
with slides.Presentation("sample.pptx") as presentation:

    # Document と DocumentBuilder オブジェクトを作成します。
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Word 文書のページサイズを設定します。
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Word 文書の余白を設定します。
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # すべてのプレゼンテーション スライドを処理します。
    for slide in presentation.slides:

        # スライド画像を生成し、メモリ ストリームに保存します。
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # スライド画像を Word 文書に追加します。
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Word 文書をファイルに保存します。
    document.save("output.docx")
```


結果：

![Word 文書](Word.png)

{{% alert color="primary" %}} 
PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換することで得られるメリットをご確認いただくには、当社の [**オンライン PPT から Word へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。 
{{% /alert %}}

## **よくある質問**

**PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

Python プロジェクトに [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) と [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) の各パッケージを追加するだけで済みます。両パッケージはスタンドアロン API として動作し、Microsoft Office をインストールする必要はありません。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides for Python .NET は、PPT、PPTX、ODP などの一般的なファイル形式を含む、すべてのプレゼンテーション形式を[サポートしています](/slides/ja/python-net/supported-file-formats/)。これにより、さまざまなバージョンの Microsoft PowerPointで作成されたプレゼンテーションを扱うことができます。