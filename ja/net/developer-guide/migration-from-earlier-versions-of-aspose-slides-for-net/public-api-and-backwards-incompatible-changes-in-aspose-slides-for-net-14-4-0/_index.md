---
title: Aspose.Slides for .NET 14.4.0におけるパブリックAPIおよび後方互換性のない変更
type: docs
weight: 60
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **パブリックAPIおよび後方互換性のない変更**
### **追加されたインターフェイス、クラス、メソッド、およびプロパティ**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlidesプロパティが追加されました**
Aspose.Slides.ILayoutSlide.HasDependingSlidesプロパティは、このレイアウトスライドに依存するスライドが少なくとも1つ存在する場合にtrueを返します。例えば：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove()メソッド**
Aspose.Slides.ILayoutSlide.Remove()メソッドは、最小限のコードでプレゼンテーションからレイアウトを削除することを可能にします。例えば：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)メソッド**
Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)メソッドを使用すると、コレクションからレイアウトを削除できます。コード例：

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
Aspose.Slides.ILayoutSlideCollection.RemoveUnused()メソッドを使用すると、未使用のレイアウトスライド（HasDependingSlidesがfalseのレイアウトスライド）を削除できます。コード例：

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

または

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlidesプロパティ**
Aspose.Slides.IMasterSlide.HasDependingSlidesプロパティは、このマスタースライドに依存するスライドが少なくとも1つ存在する場合にtrueを返します。例えば：

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove()メソッド**
Aspose.Slides.ISlide.Remove()メソッドは、最小限のコードでプレゼンテーションからスライドを削除することを可能にします。例えば：

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormatプロパティは、レイアウトが弾丸を提供する場合、SmartArtノードの弾丸用のIFillFormatを返します。弾丸画像を設定するために使用できます。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Levelプロパティ**
Aspose.Slides.SmartArt.ISmartArtNode.Levelプロパティは、SmartArtノードのネストレベルを返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "最初のレベル";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Positionプロパティ**
Aspose.Slides.SmartArt.ISmartArtNode.Positionプロパティは、ノードの兄弟の中での位置を返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove()メソッドが追加されました**
Aspose.Slides.SmartArt.ISmartArtNode.Remove()メソッドを使用すると、図からノードを削除できます。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollectionインターフェイスとGlobalLayoutSlideCollectionクラス**
IGlobalLayoutSlideCollectionインターフェイスとGlobalLayoutSlideCollectionクラスがAspose.Slides名前空間に追加されました。

GlobalLayoutSlideCollectionクラスは、IGlobalLayoutSlideCollectionインターフェイスを実装しています。

IGlobalLayoutSlideCollectionインターフェイスは、プレゼンテーション内のすべてのレイアウトスライドのコレクションを表します。IPresentation.LayoutSlidesプロパティは、IGlobalLayoutSlideCollection型です。IGlobalLayoutSlideCollectionは、マスターのレイアウトスライドの個別コレクションを統合する文脈でレイアウトスライドを追加および複製するためのメソッドを持つILayoutSlideCollectionインターフェイスを拡張します：

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 指定したレイアウトスライドのコピーをプレゼンテーションに追加するために使用できます。このメソッドは、元の書式を保持します（異なるプレゼンテーション間でレイアウトを複製する場合、レイアウトのマスターも複製される可能性があります。内部レジストリは、自動的に複製されたマスターを追跡して、同じマスタースライドの複数の複製を作成するのを防ぎます）。
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 指定したレイアウトスライドのコピーをプレゼンテーションに追加するために使用されます。新しいレイアウトは、宛先プレゼンテーションの定義されたマスターにリンクされます。このオプションは、Microsoft PowerPointの「宛先テーマの使用」オプションでコピーまたは貼り付けするのと類似しています。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – プレゼンテーションに新しいレイアウトスライドを追加するために使用されます。サポートされるレイアウトタイプ：タイトル、タイトルのみ、空白、タイトルとオブジェクト、縦書きテキスト、縦書きタイトルとテキスト、2つのオブジェクト、セクションヘッダー、2つのテキストと2つのオブジェクト、タイトルオブジェクトとキャプション、画像とキャプション、カスタム。レイアウト名は自動的に生成される場合があります。タイプがSlideLayoutType.Customの追加されたレイアウトは、プレースホルダーや形状が含まれていません。このメソッドの類似品は、IMasterSlide.LayoutSlidesプロパティを使用してアクセスされるIMasterLayoutSlideCollection.Add(SlideLayoutType, string)メソッドです。
#### **インターフェイスIMasterLayoutSlideCollectionとクラスMasterLayoutSlideCollection**
IMasterLayoutSlideCollectionインターフェイスとMasterLayoutSlideCollectionクラスがAspose.Slides名前空間に追加されました。MasterLayoutSlideCollectionクラスは、IMasterLayoutSlideCollectionインターフェイスを実装しています。

