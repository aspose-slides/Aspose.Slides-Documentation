---
title: プレゼンテーションフォーマット
type: docs
weight: 10
url: /python-net/presentation-format/
---

Aspose.Slides for Python via .NET は、プレゼンテーションフォーマットをロードする前に取得するために使用される [**PresentationFactory**](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) クラスを提供します。

プレゼンテーションフォーマットを取得するには、以下の手順に従ってください：

1. [**IPresentationInfo**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/) クラスのインスタンスを作成します。
1. プレゼンテーションフォーマットに関する情報を取得します。

以下の例では、プレゼンテーションフォーマットを取得しています：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```