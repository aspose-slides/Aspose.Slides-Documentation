---
title: ".NET でプレゼンテーションのタグとカスタム データを管理する"
linktitle: "タグとカスタム データ"
type: docs
weight: 300
url: /ja/net/managing-tags-and-custom-data/
keywords:
- "ドキュメント プロパティ"
- "タグ"
- "カスタム データ"
- "カスタム XML"
- "カスタム XML パート"
- "XML メタデータ"
- "ItemId"
- "タグの追加"
- "ペアの値"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーション内のタグとカスタム XML データを管理する方法を学びます。タグやカスタム XML パートの追加、読み取り、更新、監査、削除が含まれます。"
---
## **概要**

このドキュメントは、Aspose.Slides が PowerPoint プレゼンテーション内のタグおよびカスタム データをどのように扱うかを説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パートとして保存できます。タグは単純なキーと値の文字列ペアであり、カスタム XML パートは構造化されたメタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプ レベルでカスタム XML パートを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パートは、文書管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を保存する統合シナリオで便利です。

## **プレゼンテーション ファイル内のデータ格納**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツおよび関連データを格納するためのパッケージ構造とリレーションシップを定義します。

プレゼンテーションは複数のパートで構成され、リレーションシップで接続されています。たとえば、スライド パートは単一スライドの内容を保持し、ISO/IEC 29500 で定義された他のパートへの明示的なリレーションシップを持つことがあります。

カスタム データはタグ（[ITagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/itagcollection)）またはカスタム XML パート（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection)）として保存できます。どちらも [`ICustomData`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomdata/) インターフェイスから利用できます。

{{% alert color="info" %}}
タグは単純な文字列のキーとバリューのペアを保存します。カスタム XML パートは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パートの操作**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomdata/customxmlparts/) プロパティは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パートのコレクションを返します。例:

- `presentation.CustomData.CustomXmlParts` はプレゼンテーション自体に関連付けられたカスタム XML パートを含みます。
- `slide.CustomData.CustomXmlParts` は特定のスライドに関連付けられたカスタム XML パートを含みます。
- `shape.CustomData.CustomXmlParts` は特定のシェイプに関連付けられたカスタム XML パートを含みます。

プレゼンテーション全体のカスタム XML パートを調べたい場合は、[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用します。

### **プレゼンテーションにカスタム XML パートを追加する**

[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/add/) を使用して XML データをカスタム XML パート コレクションに追加します。XML は有効で空であってはなりません。

以下の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add は自動的に識別子を割り当てます。必要な場合にのみ特定の GUID を設定してください。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` メソッドは XML をバイト配列またはストリームとして受け取ることもでき、XML コンテンツが既にバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パートを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、バインディング情報など、単一オブジェクトにだけ関係する場合に有用です。

以下の例は、スライドに 1 つのカスタム XML パートを、シェイプに別のカスタム XML パートを追加します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

パートが追加されるレベルに応じて、どのオブジェクトの `CustomData.CustomXmlParts` コレクションにそのリレーションシップが含まれるかが決まります。プレゼンテーション レベルのデータは文書全体のメタデータに、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個別シェイプに紐付くメタデータに適しています。

### **すべてのカスタム XML パートを一覧表示および監査する**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用して、プレゼンテーション内のすべてのカスタム XML パートを取得します。各 [`ICustomXmlPart`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/) は識別子、XML コンテンツ、関連する名前空間スキーマを公開します。

以下の例は、すべてのカスタム XML パートとその名前空間スキーマを列挙します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/namespaceschemas/) は、そのカスタム XML パートに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/xmlasstring/) を使用して UTF-8 文字列として XML を扱うか、[`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/xmldata/) を使用して生の XML バイト列を扱うことができます。両方のプロパティは読み取りと更新が可能です。

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/itemid/) プロパティには、Office Open XML ドキュメント内でカスタム XML パートを識別する GUID が格納されています。統合で新しい識別子が必要な場合は変更可能です。

以下の例は、XML コンテンツと識別子の両方を更新します。

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// 現在の XML をテキストとして読み取ります。
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// XML を UTF-8 文字列として更新します。
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData は同じ XML コンテンツを生バイトとして提供します。
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// 統合で必要な場合に識別子を置き換えます。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

`XmlAsString` または `XmlData` に代入する際は、有効で空でない XML を提供してください。アプリケーションが文字列中心であれば `XmlAsString` を、バイト データ中心であれば `XmlData` を使用します。

