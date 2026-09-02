---
title: Pythonでプレゼンテーション プロパティを管理する
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
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でプレゼンテーション プロパティをマスターし、PowerPoint ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は文書プロパティの 2 種類、**組み込み** と **カスタム** をサポートしています。これらのプロパティタイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[DocumentProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/) クラスを介してプレゼンテーションの文書プロパティを操作できます。このクラスのインスタンスは、[Presentation.document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/document_properties/) プロパティから取得されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="注意" %}}
**Application** および **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for Python via .NET x.x.x が表示されますのでご注意ください。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint は、プレゼンテーション ファイルにいくつかのプロパティを追加する機能を提供します。これらの文書プロパティにより、文書（プレゼンテーション ファイル）とともに有用な情報を保存できます。文書プロパティは次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、文書タイトル、著者名、文書統計情報など、文書に関する一般的な情報を含みます。**カスタム** プロパティは、ユーザーが **Name/Value** ペアとして定義するもので、名前と値の両方がユーザーによって決められます。Aspose.Slides for Python via .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスして変更できます。Microsoft PowerPoint 2007 は、プレゼンテーション ファイルの文書プロパティを管理できるようにしています。操作手順は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルの文書プロパティを管理できるダイアログが表示されます。**Properties Dialog** では、**General, Summary, Statistics, Contents and Custom** など多数のタブがあり、それぞれ PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブは、PowerPoint ファイルのカスタムプロパティを管理するために使用されます。

## **組み込みプロパティへのアクセス**

**IDocumentProperties** オブジェクトで公開されているこれらのプロパティには、**Creator(Author)**、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数のプロデューサー間で共有されているか）、**PresentationFormat**、**Subject**、**Title** が含まれます。
```py
import aspose.slides as slides

# プレゼンテーションを表す Presentation クラスのインスタンスを作成する
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation に関連付けられたオブジェクトへの参照を作成する
    documentProperties = pres.document_properties

    # 組み込みプロパティを表示する
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

プレゼンテーション ファイルの組み込みプロパティを変更するのは、アクセスと同様に簡単です。目的のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、プレゼンテーション ファイルの組み込み文書プロパティをどのように変更できるかを示しています。
```py
import aspose.slides as slides

# プレゼンテーションを表す Presentation クラスのインスタンスを作成する
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Presentation に関連付けられたオブジェクトへの参照を作成する
    documentProperties = presentation.document_properties

    # 組み込みプロパティを設定する
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # プレゼンテーションをファイルに保存する
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for Python via .NET は、開発者がプレゼンテーションの文書プロパティにカスタム値を追加できるようにもしています。以下の例は、プレゼンテーションにカスタムプロパティを設定する方法を示しています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:
    # ドキュメント プロパティを取得する
    documentProperties = presentation.document_properties

    # カスタム プロパティを追加する
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 特定のインデックスのプロパティ名を取得する
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 選択したプロパティを削除する
    documentProperties.remove_custom_property(getPropertyName)

    # プレゼンテーションを保存する
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムプロパティのアクセスと変更**

Aspose.Slides for Python via .NET は、開発者がカスタムプロパティの値にアクセスできるようにしています。以下の例は、プレゼンテーションのすべてのカスタムプロパティにアクセスし、変更する方法を示しています。
```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンスを作成する
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation に関連付けられた document_properties オブジェクトへの参照を作成する
    documentProperties = presentation.document_properties

    # カスタム プロパティにアクセスして変更する
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # カスタム プロパティの名前と値を表示する
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # カスタム プロパティの値を変更する
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # プレゼンテーションをファイルに保存する
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` は、2 番目の引数として渡された要素数 1 のリストを通じて値を返し、格納された値はそのリスト内の既存要素の型にキャストされます。上記の例では `[""]` を使用しているため文字列プロパティを読み取ります。数値として保存されたプロパティを読み取る場合は、`[0]` のような数値プレースホルダーを渡してください。そうしないと `InvalidCastException` がスローされます。

## **校正言語の設定**

Aspose.Slides は、`Language_Id` プロパティ（[PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) クラスで公開）を提供し、PowerPoint 文書の校正言語を設定できるようにします。校正言語は、PowerPoint のスペルと文法がチェックされる言語です。

この Python コードは、PowerPoint の校正言語を設定する方法を示しています。
```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # 校正言語の Id を設定する
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **既定言語の設定**

この Python コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。
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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を介して文書プロパティを操作する方法を確認してください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合は、値を変更するか空に設定することができます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全に読み込まずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用し、次に [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成せずに保存された文書メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/python-net/examine-presentation/) を参照してください。