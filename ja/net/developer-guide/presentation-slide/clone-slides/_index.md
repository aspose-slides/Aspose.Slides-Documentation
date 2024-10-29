---
title: スライドの複製
type: docs
weight: 40
url: /ja/net/clone-slides/
keywords: "スライドの複製, スライドのコピー, スライドコピーの保存, PowerPoint, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で PowerPoint スライドを複製する"
---

## **プレゼンテーションにおけるスライドの複製**
複製とは、何かの正確なコピーまたはレプリカを作成するプロセスです。Aspose.Slides for .NET では、任意のスライドのコピーまたは複製を作成し、それを現在または他の開いているプレゼンテーションに挿入することが可能です。スライドの複製プロセスにより、元のスライドを変更することなく、開発者が修正できる新しいスライドが作成されます。スライドを複製するためのいくつかの方法があります：

- プレゼンテーションの末尾に複製する。
- プレゼンテーション内の別の位置に複製する。
- 別のプレゼンテーションの末尾に複製する。
- 別のプレゼンテーションの別の位置に複製する。
- 別のプレゼンテーションの特定の位置に複製する。

Aspose.Slides for .NET では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトによって公開される [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) オブジェクトのコレクションが [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) および [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを提供し、上記のスライド複製のタイプを実行します。

## **プレゼンテーション内の末尾に複製する**
スライドを複製し、既存のスライドの末尾で同じプレゼンテーションファイル内で使用する場合は、以下のステップに従って [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開するスライドコレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスをインスタンス化します。
1. 複製するスライドをパラメーターとして [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドに渡し、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトによって公開される [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出します。
1. 修正したプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置 (ゼロインデックス) にあるスライドをプレゼンテーションの末尾に複製しました。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{
    // 同じプレゼンテーションのスライドコレクションの末尾に目的のスライドを複製
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 修正されたプレゼンテーションをディスクに書き込む
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーション内の別の位置に複製する**
スライドを複製し、同じプレゼンテーションファイル内で異なる位置に使用する場合は、[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。
1. 複製するスライドと新しい位置のインデックスをパラメーターとして [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドに渡し、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトによって公開される [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出します。
1. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス (位置 1) にあるスライドをインデックス 1 (位置 2) に複製しました。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{
    // 同じプレゼンテーションのスライドコレクションの末尾に目的のスライドを複製
    ISlideCollection slds = pres.Slides;

    // 同じプレゼンテーションの指定したインデックスに目的のスライドを複製
    slds.InsertClone(2, pres.Slides[1]);

    // 修正されたプレゼンテーションをディスクに書き込む
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
}
```

## **別のプレゼンテーションの末尾に複製する**
別のプレゼンテーションからスライドを複製し、別のプレゼンテーションファイルで既存のスライドの末尾で使用する必要がある場合：

1. 複製元のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを追加するための宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する **Slides** コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスをインスタンス化します。
1. 複製元プレゼンテーションのスライドを [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドにパラメーターとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを宛先プレゼンテーションの末尾に複製しました。

```c#
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 複製先の PPTX (スライドが複製される場所) のために Presentation クラスをインスタンス化
    using (Presentation destPres = new Presentation())
    {
        // 複製するためにソースプレゼンテーションから目的のスライドを宛先プレゼンテーションのスライドコレクションの末尾に複製
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに書き込む
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **別のプレゼンテーションの別の位置に複製する**
一つのプレゼンテーションからスライドを複製し、別のプレゼンテーションファイルの特定の位置で使用する必要がある場合：

1. スライドを複製元とするソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを追加するためのプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する Slides コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスをインスタンス化します。
1. 複製元プレゼンテーションからスライドと希望する位置を取得し、[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) メソッドを呼び出します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを宛先プレゼンテーションのインデックス 1 (位置 2) に複製しました。

```c#
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 複製先の PPTX (スライドが複製される場所) のために Presentation クラスをインスタンス化
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに書き込む
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **別のプレゼンテーションの特定の位置に複製する**
マスタースライドを持つスライドを一つのプレゼンテーションから複製し、別のプレゼンテーションで使用する必要がある場合、まず、ソースプレゼンテーションから目的のマスタースライドを宛先プレゼンテーションに複製する必要があります。その後、そのマスタースライドを使用してマスタースライドを持つスライドを複製する必要があります。 **AddClone(ISlide, IMasterSlide)** は、ソースプレゼンテーションではなく宛先プレゼンテーションからのマスタースライドを期待します。マスターを持つスライドを複製するには、以下のステップに従ってください：

1. スライドを複製元とするソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドを複製先とする宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 複製するスライドとマスタースライドにアクセスします。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開するマスターコレクションを参照して [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) クラスをインスタンス化します。
1. [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、ソース PPTX から複製するマスターをパラメーターに渡します。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開するスライドコレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) オブジェクトによって公開される [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを呼び出し、複製するソースプレゼンテーションのスライドとマスタースライドをパラメーターとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスターを持つスライドを宛先プレゼンテーションの末尾に複製しました。

```c#
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 複製先のプレゼンテーション (スライドが複製される場所) のために Presentation クラスをインスタンス化
    using (Presentation destPres = new Presentation())
    {
        // ソースプレゼンテーションのスライドのコレクションから
        // マスタースライドと共に ISlide をインスタンス化
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 所望のマスタースライドをソースプレゼンテーションから宛先プレゼンテーションのマスターコレクションに複製
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 所望のマスタースライドをソースプレゼンテーションから宛先プレゼンテーションのマスターコレクションに複製
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 所望のマスタースライドを持つソースプレゼンテーションから
        // 宛先プレゼンテーションのスライドコレクションの末尾に目的のスライドを複製
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 宛先プレゼンテーションをディスクに保存
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    }
}
```

## 指定されたセクションの末尾に複製する

Aspose.Slides for .NET を使用すると、プレゼンテーションの一つのセクションからスライドを複製し、そのスライドを同じプレゼンテーション内の別のセクションに挿入できます。この場合、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェースからの [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) メソッドを使用する必要があります。

以下の C# コードは、スライドを複製し、複製されたスライドを指定されたセクションに挿入する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 複製するため
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```