---
title: Java を使用したプレゼンテーションのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- カスタム XML
- カスタム XML パーツ
- XML メタデータ
- ItemId
- タグを追加
- ペアの値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのタグとカスタム XML データを管理する方法を学びます。タグの追加、読み取り、更新、監査、カスタム XML パーツの削除が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションのタグとカスタム データをどのように扱うかを説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーと値の文字列ペアであり、カスタム XML パーツは構造化されたメタデータやアプリケーション固有の XML ペイロードを保存できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプの各レベルでカスタム XML パーツを追加、取得、更新、監査、削除するための API を提供します。カスタム XML パーツは、文書管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データを格納する統合に便利です。

## **プレゼンテーション ファイル内のデータ保存**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツと関連データを保存するためのパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパーツから構成されます。たとえば、スライド パーツは単一のスライドのコンテンツを保持し、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[ITagCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITagCollection)）またはカスタム XML パーツ（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection)）として保存できます。どちらも[`ICustomData`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomData/) インターフェイスを通じて利用可能です。

{{% alert color="info" %}}
タグはシンプルな文字列のキーと値のペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomData#getCustomXmlParts--) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation.getCustomData().getCustomXmlParts()` にはプレゼンテーション自体に関連付けられたカスタム XML パーツが含まれます。
- `slide.getCustomData().getCustomXmlParts()` には特定のスライドに関連付けられたカスタム XML パーツが含まれます。
- `shape.getCustomData().getCustomXmlParts()` には特定のシェイプに関連付けられたカスタム XML パーツが含まれます。

プレゼンテーション全体のカスタム XML パーツを場所に関係なく調べたい場合は、[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効で空であってはなりません。

次の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add は自動的に識別子を割り当てます。必要な場合にのみ特定の UUID を設定してください。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` メソッドは XML をバイト配列または入力ストリームとして受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレート キー、外部レコード識別子、またはバインディング情報など、単一オブジェクトにのみ関係する場合に有用です。

次の例は、スライドに 1 つのカスタム XML パーツを、シェイプにもう 1 つのカスタム XML パーツを追加します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

パーツが追加されるレベルに応じて、どのオブジェクトの `getCustomData().getCustomXmlParts()` コレクションにそのパーツへのリレーションシップが含まれるかが決まります。プレゼンテーション レベルのデータは文書全体のメタデータに適し、スライド レベルのデータは特定のスライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付けられたメタデータに適します。

### **すべてのカスタム XML パーツを一覧表示および監査する**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。各[`ICustomXmlPart`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart/) は識別子、XML コンテンツ、および関連付けられた名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId を読み取りおよび更新する**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) と[`setXmlAsString()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) を使用して UTF-8 文字列として XML を操作するか、[`getXmlData()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getXmlData--) と[`setXmlData()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) を使用して生の XML バイトを操作します。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getItemId--) メソッドは、Office Open XML 文書内でカスタム XML パーツを識別する UUID を返します。統合で新しい識別子が必要な場合は[`setItemId()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) を使用します。

次の例は、XML コンテンツと識別子を更新します。

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 現在の XML をテキストとして読み取ります。
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML を UTF-8 文字列として更新します。
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData は同じ XML コンテンツを生のバイトとして提供します。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 統合で必要な場合に識別子を置き換えます。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが文字列中心であれば文字列版を、バイト配列中心であればバイト版を使用します。

### **カスタム XML パーツを削除する**

Aspose.Slides にはカスタム XML データを削除する複数の方法があります。

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#remove--) はプレゼンテーションからカスタム XML パーツを削除します。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) はコレクションから特定のパーツを削除します。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) は指定したコレクションインデックスのパーツを削除します。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#clear--) は特定のコレクション内のすべてのパーツを削除します。

次の例は、参照に基づいてプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

既に `ICustomXmlPart` インスタンスを持っていて、特定のコレクションではなくプレゼンテーション全体から削除したい場合は `customXmlPart.remove()` を呼び出します。

インデックスで削除することもできます。

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除したい場合は `clear` を使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしてもプレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`getAllCustomXmlParts()` を走査し、各パーツを削除します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **リンクまたは共有されているカスタム XML パーツを扱う**

Office Open XML プレゼンテーションでは、同じカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルに複数のスライドやシェイプから同一のカスタム XML パーツへのリレーションシップが含まれている場合です。

共有パーツは複数の参照を持つ 1 つのデータオブジェクトとして扱うべきです。

- `setXmlAsString`、`setXmlData`、または `setItemId` で更新すると、基になるカスタム XML パーツが変更され、参照先すべてに変更が反映されます。
- `getItemId()` は、オブジェクト レベルのコレクションを監査するときに同一のカスタム XML パーツを特定するのに使用できます。
- 特定の `getCustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからだけ削除されます。プレゼンテーション全体から削除したい場合は `ICustomXmlPart.remove()` を使用します。
- 共有パーツを削除または置換する前に、オブジェクト レベルのコレクションを確認し、他のスライドやシェイプがまだ参照していないかを調べます。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは主に既にパーツを含んでいるプレゼンテーションを読み込む際に遭遇します。

次の例は、`ItemId` によってプレゼンテーション、スライド、シェイプのコレクションを監査し、複数箇所から参照されているパーツを報告します。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

この種の監査は、外部システムが生成したプレゼンテーションのカスタム XML データを変更または削除する前に有用です。同じメタデータ パーツが複数のリレーションシップに関与している可能性があるためです。

## **タグの値を取得する**

スライドでは、タグは `IDocumentProperties.getKeywords()` メソッドに相当します。このサンプル コードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) からタグの値を取得する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides ではプレゼンテーションにタグを追加できます。タグは通常、次の 2 要素で構成されます。

- カスタム プロパティの名前（例: `MyTag`）
- カスタム プロパティの値（例: `My Tag Value`）

特定のルールやプロパティに基づいてプレゼンテーションを分類したい場合は、その目的でタグを追加できます。たとえば、北米諸国のプレゼンテーションをカテゴリ分けしたい場合は、NorthAmerican タグを作成し、該当する国名を値として割り当てます。

次のサンプル コードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) にタグを追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide) に対しても設定できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

または個々の [Shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) に対して設定できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **制限事項**

`getCustomData().getTags()` コレクションを介して追加されたタグは PowerPoint ファイル内にのみ保存され、PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム 識別子はタグ付き PDF から取得できません。

**回避策**: カスタム 識別子をオブジェクトの **代替テキスト**（例: `shape.setAlternativeText("MyId")`）に保存できます。PDF にエクスポートした後、代替テキストが PDF タグ構造に現れることがあります。

## **FAQ**

**すべてのタグをプレゼンテーション、スライド、またはシェイプから一括で削除できますか？**

はい。タグ コレクション（[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/)）は、すべてのキーと値のペアを一度に削除する `clear`（[clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#clear--)）操作をサポートします。

**コレクション全体を走査せずに、名前で単一のタグを削除する方法はありますか？**

タグ コレクション（[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/)）の `remove(name)`（[remove(name)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)）を使用して、キーでタグを削除できます。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

タグ コレクションの `getNamesOfTags`（[getNamesOfTags](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#getNamesOfTags--)）を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なく、すべてのカスタム XML パーツを見つけるにはどうすればよいですか？**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得できます。

**カスタム XML パーツを更新する際、`getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 XML テキストで操作する場合は `getXmlAsString` と `setXmlAsString` を使用します。既にバイト配列として XML が利用可能、またはバイナリ指向の処理が便利な場合は `getXmlData` と `setXmlData` を使用します。どちらの表現も同じカスタム XML パーツの内容を指します。