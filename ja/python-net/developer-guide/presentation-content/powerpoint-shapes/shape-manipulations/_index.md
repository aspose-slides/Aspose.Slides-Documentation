---
title: Pythonでプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/python-net/shape-manipulations/
keywords:
- PowerPoint の図形
- プレゼンテーションの図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- インタープ図形 ID の取得
- 図形の代替テキスト
- 図形の調整ポイント
- プリセット図形の調整
- 図形ジオメトリ
- 図形のレイアウト書式
- SVGとしての図形
- 図形をSVGへ
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、プレゼンテーションの図形を識別、調整、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、スライド上の図形を順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/) として表します。コレクションは図形を検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

このドキュメントはそのモデルに従います。まず、図形を確実に特定し、プリセットの調整ポイントを変更する方法を説明し、次に図形のクローン作成、削除、非表示、順序変更の方法を示します。最後のセクションでは、レイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の特定と検索**

コレクションインデックスは既知のファイルを処理する場合に便利ですが、安定した識別子ではありません。図形の追加、削除、順序変更によりインデックスは変わります。プレゼンテーションの作成・保守方法に合わせて識別子を選択してください。

- [Shape.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/name/) は開発者が管理するテンプレートで便利で、PowerPoint の選択ウィンドウで確認しやすいです。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を設定してください。
- [Shape.alternative_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/alternative_text/) は、アクセシビリティ記述や作者が付与したタグですでに図形を特定できる場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために書き換えられる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/office_interop_shape_id/) は読み取り専用で、スライド内で一意の識別子であり、PowerPoint のインターオップで使用される図形 ID に対応します。PowerPoint と連携する場合や、図形のライフタイム中に曖昧でない参照が必要な場合に使用してください。クローンまたは再作成された図形は別の図形となり、独自の ID が付与されます。

関連する [Shape.unique_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/unique_id/) プロパティはプレゼンテーション全体で有効ですが、アドイン向けで再割り当て可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

以下の例は `name` に対して完全一致で検索し、スライドスコープのインタープ ID を報告します。テンプレートに期待する図形が含まれていない場合、コードは間違ったオブジェクトで続行せずにその結果を報告します。

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

操作が特定の図形タイプに依存する場合は、型固有のメンバーを使用する前に型を確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) の場合にのみテキストと代替テキストを更新します。

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

## **プリセット図形の調整ポイントの特定と変更**

