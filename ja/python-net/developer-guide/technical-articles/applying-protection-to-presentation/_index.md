---
title: Python で図形ロックを使用してプレゼンテーションの編集を防止する
linktitle: 編集を防止
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
keywords:
- 編集を防止
- 編集から保護
- 図形をロック
- 位置をロック
- 選択をロック
- サイズをロック
- グループ化をロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP ファイル内の図形をロックまたはロック解除し、編集を制御しながらプレゼンテーションを保護し、迅速な配信を実現する方法をご紹介します。"
---

{{% alert color="primary" %}} 

Aspose.Slidesの一般的な使用法は、Microsoft PowerPoint 2007 (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。この方法でAspose.Slidesを使用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。編集から保護することは一般的な関心事です。自動生成されたプレゼンテーションが元のフォーマットとコンテンツを保持することは重要です。

この記事では、[プレゼンテーションとスライドの構成](/slides/ja/python-net/applying-protection-to-presentation/)と、Aspose.Slides for Python via .NETがどのようにして[保護を適用するか](/slides/ja/python-net/applying-protection-to-presentation/)、そして[それをプレゼンテーションから除去するか](/slides/ja/python-net/applying-protection-to-presentation/)を説明します。この機能はAspose.Slides特有のもので、執筆時点ではMicrosoft PowerPointにはありません。これは、アプリケーションが作成したプレゼンテーションの使用方法を制御する手段を開発者に提供します。

{{% /alert %}} 
## **スライドの構成**
PPTXスライドは、自動図形、テーブル、OLEオブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、プレゼンテーションを構築するために使用可能なさまざまな要素など、多数のコンポーネントで構成されています。

Aspose.Slides for Python via .NETでは、スライド上の各要素はShapeオブジェクトに変換されます。言い換えれば、スライド上の各要素は、ShapeオブジェクトまたはShapeオブジェクトから派生したオブジェクトのいずれかです。

PPTXの構造は複雑であるため、すべての型の図形に対して一般的なロックを使用できるPPTとは異なり、異なる型の図形には異なるロックがあります。BaseShapeLockクラスは、一般的なPPTXロッキングクラスです。Aspose.Slides for Python via .NETでは、PPTX用に次の種類のロックがサポートされています。

- AutoShapeLockは自動図形をロックします。
- ConnectorLockはコネクタ図形をロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループ図形をロックします。
- PictureFrameLockは画像フレームをロックします。

プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されるアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と削除**
保護を適用することで、プレゼンテーションが編集されないことを確保します。これは、プレゼンテーションのコンテンツを保護するための便利な技術です。
### **PPTX図形への保護の適用**
Aspose.Slides for Python via .NETは、スライド上の図形を処理するためのShapeクラスを提供します。

前述のように、各図形クラスには保護のための関連する図形ロッククラスがあります。この記事では、NoSelect、NoMove、NoResizeロックに焦点を当てています。これらのロックは、図形が選択できなくなること（マウスクリックや他の選択方法を通じて）、移動やサイズ変更ができないことを保証します。

以下のコードサンプルは、プレゼンテーション内のすべての図形タイプに保護を適用します。

```py
import aspose.slides as slides

#PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #プレゼンテーション内のスライドにアクセスするためのISlideオブジェクト
    slide = pres.slides[0]

    #プレゼンテーション内のすべてのスライドを走査
    for slide in pres.slides:
        for shape in slide.shapes:
            #図形が自動図形の場合
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #図形ロックの適用
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #図形がグループ図形の場合
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #図形ロックの適用
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #図形がコネクタの場合
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #図形ロックの適用
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #図形が画像フレームの場合
            elif type(shape) is slides.PictureFrame:
                #画像フレーム図形にキャストし、画像フレーム図形ロックを取得
                picture_lock = shape.shape_lock

                #図形ロックの適用
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #プレゼンテーションファイルを保存
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **保護の削除**
Aspose.Slides for Python via .NETを使用して適用された保護は、Aspose.Slides for Python via .NETでのみ削除できます。図形のロックを解除するには、適用したロックの値をfalseに設定します。以下のコードサンプルでは、ロックされたプレゼンテーション内の図形のロックを解除する方法を示します。

```py
import aspose.slides as slides

#必要なプレゼンテーションを開く
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #図形ロックの適用
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #図形ロックの適用
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #図形ロックの適用
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #図形ロックの適用
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #プレゼンテーションファイルを保存
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **まとめ**
{{% alert color="primary" %}} 

Aspose.Slidesは、プレゼンテーション内の図形に保護を適用するための多くのオプションを提供しています。特定の図形をロックすることもできますし、プレゼンテーション内のすべての図形をループしてすべてをロックし、実質的にプレゼンテーションをロックすることも可能です。

保護を削除できるのは、以前に保護したプレゼンテーションに対してのみAspose.Slides for Python via .NETです。ロックの値をfalseに設定することで保護を解除します。

{{% /alert %}} 
