---
title: プレゼンテーションでタグとカスタム データを PHP で管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/php-java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- カスタム XML
- カスタム XML パート
- XML メタデータ
- ItemId
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションのタグとカスタム XML データを管理する方法を学びます。タグの追加、読み取り、更新、監査、カスタム XML パートの削除が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーション内のタグおよびカスタム データをどのように扱うかを説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パートとして保存できます。タグはシンプルなキーと値の文字列ペアで、カスタム XML パートは構造化メタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプのレベルでカスタム XML パートを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パートは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を保存する統合に便利です。

## **プレゼンテーション ファイルのデータ格納**

PPTX ファイル（`.pptx` 拡張子のファイル）は PresentationML 形式で保存され、これは Office Open XML 仕様の一部です。Office Open XML は、プレゼンテーション コンテンツと関連データを格納するためのパッケージ構造とリレーションシップを定義しています。

プレゼンテーションは、リレーションシップで接続された複数のパートで構成されています。たとえば、スライド パートは単一スライドのコンテンツを含み、ISO/IEC 29500 に定義された他のパートへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[TagCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/)）またはカスタム XML パート（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/)）として保存できます。両方とも [`CustomData`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customdata/) クラスを介して利用できます。

{{% alert color="primary" %}}
タグはシンプルな文字列キーとバリューのペアを格納します。カスタム XML パートは構造化された XML データを格納し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パートの操作**

