---
title: Android でシェイプロックを使用したプレゼンテーション編集の制限
linktitle: プレゼンテーション編集を制限
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
description: "Aspose.Slides for Android via Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、シェイプへの変更を制限することで、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上でシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素で構成されます。Aspose.Slides for Android via Java では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスを継承したオブジェクトとして表されます。

シェイプの種類に応じて、異なるロック オプションが提供されます。[IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) インターフェイスはシェイプロックの基底インターフェイスです。Aspose.Slides for Android via Java は以下のロック インターフェイスを提供します。

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) はコネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) はグラフィック オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) はグループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、各サポートされているシェイプに適切なロックを設定します。

## **保護の適用と削除**

互換性のあるプレゼンテーション エディタはシェイプ ロックを使用して個別の編集操作を制限します。ファイル暗号化とドキュメント レベルの書き込み保護は別個の [presentation protection settings](/slides/ja/androidjava/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for Android via Java はスライド上のシェイプを操作するために [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、[setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) を呼び出し、グループ シェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動用に [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) によってグループ化を制限します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクションをチェックし、これらの制限を適用したコピーを保存します。4 つの処理対象タイプ以外のシェイプは変更せずに残ります。ループはグループ内の子シェイプを走査しません。

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

シェイプ ロックを削除するには、その値を `false` に設定します。以下の例はシェイプ ロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) に `false` を渡してグループ化制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像のクロップを保持する**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例は左側から 12%、右側から 8% をクロップし、画像フレームのロックに対して [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) を呼び出します。`true` を渡すとさらにクロップできなくなり、既存のクロップが保持されます。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` はクロップ ロックを `true` として保存します。PowerPoint では画像が選択されていると **Crop** コマンドが無効化されます。

### **ダイアグラムをグループ化したままにする**

この例は矩形と矢印をグループ化し、グループのロックに対して [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) を呼び出してダイアグラムの構成要素をまとめたままにします。グループの移動や構成要素の塗りつぶし変更など、他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はアンガループ ロックを `true` として保存します。PowerPoint では全体のダイアグラムが選択されていると **Ungroup** コマンドが無効化されます。

### **既存のシェイプロックのレポート**

テンプレートを確認するには、テンプレートを開き各シェイプのロック オブジェクトを読み取ります。[getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) メソッドは、オブジェクト上のすべてのフラグが無効な場合に `true`、少なくとも 1 つが有効な場合に `false` を返します。グループとその子シェイプは別々のロック オブジェクトを持つため、グループにロックがなくても子シェイプを検査します。

この例はオートシェイプ、画像フレーム、グループの移動ロックをチェックし、画像のクロップ ロックとグループのアンガループ ロックも確認します。レポートは認識された有効フラグを一覧表示し、検査しないシェイプタイプはマークします。

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

例えば `Sample.pptx` のスライド 1 に、アンガループがロックされた `Layout` という名前のグループがあり、その中にクロップがロックされた `Photo` という画像があり、ロックされていない矩形 `Free` があるとします。レポートは `Free` をスキップし、次の 2 行を出力します。

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートはプレゼンテーションを変更せずに保存もせずに、保存されているシェイプレベルの編集フラグを読み取ります。ドキュメント レベルの書き込み保護は別個の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for Android via Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプタイプごとにサポートされているロックを選択し、制限を解除したい場合は値を `false` に設定してください。

## **FAQ**

**同じプレゼンテーションでシェイプロックとパスワード保護を組み合わせることはできますか？**

はい。シェイプロックは特定の編集操作を制限し、[password protection](/slides/ja/androidjava/password-protected-presentation/) はプレゼンテーションのオープンや変更を制限します。両方を同一ファイルで利用できます。

**特定のスライドだけで編集を制限し、他のスライドには影響を与えない方法はありますか？**

はい。対象スライドのシェイプにのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個別シェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) メソッドで取得したコレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は、レポート例と同様に再帰的に走査してください。