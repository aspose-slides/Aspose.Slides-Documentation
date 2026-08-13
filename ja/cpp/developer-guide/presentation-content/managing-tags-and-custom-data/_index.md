---
title: C++ を使用したプレゼンテーションでのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/cpp/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
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
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションのタグとカスタム XML データを管理する方法を学びます。追加、読み取り、更新、監査、削除などのカスタム XML パーツの操作が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データを扱う方法を説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグは単純なキーと値の文字列ペアであり、カスタム XML パーツは構造化されたメタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプレベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を保存する統合に役立ちます。

## **プレゼンテーション ファイルにおけるデータ保存**

PPTX ファイル（拡張子が `.pptx` のファイル）は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML は、プレゼンテーション コンテンツおよび関連データを保存するために使用されるパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパーツで構成されています。例えば、スライド パートは単一のスライドのコンテンツを含み、ISO/IEC 29500 によって定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[ITagCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itagcollection/)）またはカスタム XML パーツ（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/)）として保存できます。どちらも [`ICustomData`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomdata/) インターフェイスを通じて利用できます。

{{% alert color="info" %}}
タグはシンプルな文字列のキーとバリューのペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

`ICustomData::get_CustomXmlParts` メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation->get_CustomData()->get_CustomXmlParts()` はプレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide->get_CustomData()->get_CustomXmlParts()` は特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape->get_CustomData()->get_CustomXmlParts()` は特定のシェイプに関連付けられたカスタム XML パーツを含みます。

`Presentation::get_AllCustomXmlParts` を使用すると、関連付け場所に関係なくプレゼンテーション内のすべてのカスタム XML パーツを検査できます。

### **プレゼンテーションにカスタム XML パーツを追加**

`ICustomXmlPartCollection::Add` を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効で空であってはなりません。

次の例は、プレゼンテーションレベルのカスタム データ コレクションに構造化メタデータを追加します。

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

// Add は自動的に識別子を割り当てます。必要な場合にのみ特定の GUID を設定してください。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` メソッドは、XML をバイト配列またはストリームとして受け取ることもでき、XML コンテンツが既にバイナリ形式で利用できる場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加**

カスタム XML データは、プレゼンテーション全体ではなく、特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、またはバインディング情報など、単一のオブジェクトだけを記述する場合に便利です。

次の例は、スライドに 1 つのカスタム XML パーツを、シェイプに別のカスタム XML パーツを追加します。

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

パーツが追加されるレベルは、どのオブジェクトの `get_CustomData()->get_CustomXmlParts()` コレクションにそのパーツへのリレーションシップが含まれるかを決定します。プレゼンテーションレベルのデータはドキュメント全体のメタデータに適し、スライドレベルのデータは特定のスライドに属する情報に、シェイプレベルのデータは個々のシェイプに結び付けられたメタデータに適しています。

### **すべてのカスタム XML パーツを一覧表示および監査**

`Presentation::get_AllCustomXmlParts` を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 `ICustomXmlPart` は、その識別子、XML コンテンツ、および関連する名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します。

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

`ICustomXmlPart::get_NamespaceSchemas` は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

`ICustomXmlPart::get_XmlAsString` と `set_XmlAsString` を使用して UTF-8 文字列として XML を扱うか、`ICustomXmlPart::get_XmlData` と `set_XmlData` を使用して生の XML バイトを扱います。両方の表現は読み取りおよび更新が可能です。

`ICustomXmlPart::get_ItemId` メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する GUID を返します。統合で新しい識別子が必要な場合は、`set_ItemId` で識別子を変更することもできます。

次の例は、XML コンテンツと識別子を更新します。

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

`set_XmlAsString` または `set_XmlData` で XML を割り当てる際は、有効で空でない XML を提供してください。アプリケーションが主に文字列で動作するかバイト データで動作するかに応じて、いずれかの表現を使用します。

### **カスタム XML パーツの削除**

Aspose.Slides は、カスタム XML データを削除するいくつかの方法を提供します。

- `ICustomXmlPart::Remove` は、プレゼンテーションからカスタム XML パーツを削除します。
- `ICustomXmlPartCollection::Remove` は、カスタム XML パーツ コレクションから特定のパーツを削除します。
- `ICustomXmlPartCollection::RemoveAt` は、指定されたコレクション インデックスのパーツを削除します。
- `ICustomXmlPartCollection::Clear` は、特定のコレクションからすべてのパーツを削除します。

