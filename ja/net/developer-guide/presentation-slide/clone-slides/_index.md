---
title: .NET でプレゼンテーションスライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/net/clone-slides/
keywords:
- スライドのクローン
- スライドのコピー
- スライドの保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って、数秒で PPT の作成を自動化し、手作業をなくしましょう。"
---

## **プレゼンテーション内のスライドをクローンする**
クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for .NET を使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、新しいスライドが生成され、開発者は元のスライドを変更せずにこのスライドを修正できます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for .NET では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトが公開する[ISlide]オブジェクトのコレクションを使用して、上記のスライドクローン作成タイプを実行するための[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)と[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)メソッドが提供されます。

## **プレゼンテーションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内で既存のスライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを使用してください。

1. [Presentation]クラスのインスタンスを作成します。
1. [Presentation]オブジェクトが公開するSlidesコレクションを参照して[ISlideCollection]クラスのインスタンスを作成します。
1. [ISlideCollection]オブジェクトが提供する[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを呼び出し、クローンするスライドをパラメーターとして渡します。
1. 変更されたプレゼンテーションファイルを書き出します。

下の例では、プレゼンテーションの先頭位置（インデックス0）にあるスライドをプレゼンテーションの末尾にクローンしています。
```c#
 // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローンします
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // 変更されたプレゼンテーションをディスクに保存します
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```


## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)メソッドを使用します。

1. [Presentation]クラスのインスタンスを作成します。
1. [Presentation]オブジェクトが公開する**Slides**コレクションを参照してクラスのインスタンスを作成します。
1. [ISlideCollection]オブジェクトが提供する[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)メソッドを呼び出し、クローンするスライドと新しい位置のインデックスをパラメーターとして渡します。
1. 変更されたプレゼンテーションをPPTXファイルとして書き出します。

下の例では、プレゼンテーションのインデックス0（位置1）にあるスライドをインデックス1（位置2）にクローンしています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローンします
    ISlideCollection slds = pres.Slides;

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンします
    slds.InsertClone(2, pres.Slides[1]);

    // 変更されたプレゼンテーションをディスクに保存します
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に使用する必要がある場合は、以下の手順に従います。

1. スライドのクローン元となるプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドを追加する対象のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. 対象プレゼンテーションのPresentationオブジェクトが公開する**Slides**コレクションを参照して[ISlideCollection]クラスのインスタンスを作成します。
4. [ISlideCollection]オブジェクトが提供する[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメーターとして渡します。
5. 変更された対象プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションの先頭インデックスにあるスライドを対象プレゼンテーションの末尾にクローンしています。
```c#
 // ソースのプレゼンテーションファイルを読み込むための Presentation クラスをインスタンス化します
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化します
    using (Presentation destPres = new Presentation())
    {
        // ソースプレゼンテーションから目的のスライドを取得し、先方プレゼンテーションのスライド コレクションの末尾にクローンします
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 先方プレゼンテーションをディスクに保存します
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの別の位置に使用する必要がある場合は、以下の手順に従います。

1. スライドのクローン元となるプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドを追加する対象のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. 対象プレゼンテーションのPresentationオブジェクトが公開するSlidesコレクションを参照して[ISlideCollection]クラスのインスタンスを作成します。
4. [ISlideCollection]オブジェクトが提供する[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置インデックスをパラメーターとして渡します。
5. 変更された対象プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションのインデックス0にあるスライドを対象プレゼンテーションのインデックス1（位置2）にクローンしています。
```c#
 // ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化します
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化します
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 宛先プレゼンテーションをディスクに保存します
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **別のプレゼンテーションの特定の位置にスライドをクローンする**
あるプレゼンテーションからマスタースライドを含むスライドをクローンし、別のプレゼンテーションで使用する必要がある場合は、まずソースプレゼンテーションから目的のマスタースライドを対象プレゼンテーションにクローンする必要があります。その後、そのマスタースライドを使用してマスタースライド付きのスライドをクローンします。**AddClone(ISlide, IMasterSlide)** はソースプレゼンテーションではなく、対象プレゼンテーションのマスタースライドを期待します。マスタースライド付きのスライドをクローンするには、以下の手順に従ってください。

1. スライドのクローン元となるソースプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドを追加する対象プレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. クローン対象のスライドとそのマスタースライドにアクセスします。
4. 対象プレゼンテーションのPresentationオブジェクトが公開するMastersコレクションを参照して[IMasterSlideCollection]クラスのインスタンスを作成します。
5. [IMasterSlideCollection]オブジェクトが提供する[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを呼び出し、ソースPPTXからクローンするマスターをパラメーターとして渡します。
6. 対象プレゼンテーションのPresentationオブジェクトが公開するSlidesコレクションを参照して[ISlideCollection]クラスのインスタンスを作成します。
7. [ISlideCollection]オブジェクトが提供する[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスタースライドをパラメーターとして渡します。
8. 変更された対象プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションのインデックス0にあるマスタースライド付きのスライドを、ソーススライドのマスターを使用して対象プレゼンテーションの末尾にクローンしています。
```c#
// ソース プレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化します

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // スライドをクローンする宛先プレゼンテーション用に Presentation クラスをインスタンス化します（スライドがクローンされる場所）
    using (Presentation destPres = new Presentation())
    {

        // ソースプレゼンテーションのスライド コレクションから ISlide を取得し、
        // マスタースライドも取得
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドをマスター コレクションへコピーします（
        // 宛先プレゼンテーション）
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // ソースプレゼンテーションから目的のマスタースライドをマスター コレクションへコピーします（
        // 宛先プレゼンテーション）
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // ソースプレゼンテーションの目的スライドと対象マスターを使用して、末尾にクローンします（
        // 宛先プレゼンテーションのスライド コレクション）
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // ソースプレゼンテーションから目的のマスタースライドをマスター コレクションへコピーします // 宛先プレゼンテーション
        // 宛先プレゼンテーションをディスクに保存します
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **指定したセクションの末尾にスライドをクローンする**
Aspose.Slides for .NET を使用すると、プレゼンテーションのあるセクションからスライドをクローンし、同じプレゼンテーション内の別のセクションに挿入できます。この場合、[ISlideCollection]インターフェイスの[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)メソッドを使用する必要があります。

このC#コードは、スライドをクローンして指定したセクションに挿入する方法を示しています。
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


## **FAQ**

**スピーカーノートとレビュアーコメントはクローンされますか？**
はい。ノートページとレビュコメントはクローンに含まれます。不要な場合は、挿入後に[remove them](/slides/ja/net/presentation-notes/)してください。

**チャートとそのデータソースはどのように扱われますか？**
チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（たとえばOLE埋め込みのワークブック）にリンクされている場合、そのリンクは[OLE object](/slides/ja/net/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**
はい。クローンを特定のスライドインデックスに挿入し、選択した[section](/slides/ja/net/slide-section/)に配置できます。対象のセクションが存在しない場合は、まずセクションを作成し、その後スライドを移動してください。