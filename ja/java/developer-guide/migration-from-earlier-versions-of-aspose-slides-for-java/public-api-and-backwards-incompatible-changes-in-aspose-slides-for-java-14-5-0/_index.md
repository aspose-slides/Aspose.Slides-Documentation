---
title: Aspose.Slides for Java 14.5.0における公開APIと互換性のない変更
type: docs
weight: 40
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.5.0 APIで追加されたすべての [クラス](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)、 [メソッド](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)、 [プロパティ](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) およびその他の [変更](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) をリストします。

{{% /alert %}} 
## **公開APIと互換性のない変更**
### **追加されたクラスとメソッド**
#### **Aspose.Slides.IPresentationInfoインターフェイスとPresentationInfoクラスの追加**
プレゼンテーションに関する情報を表します。

メソッド Boolean isEncrypted() は、プレゼンテーションが暗号化されている場合にはTrueを返し、そうでない場合はFalseを返します。

メソッド LoadFormat getLoadFormat() はプレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.isGrouped()メソッドの追加**
メソッド Aspose.Slides.IShape.isGrouped() は、形状がグループ化されているかどうかを判断します。
#### **Aspose.Slides.IShape.getParentGroup()メソッドの追加**
メソッド Aspose.Slides.IShape.getParentGroup() は、形状がグループ化されている場合、親のGroupShapeオブジェクトを返します。そうでない場合はnullを返します。
#### **Aspose.Slides.IShapeCollection.addGroupShape()メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.addGroupShape() は新しいGroupShapeを作成し、コレクションの最後に追加します。

新しい形状がGroupShapeに追加されると、GroupShapeのフレームサイズと位置は内容に合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.clear()メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.clear() はコレクションからすべての形状を削除します。
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int)メソッドの追加**
メソッド Aspose.Slides.IShapeCollection.insertGroupShape(int) は新しいGroupShapeを作成し、指定されたインデックスでコレクションに挿入します。
新しい形状がGroupShapeに追加されると、GroupShapeのフレームサイズと位置は内容に合わせて調整されます。
#### **IPresentationFactory.getPresentationInfo(string file)、IPresentationFactory.getPresentationInfo(InputStream stream)メソッドの追加**
これらのメソッドは、開発者がプレゼンテーションファイル/ストリームについての情報をフルプレゼンテーションをロードせずに取得できるようにします。
#### **IPresentationFactory PresentationFactory.getInstance()メソッドの追加**
インスタンス化せずにファクトリ機能を使用できるようにします。
### **制限**
#### **IShape.getFrame()に対する未定義値の使用に制限が追加されました**
未定義のフレームをIShape.setFrame(IShapeFrame)に割り当てようとするコードは、一般的には意味がありません（特に親のGroupShapeが他の{{GroupShape}}に複数回ネストされている場合）。例えば：

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

または

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

このようなコードはあいまいな状況につながる可能性があります。したがって、IShape.Frameに対する未定義値の使用に制限が追加されました。x、y、width、height、flipH、flipV、およびrotationAngleの値は定義されている必要があります（Float.NaNまたはNullableBool.NotDefinedであってはいけません）。上記の例コードは現在、ArgumentException例外をスローします。
これは以下の使用ケースに適用されます：

``` java

 IShape shape = ...;

shape.setFrame(...); // 未定義にはできません

IShapeCollection shapes = ...;

// x、y、width、heightパラメータはFloat.NaNにはできません：

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

しかし、IShape.getRawFrame()フレームは未定義である可能性があります。これは、形状がプレースホルダーにリンクされている場合に意味があります。未定義の形状フレーム値は、親のプレースホルダー形状から上書きされます。その形状に親のプレースホルダー形状がない場合は、IShape.getRawFrame()に基づいて効果的なフレームが評価されるときにデフォルト値が使用されます。デフォルト値はx、y、width、height、flipH、flipV、rotationAngleの値がそれぞれ0およびNullableBool.Falseです。例えば：

``` java

 IShape shape = ...; // 形状はプレースホルダーにリンクされている

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// 現在、形状はプレースホルダーからx、y、height、flipH、flipVの値を継承し、width=100およびrotationAngle=0を上書きします。

```
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.getParent()メソッドの型と名前の変更**
Aspose.Slides.IShapeCollection.Parentプロパティの型はISlideComponentから新しいIGroupShapeインターフェイスに変更されました。IGroupShapeインターフェイスはISlideComponentの子孫であるため、既存のコードは適応の必要がありません。

Aspose.Slides.IShapeCollection.getParent()メソッドの名前はgetParentからgetParentGroup()に変更されました。
#### **Aspose.Slides.IShapeFrame.getFlipH()および.getFlipV()メソッドの型の変更**
Aspose.Slides.IShapeFrame.getFlipH()メソッドの型はboolからNullableBoolに変更されました。

IShape.getFrame()メソッドは、IShapeFrameの有効なインスタンスを返します（すべてのプロパティは定義された有効な値を持っています）。

IShape.getRawFrame()メソッドは、各プロパティが未定義の値を持つ可能性のあるIShapeFrameインスタンスを返します（特にFlipHまたはFlipVはNullableBool.NotDefinedの値を持つことがあります）。