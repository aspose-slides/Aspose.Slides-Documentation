---
title: シェイプ ロックでプレゼンテーションの編集を防止
linktitle: プレゼンテーション編集の防止
type: docs
weight: 70
url: /ja/net/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプをロック
- 位置をロック
- 選択をロック
- サイズをロック
- グループ化をロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が PPT、PPTX、ODP ファイル内のシェイプをロックまたは解除し、プレゼンテーションを保護しつつ、制御された編集と迅速な配信を可能にする方法をご紹介します。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することが一般的な懸念事項です。自動生成されたプレゼンテーションが元の書式と内容を保持することが重要です。

この記事では、プレゼンテーションとスライドの構造と、Aspose.Slides for .NET がプレゼンテーションに保護を適用し、後でそれを解除する方法について説明します。開発者がアプリケーションで生成したプレゼンテーションの使用方法を制御できるようにします。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化されたシェイプ、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションの構築に使用される要素で構成されています。Aspose.Slides for .NET では、スライド上の各要素は[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスを継承したオブジェクトで表されます。

PPTX の構造は複雑なため、すべてのシェイプタイプに対して汎用ロックを使用できる PPT とは異なり、シェイプタイプごとに異なるロックが必要です。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) インターフェイスは PPTX 用の汎用ロック クラスです。Aspose.Slides for .NET が PPTX でサポートするロックの種類は以下の通りです：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) はコネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) はグラフィカル オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) はグループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) は画像フレームをロックします。  

すべてのシェイプ オブジェクトに対して行われた操作は、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) オブジェクト全体に適用され、プレゼンテーション全体に影響します。

## **保護の適用と解除**

保護を適用すると、プレゼンテーションを編集できなくなります。これはプレゼンテーションの内容を保護する有用な手法です。

### **PPTX シェイプへの保護適用**

Aspose.Slides for .NET はスライド上のシェイプを操作するための[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを提供します。

前述のとおり、各シェイプ クラスには保護用のシェイプ ロック クラスが関連付けられています。この記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックにより、シェイプは選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできなくなります。

以下のコード サンプルは、プレゼンテーション内のすべてのシェイプ タイプに保護を適用します。
```cs
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("Sample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
foreach (ISlide slide in presentation.Slides)
{
    // スライド内のすべてのシェイプを走査します。
    foreach (IShape shape in slide.Shapes)
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

// プレゼンテーション ファイルを保存します。
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **保護の解除**

シェイプのロックを解除するには、適用されたロックの値を `false` に設定します。以下のコード サンプルは、ロックされたプレゼンテーション内のシェイプのロックを解除する方法を示しています。
```cs
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
foreach (ISlide slide in presentation.Slides)
{
    // スライド内のすべてのシェイプを走査します。
    foreach (IShape shape in slide.Shapes)
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

// プレゼンテーション ファイルを保存します。
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **結論**

Aspose.Slides では、プレゼンテーション内のシェイプを保護するためのさまざまなオプションが提供されています。個々のシェイプをロックすることも、プレゼンテーション内のすべてのシェイプを反復処理してそれぞれロックすることもでき、ファイル全体を効果的に保護できます。ロックの値を `false` に設定することで保護を解除できます。

## **FAQ**

**同じプレゼンテーションでシェイプ ロックとパスワード保護を組み合わせることはできますか？**

はい。ロックはファイル内のオブジェクトの編集を制限し、[password protection](/slides/ja/net/password-protected-presentation/) は開くことや変更を保存することへのアクセスを制御します。これらのメカニズムは相互補完的であり、一緒に機能します。

**特定のスライドだけ編集を制限し、他のスライドには影響させないことはできますか？**

はい。対象となるスライドのシェイプにロックを適用すれば、残りのスライドは引き続き編集可能です。

**シェイプ ロックはグループ化されたオブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィック オブジェクト、その他のシェイプ種別に対して専用のロック タイプがサポートされています。