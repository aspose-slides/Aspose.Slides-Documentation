---
title: Pythonでシェイプ ロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Python via .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限すると、意図したレイアウトや内容を保護できます。

この記事では、スライド上のシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプのロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ シェイプ、画像フレーム、ビデオ フレーム、コネクタ、その他の要素などで構成されます。Aspose.Slides for Python via .NET では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスから継承されたオブジェクトとして表現されます。

シェイプの種類に応じて、利用できるロック オプションは異なります。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) クラスはシェイプ ロックの基底クラスです。Aspose.Slides for Python via .NET が提供するロック クラスは以下のとおりです。

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) はコネクタ シェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) はグラフィカル オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) はグループ シェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、各サポートされたシェイプに適切なロックを設定します。

## **保護の適用と削除**

シェイプ ロックは、シェイプの選択、移動、サイズ変更などの操作を制限しますが、プレゼンテーション全体を編集不可にするわけではありません。

### **PPTX 図形への保護の適用**

Aspose.Slides for Python via .NET はスライド上のシェイプを操作するために [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを提供します。

以下の例では、オートシェイプに対して [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)、[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) を `True` に設定し、グループ シェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に対して [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) を使用し、グループは [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) でグループ化を制限します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクションをチェックし、これらの制限を適用したコピーを保存します。4 つの取り扱い対象タイプ以外のシェイプは変更されません。また、ループはグループ内の子シェイプを走査しません。

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

シェイプ ロックを削除するには、その値を `False` に設定します。次の例では、シェイプ ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

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

### **結論**

Aspose.Slides for Python via .NET を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプの種類がサポートするロックを選択し、制限を解除したい場合は値を `False` に設定してください。

## **よくある質問**

**シェイプ ロックとパスワード保護を同じプレゼンテーションで組み合わせられますか？**

はい。シェイプ ロックは特定の編集操作を制限し、[password protection](/slides/ja/python-net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドには影響させない方法はありますか？**

はい。選択したスライドのシェイプにのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) コレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合も同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーへのロックは設定されません。