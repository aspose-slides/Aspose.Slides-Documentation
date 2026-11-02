---
title: Python でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/python-java/presentation-properties/
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
description: "Aspose.Slides for Python via Java でプレゼンテーション プロパティをマスターし、PowerPoint と OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides for Python via Java は **組み込み** および **カスタム** ドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーション メタデータを読み取りおよび更新できます。

Aspose.Slides では、[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) クラスを使用してプレゼンテーションのドキュメント プロパティを操作できます。このクラスのインスタンスは [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) によって返されます。以下の例は、これらのプロパティの読み取り、変更、管理方法を示しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションの保存時にアプリケーションと作成者のメタデータを管理します。このフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツと共に記述情報を格納します。これらは 2 つのカテゴリに分かれます。

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計などの標準メタデータを含みます。  
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを格納します。

Aspose.Slides for Python via Java は両方のカテゴリへのアクセスを提供します。PowerPoint では、**ファイル → 情報 → プロパティ → 詳細プロパティ** を選択してドキュメント メタデータを確認します。ダイアログは情報を **概要**、**統計**、**目次**、**カスタム** などのタブに分類します。**カスタム** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くためのパスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) を `False` で呼び出した後にプレゼンテーションが暗号化されると、ドキュメント プロパティは公開されたままになります。アプリケーションはその後、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出すことで、開くパスワードを提供せずに公開メタデータを読み取れます。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) は Aspose.Slides がロードする内容を制御します。暗号化は行いません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例は、ドキュメント プロパティが公開されたままの暗号化されたプレゼンテーションが必要です。[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) でロードモードを確認し、次に [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) を使用して組み込みプロパティを読み取ります:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、およびその他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を行う前に、必ず [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) を確認してください。

{{% alert color="warning" title="Warning" %}}
公開メタデータにより、作成者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が露出する可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出してロードされたプレゼンテーションは、公開メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新には正しい開くパスワードと完全なロードが必要です。

この例は、公開ドキュメント プロパティを持つ暗号化された PPTX プレゼンテーションと既知の開くパスワードが必要です。[LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) でプレゼンテーション全体を開き、公開の組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) を使用して暗号化が維持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) クラスは、[getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle)、[getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) などの getter メソッドを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、フィールドが空の場合もあります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) が返すオブジェクトのセッター メソッドを使用します。この例は既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments)、[setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) を呼び出し、[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ハイパーリンクベースの管理**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) は、相対ハイパーリンク用のドキュメントレベルのベースを返します。[DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) を使用して変更またはクリアできます。プレゼンテーションとそのリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) とは別であり、ベースを変更しても保存されたリンクアドレスや絶対的な宛先は書き換えられません。

この例は、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、新しいベースアドレスを設定し、プレゼンテーションを保存して再度開き、値を確認します。その後、空文字列でベースをクリアし、別の保存ファイルで空の値を検証します。例のベースアドレスは、リンクされたファイルの場所に置き換えてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

2 つの検証メッセージは `True` を出力するはずです。ベースをクリアしても個々のハイパーリンク アドレスはそのまま残ります。

`target.pptx` への相対リンクは、ベースが `old` フォルダーを指しているときに `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは引き続き同じファイルを開きます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタム プロパティは、対応する組み込みフィールドのないメタデータを格納します。[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) メソッドを使用すると、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値（`jpype.JInt` を使用して Java 整数を渡す）を追加し、[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) でプレゼンテーションを保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換わります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カスタム プロパティへのアクセスと変更**

この例はカスタム プロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) を使用してそれらを反復処理します。[getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) は 0 ベースのインデックスを受け取り、[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) で使用される名前を返します。例は元の名前と値をそれぞれ出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタム プロパティが存在しない場合、ループは何も変更しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ライブ例**

Aspose.Slides API を使用してドキュメント プロパティを操作する方法を確認するには、オンライン アプリの [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) をお試しください:

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティによっては値を変更するか、空に設定することが可能です。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[軽量プレゼンテーションインベントリの構築](/slides/ja/python-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを開くパスワードなしで読み取れますか？**

はい。プレゼンテーションは、[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) を `False` で呼び出した後に暗号化され、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出してロードする必要があります。

**ドキュメントプロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開くパスワードでプレゼンテーション全体をロードする必要があります。