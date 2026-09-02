---
title: JavaScript を使用してプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/nodejs-java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- カスタム XML
- カスタム XML パート
- XML メタデータ
- ItemId
- タグを追加
- ペア値
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーション内のタグおよびカスタム XML データの管理方法（追加、読み取り、更新、監査、削除）を学びます。
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタムデータを扱う方法を説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パートとして保存できます。タグはシンプルなキーと値の文字列ペアで、カスタム XML パートは構造化されたメタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプのレベルでカスタム XML パートを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パートは、ドキュメント管理用識別子、ワークフロー状態、コンプライアンスメタデータ、テンプレートバインディングデータ、またはプレゼンテーション内のその他の構造化アプリケーションデータなどの情報を格納する統合に便利です。

## **プレゼンテーション ファイルにおけるデータ保存**

PPTX ファイル（拡張子が `.pptx` のファイル）は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML は、プレゼンテーション コンテンツと関連データを保存するためのパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパートで構成されます。たとえば、スライド パートは単一のスライドの内容を保持し、ISO/IEC 29500 で定義された他のパートへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[TagCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/)）またはカスタム XML パート（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpartcollection/)）として保存できます。これらは両方とも [`CustomData`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customdata/) クラスを通じて利用できます。

{{% alert color="primary" %}}
タグは単純な文字列キーと値のペアを保存します。カスタム XML パートは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パートの操作**

`[`CustomData`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customdata/)` の `getCustomXmlParts()` メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パートのコレクションを返します。例:

- `presentation.getCustomData().getCustomXmlParts()` にはプレゼンテーション自体に関連付けられたカスタム XML パートが含まれます。
- `slide.getCustomData().getCustomXmlParts()` には特定のスライドに関連付けられたカスタム XML パートが含まれます。
- `shape.getCustomData().getCustomXmlParts()` には特定のシェイプに関連付けられたカスタム XML パートが含まれます。

プレゼンテーション内のすべてのカスタム XML パートを、関連付けの場所に関係なく検査する必要がある場合は、[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を使用します。

### **プレゼンテーションにカスタム XML パートを追加する**

`[`CustomXmlPartCollection`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpartcollection/)` の `add` メソッドを使用して、XML データをカスタム XML パート コレクションに追加します。XML は有効で空であってはなりません。

次の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add は自動的に識別子を割り当てます。必要な場合にのみ特定の UUID を設定してください。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` メソッドは XML をバイト配列として受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パートを追加する**

カスタム XML データは、プレゼンテーション全体ではなく、特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、バインディング情報など、単一のオブジェクトのみを記述する場合に便利です。

次の例は、スライドに 1 つのカスタム XML パート、シェイプにもう 1 つのカスタム XML パートを追加します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

パートが追加されるレベルは、どのオブジェクトの `getCustomData().getCustomXmlParts()` コレクションにそのパートへのリレーションシップが含まれるかを決定します。プレゼンテーション レベルのデータは文書全体のメタデータに、スライド レベルのデータは特定のスライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付くメタデータに適しています。

### **すべてのカスタム XML パートを一覧表示および監査する**

`[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/)` を使用して、プレゼンテーションからすべてのカスタム XML パートを取得します。各 [`CustomXmlPart`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpart/) は、その識別子、XML コンテンツ、関連する名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パートとその名前空間スキーマを一覧表示します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpart/)` はカスタム XML パートに関連付けられた XML スキーマを返します。この情報は、外部システムによって生成された XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId の読み取りと更新**

`[`CustomXmlPart`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpart/)` の `getXmlAsString()` と `setXmlAsString()` を使用して UTF-8 文字列として XML を操作し、`getXmlData()` と `setXmlData()` を使用して生の XML バイトを操作できます。

`getItemId()` メソッドは、Office Open XML ドキュメント内でカスタム XML パートを識別する UUID を返します。統合で新しい識別子が必要な場合は `setItemId()` を使用します。

次の例は、XML コンテンツと識別子を更新します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 現在の XML をテキストとして読み取ります。
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // XML を UTF-8 文字列として更新します。
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData は同じ XML コンテンツを生のバイトとして提供します。
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // 統合で必要な場合に識別子を置き換えます。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが主に文字列で動作するかバイト データで動作するかに応じて、どちらか一方の表現を使用します。

### **カスタム XML パートの削除**

Aspose.Slides は、カスタム XML データを削除するための複数の方法を提供します:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpart/) はプレゼンテーションからカスタム XML パートを削除します。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpartcollection/) はカスタム XML パート コレクションから特定のパートを削除します。
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpartcollection/) は指定されたコレクション インデックスのパートを削除します。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/customxmlpartcollection/) は特定のコレクションからすべてのパートを削除します。

