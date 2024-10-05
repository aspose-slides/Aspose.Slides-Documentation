---
title: ウォーターマーク
type: docs
weight: 40
url: /androidjava/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキストウォーターマーク
- 画像ウォーターマーク
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides for Android via Java
description: "JavaでPowerPointプレゼンテーションにテキストと画像のウォーターマークを追加する"
---

## **ウォーターマークについて**

プレゼンテーションの**ウォーターマーク**は、スライドやすべてのプレゼンテーションスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークはプレゼンテーションが草案であることを示すために使用されます（例：「Draft」ウォーターマーク）、機密情報を含むことを示すため（例：「Confidential」ウォーターマーク）、どの会社に属しているかを指定するため（例：「Company Name」ウォーターマーク）、プレゼンテーションの作成者を特定するためなどです。ウォーターマークは、プレゼンテーションがコピーされるべきではないことを示すことで、著作権侵害を防ぐのに役立ちます。ウォーターマークは、PowerPointとOpenOfficeのプレゼンテーション形式の両方で使用されます。Aspose.Slidesでは、PowerPointのPPT、PPTX、およびOpenOfficeのODPファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/android-java/)では、PowerPointまたはOpenOfficeドキュメントにウォーターマークを作成し、そのデザインや動作を変更するさまざまな方法があります。共通の側面は、テキストウォーターマークを追加するには[ ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)インターフェイスを使用し、画像ウォーターマークを追加するには[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)クラスを使用するか、ウォーターマークシェイプを画像で満たす必要があることです。`PictureFrame`は[ IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)インターフェイスを実装しており、シェイプオブジェクトのすべての柔軟な設定を使用できます。`ITextFrame`はシェイプではなく、その設定が限られているため、[ IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)オブジェクトにラップされています。

ウォーターマークを適用する方法は2つあります。1つは単一のスライドに適用する方法、もう1つはすべてのプレゼンテーションスライドに適用する方法です。スライドマスターを使用して、すべてのプレゼンテーションスライドにウォーターマークを適用します。ウォーターマークはスライドマスターに追加され、完全にデザインされ、個々のスライドでウォーターマークを変更する権限に影響を与えることなく、すべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーによる編集ができないと見なされます。ウォーターマーク（または正確にはウォーターマークの親シェイプ）が編集されないようにするために、Aspose.Slidesはシェイプロック機能を提供します。特定のシェイプは、通常のスライドまたはスライドマスターでロックできます。ウォーターマークシェイプがスライドマスターでロックされると、すべてのプレゼンテーションスライドでロックされます。

将来的に削除したい場合に備えて、ウォーターマークに名前を付けることができます。その際、スライドのシェイプの名前でウォーターマークを見つけることができます。

ウォーターマークは、任意の方法でデザインできますが、通常は中央揃え、回転、前面位置などの共通機能があります。以下の例でこれらを使用する方法を考察します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、またはODPにテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは[ ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)インターフェイスによって表されます。このタイプは[ IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)から継承されず、ウォーターマークを柔軟に配置するための広範なプロパティセットがあります。したがって、[ ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)オブジェクトは[ IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)オブジェクトにラップされます。ウォーターマークテキストをシェイプに追加するには、以下のように[addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドを使用します。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [TextFrameクラスの使用方法](/slides/androidjava/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（すべてのスライドを一度に）にテキストウォーターマークを追加する場合は、[MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/)に追加します。ロジックの残りは、単一のスライドにウォーターマークを追加するのと同じです。まず[ IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)オブジェクトを作成し、次に[addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドを使用してウォーターマークを追加します。

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [スライドマスターの使用方法](/slides/androidjava/slide-master/)
{{% /alert %}}

### **ウォーターマークシェイプの透明度を設定する**

デフォルトでは、長方形シェイプは塗りつぶしと線の色でスタイル設定されています。次のコード行は、シェイプを透明にします。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **テキストウォーターマークのフォントを設定する**

テキストウォーターマークのフォントを以下のように変更できます。

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、以下のコードを使用します。

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **テキストウォーターマークを中央に配置する**

ウォーターマークをスライドの中央に配置することができ、そのためには次のことを行います。

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

下の画像は最終結果を示しています。

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションスライドに画像ウォーターマークを追加するには、次のようにします。

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **ウォーターマークの編集をロックする**

ウォーターマークの編集を防ぐ必要がある場合は、シェイプに対して[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--)メソッドを使用します。このプロパティを使用すると、シェイプの選択、サイズ変更、再配置、他の要素とのグループ化を防ぎ、テキストの編集をロックするなど、さまざまなことを保護できます。

```java
// ウォーターマークシェイプの変更をロックする
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **ウォーターマークを前面に移動する**

Aspose.Slidesでは、シェイプのZ順が[ IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)メソッドを介して設定できます。これを行うには、プレゼンテーションのスライドリストからこのメソッドを呼び出し、シェイプ参照とその順序番号をメソッドに渡す必要があります。この方法で、シェイプを前面に持ってきたり、スライドの後ろに送ったりできます。この機能は、プレゼンテーションの前面にウォーターマークを配置する必要がある場合に特に便利です。

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定する**

ウォーターマークの回転を調整して、スライドの対角線に配置する方法のコード例は次のとおりです。

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **ウォーターマークに名前を付ける**

Aspose.Slidesでは、シェイプの名前を設定できます。シェイプ名を使用して、将来的にそれにアクセスし、修正または削除できます。ウォーターマークシェイプに名前を付けるには、[IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)メソッドに割り当てます。

```java
watermarkShape.setName("watermark");
```

## **ウォーターマークを削除する**

ウォーターマークシェイプを削除するには、[IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--)メソッドを使用してスライドシェイプの中からそれを見つけます。その後、ウォーターマークシェイプを[IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)メソッドに渡します。

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **ライブ例**

**Aspose.Slides無料**の[ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)オンラインツールをチェックしてみると良いでしょう。

![ウォーターマークを追加および削除するオンラインツール](online_tools.png)