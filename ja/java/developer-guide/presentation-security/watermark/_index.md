---
title: ウォーターマーク
type: docs
weight: 40
url: /ja/java/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキストウォーターマーク
- 画像ウォーターマーク
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides for Java
description: "JavaでPowerPointプレゼンテーションにテキストおよび画像のウォーターマークを追加"
---

## **ウォーターマークについて**

プレゼンテーションにおける**ウォーターマーク**は、スライド上またはすべてのプレゼンテーションスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークは、プレゼンテーションがドラフトであることを示したり（例："ドラフト"ウォーターマーク）、機密情報が含まれていることを示したり（例："機密"ウォーターマーク）、どの会社に属しているかを特定したり（例："会社名"ウォーターマーク）、プレゼンテーションの著者を識別したりするために使用されます。ウォーターマークは、プレゼンテーションがコピーされてはならないことを示すことで、著作権侵害を防止するのに役立ちます。ウォーターマークは、PowerPointとOpenOfficeの両方のプレゼンテーション形式で使用されます。Aspose.Slidesでは、PowerPoint PPT、PPTX、およびOpenOffice ODPファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/java/)では、PowerPointまたはOpenOfficeドキュメントにウォーターマークを作成し、そのデザインや動作を変更するためのさまざまな方法があります。一般的な側面は、テキストウォーターマークを追加するために[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)インターフェイスを使用し、画像ウォーターマークを追加するために[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)クラスを使用するか、画像でウォーターマーク形状を塗りつぶす必要があることです。`PictureFrame`は[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)インターフェイスを実装しており、形状オブジェクトの柔軟な設定をすべて使用できます。`ITextFrame`は形状ではなく、その設定が限られているため、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)オブジェクトにラップされます。

ウォーターマークを適用する方法は二つあります：単一のスライドに適用するか、すべてのプレゼンテーションスライドに適用するかです。スライドマスターを使用してすべてのプレゼンテーションスライドにウォーターマークを適用します — ウォーターマークはスライドマスターに追加され、完全にデザインされ、個々のスライド上でウォーターマークを変更する権限に影響を与えることなく、すべてのスライドに適用されます。

ウォーターマークは、通常他のユーザーによる編集ができないと見なされます。ウォーターマーク（あるいはウォーターマークの親形状）が編集されるのを防ぐために、Aspose.Slidesは形状ロック機能を提供します。特定の形状は、通常のスライドまたはスライドマスター上でロックできます。ウォーターマーク形状がスライドマスター上でロックされている場合、それはすべてのプレゼンテーションスライド上でもロックされます。

ウォーターマークに名前を付けることができ、将来的にそれを削除したい場合は、スライドの形状から名前で見つけることができます。

ウォーターマークのデザインは自由ですが、一般的には中央揃え、回転、前面位置などの共通の特徴が存在します。以下の例では、これらの使い方について考察します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加**

PPT、PPTX、またはODPでテキストウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)インターフェイスによって表されます。このタイプは[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)から継承されていないため、ウォーターマークを柔軟に配置するための幅広いプロパティセットを持っているからです。したがって、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)オブジェクトは[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)オブジェクトにラップされます。形状にウォーターマークテキストを追加するには、以下のように[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドを使用します。

```java
String watermarkText = "機密";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [TextFrameクラスの使用方法](/slides/ja/java/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加**

プレゼンテーション全体（すなわち、すべてのスライドに一度に）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)に追加します。残りのロジックは、単一のスライドにウォーターマークを追加する際と同じです — [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)オブジェクトを作成し、その後[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドを使用してウォーターマークを追加します。

```java
String watermarkText = "機密";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [スライドマスターの使用方法](/slides/ja/java/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定**

デフォルトでは、長方形の形状は塗りつぶしおよび線の色でスタイリングされています。以下のコード行は、形状を透明にします。

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **テキストウォーターマークのフォントを設定**

以下のように、テキストウォーターマークのフォントを変更できます。

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **ウォーターマークテキストの色を設定**

ウォーターマークテキストの色を設定するには、以下のコードを使用します。

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **テキストウォーターマークを中央揃えにする**

ウォーターマークをスライドの中央に配置することが可能で、そのためには以下のようにします。

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

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

### **プレゼンテーションに画像ウォーターマークを追加**

スライドに画像ウォーターマークを追加するには、以下のようにします。

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **ウォーターマークを編集からロック**

ウォーターマークが編集されるのを防ぐ必要がある場合は、形状に対して[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)メソッドを使用します。このプロパティを使用すると、形状が選択されたり、サイズ変更されたり、再配置されたり、他の要素とグループ化されたり、テキストが編集されたりするのを防ぐことができます。

```java
// ウォーターマーク形状を変更からロック
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **ウォーターマークを前面に移動**

Aspose.Slidesでは、形状のZ順序を[IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)メソッドを通じて設定できます。これを行うには、プレゼンテーションスライドリストからこのメソッドを呼び出し、形状の参照とその順序番号を引数として渡します。この方法を使用すると、形状を前面に移動させたり、スライドの後方に送ったりできます。この機能は、プレゼンテーションの前面にウォーターマークを配置したいときに特に便利です。

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定**

以下は、ウォーターマークをスライドに対角線上に配置するための回転を調整するコード例です。

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **ウォーターマークに名前を付ける**

Aspose.Slidesでは、形状の名前を設定できます。形状名を使用すると、将来的にそれにアクセスして変更または削除できます。ウォーターマーク形状の名前を設定するには、[IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-)メソッドに割り当てます。

```java
watermarkShape.setName("watermark");
```

## **ウォーターマークを削除**

ウォーターマーク形状を削除するには、[IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--)メソッドを使用してスライドの形状内でそれを見つけます。その後、ウォーターマーク形状を[IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)メソッドに渡します。

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

**Aspose.Slidesの無料** [ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)オンラインツールをチェックすることをお勧めします。

![ウォーターマークを追加および削除するためのオンラインツール](online_tools.png)