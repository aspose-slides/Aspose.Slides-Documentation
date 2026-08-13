---
title: Android でプレゼンテーションにウォーターマークを追加する
linktitle: ウォーターマーク
type: docs
weight: 40
url: /ja/androidjava/watermark/
keywords:
- ウォーターマーク
- テキストウォーターマーク
- 画像ウォーターマーク
- ウォーターマークを追加する
- ウォーターマークを変更する
- ウォーターマークを削除する
- ウォーターマークを削除する
- PPT にウォーターマークを追加する
- PPTX にウォーターマークを追加する
- ODP にウォーターマークを追加する
- PPT からウォーターマークを削除する
- PPTX からウォーターマークを削除する
- ODP からウォーターマークを削除する
- PPT からウォーターマークを削除する
- PPTX からウォーターマークを削除する
- ODP からウォーターマークを削除する
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android の Java で PowerPoint および OpenDocument プレゼンテーションにテキストと画像のウォーターマークを管理し、ドラフトや機密情報などを示すことができます。"
---
## **イントロダクション**

**ウォーターマーク** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークはプレゼンテーションがドラフトであること（例: 「Draft」ウォーターマーク）や機密情報を含むこと（例: 「Confidential」ウォーターマーク）を示したり、所属企業を明示したり（例: 「Company Name」ウォーターマーク）、著者を特定したりするために使用されます。ウォーターマークは、コピーすべきでないことを示すことで著作権侵害を防止する役割も果たします。ウォーターマークは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用できます。Aspose.Slides では、PowerPoint PPT、PPTX、および OpenOffice ODP ファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/ja/android-java/) では、PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、デザインや動作を変更するさまざまな方法が提供されています。共通点として、テキストウォーターマークを追加する場合は [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) インターフェイスを使用し、画像ウォーターマークを追加する場合は [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe/) クラスを使用するか、ウォーターマーク形状に画像をフィルとして設定します。`PictureFrame` は [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) インターフェイスを実装しているため、形状オブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` は形状ではなく設定が制限されるため、[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 つあります: 単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスタを使用すると、ウォーターマークをすべてのスライドに適用できます。ウォーターマークはスライドマスタに追加され、そこで完全にデザインされ、個々のスライドでウォーターマークの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないように設定されます。ウォーターマーク（正確にはウォーターマークの親形状）が編集されないようにするため、Aspose.Slides は形状ロック機能を提供します。特定の形状は通常のスライドでもスライドマスタでもロックできます。スライドマスタでウォーターマーク形状をロックすると、すべてのプレゼンテーションスライドでロックされた状態になります。

将来的に削除したい場合に備えて、ウォーターマークに名前を付けることができます。名前でスライドの形状一覧から検索できるようになります。

ウォーターマークは任意のデザインで作成できますが、センター揃え、回転、前面表示などの共通の特徴があります。以下の例でこれらの使い方を検討します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、または ODP にテキストウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) から継承されておらず、柔軟な位置設定プロパティを持ちません。そのため、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) オブジェクトでラップされます。形状にウォーターマークテキストを追加するには、以下のように [addTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドを使用します。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="参照" %}} 
- [TextFrame クラスの使用方法](/slides/ja/androidjava/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキストウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドに追加する場合と同じです。まず [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) オブジェクトを作成し、次に [addTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドでウォーターマークを追加します。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="参照" %}} 
- [スライドマスタの使用方法](/slides/ja/androidjava/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定する**

デフォルトでは、矩形形状は塗りつぶしと線の色が設定されています。次のコードで形状を透明にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **テキストウォーターマークのフォントを設定する**

以下のようにテキストウォーターマークのフォントを変更できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、次のコードを使用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **テキストウォーターマークを中央揃えにする**

ウォーターマークをスライドの中央に配置するには、以下の手順を実行します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

以下の画像が最終結果です。

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションのスライドに画像ウォーターマークを追加するには、次の手順を実行します。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **ウォーターマークの編集をロックする**

ウォーターマークの編集を防止する必要がある場合は、形状の [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) メソッドを使用します。このプロパティにより、形状の選択、サイズ変更、位置変更、他の要素とのグループ化、テキストの編集ロックなどが可能になります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // ウォーターマーク形状の変更をロックする
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **ウォーターマークを前面に持ってくる**

Aspose.Slides では、形状の Z オーダーを [IShapeCollection.reorder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、形状参照と順序番号を渡すことで、形状を前面または背面に移動できます。ウォーターマークをスライドの前面に配置したい場合に便利です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **ウォーターマークの回転を設定する**

以下のコード例は、ウォーターマークをスライドの対角線上に配置するために回転させる方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **ウォーターマークに名前を付ける**

Aspose.Slides では形状に名前を設定できます。形状名を使用すると、将来その形状にアクセスして変更または削除できます。ウォーターマーク形状に名前を付けるには、[IAutoShape.setName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) メソッドを使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **ウォーターマークを削除する**

ウォーターマーク形状を削除するには、[IAutoShape.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getName--) メソッドでスライドの形状一覧から検索し、見つけた形状を [IShapeCollection.remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) メソッドに渡します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### ウォーターマークとは何ですか？また、なぜ使用すべきですか？

ウォーターマークは、スライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知度を高めたり、プレゼンテーションの不正使用を防止したりします。

### プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションのすべてのスライドにウォーターマークを追加できます。すべてのスライドを反復処理して個別に設定を適用できます。

### ウォーターマークの透明度を調整するには？

形状の塗りつぶし設定（[getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getFillFormat--)）を変更することで、透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドのコンテンツの邪魔になりません。

### ウォーターマークでサポートされている画像形式は何ですか？

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG など、さまざまな画像形式をサポートしています。

### テキストウォーターマークのフォントとスタイルをカスタマイズできますか？

はい、フォント、サイズ、スタイルを自由に選択して、プレゼンテーションのデザインやブランドの一貫性に合わせることができます。

### ウォーターマークの位置や向きを変更するには？

形状の座標、サイズ、回転プロパティをプログラムで変更することで、ウォーターマークの位置や向きを調整できます。