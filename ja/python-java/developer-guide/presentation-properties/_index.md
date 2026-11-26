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
description: "Aspose.Slides for Python via Java でプレゼンテーション プロパティを完全に管理し、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides for Python via Java は **組み込み** および **カスタム** ドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値など、プレゼンテーションのメタデータを読み取りおよび更新できます。

Aspose.Slides では、[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) クラスを通じてプレゼンテーションのドキュメント プロパティを操作できます。このクラスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) によって返されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションの保存時にアプリケーションおよびプロデューサーのメタデータを管理します。このフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツとともに記述情報を保存します。これらは次の 2 つのカテゴリに分類されます。

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを保存します。

Aspose.Slides for Python via Java は両方のカテゴリへのアクセスを提供します。PowerPoint では、**File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認します。ダイアログは情報を **概要**, **統計**, **内容**, **カスタム** などのタブにまとめます。**カスタム** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くパスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) を `False` で呼び出した後にプレゼンテーションが暗号化されると、ドキュメント プロパティは公開されたままになります。アプリケーションはその後、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出し、開くパスワードを提供せずに公開メタデータを読み取ることができます。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) は Aspose.Slides がロードする内容を制御します。暗号化にプロパティが含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例は、ドキュメント プロパティが公開された状態の暗号化されたプレゼンテーションが必要です。ロード モードを [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) で確認し、続いて [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) を使用して組み込みプロパティを読み取ります。

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

このモードでは、スライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を実行する前に、必ず [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) を確認してください。

{{% alert color="warning" title="Warning" %}}
公開メタデータは、作成者名、タイトル、件名、キーワード、会社情報、コメント、カスタム値を露出させる可能性があります。機密性の高いプロパティはプレゼンテーションと共に暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでのアクセスを特別に要求する場合のみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出してロードされたプレゼンテーションは、公開メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新するには正しい開くパスワードと完全なロードが必要です。

この例は、公開ドキュメント プロパティを持つ暗号化された PPTX プレゼンテーションと既知の開くパスワードが必要です。[LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) を使用してプレゼンテーション全体を開き、公開の組み込みプロパティを更新して結果を保存します。次に、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) を使用して暗号化が維持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

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

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) クラスは、[getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle)、[getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) などの getter メソッドを通じて組み込みメタデータを公開します。この例では既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、いくつかのフィールドは空の場合があります。

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

### **リビジョン番号と編集時間のレポート**

`presentations` フォルダー内の各 PPTX ファイルについて 1 行のレポートを作成するには、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を使用して、スライドをロードせずに [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) を読み取ります。Python via Java API は編集時間をミリ秒で返します。この例では、時間、分、秒としてフォーマットし、24 時間以上の場合は日数も表示します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

編集時間が 1 日 2 時間 5 分と記録されたプレゼンテーションの場合、レポートは以下の出力を示します。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) は、アプリケーションが [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) で変更できる値を取得します。リビジョン番号だけでは、プレゼンテーションが何回保存されたかやバージョン履歴を再構築することはできません。

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) は、ファイルに記録された編集時間を取得します。`00:00:00` の値は、誰かがプレゼンテーションを編集していても、保存された時間がゼロであることを意味します。

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) が返すオブジェクトの setter メソッドを使用します。この例では既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments)、[setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) を呼び出し、[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

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

## **ハイパーリンク ベースの管理**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) は、相対ハイパーリンク用のドキュメント レベルのベースを返します。[DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) を使用して変更またはクリアできます。これは、プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。個々のハイパーリンクの [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) とは別物で、ベースを変更しても保存されたリンクアドレスは書き換えられず、絶対的な宛先も変わりません。

この例では、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、新しいベースアドレスを設定し、プレゼンテーションを保存して再度開き、値を確認します。その後、空文字列でベースをクリアし、別の保存ファイルで空の値を検証します。例のベースアドレスは、リンクされたファイルの場所に置き換えてください。

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

2 つの検証メッセージは `True` を出力するはずです。ベースをクリアしても、個々のハイパーリンク アドレスはそのまま残ります。

`target.pptx` への相対リンクは、ベースが `old` フォルダーを指しているときは `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタムプロパティは、対応する組み込みフィールドがないメタデータを保存します。[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) メソッドを使用すると、プロパティ名で値を割り当てることができます。この例ではプレゼンテーションを作成し、テキスト値 2 つと整数バージョン値（`jpype.JInt` を使用して Java の整数を渡す）を追加し、[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) でプレゼンテーションを保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換えられます。

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

## **カスタムプロパティへのアクセスと変更**

この例ではカスタムプロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) を使用してそれらをイテレートします。[getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) は 0 ベースのインデックスを受け取り、[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) で使用される名前を返します。例では各元の名前と値を出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタムプロパティがない場合、ループは何も変更しません。

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

Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認するには、オンライン アプリの [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) をお試しください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合は、値を変更するか空に設定することが可能です。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用し、その後 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) で [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取ります。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/python-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを、開くパスワードなしで読み取れますか？**

はい。プレゼンテーションは、[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) を `False` で呼び出した後に暗号化されており、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) を `True` で呼び出してロードされている必要があります。

**ドキュメント プロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化されたプロパティのデータは一致している必要があるため、暗号化された PPTX ファイルを更新するには、正しい開くパスワードでプレゼンテーション全体をロードする必要があります。