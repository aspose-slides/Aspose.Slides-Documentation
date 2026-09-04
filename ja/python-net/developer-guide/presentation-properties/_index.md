---
title: Pythonでプレゼンテーション プロパティを管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/python-net/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
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
## **導入**

Aspose.Slides は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[DocumentProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/) クラスを介してプレゼンテーション ドキュメント プロパティを操作できます。このクラスのインスタンスは、[Presentation.document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/document_properties/) プロパティから取得されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}
Aspose Ltd. と Aspose.Slides for Python via .NET x.x.x が **Application** および **Producer** フィールドに表示されるため、これらのフィールドに値を設定することはできません。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint には、プレゼンテーション ファイルにいくつかのプロパティを追加する機能があります。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と一緒に有用な情報を保存できます。ドキュメント プロパティは次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、ドキュメント タイトル、作者名、統計情報など、ドキュメントに関する一般的な情報を含みます。**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するもので、名前も値もユーザーが決めます。Aspose.Slides for Python via .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** のメニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。**Properties Dialog** では、**General, Summary, Statistics, Contents, Custom** といった多数のタブ ページがあり、PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開封パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。プレゼンテーションが [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) を `False` に設定して暗号化されている場合、ドキュメント プロパティは公開されたままになります。アプリケーションはその後、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/only_load_document_properties/) を `True` に設定し、開封パスワードを提供せずに公開メタデータを読み取れます。

`only_load_document_properties` は Aspose.Slides が何をロードするかを制御します。暗号化されたプロパティが含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

以下の例は、[ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) でロード モードを確認し、次に [Presentation.document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/document_properties/) を使用して組み込みプロパティを読み取ります。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、およびその他のプレゼンテーション オブジェクトは利用できなくなります。アプリケーションは、プレゼンテーション オブジェクト全体が必要な操作を実行する前に、必ず `is_only_document_properties_loaded` をチェックすべきです。

{{% alert color="warning" title="Security" %}}
公開メタデータにより、作者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、`only_load_document_properties` で読み込まれたプレゼンテーションは公開メタデータの読み取り専用として意図されています。Aspose.Slides は、公開プロパティが暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、メタデータのみのオブジェクトから変更されたプロパティを保存できません。そのため、正しい開封パスワードで完全にロードしなければ更新できません。

以下の例は、[LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) でプレゼンテーションを開き、公開の組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo.is_encrypted](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/is_encrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開き、新しい値を検証します。

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**
**IDocumentProperties** オブジェクトで公開されるこれらのプロパティには、**Creator(Author)**、**Description**、**Keywords**、**Created**（作成日時）、**Modified**（更新日時）、**Printed**（最終印刷日時）、**LastModifiedBy**、**SharedDoc**（共有ドキュメントか）、**PresentationFormat**、**Subject**、**Title** が含まれます。
```py
import aspose.slides as slides

# プレゼンテーションを表す Presentation クラスのインスタンスを作成
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation に関連付けられたオブジェクトへの参照を作成
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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。目的のプロパティに文字列値を割り当てるだけで、プロパティ値が変更されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーションを表す Presentation クラスのインスタンスを作成
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Presentation に関連付けられたオブジェクトへの参照を作成
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

Aspose.Slides for Python via .NET は、プレゼンテーション ドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。

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

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for Python via .NET は、カスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンスを作成
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation に関連付けられた document_properties オブジェクトへの参照を作成
    documentProperties = presentation.document_properties

    # カスタム プロパティにアクセスして変更
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # カスタム プロパティの名前と値を表示
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # カスタム プロパティの値を変更
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # プレゼンテーションをファイルに保存
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` は、2 番目の引数として渡された 1 要素リストを通じて値を返し、格納された値はそのリスト内の要素の型にキャストされます。上記の例は `[""]` を使用しているため文字列プロパティを読み取ります。数値として格納されたプロパティを読み取るには `[0]` のような数値プレースホルダーを渡してください。そうしないと `InvalidCastException` がスローされます。

## **校正言語の設定**

Aspose.Slides は、[PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) クラスで公開されている `Language_Id` プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックと文法チェックが行われる言語です。

以下の Python コードは、PowerPoint の校正言語を設定する方法を示しています。

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

    # 校正言語の ID を設定
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **既定言語の設定**

以下の Python コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。

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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティが許可する場合は値を変更したり空に設定したりできます。

**既に存在するカスタム プロパティを追加した場合、どうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用し、次に [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/python-net/examine-presentation/) を参照してください。

**開封パスワードなしで暗号化されたプレゼンテーションの公開プロパティを読み取れますか？**

はい。プレゼンテーションが `encrypt_document_properties` を `False` に設定して暗号化され、`only_load_document_properties` を `True` に設定してロードされた場合に可能です。

**ドキュメント プロパティのみのモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、正しい開封パスワードでプレゼンテーション全体をロードしない限り、暗号化された PPTX ファイルの更新はできません。