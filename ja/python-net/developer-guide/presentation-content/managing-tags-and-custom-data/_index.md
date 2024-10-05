---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
keywords: "タグ, カスタムデータ, タグの値, タグの追加, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにタグとカスタムデータを追加する"
---

## プレゼンテーションファイルのデータストレージ

PPTXファイル（.pptx拡張子のアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されます。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素の1つである*スライド*は、*スライドパート*に1つのスライドの内容が含まれます。スライドパートには、ISO/IEC 29500で定義されたユーザー定義タグなど、他の多くのパートとの明示的な関係を持つことが許可されています。

カスタムデータ（プレゼンテーションに特有のもの）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)）およびCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)）として存在することができます。

{{% alert color="primary" %}} 

タグは本質的に文字列キーのペア値です。

{{% /alert %}} 

## タグの値を取得する

スライドでは、タグはIDocumentProperties.Keywordsプロパティに対応します。このサンプルコードは、Aspose.Slides for Python via .NETを使用して[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)からタグの値を取得する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## プレゼンテーションにタグを追加する

Aspose.Slidesを使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の2つのアイテムで構成されます：

- カスタムプロパティの名前 - `MyTag` 
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合は、それらのプレゼンテーションにタグを追加することで利益を得ることができます。たとえば、北アメリカの国々からのすべてのプレゼンテーションをカテゴリ分けする場合、北アメリカのタグを作成し、関連する国（アメリカ、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Python via .NETを使用して[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)にタグを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

タグは[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)にも設定できます：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

また、個々の[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)にも設定できます：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```