---
title: Java でシェイプレックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/java/applying-protection-to-presentation/
keywords:
- 編集の防止
- 編集から保護
- シェイプレック
- 位置ロック
- 選択ロック
- サイズ変更ロック
- グループ化ロック
- PowerPoint
- PPTX
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Java の一般的な使用法は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一環として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、図形への変更を制限することで意図したレイアウトやコンテンツを保護できます。

この記事では、スライド上で図形がどのように構成されているか、そして PPTX プレゼンテーションで図形ロックを適用および削除する方法を説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションの構築に使用される要素で構成されています。Aspose.Slides for Java では、スライド上の各要素は、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスを継承したオブジェクトで表されます。

異なる図形タイプは異なるロックオプションを提供します。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) インターフェイスは図形ロックの基本インターフェイスです。Aspose.Slides for Java は以下のロックインターフェイスを提供します：

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) オートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) コネクタ形状をロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) グラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) グループ形状をロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 画像フレームをロックします。  

ロックを [プレゼンテーション](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 全体に適用するには、スライドを反復し、各サポートされている図形に適切なロックを設定します。

## **保護の適用と削除**

対応するプレゼンテーション エディターは、図形ロックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメントレベルの書き込み保護は、別個の [プレゼンテーション保護設定](/slides/ja/java/password-protected-presentation/) です。

### **PPTX 図形への保護の適用**

Aspose.Slides for Java は、スライド上の図形を操作するための [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、[setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) を呼び出し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) を使用します。グループでは、グループ化を制限するために [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) も使用します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドの図形コレクション内の図形をチェックし、これらの制限を適用したコピーを保存します。4 つの処理対象タイプ以外の図形は変更されません。ループはグループ内の子図形を走査しません。

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

### **保護の削除**

図形ロックを削除するには、その値を `false` に設定します。以下の例では、図形ロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、`false` を [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) に渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像のトリミングの保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例では左側を 12%、右側を 8% トリミングし、画像フレームのロックに対して [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) を呼び出します。`true` を渡すことで、さらにトリミングできなくなり、既存のトリミングが保持されます。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` はトリミングロックを `true` として保存します。PowerPoint では、写真が選択されていると **Crop** コマンドが無効になります。

### **図のグループ化を維持**

この例では矩形と矢印をグループ化し、グループのロックに対して [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) を呼び出して、図のコンポーネントが一緒に保持されるようにします。グループの移動やコンポーネントの塗りつぶし変更など、他の編集は引き続き可能です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` はアン・グループロックを `true` として保存します。PowerPoint では、全体の図が選択されていると **Ungroup** コマンドが無効になります。

### **結論**

Aspose.Slides for Java を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、制限を削除する必要がある場合はその値を `false` に設定します。

## **よくある質問**

**このプレゼンテーションで図形ロックとパスワード保護を組み合わせることはできますか？**

はい。図形ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。同じファイルで両方を使用できます。

**特定のスライドだけの編集を制限し、他のスライドには影響させないことはできますか？**

はい。選択したスライドの図形にのみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個々の図形にロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) メソッドが返すコレクションを反復し、各子図形に適切なロックを適用します。入れ子になったグループについても同様に繰り返します。上記の例はスライドの図形コレクションのみを処理しているため、個々のグループメンバーにはロックが設定されません。