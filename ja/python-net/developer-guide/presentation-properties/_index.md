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
description: "Aspose.Slides for Python via .NET でプレゼンテーション プロパティをマスターし、PowerPoint ファイルの検索、ブランド付け、ワークフローを合理化します。"
---
## **導入**

Aspose.Slides for Python via .NET は **組み込み** と **カスタム** のドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーション メタデータを読み取り、更新できます。

Aspose.Slides を使用すると、[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスを介してプレゼンテーションのドキュメント プロパティを操作できます。このクラスのインスタンスは[Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)で取得されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="注意" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションおよびプロデューサーのメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツと一緒に説明情報を格納します。これらは次の 2 つのカテゴリに分かれます:

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタム プロパティ** は、ユーザー定義の名前/値ペアを格納します。

Aspose.Slides for Python via .NET は両方のカテゴリへのアクセスを提供します。PowerPoint では、**File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認します。ダイアログは情報を **Summary**、**Statistics**、**Contents**、**Custom** などのタブに分類します。**Custom** タブを使用してユーザー定義のプロパティを管理します。

## **暗号化されたプレゼンテーションからパブリック プロパティを読み取る**

開封パスワードは通常、プレゼンテーションのコンテンツとドキュメント プロパティの両方を保護します。プレゼンテーションが[ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)を `False` に設定して暗号化されている場合、ドキュメント プロパティはパブリックのままです。この場合、アプリケーションは[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/)を `True` に設定し、開封パスワードを提供せずにパブリック メタデータを読み取ることができます。

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) は Aspose.Slides がロードするものを制御します。暗号化にプロパティが含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例は、ドキュメント プロパティがパブリックのまま暗号化されたプレゼンテーションが必要です。[ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)でロードモードを確認し、続いて[Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/)で組み込みプロパティを読み取ります。

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

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルを必要とする操作を行う前に、必ず[ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)をチェックしてください。

{{% alert color="warning" title="セキュリティ" %}}
パブリック メタデータは、作成者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値などを露出する可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ、パブリックのままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) でロードされたプレゼンテーションはパブリック メタデータの読み取りを目的としています。Aspose.Slides はそのメタデータのみのオブジェクトから変更されたプロパティを保存できません。パブリック プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新には正しい開封パスワードと完全なロードが必要です。

この例は、パブリックなドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知の開封パスワードが必要です。[LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) でプレゼンテーション全体を開き、パブリックな組み込みプロパティを更新して保存します。その後、[PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしでパブリック メタデータを再度開き、新しい値を検証します。

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

アプリケーションがプレゼンテーションのコンテンツを復号またはロードできない場合、暗号化された PPTX ファイルのパブリック プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスは、[DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) などの型付きプロパティを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、格納されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、一部のフィールドは空の場合があります。

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

### **リビジョン番号と編集時間のレポート**

`presentations` フォルダー内の各 PPTX ファイルについてリビジョン番号と総編集時間をレポートするには、[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) を使用してスライドをロードせずに[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) を取得します。Python は期間を `timedelta` として表示し、記録時間が 24 時間に達した場合は日数も含めます。

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

1 日 2 時間 5 分の編集時間が記録されたプレゼンテーションの場合、レポートは次の行を含みます。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) は書き込み可能なメタデータです。その値だけではプレゼンテーションが何回保存されたかやバージョン履歴を復元することはできません。

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) はファイルに保存された編集期間を示します。`0:00:00` の値は、誰かがプレゼンテーションを編集したかどうかに関係なく、記録された期間がゼロであることを意味します。

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

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) は相対ハイパーリンク用のドキュメント レベルのベースを保持します。プレゼンテーションやリンクされたファイルを別の場所に移動するときに便利です。これは個々のハイパーリンクの[Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) とは別で、ベースを変更しても保存されたリンク アドレスは書き換えられず、絶対的な宛先も変わりません。

この例は、`target.html` のような相対リンクとファイルまたはウェブサイトへの絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、新しいベース アドレスを割り当て、プレゼンテーションを保存して再度開き値を確認します。その後、`""` でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスは、リンクされたファイルの場所に置き換えてください。

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

ベースが `old` フォルダーを指しているとき、`target.pptx` への相対リンクは `old/target.pptx` を開きました。ベースを `new` フォルダーに変更して保存し、プレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタム プロパティは、組み込みフィールドに対応しないメタデータを格納します。[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) メソッドを使用すると、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、テキスト値 2 件と整数のバージョン値を追加し、[Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) で保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換えられます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム プロパティへのアクセスと変更**

この例はカスタム プロパティを含むプレゼンテーションを開き、[DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) を使用してそれらを反復処理します。[DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) は 0 ベースのインデックスを受け取り、[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) で使用される名前を返します。この例はカスタム プロパティがすべて文字列であるプレゼンテーションが必要です。各元の名前と値を出力し、すべての値を番号付き文字列に置き換えて変更を保存します。カスタム プロパティが存在しない場合、ループは何も変更しません。

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) は第2引数として渡された 1 要素のリストを通じて値を返します。プレースホルダーは格納されたプロパティの型と一致する必要があります：文字列の場合は `[""]`、整数の場合は `[0]` を使用します。型が一致しないと `InvalidCastException` が発生します。カスタム プロパティのスキーマに合わせてプレースホルダーを選択してください。

## **ライブ例**

[**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**How can I remove a built-in property from a presentation?**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合に限り、値を変更するか空に設定できます。

**What happens if I add a custom property that already exists?**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。プロパティを事前に削除したりチェックしたりする必要はなく、Aspose.Slides が自動的に値を更新します。

**Can I access presentation properties without fully loading the presentation?**

はい。[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用し、続いて [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) で [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例と形式固有の制限については[Build a Lightweight Presentation Inventory](/slides/ja/python-net/examine-presentation/) を参照してください。

**Can I read public properties of an encrypted presentation without its opening password?**

はい。プレゼンテーションが [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) を `False` に設定して暗号化されており、[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) が `True` に設定されている必要があります。

**Can I update an encrypted PPTX file in document-properties-only mode?**

いいえ。パブリック および 暗号化されたプロパティ データは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには正しい開封パスワードでプレゼンテーション全体をロードする必要があります。