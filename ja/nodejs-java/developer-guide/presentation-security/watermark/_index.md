---
title: ウォーターマーク
type: docs
weight: 40
url: /ja/nodejs-java/watermark/
keywords: "プレゼンテーションのウォーターマーク"
description: "Aspose.Slides を使用して PowerPoint にウォーターマークを使用します。ppt プレゼンテーションにウォーターマークを追加したり、削除したりできます。画像ウォーターマークまたはテキストウォーターマークを挿入します。"
---

## **ウォーターマークについて**

**ウォーターマーク** は、プレゼンテーションのスライドまたはすべてのスライドに使用されるテキストまたは画像のスタンプです。通常、ドラフトであることを示す（例: 「Draft」ウォーターマーク）、機密情報が含まれていることを示す（例: 「Confidential」ウォーターマーク）、所属企業を示す（例: 「Company Name」ウォーターマーク）、プレゼンテーションの作成者を特定する、などに使用されます。ウォーターマークは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防止するのに役立ちます。ウォーターマークは、PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用されます。Aspose.Slides では、PowerPoint の PPT、PPTX、OpenOffice の ODP ファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) では、PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、デザインや動作を変更するさまざまな方法が用意されています。共通点は、テキストウォーターマークを追加する場合は [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 型を使用し、画像ウォーターマークを追加する場合は [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) クラスを使用するか、ウォーターマーク シェイプに画像を塗りつぶすことです。`PictureFrame` は [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 型を実装しているため、シェイプ オブジェクトのすべての柔軟な設定を使用できます。`TextFrame` はシェイプではなく設定が限られているため、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) オブジェクトにラップされています。

ウォーターマークの適用方法は 2 通りあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスターを使用すると、ウォーターマークをすべてのスライドに適用できます。ウォーターマークはスライドマスターに追加され、そこで完全にデザインされ、個々のスライドの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないように設定されます。ウォーターマーク（正確にはウォーターマークの親シェイプ）が編集されないようにするために、Aspose.Slides はシェイプ ロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスター上でロックできます。スライドマスター上でウォーターマーク シェイプがロックされると、すべてのスライドでロックされます。

将来的にウォーターマークを削除したい場合に備えて、名前を設定しておくとスライドのシェイプ一覧から名前で検索できます。

ウォーターマークはさまざまなデザインが可能ですが、一般的には中央揃え、回転、前面表示などの共通特徴があります。以下の例でこれらの使い方を説明します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加**

PPT、PPTX、ODP にテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキスト フレームを追加します。テキスト フレームは [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 型で表されます。この型は [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) から継承されておらず、柔軟な位置設定プロパティがありません。そのため、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトは [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) オブジェクトでラップされます。シェイプにウォーターマーク テキストを追加するには、ウォーターマーク テキストを引数に取る [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) メソッドを使用します:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参考" %}} 
- [How to use](/slides/ja/nodejs-java/slide-master/)[TextFrame](/slides/ja/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **プレゼンテーション全体にテキストウォーターマークを追加**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) に追加します。残りのロジックは単一スライドに追加する場合と同様です。まず [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) オブジェクトを作成し、次に [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) メソッドでウォーターマークを追加します:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="参考" %}} 
- [How to use](/slides/ja/nodejs-java/slide-master/)[Slide Master](/slides/ja/nodejs-java/slide-master/)
{{% /alert %}}

### **ウォーターマーク シェイプの透明度を設定**

デフォルトでは、矩形シェイプは塗りつぶしと線の色が設定されています。次のコードでシェイプを透明にします。
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **テキストウォーターマークのフォントを設定**

以下のようにテキストウォーターマークのフォントを変更できます。
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **ウォーターマーク テキストの色を設定**

ウォーターマーク テキストの色を設定するには、次のコードを使用します。
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **テキストウォーターマークを中央揃え**

スライド上でウォーターマークを中央揃えにするには、次のようにします。
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


以下の画像は最終結果を示しています。

![The text watermark](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーション全体に画像ウォーターマークを追加**

すべてのスライドに画像ウォーターマークを追加するには、次の手順を実行します。
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **ウォーターマークの編集をロック**

ウォーターマークの編集を防止する必要がある場合は、シェイプの [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) メソッドを使用します。このプロパティにより、シェイプの選択、サイズ変更、位置変更、他の要素とのグループ化、テキストの編集ロックなどが保護できます。
```javascript
// ウォーターマークシェイプの変更をロック
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="参考" %}} 
- [How to Lock Shapes from Editing](/slides/ja/nodejs-java/presentation-locking/)
{{% /alert %}}

### **ウォーターマークを前面に持ってくる**

Aspose.Slides では、シェイプの Z 順序を [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、シェイプ参照と順序番号を渡します。これにより、シェイプを前面に持ってくる、または背面に送ることが可能です。プレゼンテーションの前面にウォーターマークを配置したい場合に便利です。
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ウォーターマークの回転を設定**

ウォーターマークをスライド全体に対して対角線上に配置する回転例を次に示します。
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **ウォーターマークに名前を設定**

Aspose.Slides ではシェイプに名前を設定できます。名前を付けておくと、将来そのシェイプにアクセスして変更または削除できます。ウォーターマーク シェイプの名前を設定するには、[**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) メソッドを使用します。
```javascript
watermarkShape.setName("watermark");
```


### **ウォーターマークを削除**

ウォーターマーク シェイプを削除するには、[AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) メソッドでスライドのシェイプ一覧から見つけ、[**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) メソッドにシェイプを渡します。
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**ウォーターマークとは何ですか？また、なぜ使用すべきですか？**

ウォーターマークは、スライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知度を高めたり、プレゼンテーションの不正使用を防止したりするのに役立ちます。

**プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？**

はい、Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドにウォーターマークを追加できます。すべてのスライドを反復処理し、個別にウォーターマーク設定を適用します。

**ウォーターマークの透明度はどのように調整できますか？**

シェイプの [fill 設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) を変更することで、ウォーターマークの透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドの内容の妨げにならなくなります。

**ウォーターマークで使用できる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式をサポートしています。

**テキストウォーターマークのフォントやスタイルはカスタマイズできますか？**

はい、フォント、サイズ、スタイルを自由に選択して、プレゼンテーションのデザインやブランドの一貫性に合わせることができます。

**ウォーターマークの位置や向きはどのように変更できますか？**

シェイプの座標、サイズ、回転プロパティを変更することで、ウォーターマークの位置や向きを調整できます。