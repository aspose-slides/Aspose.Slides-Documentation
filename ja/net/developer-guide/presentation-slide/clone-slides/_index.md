---
title: .NET でプレゼンテーションスライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/net/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドをすばやく複製します。明確なコード例に従って、数秒で PPT 作成を自動化し、手作業を不要にします。"
---
## **はじめに**

クローン作成とは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides では任意のスライドをコピー（クローン）し、クローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することもできます。スライドのクローン作成により、元のスライドに影響を与えずに開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります：

- プレゼンテーションの末尾にクローンする。
- 同一プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーション内の別の位置にクローンする。
- マスタースライドと共に別のプレゼンテーションにクローンする。

Aspose.Slides for .NET では、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) オブジェクトが公開するスライドコレクション（[ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/) オブジェクトのコレクション）に、上記のスライドクローン操作を実行するための [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) および [InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/insertclone/) メソッドが用意されています。

## **プレゼンテーションの末尾にスライドをクローンする**

同一プレゼンテーションファイル内で既存のスライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
1. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置（インデックス0）にあるスライドをプレゼンテーションの末尾にクローンしました。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 変更されたプレゼンテーションをディスクに保存
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **プレゼンテーション内の別の位置にスライドをクローンする**
同一プレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) オブジェクトが提供する [InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス1（位置2）にあるスライドをインデックス2（位置3）にクローンしました。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.Slides;

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    slds.InsertClone(2, pres.Slides[1]);

    // 変更されたプレゼンテーションをディスクに保存
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存のスライドの末尾に使用する必要がある場合は、以下の手順を実行します。

1. スライドをクローン元とするプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを追加先とする宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの Presentation オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメーターとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの最初のインデックスにあるスライドを宛先プレゼンテーションの末尾にクローンしました。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ソースプレゼンテーションファイルを読み込むための Presentation クラスのインスタンスを作成
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成
    using (Presentation destPres = new Presentation())
    {
        // ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローン
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **別のプレゼンテーション内の別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用する必要がある場合は、以下の手順を実行します。

1. スライドをクローン元とするソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを追加先とするプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) オブジェクトが提供する [InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置をパラメーターとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるスライドを宛先プレゼンテーションのインデックス1（位置2）にクローンしました。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ソースプレゼンテーションファイルを読み込むための Presentation クラスのインスタンスを作成
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **マスタースライド付きでスライドを別のプレゼンテーションにクローンする**
あるプレゼンテーションからマスタースライド付きのスライドをクローンし、別のプレゼンテーションで使用する必要がある場合、まずソースプレゼンテーションから目的のマスタースライドを宛先プレゼンテーションにクローンする必要があります。その後、マスタースライドを使用してスライドをクローンします。**AddClone(ISlide, IMasterSlide)** は、ソースではなく宛先プレゼンテーションのマスタースライドを期待します。マスタースライド付きでスライドをクローンするには、以下の手順に従ってください。

1. スライドをクローン元とするソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドをクローン先とする宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. クローン対象のスライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection) クラスのインスタンスを作成します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) オブジェクトが公開する Slides コレクションへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソースプレゼンテーションからクローンするスライドとマスタースライドをパラメーターとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるマスタースライド付きスライドを、ソーススライドのマスターを使用して宛先プレゼンテーションの末尾にクローンしました。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ソースプレゼンテーションファイルを読み込むための Presentation クラスのインスタンスを作成

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // スライドをクローンする先のプレゼンテーション用に Presentation クラスのインスタンスを作成
    using (Presentation destPres = new Presentation())
    {

        // ソースプレゼンテーションのスライドコレクションから ISlide をインスタンス化し、 
        // マスタースライドも取得
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドを取得し、 
        // 宛先プレゼンテーションのマスターコレクションにクローン
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドを取得し、 
        // 宛先プレゼンテーションのマスターコレクションにクローン
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // ソースプレゼンテーションの目的のスライドを、目的のマスターと共に、 
        // 宛先プレゼンテーションのスライドコレクションの末尾にクローン
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // ソースプレゼンテーションから目的のマスタースライドを取得し、宛先プレゼンテーションのマスターコレクションにクローン // 宛先プレゼンテーション
        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **指定セクションの末尾にスライドをクローンする**

Aspose.Slides for .NET では、プレゼンテーションのあるセクションからスライドをクローンし、同じプレゼンテーション内の別のセクションに挿入できます。この場合、[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) インターフェイスの [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用する必要があります。

以下の C# コードは、スライドをクローンし、指定されたセクションにクローンしたスライドを挿入する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // クローンするため
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **スライドサイズの一致を確保する**

スライドを別のプレゼンテーションにクローンする際は、宛先プレゼンテーションがソースと同じスライドサイズであることを確認してください。スライドサイズが異なる場合、Aspose.Slides はクローンされたシェイプのサイズを自動的に再スケーリングせず、元の座標とサイズのまま保持するため、コンテンツがずれたりスライド境界を超えて表示される可能性があります。

マスターとスライドをクローンする前に、宛先プレゼンテーションのスライドサイズをソースに合わせて設定できます。

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

マスターとスライドをクローンする前に実行してください。

## **FAQ**

**スピーカーノートおよびレビュアーコメントはクローンされますか？**

はい。ノートページとレビュアーコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/net/presentation-notes/)（削除）してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはすべてコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/net/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。クローンを特定のスライドインデックスに挿入し、選択した [section](/slides/ja/net/slide-section/) に配置できます。対象のセクションが存在しない場合は、まずセクションを作成し、スライドをその中に移動してください。