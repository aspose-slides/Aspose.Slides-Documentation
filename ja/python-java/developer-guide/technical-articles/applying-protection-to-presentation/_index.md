---
title: Python で形状ロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/python-java/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- 形状ロック
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
description: "Aspose.Slides for Python via Java を使用して PPTX プレゼンテーションの形状をロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、形状への変更を制限することで、意図したレイアウトやコンテンツを保持できます。

この記事では、スライド上での形状の構成方法と、PPTX プレゼンテーション内で形状ロックを適用および削除する方法について説明します。これらのロックにより、個々の形状に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された形状、画像フレーム、ビデオフレーム、コネクタ、およびプレゼンテーションを構成するその他の要素で構成されます。Aspose.Slides for Python via Java では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) クラスを継承したオブジェクトとして表されます。

形状の種類に応じて異なるロックオプションが提供されます。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) クラスは形状ロックの基底クラスです。Aspose.Slides for Python via Java は次のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) オートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) コネクタ形状をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) グラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) グループ形状をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 全体にロックを適用するには、スライドを反復処理し、サポートされている各形状に適切なロックを設定します。

## **保護の適用と削除**

形状ロックは、形状の選択、移動、サイズ変更などの操作を制限します。プレゼンテーション全体が編集できなくなるわけではありません。

### **PPTX 形状への保護の適用**

Aspose.Slides for Python via Java は、スライド上の形状を操作するために [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) クラスを提供します。

この例では、オートシェイプに対して `True` を指定して [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出します。また、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) を使用してグループ化を制限します。

この例では既存の PPTX プレゼンテーションを読み込み、各スライドの形状コレクション内の形状をチェックし、これらの制限が適用されたコピーを保存します。取り扱い対象の 4 種類以外の形状は変更されません。ループはグループ内の子形状を走査しません。

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

形状ロックを解除するには、その値を `False` に設定します。以下の例では、形状ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) に `False` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。その他のロック設定は変更されません。

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

### **結論**

Aspose.Slides for Python via Java を使用すると、個々の形状に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各形状タイプがサポートするロックを選択し、制限を解除したい場合はその値を `False` に設定してください。

## **FAQ**

**同じプレゼンテーションで形状ロックとパスワード保護を組み合わせることはできますか？**

はい。形状ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/python-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドに影響を与えないようにできますか？**

はい。選択したスライドの形状にのみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個々の形状にロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを反復処理し、各子形状に適切なロックを適用します。ネストしたグループがある場合も同様に繰り返します。上記の例はスライドの形状コレクションのみを処理しているため、個々のグループメンバーへのロックは設定されません。