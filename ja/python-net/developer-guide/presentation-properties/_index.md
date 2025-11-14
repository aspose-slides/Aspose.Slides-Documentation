---
title: Python でプレゼンテーションのプロパティを管理する
linktitle: プレゼンテーションのプロパティ
type: docs
weight: 70
url: /ja/python-net/presentation-properties/
keywords:
- PowerPoint のプロパティ
- プレゼンテーションのプロパティ
- ドキュメントのプロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメントのメタデータ
- メタデータの編集
- 校正言語
- 既定の言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でプレゼンテーションの各種プロパティを使いこなし、PowerPoint ファイルの検索性、ブランディング、ワークフローを効率化しましょう。"
---

## **ライブ例**
[**Aspose.Slides メタデータ**](https://products.aspose.app/slides/metadata) オンラインアプリを試して、Aspose.Slides APIを介してドキュメントプロパティを操作する方法を確認してください：

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **プレゼンテーションプロパティについて**
Aspose.Slides for Python via .NETは、**組み込み**プロパティと**カスタム**プロパティの2種類のドキュメントプロパティをサポートしていることを前述しました。したがって、開発者はAspose.Slides for Python via .NET APIを使用して両方の種類のプロパティにアクセスできます。Aspose.Slides for Python via .NETは、[Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)プロパティを介してプレゼンテーションファイルに関連付けられたドキュメントプロパティを表すクラス[IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/)を提供します。開発者は、以下に説明するように、**Presentation**オブジェクトによって公開されている[IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/)プロパティを使用してプレゼンテーションファイルのドキュメントプロパティにアクセスできます：



{{% alert color="primary" %}} 

**Application**および**Producer**フィールドに対して値を設定することはできないことに注意してください。なぜなら、Aspose Ltd.およびAspose.Slides for Python via .NET x.x.xがこれらのフィールドに表示されるためです。

{{% /alert %}} 


## **プレゼンテーションプロパティの管理**
Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供します。これらのドキュメントプロパティは、ドキュメント（プレゼンテーションファイル）とともに有用な情報を保存することができます。ドキュメントプロパティには次の2種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み**プロパティには、ドキュメントのタイトル、著者名、ドキュメント統計など、ドキュメントに関する一般的な情報が含まれています。**カスタム**プロパティは、ユーザーが**名前/値**のペアとして定義したもので、名前と値の両方がユーザーによって定義されます。Aspose.Slides for Python via .NETを使用して、開発者は組み込みプロパティとカスタムプロパティの値にアクセスし、変更することができます。Microsoft PowerPoint 2007は、プレゼンテーションファイルのドキュメントプロパティを管理することを許可します。すべての操作は、Microsoft PowerPoint 2007のOfficeアイコンをクリックし、その後**準備 | プロパティ | 詳細プロパティ**メニュー項目を選択するだけです。**詳細プロパティ**メニュー項目を選択すると、PowerPointファイルのドキュメントプロパティを管理するためのダイアログが表示されます。**プロパティダイアログ**では、**一般、概要、統計、内容、カスタム**などの多くのタブページがあることがわかります。これらすべてのタブページは、PowerPointファイルに関連するさまざまな情報を構成することを可能にします。**カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。
## **組み込みプロパティへのアクセス**
これらのプロパティは**IDocumentProperties**オブジェクトによって公開されており、次のものを含みます：**Creator(Author)**、**Description**、**Keywords**、**Created**（作成日）、**Modified**（最終変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**、および**Title**
```py
import aspose.slides as slides

# プレゼンテーションを表すPresentationクラスのインスタンスを作成します
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # プレゼンテーションに関連付けられたオブジェクトへの参照を作成します
    documentProperties = pres.document_properties

    # 組み込みプロパティを表示します
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```
## **組み込みプロパティの変更**
プレゼンテーションファイルの組み込みプロパティを変更するのは、それらにアクセスするのと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、そのプロパティの値が変更されます。以下の例では、プレゼンテーションファイルの組み込みドキュメントプロパティをどのように変更できるかを示しています。

```py
import aspose.slides as slides

# プレゼンテーションを表すPresentationクラスのインスタンスを作成します
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # プレゼンテーションに関連付けられたオブジェクトへの参照を作成します
    documentProperties = presentation.document_properties

    # 組み込みプロパティを設定します
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "プレゼンテーションプロパティの変更"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # プレゼンテーションをファイルに保存します
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムプレゼンテーションプロパティの追加**
Aspose.Slides for Python via .NETは、開発者がプレゼンテーションのドキュメントプロパティにカスタム値を追加できるようにします。以下に示す例では、プレゼンテーションのカスタムプロパティを設定する方法を示しています。

```py
import aspose.slides as slides

# Presentationクラスのインスタンスを作成します
with slides.Presentation() as presentation:
    # ドキュメントプロパティを取得します
    documentProperties = presentation.document_properties

    # カスタムプロパティを追加します
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 特定のインデックスでプロパティ名を取得します
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 選択したプロパティを削除します
    documentProperties.remove_custom_property(getPropertyName)

    # プレゼンテーションを保存します
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムプロパティへのアクセスと変更**
Aspose.Slides for Python via .NETは、開発者がカスタムプロパティの値にアクセスできるようにします。以下の例では、プレゼンテーションのすべてのカスタムプロパティにアクセスし、変更する方法を示しています。

```py
import aspose.slides as slides

# PPTXを表すPresentationクラスのインスタンスを作成します
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # プレゼンテーションに関連付けられたdocument_propertiesオブジェクトへの参照を作成します
    documentProperties = presentation.document_properties

    # カスタムプロパティにアクセスし、変更します
    for i in range(documentProperties.count_of_custom_properties):
        # カスタムプロパティの名前と値を表示します
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # カスタムプロパティの値を変更します
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # プレゼンテーションをファイルに保存します
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションが変更されたか作成されたかの確認**
Aspose.Slides for Python via .NETは、プレゼンテーションが変更されたか作成されたかを確認する機能を提供します。以下に示す例では、プレゼンテーションが作成されたのか変更されたのかを確認する方法を示しています。

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **校正言語の設定**

Aspose.Slidesは、PowerPointドキュメントの校正言語を設定できる`Language_Id`プロパティ（[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)クラスによって公開されています）を提供します。校正言語は、PowerPoint内のスペルと文法がチェックされる言語です。

以下のPythonコードは、PowerPointの校正言語を設定する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # 校正言語のIdを設定します
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **デフォルト言語の設定**

以下のPythonコードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```