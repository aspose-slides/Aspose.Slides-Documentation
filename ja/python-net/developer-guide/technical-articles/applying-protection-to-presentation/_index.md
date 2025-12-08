---
title: Pythonでシェイプロックを使用してプレゼンテーションの編集を防止
linktitle: プレゼンテーションの編集防止
type: docs
weight: 70
url: /ja/python-net/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプのロック
- 位置のロック
- 選択のロック
- サイズのロック
- グループ化のロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET 経由）で PPT、PPTX、ODP ファイルのシェイプをロックまたはロック解除する方法を紹介します。プレゼンテーションを保護しながら、編集を制御し、納品を高速化します。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を利用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することがよく求められます。自動生成されたプレゼンテーションが元の書式やコンテンツを保持することが重要です。

この記事では、プレゼンテーションとスライドの構造と、Aspose.Slides for Python がプレゼンテーションに保護を適用し、後でそれを削除する方法を説明します。これにより、開発者はアプリケーションが生成するプレゼンテーションの使用方法を制御できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオ フレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for Python では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを継承したオブジェクトで表されます。

PPTX の構造は複雑で、PPT のようにすべてのシェイプに対して汎用ロックを使用できません。シェイプの種類ごとに異なるロックが必要です。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) クラスは PPTX 用の汎用ロッククラスです。Aspose.Slides for Python for PPTX がサポートするロックの種類は次のとおりです。

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) はコネクタ シェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) はグラフィック オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) はグループ シェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクト内のすべてのシェイプ オブジェクトに対して実行された操作は、プレゼンテーション全体に適用されます。

## **保護の適用と削除**

保護を適用すると、プレゼンテーションを編集できなくなります。これはコンテンツを保護する有用な手法です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Python はスライド上のシェイプを操作するために [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを提供します。

前述のとおり、各シェイプ クラスには保護用のシェイプロック クラスが関連付けられています。この記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックはシェイプが選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできないようにします。

以下のコード サンプルは、プレゼンテーション内のすべてのシェイプ タイプに保護を適用します。
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
    # プレゼンテーション ファイルを保存します。
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **保護の削除**

シェイプのロックを解除するには、適用されたロックの値を `False` に設定します。次のコード サンプルは、ロックされたプレゼンテーションでシェイプのロックを解除する方法を示しています。
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
    # プレゼンテーション ファイルを保存します。
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **結論**

Aspose.Slides では、プレゼンテーション内のシェイプを保護するためのさまざまなオプションが用意されています。個々のシェイプをロックすることも、プレゼンテーション内のすべてのシェイプを反復処理してそれぞれロックすることもでき、ファイル全体を効果的に保護できます。ロックの値を `False` に設定すれば保護を解除できます。

## **FAQ**

**シェイプ ロックとパスワード保護を同じプレゼンテーションで組み合わせられますか？**

はい。ロックはファイル内のオブジェクトの編集を制限し、[password protection](/slides/ja/python-net/password-protected-presentation/) は開封や変更の保存へのアクセスを制御します。これらのメカニズムは相補的に機能します。

**特定のスライドだけ編集を制限し、他のスライドはそのままにできますか？**

はい。選択したスライドのシェイプにロックを適用すれば、残りのスライドは引き続き編集可能です。

**シェイプ ロックはグループ化オブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィック オブジェクト、その他のシェイプ種別に対応した専用ロック タイプがサポートされています。