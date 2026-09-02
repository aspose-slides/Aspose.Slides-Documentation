---
title: Python でプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/python-net/managing-tags-and-custom-data/
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
description: "Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションのタグとカスタム XML データを管理する方法を学びます。カスタム XML パーツの追加、読み取り、更新、監査、削除が含まれます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データを扱う方法を説明します。プレゼンテーション固有のデータはタグまたはカスタム XML パーツとして保存できます。タグは単純なキーと値の文字列ペアで、カスタム XML パーツは構造化されたメタデータやアプリケーション固有の XML ペイロードを格納できます。

Aspose.Slides は、プレゼンテーション、スライド、シェイプ レベルでカスタム XML パーツを追加、読み取り、更新、監査、削除するための API を提供します。カスタム XML パーツは、ドキュメント管理識別子、ワークフロー状態、コンプライアンス メタデータ、テンプレート バインディング データ、またはプレゼンテーション内のその他の構造化アプリケーション データなどの情報を格納する統合に便利です。

## **プレゼンテーション ファイル内のデータ格納**

PPTX ファイル（`.pptx` 拡張子のファイル）は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML は、プレゼンテーション コンテンツと関連データを格納するためのパッケージ構造とリレーションシップを定義します。

プレゼンテーションは、リレーションシップで接続された複数のパーツで構成されます。たとえば、スライド パーツは単一スライドのコンテンツを保持し、ISO/IEC 29500 で定義された他のパーツへの明示的なリレーションシップを持つことができます。

カスタム データはタグ（[TagCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/)）またはカスタム XML パーツ（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpartcollection/)）として格納できます。どちらも [`CustomData`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customdata/) クラスから利用できます。

{{% alert color="primary" %}}
タグはシンプルな文字列キーとバリューのペアを保存します。カスタム XML パーツは構造化された XML データを保存し、プレゼンテーション、スライド、またはシェイプに関連付けることができます。
{{% /alert %}}

## **カスタム XML パーツの操作**

[`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customdata/custom_xml_parts/) プロパティは、特定のプレゼンテーション オブジェクトに関連付けられたカスタム XML パーツのコレクションを返します。例:

- `presentation.custom_data.custom_xml_parts` はプレゼンテーション自体に関連付けられたカスタム XML パーツを含みます。
- `slide.custom_data.custom_xml_parts` は特定のスライドに関連付けられたカスタム XML パーツを含みます。
- `shape.custom_data.custom_xml_parts` は特定のシェイプに関連付けられたカスタム XML パーツを含みます。

プレゼンテーション全体のカスタム XML パーツを場所に関係なく取得したい場合は、[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/all_custom_xml_parts/) を使用します。

### **プレゼンテーションにカスタム XML パーツを追加する**

[`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpartcollection/add/) を使用して、XML データをカスタム XML パーツ コレクションに追加します。XML は有効かつ空でない必要があります。

