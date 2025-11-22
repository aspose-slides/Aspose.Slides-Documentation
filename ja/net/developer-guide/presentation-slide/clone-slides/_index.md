---
title: スライドのクローン
type: docs
weight: 40
url: /ja/net/clone-slides/
keywords: "スライドをクローン, スライドをコピー, スライドのコピーを保存, PowerPoint, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で PowerPoint スライドをクローン"
---

## **プレゼンテーション内のスライドをクローン**
クローン作成とは、何かを正確にコピーまたはレプリカにするプロセスです。Aspose.Slides for .NET では、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローン
- プレゼンテーション内の別の位置にクローン
- 別のプレゼンテーションの末尾にクローン
- 別のプレゼンテーションの別の位置にクローン
- 別のプレゼンテーションの特定の位置にクローン

Aspose.Slides for .NET では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する (ISlide オブジェクトのコレクション) が、上記のスライドクローン作成を実行するための [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) および [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを提供します。

## **プレゼンテーション内の末尾にクローン**
同じプレゼンテーションファイル内で、既存のスライドの末尾にクローンしたスライドを使用したい場合は、以下の手順に従って [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを取得します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
1. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの先頭位置（インデックス0）にあるスライドをプレゼンテーションの末尾にクローンしています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 変更されたプレゼンテーションをディスクに保存
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **プレゼンテーション内の別の位置にクローン**
同じプレゼンテーションファイル内で別の位置にクローンしたスライドを使用したい場合は、[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスのインスタンスを取得します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトが公開する [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス0（位置1）にあるスライドをインデックス1（位置2）にクローンしています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.Slides;

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    slds.InsertClone(2, pres.Slides[1]);

    // 変更されたプレゼンテーションをディスクに保存
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **別のプレゼンテーションの末尾にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に追加したい場合は、次の手順を実行します。

1. スライドのクローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドのクローン先となる目的のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 目的プレゼンテーションの Presentation オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを取得します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメーターとして渡します。
1. 変更された目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの先頭インデックスにあるスライドを目的プレゼンテーションの末尾にクローンしています。
```c#
// ソースプレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
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


## **別のプレゼンテーションの別の位置にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に挿入したい場合は、次の手順を実行します。

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを追加したいプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを取得します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトが公開する [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置をパラメーターとして渡します。
1. 変更された目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0（位置1）にあるスライドを目的プレゼンテーションのインデックス1（位置2）にクローンしています。
```c#
// ソースプレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドがクローンされる先の PPTX 用に Presentation クラスをインスタンス化
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **別のプレゼンテーションの特定の位置にクローン（マスタースライド付き）**
マスタースライドを持つスライドをあるプレゼンテーションから別のプレゼンテーションにクローンしたい場合、まずソースプレゼンテーションから目的プレゼンテーションにマスタースライドをクローンする必要があります。その後、マスタースライドを使用してスライドをクローンします。**AddClone(ISlide, IMasterSlide)** は、ソースプレゼンテーションではなく目的プレゼンテーションのマスタースライドを受け取ります。マスタースライド付きスライドをクローンする手順は以下の通りです。

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドのクローン先となる目的プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. クローン対象のスライドとマスタースライドにアクセスします。
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) クラスのインスタンスを取得します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスのインスタンスを取得します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスタースライドをパラメーターとして渡します。
1. 変更された目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるマスタースライド付きスライドを、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしています。
```c#
// ソースプレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // スライドがクローンされる宛先プレゼンテーション用に Presentation クラスをインスタンス化
    using (Presentation destPres = new Presentation())
    {

        // ソースプレゼンテーションのスライドコレクションから ISlide をインスタンス化し、 
        // マスタースライド
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドをマスターのコレクションにクローン
        // 宛先プレゼンテーション
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドをマスターのコレクションにクローン
        // 宛先プレゼンテーション
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // ソースプレゼンテーションから目的のマスタースライドを使用してスライドを末尾にクローン
        // 宛先プレゼンテーションのスライドコレクション
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // ソースプレゼンテーションから目的のマスタースライドをマスターのコレクションにクローン // 宛先プレゼンテーション
        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **指定セクションの末尾にクローン**
Aspose.Slides for .NET を使用すると、プレゼンテーションのあるセクションからスライドをクローンし、同じプレゼンテーション内の別のセクションに挿入できます。この場合、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェイスの [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用します。

以下の C# コードは、スライドをクローンし、指定セクションに挿入する方法を示しています。
```c#
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


## **よくある質問**

**スピーカーノートやレビューコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/net/presentation-notes/) してください。

**グラフとそのデータソースはどう扱われますか？**

グラフオブジェクト、書式設定、埋め込みデータはコピーされます。グラフが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/net/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と再取得動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [section](/slides/ja/net/slide-section/) に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。