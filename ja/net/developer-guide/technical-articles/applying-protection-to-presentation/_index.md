---
title: .NET でシェイプレックによりプレゼンテーションの編集を制限する
linktitle: プレゼンテーション編集の制限
type: docs
weight: 70
url: /ja/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPTX プレゼンテーション内のシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、図形の変更を制限することで、意図したレイアウトとコンテンツを保持できます。

この記事では、スライド上の図形の配置方法と、PPTX プレゼンテーションで図形ロックを適用および解除する方法を説明します。これらのロックにより、個々の図形に対して特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーション作成に使用される要素で構成されます。Aspose.Slides for .NET では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそれを継承したクラスで表されます。

異なる図形タイプはそれぞれ異なるロックオプションを提供します。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) インターフェイスは図形ロックの基本インターフェイスです。Aspose.Slides for .NET は以下のロックインターフェイスを提供します:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) はコネクタ形状をロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) はグループ形状をロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、各サポート対象の図形に適切なロックを設定します。

## **保護の適用と削除**

対応するプレゼンテーション エディターは図形ロックを使用して個々の編集操作を制限します。ファイル暗号化やドキュメント単位の書き込み保護は、別の [presentation protection settings](/slides/ja/net/password-protected-presentation/) です。

### **PPTX 図形への保護の適用**

Aspose.Slides for .NET はスライド上の図形を操作するために [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)、[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) を `true` に設定し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) を使用し、グループは [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) を使用してグルーピングを制限します。

この例は既存の PPTX プレゼンテーションをロードし、各スライドの ShapeCollection を走査して図形を確認し、これらの制限を適用したコピーを保存します。対象の 4 種類以外の図形は変更されません。ループはグループ内の子図形を走査しません。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **保護の削除**

図形ロックを削除するには、その値を `false` に設定します。以下の例ではロックされたプレゼンテーションをロードし、[IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **画像の切り抜きの保持**

作業ディレクトリに `photo.jpg` という名前の写真を置きます。この例では左側を 12%、右側を 8% 切り抜き、画像フレームに [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) を設定します。このフラグにより、以降の切り抜きが制限され、既存の切り抜きが保持されます。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` は切り抜きロックを `true` として保存します。PowerPoint では写真が選択されているときに **Crop** コマンドが無効になります。

### **図表をグループ化したまま保持**

この例では四角形と矢印をグループ化し、グループ自体に [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) を設定して図表の構成要素が一緒に保たれるようにします。グループの移動や構成要素の塗りの変更など、その他の編集は引き続き可能です。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` はアングループロックを `true` として保存します。PowerPoint では図全体が選択されているときに **Ungroup** コマンドが無効になります。

### **結論**

Aspose.Slides for .NET を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、制限を解除する必要がある場合は値を `false` に設定してください。

## **FAQ**

**プレゼンテーションで図形ロックとパスワード保護を同時に使用できますか？**

はい。図形ロックは特定の編集操作を制限し、[password protection](/slides/ja/net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで併用可能です。

**特定のスライドだけ編集を制限し、他のスライドには影響させませんか？**

はい。対象スライドの図形にのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個々の図形にロックを適用するにはどうすればよいですか？**

グループの [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションを走査し、各子図形に適切なロックを適用します。入れ子のグループについても同様に繰り返します。上記の例はスライドの ShapeCollection のみを処理しているため、個々のグループメンバーにはロックが設定されません。