---
title: Java でシェイプレックによりプレゼンテーション編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/java/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプのロック
- 位置のロック
- 選択のロック
- サイズ変更のロック
- グループ化のロック
- PowerPoint
- PPTX
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限することで、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上のシェイプの構成方法と、PPTX プレゼンテーションでシェイプ ロックを適用および解除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成要素**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオ フレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for Java では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスから派生したオブジェクトで表されます。

シェイプの種類によってロック オプションが異なります。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) インターフェイスはシェイプ ロックの基本インターフェイスです。Aspose.Slides for Java が提供するロック インターフェイスは次のとおりです。

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) はコネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) はグラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) はグループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 全体にロックを適用するには、スライドを列挙し、各サポート対象シェイプに適切なロックを設定します。

## **保護の適用と解除**

シェイプ ロックは、シェイプの選択、移動、サイズ変更などの操作を制限しますが、プレゼンテーション全体を編集不可にするわけではありません。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Java はスライド上のシェイプを操作するために [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを提供します。

例ではオートシェイプに対して `true` を渡して [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、[setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) を呼び出し、グループ シェイプ、コネクタ、画像フレームでも同等のロックを適用します。コネクタは移動に対して [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) でグループ化を制限します。

例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクション内のシェイプを確認し、これらの制限を適用したコピーを保存します。4 種類のシェイプ以外は変更されません。ループはグループ内の子シェイプを走査しません。

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

シェイプ ロックを解除するには、その値を `false` に設定します。以下の例はロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) に `false` を渡してグループ化制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

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

Aspose.Slides for Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプの種類がサポートするロックを選択し、削除が必要な場合は値を `false` に設定してください。

## **FAQ**

**同じプレゼンテーションでシェイロックとパスワード保護を組み合わせることはできますか？**

はい。シェイロックは特定の編集操作を制限し、[password protection](/slides/ja/java/password-protected-presentation/) はプレゼンテーションの開封や変更自体を制限します。両方を同一ファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドには影響を与えないようにできますか？**

はい。選択したスライドのシェイプにのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個別シェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) メソッドが返すコレクションを列挙し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーにはロックを設定していません。