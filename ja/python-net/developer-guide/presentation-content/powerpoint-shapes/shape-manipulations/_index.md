---
title: Pythonでプレゼンテーションの図形を管理
linktitle: 図形操作
type: docs
weight: 40
url: /ja/python-net/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形順序の変更
- インターオプ図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- SVG 形式の図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、プレゼンテーションの図形を識別、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、スライド上の図形を順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/) として表します。このコレクションは、図形の検索・変更が行える場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

この記事はそのモデルに従います。まず図形を確実に識別する方法を説明し、次に図形のクローン作成、削除、非表示、並び替えのやり方を示します。最終セクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について説明します。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形を追加、削除、並び替えするとインデックスが変わる可能性があります。プレゼンテーションの作成・管理方法に合わせて識別子を選択してください：

- [Shape.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/name/) は開発者が管理するテンプレートに便利で、PowerPoint の選択ウィンドウで確認しやすいです。名前は編集可能で、一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [Shape.alternative_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/alternative_text/) は、アクセシビリティの説明や作者が付与したタグで図形を識別できる場合に便利です。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えられることがあり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして静かに再利用しないでください。
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/office_interop_shape_id/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint のインターオプで使用される形状 ID に対応しています。PowerPoint との統合や、図形の存続期間中に曖昧でない参照が必要な場合に使用してください。クローンや再作成された図形は別の図形となり、独自の ID を持ちます。

関連する [Shape.unique_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/unique_id/) プロパティはプレゼンテーション単位のスコープを持ちますが、アドイン向けに設計されており再割り当てが可能です。永続的な外部キーとして扱わないでください。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

以下の例は `name` で完全一致検索を行い、スライドスコープのインターオプ ID を報告します。テンプレートに期待する図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで処理を続行しません。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

操作が特定の図形タイプに限定される場合は、型固有のメンバーを使用する前にタイプを確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) の場合にのみテキストと代替テキストを更新します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **図形コレクションの変更**

add、clone、remove、reorder メソッドはコレクションに対して即座に作用します。操作により図形の数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_clone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[ShapeCollection.insert_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/insert_clone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標を受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズ変更も行えます。

この例は宛先スライドを作成し、ラベル付き長方形を前方にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンに対する変更は元の図形を変更しません。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

クローン作成は図形の内容と書式をコピーし、名前や代替テキストも含まれます。これらの値を一意にする必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑な図形が使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しい図形 ID を持ちます。

### **図形の削除**

[ShapeCollection.remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/remove/) は特定の図形オブジェクトをコレクションから削除します。インデックス付き反復中に複数の一致を削除する場合は、後方から走査して残りのインデックスが有効なままになるようにしてください。

この例は指定された名前を持つすべての図形を削除します。固定されたコレクション項目ではなく `slide.shapes[index]` を読み取り、図形を不要にキャストしません。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

削除後は図形数と後続の図形インデックスが変わります。影響を受けない図形への参照は、保存したインデックスよりも信頼性が高くなります。また、コネクタやアニメーションなど、削除対象オブジェクトを参照しているプレゼンテーション機能も考慮してください。可視図形を削除すると、スライドの見た目以上の変化が生じることがあります。

### **図形の非表示**

[Shape.hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/hidden/) を `True` に設定すると、図形はコレクションに残りますが、通常のスライドショーには表示されません。インデックス、書式、内容はコードから引き続き利用可能なので、後で復元できるオプション要素の非表示に適しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

非表示は削除やセキュリティではありません。ユーザーやコードによってオブジェクトを検出し、再表示することができ、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う図形はコレクションの順序で描画されます。[ShapeCollection.reorder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/reorder/) は既存の図形をクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`len(slide.shapes) - 1` が前面です。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

長方形は最初に作成され、最初は楕円の背面に配置されます。最後のインデックスに移動させると前面に来ます。関連する図形をすべて追加またはクローンした後で Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の図形コレクションを持ちます。レイアウトコレクション内の図形は、通常スライド上の同じ位置にある図形とは別のオブジェクトです。レイアウトが提供する書式設定を理解もしくは変更する必要がある場合は、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [Shape.fill_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/fill_format/) と [Shape.line_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/line_format/) を読み取り、すべての図形が `AutoShape` であると仮定していません。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

レイアウトを編集すると、それを使用している複数のスライドに影響を及ぼす可能性があります。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを確認し、そのレイアウトを使用するすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[Shape.write_as_svg](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/write_as_svg/) は単一の図形の描画内容をストリームに書き込みます。結果にはその図形のみが含まれ、スライド全体の背景や隣接する図形は含まれません。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式設定やフォント、画像といったリソースに依存します。全体の構成が必要な場合は、個々の図形ではなくスライド全体をエクスポートしてください。ストリームの所有権は呼び出し側にあり、使用後に閉じる必要があります。

## **図形の配置**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/align_shapes/) のオーバーロードは、すべての図形または選択したコレクションインデックスを配置します。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または配置モードを指定します。`align_to_slide` を `True` に設定するとスライドのエッジに合わせ、`False` に設定すると選択した図形同士の相対位置で配置します。

この例は 3 つの図形をスライドの上端に揃えます。現在のインデックスは配置直前に取得されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

配置は位置を変更しますが、Z オーダーは変わりません。相対配置には通常最低 2 つの図形が必要で、水平または垂直の分布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `flip_h` と `flip_v` の値は [NullableBool](https://reference.aspose.com/slides/ja/python-net/aspose.slides/nullablebool/) を使用します：`TRUE` はフリップを有効にし、`FALSE` は無効にし、`NOT_DEFINED` は未指定またはデフォルト状態を保ちます。

以下の入力プレゼンテーションには、フリップされていない図形が 1 つ含まれています。

![フリップ前の図形](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、フリップ設定の 2 つだけを置き換えます。新しい [Shape.frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/frame/) を割り当てるとフレーム全体が置き換えられるため、重要です。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転は保持されます。

![フリップ後の図形](flipped_shape.png)

## **よくある質問**

**コレクションインデックスを図形の識別子として使用すべきですか？**

コレクションがインデックス使用前に変更されない短期的な処理の場合にのみ使用してください。作成されたテンプレートでは検証済みの `name` または `alternative_text` の慣例を、スライドスコープのインターオプ作業では `office_interop_shape_id` を使用することを推奨します。

**図形を非表示にすると Z オーダーから削除されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残ります。検索、並び替え、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`add_clone` はクローンをコレクションの末尾に追加するため、Z オーダーの前面になります。初期インデックスを指定したい場合は `insert_clone` を使用するか、すべての図形を追加した後に `reorder` してください。