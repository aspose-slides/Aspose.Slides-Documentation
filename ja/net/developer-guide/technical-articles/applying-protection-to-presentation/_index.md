---
title: プレゼンテーションへの保護の適用
type: docs
weight: 70
url: /ja/net/applying-protection-to-presentation/
--- 

{{% alert color="primary" %}} 

Aspose.Slidesの一般的な使用法は、Microsoft PowerPoint 2007 (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。このようにAspose.Slidesを使用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。それらを編集から保護することは一般的な懸念です。自動生成されたプレゼンテーションが元のフォーマットと内容を保持することは重要です。

この記事では、[プレゼンテーションとスライドがどのように構成されるか](/slides/ja/net/applying-protection-to-presentation/)と、Aspose.Slides for .NETが[どのように保護を適用するか](/slides/ja/net/applying-protection-to-presentation/)、その後[どのように保護を解除するか](/slides/ja/net/applying-protection-to-presentation/)を説明します。この機能はAspose.Slidesに特有であり、この記事執筆時点ではMicrosoft PowerPointでは利用できません。これにより、開発者は自分のアプリケーションが作成するプレゼンテーションがどのように使用されるかを制御する方法を提供します。

{{% /alert %}} 
## **スライドの構成**
PPTXスライドは、オートシェイプ、表、OLEオブジェクト、グループ化されたシェイプ、ピクチャーフレーム、ビデオフレーム、コネクタ、その他のさまざまな要素によって構成されています。

Aspose.Slides for .NETでは、スライド上の各要素はShapeオブジェクトに変換されます。言い換えれば、スライド上の各要素はShapeオブジェクトか、Shapeオブジェクトから派生したオブジェクトです。

PPTXの構造は複雑で、PPTのようにすべての種類のシェイプに対して一般的なロックを使用することはできません。異なるシェイプのタイプには異なる種類のロックがあります。BaseShapeLockクラスは、一般的なPPTXロッククラスです。Aspose.Slides for .NETでは、PPTXに対して以下の種類のロックがサポートされています。

- AutoShapeLockはオートシェイプをロックします。
- ConnectorLockはコネクタシェイプをロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループシェイプをロックします。
- PictureFrameLockはピクチャーフレームをロックします。

プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されるアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と解除**
保護を適用することは、プレゼンテーションが編集できないようにすることを保証します。これは、プレゼンテーションの内容を保護するための有用な技術です。
### **PPTXシェイプへの保護の適用**
Aspose.Slides for .NETは、スライド上のシェイプを扱うためのShapeクラスを提供します。

前述のように、各シェイプクラスには保護用の関連するシェイプロッククラスがあります。この記事では、NoSelect、NoMove、NoResizeロックに焦点を当てています。これらのロックは、シェイプを選択できない（マウスのクリックや他の選択方法を通じて）ようにし、移動したりサイズ変更を行ったりできないことを保証します。

以下のコードサンプルは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。

```c#
//PPTXファイルを表すPresentationクラスのインスタンス化
Presentation pTemplate = new Presentation("RectPicFrame.pptx");

//プレゼンテーション内のスライドにアクセスするためのISlideオブジェクト
ISlide slide = pTemplate.Slides[0];

//一時的なシェイプを保持するためのIShapeオブジェクト
IShape shape;

//プレゼンテーション内のすべてのスライドを巡回
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //スライド内のすべてのシェイプを巡回
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //シェイプがオートシェイプの場合
        if (shape is IAutoShape)
        {
            //オートシェイプにキャストしてオートシェイプロックを取得
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //シェイプロックを適用
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //シェイプがグループシェイプの場合
        else if (shape is IGroupShape)
        {
            //グループシェイプにキャストしてグループシェイプロックを取得
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //シェイプロックを適用
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //シェイプがコネクタの場合
        else if (shape is IConnector)
        {
            //コネクタシェイプにキャストしてコネクタシェイプロックを取得
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //シェイプロックを適用
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //シェイプがピクチャーフレームの場合
        else if (shape is IPictureFrame)
        {
            //ピクチャーフレームシェイプにキャストしてピクチャーフレームシェイプロックを取得
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //シェイプロックを適用
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }
}

//プレゼンテーションファイルを保存
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **保護の解除**
Aspose.Slides for .NETを使用して適用された保護は、Aspose.Slides for .NETを使用してのみ解除できます。シェイプのロックを解除するには、適用されたロックの値をfalseに設定します。以下のコードサンプルは、ロックされたプレゼンテーション内のシェイプを解除する方法を示しています。

```c#
//目的のプレゼンテーションを開く
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//プレゼンテーション内のスライドにアクセスするためのISlideオブジェクト
ISlide slide = pTemplate.Slides[0];

//一時的なシェイプを保持するためのIShapeオブジェクト
IShape shape;

//プレゼンテーション内のすべてのスライドを巡回
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //スライド内のすべてのシェイプを巡回
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //シェイプがオートシェイプの場合
        if (shape is IAutoShape)
        {
            //オートシェイプにキャストしてオートシェイプロックを取得
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //シェイプロックを適用
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //シェイプがグループシェイプの場合
        else if (shape is IGroupShape)
        {
            //グループシェイプにキャストしてグループシェイプロックを取得
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //シェイプロックを適用
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //シェイプがコネクタシェイプの場合
        else if (shape is IConnector)
        {
            //コネクタシェイプにキャストしてコネクタシェイプロックを取得
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //シェイプロックを適用
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //シェイプがピクチャーフレームの場合
        else if (shape is IPictureFrame)
        {
            //ピクチャーフレームシェイプにキャストしてピクチャーフレームシェイプロックを取得
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //シェイプロックを適用
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }
}

//プレゼンテーションファイルを保存
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **まとめ**
{{% alert color="primary" %}} 

Aspose.Slidesは、プレゼンテーション内のシェイプに保護を適用するための多くのオプションを提供します。特定のシェイプをロックしたり、プレゼンテーション内のすべてのシェイプをループしてロックしたりして、実質的にプレゼンテーションをロックすることができます。

保護を解除できるのは、以前に保護されたプレゼンテーションから保護を解除するためのAspose.Slides for .NETだけです。ロックの値をfalseに設定することで保護を解除します。

{{% /alert %}} 