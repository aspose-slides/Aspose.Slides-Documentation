---
title: Android でのプレゼンテーションにおけるタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/androidjava/managing-tags-and-custom-data
keywords:
- ドキュメントプロパティ
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーション内のタグとカスタム XML データの管理方法（追加、読み取り、更新、監査、削除）を学びます。"
---
## **概要**

本記事では、Aspose.Slides が PowerPoint プレゼンテーション内のタグとカスタム データをどのように扱うかを説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーと値の文字列ペアで、カスタム XML パーツは構造化メタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプのレベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理の識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を格納する統合に便利です。

## **プレゼンテーション ファイル内のデータ保存**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツおよび関連データを格納するためのパッケージ構造とリレーションシップを定義しています。

プレゼンテーションは、リレーションシップで接続された複数のパーツで構成されます。たとえば、スライド パートは単一のスライドのコンテンツを含み、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ ([ITagCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITagCollection)) またはカスタム XML パーツ ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection)) として保存できます。これらはすべて [`ICustomData`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomData/) インターフェイスを介して利用可能です。

{{% alert color="primary" %}}
タグはシンプルな文字列キーとバリューのペアを格納します。カスタム XML パーツは構造化された XML データを格納し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

`ICustomData.getCustomXmlParts()` メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation.getCustomData().getCustomXmlParts()` は、プレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide.getCustomData().getCustomXmlParts()` は、特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape.getCustomData().getCustomXmlParts()` は、特定のシェイプに関連付けられたカスタム XML パーツを含みます。

プレゼンテーション内のすべてのカスタム XML パーツを、関連付け場所に関係なく検査したい場合は、[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

`ICustomXmlPartCollection.add` を使用して、カスタム XML パーツ コレクションに XML データを追加します。XML は有効で空であってはなりません。

以下の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します：

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

    // add は自動的に識別子を割り当てます。必要な場合にのみ特定の UUID を設定します。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` メソッドは XML をバイト配列または入力ストリームとして受け取ることもでき、XML コンテンツが既にバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく、特定のスライドまたはシェイプに関連付けることができます。これにより、メタデータがテンプレートキー、外部レコード識別子、バインディング情報など、特定のオブジェクトのみを記述する場合に便利です。

以下の例は、スライドに 1 つのカスタム XML パーツを、シェイプに別のカスタム XML パーツを追加します：

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

パーツが追加されるレベルに応じて、どのオブジェクトの `getCustomData().getCustomXmlParts()` コレクションにそのパーツへのリレーションシップが含まれるかが決まります。プレゼンテーション レベルのデータは文書全体のメタデータに適し、スライド レベルのデータは特定のスライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付けられたメタデータに適しています。

### **すべてのカスタム XML パーツを一覧表示および監査する**

`Presentation.getAllCustomXmlParts()` を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 [`ICustomXmlPart`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart/) は、その識別子、XML コンテンツ、関連付けられた名前空間スキーマを公開します。

以下の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します：

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションの監査時に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

`ICustomXmlPart.getXmlAsString()` と [`setXmlAsString()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) を使用して UTF-8 文字列として XML を操作するか、[`getXmlData()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) と [`setXmlData()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) を使用して生の XML バイトを操作します。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する UUID を返します。統合で新しい識別子が必要な場合は、[`setItemId()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) を使用します。

以下の例は、XML コンテンツと識別子を更新します：

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

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが主に文字列で操作するかバイト データで操作するかに応じて、どちらか一方の表現を使用します。

### **カスタム XML パーツの削除**

`ICustomXmlPart.remove` は、プレゼンテーションからカスタム XML パーツを削除します。

`ICustomXmlPartCollection.remove` は、カスタム XML パーツ コレクションから特定のパーツを削除します。

`ICustomXmlPartCollection.removeAt` は、指定されたコレクションインデックスにあるパーツを削除します。

`ICustomXmlPartCollection.clear` は、特定のコレクションからすべてのパーツを削除します。

以下の例は、参照によりプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します：

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

`ICustomXmlPart` をすでに取得していて、プレゼンテーションからそのパーツだけを削除したい場合は、`customXmlPart.remove()` を呼び出します。

インデックスで項目を削除することもできます：

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

`clear` は選択したコレクションにのみ影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`getAllCustomXmlParts()` を反復処理し、各パーツを削除します：

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

### **リンクまたは共有されたカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルに複数のスライドやシェイプから同じ基礎カスタム XML パーツへのリレーションシップが含まれている場合があります。

共有パーツは、複数のリファレンスを持つ単一データオブジェクトとして扱う必要があります。

- `setXmlAsString`、`setXmlData`、`setItemId` で更新すると、基になるカスタム XML パーツが変更されるため、そのパーツが参照されているすべての場所に変更が適用されます。
- 監査時にオブジェクトレベルのコレクションで同一のカスタム XML パーツを識別するために、`getItemId()` を使用できます。
- 特定の `getCustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。パーツ自体をプレゼンテーションから削除する必要がある場合は、`ICustomXmlPart.remove()` を使用します。
- 共有パーツを削除または置換する前に、他のスライドやシェイプがまだ参照しているかどうかを確認するために、オブジェクトレベルのコレクションを調査してください。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成し、既存の `ICustomXmlPart` を受け入れません。したがって、共有リレーションシップは、既にそれらを含むプレゼンテーションをロードする際に最も一般的に見られます。

以下の例は、`ItemId` によってプレゼンテーション、スライド、シェイプ レベルのコレクションを監査し、複数の場所から参照されているパーツを報告します：

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

この種の監査は、外部システムで作成されたプレゼンテーションのカスタム XML データを変更または削除する前に役立ちます。同一のメタデータ パーツが複数のリレーションシップに関与している可能性があるためです。

## **タグの値の取得**

スライドでは、タグは `IDocumentProperties.getKeywords()` メソッドに相当します。以下のサンプルコードは、Aspose.Slides for Android via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) のタグ値を取得する方法を示しています。

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

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。- カスタム プロパティの名前（例：`MyTag`） - カスタム プロパティの値（例：`My Tag Value`）。

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合は、その目的でタグを追加できます。たとえば、北米諸国のプレゼンテーションを分類したい場合は、北米タグを作成し、該当する国名をその値として割り当てることができます。

以下のサンプルコードは、Aspose.Slides for Android via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) にタグを追加する方法を示しています：

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

タグは [Slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlide) に対しても設定できます：

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

または個々の [Shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape) に対して設定できます：

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

`getCustomData().getTags()` コレクションを介して追加されたタグは、PowerPoint ファイルにのみ保存されます。プレゼンテーションを PDF にエクスポートした際に、タグ構造へは **転送されません**。したがって、タグとして割り当てたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例：`shape.setAlternativeText("MyId")`）にカスタム識別子を保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に反映される場合があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。[タグコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) は、[clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#clear--) 操作をサポートしており、すべてのキーとバリューペアを一括で削除できます。

**コレクション全体を反復処理せずに、名前で単一のタグを削除するには？**

[タグコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するには？**

[タグコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なく、すべてのカスタム XML パーツを見つけるには？**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツを更新する際、`getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使用すべきですか？**

アプリケーションが UTF-8 の XML テキストで操作する場合は `getXmlAsString` と `setXmlAsString` を使用します。XML が既にバイト配列として利用可能、またはバイナリ指向の処理が便利な場合は `getXmlData` と `setXmlData` を使用してください。どちらの表現も同じカスタム XML パーツの XML コンテンツを指します。