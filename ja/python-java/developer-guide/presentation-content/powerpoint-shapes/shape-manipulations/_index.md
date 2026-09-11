---
title: Python via Java でプレゼンテーションシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/python-java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーションシェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- インタープリットシェイプ ID の取得
- シェイプ代替テキスト
- シェイプ調整ポイント
- プリセットシェイプ調整
- シェイプジオメトリ
- シェイプレイアウト書式
- シェイプの SVG 変換
- シェイプを SVG にエクスポート
- シェイプの配置
- シェイプのフリップ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションシェイプの識別、調整、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップ方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java は、スライド上のシェイプを順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) として表します。このコレクションはシェイプの取得・変更場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面のシェイプで、最後のインデックスが最前面のシェイプになります。

この記事はこのモデルに従って解説します。まずシェイプを確実に識別し、プリセットの調整ポイントを変更する方法を説明し、続いてシェイプのクローン作成、削除、非表示、順序変更の手順を示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について扱います。各例は独立しているため、必要な操作だけを使用できます。

## **シェイプの識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。シェイプの追加・削除・再順序付けによりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getName) は開発者が管理するテンプレートに有用で、PowerPoint の選択ペインでも確認しやすいです。名前は編集可能で一意である保証はないため、コードで使用する場合は命名規則を設けてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) はアクセシビリティ説明や作者が付与したタグが既にシェイプを識別している場合に便利です。ユーザーに見えるためローカライズや書き換えが行われる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getOfficeInteropShapeId) は読み取り専用の識別子で、スライド内で一意であり PowerPoint のインタープリットで使用されるシェイプ ID に対応します。PowerPoint と連携する場合や、シェイプの存続期間中に曖昧でない参照が必要な場合に使用してください。クローンや再作成されたシェイプは別のシェイプとなり、独自の ID が付与されます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getUniqueId) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があります。永続的な外部キーとして扱わないでください。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプがまだ存在するか検証してください。

以下の例は名前で完全一致検索し、スライドスコープのインタープリット ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードは結果を報告し、誤ったオブジェクトで続行しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

操作がシェイプの種類に依存する場合は、型固有のメンバーを使用する前にタイプを確認してください。この例は、対象が [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) の場合にのみテキストと代替テキストを更新します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **プリセットシェイプ調整の識別と変更**

