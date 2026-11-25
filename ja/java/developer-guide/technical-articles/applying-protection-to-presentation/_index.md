---
title: Java でシェイロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 60
url: /ja/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPTX プレゼンテーション内のシェイプをロックおよびロック解除し、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for Java の一般的な使用例は、PowerPoint（PPTX）プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限すると、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上でシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、そしてプレゼンテーションを構築するために使用される他の要素などのコンポーネントで構成されます。Aspose.Slides for Java では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそれを継承したクラスで表されます。

シェイプタイプごとに異なるロックオプションが公開されています。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) インターフェイスはシェイプロックの基本インターフェイスです。Aspose.Slides for Java は以下のロックインターフェイスを提供します。

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) はコネクタシェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) はグループシェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、各サポートされているシェイプに適切なロックを設定します。

## **保護の適用と削除**

互換性のあるプレゼンテーションエディタはシェイプロックを使用して個々の編集操作を制限します。ファイル暗号化とドキュメントレベルの書き込み保護は別個の [presentation protection settings](/slides/ja/java/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Java はスライド上のシェイプを操作するための [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを提供します。

サンプルはオートシェイプに対して `true` とともに [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、[setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) を呼び出し、グループシェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に対して [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) でグループ化を制限します。

サンプルは既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内のシェイプを確認し、これらの制限を適用したコピーを保存します。4 つの対象タイプ以外のシェイプは変更されません。ループはグループ内の子シェイプを走査しません。

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

シェイプロックを削除するには、その値を `false` に設定します。以下のサンプルはシェイプロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) に `false` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像の切り抜きの保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。サンプルは左側から 12％、右側から 8％ を切り抜き、その後画像フレームのロックに対して [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) を呼び出します。`true` を渡すとさらに切り抜きが制限され、既存の切り抜きが保持されます。

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

`PictureLocked.pptx` は切り抜きロックを `true` として保存します。PowerPoint では写真が選択されていると **Crop** コマンドが無効になります。

### **図のグループ化を維持**

サンプルは長方形と矢印をグループ化し、グループのロックに対して [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) を呼び出すことで、図の構成要素をまとめたままにします。グループの移動や構成要素の塗り替えといった他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はアンガルーピングロックを `true` として保存します。PowerPoint では全体の図が選択されていると **Ungroup** コマンドが無効になります。

### **既存のシェイプロックのレポート**

テンプレートを確認するには、それを開いて各シェイプのロックオブジェクトを読み取ります。[getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) メソッドは、オブジェクト上のすべてのフラグが無効な場合に `true` を、少なくとも 1 つが有効な場合に `false` を返します。グループとその子には別々のロックオブジェクトがあるため、グループにロックがなくても子を検査します。

このサンプルはオートシェイプ、画像フレーム、グループの移動をチェックし、画像の切り抜きとグループのアンガルーピングも確認します。レポートは認識した有効なフラグを一覧表示し、検査しないシェイプタイプにはマークを付けます。

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

`Sample.pptx` のスライド 1 に、アンガルーピングがロックされた `Layout` という名前のグループがあり、その中に切り抜きがロックされた `Photo` という画像が、そしてロックされていない矩形 `Free` があるとします。レポートは `Free` をスキップし、次の 2 行を出力します。

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートはプレゼンテーションを変更したり保存したりせずに、保存されているシェイプレベルの編集フラグを読み取ります。ドキュメントレベルの書き込み保護は別個の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプタイプごとにサポートされているロックを選択し、制限を解除したいときは値を `false` に設定してください。

## **FAQ**

**プレゼンテーション内でシェイプロックとパスワード保護を同時に使用できますか？**

はい。シェイプロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドには影響を与えませんか？**

はい。選択したスライドのシェイプにのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) メソッドが返すコレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は、レポートサンプルの走査ロジックに従って同様に処理します。