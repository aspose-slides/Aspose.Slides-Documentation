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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

## **パブリック API と後方互換性がない変更**
### **追加されたインターフェイス、クラス、メソッド、およびプロパティ**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides プロパティが追加されました**
Aspose.Slides.ILayoutSlide.HasDependingSlides プロパティは、このレイアウト スライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

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
Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) メソッドは、コレクションからレイアウトを削除します。コード例:

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
Aspose.Slides.ILayoutSlideCollection.RemoveUnused() メソッドは、未使用のレイアウト スライド (HasDependingSlides が false のレイアウト スライド) を削除します。コード例:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

または

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides プロパティ**
Aspose.Slides.IMasterSlide.HasDependingSlides プロパティは、このマスタースライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

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
Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat プロパティは、レイアウトが箇条書きを提供している場合に SmartArt ノードの箇条書きの IFillFormat を返します。箇条書き画像の設定に使用できます。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level プロパティ**
Aspose.Slides.SmartArt.ISmartArtNode.Level プロパティは、SmartArt ノードのネスト レベルを返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position プロパティ**
Aspose.Slides.SmartArt.ISmartArtNode.Position プロパティは、兄弟ノード間でのノードの位置を返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() メソッドが追加されました**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() メソッドは、ダイアグラムからノードを削除できます。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection インターフェイスおよび GlobalLayoutSlideCollection クラス**
IGlobalLayoutSlideCollection インターフェイスと GlobalLayoutSlideCollection クラスが Aspose.Slides 名前空間に追加されました。

GlobalLayoutSlideCollection クラスは IGlobalLayoutSlideCollection インターフェイスを実装します。

IGlobalLayoutSlideCollection インターフェイスは、プレゼンテーション内のすべてのレイアウト スライドのコレクションを表します。IPresentation.LayoutSlides プロパティの型は IGlobalLayoutSlideCollection です。IGlobalLayoutSlideCollection は ILayoutSlideCollection を拡張し、マスターの個別レイアウト スライド コレクションを統合するコンテキストでレイアウト スライドを追加およびクローンするメソッドを提供します。

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 指定したレイアウト スライドのコピーをプレゼンテーションに追加できます。このメソッドは元の書式設定を保持します (異なるプレゼンテーション間でレイアウトをクローンする場合、レイアウトのマスターもクローンされます)。内部レジストリは自動的にクローンされたマスターを追跡し、同じマスタースライドの重複クローン作成を防止します。
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 指定したレイアウト スライドのコピーをプレゼンテーションに追加し、新しいレイアウトを宛先プレゼンテーションの指定マスターにリンクします。このオプションは、Microsoft PowerPoint の **Use Destination Theme** オプションを使用したコピー/貼り付けと同等です。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 新しいレイアウト スライドをプレゼンテーションに追加します。サポートされるレイアウト タイプ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom。レイアウト名は自動生成可能です。SlideLayoutType.Custom のレイアウトにはプレースホルダーもシェイプも含まれません。このメソッドの類似は、IMasterSlide.LayoutSlides プロパティでアクセスできる IMasterLayoutSlideCollection.Add(SlideLayoutType, string) メソッドです。
#### **Interface IMasterLayoutSlideCollection と class MasterLayoutSlideCollection**
IMasterLayoutSlideCollection インターフェイスと MasterLayoutSlideCollection クラスが Aspose.Slides 名前空間に追加されました。MasterLayoutSlideCollection クラスは IMasterLayoutSlideCollection インターフェイスを実装します。

IMasterLayoutSlideCollection インターフェイスは、特定のマスタースライドに属するすべてのレイアウト スライドのコレクションを表します。ILayoutSlideCollection を拡張し、マスターの個別レイアウト スライド コレクションのコンテキストでレイアウト スライドを追加、挿入、削除、クローンするメソッドを提供します。

``` csharp

 // メソッド シグネチャ:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// ソースレイアウトのコピーを destMasterSlide に添付するコード例:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

このメソッドは、指定されたレイアウト スライドのコピーをコレクションの末尾に追加できます。新しいレイアウトはこのレイアウト スライド コレクションの親マスタースライドにリンクされます。したがって、PowerPoint の **Use Destination Theme** オプションを使用したコピー/貼り付けと同等です。このメソッドの類似は、IPresentation.LayoutSlides プロパティでアクセスできる IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) メソッドです。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 指定した位置にレイアウト コピーを挿入します。新しいレイアウトは親マスタースライドにリンクされ、PowerPoint の **Use Destination Theme** オプションを使用したコピー/貼り付けと同等です。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 新しいレイアウト スライドを追加または挿入します。サポートされるレイアウト タイプは上記と同じです。レイアウト名は自動生成可能です。SlideLayoutType.Custom のレイアウトにはプレースホルダーもシェイプも含まれません。このメソッドの類似は、IPresentation.LayoutSlides プロパティでアクセスできる IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) メソッドです。
- void RemoveAt(int index); – 指定インデックスのレイアウトを削除します。
- void Reorder(int index, ILayoutSlide layoutSlide); – コレクション内のレイアウト スライドを指定位置に移動します。
### **変更されたメソッドおよびプロパティ**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) メソッドのシグネチャ**
ISlideCollection メソッドのシグネチャ:

``` csharp

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

``` 

は廃止され、以下のシグネチャに置き換えられました。

``` csharp

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

``` 

allowCloneMissingLayout パラメーターは、宛先マスターに新しい（クローンされた）スライドに適合するレイアウトが存在しない場合の動作を指定します。適合レイアウトとは、ソーススライドと同じタイプまたは名前のレイアウトです。指定マスターに適合レイアウトがない場合、allowCloneMissingLayout が true のときはレイアウトがクローンされ、false のときは PptxEditException がスローされます。

廃止された呼び出し例:

``` csharp

AddClone(sourceSlide, destMaster);

``` 

は allowCloneMissingLayout が false とみなされます (適合レイアウトが無い場合は例外がスローされます)。新しいシグネチャを使用した同等の呼び出しは次のとおりです:

``` csharp

AddClone(sourceSlide, destMaster, false);

``` 

レイアウトが自動的にクローンされ、例外がスローされないようにしたい場合は、allowCloneMissingLayout に true を渡してください。

同様に ISlideCollection メソッド:

``` csharp

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

``` 

も廃止され、以下のシグネチャに置き換えられました。

``` csharp

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);

``` 
#### **Aspose.Slides.IMasterSlide.LayoutSlides プロパティの型**
Aspose.Slides.IMasterSlide.LayoutSlides プロパティの型は ILayoutSlideCollection から新しい IMasterLayoutSlideCollection インターフェイスに変更されました。IMasterLayoutSlideCollection は ILayoutSlideCollection の派生なので、既存コードの変更は不要です。
#### **Aspose.Slides.IPresentation.LayoutSlides プロパティの型が変更されました**
Aspose.Slides.IPresentation.LayoutSlides プロパティの型は ILayoutSlideCollection から新しい IGlobalLayoutSlideCollection インターフェイスに変更されました。IGlobalLayoutSlideCollection は ILayoutSlideCollection の派生なので、既存コードの変更は不要です。