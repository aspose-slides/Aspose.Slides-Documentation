---
title: Pythonでシェイプロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限する
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
keywords:
- 編集の防止
- 編集から保護
- シェイプをロック
- 位置をロック
- 選択をロック
- サイズ変更をロック
- グループ化をロック
- PowerPoint
- PPTX
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを作成、更新、保存することです。これらは自動化されたワークフローの一部として利用されます。ユーザーがプレゼンテーションを受け取る際に、シェイプへの変更を制限することで、意図したレイアウトやコンテンツを保護できます。

本記事では、スライド上のシェイプの配置方法と、PPTX プレゼンテーションでシェイプロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオ フレーム、コネクタ、その他の要素から構成されます。Aspose.Slides for Python via .NET では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスから継承されたオブジェクトとして表現されます。

シェイプの種類に応じて異なるロック オプションが提供されます。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) クラスはシェイプロックの基底クラスです。Aspose.Slides for Python via .NET は以下のロック クラスを提供します。

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) オートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) コネクタ シェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) グラフィカル オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) グループ シェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを順に走査し、各サポートされているシェイプに適切なロックを設定します。

## **保護の適用と削除**

互換性のあるプレゼンテーション エディタはシェイプ ロックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメント レベルの書き込み保護は、別の[プレゼンテーション保護設定](/slides/ja/python-net/password-protected-presentation/)です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Python via .NET は、スライド上のシェイプを操作するための [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを提供します。

この例では、オートシェイプに対して [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)、[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) を `True` に設定し、グループ シェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) を使用し、グループは [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) でグループ化を制限します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクション内のシェイプをチェックし、これらの制限を適用したコピーを保存します。対象外の 4 種類以外のシェイプは変更されません。ループはグループ内の子シェイプを走査しません。

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

### **保護の削除**

シェイプ ロックを削除するには、対応する値を `False` に設定します。以下の例はロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) を介して選択、移動、およびサイズ変更の制限をクリアします。また、[GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) もクリアし、プレゼンテーションのコピーを保存します。その他のロック設定はそのまま残ります。

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

### **画像のトリミングを保持**

作業ディレクトリに `photo.jpg` という名前の画像を配置します。この例では左側から 12%、右側から 8% をトリミングし、その後画像フレームに [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) を設定してトリミングを保持します。

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

`PictureLocked.pptx` はトリミング ロックを `True` として保存します。PowerPoint では画像が選択されていると **トリミング** コマンドが無効になります。

### **図表をグループ化したまま保持**

この例では矩形と矢印をグループ化し、グループ自体に [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) を設定して図表のコンポーネントをまとめて保持します。グループの移動やコンポーネントの塗りの変更など、その他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はグループ解除ロックを `True` として保存します。PowerPoint では図全体が選択されていると **グループ解除** コマンドが無効になります。

### **結論**

Aspose.Slides for Python via .NET を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプの種類がサポートするロックを選択し、制限を解除したいときは値を `False` に設定してください。

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

はい。シェイプ ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/python-net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで使用できます。

**Can I restrict editing on specific slides without affecting others?**

はい。選択したスライドのシェイプにのみロックを適用すれば、他のスライドのロック設定には影響しません。

**How can I apply locks to individual shapes inside a group?**

グループの [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) コレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合も同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーにはロックを設定していません。