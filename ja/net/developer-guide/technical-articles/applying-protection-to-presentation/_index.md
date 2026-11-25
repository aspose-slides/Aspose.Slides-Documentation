---
title: .NET のシェイプロックでプレゼンテーションの編集を制限する
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
description: "Aspose.Slides for .NET を使用して PPTX プレゼンテーションのシェイプをロックおよび解除し、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限すると、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上のシェイプの構成方法と、PPTX プレゼンテーションでシェイプレックを適用および解除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、ピクチャーフレーム、ビデオフレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for .NET では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスから派生したオブジェクトで表されます。

シェイプの種類に応じてロックオプションが異なります。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) インターフェイスはシェイプレックの基本インターフェイスです。Aspose.Slides for .NET は以下のロックインターフェイスを提供します。

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) オートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) コネクタシェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) グラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) グループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) ピクチャーフレームをロックします。

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを列挙し、各サポート対象シェイプに適切なロックを設定します。

## **保護の適用と解除**

互換性のあるプレゼンテーション エディタはシェイプレックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメント レベルの書き込み保護は別個の [プレゼンテーション保護設定](/slides/ja/net/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for .NET はスライド上のシェイプを操作するための [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) 、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) 、[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) を `true` に設定し、グループ シェイプ、コネクタ、ピクチャーフレームにも同等のロックを適用します。コネクタは移動のために [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) を使用します。グループはさらに [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) でグループ化を制限します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクションを調べ、これらの制限を適用したコピーを保存します。取り扱われない 4 種類以外のシェイプは変更せずに残ります。ループはグループ内部の子シェイプは走査しません。

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

### **保護の解除**

シェイプレックを解除するには、その値を `false` に設定します。以下の例ではロック付きプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 、[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限をクリアします。また [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定はそのまま残ります。

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

### **画像トリミングの保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例は左側を 12%、右側を 8% トリミングし、ピクチャーフレームに対して [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) を設定します。このフラグによりそれ以上のトリミングが制限され、既存のトリミングが保持されます。

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

`PictureLocked.pptx` はトリムロックを `true` として保存します。PowerPoint では写真が選択されていると **Crop** コマンドが無効になります。

### **図のグループ化を維持**

この例では長方形と矢印をグループ化し、グループ自体に [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) を設定して図の構成要素が一緒に保たれるようにします。グループの移動や構成要素の塗りつぶし変更など、他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はアンレングロックを `true` として保存します。PowerPoint では全体の図が選択されていると **Ungroup** コマンドが無効になります。

### **既存シェイプロックのレポート**

テンプレートを確認するにはそれを開き、各シェイプのロック オブジェクトを読み取ります。[NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) はそのオブジェクトのすべてのフラグが無効の場合に `true`、少なくとも 1 つが有効な場合に `false` です。グループとその子には個別のロック オブジェクトがあるため、グループにロックがなくても子シェイプを検査します。

この例はオートシェイプ、ピクチャーフレーム、グループの移動、画像のトリミング、グループのアンレングロックをチェックします。認識したフラグをレポートし、検査しないシェイプ種別はマークします。

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

`Sample.pptx` のスライド 1 に、アンレングロックが設定された `Layout` という名前のグループがあり、その中にトリミングがロックされた `Photo` という画像、ロックされていない `Free` という長方形が含まれているとします。レポートは `Free` をスキップし、次の 2 行を出力します。

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートはプレゼンテーションを変更したり保存したりせずに、保存されているシェイプ レベルの編集フラグを読み取ります。ドキュメント レベルの書き込み保護は別個の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for .NET を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプ種別がサポートするロックを選択し、制限を解除したいときは値を `false` に設定してください。

## **FAQ**

**同じプレゼンテーションでシェイプレックとパスワード保護を組み合わせることはできますか？**

はい。シェイプレックは特定の編集操作を制限し、[パスワード保護](/slides/ja/net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。同じファイルで両方を使用できます。

**特定のスライドだけ編集を制限し、他のスライドには影響を与えないようにできますか？**

はい。選択したスライドのシェイプにだけロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの[Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションを反復処理し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合も、レポート例の走査と同様に繰り返します。