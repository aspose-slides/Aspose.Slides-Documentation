---
title: Python で PowerPoint プレゼンテーションの機密ラベルを管理
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/python-net/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツマーキング
- 情報保護
- ドキュメント ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 機密ラベルを読み取り、追加、更新、削除、そして移行します。"
---
## **概要**

Microsoft Purview の機密ラベルは、組織がドキュメントを分類および管理できるようにします。自動化されたプレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要があります。

Aspose.Slides for Python via .NET は、[Presentation.sensitivity_labels](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sensitivity_labels/) を通じて最新の機密ラベルメタデータを公開します。このプロパティは、保存前に検査および変更できる [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/) を返します。

{{% alert color="primary" title="Note" %}}
機密ラベルの識別子とポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を確認してください。[SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/content_mark_types/) の値はラベルに関連付けられたコンテンツマーキングを示しますが、スライドに可視的なテキストや図形を自動的に追加するものではありません。
{{% /alert %}}

## **機密ラベルプロパティの理解**

各 [SensitivityLabel](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/) には以下のメタデータが含まれます。

| プロパティ | 目的 |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/id/) | Purview ポリシー内の機密ラベルを識別します。 |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/site_id/) | ラベルポリシーに関連付けられたサイトを識別します。 |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/is_enabled/) | ラベルが有効かどうかを示します。 |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/is_removed/) | ラベルが削除されたことを示します。削除状態をメタデータに保持する必要がある場合はこのプロパティを `True` に設定します。 |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | ラベルが自動的に適用されたかユーザーの判断で適用されたかを示します。 |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | ラベルに関連付けられたコンテンツマーキングの種類を一覧表示します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelassignmenttype/) 列挙型は、ラベルがどのように割り当てられたかを表します。

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelassignmenttype/) はデフォルトまたは自動的に適用されたラベルを表します。  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelassignmenttype/) はユーザーの判断で適用されたラベル（手動適用、推奨、必須ラベルを含む）を表します。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) 列挙型は、ラベルに関連付けられたマーキングを識別します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) | ラベルがデフォルトまたは自動的に適用されたことを示します。 |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) | ヘッダーコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) | フッターコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) | ウォーターマークコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーキングタイプを 1 つのラベルに関連付けることができます。

## **既存の機密ラベルの一覧取得**

[Presentation.sensitivity_labels](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sensitivity_labels/) から最新のラベルコレクションを取得し、列挙します。次の例は各ラベルに保存されているすべてのプロパティとコンテンツマーキングを列挙します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **コンテンツマーキング付き機密ラベルの追加**

ラベル識別子、サイト識別子、有効状態、割り当て方法を指定して [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/add/) を使用します。サイト識別子は Python の `uuid.UUID` オブジェクトとして渡します。メソッドが新しい [SensitivityLabel](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/) を返したら、必要なマーキング値を [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/content_mark_types/) に追加します。

次の例は、フッターとウォーターマークのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **機密ラベルの更新**

[SensitivityLabel](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/) のプロパティは読み書き可能です。ただし、[SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/content_mark_types/) が返すリストはそのリスト操作によって変更します。対象ラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツマーキングタイプを更新できます。変更を永続化するためにプレゼンテーションを保存します。

次の例は、最初のラベルの有効状態と割り当て方法を更新します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **機密ラベルを削除済みとしてマークする**

ラベルが削除されたことを保持したい場合は、ラベルを検索し、[SensitivityLabel.is_removed](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/is_removed/) を `True` に設定します。これによりラベルエントリは残り、削除状態が記録されます。モダンコレクションからエントリ自体を削除したい場合は、[SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) を使用し、すべてのエントリを削除するには [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/clear/) を使用します。

次の例は特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **レガシー MIP 機密ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベルコレクションではなくカスタムドキュメントプロパティに機密ラベルメタデータを保存することがあります。[DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) を使用してそのメタデータを読み取ります。このメソッドはレガシーカスタムプロパティを解析し、[SensitivityLabel](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/) オブジェクトを返します。

メタデータを移行するには、返された各ラベルを [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/add/) を介して最新の [SensitivityLabelCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/) に追加します。重複したラベル識別子の追加は例外を発生させるため、例ではコピー前に宛先コレクションをチェックしています。各レガシーラベルが現在の Purview ポリシーにまだ存在するかどうかを検証するロジックを追加することもできます。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

移行は解析されたラベルオブジェクトを最新コレクションにコピーします。すべてのカスタムドキュメントプロパティをクリアする必要はなく、無関係なドキュメントメタデータはそのまま残ります。[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) と [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) を使用して、最新のラベルメタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツマーキングタイプを追加すると、スライドに可視的なヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/content_mark_types/) で追加された値は機密ラベルに関連付けられたマーキングを記述するだけで、プレゼンテーションに可視的なテキストや図形は作成しません。必要に応じて、別途スライドコンテンツを追加してこれらのマーキングを表示させてください。

**ラベルを「削除済み」とマークすることと、コレクションから削除することの違いは何ですか？**

[SensitivityLabel.is_removed](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/is_removed/) を `True` に設定すると、ラベルエントリは残り、削除状態が記録されます。[SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) を呼び出すと、最新コレクションからエントリ自体が削除されます。組織のメタデータ保持要件に合わせて操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の機密ラベルの両方を同時に含めることはできますか？**

はい。レガシーラベルはカスタムドキュメントプロパティに残したままにでき、最新のラベルは [Presentation.sensitivity_labels](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sensitivity_labels/) から取得できます。[DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) を使用してレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同一識別子のラベルを複数回追加するとどうなりますか？**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabelcollection/add/) は、コレクションに同じ識別子のラベルがすでに存在する場合に例外をスローします。ラベルを追加または移行する前に、既存の [SensitivityLabel.id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sensitivitylabel/id/) 値を確認してください。

**更新された機密ラベルを保持するために使用すべき出力形式はどれですか？**

上記の例のように、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) に [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) を指定してプレゼンテーションを PPTX として保存してください。