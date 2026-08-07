---
title: C++ を使用してプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/cpp/managing-tags-and-custom-data/
keywords:
- 文書プロパティ
- タグ
- カスタム データ
- カスタム XML
- カスタム XML パーツ
- XML メタデータ
- ItemId
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション内のタグとカスタム XML データを管理する方法を学びます。タグの追加、読み取り、更新、監査、およびカスタム XML パーツの削除が含まれます。"
---
## **概要**

本稿では、Aspose.Slides が PowerPoint プレゼンテーションでタグおよびカスタム データを扱う方法について説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグは単純なキーと値の文字列ペアであり、カスタム XML パーツは構造化メタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプの各レベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、文書管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データを保存する統合に役立ちます。

## **プレゼンテーション ファイルにおけるデータ ストレージ**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツおよび関連データを保存するために使用されるパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパートで構成されます。たとえば、スライド パートは単一スライドのコンテンツを保持し、ISO/IEC 29500 によって定義された他のパートへの明示的なリレーションシップを持つことができます。

カスタム データはタグ([ITagCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itagcollection/))またはカスタム XML パーツ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/))として保存できます。両方とも[`ICustomData`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomdata/)インターフェイスを介して利用できます。

{{% alert color="primary" %}}
タグはシンプルな文字列のキーとバリューのペアを保存します。カスタム XML パーツは構造化 XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomdata/get_customxmlparts/) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation->get_CustomData()->get_CustomXmlParts()` はプレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide->get_CustomData()->get_CustomXmlParts()` は特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape->get_CustomData()->get_CustomXmlParts()` は特定のシェイプに関連付けられたカスタム XML パーツを含みます。

プレゼンテーション全体のカスタム XML パーツを場所に関係なく確認する必要がある場合は、[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_allcustomxmlparts/) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/add/) を使用して XML データをカスタム XML パーツコレクションに追加します。XML は有効かつ空であってはなりません。

次の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add は自動的に識別子を割り当てます。必要な場合のみ特定の GUID を設定してください。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` メソッドは、XML をバイト配列またはストリームとして受け取ることもでき、XML コンテンツが既にバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく、特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレート キー、外部レコード識別子、またはバインディング情報など、単一のオブジェクトのみを記述する場合に有用です。

次の例は、スライドに 1 つのカスタム XML パーツを、シェイプに別のカスタム XML パーツを追加します:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

パーツが追加されるレベルは、どのオブジェクトの `get_CustomData()->get_CustomXmlParts()` コレクションにそのパーツへのリレーションシップが含まれるかを決定します。プレゼンテーション レベルのデータは文書全体のメタデータに適し、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付けられたメタデータに適しています。

### **すべてのカスタム XML パーツを一覧表示および監査する**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_allcustomxmlparts/) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。各[`ICustomXmlPart`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/) は識別子、XML コンテンツ、関連付けられた名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションの監査時に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) と `set_XmlAsString` を使用して UTF-8 文字列として XML を操作するか、[`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/get_xmldata/) と `set_XmlData` を使用して生の XML バイトを操作できます。両方の表現は読み取りおよび更新が可能です。

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/get_itemid/) メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する GUID を返します。統合で新しい識別子が必要な場合は、`set_ItemId` で変更することもできます。

次の例は、XML コンテンツと識別子を更新します:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// 現在の XML をテキストとして読み取ります。
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML を UTF-8 文字列として更新します。
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData は同じ XML コンテンツを生バイトとして提供します。
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// 統合で必要な場合に識別子を置き換えます。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

`set_XmlAsString` または `set_XmlData` で XML を設定する際は、有効で空でない XML を提供してください。アプリケーションが文字列中心かバイトデータ中心かに応じて、どちらか一方の表現を使用します。

### **カスタム XML パーツを削除する**

Aspose.Slides にはカスタム XML データを削除する複数の方法があります:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpart/remove/) はプレゼンテーションからカスタム XML パーツを削除します。
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/remove/) はコレクションから特定のパーツを削除します。
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/removeat/) は指定したインデックスのパーツを削除します。
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/clear/) は特定のコレクション内のすべてのパーツを削除します。

次の例は、参照によってプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

既に `ICustomXmlPart` のインスタンスを持っていて、そのパーツを特定のコレクションではなくプレゼンテーション全体から削除したい場合は、`customXmlPart->Remove()` を呼び出します。

インデックスで項目を削除することもできます:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除する必要がある場合は、`Clear` を使用します。

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`get_AllCustomXmlParts()` を列挙し、各パーツを個別に削除します:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **リンクされたまたは共有されたカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルが複数のスライドやシェイプから同じ基底カスタム XML パーツへのリレーションシップを含むことがあります。

共有パーツは、複数の参照を持つ単一のデータ オブジェクトとして扱うべきです:

- `set_XmlAsString`、`set_XmlData`、`set_ItemId` で更新すると、基底カスタム XML パーツが変更され、参照先すべてに変更が反映されます。
- `get_ItemId()` を使用して、オブジェクト レベルのコレクションを監査するときに同一のカスタム XML パーツを識別できます。
- 特定の `get_CustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体からパーツ自体を削除したい場合は `ICustomXmlPart::Remove()` を使用します。
- 共有パーツを削除または置換する前に、オブジェクト レベルのコレクションを確認し、他のスライドやシェイプがまだ参照していないか確認してください。

`Add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは主に、既に共有パーツを含むプレゼンテーションをロードする際に遭遇します。

次の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプのコレクションを監査し、複数箇所から参照されているパーツを報告します:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

この種の監査は、外部システムが生成したプレゼンテーションでカスタム XML データを変更または削除する前に有用です。なぜなら、同一のメタデータ パーツが複数のリレーションシップに参加している可能性があるからです。

## **タグの値を取得する**

スライドでは、タグは `IDocumentProperties::get_Keywords` プロパティに対応します。このサンプル コードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) のタグ値を取得する方法を示しています:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの要素で構成されます:

- カスタム プロパティの名前 (例: `MyTag`);
- カスタム プロパティの値 (例: `My Tag Value`)。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加して目的を達成できます。たとえば、北米諸国のプレゼンテーションを分類したい場合、北米タグを作成し、該当する国名を値として割り当てます。

次のサンプルコードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) にタグを追加する方法を示しています:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

タグは [Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/) に対しても設定できます:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

または個別の [Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/) に対して設定できます:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **制限事項**

`get_CustomData()->get_Tags()` コレクションを通じて追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム 識別子はタグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text** にカスタム 識別子を保存できます (例: `shape->set_AlternativeText(u"MyId")`)。PDF にエクスポートすると、Alt Text が PDF タグ構造に現れる可能性があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプのすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) は、すべてのキーとバリューのペアを一度に削除する [Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/clear/) 操作をサポートします。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

`TagCollection` の [Remove(name)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/remove/) を使用して、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全なリストを取得するには？**

[tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) の [GetNamesOfTags](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なくすべてのカスタム XML パーツを見つけるには？**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_allcustomxmlparts/) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツを更新する際、`get_XmlAsString`/`set_XmlAsString` と `get_XmlData`/`set_XmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 の XML テキストで主に作業する場合は `get_XmlAsString` と `set_XmlAsString` を使用し、XML が既にバイト配列として利用可能、またはバイナリ指向の処理が好ましい場合は `get_XmlData` と `set_XmlData` を使用してください。どちらの表現も同一カスタム XML パーツの XML コンテンツを指します。