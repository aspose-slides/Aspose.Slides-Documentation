---
title: "Aspose.Slides for .NET 14.5.0 のパブリック API と下位互換性のない変更"
linktitle: "Aspose.Slides for .NET 14.5.0"
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.5.0 APIで導入されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) クラス、メソッド、プロパティなど、また新しい[制限](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) やその他の[変更](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) を一覧表示します。

{{% /alert %}} 
## **パブリック API と下位互換性のない変更**
### **追加されたインターフェイス、クラス、プロパティ、メソッド**
#### **Aspose.Slides.IPresentationInfo インターフェイス と PresentationInfo クラス を追加**
プレゼンテーションに関する情報を表します。

- Boolean プロパティ IsEncrypted は、プレゼンテーションが暗号化されている場合は True、そうでない場合は False を取得します。
- プロパティ LoadFormat は、プレゼンテーションの種類を取得します。
#### **Aspose.Slides.IShape.IsGrouped プロパティ を追加**
Aspose.Slides.IShape.IsGrouped プロパティは、シェイプがグループ化されているかどうかを判定します。
#### **Aspose.Slides.IShape.ParentGroup プロパティ を追加**
Aspose.Slides.IShape.ParentGroup プロパティは、シェイプがグループ化されている場合は親の GroupShape オブジェクトを返します。そうでなければ null を返します。
#### **Aspose.Slides.IShapeCollection.AddGroupShape() メソッド を追加**
Aspose.Slides.IShapeCollection.AddGroupShape() メソッドは新しい GroupShape を作成し、コレクションの末尾に追加します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.Clear() メソッド を追加**
Aspose.Slides.IShapeCollection.Clear() メソッドは、コレクション内のすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッド を追加**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドは新しい GroupShape を作成し、指定されたインデックス位置にコレクションへ挿入します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) メソッド を追加**
これらのメソッドにより、プレゼンテーションを完全にロードせずに、プレゼンテーション ファイルまたはストリームに関する情報を取得できます。
#### **IPresentationFactory PresentationFactory.Instance プロパティ を追加**
このプロパティにより、開発者はインスタンス化せずにファクトリ機能を使用できます。
### **制限**
#### **IShape.Frame に対する制限**
IShape.Frame に未定義の値を使用することに対して制限が追加されました。IShape.Frame に未定義のフレームを割り当てようとするコードは、ほとんどの場合意味がありません（特に親の GroupShape が他の {{GroupShape}} に複数階層でネストされている場合）。例:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

または

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

このようなコードは曖昧な状況を引き起こす可能性があります。したがって、IShape.Frame に未定義の値を使用することに対して制限が追加されました。x、y、width、height、flipH、flipV および rotationAngle の値は定義されている必要があり（float.NaN や NullableBool.NotDefined に設定してはいけません）、上記の例コードは現在 ArgumentException 例外をスローします。
これは以下の使用例に適用されます:

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

ただし IShape.RawFrame のフレーム プロパティは未定義にできる場合があります。これはシェイプがプレースホルダーにリンクされている場合に意味があります。その場合、未定義のシェイプ フレーム値は親プレースホルダーシェイプから上書きされます。親プレースホルダーシェイプが存在しない場合、そのシェイプは IShape.RawFrame に基づいて有効フレームを評価するときにデフォルト値を使用します。デフォルト値は x、y、width、height、flipH、flipV、rotationAngle がそれぞれ 0 と NullableBool.False です。例:

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.Parent プロパティの名前と型が変更**
- Aspose.Slides.IShapeCollection.Parent プロパティの型は ISlideComponent から新しい IGroupShape インターフェイスに変更されました。IGroupShape インターフェイスは ISlideComponent の派生であるため、既存コードの変更は不要です。
- Aspose.Slides.IShapeCollection.Parent プロパティの名前は Parent から ParentGroup に変更されました。
#### **Aspose.Slides.IShapeFrame.FlipH、.FlipV プロパティの型が変更**
- Aspose.Slides.IShapeFrame.FlipH プロパティの型は bool から NullableBool に変更されました。
- IShape.Frame プロパティは、すべてのプロパティに有効な値が定義された IShapeFrame の有効インスタンスを返します。
- IShape.RawFrame プロパティは、各プロパティが未定義の値を持つ可能性のある IShapeFrame のインスタンスを返します（特に FlipH または FlipV は NullableBool.NotDefined になることがあります）。