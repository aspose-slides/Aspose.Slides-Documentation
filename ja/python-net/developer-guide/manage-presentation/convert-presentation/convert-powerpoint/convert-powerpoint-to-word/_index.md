---
title: PowerPointをWordに変換する
type: docs
weight: 110
url: /python-net/convert-powerpoint-to-word/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, Word, DOCX, DOC, PPTXをDOCXに, PPTをDOCに, PPTXをDOCに, PPTをDOCXに, Python, Aspose.Slides"
description: "PythonでPowerPointプレゼンテーションをWordに変換する"
---

プレゼンテーション（PPTまたはPPTX）のテキストコンテンツや情報を新たな方法で使用する予定がある場合、プレゼンテーションをWord（DOCまたはDOCX）に変換することで利益を得ることができます。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツ用のツールや機能が充実しています。
* Wordの編集機能に加え、コラボレーション、印刷、共有機能の強化もお楽しみいただけます。

{{% alert color="primary" %}} 

スライドからのテキストコンテンツを扱うことで得られる利点を確認するために、ぜひ[**プレゼンテーションからWordへのオンライン変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-word)をお試しください。

{{% /alert %}} 

## **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOCX）に変換するには、[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/)と[Aspose.Words for Python via .NET](https://products.aspose.com/words/python-net/)の両方が必要です。

スタンドアロンAPIとして、[Aspose.Slides](https://products.aspose.com/slides/python-net/) for Python via .NETは、プレゼンテーションからテキストを抽出するための機能を提供します。

[Aspose.Words](https://products.aspose.com/words/python-net/)は、アプリケーションがMicrosoft Wordを利用せずに文書を生成、修正、変換、レンダリング、印刷し、その他のタスクを実行できる高度な文書処理APIです。

## **PythonでPowerPointをWordに変換する**

1. program.pyファイルにこれらの名前空間を追加します：

```py
import aspose.slides as slides
import aspose.words as words
```

2. このコードスニペットを使用してPowerPointをWordに変換します：

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # スライド画像を生成
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # スライドのテキストを挿入
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```