[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customdata/#getCustomXmlParts) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パートのコレクションを返します。例:

- `$presentation->getCustomData()->getCustomXmlParts()` は、プレゼンテーション自体に関連付けられたカスタム XML パートを含みます。
- `$slide->getCustomData()->getCustomXmlParts()` は、特定のスライドに関連付けられたカスタム XML パートを含みます。
- `$shape->getCustomData()->getCustomXmlParts()` は、特定のシェイプに関連付けられたカスタム XML パートを含みます。

プレゼンテーション全体のカスタム XML パートを、関連付け位置に関係なく確認する必要がある場合は、[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用してください。

### **プレゼンテーションにカスタム XML パートを追加する**

[`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/#add) を使用して、XML データをカスタム XML パート コレクションに追加します。XML は有効で空であってはなりません。

以下の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add は自動的に識別子を割り当てます。必要な場合にのみ特定の UUID を設定してください。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` メソッドは、XML をバイト配列または入力ストリームとして受け取ることもでき、XML 内容がすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パートを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、バインディング情報など、単一のオブジェクトのみを記述する場合に便利です。

以下の例は、スライドに 1 つのカスタム XML パートを、シェイプに別のカスタム XML パートを追加します。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

パートが追加されるレベルは、どのオブジェクトの `getCustomData()->getCustomXmlParts()` コレクションにそのパートへのリレーションシップが含まれるかを決定します。プレゼンテーション レベルのデータは文書全体のメタデータに適し、スライド レベルのデータは特定のスライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結びつくメタデータに適しています。

### **すべてのカスタム XML パートを一覧表示および監査する**

[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用して、プレゼンテーションからすべてのカスタム XML パートを取得します。各 [`CustomXmlPart`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/) は、その識別子、XML コンテンツ、および関連する名前空間スキーマを公開します。

以下の例は、すべてのカスタム XML パートとその名前空間スキーマを一覧表示します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) は、カスタム XML パートに関連付けられた XML スキーマを返します。この情報は、外部システムによって生成された XML を含むプレゼンテーションを監査する際に有用です。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#getXmlAsString) と [`setXmlAsString()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#setXmlAsString) を使用して UTF-8 文字列として XML を操作し、または [`getXmlData()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#getXmlData) と [`setXmlData()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#setXmlData) を使用して生の XML バイトを操作します。

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#getItemId) メソッドは、Office Open XML ドキュメント内でカスタム XML パートを識別する UUID を返します。統合で新しい識別子が必要な場合は、[`setItemId()`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#setItemId) を使用してください。

以下の例は、XML コンテンツと識別子を更新します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // 現在の XML をテキストとして読み取ります。
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // XML を UTF-8 文字列として更新します。
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData は生のバイトとして同じ XML コンテンツを提供します。
    $customXmlData = $customXmlPart->getXmlData();

    // 統合で必要なときに識別子を置き換えます。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが主に文字列で動作するかバイト データで動作するかに応じて、どちらか一方の表現を使用します。

### **カスタム XML パートの削除**

Aspose.Slides はカスタム XML データを削除するための複数の方法を提供します：

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpart/#remove) は、プレゼンテーションからカスタム XML パートを削除します。
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/#remove) は、カスタム XML パート コレクションから特定のパートを削除します。
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/#removeAt) は、指定されたコレクションインデックスのパートを削除します。
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/#clear) は、特定のコレクションからすべてのパートを削除します。

以下の例は、参照によりプレゼンテーション レベルのカスタム XML パートを 1 つ削除します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`CustomXmlPart` をすでに取得していて、特定のコレクションを指定せずにプレゼンテーションからそのパートを削除したい場合は、`$customXmlPart->remove()` を呼び出してください。

インデックスで項目を削除することもできます:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **コレクションからすべてのカスタム XML パートをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パートを削除する必要がある場合は、`clear` を使用します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パートを削除するには、`getAllCustomXmlParts()` を反復処理し、各パートを削除します:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **リンクまたは共有されたカスタム XML パートの取り扱い**

Office Open XML プレゼンテーションでは、同じカスタム XML パートが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルは、複数のスライドやシェイプから同一のカスタム XML パートへのリレーションシップを含むことができます。

共有パートは、複数の参照を持つ単一のデータオブジェクトとして扱うべきです：

- `setXmlAsString`、`setXmlData`、または `setItemId` で更新すると、基になるカスタム XML パートが変更され、そのパートが参照されているすべての場所に変更が適用されます。
- `getItemId()` は、オブジェクトレベルのコレクションを監査する際に同一のカスタム XML パートを識別するために使用できます。
- 特定の `getCustomXmlParts()` コレクションからパートを削除すると、そのコレクションからパートが削除されます。パート自体をプレゼンテーションから削除する必要がある場合は、`CustomXmlPart::remove()` を使用してください。
- 共有パートを削除または置換する前に、オブジェクトレベルのコレクションを検査し、他のスライドやシェイプがまだ参照しているかどうかを確認してください。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パートを作成します。既存の `CustomXmlPart` を受け入れることはありません。そのため、共有リレーションシップは、すでにそれらを含むプレゼンテーションをロードするときに最も一般的に遭遇します。

以下の例は、`ItemId` によってプレゼンテーション、スライド、シェイプレベルのコレクションを監査し、複数の場所から参照されているパートを報告します。

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

この種の監査は、外部システムで作成されたプレゼンテーションのカスタム XML データを変更または削除する前に有用です。なぜなら、同一のメタデータ パートが複数のリレーションシップに関与している可能性があるからです。

## **タグの値を取得する**

スライドでは、タグは `DocumentProperties::getKeywords()` メソッドに対応しています。このサンプル コードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のタグ値を取得する方法を示しています。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、2 つの項目で構成されます：

- カスタム プロパティの名前（例: `MyTag`）;
- カスタム プロパティの値（例: `My Tag Value`）。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、その目的でタグを追加できます。たとえば、北米諸国のプレゼンテーションを分類したい場合、北米タグを作成し、対象となる国名をその値として割り当てることができます。

このサンプルコードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) にタグを追加する方法を示しています。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) に対しても設定できます：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

または個々の [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) に対しても設定できます：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **制限事項**

`getCustomData()->getTags()` コレクションを通じて追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際に、タグは PDF タグ構造に **転送されません**。したがって、タグとして割り当てたカスタム識別子は、タグ付き PDF から取得できません。

**回避策**: カスタム識別子をオブジェクトの **Alt Text**（例: `$shape->setAlternativeText("MyId")`）に保存できます。PDF にエクスポートした後、Alt Text が PDF タグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/) は、すべてのキーとバリューのペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/#clear) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

タグコレクションの [remove(name)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/#remove) を使用して、キーでタグを削除してください。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[getNamesOfTags](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/#getNamesOfTags) をタグコレクションで使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なく、すべてのカスタム XML パートを見つけるにはどうすればよいですか？**

[Presentation::getAllCustomXmlParts()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用して、プレゼンテーション内のすべてのカスタム XML パートを取得してください。

**カスタム XML パートを更新する際、`getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 の XML テキストで主に動作する場合は `getXmlAsString` と `setXmlAsString` を使用してください。XML がすでにバイト配列として利用可能である、またはバイナリ指向の処理が便利な場合は `getXmlData` と `setXmlData` を使用します。両方の表現は同一のカスタム XML パートの XML コンテンツを指します。