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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.5.0 APIで導入されたすべての[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) クラス、メソッド、プロパティ等、また新しい[restrictions](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)やその他の[changes](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)を一覧表示します。

{{% /alert %}} 
## **公開 API と後方互換性のない変更**
### **追加されたインターフェイス、クラス、プロパティ、メソッド**
#### **Aspose.Slides.IPresentationInfo インターフェイスと PresentationInfo クラスの追加**
プレゼンテーションに関する情報を表します。

- Boolean プロパティ IsEncrypted は、プレゼンテーションが暗号化されている場合は True を取得し、そうでない場合は False を取得します。
- プロパティ LoadFormat は、プレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.IsGrouped プロパティの追加**
Aspose.Slides.IShape.IsGrouped プロパティは、シェイプがグループ化されているかどうかを判定します。
#### **Aspose.Slides.IShape.ParentGroup プロパティの追加**
Aspose.Slides.IShape.ParentGroup プロパティは、シェイプがグループ化されている場合に親の GroupShape オブジェクトを返します。そうでない場合は null を返します。
#### **Aspose.Slides.IShapeCollection.AddGroupShape() メソッドの追加**
Aspose.Slides.IShapeCollection.AddGroupShape() メソッドは新しい GroupShape を作成し、コレクションの末尾に追加します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.Clear() メソッドの追加**
Aspose.Slides.IShapeCollection.Clear() メソッドは、コレクションからすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドの追加**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) メソッドは新しい GroupShape を作成し、指定されたインデックス位置にコレクションに挿入します。
新しいシェイプが追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) メソッドの追加**
これらのメソッドは、プレゼンテーション ファイルまたはストリームを完全にロードせずに情報を取得できるようにします。
#### **IPresentationFactory PresentationFactory.Instance プロパティの追加**
このプロパティにより、開発者はインスタンス化せずにファクトリ機能を利用できます。
### **制限**
#### **IShape.Frame の制限**
未定義の値を IShape.Frame に使用することに対して制限が追加されました。IShape.Frame に未定義のフレームを割り当てようとするコードは、ほとんどの場合意味がありません（特に親の GroupShape が他の {{GroupShape}} に複数ネストされている場合）。例として：

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

または

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

このようなコードは不明確な状況を招く可能性があります。そのため、IShape.Frame に未定義の値を使用することに対して制限が追加されました。x、y、width、height、flipH、flipV、rotationAngle の値は必ず定義されており（float.NaN や NullableBool.NotDefined に設定されていない）、上記の例コードは現在 ArgumentException 例外をスローします。
これは以下の使用例に適用されます：

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

ただし、IShape.RawFrame のフレームプロパティは未定義にできます。これはシェイプがプレースホルダーにリンクされている場合に意味があります。その場合、未定義のシェイプフレーム値は親のプレースホルダーシェイプから上書きされます。親プレースホルダーシェイプが存在しない場合、そのシェイプは IShape.RawFrame に基づいて実効フレームを評価する際にデフォルト値を使用します。デフォルト値は x、y、width、height、flipH、flipV、rotationAngle がそれぞれ 0 と NullableBool.False です。例として：

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.Parent プロパティの名前と型の変更**
- Aspose.Slides.IShapeCollection.Parent プロパティの型は ISlideComponent から新しい IGroupShape インターフェイスに変更されました。IGroupShape インターフェイスは ISlideComponent の派生であるため、既存のコードに変更は不要です。
- Aspose.Slides.IShapeCollection.Parent プロパティの名前は Parent から ParentGroup に変更されました。
#### **Aspose.Slides.IShapeFrame.FlipH および .FlipV プロパティの型の変更**
- Aspose.Slides.IShapeFrame.FlipH プロパティの型は bool から NullableBool に変更されました。
- IShape.Frame プロパティは、すべてのプロパティが定義された実効値を持つ IShapeFrame のインスタンスを返します。
- IShape.RawFrame プロパティは、各プロパティが未定義値（特に FlipH や FlipV が NullableBool.NotDefined になる可能性がある）を持つ IShapeFrame のインスタンスを返します。