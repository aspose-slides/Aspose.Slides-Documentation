---
title: Node.js でシェイプ ロックを使用したプレゼンテーション編集の制限
linktitle: プレゼンテーション編集の制限
type: docs
weight: 60
url: /ja/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PPTX プレゼンテーション内のシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java の一般的な使用例は、PowerPoint（PPTX）プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、シェイプの変更を制限することで意図したレイアウトとコンテンツを保持できます。

この記事では、スライド上のシェイプの構成と、PPTX プレゼンテーションでシェイプのロックを適用および解除する方法を説明します。これらのロックにより、個々のシェイプに対して特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素などで構成されます。Aspose.Slides for Node.js via Java では、スライド上の各要素は [シェイプ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスを継承したオブジェクトで表されます。

シェイプの種類に応じて異なるロックオプションが提供されます。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) クラスはシェイプロックの基底クラスです。Aspose.Slides for Node.js via Java が提供するロッククラスは次のとおりです。

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) はコネクタシェイプをロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) はグループシェイプをロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、サポートされている各シェイプに適切なロックを設定します。

## **保護の適用と解除**

シェイプロックは、シェイプの選択、移動、サイズ変更などの操作を制限します。プレゼンテーション全体を編集不能にするわけではありません。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Node.js via Java は、スライド上のシェイプを操作するために [シェイプ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスを提供します。

例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出し、グループシェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に対して [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) を使用します。グループは [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) も使用してグループ化を制限します。

例は既存の PPTX プレゼンテーションをロードし、各スライドのシェイプコレクションをチェックして、これらの制限を適用したコピーを保存します。4 つの処理対象タイプ以外のシェイプは変更されません。ループはグループ内の子シェイプまでは走査しません。

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

### **保護の解除**

シェイプロックを解除するには、その値を `false` に設定します。以下の例はロックが設定されたプレゼンテーションをロードし、[AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) に `false` を渡してグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

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

### **結論**

Aspose.Slides for Node.js via Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプタイプごとにサポートされているロックを選択し、解除が必要なときは値を `false` に設定してください。

## **FAQ**

**シェイプロックとパスワード保護を同じプレゼンテーションで併用できますか？**

はい。シェイプロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/nodejs-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで使用可能です。

**特定のスライドだけに編集制限をかけ、他のスライドには影響させない方法はありますか？**

はい。ロックは対象スライドのシェイプにのみ適用すれば、他のスライドのロック設定には影響しません。

**グループ内の個別シェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) メソッドで返されるコレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は同様に繰り返します。上記の例はスライドのシェイプコレクションのみを処理しているため、個別のグループメンバーにはロックを設定していません。