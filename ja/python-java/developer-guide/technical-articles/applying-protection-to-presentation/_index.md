---
title: Python でシェイプレックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/python-java/applying-protection-to-presentation/
keywords:
- 編集の防止
- 編集からの保護
- シェイプのロック
- 位置のロック
- 選択のロック
- サイズ変更のロック
- グループ化のロック
- PowerPoint
- PPTX
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、図形の変更を制限することで、意図されたレイアウトとコンテンツを保護できます。

この記事では、スライド上の図形の構成方法と、PPTX プレゼンテーションで図形ロックを適用および削除する方法を説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素で構成されます。Aspose.Slides for Python via Java では、スライド上の各要素は[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)クラスを継承したオブジェクトとして表されます。

異なる図形タイプは異なるロックオプションを提供します。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/)クラスは図形ロックの基底クラスです。Aspose.Slides for Python via Java は以下のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) はコネクタ形状をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) はグラフィックオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) はグループ形状をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

複数の[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)にロックを適用するには、スライドを順に走査し、各サポートされている図形に適切なロックを設定します。

## **保護の適用と削除**

対応するプレゼンテーションエディタは図形ロックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメントレベルの書き込み保護は、別の[プレゼンテーション保護設定](/slides/ja/python-java/password-protected-presentation/)です。

### **PPTX 図形への保護の適用**

Aspose.Slides for Python via Java はスライド上の図形を操作するために[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)クラスを提供します。

この例では、オートシェイプに対して `True` を指定して[setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) および[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked)を呼び出し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために[setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove)を使用し、グループはグループ化を制限するために[setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)を使用します。

この例では既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内の図形をチェックし、これらの制限が適用されたコピーを保存します。取り扱われる4つのタイプ以外の図形は変更されません。ループはグループ内の子図形を走査しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **保護の削除**

図形ロックを削除するには、その値を `False` に設定します。以下の例では、図形ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)、および[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/)を通じて選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)に `False` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **画像のクロップを保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例では左側を 12%、右側を 8% クロップし、[setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) を `True` で呼び出してクロップを保持します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`PictureLocked.pptx` では、写真を選択すると PowerPoint が **Crop** コマンドを無効にします。

### **図表をグループ化したまま保持**

この例では矩形と矢印をグループ化し、[setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) を `True` で呼び出して2つの図形を一緒に保持します。グループを移動したり、コンポーネントの塗りつぶしを変更したりすることは依然可能です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`DiagramLocked.pptx` では、全体の図表を選択すると PowerPoint が **Ungroup** コマンドを無効にします。

### **既存の図形ロックのレポート**

テンプレートを確認するには、テンプレートを開き、各図形のロックオブジェクトを読み取ります。[getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) メソッドは、オブジェクト上のすべてのフラグが無効な場合に `True`、少なくとも1つが有効な場合に `False` を返します。グループとその子要素は別々のロックオブジェクトを持つため、グループにロックがなくても子要素を検査してください。

この例では、オートシェイプ、画像フレーム、グループの移動をチェックします。また、画像のクロップとグループのアン​グループ化も確認します。レポートは認識した有効なフラグを一覧表示し、検査しなかった図形タイプにはマークを付けます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

`Sample.pptx` のスライド1に、アン​グループ化がロックされた `Layout` という名前のグループがあり、その内部にクロップがロックされた `Photo` という画像があり、ロックされていない矩形 `Free` があるとします。レポートは `Free` をスキップし、次の2行を出力します：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートは保存された図形レベルの編集フラグを変更したりプレゼンテーションを保存したりせずに読み取ります。ドキュメントレベルの書き込み保護は別の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for Python via Java を使用すると、個々の図形に対する特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、制限を解除する必要がある場合はその値を `False` に設定してください。

## **よくある質問**

**プレゼンテーションで図形ロックとパスワード保護を同時に使用できますか？**

はい。図形ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/python-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけの編集を制限し、他のスライドに影響を与えませんか？**

はい。選択したスライドの図形にのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**グループ内の個々の図形にロックを適用するにはどうすればよいですか？**

グループの[getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)メソッドが返すコレクションを走査し、各子図形に適切なロックを適用します。入れ子になったグループがある場合も同様に、レポート例の走査方法に従って繰り返します。