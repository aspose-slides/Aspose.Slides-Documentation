---
title: Aspose.Slides for .NET 14.4.0 の公開 API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

## **パブリック API と下位互換性のない変更**
### **追加されたインターフェイス、クラス、メソッド、およびプロパティ**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides プロパティが追加されました**
このプロパティ Aspose.Slides.ILayoutSlide.HasDependingSlides は、このレイアウト スライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() メソッド**
Aspose.Slides.ILayoutSlide.Remove() メソッドを使用すると、最小限のコードでプレゼンテーションからレイアウトを削除できます。例:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) メソッド**
このメソッドは、コレクションからレイアウトを削除できます。コード例:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

または

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Aspose.Slides.ILayoutSlideCollection.RemoveUnused() メソッドを使用すると、未使用のレイアウト スライド（HasDependingSlides が false のレイアウト スライド）を削除できます。コード例:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

または

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides プロパティ**
このプロパティ Aspose.Slides.IMasterSlide.HasDependingSlides は、このマスター スライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() メソッド**
Aspose.Slides.ISlide.Remove() メソッドを使用すると、最小限のコードでプレゼンテーションからスライドを削除できます。例:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
このプロパティ Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat は、レイアウトが箇条書きを提供している場合に SmartArt ノードの箇条書きの IFillFormat を返します。箇条書き画像の設定に使用できます。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level プロパティ**
このプロパティ Aspose.Slides.SmartArt.ISmartArtNode.Level は、SmartArt ノードの入れ子レベルを返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position プロパティ**
このプロパティ Aspose.Slides.SmartArt.ISmartArtNode.Position は、同じ階層内でのノードの位置を返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() メソッドが追加されました**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() メソッドを使用すると、ダイアグラムからノードを削除できます。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection インターフェイスと GlobalLayoutSlideCollection クラス**
IGlobalLayoutSlideCollection インターフェイスと GlobalLayoutSlideCollection クラスが Aspose.Slides 名前空間に追加されました。

GlobalLayoutSlideCollection クラスは IGlobalLayoutSlideCollection インターフェイスを実装します。

IGlobalLayoutSlideCollection インターフェイスは、プレゼンテーション内のすべてのレイアウト スライドのコレクションを表します。IPresentation.LayoutSlides プロパティの型は IGlobalLayoutSlideCollection です。IGlobalLayoutSlideCollection は ILayoutSlideCollection インターフェイスを拡張し、マスターの個別レイアウト スライド コレクションを統合するコンテキストでレイアウト スライドを追加およびクローンするためのメソッドを提供します:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 指定したレイアウト スライドのコピーをプレゼンテーションに追加する際に使用できます。このメソッドは元の書式設定を保持します（異なるプレゼンテーション間でレイアウトをクローンする場合、レイアウトのマスターもクローンされます。内部レジストリは自動的にクローンされたマスターを追跡し、同一マスター スライドの複数クローン作成を防止します）。
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 指定したレイアウト スライドのコピーをプレゼンテーションに追加する際に使用します。新しいレイアウトは対象プレゼンテーションの指定マスターにリンクされます。このオプションは Microsoft PowerPoint の **Use Destination Theme** オプションを使用したコピー/貼り付けと同等です。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – プレゼンテーションに新しいレイアウト スライドを追加します。サポートされるレイアウト タイプ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom。レイアウト名は自動的に生成できます。SlideLayoutType.Custom のレイアウトはプレースホルダーもシェイプも含みません。このメソッドの類似は IMasterSlide.LayoutSlides プロパティでアクセスできる IMasterLayoutSlideCollection.Add(SlideLayoutType, string) メソッドです。
#### **Interface IMasterLayoutSlideCollection と class MasterLayoutSlideCollection**
IMasterLayoutSlideCollection インターフェイスと MasterLayoutSlideCollection クラスが Aspose.Slides 名前空間に追加されました。MasterLayoutSlideCollection クラスは IMasterLayoutSlideCollection インターフェイスを実装します。

IMasterLayoutSlideCollection インターフェイスは、特定のマスター スライドのすべてのレイアウト スライドのコレクションを表します。ILayoutSlideCollection インターフェイスを拡張し、マスターのレイアウト スライドの個別コレクション内でレイアウト スライドを追加、挿入、削除、またはクローンするためのメソッドを提供します:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

このメソッドは、指定したレイアウト スライドのコピーをコレクションの末尾に追加するために使用できます。新しいレイアウトはこのレイアウト スライド コレクションの親マスター スライドにリンクされます。したがって、PowerPoint の **Use Destination Theme** を使用したコピー/貼り付けと同等です。このメソッドの類似は IPresentation.LayoutSlides プロパティでアクセスできる IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) メソッドです。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 指定した位置にレイアウト スライドのコピーを挿入します。新しいレイアウトは親マスター スライドにリンクされます。PowerPoint の **Use Destination Theme** を使用したコピー/貼り付けと同等です。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 新しいレイアウト スライドを追加または挿入します。サポートされるレイアウト タイプは上記と同じです。レイアウト名は自動的に生成できます。SlideLayoutType.Custom のレイアウトはプレースホルダーもシェイプも含みません。このメソッドの類似は IPresentation.LayoutSlides プロパティでアクセスできる IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) メソッドです。
- void RemoveAt(int index); – 指定したインデックスのレイアウトを削除します。
- void Reorder(int index, ILayoutSlide layoutSlide); – コレクション内のレイアウト スライドを指定位置へ移動します。
### **変更されたメソッドとプロパティ**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) メソッドのシグネチャ**
ISlideCollection メソッドのシグネチャ:

``` csharp
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
```

は廃止され、以下のシグネチャに置き換えられました:

``` csharp
ISSlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
```

allowCloneMissingLayout パラメーターは、destMaster に新しい（クローンされた）スライド用の適切なレイアウトが存在しない場合の動作を指定します。適切なレイアウトとは、ソース スライドと同じタイプまたは名前のレイアウトです。指定されたマスターに適切なレイアウトがない場合、allowCloneMissingLayout が true のときはレイアウトがクローンされ（true）、false のときは PptxEditException がスローされます。

廃止された呼び出し:

``` csharp
AddClone(sourceSlide, destMaster);
```

は allowCloneMissingLayout が false と同等とみなされます（適切なレイアウトがない場合は PptxEditException がスローされます）。新しいシグネチャを使用した同等の呼び出しは次のとおりです:

``` csharp
AddClone(sourceSlide, destMaster, false);
```

レイアウトが自動的にクローンされ、例外がスローされないようにしたい場合は、allowCloneMissingLayout パラメーターを true に設定してください。

同様に、ISlideCollection メソッド:

``` csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
```

も廃止され、以下のシグネチャに置き換えられました:

``` csharp
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
```
#### **Aspose.Slides.IMasterSlide.LayoutSlides プロパティの型**
Aspose.Slides.IMasterSlide.LayoutSlides プロパティの型は ILayoutSlideCollection から新しい IMasterLayoutSlideCollection インターフェイスに変更されました。IMasterLayoutSlideCollection インターフェイスは ILayoutSlideCollection の子孫であるため、既存のコードは変更不要です。
#### **Aspose.Slides.IPresentation.LayoutSlides プロパティの型が変更されました**
Aspose.Slides.IPresentation.LayoutSlides プロパティの型は ILayoutSlideCollection から新しい IGlobalLayoutSlideCollection インターフェイスに変更されました。IGlobalLayoutSlideCollection インターフェイスは ILayoutSlideCollection の子孫であるため、既存のコードは変更不要です。