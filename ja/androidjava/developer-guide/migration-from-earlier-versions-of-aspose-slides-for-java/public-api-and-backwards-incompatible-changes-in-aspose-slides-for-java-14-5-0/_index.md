---
title: Aspose.Slides for Java 14.5.0における公開APIと後方互換性のない変更
type: docs
weight: 40
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.5.0 APIで追加されたすべての[class](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)クラス、メソッド、プロパティなど、追加された[restrictions](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)やその他の[changes](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)を一覧表示します。

{{% /alert %}} 
## **公開APIと後方互換性のない変更**
### **追加されたクラスとメソッド**
#### **Aspose.Slides.IPresentationInfoインターフェースとPresentationInfoクラスを追加**
プレゼンテーションに関する情報を表します。

メソッド Boolean isEncrypted() は、プレゼンテーションが暗号化されている場合はTrueを、そうでない場合はFalseを取得します。

メソッド LoadFormat getLoadFormat() はプレゼンテーションのタイプを取得します。
#### **Aspose.Slides.IShape.isGrouped()メソッドを追加**
メソッドAspose.Slides.IShape.isGrouped()は、図形がグループ化されているかどうかを判断します。
#### **Aspose.Slides.IShape.getParentGroup()メソッドを追加**
メソッドAspose.Slides.IShape.getParentGroup()は、図形がグループ化されている場合、親のGroupShapeオブジェクトを返します。そうでない場合はnullを返します。
#### **Aspose.Slides.IShapeCollection.addGroupShape()メソッドを追加**
メソッドAspose.Slides.IShapeCollection.addGroupShape()は、新しいGroupShapeを作成し、コレクションの末尾に追加します。

新しい図形がGroupShapeに追加されると、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.clear()メソッドを追加**
メソッドAspose.Slides.IShapeCollection.clear()は、コレクションからすべての図形を削除します。
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int)メソッドを追加**
メソッドAspose.Slides.IShapeCollection.insertGroupShape(int)は、新しいGroupShapeを作成し、指定されたインデックスにコレクションに挿入します。
新しい図形がGroupShapeに追加されると、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.getPresentationInfo(string file)、IPresentationFactory.getPresentationInfo(InputStream stream)メソッドを追加**
これらのメソッドにより、開発者はプレゼンテーションファイル/ストリームについての情報を、完全なプレゼンテーションの読み込みなしで受け取ることができます。
#### **IPresentationFactory PresentationFactory.getInstance()メソッドを追加**
インスタンス化せずにファクトリ機能を使用できるようになります。
### **制限**
#### **IShape.getFrame()に未定義の値を使用するための制限が追加されました**
IShape.setFrame(IShapeFrame)に未定義のフレームを割り当てようとするコードは、一般的なケースでは意味を成しません（特に、親のGroupShapeが他の{{GroupShape}}に複数ネストされている場合）。例えば：

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

または

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

そのようなコードは不明瞭な状況を引き起こす可能性があります。したがって、IShape.Frameに未定義の値を使用するための制限が追加されました。x、y、width、height、flipH、flipV、およびrotationAngleの値は定義されている必要があります（Float.NaNまたはNullableBool.NotDefinedではなく）。上記の例のコードは現在、ArgumentException例外をスローします。
これは次の使用例に適用されます：

``` java

 IShape shape = ...;

shape.setFrame(...); // 未定義にすることはできません

IShapeCollection shapes = ...;

// x、y、width、heightパラメータはFloat.NaNにできません：

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

しかし、IShape.getRawFrame()フレームは未定義になる可能性があります。これは、図形がプレースホルダーにリンクされている場合に意味があります。未定義の図形フレームの値は、親のプレースホルダー図形から上書きされます。その図形のために親のプレースホルダー図形がない場合は、IShape.getRawFrame()に基づいて有効なフレームを評価する際にデフォルト値が使用されます。デフォルト値はx、y、width、height、flipH、flipV、rotationAngleに対して0およびNullableBool.Falseです。例えば：

``` java

 IShape shape = ...; // 図形はプレースホルダーにリンクされています

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// 現在、図形はプレースホルダーからx、y、height、flipH、flipVの値を継承し、width=100とrotationAngle=0を上書きします。

```
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.getParent()メソッドの型と名前が変更されました**
Aspose.Slides.IShapeCollection.Parentプロパティの型がISlideComponentから新しいIGroupShapeインターフェースに変更されました。IGroupShapeインターフェースはISlideComponentの子孫であるため、既存のコードは適応の必要がありません。

Aspose.Slides.IShapeCollection.getParent()メソッドの名前がgetParentからgetParentGroup()に変更されました。
#### **Aspose.Slides.IShapeFrame.getFlipH()および.getFlipV()メソッドの型を変更**
Aspose.Slides.IShapeFrame.getFlipH()メソッドの型がboolからNullableBoolに変更されました。

IShape.getFrame()メソッドは、IShapeFrameの有効なインスタンスを返します（これらのプロパティのすべてが有効な値を持っています）。

IShape.getRawFrame()メソッドは、各プロパティが未定義の値を持つ可能性があるIShapeFrameインスタンスを返します（特にFlipHまたはFlipVはNullableBool.NotDefinedの値を持つ可能性があります）。