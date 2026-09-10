---
title: Python を使用したプレゼンテーションでのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/python-java/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーション内のタグとカスタム XML データを管理する方法を学びます。タグの追加、読み取り、更新、監査、カスタム XML パーツの削除が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションにおけるタグとカスタム データをどのように扱うかを説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグはシンプルなキーと値の文字列ペアであり、カスタム XML パーツは構造化メタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプ レベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理用識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内に保存するその他の構造化アプリケーション データを格納する統合シナリオで役立ちます。

## **プレゼンテーション ファイル内のデータ格納**

`.pptx` 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML は、プレゼンテーション コンテンツと関連データを格納するためのパッケージ構造とリレーションシップを定義しています。

プレゼンテーションは、リレーションシップで接続された複数のパーツから構成されます。たとえば、スライド パートは単一のスライドの内容を保持し、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[TagCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/)）またはカスタム XML パーツ（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/)）として格納できます。両方とも [CustomData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/) クラスから利用できます。

{{% alert color="info" title="注意" %}}
タグはシンプルな文字列のキー‑バリュー ペアを保存します。カスタム XML パーツは構造化 XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) メソッドは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- プレゼンテーションの [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) コレクションには、プレゼンテーション自体に関連付けられたカスタム XML パーツが含まれます。
- スライドの [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) コレクションには、特定のスライドに関連付けられたカスタム XML パーツが含まれます。
- シェイプの [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) コレクションには、特定のシェイプに関連付けられたカスタム XML パーツが含まれます。

