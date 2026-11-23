---
title: Node.js でシェイプロックを使用したプレゼンテーション編集の制限
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して PPTX プレゼンテーション内のシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java の一般的な使用例は、自動化されたワークフローの一部として PowerPoint (PPTX) プレゼンテーションを作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプの変更を制限することで、意図したレイアウトと内容を保護できます。

この記事では、スライド上でシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプロックを適用および削除する方法を説明します。これらのロックを使用すると、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成要素**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、そしてプレゼンテーションの作成に使用されるその他の要素で構成されています。Aspose.Slides for Node.js via Java では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスを継承したオブジェクトとして表されます。

シェイプの種類ごとに異なるロックオプションが用意されています。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) クラスはシェイプロックの基底クラスです。Aspose.Slides for Node.js via Java は以下のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) はコネクタシェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) はグループシェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 全体にロックを適用するには、スライドを反復処理し、各サポートされているシェイプに適切なロックを設定します。

## **保護の適用と削除**

対応するプレゼンテーションエディタはシェイプロックを使用して個別の編集操作を制限します。ファイルの暗号化やドキュメントレベルの書き込み保護は、別個の [プレゼンテーション保護設定](/slides/ja/nodejs-java/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Node.js via Java は、スライド上のシェイプを操作するために [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスを提供します。

例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出します。同様のロックがグループシェイプ、コネクタ、画像フレームにも適用されます。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループはグループ化を制限するために [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) も使用します。

例では既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内のシェイプをチェックし、これらの制限が適用されたコピーを保存します。扱われた 4 種類以外のシェイプは変更されません。ループはグループ内の子シェイプを走査しません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **保護の削除**

シェイプロックを削除するには、その値を `false` に設定します。以下の例ではシェイプロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 、[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、`false` を [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) に渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **画像のトリミングを保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。例では左側を 12%、右側を 8% トリミングし、画像フレームのロックに対して [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) を呼び出します。`true` を渡すことで、さらにトリミングできなくなり、既存のトリミングが保持されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` はトリムロックを `true` として保存します。PowerPoint では、写真が選択されていると **Crop** コマンドが無効になります。

### **図のグループ化を維持**

例では矩形と矢印をグループ化し、グループのロックに対して [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) を呼び出すことで、図の構成要素が一緒に保たれるようにします。グループの移動やコンポーネントの塗りつぶし変更など、他の編集は引き続き可能です。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` はグループ解除ロックを `true` として保存します。PowerPoint では、図全体が選択されていると **Ungroup** コマンドが無効になります。

### **結論**

Aspose.Slides for Node.js via Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各シェイプタイプがサポートするロックを選択し、制限を解除する必要がある場合は値を `false` に設定してください。

## **よくある質問**

**同じプレゼンテーションでシェイプロックとパスワード保護を組み合わせることはできますか？**

はい。シェイプロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/nodejs-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**他のスライドに影響を与えずに、特定のスライドだけの編集を制限できますか？**

はい。対象となるスライドのシェイプにのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを反復処理し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合も同様に繰り返します。上記の例はスライドのシェイプコレクションのみを処理しているため、個々のグループメンバーにはロックを設定していません。