プリセットジオメトリ シェイプは、角のサイズ、矢印の比率、弧の角度などを制御する調整ポイントを公開することがあります。これらは読み取り専用の [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/geometryshape/#getAdjustments) コレクションを介してアクセスします。コレクション自体はシェイプが提供しますが、各 [AdjustValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/) は変更可能な値を保持しています。

固定インデックスのみに依存しないでください。調整項目を走査し、読み取り専用の [getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) メソッドで返される [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/) を確認します。この型は調整が何を制御するかを示します。読み取り専用の [getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) メソッドは追加の識別情報を提供し、同一の意味タイプが複数ある場合に特に有用です。

調整の意味に合ったメソッドを使用してください。

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | 丸み角のサイズ | [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | 矢尻の太さ | [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | 矢じりの長さ | [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | 矢じりの幅 | [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | パイまたは円弧の開始角度 | [setAngleValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | パイまたは円弧の終了角度 | [setAngleValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) と [getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) は読み取り専用情報を返します。[getRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getRawValue) と [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) はプリセット固有のジオメトリ単位で整数を扱い、[getAngleValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getAngleValue) と [setAngleValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setAngleValue) は度単位の角度を扱います。調整項目の数・順序・意味・有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/geometryshape/#getShapeType) に依存します。あるプリセットで有効な値が別のプリセットでは無効または別の効果を持つことがあります。

[getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) が [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#Custom) を返す場合、API は標準的な意味を認識していません。[getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName)、プリセットタイプ、既存値を確認し、期待する意味と範囲が分かっている場合以外は調整を変更しないでください。認識されたタイプでも、同一タイプが複数存在するかどうかを確認してから値を選択してください。[Connector](/slides/ja/python-java/connector/) 記事ではコネクタの曲げ調整でこの状況が示されています。

以下の完全な例は、3 種類のプリセットシェイプのデフォルト版と変更版を作成します。すべての調整を走査し、名前とタイプを報告し、サイズ関連の値は [setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) で、角度は [setAngleValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setAngleValue) で変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整された角丸矩形、四方向矢印、パイです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # デフォルトと調整済みシェイプ列のヘッダーを追加します。
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

調整の意味タイプを確認してから値を変更することで、コードの意図が明確になり、異なるプリセットシェイプ間で同一インデックスが同じ意味を持つと仮定するリスクを回避できます。

## **シェイプコレクションの変更**

add、clone、remove、reorder メソッドはコレクションに即座に反映されます。操作によりシェイプ数や順序が変わった場合、事前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン**

[addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addClone) は独立したコピーを作成し、対象コレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#insertClone) もコピーを作りますが、指定した Z オーダーインデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズ変更も行います。

例では、宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入しています。いずれかのクローンを変更しても元のシェイプには影響しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

クローンはシェイプのコンテンツと書式（名前や代替テキストを含む）をコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を付与してください。複雑なシェイプが使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新たなシェイプ ID を持ちます。

### **シェイプの削除**

[remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#remove) は特定のシェイプオブジェクトをコレクションから削除します。インデックス走査中に複数の一致を削除する場合は、末尾から逆順に走査して残りのインデックスが有効なままになるようにしてください。

この例は、指定された名前を持つすべてのシェイプを削除します。固定のコレクション項目ではなく、現在のインデックスからシェイプを取得し、不要なキャストも行っていません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

削除後はシェイプ数と後続シェイプのインデックスが変わります。影響を受けないシェイプへの参照は、保存したインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している可能性があることに留意してください。表示シェイプを削除すると、スライドの外観以上の影響が出ることがあります。

### **シェイプの非表示**

[Hidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setHidden) を `True` に設定すると、シェイプはコレクション内に残りますが、通常のスライドショーでは表示されなくなります。インデックス、書式、コンテンツはコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

非表示は削除やセキュリティとは異なります。ユーザーやコードによって再度表示状態に変更でき、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合うシェイプはコレクション順に描画されます。[reorder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#reorder) は既存シェイプをクローンせずに指定インデックスへ移動します。インデックス `0` が背面、コレクション [size](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#size) - 1 が前面です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例では矩形を最初に作成し、最初は楕円の背面にあります。最終インデックスへ移動すると前面に配置されます。すべての関連シェイプを追加またはクローンした後に Z オーダーを確定してください。これらの操作はコレクションに新しい項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上のシェイプの検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクション内のシェイプは、通常スライド上の同位置シェイプとは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウトシェイプを検査してください。

次の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getFillFormat) と [LineFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getLineFormat) を取得しますが、すべてのシェイプが [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) であると仮定していません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響します。レイアウトシェイプを変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを確認し、レイアウトを使用しているすべてのスライドでテストしてください。

## **シェイプを SVG にエクスポート**

[Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) の `writeAsSvg` メソッドは、単一シェイプのレンダリング結果をストリームに書き込みます。結果にはシェイプだけが含まれ、スライド全体の背景や隣接シェイプは含まれません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式やフォント・画像といったリソースに依存します。スライド全体が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる責任があります。

## **シェイプの配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#alignShapes) のオーバーロードは、すべてのシェイプまたは選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapesalignmenttype/) で辺、中心線、配置モードを指定します。`align_to_slide` を `True` にするとスライドの端に合わせ、`False` にすると選択シェイプ同士の相対位置で整列します。

この例は 3 つのシェイプをスライド上部に整列させます。返されたシェイプ参照は、整列直前に現在のインデックスに変換されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

配置は位置を変更し、Z オーダーは変わりません。相対配置には通常最低 2 つのシェイプが必要で、水平または垂直の等間隔配置には間隔を定義できるだけのシェイプ数が必要です。メソッド呼び出し前にコレクションを変更した場合は、インデックスを再計算してください。

## **シェイプのフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その [getFlipH](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeframe/#getFlipH) と [getFlipV](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeframe/#getFlipV) の値は [NullableBool](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/) を使用します：`True` でフリップ、`False` で無効、`NotDefined` は未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションには、フリップされていないシェイプが 1 つ含まれています。

![フリップ前のシェイプ](shape_to_be_flipped.png)

例では、他のフレーム値はすべて保持し、フリップ設定だけを置き換えています。これは新しい [Frame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setFrame) を設定するとフレーム全体が上書きされるため重要です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存されたシェイプは水平・垂直に鏡像化されますが、位置・サイズ・回転はそのままです。

![フリップ後のシェイプ](flipped_shape.png)

## **FAQ**

**コレクションインデックスをシェイプの識別子として使用すべきですか？**

インデックスが操作中に変わらない、短時間の処理のみで使用する場合に限ります。作成されたテンプレートでは検証済みの [Name](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getName) または [AlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) を使用することを推奨し、スライドスコープのインタープリット作業では [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getOfficeInteropShapeId) を使用してください。

**シェイプを非表示にすると Z オーダーから除外されますか？**

いいえ。非表示シェイプは同じインデックスでコレクションに残り、検索、再配置、編集、再表示が可能です。

**クローンしたシェイプが別のシェイプより前面に表示されたのはなぜですか？**

[addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addClone) はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面です。初期インデックスを指定したい場合は [insertClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#insertClone) を使用するか、すべてのシェイプ追加後に [reorder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#reorder) で位置を調整してください。

**固定インデックスでプリセットシェイプの調整を識別できますか？**

正確なプリセットとコレクション配置を検証した場合に限り可能です。できるだけ [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/geometryshape/#getAdjustments) を走査し、[AdjustValue.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) を確認してください。同一の意味タイプが複数ある場合は、[AdjustValue.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) も併せて使用してください。