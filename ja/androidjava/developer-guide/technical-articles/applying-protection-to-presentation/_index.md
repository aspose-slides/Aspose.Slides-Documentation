---
title: Android でシェイプ ロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一環として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限することで、意図されたレイアウトとコンテンツを保護できます。

この記事では、スライド上のシェイプの構成方法と、PPTX プレゼンテーションでシェイプ ロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、ピクチャーフレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素で構成されます。Aspose.Slides for Android via Java では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスから派生したオブジェクトとして表されます。

シェイプの種類ごとに異なるロック オプションが公開されています。[IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) インターフェイスはシェイプ ロックの基本インターフェイスです。Aspose.Slides for Android via Java は以下のロック インターフェイスを提供します：

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) はコネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) はグラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) はグループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) はピクチャーフレームをロックします。  

ロックを [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 全体に適用するには、スライドを反復処理し、サポートされている各シェイプに適切なロックを設定します。

## **保護の適用と解除**

シェイプ ロックは、シェイプの選択、移動、サイズ変更などの操作を制限します。プレゼンテーション全体が編集不可になるわけではありません。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Android via Java は、スライド上のシェイプを操作するための [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、[setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) を呼び出し、グループシェイプ、コネクタ、ピクチャーフレームにも同等のロックを設定します。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) を使用し、グループはグルーピングを制限するために [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) も使用します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内のシェイプをチェックし、これらの制限が適用されたコピーを保存します。対象の 4 種類以外のシェイプは変更されません。ループはグループ内の子シェイプを走査しません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **保護の解除**

シェイプ ロックを解除するには、その値を `false` に設定します。以下の例では、シェイプ ロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、`false` を [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) に渡すことでグルーピング制限も解除し、プレゼンテーションのコピーを保存します。その他のロック設定は変更されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **結論**

Aspose.Slides for Android via Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプの種類ごとにサポートされているロックを選択し、制限を解除したい場合はその値を `false` に設定してください。

## **FAQ**

**同じプレゼンテーションでシェイプ ロックとパスワード保護を組み合わせることはできますか？**

はい。シェイプ ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/androidjava/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけの編集を制限し、他のスライドには影響させないことはできますか？**

はい。選択したスライドのシェイプにのみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) メソッドが返すコレクションを反復処理し、各子シェイプに適切なロックを適用します。入れ子になったグループについても同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーにはロックが設定されません。