IMasterLayoutSlideCollectionインターフェイスは、定義されたマスタースライドのすべてのレイアウトスライドのコレクションを表します。個々のマスターレイアウトスライドのコレクションの文脈内でレイアウトスライドを追加、挿入、削除、または複製するためのメソッドを使用して、ILayoutSlideCollectionインターフェイスを拡張しています：

``` csharp

 // メソッドシグネチャ：

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// sourceLayoutのコピーをdestMasterSlideに追加するコード例：

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

このメソッドを使用して、指定されたレイアウトスライドのコピーをコレクションの末尾に追加できます。新しいレイアウトは、このレイアウトスライドコレクションの親マスタースライドにリンクされます。したがって、これはPowerPointの「宛先テーマの使用」オプションでコピーまたは貼り付けするのと類似しています。このメソッドの類似品は、IPresentation.LayoutSlidesプロパティを介してアクセスされるIGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide)メソッドです。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 指定された位置に指定されたレイアウトスライドのコピーを挿入するために使用されます。新しいレイアウトは、このレイアウトスライドコレクションの親マスタースライドにリンクされます。したがって、これはPowerPointの「宛先テーマの使用」オプションでコピーおよび貼り付けするのと類似しています。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 新しいレイアウトスライドを追加または挿入するために使用されます。サポートされるレイアウトタイプ：タイトル、タイトルのみ、空白、タイトルとオブジェクト、縦書きテキスト、縦書きタイトルとテキスト、2つのオブジェクト、セクションヘッダー、2つのテキストと2つのオブジェクト、タイトルオブジェクトとキャプション、画像とキャプション、カスタム。レイアウト名は自動的に生成される場合があります。追加されたSlideLayoutType.Custom型のレイアウトには、プレースホルダーや形状が含まれていません。このメソッドの類似品は、IPresentation.LayoutSlidesプロパティを使用してアクセスされるIGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string)メソッドです。
- void RemoveAt(int index); – 指定されたインデックスのレイアウトをコレクションから削除するために使用されます。
- void Reorder(int index, ILayoutSlide layoutSlide); – コレクションから指定された位置にレイアウトスライドを移動するために使用されます。
### **変更されたメソッドおよびプロパティ**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)メソッドのシグネチャ**
ISlideCollectionメソッドのシグネチャは次のように古くなりました：
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

現在は次のシグネチャに置き換えられました：

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayoutパラメーターは、新しい（複製された）スライドのためにdestMasterに適切なレイアウトがない場合の対処方法を指定します。適切なレイアウトとは、ソーススライドのレイアウトと同じタイプまたは名前を持つレイアウトです。指定されたマスターに適切なレイアウトがない場合、ソーススライドのレイアウトが複製され（allowCloneMissingLayoutがtrueの場合）、PptxEditExceptionがスローされます（allowCloneMissingLayoutがfalseの場合）。

古いメソッドの呼び出しは次のようになります：

AddClone(sourceSlide, destMaster);

これはallowCloneMissingLayoutがfalseになることを想定しています（すなわち、適切なレイアウトがない場合、PptxEditExceptionがスローされます）。機能的に同等の新しいシグネチャを使用した呼び出しは次のようになります：
AddClone(sourceSlide, destMaster, false);

欠落しているレイアウトをPptxEditExceptionをスローする代わりに自動的に複製するようにしたい場合は、allowCloneMissingLayoutパラメーターをtrueとして渡してください。

同様に、ISlideCollectionメソッド：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

も古くなっており、次のシグネチャに置き換えられました：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlidesプロパティの型**
Aspose.Slides.IMasterSlide.LayoutSlidesプロパティの型は、ILayoutSlideCollectionから新しいIMasterLayoutSlideCollectionインターフェイスに変更されました。IMasterLayoutSlideCollectionインターフェイスはILayoutSlideCollectionの子孫ですので、既存のコードに適応は必要ありません。
#### **Aspose.Slides.IPresentation.LayoutSlidesプロパティの型が変更されました**
Aspose.Slides.IPresentation.LayoutSlidesプロパティの型は、ILayoutSlideCollectionから新しいIGlobalLayoutSlideCollectionインターフェイスに変更されました。IGlobalLayoutSlideCollectionインターフェイスはILayoutSlideCollectionの子孫ですので、既存のコードに適応は必要ありません。