プリセットジオメトリ図形は、角丸サイズ、矢印比例、円弧角度などの機能を制御する調整ポイントを公開できます。これらは読み取り専用の [GeometryShape.adjustments](https://reference.aspose.com/slides/ja/python-net/aspose.slides/geometryshape/adjustments/) コレクションを介してアクセスします。コレクション自体は図形から提供されますが、各 [AdjustValue](https://reference.aspose.com/slides/ja/python-net/aspose.slides/adjustvalue/) が変更可能な値を保持しています。

固定インデックスだけに依存しないでください。調整項目を走査し、読み取り専用の [AdjustValue.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/adjustvalue/type/) プロパティを確認します。このプロパティの [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapeadjustmenttype/) 値が調整が何を制御するかを示します。読み取り専用の [AdjustValue.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/adjustvalue/name/) プロパティは追加の識別情報を提供し、同一のセマンティックタイプを持つ複数の調整がある場合に特に有用です。

調整の意味に合った value プロパティを使用してください。

| 調整タイプ | 用途 | 変更する値 |
|---|---|---|
| `CORNER_SIZE` | 角丸のサイズ | [raw_value](https://reference.aspose.com/slides/ja/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | 矢印の尾部の太さ | `raw_value` |
| `ARROWHEAD_LENGTH` | 矢尻の長さ | `raw_value` |
| `ARROWHEAD_WIDTH` | 矢尻の幅 | `raw_value` |
| `START_ANGLE` | 扇形または円弧の開始角度 | [angle_value](https://reference.aspose.com/slides/ja/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | 扇形または円弧の終了角度 | `angle_value` |

`type` と `name` は代入できません。`raw_value` はプリセット固有のジオメトリ単位での読み書き可能な整数で、`angle_value` は度単位の読み書き可能な角度です。調整項目の数・順序・意味・有効範囲は [GeometryShape.shape_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/geometryshape/shape_type/) に依存します。あるプリセットで有効な値が別のプリセットでは無効または別の効果になることがあります。

`type` が `ShapeAdjustmentType.CUSTOM` の場合、API は標準的なセマンティック意味を認識しません。`name`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が分かっている場合以外は調整を変更しないでください。認識できるタイプであっても、同一タイプが複数回出現するかどうかを確認してから値を選択してください。[Connector](/slides/ja/python-net/connector/) 記事では、コネクタの曲げ調整でこの状況が示されています。

以下の完全例は、3 つのプリセット図形のデフォルトバージョンと変更バージョンを作成します。すべての調整項目を走査し、`name` と `type` を報告し、サイズ関連の値は `raw_value`、角度は `angle_value` で変更し、結果を保存します。左列はデフォルトジオメトリを保持し、右列は調整された角丸長方形、四方向矢印、円弧を示します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトと調整された図形列のヘッダーを追加します。
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

値を変更する前にセマンティックタイプを確認することで、コードは意図を明示的に示し、異なるプリセット図形間で同一インデックスが同じ意味を持つと仮定することを防げます。

## **ShapeCollection の変更**

add、clone、remove、reorder メソッドはコレクションに対して即座に作用します。操作により図形の数や順序が変わる場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_clone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[ShapeCollection.insert_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/insert_clone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも行います。

この例は目的スライドを作成し、ラベル付き長方形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンを変更しても元の図形は影響を受けません。

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

クローンは図形の内容と書式、名前、代替テキストをコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を付与してください。複雑な図形が使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目となり、新しい図形 ID を持ちます。

### **図形の削除**

[ShapeCollection.remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/remove/) は特定の図形オブジェクトをコレクションから削除します。インデックスで走査しながら複数の一致項目を削除する場合、残りのインデックスが有効であり続けるように末尾から逆方向に走査してください。

この例は指定された名前を持つすべての図形を削除します。固定のコレクション項目ではなく `slide.shapes[index]` を読み取り、不要なキャストも行っていません。

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

削除後は図形数と以降の図形インデックスが変わります。影響を受けない図形への参照は保存したインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象のオブジェクトを参照している可能性があることに留意してください。表示可能な図形を削除すると、スライドの見た目以外にも影響が出ることがあります。

### **図形の非表示**

[Shape.hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/hidden/) を `True` に設定すると、図形はコレクションに残ったまま通常のスライドショーには表示されません。インデックス、書式、内容はコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

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

非表示は削除やセキュリティとは異なります。ユーザーやコードが図形を発見して再表示することができ、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う図形はコレクション順に描画されます。[ShapeCollection.reorder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/reorder/) は既存の図形をクローンせずに目的インデックスへ移動します。インデックス `0` が背面、`len(slide.shapes) - 1` が前面です。

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

長方形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動すると前面に配置されます。すべての関連図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上の図形を検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個の図形コレクションを持ちます。レイアウトコレクション内の図形は、同じ位置にある通常スライドの図形と同一オブジェクトではありません。レイアウトが提供する書式を理解または変更する必要があるときは、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [Shape.fill_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/fill_format/) と [Shape.line_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/line_format/) を、すべてが `AutoShape` であると仮定せずに取得します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがそのオブジェクトを継承しているかローカルで上書きしているかを確認し、レイアウトを使用しているすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[Shape.write_as_svg](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/write_as_svg/) は単一図形のレンダリング結果をストリームに書き込みます。結果には図形そのものだけが含まれ、スライド全体の背景や隣接する図形は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式やフォント、画像などのリソースに依存します。全体構成が必要な場合は、個別図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、クローズする必要があります。

## **図形の配置**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/align_shapes/) のオーバーロードは、すべての図形または選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または配置モードを指定します。`align_to_slide` を `True` に設定するとスライドのエッジに合わせ、`False` にすると選択した図形同士の相対位置で整列します。

この例は 3 つの図形をスライド上部エッジに揃えます。現在のインデックスは整列直前に取得されます。

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

整列は位置を変更し、Z オーダーは変わりません。相対整列は通常少なくとも 2 つの図形が必要で、水平または垂直の均等配置は間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `flip_h` と `flip_v` の値は [NullableBool](https://reference.aspose.com/slides/ja/python-net/aspose.slides/nullablebool/) を使用し、`TRUE` でフリップ有効、`FALSE` で無効、`NOT_DEFINED` で未設定または既定状態を保持します。

以下の入力プレゼンテーションはフリップされていない図形を 1 つ含みます。

![The shape before flipping](shape_to_be_flipped.png)

この例は他のすべてのフレーム値はそのままにし、フリップ設定だけを置き換えます。これは新しい [Shape.frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/frame/) を代入するとフレーム全体が置き換わるため重要です。

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

保存された図形は水平・垂直に鏡像化され、位置、サイズ、回転は保持されます。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

コレクションが変更されない短期間の処理に限って使用してください。テンプレートが作者管理の場合は検証済みの `name` または `alternative_text` を、スライドスコープのインタープ操作が必要な場合は `office_interop_shape_id` を推奨します。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、再配置、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`add_clone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面です。初期インデックスを指定したい場合は `insert_clone` を使用するか、すべての図形を追加した後に `reorder` で位置を調整してください。

**プリセット図形の調整を固定インデックスで特定しても良いですか？**

正確なプリセットとコレクション構成を検証した場合に限り可能です。`GeometryShape.adjustments` を走査し `AdjustValue.type` を確認することを推奨します。同一のセマンティックタイプが複数出現する場合は追加情報として `AdjustValue.name` を利用してください。