---
title: Python で Shape Locks を使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/python-java/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- 図形ロック
- 位置ロック
- 選択ロック
- サイズ変更ロック
- グループ化ロック
- PowerPoint
- PPTX
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PPTX プレゼンテーションの図形をロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、図形への変更を制限することで、意図されたレイアウトとコンテンツを保持できます。

本記事では、スライド上の図形の構成方法と、PPTX プレゼンテーションで図形ロックを適用および削除する方法について説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素で構成されています。Aspose.Slides for Python via Java では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) クラスを継承したオブジェクトで表されます。

異なる図形タイプは異なるロックオプションを提供します。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) クラスは図形ロックの基底クラスです。Aspose.Slides for Python via Java は以下のロッククラスを提供します。

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) はコネクタ図形をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) はグループ図形をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

ロックを [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 全体に適用するには、スライドを反復処理し、サポートされている各図形に適切なロックを設定します。

## **保護の適用と解除**

互換性のあるプレゼンテーションエディタは図形ロックを使用して個々の編集操作を制限します。ファイル暗号化および文書レベルの書き込み保護は、別の [プレゼンテーション保護設定](/slides/ja/python-java/password-protected-presentation/) です。

### **PPTX 図形への保護の適用**

Aspose.Slides for Python via Java は、スライド上の図形を操作するための [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) クラスを提供します。

この例では、オートシェイプに対して `True` を指定して [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出し、グループ図形、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) でグループ化を制限します。

この例では既存の PPTX プレゼンテーションをロードし、各スライドのシェイプコレクション内の図形を確認し、これらの制限が適用されたコピーを保存します。扱われる4つのタイプ以外の図形は変更されません。ループはグループ内の子図形を走査しません。

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

### **保護の解除**

図形ロックを解除するには、その値を `False` に設定します。以下の例では、図形ロックが設定されたプレゼンテーションをロードし、[AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) を介して選択、移動、サイズ変更の制限をクリアします。また、`False` を [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) に渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例では左から12%、右から8% をクロップし、[setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) に `True` を渡してクロップを保持します。

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

### **ダイアグラムをグループ化したまま保持**

この例では、長方形と矢印をグループ化し、[setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) に `True` を渡すことで2つの図形を一緒に保ちます。グループを移動したり、構成要素の塗りつぶしを変更したりすることは可能です。

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

`DiagramLocked.pptx` では、全体のダイアグラムを選択すると PowerPoint が **Ungroup** コマンドを無効にします。

### **結論**

Aspose.Slides for Python via Java を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、制限を解除する必要がある場合はその値を `False` に設定してください。

## **よくある質問**

**Can I combine shape locks and password protection in the same presentation?**  
はい。図形ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/python-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**Can I restrict editing on specific slides without affecting others?**  
はい。選択したスライドの図形にのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**How can I apply locks to individual shapes inside a group?**  
グループの [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを反復処理し、各子図形に適切なロックを適用します。ネストされたグループについても同様に繰り返します。上記の例はスライドのシェイプコレクションのみを処理しているため、個々のグループメンバーにはロックを設定していません。