---
title: Aspose.Slides for .NET 14.5.0 の公開 API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 14.5.0 APIで導入されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)クラス、メソッド、プロパティなど、 新しい[制限](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)および他の[変更](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) を一覧表示します。

{{% /alert %}} 
## **公開 API と後方互換性のない変更**
### **追加されたインターフェイス、クラス、プロパティ、メソッド**
#### **Aspose.Slides.IPresentationInfo インターフェイス と PresentationInfo クラスを追加**
プレゼンテーションに関する情報を表します。

- ブール型プロパティ IsEncrypted は、プレゼンテーションが暗号化されている場合は True、そうでない場合は False を取得します。
- プロパティ LoadFormat はプレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.IsGrouped プロパティを追加**
Aspose.Slides.IShape.IsGrouped プロパティは、シェイプがグループ化されているかどうかを判定します。
#### **Aspose.Slides.IShape.ParentGroup プロパティを追加**
Aspose.Slides.IShape.ParentGroup プロパティは、シェイプがグループ化されている場合は親の GroupShape オブジェクトを返し、そうでない場合は null を返します。
#### **Aspose.Slides.IShapeCollection.AddGroupShape() メソッドを追加**
Aspose.Slides.IShapeCollection.AddGroupShape() メソッドは新しい GroupShape を作成し、コレクションの末尾に追加します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.Clear() メソッドを追加**
Aspose.Slides.IShapeCollection.Clear() メソッドはコレクションからすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドを追加**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドは新しい GroupShape を作成し、指定されたインデックス位置にコレクションに挿入します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.GetPresentationInfo(string file)、IPresentationFactory.GetPresentationInfo(Stream stream) メソッドを追加**
これらのメソッドは、プレゼンテーションを完全にロードせずに、プレゼンテーションファイルまたはストリームに関する情報を取得できるようにします。
#### **IPresentationFactory の PresentationFactory.Instance プロパティを追加**
このプロパティにより、開発者はインスタンス化せずにファクトリ機能を使用できます。
### **制限**
#### **IShape.Frame への制限**
IShape.Frame に未定義の値を使用することに対する制限が追加されました。未定義のフレームを IShape.Frame に代入しようとするコードは、ほとんどの場合意味がありません（特に親の GroupShape が他の {{GroupShape}} に複数階層で入れ子になっている場合）。例:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// ArgumentException をスローします: フレーム値は定義されている必要があります。
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

または

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// ArgumentException をスローします: x、y、幅、そして高さは定義されている必要があります。
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

このようなコードは不明確な状況を招く可能性があります。そのため、IShape.Frame に未定義の値を使用することに対する制限が追加されました。x、y、width、height、flipH、flipV、rotationAngle の値は定義されている必要があり（float.NaN や NullableBool.NotDefined に設定されてはいけません）、上記の例コードは現在 ArgumentException 例外をスローします。
これは次の使用例に適用されます:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x、y、幅、高さパラメーターは float.NaN にできず、flipH、flipV は NullableBool.NotDefined にできません:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// 同じ制限がシェイプを作成するすべてのメソッドに適用されます:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

ただし、IShape.RawFrame のフレームプロパティは未定義のままにできます。これはシェイプがプレースホルダーにリンクされている場合に意味があります。その場合、未定義のシェイプフレーム値は親プレースホルダーシェイプから上書きされます。親プレースホルダーシェイプが存在しない場合、シェイプは IShape.RawFrame に基づいて有効フレームを評価する際にデフォルト値を使用します。デフォルト値は x、y、width、height、flipH、flipV、rotationAngle について 0 と NullableBool.False です。例:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // シェイプはプレースホルダーにリンクされています
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // これでシェイプはプレースホルダーから x、y、height、flipH、flipV の値を継承し、width=100 と rotationAngle=0 を上書きします。
}
``` 
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.Parent プロパティの名前と型を変更**
- Aspose.Slides.IShapeCollection.Parent プロパティの型は ISlideComponent から新しい IGroupShape インターフェイスに変更されました。IGroupShape インターフェイスは ISlideComponent の派生であるため、既存のコードは変更不要です。
- Aspose.Slides.IShapeCollection.Parent プロパティの名前は Parent から ParentGroup に変更されました。
#### **Aspose.Slides.IShapeFrame.FlipH および .FlipV プロパティの型を変更**
- Aspose.Slides.IShapeFrame.FlipH プロパティの型は bool から NullableBool に変更されました。
- IShape.Frame プロパティは、すべてのプロパティに有効な値が定義された IShapeFrame のインスタンスを返します。
- IShape.RawFrame プロパティは、各プロパティが未定義の値を持つ可能性がある IShapeFrame のインスタンスを返します（特に FlipH や FlipV は NullableBool.NotDefined の値を取ることがあります）。