---
title: C++ で PowerPoint プレゼンテーションの機密ラベルを管理する
linktitle: 機密ラベル
type: docs
weight: 50
url: /ja/cpp/sensitivity-labels/
keywords:
- 機密ラベル
- Microsoft Purview
- Microsoft Information Protection
- MIP メタデータ
- コンテンツ マーキング
- 情報保護
- ドキュメント ガバナンス
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- C++
- Aspose.Slides
description: "Microsoft Purview の機密ラベルを PowerPoint PPTX プレゼンテーションで読み取り、追加、更新、削除、そして移行します（C++ 用 Aspose.Slides）。"
---
## **概要**

Microsoft Purview の機密ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動プレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで書き込まれたラベルメタデータを移行したりする必要がある場合があります。

Aspose.Slides は、[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) を介して最新の機密ラベル メタデータを公開します。このメソッドは、[ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/) を返し、プレゼンテーションを PPTX として保存する前に内容を検査および変更できます。

{{% alert color="primary" title="Note" %}}
機密ラベルの識別子とポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を確認してください。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) の値はラベルに関連付けられたコンテンツ マークを示しますが、スライドに目に見えるテキストや図形を自動的に追加するわけではありません。
{{% /alert %}}

## **機密ラベル プロパティの理解**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) には以下のメタデータが含まれます。

| アクセサー | 目的 |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview ポリシー内の機密ラベルを識別します。 |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_siteid/) | ラベル ポリシーに関連付けられたサイトを識別します。 |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | ラベルが有効かどうかを示します。 |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | ラベルが削除されたことを示します。削除状態をメタデータに保持する必要がある場合は `true` に設定します。 |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | ラベルが自動的に適用されたか、ユーザーの決定によって適用されたかを指定します。 |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | ラベルに関連付けられたコンテンツ マークの種類を列挙します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) 列挙体は、ラベルの割り当て方法を表します。

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) はデフォルトまたは自動的に適用されたラベルを表します。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) はユーザーの決定によって適用されたラベル（手動適用、推奨、必須ラベルを含む）を表します。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) 列挙体は、ラベルに関連付けられたマークの種類を特定します。

| 値 | 意味 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツ マークがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツ マークがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツ マークがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーク タイプを 1 つのラベルに関連付けることができます。

## **既存の機密ラベルの一覧表示**

[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) から最新のラベル コレクションを取得し、列挙します。以下の例は、各ラベルに格納されているすべてのプロパティとコンテンツ マークを一覧表示します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **コンテンツ マーク付き機密ラベルの追加**

ラベル識別子、サイト識別子、有効状態、割り当て方法を指定して [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) を使用します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) を通じて必要なマーク 値を追加します。

以下の例は、フッターとウォーターマークのマークが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **機密ラベルの更新**

[ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) の値は、getter と setter メソッドを介して読み書きできます。ただし、[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) が返すコレクションは、リスト操作で変更します。対象ラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツ マーク タイプを更新できます。変更を永続化するためにプレゼンテーションを保存してください。

以下の例は、最初のラベルの有効状態と割り当て方法を更新します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **機密ラベルを削除済みとしてマークする**

ラベルが削除されたことを保持したい場合は、ラベルを取得して [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) に `true` を渡して呼び出します。これにより、ラベル エントリは残り、削除状態が記録されます。モダン コレクションからエントリ自体を削除したい場合は、[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/removeat/) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/clear/) を使用します。

以下の例は、特定のラベルを削除済みとしてマークし、更新されたプレゼンテーションを保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **レガシー MIP 機密ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新のラベル コレクションではなくカスタム ドキュメント プロパティに機密ラベル メタデータを格納することがあります。これらのメタデータは [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) で取得できます。このメソッドはレガシーのカスタム プロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、返された各ラベルを [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) を使って最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/) に追加します。重複したラベル識別子を追加しようとすると例外がスローされるため、例はコピー前に宛先コレクションを確認します。各レガシー ラベルが現在の Purview ポリシーにまだ存在するかどうかを検証するロジックを追加しても構いません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

この移行は、解析されたラベル オブジェクトを最新のコレクションにコピーします。すべてのカスタム ドキュメント プロパティをクリアする必要はなく、関連しないドキュメント メタデータはそのまま残ります。[IPresentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) と [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を使用して、最新のラベル メタデータを PPTX ファイルに書き込みます。

## **FAQ**

**コンテンツ マーク タイプを追加すると、スライドに目に見えるヘッダー、フッター、またはウォーターマークが作成されますか？**

いいえ。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) を通じて追加された値は、機密ラベルに関連付けられたマークを記述するだけで、プレゼンテーションに目に見えるテキストや図形は作成されません。ワークフローでこれらのマークを表示する必要がある場合は、別途スライド コンテンツを追加してください。

**ラベルを「削除済み」とマークすることと、コレクションから削除することの違いは何ですか？**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) に `true` を設定すると、ラベル エントリは保持され、削除状態が記録されます。[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/removeat/) を呼び出すと、最新のコレクションからエントリ自体が削除されます。組織のメタデータ保持ポリシーに合わせて操作を選択してください。

**プレゼンテーションはレガシー MIP メタデータと最新の機密ラベルの両方を含めることができますか？**

はい。レガシー ラベルはカスタム ドキュメント プロパティに残したままにでき、最新のラベルは [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) で取得できます。[IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) を使用してレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同一の識別子を持つラベルを複数回追加しようとするとどうなりますか？**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) は、コレクションに同じ識別子のラベルが既に存在する場合に引数例外をスローします。ラベルを追加または移行する前に、既存の [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_id/) の値を確認してください。

**更新された機密ラベルを保持するために使用すべき出力形式は何ですか？**

上記の例に示すように、[IPresentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) に [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を指定してプレゼンテーションを PPTX として保存してください。