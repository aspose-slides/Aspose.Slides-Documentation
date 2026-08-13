---
title: "C++ で PowerPoint プレゼンテーションの感度ラベルを管理する"
linktitle: "感度ラベル"
type: docs
weight: 50
url: /ja/cpp/sensitivity-labels/
keywords:
  - "感度ラベル"
  - "Microsoft Purview"
  - "Microsoft Information Protection"
  - "MIP メタデータ"
  - "コンテンツマーキング"
  - "情報保護"
  - "ドキュメント ガバナンス"
  - "PowerPoint"
  - "PPTX"
  - "プレゼンテーション セキュリティ"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して、PowerPoint PPTX プレゼンテーション内の Microsoft Purview 感度ラベルを読み取り、追加、更新、削除、そして移行します。"
---
## **概要**

Microsoft Purview の感度ラベルは、組織がドキュメントを分類および管理するのに役立ちます。自動プレゼンテーション処理中に、アプリケーションは既存のラベルを保持したり、ポリシーで選択されたラベルを適用したり、状態を更新したり、古い Microsoft Information Protection (MIP) ワークフローで作成されたラベルメタデータを移行したりする必要があります。

Aspose.Slides は、[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) を介して最新の感度ラベルメタデータを公開します。このメソッドは、プレゼンテーションを PPTX として保存する前に検査および変更できる [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/) を返します。

{{% alert color="info" title="Note" %}}
感度ラベルの識別子およびポリシー情報は、Microsoft Purview の構成で定義されます。メタデータを追加または移行する前に、環境でラベルの利用可能性とポリシー要件を確認してください。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) の値はラベルに関連付けられたコンテンツマーキングを示しますが、スライドに可視テキストやシェイプを自動的に追加するわけではありません。
{{% /alert %}}

## **感度ラベル プロパティを理解する**

各 [ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) には以下のメタデータが含まれます。

| Accessors | Purpose |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview ポリシー内で感度ラベルを識別します。 |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_siteid/) | ラベルポリシーに関連付けられたサイトを識別します。 |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | ラベルが有効かどうかを示します。 |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | ラベルが削除されたことを示します。削除状態をメタデータに保持する必要がある場合は `true` に設定します。 |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | ラベルが自動的に適用されたか、ユーザーの選択によって適用されたかを指定します。 |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | ラベルに関連付けられたコンテンツマーキングの種類を一覧表示します。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) 列挙体は、ラベルがどのように割り当てられたかを示します。

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) は、デフォルトまたは自動的に適用されたラベルを表します。  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelassignmenttype/) は、ユーザーの決定により適用されたラベル（手動適用、推奨、必須ラベルを含む）を表します。

[SensitivityLabelContentType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) 列挙体は、ラベルに関連付けられたマーキングを識別します。

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ラベルはデフォルトまたは自動的に適用されました。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ヘッダー コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | フッター コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | ウォーターマーク コンテンツ マーキングがラベルに関連付けられています。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sensitivitylabelcontenttype/) | 暗号化保護がラベルに関連付けられています。 |

複数のマーキングタイプが 1 つのラベルに関連付けられることがあります。

## **既存の感度ラベルの一覧**

[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) から最新のラベルコレクションを取得し、列挙します。以下の例は各ラベルに格納されたすべてのプロパティとコンテンツマーキングを一覧表示します。

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

## **コンテンツマーキング付き感度ラベルの追加**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) を使用して、ラベル識別子、サイト識別子、有効状態、割り当て方法を指定します。メソッドが新しい [ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) を返したら、[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) を介して必要なマーキング値を追加します。

以下の例は、フッターとウォーターマークのマーキングが関連付けられた手動選択ラベルを追加し、結果を PPTX として保存します。

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

## **感度ラベルの更新**

[ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) の値は、getter と setter メソッドを介して読み書きできます。ただし、[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) が返すコレクションはリスト操作で変更します。目的のラベルを特定したら、識別子、サイト識別子、有効状態、割り当て方法、削除状態、コンテンツマーキングタイプを更新できます。プレゼンテーションを保存して変更を永続化してください。

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

## **感度ラベルを削除済みとしてマークする**

ラベルが削除されたことを保持するには、ラベルを取得し、[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) に `true` を渡して呼び出します。これによりラベルエントリは残り、削除状態が記録されます。最新コレクションからエントリ自体を削除したい場合は、[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/removeat/) を使用し、すべてのエントリを削除するには [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/clear/) を使用します。

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

## **レガシー MIP 感度ラベルの読み取りと移行**

古い MIP ベースのワークフローは、最新ラベルコレクションの代わりにカスタム ドキュメント プロパティに感度ラベルメタデータを保存することがあります。これらのメタデータは [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) で取得します。このメソッドはレガシー カスタム プロパティを解析し、[ISensitivityLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/) オブジェクトの配列を返します。

メタデータを移行するには、取得した各ラベルを [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) を介して最新の [ISensitivityLabelCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/) に追加します。重複ラベル識別子の追加は例外をスローするため、例ではコピー前に宛先コレクションをチェックしています。必要に応じて、各レガシー ラベルが現在の Purview ポリシーに存在するかどうかを検証するロジックを追加できます。

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

この移行は解析されたラベル オブジェクトを最新コレクションにコピーします。すべてのカスタム ドキュメント プロパティをクリアする必要はなく、無関係なドキュメント メタデータはそのまま残ります。最新ラベルメタデータを書き込むには、[IPresentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) と [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を使用して PPTX ファイルとして保存してください。

## **FAQ**

**コンテンツマーキングタイプを追加すると、スライドにヘッダー、フッター、またはウォーターマークが表示されますか？**

いいえ。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) を介して追加された値は、感度ラベルに関連付けられたマーキングを記述するだけで、プレゼンテーションに可視テキストやシェイプを自動的に作成するわけではありません。これらのマーキングをスライドに表示する必要がある場合は、別途スライド コンテンツを追加してください。

**ラベルを「削除済み」とマークすることと、コレクションから削除することの違いは何ですか？**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/set_isremoved/) に `true` を設定すると、ラベルエントリは保持され、その削除状態が記録されます。[ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/removeat/) を呼び出すと、最新コレクションからエントリ自体が削除されます。組織のメタデータ保持要件に合った操作を選択してください。

**プレゼンテーションにレガシー MIP メタデータと最新感度ラベルの両方を含めることはできますか？**

はい。レガシー ラベルはカスタム ドキュメント プロパティに残したままにでき、最新ラベルは [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) を通じて利用できます。[IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) でレガシー メタデータを読み取り、最新コレクションにまだ存在しない有効なラベルだけを移行してください。

**同じ識別子を持つラベルを複数回追加しようとするとどうなりますか？**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabelcollection/add/) は、コレクションに同じ識別子のラベルが既に存在する場合、引数例外をスローします。追加または移行前に既存の [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isensitivitylabel/get_id/) 値を確認してください。

**更新された感度ラベルを保持するために使用すべき出力形式は何ですか？**

上記の例に示すように、[IPresentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) と [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を使用してプレゼンテーションを PPTX として保存してください。