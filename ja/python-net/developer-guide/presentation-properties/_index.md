---
title: Python でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/python-net/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 詳細プロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でプレゼンテーション プロパティをマスターし、PowerPoint ファイルの検索、ブランディング、ワークフローを効率化します。"
---

## **プレゼンテーション プロパティについて**

前述のとおり、Aspose.Slides for Python via .NET は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は Aspose.Slides for Python via .NET API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Python via .NET は、[IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) クラスを提供し、[Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) プロパティを通じてプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表します。開発者は **Presentation** オブジェクトが公開する [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

{{% alert color="primary" %}} 
Application および Producer フィールドの値は設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for Python via .NET x.x.x が表示されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint では、プレゼンテーション ファイルにプロパティを追加する機能が提供されています。これらのドキュメント プロパティにより、文書（プレゼンテーション ファイル）と共に有用な情報を保存できます。プロパティは次の 2 種類に分かれます。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み** プロパティは、文書のタイトル、作者名、統計情報など、文書全般に関する情報を含みます。**カスタム** プロパティは、ユーザーが **名前/値** ペアとして定義するもので、名前と値の両方をユーザーが決定します。Aspose.Slides for Python via .NET を使用すると、組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。手順は、Office アイコンをクリックし、**準備 | プロパティ | 詳細プロパティ** を選択するだけです。**詳細プロパティ** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。**プロパティ ダイアログ** では、**全般、要約、統計、内容、カスタム** といった多数のタブページがあり、PowerPoint ファイルに関するさまざまな情報を構成できます。**カスタム** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **組み込みプロパティへのアクセス**

**IDocumentProperties** オブジェクトが公開するプロパティには、**Creator(Author)**、**Description**、**Keywords**、**Created**（作成日時）、**Modified**（変更日時）、**Printed**（最終印刷日時）、**LastModifiedBy**、**SharedDoc**（複数のプロデューサー間で共有されているか）、**PresentationFormat**、**Subject**、**Title** などがあります。

```py
import aspose.slides as slides

# プレゼンテーションを表す Presentation クラスのインスタンスを作成
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Presentation に紐付くオブジェクトへの参照を作成
    documentProperties = pres.document_properties

    # 組み込みプロパティを表示
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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を代入すれば、プロパティの値が変更されます。以下のサンプルでは、組み込みドキュメント プロパティを変更する方法を示しています。

```py
import aspose.slides as slides

# Presentation を表す Presentation クラスのインスタンスを作成
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Presentation に紐付くオブジェクトへの参照を作成
    documentProperties = presentation.document_properties

    # 組み込みプロパティを設定
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # プレゼンテーションをファイルに保存
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for Python via .NET では、プレゼンテーション ドキュメント プロパティにカスタムの値を追加することもできます。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:
    # ドキュメント プロパティを取得
    documentProperties = presentation.document_properties

    # カスタム プロパティを追加
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 特定のインデックスのプロパティ名を取得
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 選択したプロパティを削除
    documentProperties.remove_custom_property(getPropertyName)

    # プレゼンテーションを保存
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム プロパティの取得と変更**

Aspose.Slides for Python via .NET では、カスタム プロパティの値にアクセスし、変更することも可能です。以下のサンプルは、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンスを作成
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Presentation に紐付く document_properties オブジェクトへの参照を作成
    documentProperties = presentation.document_properties

    # カスタム プロパティにアクセスして変更
    for i in range(documentProperties.count_of_custom_properties):
        # カスタム プロパティの名前と値を表示
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # カスタム プロパティの値を変更
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # プレゼンテーションをファイルに保存
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **校正言語の設定**

Aspose.Slides は、[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) クラスが提供する `Language_Id` プロパティを使用して、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックと文法チェックが行われる言語です。

以下の Python コードは、PowerPoint の校正言語を設定する方法を示しています。

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

    # 校正言語の Id を設定
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **デフォルト言語の設定**

以下の Python コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。

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

## **ライブ例**

[**Aspose.Slides メタデータ**](https://products.aspose.app/slides/metadata) オンライン アプリを試して、Aspose.Slides API でドキュメント プロパティを操作する方法を確認してください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当プロパティが許可している場合は空に設定したりすることは可能です。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したりチェックしたりする必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーションを完全に読み込まずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) クラスの [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) メソッドを使用してプレゼンテーション情報のみを取得し、[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) クラスの [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) メソッドでプロパティを読み取ることで、メモリ使用量を抑えつつ高速にプロパティへアクセスできます。