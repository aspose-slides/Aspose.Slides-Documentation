---
title: Python で PowerPoint プレゼンテーションの感度ラベルを管理
linktitle: 感度ラベル
type: docs
weight: 50
url: /ja/python-java/sensitivity-labels/
keywords:
- 感度ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツ マーク
- 情報保護
- ドキュメント ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 感度ラベルを読み取り、追加、更新、削除、移行します。"
---
## **概要**

Microsoft Purview の感度ラベルは、組織がドキュメントを分類および管理できるようにします。自動プレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行する必要がある場合があります。

Aspose.Slides は、[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSensitivityLabels) を通じて最新の感度ラベル メタデータを提供します。このメソッドは、[SensitivityLabelCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/) を返し、PPTX として保存する前に検査および変更できます。

{{% alert color="info" title="Note" %}}
感度ラベルの識別子とポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を検証してください。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) の値はラベルに関連付けられたコンテンツマークを示しますが、スライドに可視的なテキストや図形を追加するものではありません。
{{% /alert %}}

## **感度ラベルのプロパティを理解する**

各 [SensitivityLabel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/) には次のメタデータが含まれます。

| メソッド | 目的 |
| --- | --- |
| [getId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getId) と [setId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setId) | Purview ポリシー内の感度ラベル識別子を取得または設定します。 |
| [getSiteId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getSiteId) と [setSiteId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setSiteId) | ラベル ポリシーに関連付けられたサイトを取得または設定します。 |
| [isEnabled](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#isEnabled) と [setEnabled](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setEnabled) | ラベルが有効かどうかを取得または設定します。 |
| [isRemoved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#isRemoved) と [setRemoved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setRemoved) | ラベルが削除されたかどうかを取得または設定します。メタデータに削除状態を保持する必要がある場合は、値を `True` に設定します。 |
| [getAssignmentMethodType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) と [setAssignmentMethodType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | ラベルが自動的に適用されたか、ユーザーの決定によって適用されたかを取得または設定します。 |
| [getContentMarkTypes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | ラベルに関連付けられたコンテンツ マークの種類を取得します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelassignmenttype/) クラスは、ラベルがどのように割り当てられたかを定義します。

- [Standard](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelassignmenttype/) はデフォルトまたは自動的に適用されたラベルを表します。  
- [Privileged](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelassignmenttype/) はユーザーの決定により適用されたラベルを表し、手動適用、推奨、必須ラベルを含みます。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) クラスはラベルに関連付けられるマークを定義します。

| 値 | 意味 |
| --- | --- |
| [None](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) | ラベルがデフォルトまたは自動的に適用されました。 |
| [Header](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツ マークがラベルに関連付けられています。 |
| [Footer](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツ マークがラベルに関連付けられています。 |
| [Watermark](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツ マークがラベルに関連付けられています。 |
| [Encryption](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

1 つのラベルに複数のマークタイプを関連付けることができます。

## **既存の感度ラベルを一覧表示**

最新のラベル コレクションを [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSensitivityLabels) で読み取り、列挙します。以下の例は、各ラベルに格納されたすべてのプロパティとコンテンツ マークを一覧表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **コンテンツ マーク付き感度ラベルを追加**

ラベル識別子、サイト識別子、有効状態、割り当て方法を指定して [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#add) を使用します。メソッドが新しい [SensitivityLabel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/) を返したら、[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストを介して必要なマーク 値を追加します。

以下の例は、フッターとウォーターマークのマークが関連付いた手動選択ラベルを追加し、結果を PPTX として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **感度ラベルを更新**

[SensitivityLabel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/) の値は読み書き可能ですが、[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストはそのリスト操作を通じて変更します。目的のラベルを見つけたら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツ マークの種類を更新できます。プレゼンテーションを保存して変更を永続化してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **感度ラベルを削除済みとしてマーク**

ラベルが削除された事実を保持するには、ラベルを見つけて [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setRemoved) を `True` で呼び出します。これによりラベルのエントリは保持され、削除状態が記録されます。代わりにモダン コレクションからエントリを削除する必要がある場合は、[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) を使用し、すべてのエントリを削除するには [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#clear) を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **レガシー MIP 感度ラベルを読み取り、移行**

古い MIP ベースのワークフローは、最新のラベル コレクションの代わりにカスタム ドキュメント プロパティに感度ラベル メタデータを保存することがあります。[DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getSensitivityLabels) でそのメタデータを読み取ります。このメソッドはレガシー カスタム プロパティを解析し、[SensitivityLabel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#add) を通じて最新の [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/) に追加します。重複するラベル識別子を追加しようとすると例外が発生するため、例ではコピー前に宛先コレクションをチェックしています。各レガシー ラベルが現在の Purview ポリシーにまだ存在するかを確認するための追加検証を実装できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

移行は解析されたラベルオブジェクトを最新のコレクションにコピーします。すべてのカスタム ドキュメント プロパティをクリアする必要はなく、無関係なドキュメント メタデータはそのまま残ります。[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) を使用して、最新のラベル メタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツ マーク タイプを追加すると、スライドに目に見えるヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) が返すリストに追加された値は、感度ラベルに関連付けられたマークを示すだけで、プレゼンテーションに可視的なテキストや図形を作成するものではありません。ワークフローでそれらのマークを表示する必要がある場合は、対応するスライド コンテンツを別途追加してください。

**ラベルを削除済みとしてマークすることと、コレクションから削除することの違いは何ですか？**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#setRemoved) を `True` に設定すると、ラベル エントリは保持され、削除状態が記録されます。[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) を呼び出すと、モダン コレクションからエントリが削除されます。組織のメタデータ保持要件に合わせて操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の感度ラベルの両方を含めることはできますか？**

はい。レガシー ラベルはカスタム ドキュメント プロパティに残したまま、最新のラベルは [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSensitivityLabels) で取得できます。[DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getSensitivityLabels) を使用してレガシー メタデータを読み取り、最新のコレクションにまだ存在しない有効なラベルのみを移行してください。

**同じ識別子を持つラベルを複数回追加するとどうなりますか？**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabelcollection/#add) は同じ識別子のラベルがすでにコレクションに存在すると例外をスローします。[SensitivityLabel.getId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sensitivitylabel/#getId) が返す既存の値をチェックしてからラベルを追加または移行してください。

**更新された感度ラベルを保持するために使用すべき出力形式はどれですか？**

プレゼンテーションは [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) を使用して PPTX として保存してください。上記の例に示すようにしてください。