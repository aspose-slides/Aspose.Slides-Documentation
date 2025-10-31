---
title: Pythonのシェイプレックでプレゼンテーションの編集を防止
linktitle: プレゼンテーション編集の防止
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプレック
- 位置ロック
- 選択ロック
- サイズロック
- グループ化ロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が PPT、PPTX、ODP ファイルのシェイプをロックまたは解除し、プレゼンテーションを保護しつつ、編集を制御し、配信を高速化する方法を紹介します。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することが一般的な懸念事項となります。自動生成されたプレゼンテーションが元の書式や内容を保持することが重要です。

本記事では、プレゼンテーションとスライドの構造、および Aspose.Slides for Python がプレゼンテーションに保護を適用し、後でそれを解除する方法を説明します。開発者は、アプリケーションが生成するプレゼンテーションの使用方法を制御する手段を得られます。

## **スライドの構成要素**

プレゼンテーションのスライドは、オートシェイプ、表、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for Python では、スライド上の各要素は [シェイプ](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを継承したオブジェクトで表されます。

PPTX の構造は複雑であるため、すべてのシェイプタイプに対して汎用ロックが使用できる PPT とは異なり、シェイプタイプごとに異なるロックが必要です。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) クラスは PPTX 用の汎用ロック クラスです。Aspose.Slides for Python が PPTX でサポートするロック タイプは次のとおりです。

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) オートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) コネクタ シェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) グラフィック オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) グループ シェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクト内のすべてのシェイプ オブジェクトに対して行われる操作は、プレゼンテーション全体に適用されます。

## **保護の適用と解除**

保護を適用すると、プレゼンテーションを編集できなくなります。これはプレゼンテーションのコンテンツを保護するための有用な手法です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Python はスライド上のシェイプを操作するために [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを提供します。

前述のとおり、各シェイプ クラスには保護用のシェイプレック クラスが紐付いています。本記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックにより、シェイプを選択（マウスクリックやその他の選択方法）できなくなり、移動やサイズ変更もできなくなります。

以下のコード サンプルはプレゼンテーション内のすべてのシェイプ タイプに保護を適用します。

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("Sample.pptx") as presentation:
    # プレゼンテーション内のすべてのスライドを走査します。
    for slide in presentation.slides:
        # スライド内のすべてのシェイプを走査します。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # プレゼンテーションファイルを保存します。
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **保護の解除**

シェイプのロックを解除するには、適用されたロックの値を `False` に設定します。以下のコード サンプルはロックされたプレゼンテーション内のシェイプのロックを解除する方法を示しています。

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # プレゼンテーション内のすべてのスライドを走査します。
    for slide in presentation.slides:
        # スライド内のすべてのシェイプを走査します。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # プレゼンテーションファイルを保存します。
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **結論**

Aspose.Slides はプレゼンテーション内のシェイプを保護するための複数のオプションを提供します。個々のシェイプにロックを設定することも、プレゼンテーション内のすべてのシェイプを列挙してそれぞれにロックを設定することもでき、ファイル全体を効果的に保護できます。ロックの値を `False` に設定すれば保護を解除できます。

## **FAQ**

**同じプレゼンテーションでシェイプレックとパスワード保護を組み合わせることはできますか？**

はい。ロックはファイル内のオブジェクトの編集を制限し、[パスワード保護](/slides/ja/python-net/password-protected-presentation/) は開封および/または変更の保存へのアクセスを制御します。これらのメカニズムは相互補完的に機能します。

**特定のスライドだけ編集を制限し、他のスライドには影響しないようにできますか？**

はい。選択したスライド上のシェイプにロックを適用すれば、残りのスライドは引き続き編集可能です。

**シェイプレックはグループ化オブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィック オブジェクト、およびその他のシェイプ種別に対して、専用のロック タイプがサポートされています。