次の例は、プレゼンテーション レベルのカスタム データ コレクションに構造化メタデータを追加します。

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add は自動的に識別子を割り当てます。必要な場合にのみ特定の GUID を設定してください。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` メソッドは、XML をバイト配列またはストリームとして受け取ることもでき、XML コンテンツがすでにバイナリ形式で利用可能な場合に便利です。

### **スライドまたはシェイプにカスタム XML パーツを追加する**

カスタム XML データは、プレゼンテーション全体ではなく特定のスライドまたはシェイプに関連付けることができます。これは、メタデータがテンプレート キー、外部レコード識別子、またはバインディング情報のように単一オブジェクトにのみ関係する場合に有用です。

次の例は、スライドに 1 つ、シェイプに 1 つのカスタム XML パーツを追加します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

パーツが追加されるレベルに応じて、どのオブジェクトの `custom_data.custom_xml_parts` コレクションにそのリレーションシップが含まれるかが決まります。プレゼンテーション レベルのデータは文書全体のメタデータに、スライド レベルのデータは特定スライドに属する情報に、シェイプ レベルのデータは個々のシェイプに結び付いたメタデータに適しています。

### **すべてのカスタム XML パーツを一覧化および監査する**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/all_custom_xml_parts/) を使用して、プレゼンテーションからすべてのカスタム XML パーツを取得します。各 [`CustomXmlPart`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/) は識別子、XML コンテンツ、関連付けられた名前空間スキーマを公開します。

次の例は、すべてのカスタム XML パーツとその名前空間スキーマを一覧表示します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/namespace_schemas/) は、カスタム XML パーツに関連付けられた XML スキーマを返します。この情報は、外部システムによって生成された XML を含むプレゼンテーションの監査に役立ちます。

### **XML コンテンツと ItemId の読み取りおよび更新**

[`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/xml_as_string/) を使用して UTF-8 文字列として XML を操作するか、[`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/xml_data/) を使用して生の XML バイトを操作します。両方のプロパティは読み取りと更新が可能です。

[`CustomXmlPart.item_id`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/item_id/) プロパティは、Office Open XML ドキュメント内でカスタム XML パーツを識別する GUID を保持します。統合が新しい識別子を必要とする場合は変更することもできます。

次の例は XML コンテンツと識別子を更新します。

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # 現在の XML をテキストとして読み取ります。
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # XML を UTF-8 文字列として更新します。
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data は同じ XML コンテンツを生バイトとして提供します。
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # 統合で必要な場合に識別子を置き換えます。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`xml_as_string` または `xml_data` に代入する際は、有効で空でない XML を提供してください。アプリケーションが文字列中心であれば `xml_as_string` を、バイト配列中心であれば `xml_data` を使用します。

### **カスタム XML パーツの削除**

Aspose.Slides にはカスタム XML データを削除する複数の方法があります:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpart/remove/) はプレゼンテーションからカスタム XML パーツを削除します。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpartcollection/remove/) は特定のパーツをコレクションから削除します。
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpartcollection/remove_at/) は指定されたインデックスのパーツを削除します。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/customxmlpartcollection/clear/) は特定のコレクションからすべてのパーツを削除します。

次の例は、プレゼンテーション レベルのカスタム XML パーツを参照で削除します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

既に `CustomXmlPart` インスタンスを持っていて、そのパーツ自体をプレゼンテーションから削除したい場合は `custom_xml_part.remove()` を呼び出します。

インデックスで項目を削除することもできます:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **コレクションからすべてのカスタム XML パーツをクリアする**

特定のプレゼンテーション オブジェクトに関連付けられたすべてのカスタム XML パーツを削除したいときは `clear` を使用します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` は選択されたコレクションのみに影響します。たとえば、スライドのコレクションをクリアしてもプレゼンテーション レベルやシェイプ レベルのコレクションはクリアされません。

プレゼンテーション内のすべてのカスタム XML パーツを削除するには、`all_custom_xml_parts` を列挙し各パーツを削除します:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **リンクまたは共有されたカスタム XML パーツの取り扱い**

Office Open XML プレゼンテーションでは、同一のカスタム XML パーツが複数のオブジェクトから参照されることがあります。たとえば、既存ファイルに複数のスライドやシェイプから同じカスタム XML パーツへのリレーションシップが含まれることがあります。

共有パーツは複数の参照を持つ単一のデータオブジェクトとして扱う必要があります:

- `xml_as_string`、`xml_data`、または `item_id` を更新すると基になるカスタム XML パーツが変更され、参照先すべてに反映されます。
- `item_id` はオブジェクト レベルのコレクションを監査するときに同一パーツを特定するために使用できます。
- 特定の `custom_xml_parts` コレクションからパーツを削除すると、そのコレクションからのみ削除されます。プレゼンテーション全体から削除したい場合は `CustomXmlPart.remove()` を使用してください。
- 共有パーツを削除または置換する前に、オブジェクト レベルのコレクションを調べ、他のスライドやシェイプがまだ参照していないか確認してください。

`add` のオーバーロードは XML コンテンツから新しいカスタム XML パーツを作成します。既存の `CustomXmlPart` を受け取ることはできません。そのため、共有リレーションシップは既に含まれているプレゼンテーションを読み込む際に最も一般的に遭遇します。

次の例は `item_id` によってプレゼンテーション、スライド、シェイプ レベルのコレクションを監査し、複数箇所から参照されているパーツを報告します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

この種の監査は、外部システムで作成されたプレゼンテーションのカスタム XML データを変更または削除する前に有用です。同一メタデータ パーツが複数のリレーションシップに参加している可能性があるためです。

## **タグの値の取得**

スライドでは、タグは `DocumentProperties.keywords` プロパティに相当します。次のサンプルコードは、Aspose.Slides for Python via .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のタグ値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides ではプレゼンテーションにタグを追加できます。タグは通常、次の 2 要素で構成されます:

- カスタム プロパティの名前（例: `MyTag`）
- カスタム プロパティの値（例: `My Tag Value`）

特定のルールやプロパティに基づいてプレゼンテーションを分類したい場合にタグを追加できます。たとえば、北米諸国のプレゼンテーションを分類したい場合は、North American タグを作成し、該当する国名を値として設定します。

次のサンプルコードは、Aspose.Slides for Python via .NET を使用して [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) にタグを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

タグは [Slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) に対しても設定できます:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

または個々の [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) に対しても設定できます:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **制限事項**

`custom_data.tags` コレクションを通じて追加されたタグは PowerPoint ファイルにのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム識別子はタグ付き PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例: `shape.alternative_text = "MyId"`）にカスタム識別子を保存できます。PDF にエクスポートすると、Alt Text が PDF タグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。タグ コレクション（[tag collection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/)）は、すべてのキーとバリューのペアを一度に削除する `clear`（[clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/clear/)）操作をサポートしています。

**コレクション全体を走査せずに名前で単一のタグを削除するにはどうすればよいですか？**

`TagCollection`（[TagCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/)）の `remove(name)`（[remove(name)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/remove/)）を使用してキーでタグを削除します。

**解析やフィルタリングのためにタグ名の完全なリストを取得するには？**

タグ コレクション（[tag collection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/)）の `get_names_of_tags`（[get_names_of_tags](https://reference.aspose.com/slides/ja/python-net/aspose.slides/tagcollection/get_names_of_tags/)）を使用すると、すべてのタグ名の配列が返されます。

**保存場所に関係なくすべてのカスタム XML パーツを取得するには？**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/all_custom_xml_parts/) を使用して、プレゼンテーション内のすべてのカスタム XML パーツを取得します。

**カスタム XML パーツを更新する際に `xml_as_string` と `xml_data` のどちらを使うべきですか？**

アプリケーションが UTF-8 の XML テキストで主に動作する場合は `xml_as_string` を使用します。XML がすでにバイト配列として利用可能であるか、バイナリ指向の処理が便利な場合は `xml_data` を使用します。どちらのプロパティも同一カスタム XML パーツの XML コンテンツを表します。