### **カスタム XML パートの削除**

Aspose.Slides ではカスタム XML データを削除する方法が複数用意されています。

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/remove/) はプレゼンテーションからカスタム XML パートを削除します。
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/remove/) はコレクションから特定のパートを削除します。
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/removeat/) は指定インデックスのパートを削除します。
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/clear/) はコレクション内のすべてのパートを削除します。

以下の例は、参照によってプレゼンテーション レベルのカスタム XML パートを 1 つ削除します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

既に `ICustomXmlPart` インスタンスを保持していて、そのパートをプレゼンテーション全体から削除したい場合は `customXmlPart.Remove()` を呼び出します。

インデックスで削除することも可能です。

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **コレクションからすべてのカスタム XML パートをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パートを削除したい場合は `Clear` を使用します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` は選択したコレクションのみに影響します。たとえば、スライドのコレクションをクリアしてもプレゼンテーション レベルやシェイプ レベルのコレクションは保持されます。

プレゼンテーション内のすべてのカスタム XML パートを削除したい場合は、`AllCustomXmlParts` を列挙し各パートを削除します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **リンクまたは共有されたカスタム XML パートの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パートが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存ファイルに複数のスライドやシェイプから同じカスタム XML パートへのリレーションシップが存在する場合です。

共有パートは複数の参照を持つ単一データオブジェクトとして扱う必要があります。

- `XmlAsString`、`XmlData`、`ItemId` を更新すると、基になるカスタム XML パートが変更され、参照先すべてに反映されます。
- 監査時に同一パートを特定するために `ItemId` を使用できます。
- 特定の `CustomXmlParts` コレクションからパートを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体からパート自体を削除したい場合は `ICustomXmlPart.Remove()` を使用します。
- 共有パートを削除または置換する前に、オブジェクト レベルのコレクションを調べて他のスライドやシェイプがまだ参照していないか確認してください。

`Add` のオーバーロードは XML コンテンツから新しいカスタム XML パートを作成します。既存の `ICustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは既にパートを含むプレゼンテーションを読み込む際に最も一般的に遭遇します。

以下の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプ レベルのコレクションを監査し、複数箇所から参照されているパートを報告します。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

この種の監査は、外部システムが生成したプレゼンテーションでカスタム XML データを変更または削除する前に実施すると有用です。なぜなら同一メタデータ パートが複数のリレーションシップに参加している可能性があるからです。

## **タグの値を取得する**

スライドでタグは `IDocumentProperties.Keywords` プロパティに相当します。次のサンプルコードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) からタグの値を取得する方法を示します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides ではプレゼンテーションにタグを追加できます。タグは通常、次の 2 つの要素から構成されます。

- カスタム プロパティの名前（例: `MyTag`）
- カスタム プロパティの値（例: `My Tag Value`）

特定のルールやプロパティに基づいてプレゼンテーションを分類したい場合にタグを活用できます。たとえば、北米諸国のプレゼンテーションを分類したい場合は「NorthAmerican」というタグを作成し、該当する国名を値として設定します。

次のサンプルコードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) にタグを追加する方法を示します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

タグは [Slide](https://reference.aspose.com/slides/ja/net/aspose.slides/slide) に対しても設定できます。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

あるいは個々の [Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/shape) に対して設定することも可能です。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **制限事項**

`CustomData.Tags` コレクションを通じて追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして付与したカスタム識別子はタグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text** にカスタム識別子を格納します（例: `shape.AlternativeText = "MyId"`）。PDF にエクスポートすると、Alt Text が PDF タグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) は [Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/clear/) 操作をサポートしており、すべてのキーとバリューのペアを一度に削除できます。

**コレクション全体を走査せずに、名前だけで単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/remove/) を使用して、キーでタグを削除できます。

**解析やフィルタリングのためにタグ名の完全な一覧を取得したいです。方法は？**

[tag collection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) の [GetNamesOfTags](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名を配列で取得できます。

**保存場所に関係なくすべてのカスタム XML パートを取得するには？**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用して、プレゼンテーション内のすべてのカスタム XML パートを取得します。

**カスタム XML パートを更新する際、`XmlAsString` と `XmlData` のどちらを使うべきですか？**

アプリケーションが UTF-8 の XML テキストで主に動作する場合は `XmlAsString` を使用してください。XML がすでにバイト配列として利用可能、またはバイナリ指向の処理が便利な場合は `XmlData` を使用します。どちらも同一カスタム XML パートの内容を表します。