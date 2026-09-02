---
title: Java を使用したプレゼンテーションでのタグとカスタム データの管理
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
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内のタグとカスタム XML データを管理する方法を学びます。タグやカスタム XML パーツの追加、読み取り、更新、監査、削除が含まれます。"
---
## **概要**

本記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データを扱う方法を説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーとバリューの文字列ペアであり、カスタム XML パーツは構造化メタデータやアプリケーション固有の XML ペイロードを保存できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプ レベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーションデータなどの情報を格納する統合に役立ちます。

## **プレゼンテーション ファイルにおけるデータ保存**

PPTX ファイル（`.pptx` 拡張子を持つファイル）は、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツと関連データを保存するために使用されるパッケージ構造とリレーションシップを定義しています。

プレゼンテーションは、リレーションシップで接続された複数のパーツで構成されます。たとえば、スライド パートは単一のスライドの内容を含み、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[ITagCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITagCollection)）またはカスタム XML パーツ（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection)）として保存できます。両方とも [`ICustomData`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomData/) インターフェイスを通じて利用可能です。

{{% alert color="primary" %}}
タグはシンプルな文字列キーとバリューのペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomData#getCustomXmlParts--) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例として：

- `presentation.getCustomData().getCustomXmlParts()` はプレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide.getCustomData().getCustomXmlParts()` は特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape.getCustomData().getCustomXmlParts()` は特定のシェイプに関連付けられたカスタム XML パーツを含みます。

プレゼンテーション内のすべてのカスタム XML パーツを、関連付けられた場所に関係なくチェックしたい場合は、[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効で空でない必要があります。

次の例は、プレゼンテーションレベルのカスタム データ コレクションに構造化メタデータを追加します：

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

    // add は自動的に識別子を割り当てます。必要な場合のみ特定の UUID を設定します。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` メソッドは、XML をバイト配列または入力ストリームとして受け取ることもでき、XML コンテンツがバイナリ形式で既に利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく、特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレートキー、外部レコード識別子、バインディング情報など、単一のオブジェクトだけを記述する場合に便利です。

次の例は、スライドに 1 つのカスタム XML パーツを、シェイプに別のカスタム XML パーツを追加します：

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

パーツが追加されるレベルは、どのオブジェクトの `getCustomData().getCustomXmlParts()` コレクションにそのパーツへのリレーションシップが含まれるかを決定します。プレゼンテーションレベルのデータはドキュメント全体のメタデータに適し、スライドレベルのデータは特定のスライドに属する情報に、シェイプレベルのデータは個々のシェイプに結びつくメタデータに適します。

### **すべてのカスタム XML パーツを一覧表示および監査する**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 [`ICustomXmlPart`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart/) は、識別子、XML コンテンツ、および関連する名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します：

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) は、カスタム XML パーツに関連付けられた XML スキーマを返します。外部システムが生成した XML を含むプレゼンテーションを監査する際に、この情報は役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) と [`setXmlAsString()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) を使用して XML を UTF-8 文字列として扱い、あるいは [`getXmlData()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getXmlData--) と [`setXmlData()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) を使用して生の XML バイトを扱います。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#getItemId--) メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する UUID を返します。統合で新しい識別子が必要な場合は、[`setItemId()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) を使用します。

次の例は、XML コンテンツと識別子を更新します：

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

    // getXmlData は同じ XML 内容を生バイトとして提供します。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 統合で必要な場合に識別子を置き換えます。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが主に文字列で動作するかバイト データで動作するかに応じて、どちらか一方の表現を使用します。

### **カスタム XML パーツの削除**

Aspose.Slides には、カスタム XML データを削除するいくつかの方法があります。

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPart#remove--) は、プレゼンテーションからカスタム XML パーツを削除します。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) は、カスタム XML パーツ コレクションから特定のパーツを削除します。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) は、指定されたコレクションインデックスのパーツを削除します。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection#clear--) は、特定のコレクションからすべてのパーツを削除します。

次の例は、参照によりプレゼンテーションレベルのカスタム XML パーツを 1 つ削除します：

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

`ICustomXmlPart` を既に持っていて、特定のコレクションを指定せずにプレゼンテーションからそのパーツを削除したい場合は、`customXmlPart.remove()` を呼び出します。

インデックスで項目を削除することもできます。

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除する必要がある場合は、`clear` を使用します。

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

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーションレベルやシェイプレベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`getAllCustomXmlParts()` を反復し、各パーツを削除します。

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

### **リンクまたは共有されたカスタム XML パーツの扱い**

Office Open XML プレゼンテーションでは、同じカスタム XML パーツが�数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルには、複数のスライドやシェイプから同じ基礎となるカスタム XML パーツへのリレーションシップが含まれていることがあります。

共有パーツは、複数の参照を持つ単一のデータオブジェクトとして扱うべきです：

- `setXmlAsString`、`setXmlData`、または `setItemId` で更新すると、基礎となるカスタム XML パーツが変更されるため、そのパーツが参照されているすべての場所に変更が適用されます。
- `getItemId()` は、オブジェクトレベルのコレクションを監査する際に、同じカスタム XML パーツを特定するために使用できます。
- 特定の `getCustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。パーツ自体をプレゼンテーションから削除する必要がある場合は、`ICustomXmlPart.remove()` を使用します。
- 共有パーツを削除または置換する前に、オブジェクトレベルのコレクションを確認し、他のスライドやシェイプがまだ参照しているかどうかを判断します。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` を受け取ることはできません。したがって、共有リレーションシップは、すでにそれらを含んでいるプレゼンテーションを読み込む際に最も一般的に遭遇します。

次の例は、`ItemId` によってプレゼンテーション、スライド、シェイプレベルのコレクションを監査し、複数の場所から参照されているパーツを報告します：

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

この種の監査は、外部システムによって作成されたプレゼンテーションでカスタム XML データを変更または削除する前に有用です。同じメタデータ パーツが複数のリレーションシップに参加している可能性があるためです。

## **タグの値の取得**

スライドでは、タグは `IDocumentProperties.getKeywords()` メソッドに対応します。このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) のタグ値を取得する方法を示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます：

- カスタム プロパティの名前（例：`MyTag`）；
- カスタム プロパティの値（例：`My Tag Value`）。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合は、その目的のためにタグを追加できます。たとえば、北米諸国のプレゼンテーションを分類したい場合は、北米タグを作成し、該当する国名をその値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) にタグを追加する方法を示します：

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

タグは [Slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide) に対しても設定できます：

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

あるいは個々の [Shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) に対して設定できます：

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

`getCustomData().getTags()` コレクションを通じて追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際に、タグは PDF のタグ構造へは **転送されません**。したがって、タグとして割り当てられたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**：カスタム識別子をオブジェクトの **Alt Text** に保存できます（例：`shape.setAlternativeText("MyId")`）。PDF にエクスポートした後、Alt Text が PDF のタグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) は、すべてのキーとバリューのペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#clear--) 操作をサポートしています。

**コレクション全体を反復せずに、名前で単一のタグを削除するには？**

[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するには？**

[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用します。すべてのタグ名の配列を返します。

**保存場所に関わらず、すべてのカスタム XML パーツを見つけるには？**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツを更新する際、`getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 の XML テキストで動作する場合は `getXmlAsString` と `setXmlAsString` を使用します。XML がすでにバイト配列として利用可能であるか、バイナリ指向の処理が便利な場合は `getXmlData` と `setXmlData` を使用します。どちらの表現も同じカスタム XML パーツの XML コンテンツを指します。