次の例は、参照によってプレゼンテーション レベルのカスタム XML パートを 1 つ削除します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`CustomXmlPart` をすでに取得していて、特定のコレクションではなくプレゼンテーションからそのパートを削除したい場合は、`customXmlPart.remove()` を呼び出します。

インデックスで項目を削除することもできます:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **コレクションからすべてのカスタム XML パートをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パートを削除する必要がある場合は、`clear` を使用します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パートを削除するには、`getAllCustomXmlParts()` を反復処理し、各パートを削除します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **リンクまたは共有されたカスタム XML パートの処理**

Office Open XML プレゼンテーションでは、同一のカスタム XML パートが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルは複数のスライドやシェイプから同じ基礎カスタム XML パートへのリレーションシップを含むことがあります。

共有パートは、複数の参照を持つ単一のデータオブジェクトとして扱う必要があります:

- `setXmlAsString`、`setXmlData`、または `setItemId` で更新すると、基礎となるカスタム XML パートが変更され、そのパートが参照されているすべての場所に変更が適用されます。
- 監査時にオブジェクト レベルのコレクションで同一のカスタム XML パートを識別するために `getItemId()` を使用できます。
- 特定の `getCustomXmlParts()` コレクションからパートを削除すると、そのコレクションからは削除されます。パート自体をプレゼンテーションから削除する必要がある場合は `CustomXmlPart.remove()` を使用します。
- 共有パートを削除または置換する前に、他のスライドやシェイプがまだ参照しているかどうかを判断するためにオブジェクト レベルのコレクションを確認します。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パートを作成します。既存の `CustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは、既にそれらを含むプレゼンテーションを読み込む際に最も一般的に発生します。

次の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプ レベルのコレクションを監査し、複数箇所から参照されているパートをレポートします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

この種の監査は、外部システムで作成されたプレゼンテーションのカスタム XML データを変更または削除する前に役立ちます。なぜなら、同一のメタデータ パートが複数のリレーションシップに関与している可能性があるからです。

## **タグの値を取得する**

スライドでは、タグは `DocumentProperties.getKeywords()` メソッドに相当します。このサンプル コードは、Node.js 用 Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) のタグ値を取得する方法を示しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます:

- カスタム プロパティの名前（例: `MyTag`）;
- カスタム プロパティの値（例: `My Tag Value`）。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合は、その目的でタグを追加できます。例えば、北米諸国のプレゼンテーションをカテゴリ分けしたい場合、北米タグを作成し、該当する国名を値として割り当てることができます。

このサンプル コードは、Node.js 用 Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) にタグを追加する方法を示しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/) に対して設定することもできます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

または個々の [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) に対して設定できます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **制限事項**

`getCustomData().getTags()` コレクションを通じて追加されたタグは PowerPoint ファイルにのみ保存されます。プレゼンテーションを PDF にエクスポートした際に、これらのタグは PDF のタグ構造へ **転送されません**。したがって、タグとして割り当てたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例: `shape.setAlternativeText("MyId")`）にカスタム識別子を保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。`[tag collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/)` はすべてのキーと値のペアを一度に削除する `[clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/)` 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

`[tag collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/)` 上で `remove(name)` を使用すると、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

`[tag collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/)` で `getNamesOfTags()` を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なくすべてのカスタム XML パートを見つけるにはどうすればよいですか？**

`[Presentation.getAllCustomXmlParts()](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/)` を使用すると、プレゼンテーション内のすべてのカスタム XML パートを取得できます。

**カスタム XML パートを更新する際に `getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 XML テキストで動作する場合は `getXmlAsString` と `setXmlAsString` を使用します。XML がすでにバイト配列として利用可能であるか、バイナリ指向の処理がより便利な場合は `getXmlData` と `setXmlData` を使用します。いずれの表現も同一のカスタム XML パートの XML コンテンツを指します。