プレゼンテーション全体のすべてのカスタム XML パーツを調べる必要がある場合は、[Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用してください。

### **プレゼンテーションにカスタム XML パーツを追加する**

[CustomXmlPartCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#add) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効で空であってはなりません。

以下の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add は自動的に識別子を割り当てます。特定の UUID が必要な場合にのみ設定してください。
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#add) メソッドは、バイト配列または入力ストリームとして XML を受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレート キー、外部レコード識別子、またはバインディング情報のように単一オブジェクトにのみ関係する場合に有用です。

以下の例は、スライドに 1 つのカスタム XML パーツ、シェイプに別のパーツを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

パーツが追加されるレベルは、どのオブジェクトの [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) コレクションにそのパートへのリレーションシップが含まれるかを決定します。プレゼンテーション レベルのデータは文書全体のメタデータに適し、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個々のシェイプに紐付くメタデータに適します。

### **すべてのカスタム XML パーツを列挙および監査する**

[Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。各 [CustomXmlPart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/) は、その識別子、XML コンテンツ、および関連付けられた名前空間スキーマを公開します。

以下の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムが生成した XML を含むプレゼンテーションを監査する際に役立ちます。

### **XML コンテンツと ItemId の取得・更新**

XML を UTF‑8 文字列として扱う場合は [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getXmlAsString) と [setXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlAsString) を、バイト データとして扱う場合は [getXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getXmlData) と [setXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlData) を使用します。

[CustomXmlPart.getItemId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getItemId) メソッドは、Office Open XML ドキュメント内でカスタム XML パーツを識別する UUID を返します。統合で新しい識別子が必要な場合は [setItemId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setItemId) を使用してください。

以下の例は、XML コンテンツと識別子を更新します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # 現在の XML をテキストとして読み取ります。
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # XML を UTF-8 文字列として更新します。
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData は同じ XML 内容を生バイトとして提供します。
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # 統合で必要な場合に識別子を置き換えます。
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

[setXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlAsString) または [setXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlData) を呼び出す際は、必ず有効で空でない XML を提供してください。アプリケーションが文字列中心であれば前者、バイト データ中心であれば後者を選択します。

### **カスタム XML パーツの削除**

Aspose.Slides ではカスタム XML データを削除する方法が複数用意されています。

- [CustomXmlPart.remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#remove) はプレゼンテーションからカスタム XML パーツを削除します。
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#remove) はコレクション内の特定のパーツを削除します。
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#removeAt) は指定したインデックス位置のパーツを削除します。
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#clear) は特定のコレクション内のすべてのパーツを削除します。

以下の例は、参照に基づいてプレゼンテーション レベルのカスタム XML パーツを 1 つ削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

既に [CustomXmlPart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/) のインスタンスを持っていて、コレクションではなくプレゼンテーション全体から削除したい場合は、[CustomXmlPart.remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#remove) を呼び出してください。

インデックスで削除することも可能です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除する必要がある場合は、[clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#clear) を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#clear) は選択されたコレクションにのみ影響します。たとえば、スライドのコレクションをクリアしてもプレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除したい場合は、[getAllCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAllCustomXmlParts) を列挙し、各パーツを個別に削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **リンクされているまたは共有されているカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のプレゼンテーション オブジェクトから参照されることがあります。たとえば、既存のファイルに複数のスライドやシェイプから同じカスタム XML パーツへのリレーションシップが含まれている場合です。

共有パーツは、複数の参照を持つ単一のデータオブジェクトとして扱う必要があります。

- [setXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlAsString)、[setXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlData)、または [setItemId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setItemId) で更新すると、基になるカスタム XML パーツが変更され、参照先すべてに反映されます。
- [getItemId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getItemId) は、オブジェクト レベルのコレクションを監査する際に同一パーツを識別するために使用できます。
- 特定の [getCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getCustomXmlParts) コレクションからパーツを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体から削除したい場合は [CustomXmlPart.remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#remove) を使用してください。
- 共有パーツを削除または置換する前に、他のスライドやシェイプがまだ参照しているかどうかをオブジェクト レベルのコレクションで確認してください。

[add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpartcollection/#add) のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成しますが、既存の [CustomXmlPart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/) を受け取ることはできません。したがって、共有リレーションシップは主に、すでに共有パーツを含むプレゼンテーションを読み込む際に発生します。

以下の例は、`ItemId` に基づいてプレゼンテーション、スライド、シェイプ レベルのコレクションを監査し、複数箇所から参照されているパーツを報告します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

この種の監査は、外部システムで作成されたプレゼンテーションのカスタム XML データを変更または削除する前に有用です。同一メタデータ パーツが複数のリレーションシップに関与している可能性があるためです。

## **タグの値取得**

スライドにおけるタグは、[DocumentProperties.getKeywords](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getKeywords) メソッドに対応します。以下のサンプルコードは、Aspose.Slides for Python via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) からタグの値を取得する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **プレゼンテーションへのタグ追加**

Aspose.Slides では、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの要素で構成されます。

- カスタム プロパティの名前（例: `MyTag`）
- カスタム プロパティの値（例: `My Tag Value`）

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加して目的を達成できます。たとえば、北米諸国のプレゼンテーションを分類したい場合は、NorthAmerican というタグを作成し、国名をその値として設定します。

以下のサンプルコードは、Aspose.Slides for Python via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) にタグを追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

タグは [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) に対しても設定できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

または個別の [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) に対して設定できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **制限事項**

[CustomData.getTags](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customdata/#getTags) コレクションを通じて追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム識別子はタグ付き PDF から取得できません。

**回避策**: オブジェクトの **代替テキスト**（例: [Shape.setAlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setAlternativeText) に `"MyId"` を設定）にカスタム識別子を保存できます。PDF にエクスポートした後、代替テキストが PDF タグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。タグコレクション（[tagcollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/)）は、すべてのキー‑バリュー ペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/#clear) 操作をサポートしています。

**コレクション全体を走査せずに、名前だけで単一のタグを削除する方法はありますか？**

[tag collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/) の [remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/#remove) を使用して、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全なリストを取得したいです。**

[tag collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tagcollection/#getNamesOfTags) を使用すると、すべてのタグ名が配列で返されます。

**保存場所に関係なくすべてのカスタム XML パーツを取得するにはどうすればよいですか？**

[Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getAllCustomXmlParts) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得してください。

**カスタム XML パーツを更新する際に、[getXmlAsString]/[setXmlAsString] と [getXmlData]/[setXmlData] のどちらを使用すべきですか？**

アプリケーションが UTF‑8 の XML テキストで動作する場合は [getXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getXmlAsString) と [setXmlAsString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlAsString) を使用してください。XML がすでにバイト配列として利用可能であるか、バイナリ指向の処理が便利な場合は [getXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#getXmlData) と [setXmlData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/customxmlpart/#setXmlData) を使用してください。どちらの表現も同じカスタム XML パーツのコンテンツを指します。