---
title: Android でのプレゼンテーションにおけるタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーション内のタグとカスタム XML データを管理する方法を学びます。タグやカスタム XML パーツの追加、読み取り、更新、監査、削除が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データを扱う方法について説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーとバリューの文字列ペアで、カスタム XML パーツは構造化されたメタデータやアプリケーション固有の XML ペイロードを保存できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプのレベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を保存する統合に便利です。

## **プレゼンテーション ファイルのデータ保存**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツと関連データを保存するために使用されるパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパーツで構成されます。たとえば、スライド パーツは単一スライドのコンテンツを保持し、ISO/IEC 29500 によって定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ ([ITagCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITagCollection)) またはカスタム XML パーツ ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection)) として保存できます。両方とも [`ICustomData`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomData/) インターフェイスから利用可能です。

{{% alert color="info" %}}
タグはシンプルな文字列のキー‑バリュー ペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation.getCustomData().getCustomXmlParts()` はプレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide.getCustomData().getCustomXmlParts()` は特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape.getCustomData().getCustomXmlParts()` は特定のシェイプに関連付けられたカスタム XML パーツを含みます。

プレゼンテーション全体のカスタム XML パーツを調査したい場合は、`Presentation.getAllCustomXmlParts()` を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効で空であってはなりません。

以下の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します:

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

    // add は識別子を自動的に割り当てます。特定の UUID は必要なときだけ設定してください。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` メソッドは、XML をバイト配列または入力ストリームとして受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレート キー、外部レコード識別子、バインディング情報など、単一オブジェクトにのみ関係する場合に有用です。

以下の例は、スライドに 1 つ、シェイプに 1 つのカスタム XML パーツを追加します:

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

パーツが追加されるレベルは、どのオブジェクトの `getCustomData().getCustomXmlParts()` コレクションにそのリレーションシップが含まれるかを決定します。プレゼンテーション レベルのデータはドキュメント全体のメタデータに、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付けられたメタデータに適しています。

### **すべてのカスタム XML パーツを一覧表示および監査する**

`Presentation.getAllCustomXmlParts()` を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 [`ICustomXmlPart`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart/) は、識別子、XML コンテンツ、および関連付けられた名前空間スキーマを公開します。

以下の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します:

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

### **XML コンテンツおよび ItemId の読み取りと更新**

`ICustomXmlPart.getXmlAsString()` と `setXmlAsString()` を使用して UTF-8 文字列として XML を操作するか、`getXmlData()` と `setXmlData()` を使用して生の XML バイトを操作します。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する UUID を返します。統合で新しい識別子が必要な場合は、`setItemId()` を使用します。

以下の例は、XML コンテンツと識別子を更新します:

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

    // getXmlData は同じ XML コンテンツを生バイトとして提供します。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 統合で必要な場合に識別子を置き換えます。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` または `setXmlData` を呼び出す際は、有効で空でない XML を提供してください。アプリケーションが文字列中心で動作するかバイト データ中心で動作するかに応じて、どちらか一方の表現を使用します。

### **カスタム XML パーツを削除する**

Aspose.Slides にはカスタム XML データを削除する複数の方法があります:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPart#remove--) はプレゼンテーションからカスタム XML パーツを削除します。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) はコレクションから特定のパーツを削除します。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) は指定インデックスのパーツを削除します。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) は特定のコレクションからすべてのパーツを削除します。

以下の例は、参照によってプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します:

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

既に `ICustomXmlPart` を保持していて、特定のコレクションではなくプレゼンテーションからそのパーツを削除したい場合は、`customXmlPart.remove()` を呼び出します。

インデックスで項目を削除することもできます:

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

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしても、プレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`getAllCustomXmlParts()` を反復処理し、各パーツを削除します:

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

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存ファイルが複数のスライドやシェイプから同じカスタム XML パーツへのリレーションシップを含む場合です。

共有パーツは、複数の参照を持つ単一のデータオブジェクトとして扱うべきです:

- `setXmlAsString`、`setXmlData`、`setItemId` で更新すると、基になるカスタム XML パーツが変更され、参照先すべてに変更が反映されます。
- `getItemId()` は、オブジェクト レベルのコレクションを監査する際に同一のカスタム XML パーツを特定するために使用できます。
- 特定の `getCustomXmlParts()` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体からパーツ自体を削除したい場合は `ICustomXmlPart.remove()` を使用します。
- 共有パーツを削除または置換する前に、他のスライドやシェイプがまだ参照しているかどうかをオブジェクト レベルのコレクションで確認してください。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `ICustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは、すでにそれらを含むプレゼンテーションを読み込む際に最も一般的に遭遇します。

以下の例は、`ItemId` によってプレゼンテーション、スライド、シェイプのコレクションを監査し、複数箇所から参照されているパーツをレポートします:

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

この種の監査は、外部システムが作成したプレゼンテーションでカスタム XML データを変更または削除する前に役立ちます。なぜなら同一メタデータ パーツが複数のリレーションシップに参加している可能性があるからです。

## **タグの値を取得する**

スライドでは、タグは `IDocumentProperties.getKeywords()` メソッドに相当します。このサンプル コードは、Aspose.Slides for Android via Java で [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) のタグ値を取得する方法を示しています:

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

Aspose.Slides はプレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます:

- カスタム プロパティの名前、例: `MyTag`
- カスタム プロパティの値、例: `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加して目的を達成できます。たとえば、北米諸国のプレゼンテーションを分類したい場合、北米タグを作成し、該当する国名をその値として割り当てます。

以下のサンプル コードは、Aspose.Slides for Android via Java で [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) にタグを追加する方法を示しています:

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

タグは [Slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlide) に対しても設定できます:

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

または個々の [Shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape) に対して設定できます:

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

`getCustomData().getTags()` コレクションを介して追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム識別子はタグ付けされた PDF から取得できません。

**回避策**: カスタム識別子をオブジェクトの **Alt Text** に保存できます（例: `shape.setAlternativeText("MyId")`）。PDF にエクスポートすると、Alt Text が PDF タグ構造に現れる可能性があります。

## **FAQ**

**プレゼンテーション、スライド、シェイプのすべてのタグを一括で削除できますか？**

はい。[タグ コレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) は、すべてのキー‑バリュー ペアを一度に削除する `clear` 操作をサポートしています。

**コレクション全体を走査せずに名前で単一のタグを削除する方法は？**

タグ コレクション上で `remove(name)` を使用して、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全なリストを取得するには？**

タグ コレクション上で `getNamesOfTags` を使用すると、すべてのタグ名が配列で返されます。

**保存場所に関係なくすべてのカスタム XML パーツを取得するには？**

`Presentation.getAllCustomXmlParts()` を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツの更新には `getXmlAsString`/`setXmlAsString` と `getXmlData`/`setXmlData` のどちらを使うべきですか？**

アプリケーションが UTF‑8 XML テキストで動作する場合は `getXmlAsString` と `setXmlAsString` を使用します。XML が既にバイト配列として利用可能、またはバイナリ中心の処理が便利な場合は `getXmlData` と `setXmlData` を使用します。どちらの表現も同一カスタム XML パーツのコンテンツを指します。