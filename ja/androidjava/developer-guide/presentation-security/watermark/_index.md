---
title: Android のプレゼンテーションにウォーターマークを追加
linktitle: ウォーターマーク
type: docs
weight: 40
url: /ja/androidjava/watermark/
keywords:
- ウォーターマーク
- テキスト ウォーターマーク
- 画像 ウォーターマーク
- ウォーターマークを追加
- ウォーターマークを変更
- ウォーターマークを削除
- ウォーターマークを削除
- PPT にウォーターマークを追加
- PPTX にウォーターマークを追加
- ODP にウォーターマークを追加
- PPT からウォーターマークを削除
- PPTX からウォーターマークを削除
- ODP からウォーターマークを削除
- PPT からウォーターマークを削除
- PPTX からウォーターマークを削除
- ODP からウォーターマークを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 上の Java で PowerPoint および OpenDocument プレゼンテーションにテキストと画像のウォーターマークを管理し、ドラフトや機密情報などを示します。"
---

## **ウォーターマークについて**

**ウォーターマーク** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、ドラフトであることを示す（例:「Draft」ウォーターマーク）や、機密情報を含むことを示す（例:「Confidential」ウォーターマーク）など、プレゼンテーションがどの会社に属するか（例:「Company Name」ウォーターマーク）や、作成者を識別するために使用されます。ウォーターマークは、プレゼンテーションをコピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。ウォーターマークは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用されます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP のファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/android-java/) では、PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、デザインや動作を変更するさまざまな方法が用意されています。共通点は、テキストウォーターマークを追加する場合は [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) インターフェイスを使用し、画像ウォーターマークを追加する場合は [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) クラスまたは画像でシェイプを塗りつぶすことです。`PictureFrame` は [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスを実装しているため、シェイプ オブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` はシェイプではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 つあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライド全体にウォーターマークを適用するにはスライド マスターを使用します。ウォーターマークはスライド マスターに追加され、そこで完全にデザインされ、個々のスライドの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないように設定されます。ウォーターマーク（正確にはウォーターマークの親シェイプ）を編集できないようにするために、Aspose.Slides はシェイプ ロック機能を提供します。特定のシェイプは通常のスライドまたはスライド マスター上でロックできます。スライド マスター上でウォーターマーク シェイプをロックすると、すべてのプレゼンテーション スライドでロックされた状態になります。

将来的にウォーターマークを削除したい場合に備えて、シェイプ名を設定しておくことができます。名前を付けておけば、スライドのシェイプ一覧から名前で検索して削除できます。

ウォーターマークは任意の方法でデザインできますが、中心揃え、回転、前面表示などの共通の特徴があります。以下のサンプルでこれらの使い方を確認しましょう。

## **テキスト ウォーターマーク**

### **スライドにテキスト ウォーターマークを追加する**

PPT、PPTX、ODP にテキスト ウォーターマークを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキスト フレームを追加します。テキスト フレームは [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) インターフェイスで表されます。このタイプは [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) から継承されていないため、柔軟な位置指定プロパティがありません。そのため、[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) オブジェクトにラップされます。シェイプにウォーターマーク テキストを追加するには、以下のように [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドを使用します。
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参照" %}} 
- [TextFrame クラスの使用方法](/slides/ja/androidjava/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト ウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト ウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドに追加する場合と同じです。まず [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) オブジェクトを作成し、次に [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) メソッドでウォーターマークを設定します。
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参照" %}} 
- [スライド マスターの使用方法](/slides/ja/androidjava/slide-master/)
{{% /alert %}}

### **ウォーターマーク シェイプの透明度を設定する**

既定では、矩形シェイプは塗りつぶしと線の色が設定されています。次のコードでシェイプを透明にできます。
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **テキスト ウォーターマークのフォントを設定する**

以下のようにテキスト ウォーターマークのフォントを変更できます。
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **ウォーターマーク テキストの色を設定する**

ウォーターマーク テキストの色を設定するには、次のコードを使用します。
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```


### **テキスト ウォーターマークを中央に配置する**

ウォーターマークをスライドの中央に配置することができます。以下の手順をご参照ください。
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


以下の画像は最終結果を示しています。

![テキスト ウォーターマーク](text_watermark.png)

## **画像 ウォーターマーク**

### **プレゼンテーションに画像 ウォーターマークを追加する**

プレゼンテーション スライドに画像 ウォーターマークを追加するには、次の手順を実行します。
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **ウォーターマークの編集をロックする**

ウォーターマークの編集を防止する必要がある場合は、シェイプに対して [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) メソッドを使用します。このプロパティにより、シェイプの選択、サイズ変更、再配置、他の要素とのグループ化、テキストの編集ロックなどを保護できます。
```java
// ウォーターマークシェイプの変更をロックする
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **ウォーターマークを前面に持ってくる**

Aspose.Slides では、シェイプの Z 順序を [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) メソッドで設定できます。プレゼンテーションのスライドリストからこのメソッドを呼び出し、シェイプ参照と順序番号を渡すことで、シェイプを前面または背面に移動できます。この機能は、ウォーターマークをプレゼンテーションの前面に配置したい場合に特に便利です。
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ウォーターマークの回転を設定する**

以下のコード例は、ウォーターマークをスライドの対角線上に配置するために回転させる方法を示しています。
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **ウォーターマークに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。名前を付けておけば、将来的にそのシェイプにアクセスして変更または削除できます。ウォーターマーク シェイプに名前を設定するには、[IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) メソッドを使用します。
```java
watermarkShape.setName("watermark");
```


### **ウォーターマークを削除する**

ウォーターマーク シェイプを削除するには、[IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) メソッドでスライドのシェイプ一覧から対象シェイプを取得し、[IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) メソッドに渡します。
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

**ウォーターマークとは何ですか？また、なぜ使用すべきですか？**

ウォーターマークは、スライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知度を高めたり、プレゼンテーションの不正使用を防止したりします。

**プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？**

はい。Aspose.Slides を使用すると、プログラムでプレゼンテーションの各スライドにウォーターマークを追加できます。すべてのスライドをループして個別に設定できます。

**ウォーターマークの透明度はどのように調整しますか？**

シェイプの塗りつぶし設定（[getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getFillFormat--)）を変更することで、透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドの内容の妨げになりません。

**ウォーターマークでサポートされている画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG など、さまざまな画像形式をサポートしています。

**テキスト ウォーターマークのフォントやスタイルはカスタマイズできますか？**

はい。プレゼンテーションのデザインやブランドの一貫性に合わせて、任意のフォント、サイズ、スタイルを選択できます。

**ウォーターマークの位置や向きはどのように変更しますか？**

シェイプの座標、サイズ、回転プロパティをプログラムで変更することで、位置や向きを調整できます。