---
title: Aspose.Slides for .NET 14.5.0における公開APIと後方互換性のない変更
type: docs
weight: 70
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.5.0 APIで導入されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)クラス、メソッド、プロパティなど、新しい[制限](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)およびその他の[変更](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)について一覧表示します。

{{% /alert %}} 
## **公開APIと後方互換性のない変更**
### **追加されたインターフェイス、クラス、プロパティ、およびメソッド**
#### **Aspose.Slides.IPresentationInfoインターフェイスおよびPresentationInfoクラスの追加**
プレゼンテーションに関する情報を表します。

- BooleanプロパティIsEncryptedは、プレゼンテーションが暗号化されている場合はTrueを返し、それ以外の場合はFalseを返します。
- プロパティLoadFormatはプレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.IsGroupedプロパティの追加**
プロパティAspose.Slides.IShape.IsGroupedは、シェイプがグループ化されているかどうかを決定します。
#### **Aspose.Slides.IShape.ParentGroupプロパティの追加**
プロパティAspose.Slides.IShape.ParentGroupは、シェイプがグループ化されている場合に親GroupShapeオブジェクトを返します。それ以外の場合はnullを返します。
#### **Aspose.Slides.IShapeCollection.AddGroupShape()メソッドの追加**
メソッドAspose.Slides.IShapeCollection.AddGroupShape()は、新しいGroupShapeを作成し、コレクションの末尾に追加します。
新しいシェイプが追加されると、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.Clear()メソッドの追加**
メソッドAspose.Slides.IShapeCollection.Clear()は、コレクションからすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int)メソッドの追加**
メソッドAspose.Slides.IShapeCollection.InsertGroupShape(int)は、新しいGroupShapeを作成し、指定されたインデックス位置にコレクションに挿入します。
新しいシェイプが追加されると、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.GetPresentationInfo(string file)、IPresentationFactory.GetPresentationInfo(Stream stream)メソッドの追加**
これらのメソッドは、プレゼンテーションを完全にロードせずに、プレゼンテーションファイルまたはストリームに関する情報を取得できるようにします。
#### **IPresentationFactory PresentationFactory.Instanceプロパティの追加**
このプロパティは、開発者がインスタンス化せずにファクトリ機能を使用できるようにします。
### **制限事項**
#### **IShape.Frameに対する制限**
IShape.Frameに対して未定義の値を使用するための制限が追加されました。未定義のフレームをIShape.Frameに割り当てようとするコードは、ほとんどの場合意味を成しません（特に親GroupShapeが他の{{GroupShape}}に多重にネストされている場合）。例えば：

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

または

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

そのようなコードは不明瞭な状況を引き起こす可能性があります。したがって、IShape.Frameに対して未定義の値を使用しないための制限が追加されました。x、y、幅、高さ、flipH、flipV、およびrotationAngleの値は定義されている必要があります（float.NaNまたはNullableBool.NotDefinedに設定されてはいけません）。上記の例のコードは、今やArgumentException例外をスローします。
これは、以下の使用ケースに適用されます：

``` csharp

 IShape shape = ...;

shape.Frame = ...; // 未定義にはできません

IShapeCollection shapes = ...;

// x、y、幅、高さのパラメータはfloat.NaNにはできません：

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

しかし、IShape.RawFrameフレームプロパティは未定義にすることができます。これは、シェイプがプレースホルダーにリンクされている場合に意味を持ちます。この場合、未定義のシェイプフレームの値は、親プレースホルダーシェイプからオーバーライドされます。親プレースホルダーシェイプがない場合、そのシェイプはIShape.RawFrameに基づいて有効なフレームを評価するときにデフォルト値を使用します。デフォルト値は、x、y、幅、高さ、flipH、flipV、およびrotationAngleに対して0およびNullableBool.Falseです。例えば：

``` csharp

 IShape shape = ...; // shapeはプレースホルダーにリンクされています

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// 現在、shapeはプレースホルダーからx、y、高さ、flipH、flipVの値を継承し、幅=100とrotationAngle=0をオーバーライドします。

``` 
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.Parentプロパティ名とタイプの変更**
- Aspose.Slides.IShapeCollection.ParentプロパティのタイプはISlideComponentから新しいIGroupShapeインターフェイスに変更されました。IGroupShapeインターフェイスはISlideComponentの子孫であるため、既存のコードは適応が必要ありません。
- Aspose.Slides.IShapeCollection.Parentプロパティの名前はParentからParentGroupに変更されました。
#### **Aspose.Slides.IShapeFrame.FlipHおよび.FlipVプロパティのタイプの変更**
- Aspose.Slides.IShapeFrame.FlipHプロパティのタイプはboolからNullableBoolに変更されました。
- IShape.Frameプロパティは、定義された有効値を持つIShapeFrameのインスタンスを返します。
- IShape.RawFrameプロパティは、各プロパティが未定義の値を持つ可能性があるIShapeFrameのインスタンスを返します（特にFlipHまたはFlipVはNullableBool.NotDefinedの値を持つ可能性があります）。