---
title: Python でシェイプレックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプレック
- 位置ロック
- 選択ロック
- サイズ変更ロック
- グループ化ロック
- PowerPoint
- PPTX
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、図形への変更を制限することで、意図されたレイアウトとコンテンツを維持できます。

この記事では、スライド上で図形がどのように構成されているか、そして PPTX プレゼンテーションで図形ロックを適用および解除する方法を説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオ フレーム、コネクタ、その他プレゼンテーションを構成する要素から構成されます。Aspose.Slides for Python via .NET では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスから派生したオブジェクトで表されます。

図形の種類に応じて異なるロックオプションが提供されます。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) クラスは図形ロックの基底クラスです。Aspose.Slides for Python via .NET は以下のロック クラスを提供します。

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) はコネクタ図形をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) はグラフィック オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) はグループ図形をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを列挙し、各サポート対象の図形に適切なロックを設定します。

## **保護の適用と解除**

互換性のあるプレゼンテーション エディタは図形ロックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメント レベルの書き込み保護は別の [presentation protection settings](/slides/ja/python-net/password-protected-presentation/) です。

### **PPTX 図形への保護の適用**

Aspose.Slides for Python via .NET はスライド上の図形を操作するために [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを提供します。

サンプルでは、オートシェイプに対して [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)、[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) を `True` に設定し、グループ図形、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に対して [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) を使用し、グループは [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) でグループ化を制限します。

サンプルは既存の PPTX プレゼンテーションを読み込み、各スライドの shape collection を走査してロックを設定し、制限が適用されたコピーを保存します。4 種類以外の図形は変更せずに残ります。ループはグループ内の子図形まで走査しません。

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **保護の解除**

図形ロックを解除するには、その値を `False` に設定します。以下のサンプルはロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **画像クロップの保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。サンプルは左側から 12%、右側から 8% をクロップし、画像フレームに [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) を設定します。このフラグにより以降のクロップが制限され、既存のクロップが保持されます。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` はクロップロックを `True` として保存します。PowerPoint で写真を選択すると **Crop** コマンドが無効になります。

### **図のグループ化を保持**

サンプルは矩形と矢印をグループ化し、グループ自体に [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) を設定して図の構成要素が一体化されたままになるようにします。グループの移動や構成要素の塗りの変更など、他の編集は引き続き可能です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` はアングループロックを `True` として保存します。PowerPoint で全体の図を選択すると **Ungroup** コマンドが無効になります。

### **既存の図形ロックのレポート**

テンプレートを確認するには開いて各図形のロック オブジェクトを読み取ります。すべてのフラグが無効の場合は [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) が `True` となり、少なくとも 1 つが有効な場合は `False` になります。グループとその子図形は別個のロック オブジェクトを持つため、グループにロックがなくても子図形を検査します。

このサンプルはオートシェイプ、画像フレーム、グループの移動、画像のクロップ、グループのアングループをチェックし、認識したフラグを報告するとともに、検査しない図形タイプをマークします。

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

たとえば `Sample.pptx` のスライド 1 に、アングループがロックされた `Layout` という名前のグループがあり、その中にクロップがロックされた `Photo` という画像があり、ロックのかかっていない `Free` という矩形があるとします。レポートは `Free` をスキップし、次の 2 行を出力します。

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

レポートはプレゼンテーションを変更せずに保存もしません。ドキュメント レベルの書き込み保護は別の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for Python via .NET を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、解除が必要なときは値を `False` に設定してください。

## **よくある質問**

**形状ロックとパスワード保護を同じプレゼンテーションで組み合わせられますか？**

はい。形状ロックは特定の編集操作を制限し、[password protection](/slides/ja/python-net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限します。両方を同じファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドには影響させない方法はありますか？**

はい。ロックは選択したスライドの図形にだけ適用してください。これにより他のスライドのロック設定は変更されません。

**グループ内の個別の図形にロックを適用するにはどうすればよいですか？**

グループの [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) コレクションを列挙し、各子図形に適切なロックを適用します。入れ子になったグループがある場合は、レポート例と同様の走査を繰り返してください。