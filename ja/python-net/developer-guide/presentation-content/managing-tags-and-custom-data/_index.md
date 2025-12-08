---
title: "Pythonでプレゼンテーションのタグとカスタムデータを管理する"
linktitle: "タグとカスタムデータ"
type: docs
weight: 300
url: /ja/python-net/managing-tags-and-custom-data/
keywords:
- ドキュメントプロパティ
- タグ
- カスタムデータ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でタグとカスタムデータの追加、取得、更新、削除方法を学び、PowerPoint と OpenDocument のプレゼンテーション例を示します。"
---

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（拡張子が .pptx のアイテム）は、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義しています。

プレゼンテーションの要素の一つである *スライド* は、単一のスライドの内容を含む *スライド パート* です。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーのペア値です。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは IDocumentProperties.Keywords プロパティに対応します。このサンプルコードは、Aspose.Slides for Python via .NET を使用して [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のタグの値を取得する方法を示しています：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます：

- カスタム プロパティの名前 - `MyTag`  
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをすべてまとめたい場合、北米というタグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Python via .NET を使用して [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) にタグを追加する方法を示しています：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


タグは [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) に対しても設定できます：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


または個々の [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) に対しても設定できます：
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一括で削除する [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を反復せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) で [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) を使用します。それはすべてのタグ名の配列を返します。