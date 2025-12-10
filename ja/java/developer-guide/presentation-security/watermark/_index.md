---
title: Javaでプレゼンテーションにウォーターマークを追加する
linktitle: ウォーターマーク
type: docs
weight: 40
url: /ja/java/watermark/
keywords:
- ウォーターマーク
- テキストウォーターマーク
- 画像ウォーターマーク
- ウォーターマークの追加
- ウォーターマークの変更
- ウォーターマークの除去
- ウォーターマークの削除
- PPTへのウォーターマーク追加
- PPTXへのウォーターマーク追加
- ODPへのウォーターマーク追加
- PPTからのウォーターマーク除去
- PPTXからのウォーターマーク除去
- ODPからのウォーターマーク除去
- PPTからのウォーターマーク削除
- PPTXからのウォーターマーク削除
- ODPからのウォーターマーク削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "JavaでPowerPointおよびOpenDocumentのプレゼンテーションにテキストや画像のウォーターマークを管理し、ドラフト、機密情報、著作権などを示すことができます。"
---

## **ウォーターマークについて**

**ウォーターマーク**は、スライドやプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークはドラフトであることを示す（例: 「Draft」ウォーターマーク）や、機密情報が含まれていることを示す（例: 「Confidential」ウォーターマーク）、所属会社を指定する（例: 「Company Name」ウォーターマーク）、プレゼンテーションの作成者を識別するなどに使用されます。ウォーターマークは、コピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。ウォーターマークは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用されます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP ファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/java/) では、PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、デザインや動作を変更するさまざまな方法があります。共通点として、テキストウォーターマークを追加する場合は[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)インターフェイスを使用し、画像ウォーターマークを追加する場合は[PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)クラスを使用するか、ウォーターマーク形状に画像をフィルとして設定します。`PictureFrame`は[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)インターフェイスを実装しており、形状オブジェクトの柔軟な設定をすべて利用できます。`ITextFrame`は形状ではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)オブジェクトにラップされます。

ウォーターマークの適用方法は 2 つあります：単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスターは、すべてのスライドにウォーターマークを適用するために使用されます。ウォーターマークはスライドマスターに追加され、そこで完全にデザインされ、個々のスライドでの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないと見なされます。ウォーターマーク（正確にはウォーターマークの親形状）の編集を防止するために、Aspose.Slides は形状ロック機能を提供します。特定の形状は通常のスライドまたはスライドマスター上でロックできます。スライドマスター上でウォーターマーク形状がロックされている場合、すべてのプレゼンテーションスライドでロックされます。

将来的に削除したい場合に備えて、ウォーターマークに名前を設定すると、スライドの形状コレクションから名前で見つけることができます。

ウォーターマークは任意の方法でデザインできますが、一般的には中央揃え、回転、最前面表示などの共通機能があります。以下の例でそれらの使い方を検討します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、または ODP でテキストウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)インターフェイスで表されます。このタイプは[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)から継承されておらず、柔軟な位置決めプロパティが豊富です。したがって、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)オブジェクトは[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)オブジェクトにラップされます。形状にウォーターマークテキストを追加するには、以下のように[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドを使用します。
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参照" %}} 
- [TextFrame クラスの使用方法](/slides/ja/java/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)に追加します。残りのロジックは単一スライドに追加する場合と同じです—[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)オブジェクトを作成し、[addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)メソッドでウォーターマークを追加します。
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参照" %}} 
- [スライドマスターの使用方法](/slides/ja/java/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定する**

デフォルトでは、矩形形状は塗りつぶしと線の色が設定されています。次のコード行で形状を透明にします。
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **テキストウォーターマークのフォントを設定する**

以下のようにテキストウォーターマークのフォントを変更できます。
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、次のコードを使用します。
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **テキストウォーターマークを中央揃えにする**

スライド上でウォーターマークを中央に配置することが可能です。以下のように行います。
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


以下の画像は最終結果を示しています。

![The text watermark](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションのスライドに画像ウォーターマークを追加するには、次の手順を実行します。
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **ウォーターマークの編集をロックする**

ウォーターマークの編集を防止する必要がある場合は、形状上で[IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)メソッドを使用します。このプロパティにより、形状の選択、サイズ変更、再配置、他の要素とのグループ化、テキスト編集のロックなどが可能になります。
```java
// ウォーターマーク形状の変更をロックする
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **ウォーターマークを最前面に持ってくる**

Aspose.Slidesでは、形状の Z オーダーは[IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、形状参照と順序番号を渡すことで、形状を最前面または背面に移動できます。この機能は、ウォーターマークをプレゼンテーションの前面に配置する必要がある場合に特に有用です。
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ウォーターマークの回転を設定する**

以下は、ウォーターマークをスライド全体に対して対角線上に配置するための回転を調整するコード例です。
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **ウォーターマークに名前を設定する**

Aspose.Slidesでは、形状に名前を設定できます。形状名を使用すると、将来その形状にアクセスして変更または削除できます。ウォーターマーク形状の名前を設定するには、[IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-)メソッドに割り当てます。
```java
watermarkShape.setName("watermark");
```


### **ウォーターマークを削除する**

ウォーターマーク形状を削除するには、[IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--)メソッドでスライドの形状から検索し、[IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)メソッドに渡します。
```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**ウォーターマークとは何か、なぜ使用すべきか？**

ウォーターマークとは、スライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知度を高めたり、プレゼンテーションの不正使用を防止したりするために使用されます。

**プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？**

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションのすべてのスライドにウォーターマークを追加できます。スライドをすべてループして、個別にウォーターマーク設定を適用します。

**ウォーターマークの透明度を調整するにはどうすればよいですか？**

形状の塗りつぶし設定([getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getFillFormat--))を変更することで、ウォーターマークの透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドの内容の妨げになりません。

**ウォーターマークでサポートされる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式をサポートしています。

**テキストウォーターマークのフォントやスタイルをカスタマイズできますか？**

はい、プレゼンテーションのデザインやブランドの一貫性に合わせて、任意のフォント、サイズ、スタイルを選択できます。

**ウォーターマークの位置や向きを変更するにはどうすればよいですか？**

形状の座標、サイズ、回転プロパティを変更することで、プログラムからウォーターマークの位置や向きを調整できます。