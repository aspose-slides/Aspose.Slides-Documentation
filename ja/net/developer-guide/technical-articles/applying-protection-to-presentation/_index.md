---
title: .NET のシェイプレックでプレゼンテーションの編集を防止
linktitle: プレゼンテーションの編集防止
type: docs
weight: 70
url: /ja/net/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプレック
- 位置ロック
- 選択ロック
- サイズロック
- グループ化ロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が PPT、PPTX、ODP ファイル内のシェイプをロックまたはアンロックする方法を確認し、プレゼンテーションを保護しつつ、制御された編集を可能にします。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することがよく求められます。自動生成されたプレゼンテーションが元の書式や内容を保持することが重要です。

この記事では、プレゼンテーションとスライドの構造と、Aspose.Slides for .NET でプレゼンテーションに保護を適用し、後で解除する方法を説明します。開発者は、アプリケーションが生成するプレゼンテーションの使用方法を制御できます。

## **スライドの構成**

プレゼンテーションスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ形状、画像フレーム、ビデオフレーム、コネクタ、その他の要素で構成されます。Aspose.Slides for .NET では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを実装するか、そこから継承したクラスのオブジェクトとして表現されます。

PPTX の構造は複雑で、PPT のようにすべての形状タイプに対して汎用ロックを使用できません。形状タイプごとに異なるロックが必要です。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) インターフェイスが PPTX 用の汎用ロッククラスです。Aspose.Slides for .NET が PPTX でサポートするロックの種類は次のとおりです。

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) はコネクタ形状をロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) はグラフィックオブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) はグループ形状をロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) オブジェクト内のすべての形状オブジェクトに対して実行される操作は、プレゼンテーション全体に適用されます。

## **保護の適用と解除**

保護を適用すると、プレゼンテーションを編集できなくなります。これはコンテンツを守るための有用な手法です。

### **PPTX 形状への保護の適用**

Aspose.Slides for .NET はスライド上の形状を操作するために [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスを提供します。

前述のとおり、各形状クラスには保護用の形状ロッククラスが対応しています。本稿では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックにより、形状を選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできなくなります。

以下のコードサンプルは、プレゼンテーション内のすべての形状タイプに保護を適用します。
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

形状のロックを解除するには、適用されたロックの値を `false` に設定します。次のコードサンプルは、ロックされたプレゼンテーション内の形状のロックを解除する方法を示しています。
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

Aspose.Slides はプレゼンテーション内の形状を保護するための複数のオプションを提供します。個々の形状にロックを設定することも、プレゼンテーション内のすべての形状を走査してそれぞれにロックを設定することで、ファイル全体を効果的に保護することもできます。ロックの値を `false` に設定すれば、保護を解除できます。

## **FAQ**

**同じプレゼンテーションで形状ロックとパスワード保護を組み合わせられますか？**

はい。ロックはファイル内部のオブジェクトの編集を制限し、[パスワード保護](/slides/ja/net/password-protected-presentation/) は開封や変更の保存に対するアクセスを制御します。これらのメカニズムは相補的に機能します。

**特定のスライドだけ編集を制限し、他のスライドはそのままにできますか？**

はい。選択したスライド上の形状にロックを適用すれば、残りのスライドは引き続き編集可能です。

**形状ロックはグループ化されたオブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィックオブジェクト、その他の形状種別に対応した専用のロックタイプがサポートされています。