次の例は、参照によりプレゼンテーションレベルのカスタム XML パーツを 1 つ削除します。

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

`ICustomXmlPart` を既に取得していて、特定のコレクションを指定せずにプレゼンテーションからそのパーツを削除したい場合は、`customXmlPart->Remove()` を呼び出します。

インデックスで項目を削除することもできます。

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **コレクションからすべてのカスタム XML パーツをクリア**

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

`Clear` は選択されたコレクションのみに影響します。例えば、スライドのコレクションをクリアしても、プレゼンテーションレベルやシェイプレベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`get_AllCustomXmlParts()` を反復処理し、各パーツを削除します。

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

### **リンクまたは共有されたカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同じカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。例えば、既存のファイルは、複数のスライドやシェイプから同じ基礎となるカスタム XML パーツへのリレーションシップを含むことがあります。

共有パーツは、複数の参照を持つ単一のデータオブジェクトとして扱うべきです：

- `set_XmlAsString`、`set_XmlData`、または `set_ItemId` で更新すると、基礎となるカスタム XML パーツが変更され、そのパーツが参照されているすべての場所に変更が適用されます。
- `get_ItemId()` は、オブジェクトレベルのコレクションを監査するときに同じカスタム XML パーツを識別するために使用できます。
- 特定の `get_CustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからパーツが削除されます。パーツ自体をプレゼンテーションから削除する必要がある場合は、`ICustomXmlPart::Remove()` を使用します。
- 共有パーツを削除または置き換える前に、オブジェクトレベルのコレクションを確認し、他のスライドやシェイプがまだ参照しているかどうかを判断してください。

`Add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` は受け付けません。したがって、共有リレーションシップは、既にそれらを含むプレゼンテーションを読み込むときに最も一般的に遭遇します。

次の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプレベルのコレクションを監査し、複数箇所から参照されているパーツを報告します。

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

この種の監査は、外部システムによって作成されたプレゼンテーションでカスタム XML データを変更または削除する前に有用です。なぜなら、同じメタデータ パーツが複数のリレーションシップに関与している可能性があるからです。

## **タグの値の取得**

Slides では、タグは `IDocumentProperties::get_Keywords` プロパティに対応します。このサンプルコードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) のタグ値を取得する方法を示しています。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます：

- カスタム プロパティの名前（例: `MyTag`）；
- カスタム プロパティの値（例: `My Tag Value`）。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合は、その目的でタグを追加できます。例えば、北米諸国のプレゼンテーションをカテゴリ分けしたい場合は、北米タグを作成し、該当する国をその値として割り当てることができます。

このサンプルコードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) にタグを追加する方法を示しています。

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

タグは [Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/) に対しても設定できます：

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

あるいは個別の [Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/) に対しても設定できます：

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

`get_CustomData()->get_Tags()` コレクションを通じて追加されたタグは PowerPoint ファイルにのみ保存されます。プレゼンテーションを PDF にエクスポートした際に、PDF のタグ構造へは **転送されません**。したがって、タグとして割り当てられたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text** にカスタム識別子を保存することができます（例: `shape->set_AlternativeText(u"MyId")`）。PDF にエクスポートした後、Alt Text が PDF のタグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。 [tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) は、すべてのキーとバリューのペアを一度に削除する [Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を反復せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/remove/) を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) で [GetNamesOfTags](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なく、すべてのカスタム XML パーツを見つけるにはどうすればよいですか？**

プレゼンテーション内のすべてのカスタム XML パーツを取得するには、[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_allcustomxmlparts/) を使用します。

**カスタム XML パーツを更新する際に、`get_XmlAsString`/`set_XmlAsString` と `get_XmlData`/`set_XmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 XML テキストで動作する場合は `get_XmlAsString` と `set_XmlAsString` を使用してください。XML がすでにバイト配列として利用できる場合や、バイナリ指向の処理が便利な場合は `get_XmlData` と `set_XmlData` を使用してください。両方の表現は同じカスタム XML パーツの XML コンテンツを指します。