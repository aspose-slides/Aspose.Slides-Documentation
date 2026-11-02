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
- カスタム プロパティ
- 高度なプロパティ
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
## **概要**

Aspose.Slides for Python via .NET は **組み込み** と **カスタム** のドキュメント プロパティをサポートします。これらのプロパティを使用して、作者、タイトル、ユーザー定義値などのプレゼンテーション メタデータを読み取りおよび更新します。

Aspose.Slides は [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスを介してプレゼンテーション ドキュメント プロパティを操作できます。このクラスのインスタンスは [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) で返されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションとプロデューサーのメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツとともに記述情報を格納します。カテゴリは 2 つに分かれます:

- **組み込みプロパティ** は、タイトル、作者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを格納します。

Aspose.Slides for Python via .NET は両方のカテゴリへのアクセスを提供します。PowerPoint では、**File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認します。ダイアログは情報を **Summary**、**Statistics**、**Contents**、**Custom** といったタブに分類します。ユーザー定義プロパティを管理するには **Custom** タブを使用します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開封パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。プレゼンテーションが [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) を `False` に設定して暗号化されている場合、ドキュメント プロパティは公開されたままです。アプリケーションはその後、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) を `True` に設定して、開封パスワードを提供せずに公開メタデータを読み取ることができます。

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) は Aspose.Slides が読み込む対象を制御します。暗号化にプロパティが含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

この例は、ドキュメント プロパティが公開されたままの暗号化プレゼンテーションを必要とします。ロード モードを [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) で確認し、次に [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) を介して組み込みプロパティを読み取ります。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

このモードではスライド コンテンツは読み込まれません。スライド、マスタ、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を実行する前に、必ず [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) をチェックしてください。

{{% alert color="warning" title="Security" %}}
公開メタデータは、作者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値などを露出させる可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) で読み込まれたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides は、暗号化されたプレゼンテーション内部の対応データと整合性を保つ必要があるため、メタデータのみのオブジェクトから変更されたプロパティを保存できません。そのため、正しい開封パスワードで完全にロードする必要があります。

この例は、公開ドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知の開封パスワードを前提としています。[LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) でプレゼンテーション全体を開き、公開された組み込みプロパティを更新して保存します。その後、[PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスは、[DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) などの型付きプロパティを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されているメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、空のフィールドがある場合があります。

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) が公開する書き込み可能プロパティに値を割り当てます。この例は既存のプレゼンテーションを開き、[DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)、[DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/)、[DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) を設定し、[Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクベースの管理**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) は相対ハイパーリンク用のドキュメント レベルのベースを保持します。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) とは別物で、ベースを変更しても保存されたリンクアドレスは書き換えられず、絶対的な宛先も変更されません。

この例は `target.html` のような相対リンクと、ファイルまたは Web サイトへの絶対リンクの両方を含むプレゼンテーションを前提とします。既存のベースを読み取り、新しいベース アドレスを割り当て、プレゼンテーションを保存して再度開き、値を確認します。その後、`""` でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスはリンクされたファイルの場所に置き換えてください。

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

2 つの検証メッセージは `True` と出力されるはずです。ベースをクリアしても個々のハイパーリンク アドレスはそのまま残ります。

相対リンク `target.pptx` はベースが `old` フォルダーを指しているとき `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタム プロパティは、組み込みフィールドに対応しないメタデータを格納します。[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) メソッドを使用すると、プロパティ名で値を割り当てることができます。この例はプレゼンテーションを作成し、テキスト値 2 つと整数のバージョン値を追加して、[Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) で保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換えられます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムプロパティへのアクセスと変更**

この例はカスタム プロパティを含むプレゼンテーションを開き、[DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) を使用してそれらを反復処理します。[DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) は 0 ベースのインデックスを受け取り、[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) で使用される名前を返します。この例はカスタム プロパティがすべて文字列であるプレゼンテーションを前提とします。元の名前と値をそれぞれ出力し、すべての値を番号付き文字列に置き換えて変更を保存します。カスタム プロパティが存在しない場合、ループは何も変更しません。

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) は第2引数として渡された 1 要素リストを通じて値を返します。プレースホルダーは格納されたプロパティの型と一致させる必要があります。文字列の場合は `[""]`、整数の場合は `[0]` を使用してください。型が一致しないと `InvalidCastException` が発生します。カスタム プロパティのスキーマに合わせてプレースホルダーを選択してください。

## **ライブ例**

[**PowerPoint メタデータの表示と編集**](https://products.aspose.app/slides/metadata) オンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティが許可している場合は、その値を変更するか空に設定できます。

**既に存在するカスタム プロパティを追加するとどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用し、続いて [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例と形式固有の制限については [Build a Lightweight Presentation Inventory](/slides/ja/python-net/examine-presentation/) を参照してください。

**開封パスワードなしで暗号化されたプレゼンテーションの公開プロパティを読み取れますか？**

はい。プレゼンテーションが [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) を `False` に設定して暗号化されており、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) が `True` に設定されている必要があります。

**ドキュメント プロパティのみのモードで暗号化された PPTX ファイルを更新できますか？**

できません。公開プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには正しい開封パスワードでプレゼンテーション全体をロードする必要があります。