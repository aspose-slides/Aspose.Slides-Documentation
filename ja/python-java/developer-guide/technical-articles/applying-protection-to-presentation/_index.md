---
title: シェイプ ロックでプレゼンテーションの編集を防止
linktitle: プレゼンテーションの編集防止
type: docs
weight: 60
url: /ja/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java が PPT、PPTX、ODP ファイルのシェイプをロックまたはアンロックする方法を紹介し、プレゼンテーションを保護しながら、制御された編集と迅速な配信を可能にします。"
---
## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint（PPTX）プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。Aspose.Slides をこのように使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することが共通の懸念事項となります。自動生成されたプレゼンテーションが元の書式やコンテンツを保持することが重要です。

本記事では、プレゼンテーションとスライドの構造、および Aspose.Slides for Python via Java がプレゼンテーションに保護を適用し、後でそれを解除する方法について説明します。開発者は、アプリケーションが生成するプレゼンテーションの使用方法を制御する手段を得られます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオ フレーム、コネクタ、その他の要素などのコンポーネントで構成されます。Aspose.Slides for Python via Java では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) クラスから派生したオブジェクトで表されます。

PPTX の構造は複雑なため、すべてのシェイプタイプに共通のロックを使用できる PPT とは異なり、シェイプタイプごとに異なるロックが必要です。[BaseShapeLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseshapelock/) クラスは PPTX 用の汎用ロック クラスです。Aspose.Slides for Python via Java が PPTX でサポートするロックの種類は次のとおりです。

- [AutoShapeLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connectorlock/) はコネクタ シェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/graphicalobjectlock/) はグラフィカル オブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshapelock/) はグループ シェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクト内のすべてのシェイプ オブジェクトに対して実行される操作は、プレゼンテーション全体に適用されます。

## **保護の適用と削除**

保護を適用すると、プレゼンテーションを編集できなくなります。これはプレゼンテーションの内容を保護する有用な手法です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Python via Java は、スライド上のシェイプを操作するために [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) クラスを提供します。

前述のとおり、各シェイプ クラスには保護用のシェイプ ロック クラスが関連付けられています。本記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックは、シェイプが選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできないようにします。

以下のコード サンプルは、プレゼンテーション内のすべてのシェイプ タイプに保護を適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("Sample.pptx")
try:
    # プレゼンテーション内のすべてのスライドを走査します。
    for slide in presentation.getSlides():
        # スライド内のすべてのシェイプを走査します。
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

    # プレゼンテーション ファイルを保存します。
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **保護の解除**

シェイプのロックを解除するには、適用されたロックの値を `False` に設定します。次のコード サンプルは、ロックされたプレゼンテーション内のシェイプのロックを解除する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("ProtectedSample.pptx")
try:
    # プレゼンテーション内のすべてのスライドを走査します。
    for slide in presentation.getSlides():
        # スライド内のすべてのシェイプを走査します。
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

    # プレゼンテーション ファイルを保存します。
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **結論**

Aspose.Slides では、プレゼンテーション内のシェイプを保護するためのさまざまなオプションが用意されています。個々のシェイプにロックをかけることも、プレゼンテーション内のすべてのシェイプを列挙して各シェイプにロックをかけることもでき、ファイル全体を実質的に保護できます。ロックの値を `False` に設定すれば、保護を解除できます。

## **よくある質問**

**シェイプ ロックとパスワード保護を同じプレゼンテーションで組み合わせられますか？**

はい。ロックはファイル内のオブジェクトの編集を制限し、[password protection](/slides/ja/python-java/password-protected-presentation/) は開く際や変更を保存する際のアクセスを制御します。これらの仕組みは相補的に機能します。

**特定のスライドだけ編集を制限し、他のスライドはそのままにできますか？**

はい。対象スライドのシェイプにロックを適用すれば、残りのスライドは編集可能なままです。

**シェイプ ロックはグループ化オブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィック オブジェクト、およびその他のシェイプ種別に対応した専用ロック タイプがサポートされています。