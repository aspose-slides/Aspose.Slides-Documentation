---
title: Node.js でシェイプ ロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限する
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
description: "Aspose.Slides for Node.js via Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、形状の変更を制限することで意図したレイアウトとコンテンツを保護できます。

本記事では、スライド上で形状がどのように構成されているか、そしてPPTXプレゼンテーションで形状ロックを適用および削除する方法を説明します。これらのロックにより、個々の形状に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLEオブジェクト、グループ化された形状、画像フレーム、ビデオフレーム、コネクタ、その他の要素で構成され、プレゼンテーションを構築するために使用されます。Aspose.Slides for Node.js via Java では、スライド上の各要素は[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)クラスを継承したオブジェクトとして表されます。

異なる形状タイプは異なるロックオプションを提供します。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/)クラスは形状ロックの基底クラスです。Aspose.Slides for Node.js via Java は以下のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) はコネクタ形状をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) はグループ形状をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)全体にロックを適用するには、スライドを反復処理し、サポートされている各形状に適切なロックを設定します。

## **保護の適用と削除**

対応するプレゼンテーションエディタは形状ロックを使用して個々の編集操作を制限します。ファイル暗号化およびドキュメントレベルの書き込み保護は、別個の[プレゼンテーション保護設定](/slides/ja/nodejs-java/password-protected-presentation/)です。

### **PPTX 形状への保護の適用**

Aspose.Slides for Node.js via Java はスライド上の形状を操作するために[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)クラスを提供します。

この例では、オートシェイプに対して `true` を指定して[setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked)を呼び出し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために[setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove)を使用し、グループはグループ化を制限するために[setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)も使用します。

この例では既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内の形状をチェックし、これらの制限を適用したコピーを保存します。4 種類の処理対象外の形状はそのまま残ります。ループはグループ内の子シェイプを走査しません。

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

形状ロックを削除するには、その値を `false` に設定します。以下の例では、形状ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) に `false` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像のクロップを保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例では左から12%、右から8% をクロップし、その後画像フレームのロックに対して[setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked)を呼び出します。`true` を渡すとさらにクロップできなくなり、既存のクロップが保持されます。

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

`PictureLocked.pptx` はクロップロックを `true` として保存します。PowerPoint では、写真が選択されていると **Crop** コマンドが無効になります。

### **図のグループ化を維持**

この例では長方形と矢印をグループ化し、グループのロックに対して[setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked)を呼び出して図のコンポーネントを一体化します。グループの移動やコンポーネントの塗りつぶし変更など、他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はアンガループロックを `true` として保存します。PowerPoint では、図全体が選択されていると **Ungroup** コマンドが無効になります。

### **既存の形状ロックのレポート**

テンプレートを確認するには、テンプレートを開き各形状のロックオブジェクトを読み取ります。[getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) メソッドは、オブジェクト上のすべてのフラグが無効の場合に `true` を、少なくとも1つが有効な場合に `false` を返します。グループとその子は別々のロックオブジェクトを持つため、グループにロックがなくても子を検査してください。

この例ではオートシェイプ、画像フレーム、グループの移動をチェックします。また、画像のクロップとグループのアンガループもチェックします。レポートは認識した有効なフラグを一覧表示し、検査しない形状タイプにはマークを付けます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

`Sample.pptx` のスライド1に、アンガループがロックされた `Layout` という名前のグループがあり、その内部にクロップがロックされた `Photo` という画像があり、ロックされていない矩形 `Free` があるとします。レポートは `Free` をスキップし、次の2行を出力します：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートは保存された形状レベルの編集フラグを読み取りますが、変更したりプレゼンテーションを保存したりはしません。ドキュメントレベルの書き込み保護は別個の設定であり、各フラグの適用はエディタ次第です。

## **結論**

Aspose.Slides for Node.js via Java を使用すると、個々の形状に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各形状タイプがサポートするロックを選択し、制限を解除する必要がある場合は値を `false` に設定してください。

## **よくある質問**

**同じプレゼンテーションで形状ロックとパスワード保護を組み合わせることはできますか？**

はい。形状ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/nodejs-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけの編集を制限し、他のスライドに影響を与えないようにすることはできますか？**

はい。選択したスライド上の形状にのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**グループ内の個々の形状にロックを適用するにはどうすればよいですか？**

グループの[getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)メソッドが返すコレクションを反復処理し、各子形状に適切なロックを適用します。ネストされたグループがある場合も同様に、レポート例の走査手順に従って繰り返します。