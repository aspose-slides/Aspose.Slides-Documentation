---
title: .NET のシェイプ ロックでプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限する
type: docs
weight: 70
url: /ja/net/applying-protection-to-presentation/
keywords:
- 編集の防止
- 編集から保護
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
description: "Aspose.Slides for .NET を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for .NET の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、シェイプへの変更を制限することで、意図したレイアウトやコンテンツを保護できます。

この記事では、スライド上のシェイプの構成方法と、PPTX プレゼンテーションでシェイプ ロックを適用および解除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for .NET では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそれを継承したクラスで表されます。

シェイプの種類に応じて異なるロックオプションが提供されます。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) インターフェイスはシェイプ ロックの基本インターフェイスです。Aspose.Slides for .NET は以下のロックインターフェイスを提供します：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) オートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) コネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) グラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) グループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 全体にロックを適用するには、スライドを走査し、各サポートされているシェイプに適切なロックを設定します。

## **保護の適用と解除**

シェイプ ロックは、シェイプの選択、移動、サイズ変更などの操作を制限します。プレゼンテーション全体を編集不可にするわけではありません。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for .NET はスライド上のシェイプを操作するために [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを提供します。

サンプルでは、オートシェイプに対して [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)、[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) を `true` に設定し、グループ シェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) を使用し、グループはグループ化を制限するために [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) を使用します。

このサンプルは既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクションをチェックし、これらの制限を適用したコピーを保存します。対象の4つのタイプ以外のシェイプは変更されません。ループはグループ内の子シェイプは走査しません。

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

シェイプ ロックを解除するには、その値を `false` に設定します。以下のサンプルはロックされたシェイプを含むプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **結論**

Aspose.Slides for .NET を使用すると、個々のシェイプに対する特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプの種類がサポートするロックを選択し、制限を解除したい場合はその値を `false` に設定してください。

## **FAQ**

**同じプレゼンテーションでシェイプ ロックとパスワード保護を組み合わせることはできますか？**

はい。シェイプ ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/net/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけで編集を制限し、他のスライドに影響を与えないようにできますか？**

はい。選択したスライドのシェイプにのみロックを適用します。これにより他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーにはロックが設定されません。