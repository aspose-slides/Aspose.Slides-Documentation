---
title: ".NET で PowerPoint プレゼンテーションの感度ラベルを管理する"
linktitle: "感度ラベル"
type: docs
weight: 50
url: /ja/net/sensitivity-labels/
keywords:
- "感度ラベル"
- "Microsoft Purview"
- "Microsoft Information Protection"
- "MIP メタデータ"
- "コンテンツ マーキング"
- "情報保護"
- "ドキュメント ガバナンス"
- "PowerPoint"
- "PPTX"
- "プレゼンテーション セキュリティ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 感度ラベルを読み取り、追加、更新、削除、移行します。"
---
## **概要**

Microsoft Purview の感度ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動化されたプレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要がある場合があります。

Aspose.Slides は、[Presentation.SensitivityLabels](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sensitivitylabels/) を介して最新の感度ラベルメタデータを提供します。このプロパティは、保存前に検査および変更できる [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/) を返します。

{{% alert color="info" title="Note" %}}
感度ラベルの識別子およびポリシー情報は、Microsoft Purview の構成で定義されています。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を検証してください。[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/contentmarktypes/) の値はラベルに関連付けられたコンテンツマーキングを示しますが、スライドに目に見えるテキストや図形を自動的に追加するものではありません。
{{% /alert %}}

## **感度ラベルプロパティの理解**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/) には以下のメタデータが含まれます。

| プロパティ | 目的 |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/id/) | Purview ポリシー内の感度ラベルを識別します。 |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/siteid/) | ラベルポリシーに関連付けられたサイトを識別します。 |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/isenabled/) | ラベルが有効かどうかを示します。 |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/isremoved/) | ラベルが削除されたことを示します。削除状態をメタデータに保持する必要がある場合は、このプロパティを `true` に設定します。 |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | ラベルが自動的に適用されたか、ユーザーの判断によって適用されたかを指定します。 |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/contentmarktypes/) | ラベルに関連付けられたコンテンツマーキングタイプの一覧を示します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelassignmenttype/) 列挙体は、ラベルがどのように割り当てられたかを示します。

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelassignmenttype/) はデフォルトまたは自動的に適用されたラベルを表します。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelassignmenttype/) はユーザーの判断によって適用されたラベルを表し、手動適用、推奨、必須ラベルを含みます。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) 列挙体は、ラベルに関連付けられたマーキングを識別します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) | ヘッダーコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) | フッターコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) | 透かしコンテンツマーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ja/net/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーキングタイプを 1 つのラベルに関連付けることができます。

## **既存の感度ラベルの一覧表示**

[Presentation.SensitivityLabels](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sensitivitylabels/) から最新のラベルコレクションを読み取り、列挙します。以下の例は、各ラベルに格納されているすべてのプロパティとコンテンツマーキングを一覧表示します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **コンテンツマーキング付き感度ラベルの追加**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/add/) を使用して、ラベル識別子、サイト識別子、有効状態、割り当て方法を指定します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/contentmarktypes/) を介して必要なマーキング値を追加します。

以下の例は、フッターと透かしのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **感度ラベルの更新**

[ISensitivityLabel](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/) のプロパティは読み書き可能です。ただし、[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/contentmarktypes/) が返すコレクションはそのリスト操作を通じて変更します。必要なラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツマーキングタイプを更新できます。変更を永続化するためにプレゼンテーションを保存してください。

以下の例は、最初のラベルの有効状態と割り当て方法を更新します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **感度ラベルを削除済みとしてマークする**

ラベルが削除された事実を保持するには、ラベルを見つけて [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/isremoved/) を `true` に設定します。これにより、ラベルエントリは残り、削除状態が記録されます。コレクションからエントリを完全に削除する必要がある場合は、[ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/removeat/) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/clear/) を使用します。

以下の例は、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **レガシー MIP 感度ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベルコレクションではなくカスタムドキュメントプロパティに感度ラベルメタデータを保存することがあります。[IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/getsensitivitylabels/) でそのメタデータを読み取ります。このメソッドはレガシーのカスタムプロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/add/) を介して最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/) に追加します。重複したラベル識別子を追加しようとすると例外がスローされるため、例ではコピー前に対象コレクションをチェックしています。各レガシーラベルが現在の Purview ポリシーにまだ存在するかどうかを確認する追加の検証を実装することもできます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

この移行は解析されたラベルオブジェクトを最新コレクションにコピーします。すべてのカスタムドキュメントプロパティをクリアする必要はなく、無関係なドキュメントメタデータはそのまま残ります。[IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) を指定して、最新のラベルメタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツマーキングタイプを追加すると、スライドに目に見えるヘッダー、フッター、または透かしが作成されますか？**

いいえ。[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/contentmarktypes/) を通じて追加された値は、感度ラベルに関連付けられたマーキングを記述しますが、プレゼンテーション内に目に見えるテキストや図形を作成するものではありません。必要に応じて、ワークフローで別途対応するスライドコンテンツを追加してください。

**ラベルを削除済みとしてマークすることと、コレクションから削除することの違いは何ですか？**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/isremoved/) を `true` に設定すると、ラベルエントリは保持され、削除状態が記録されます。一方、[ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/removeat/) を呼び出すと、最新コレクションからエントリ自体が削除されます。組織のメタデータ保持要件に合わせて操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新の感度ラベルの両方を含めることはできますか？**

はい。レガシーラベルはカスタムドキュメントプロパティに残したままにでき、最新のラベルは [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sensitivitylabels/) から取得できます。[IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/getsensitivitylabels/) を使用してレガシーメタデータを読み取り、まだ最新コレクションに存在しない有効なラベルだけを移行してください。

**同一識別子のラベルを複数回追加しようとするとどうなりますか？**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabelcollection/add/) は、コレクションに同じ識別子を持つラベルがすでに存在する場合、`ArgumentException` をスローします。ラベルを追加または移行する前に、既存の [ISensitivityLabel.Id](https://reference.aspose.com/slides/ja/net/aspose.slides/isensitivitylabel/id/) 値を確認してください。

**更新された感度ラベルを保持するために使用すべき出力形式はどれですか？**

上記の例に示すように、[IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) を指定してプレゼンテーションを PPTX として保存してください。