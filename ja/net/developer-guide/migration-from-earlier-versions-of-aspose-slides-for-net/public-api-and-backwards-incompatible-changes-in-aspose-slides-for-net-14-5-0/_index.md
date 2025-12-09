---
title: Aspose.Slides for .NET 14.5.0 の公開 API と下位互換性のない変更
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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行します。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.5.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) クラス、メソッド、プロパティなど、すべての[制約](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) および他の[変更](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) を一覧表示します。

{{% /alert %}} 
## **公開 API および下位互換性のない変更**
### **追加されたインターフェイス、クラス、プロパティ、メソッド**
#### **Aspose.Slides.IPresentationInfo インターフェイスと PresentationInfo クラスの追加**
プレゼンテーションに関する情報を表します。

- Boolean プロパティ IsEncrypted は、プレゼンテーションが暗号化されている場合は True を取得し、そうでない場合は False を取得します。
- プロパティ LoadFormat は、プレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.IsGrouped プロパティの追加**
プロパティ Aspose.Slides.IShape.IsGrouped は、シェイプがグループ化されているかどうかを判定します。
#### **Aspose.Slides.IShape.ParentGroup プロパティの追加**
プロパティ Aspose.Slides.IShape.ParentGroup は、シェイプがグループ化されている場合は親の GroupShape オブジェクトを返し、そうでない場合は null を返します。
#### **Aspose.Slides.IShapeCollection.AddGroupShape() メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.AddGroupShape() は新しい GroupShape を作成し、コレクションの末尾に追加します。新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.Clear() メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.Clear() はコレクションからすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.InsertGroupShape(int) は新しい GroupShape を作成し、指定されたインデックス位置にコレクションへ挿入します。新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream) メソッドの追加**
これらのメソッドは、プレゼンテーション全体をロードせずに、プレゼンテーション ファイルまたはストリームに関する情報を取得できるようにします。
#### **IPresentationFactory PresentationFactory.Instance プロパティの追加**
このプロパティにより、開発者はインスタンス化せずにファクトリ機能を利用できます。
### **制約**
#### **IShape.Frame の制限**
IShape.Frame に未定義の値を使用することに対して制限が追加されました。IShape.Frame に未定義のフレームを割り当てようとするコードは、ほとんどの場合意味がありません（特に親の GroupShape が他の {{GroupShape}} に複数階層で入れ子になっている場合）。例として：

``` csharp
 IShape shape = ...;
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

このようなコードは不明瞭な状態を招く可能性があります。そのため、IShape.Frame に未定義の値を使用することに対して制限が追加されました。x、y、width、height、flipH、flipV、rotationAngle の値は必ず定義されている必要があり（float.NaN や NullableBool.NotDefined に設定してはいけません）、上記の例コードは現在 ArgumentException 例外をスローします。これは以下の使用ケースに適用されます：

``` csharp
 IShape shape = ...;
shape.Frame = ...; // Cannot be undefined
IShapeCollection shapes = ...;
// x, y, width, height parameters cannot be float.NaN:
{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

ただし、IShape.RawFrame のフレームプロパティは未定義のままにすることができます。これはシェイプがプレースホルダーにリンクされている場合に意味があります。その場合、未定義のシェイプ フレーム値は親プレースホルダー シェイプから上書きされます。親プレースホルダー シェイプが存在しない場合、シェイプは IShape.RawFrame に基づいて有効フレームを評価する際にデフォルト値を使用します。デフォルト値は x、y、width、height、flipH、flipV、rotationAngle については 0 と NullableBool.False です。例：

``` csharp
 IShape shape = ...; // shape is linked to placeholder
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.
``` 
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.Parent プロパティの名前と型の変更**
- Aspose.Slides.IShapeCollection.Parent プロパティの型は ISlideComponent から新しい IGroupShape インターフェイスに変更されました。IGroupShape インターフェイスは ISSlideComponent の子孫であるため、既存のコードを変更する必要はありません。
- Aspose.Slides.IShapeCollection.Parent プロパティの名前は Parent から ParentGroup に変更されました。
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV プロパティの型の変更**
- Aspose.Slides.IShapeFrame.FlipH プロパティの型は bool から NullableBool に変更されました。
- IShape.Frame プロパティは、有効なインスタンスの IShapeFrame を返します（すべてのプロパティに定義済みの有効値があります）。
- IShape.RawFrame プロパティは、各プロパティが未定義の値を持つ可能性がある IShapeFrame のインスタンスを返します（特に FlipH または FlipV は NullableBool.NotDefined の値を持つことがあります）。