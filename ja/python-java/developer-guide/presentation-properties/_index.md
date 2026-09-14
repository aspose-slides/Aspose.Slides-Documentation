---
title: Python でプレゼンテーション プロパティを管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/python-java/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
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
description: "Aspose.Slides for Python via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを合理化します。"
---
## **はじめに**

Aspose.Slides はドキュメント プロパティの 2 種類、**組み込み** と **カスタム** をサポートしています。これらのプロパティタイプはどちらも Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides を使用すると、[DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) クラスを通じてプレゼンテーションのドキュメント プロパティを操作できます。このクラスのインスタンスは[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDocumentProperties) によって返されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
**Application** および **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存するたびにこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Java」とそれを生成したライブラリのバージョンを報告します。[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#setNameOfApplication) に渡された値は、プレゼンテーションが書き出される際に破棄されます。
{{% /alert %}}

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。下図のように Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** を選択します：

|**Advanced Properties メニュー項目の選択**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

**Advanced Properties** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます：

|**プロパティ ダイアログ**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

**Properties Dialog** には **General**、**Summary**、**Statistics**、**Contents**、**Custom** などのタブが含まれます。これらのタブを使用して PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブを使用してカスタム プロパティを管理してください。

## **Python via Java 用 Aspose.Slides でドキュメント プロパティを操作する**

前述のとおり、Python via Java 用 Aspose.Slides は **組み込み** と **カスタム** の両方のドキュメント プロパティをサポートしています。[DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) クラスはプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表します。

[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDocumentProperties) を使用して、以下に示すようにこれらのプロパティにアクセスします。

## **暗号化されたプレゼンテーションからパブリック プロパティを読み取る**

開くパスワードは通常、プレゼンテーションのコンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に `false` を渡してプレゼンテーションを暗号化した場合、ドキュメント プロパティはパブリックのままです。その後、アプリケーションは [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) に `true` を渡すことで、開くパスワードを提供せずにパブリック メタデータを読み取れます。

ドキュメント プロパティのみのオプションは Aspose.Slides が何をロードするかを制御しますが、暗号化自体は解除しません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

以下の例は、[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) でロード モードを確認し、続いて [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDocumentProperties) で組み込みプロパティを読み取ります：

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

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは常に、完全なプレゼンテーション オブジェクト モデルが必要な操作を行う前に [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) をチェックすべきです。

{{% alert color="warning" title="Warning" %}}
パブリック メタデータには、作者名、タイトル、サブジェクト、キーワード、会社情報、コメント、およびカスタム値が含まれる可能性があります。機密性の高いプロパティはプレゼンテーションと一緒に暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでのアクセスを特別に要求する場合にのみ、パブリックのままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、ドキュメント プロパティのみモードでロードされたプレゼンテーションはパブリック メタデータの読み取りを目的としています。Aspose.Slides はそのメタデータだけのオブジェクトから変更されたプロパティを保存できません。パブリック プロパティは暗号化されたプレゼンテーション内部のデータと一貫性を保つ必要があるため、正しい開くパスワードで完全にロードしなければ更新できません。

以下の例は [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) でプレゼンテーションを開き、パブリック 組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#isEncrypted) を使用して暗号化が保持されていることを確認し、パスワードなしでパブリック メタデータを再度開いて新しい値を検証します：

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

アプリケーションがプレゼンテーションのコンテンツを復号またはロードできない場合、暗号化された PPTX ファイルのパブリック プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティにアクセスする**

[DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) が公開する組み込みプロパティには、**Creator**（作成者）、**Description**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（共有ドキュメントか）、**PresentationFormat**、**Subject**、**Title** が含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# プレゼンテーションを表す Presentation クラスのインスタンスを作成
presentation = Presentation("Presentation.pptx")
try:
    # Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    properties = presentation.getDocumentProperties()

    # 組み込みプロパティを表示
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **組み込みプロパティを変更する**

組み込みプロパティの変更はそれらにアクセスするのと同じくらい簡単です。対応するセッターを使用して新しい値を割り当てます。以下の例は Python via Java 用 Aspose.Slides で組み込みドキュメント プロパティを変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    properties = presentation.getDocumentProperties()

    # 組み込みプロパティを設定
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # プレゼンテーションをファイルに保存
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例は、変更後の組み込みプロパティを以下のように表示します：

|**変更後の組み込みドキュメント プロパティ**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **カスタム ドキュメント プロパティを追加する**

Python via Java 用 Aspose.Slides は、開発者がプレゼンテーションにカスタム ドキュメント プロパティを追加することも可能です。以下の例は 3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索してそのプロパティを削除します。その結果、保存されたプレゼンテーションには 2 つだけ残ります。カスタム プロパティは追加順ではなくアルファベット順にインデックス付けされます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ドキュメント プロパティを取得
    properties = presentation.getDocumentProperties()

    # カスタム プロパティを追加
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # 特定のインデックスのプロパティ名を取得
    property_name = properties.getCustomPropertyName(2)

    # 選択したプロパティを削除
    properties.removeCustomProperty(property_name)

    # プレゼンテーションを保存
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**追加されたカスタム ドキュメント プロパティ**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **カスタム プロパティにアクセスおよび変更する**

Python via Java 用 Aspose.Slides は、カスタム プロパティの値にアクセスすることも可能です。以下の例はプレゼンテーション内のすべてのカスタム プロパティにアクセスし、変更する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    properties = presentation.getDocumentProperties()

    # カスタム プロパティにアクセスして変更
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # カスタム プロパティの名前と値を表示
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # カスタム プロパティの値を変更
        properties.set_Item(property_name, f"New Value {i + 1}")

    # プレゼンテーションをファイルに保存
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例は [PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は変更前後のカスタム プロパティを示します：

|**変更前のカスタム プロパティ**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**変更後のカスタム プロパティ**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}
新しいメソッド [readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)、および [writeBindedPresentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) が [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) に追加され、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#setLastSavedTime) メソッドの動作が変更されました。
{{% /alert %}}

新しく追加された 2 つのメソッド [readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) と [updateDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) は、[PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) クラスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティを変更および更新できます。

プロパティをロードし、値を変更し、ドキュメントを更新する典型的なワークフローは以下のように実装できます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# プレゼンテーション情報を読み取る
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# 現在のプロパティを取得
properties = presentation_info.readDocumentProperties()

# Author と Title フィールドの新しい値を設定
properties.setAuthor("New Author")
properties.setTitle("New Title")

# 新しい値でプレゼンテーションを更新
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

特定のプレゼンテーションのプロパティをテンプレートとして他のプレゼンテーションのプロパティを更新する別の方法があります：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新することも可能です：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **校正言語を設定する**

Aspose.Slides は [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#setLanguageId) メソッドを提供し、PowerPoint 文書の校正言語を設定できます。校正言語はプレゼンテーションのスペルチェックと文法チェックに使用される言語です。

この Python コードは PowerPoint の校正言語を設定する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # 校正言語の ID を設定

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **デフォルト言語を設定する**

この Python コードは PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # テキスト付きの長方形シェイプを追加
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # 最初のポーションの言語を確認
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) オンライン アプリを試して、Aspose.Slides API を介したドキュメント プロパティの操作方法を確認してください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、値を変更するか、プロパティが許可する場合は空に設定できます。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット別の制限については、[軽量プレゼンテーションインベントリの構築](/slides/ja/python-java/examine-presentation/) を参照してください。

**開くパスワードなしで暗号化されたプレゼンテーションのパブリック プロパティを読み取れますか？**

はい。ドキュメント プロパティの暗号化がプレゼンテーションの暗号化前に無効化され、プレゼンテーションがドキュメント プロパティのみモードでロードされている必要があります。

**ドキュメント プロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。パブリック プロパティと暗号化されたプロパティ データは一致している必要があるため、暗号化された PPTX ファイルを更新するには正しい開くパスワードでプレゼンテーション全体をロードする必要があります。