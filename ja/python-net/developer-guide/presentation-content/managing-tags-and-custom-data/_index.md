---
title: Python でプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/python-net/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションの例とともに、Aspose.Slides for Python via .NET でタグとカスタム データの追加、読み取り、更新、削除方法を学びます。"
---
## **概要**

このドキュメントでは、Aspose.Slides が PowerPoint プレゼンテーションでタグおよびカスタム データをどのように扱うかを説明します。データが PPTX ファイルにどのように保存されるかを簡潔に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在し得ること、タグがキーと値の文字列ペアであることを説明します。

タグの値の取得方法や、プレゼンテーション、個々のスライド、またはシェイプにタグを追加する方法も示します。さらに、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するといった、一般的なタグ管理タスクについても取り上げます。

## **プレゼンテーション ファイルのデータ格納**

拡張子 .pptx のファイルは PresentationML 形式で保存され、Office Open XML 仕様の一部です。Office Open XML 形式はプレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素の一つである *スライド* は、単一スライドの内容を保持する *スライド パート* です。スライド パートは ISO/IEC 29500 で定義された User Defined Tags など、多くのパーツへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itagcollection/)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icustomxmlpartcollection/)）として存在する場合があります。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは IDocumentProperties.Keywords プロパティに対応します。以下のサンプルコードは、Aspose.Slides for Python via .NET の [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) でタグの値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

以下のサンプルコードは、Aspose.Slides for Python via .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) にタグを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

タグは [Slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) に対しても設定できます。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

または個々の [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) に対して設定できます。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **制限事項**

`custom_data.tags` コレクションを介して追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際、タグ構造へは **転送されません**。したがって、タグとして割り当てたカスタム識別子は PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例：`shape.alternative_text = "MyId"`）にカスタム識別子を保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に表示される場合があります。

## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[タグ コレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/) は [clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/clear/) 操作をサポートしており、すべてのキー-値ペアを一度に削除できます。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全な一覧を取得するには？**

[tag コレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/) の [get_names_of_tags](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/get_names_of_tags/) を使用すると、すべてのタグ名の配列が返されます。