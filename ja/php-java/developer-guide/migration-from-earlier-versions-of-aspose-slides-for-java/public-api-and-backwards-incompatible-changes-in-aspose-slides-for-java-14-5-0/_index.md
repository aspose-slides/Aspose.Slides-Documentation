---
title: Aspose.Slides for PHP via Java 14.5.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 40
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 14.5.0 APIで導入されたすべての[追加された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)クラス、メソッド、プロパティなど、すべての新しい[制限](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)およびその他の[変更](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)をリストしています。

{{% /alert %}} 
## **パブリックAPIと後方互換性のない変更**
### **追加されたクラスとメソッド**
#### **Aspose.Slides.IPresentationInfoインターフェースおよびPresentationInfoクラスの追加**
プレゼンテーションに関する情報を表します。

メソッドBoolean isEncrypted()は、プレゼンテーションが暗号化されている場合はTrueを返し、そうでない場合はFalseを返します。

メソッドLoadFormat getLoadFormat()は、プレゼンテーションの種類を取得します。
#### **Aspose.Slides.IShape.isGrouped()メソッドの追加**
メソッドAspose.Slides.IShape.isGrouped()は、シェイプがグループ化されているかどうかを判断します。
#### **Aspose.Slides.IShape.getParentGroup()メソッドの追加**
メソッドAspose.Slides.IShape.getParentGroup()は、シェイプがグループ化されている場合、親GroupShapeオブジェクトを返します。そうでない場合はnullを返します。
#### **Aspose.Slides.IShapeCollection.addGroupShape()メソッドの追加**
メソッドAspose.Slides.IShapeCollection.addGroupShape()は、新しいGroupShapeを作成し、コレクションの末尾に追加します。

新しいシェイプがGroupShapeに追加されるとき、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.clear()メソッドの追加**
メソッドAspose.Slides.IShapeCollection.clear()は、コレクションからすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int)メソッドの追加**
メソッドAspose.Slides.IShapeCollection.insertGroupShape(int)は、新しいGroupShapeを作成し、指定されたインデックスにコレクションに挿入します。
新しいシェイプがGroupShapeに追加されるとき、GroupShapeのフレームサイズと位置はコンテンツに合わせて調整されます。
#### **IPresentationFactory.getPresentationInfo(string file)、IPresentationFactory.getPresentationInfo(InputStream stream)メソッドの追加**
これらのメソッドは、開いたプレゼンテーションのファイル/ストリームの情報をフルプレゼンテーションロードなしで取得できるようにします。
#### **IPresentationFactory PresentationFactory.getInstance()メソッドの追加**
インスタンス化せずにファクトリ機能を使用できます。
### **制限**
#### **IShape.getFrame()で未定義の値を使用するための制限が追加されました**
IShape.setFrame(IShapeFrame)に未定義のフレームを割り当てようとするコードは、一般的なケースでは意味を成しません（特に、親GroupShapeが他の{{GroupShape}}に複数回ネストされている場合）。例えば：

```php
  $shape = $$missing$;
  $shape->setFrame(new ShapeFrame(Float::NaN, Float::NaN, Float::NaN, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, Float::NaN));

```

または

```php
  slide.Shapes->AddAutoShape(ShapeType::RoundCornerRectangle, Float::NaN, Float::NaN, Float::NaN, Float::NaN);

```

このようなコードは不明確な状況を招く可能性があります。したがって、IShape.Frameで未定義の値を使用するための制限が追加されました。x、y、width、height、flipH、flipV、およびrotationAngleの値は定義されている必要があります（Float.NaNまたはNullableBool.NotDefinedではなく）。上記の例のコードは現在、ArgumentException例外をスローします。
これは以下の使用ケースに適用されます：

```php
  $shape = $$missing$;
  $shape->setFrame();// 未定義にすることはできません

  $shapes = $$missing$;
  # x, y, width, heightパラメーターはFloat.NaNであってはなりません：
  {
    $shapes->addAudioFrameCD();
    $shapes->addAudioFrameEmbedded();
    $shapes->addAudioFrameLinked();
    $shapes->addAutoShape();
    $shapes->addChart();
    $shapes->addConnector();
    $shapes->addOleObjectFrame();
    $shapes->addPictureFrame();
    $shapes->addSmartArt();
    $shapes->addTable();
    $shapes->addVideoFrame();
    $shapes->insertAudioFrameEmbedded();
    $shapes->insertAudioFrameLinked();
    $shapes->insertAutoShape();
    $shapes->insertChart();
    $shapes->insertConnector();
    $shapes->insertOleObjectFrame();
    $shapes->insertPictureFrame();
    $shapes->insertTable();
    $shapes->insertVideoFrame();
  }
```

ただし、IShape.getRawFrame()フレームは未定義にすることができます。これは、シェイプがプレースホルダーにリンクされている場合に意味があります。その場合、未定義のシェイプフレーム値は親プレースホルダーシェイプからオーバーライドされます。そのシェイプに親プレースホルダーシェイプが存在しない場合、IShape.getRawFrame()に基づいて有効なフレームを評価するときにデフォルト値が使用されます。デフォルト値は、x、y、width、height、flipH、flipV、rotationAngleの0とNullableBool.Falseです。例えば：

```php
  $shape = $$missing$;// シェイプはプレースホルダーにリンクされています

  $shape->setRawFrame(new ShapeFrame(Float::NaN, Float::NaN, 100, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, 0));
  # 現在、シェイプはプレースホルダーからx、y、height、flipH、flipVの値を継承し、width=100およびrotationAngle=0をオーバーライドします。

```
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.getParent()メソッドの型および名前の変更**
Aspose.Slides.IShapeCollection.Parentプロパティの型がISlideComponentから新しいIGroupShapeインターフェースに変更されました。IGroupShapeインターフェースはISlideComponentの子孫であるため、既存のコードは適応の必要がありません。

Aspose.Slides.IShapeCollection.getParent()メソッドの名前はgetParentからgetParentGroup()に変更されました。
#### **Aspose.Slides.IShapeFrame.getFlipH()および.getFlipV()メソッドの型の変更**
Aspose.Slides.IShapeFrame.getFlipH()メソッドの型がboolからNullableBoolに変更されました。

IShape.getFrame()メソッドは、全てのプロパティが定義された有効な値を持つIShapeFrameのインスタンスを返します。

IShape.getRawFrame()メソッドは、各プロパティが未定義の値を持つ可能性のあるIShapeFrameインスタンスを返します（特にFlipHまたはFlipVはNullableBool.NotDefinedの値を持つことがあります）。