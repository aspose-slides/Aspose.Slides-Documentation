---
title: Java でプレゼンテーションに透かしを追加
linktitle: 透かし
type: docs
weight: 40
url: /ja/java/watermark/
keywords:
- 透かし
- テキスト透かし
- 画像透かし
- 透かしの追加
- 透かしの変更
- 透かしの削除
- 透かしの削除
- PPT への透かし追加
- PPTX への透かし追加
- ODP への透かし追加
- PPT からの透かし削除
- PPTX からの透かし削除
- ODP からの透かし削除
- PPT からの透かし削除
- PPTX からの透かし削除
- ODP からの透かし削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java で PowerPoint と OpenDocument のプレゼンテーションにテキストおよび画像の透かしを管理し、ドラフト、機密情報、著作権などを示します。"
---
## **概要**

**透かし** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションが草案であること（例: 「Draft」透かし）や機密情報が含まれていること（例: 「Confidential」透かし）を示したり、どの会社に属しているか（例: 「Company Name」透かし）を明示したり、プレゼンテーションの作者を特定したりするために使用されます。透かしは、プレゼンテーションをコピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。透かしは PowerPoint と OpenOffice の両方のプレゼンテーション形式で使用されます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP のファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/ja/java/) では、PowerPoint や OpenOffice ドキュメントに透かしを作成し、そのデザインや動作を変更するさまざまな方法が用意されています。共通点として、テキスト透かしを追加する場合は [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) インターフェイスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe/) クラスまたは透かしシェイプに画像を貼り付けます。`PictureFrame` は [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) インターフェイスを実装しているため、シェイプ オブジェクトの柔軟な設定をすべて使用できます。`ITextFrame` はシェイプではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) オブジェクトにラップされます。

透かしの適用方法は 2 つあります。単一のスライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライド マスタを使用すると、透かしをすべてのスライドに適用できます。透かしはスライド マスタに追加され、そこでデザインが完了した後、個々のスライドの透かし編集権限に影響を与えることなくすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないものと見なされます。透かし（正確には透かしの親シェイプ）の編集を防止するために、Aspose.Slides はシェイプ ロック機能を提供します。特定のシェイプは通常のスライドまたはスライド マスタ上でロックできます。スライド マスタ上で透かしシェイプがロックされている場合、すべてのプレゼンテーション スライドでロックされます。

透かしに名前を設定すれば、将来削除したい場合にスライドのシェイプ一覧から名前で見つけることができます。

透かしは任意の方法でデザインできますが、一般的にはセンター揃え、回転、前面表示などの共通要素があります。以下のサンプルでこれらの使い方を確認します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加**

PPT、PPTX、ODP にテキスト透かしを追加するには、まずスライドにシェイプを追加し、次にそのシェイプにテキスト フレームを追加します。テキスト フレームは [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) から継承されておらず、透かしの位置を柔軟に設定するための豊富なプロパティがありません。そのため、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) オブジェクトにラップされます。シェイプに透かしテキストを追加するには、以下のように [addTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドを使用します。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="関連記事" %}} 
- [TextFrame クラスの使用方法](/slides/ja/java/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト透かしを追加**

テキスト透かしをプレゼンテーション全体（すべてのスライド）に追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterslide/) に追加します。単一スライドに透かしを追加するロジックと同様に、[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) オブジェクトを作成し、[addTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドで透かしを追加します。

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="関連記事" %}} 
- [スライドマスタの使用方法](/slides/ja/java/slide-master/)
{{% /alert %}}

### **透かしシェイプの透明度を設定**

デフォルトでは、長方形シェイプは塗りつぶしと線の色が設定されています。以下のコードでシェイプを透明にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **テキスト透かしのフォントを設定**

以下の例のように、テキスト透かしのフォントを変更できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **透かしテキストの色を設定**

透かしテキストの色を設定するには、次のコードを使用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **テキスト透かしを中央揃え**

透かしをスライドの中央に配置することが可能です。以下の手順で実現します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

以下の画像は最終結果を示しています。

![テキスト透かし](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加**

プレゼンテーションのスライドに画像透かしを追加するには、次の手順を実行します。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **透かしの編集をロック**

透かしの編集を防止したい場合は、シェイプに対して [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) メソッドを使用します。このプロパティにより、シェイプの選択、サイズ変更、再配置、他の要素とのグループ化、テキスト編集のロックなどが可能になります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 透かしシェイプの変更をロック
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **透かしを最前面に移動**

Aspose.Slides では、シェイプの Z 順序を [IShapeCollection.reorder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、シェイプ参照と順序番号を渡すことで、シェイプを最前面または背面に移動できます。透かしをプレゼンテーションの前面に配置したい場合に特に有用です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **透かしの回転を設定**

透かしをスライド全体に対して斜めに配置するための回転調整コード例です。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **透かしに名前を設定**

Aspose.Slides ではシェイプに名前を付けることができます。シェイプ名を使用すれば、将来その透かしを変更または削除する際に簡単にアクセスできます。透かしシェイプの名前を設定するには、[IAutoShape.setName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setName-java.lang.String-) メソッドを使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **透かしを削除**

透かしシェイプを削除するには、まず [IAutoShape.getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) メソッドでスライドのシェイプから名前を検索し、次にそのシェイプを [IShapeCollection.remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) メソッドに渡します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **よくある質問**

### **透かしとは何か、なぜ使用すべきか**

透かしはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

### **プレゼンテーションのすべてのスライドに透かしを追加できますか？**

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションの全スライドに透かしを追加できます。すべてのスライドを反復処理し、個別に透かし設定を適用します。

### **透かしの透明度はどのように調整できますか？**

シェイプの塗りつぶし設定（[getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getFillFormat--)）を変更することで、透かしの透明度を調整できます。これにより、透かしが控えめになり、スライドの内容の妨げになりません。

### **透かしに使用できる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式をサポートしています。

### **テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい、プレゼンテーションのデザインやブランドの一貫性に合わせて、任意のフォント、サイズ、スタイルを選択できます。

### **透かしの位置や向きを変更するにはどうすればよいですか？**

シェイプの座標、サイズ、回転プロパティをプログラムで変更することで、透かしの位置や向きを調整できます。