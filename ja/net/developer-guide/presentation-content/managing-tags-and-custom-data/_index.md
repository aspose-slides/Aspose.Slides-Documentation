---
title: .NET でプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/net/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- カスタム XML
- カスタム XML パーツ
- XML メタデータ
- ItemId
- タグを追加
- ペア値
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのタグとカスタム XML データを管理する方法を学びます。タグやカスタム XML パーツの追加、読み取り、更新、監査、削除が含まれます。"
---
## **概要**

本記事では、Aspose.Slides が PowerPoint プレゼンテーションにおけるタグおよびカスタムデータをどのように扱うかについて説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーとバリューの文字列ペアであり、カスタム XML パーツは構造化されたメタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプの各レベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データを格納する統合に役立ちます。

## **プレゼンテーション ファイル内のデータ 保存**

.pptx 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツと関連データを格納するためのパッケージ構造およびリレーションシップを定義します。

プレゼンテーションは、リレーションシップで結ばれた複数のパーツで構成されます。たとえば、スライド パーツは単一のスライドの内容を保持し、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことがあります。

カスタム データは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/itagcollection)）またはカスタム XML パーツ（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection)）として保存できます。両方とも [`ICustomData`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomdata/) インターフェイスを介して利用できます。

{{% alert color="primary" %}}
タグはシンプルな文字列キーとバリューのペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomdata/customxmlparts/) プロパティは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation.CustomData.CustomXmlParts` にはプレゼンテーション自体に関連付けられたカスタム XML パーツが含まれます。
- `slide.CustomData.CustomXmlParts` には特定のスライドに関連付けられたカスタム XML パーツが含まれます。
- `shape.CustomData.CustomXmlParts` には特定のシェイプに関連付けられたカスタム XML パーツが含まれます。

プレゼンテーション全体のカスタム XML パーツを場所に関係なく確認したい場合は、[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/add/) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効かつ空であってはなりません。

次の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

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

// Add は自動的に識別子を割り当てます。必要な場合のみ特定の GUID を設定してください。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` メソッドは、XML をバイト配列またはストリームとして受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、またはバインディング情報など、単一オブジェクトにのみ適用される場合に有用です。

次の例は、スライドに 1 つ、シェイプに 1 つのカスタム XML パーツを追加します。

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

パーツが追加されるレベルに応じて、どのオブジェクトの `CustomData.CustomXmlParts` コレクションにそのリレーションシップが含まれるかが決まります。プレゼンテーション レベルのデータはドキュメント全体のメタデータに、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個々のシェイプに紐付くメタデータに適しています。

### **すべてのカスタム XML パーツを一覧表示および監査する**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 [`ICustomXmlPart`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/) は、識別子、XML コンテンツ、関連付けられた名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します。

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/namespaceschemas/) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/xmlasstring/) を使用して UTF-8 文字列として XML を操作するか、[`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/xmldata/) を使用して生の XML バイトを操作します。両方のプロパティは読み取りおよび更新が可能です。

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/itemid/) プロパティには、Office Open XML ドキュメント内でカスタム XML パーツを識別する GUID が格納されます。統合で新しい識別子が必要な場合は変更可能です。

次の例は、XML コンテンツと識別子を更新します。

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

// XmlData は同じ XML 内容を生バイトとして提供します。
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// 統合で必要な場合に識別子を置き換えます。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

`XmlAsString` または `XmlData` に代入する際は、有効で空でない XML を提供してください。アプリケーションが文字列中心かバイト データ中心かに応じて、どちらか一方の表現を使用します。

### **カスタム XML パーツを削除する**

Aspose.Slides にはカスタム XML データを削除する複数の方法があります。

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpart/remove/) はプレゼンテーションからカスタム XML パーツを削除します。
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/remove/) は特定のコレクションからパーツを削除します。
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/removeat/) は指定したコレクションインデックスのパーツを削除します。
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection/clear/) は特定のコレクション内のすべてのパーツを削除します。

次の例は、参照を使用してプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します。

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

既に `ICustomXmlPart` のインスタンスを保持していて、特定のコレクションを指定せずにプレゼンテーションからそのパーツを削除したい場合は、`customXmlPart.Remove()` を呼び出します。

インデックスによる削除も可能です。

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除する場合は `Clear` を使用します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしてもプレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`AllCustomXmlParts` を列挙し、各パーツを個別に削除します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **リンクされたまたは共有されたカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存ファイルに複数のスライドやシェイプから同じ基盤カスタム XML パーツへのリレーションシップが含まれている場合です。

共有パーツは、複数の参照を持つ単一のデータ オブジェクトとして扱う必要があります。

- `XmlAsString`、`XmlData`、`ItemId` を更新すると基盤のカスタム XML パーツが変更され、参照先すべてに反映されます。
- `ItemId` は、オブジェクト レベルのコレクションを監査する際に同一パーツを識別するために使用できます。
- 特定の `CustomXmlParts` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体から削除したい場合は `ICustomXmlPart.Remove()` を使用してください。
- 共有パーツを削除または置換する前に、他のスライドやシェイプがまだ参照していないか、オブジェクト レベルのコレクションを確認してください。

`Add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは既にパーツを含むプレゼンテーションを読み込む際に最も一般的に遭遇します。

次の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプの各コレクションを監査し、複数箇所から参照されているパーツを報告します。

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

この種の監査は、外部システムによって作成されたプレゼンテーション内のカスタム XML データを修正または削除する前に有用です。同一メタデータ パーツが複数のリレーションシップに関与している可能性があるためです。

## **タグの値を取得する**

スライドにおけるタグは `IDocumentProperties.Keywords` プロパティに対応します。このサンプル コードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) のタグ値を取得する方法を示しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 項目で構成されます。

- カスタム プロパティの名前、例: `MyTag`
- カスタム プロパティの値、例: `My Tag Value`

特定の規則やプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加して目的を達成できます。たとえば、北米諸国のプレゼンテーションを分類したい場合、北米タグを作成し、該当する国名を値として設定します。

次のサンプル コードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) にタグを追加する方法を示しています。

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

または個々の [Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/shape) に対して設定できます。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **制限事項**

`CustomData.Tags` コレクションを介して追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム識別子はタグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **代替テキスト**（例: `shape.AlternativeText = "MyId"`）にカスタム識別子を保存できます。PDF にエクスポートした後、代替テキストが PDF タグ構造に表示される可能性があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[タグ コレクション](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) は、[Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/clear/) 操作をサポートしており、すべてのキーとバリューのペアを一度に削除できます。

**コレクション全体を走査せずに、名前で単一のタグを削除する方法は？**

[TagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/remove/) を使用して、キーでタグを削除します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するには？**

タグ コレクションの [GetNamesOfTags](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なくすべてのカスタム XML パーツを見つけるには？**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/allcustomxmlparts/) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツを更新する際、`XmlAsString` と `XmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 の XML テキストで作業する場合は `XmlAsString` を使用します。XML がすでにバイト配列として利用可能、またはバイナリ指向の処理が便利な場合は `XmlData` を使用します。どちらのプロパティも同一カスタム XML パーツの XML コンテンツを表します。