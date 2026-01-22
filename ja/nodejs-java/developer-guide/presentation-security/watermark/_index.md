---
title: "JavaScript でプレゼンテーションにウォーターマークを追加する"
linktitle: "ウォーターマーク"
type: docs
weight: 40
url: /ja/nodejs-java/watermark/
keywords:
- "ウォーターマーク"
- "テキストウォーターマーク"
- "画像ウォーターマーク"
- "ウォーターマークを追加"
- "ウォーターマークを変更"
- "ウォーターマークを削除"
- "ウォーターマークを削除"
- "PPT にウォーターマークを追加"
- "PPTX にウォーターマークを追加"
- "ODP にウォーターマークを追加"
- "PPT からウォーターマークを削除"
- "PPTX からウォーターマークを削除"
- "ODP からウォーターマークを削除"
- "PPT からウォーターマークを削除"
- "PPTX からウォーターマークを削除"
- "ODP からウォーターマークを削除"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Node.js で PowerPoint および OpenDocument のプレゼンテーションのテキストと画像のウォーターマークを管理し、ドラフトや機密情報、著作権などを示すことができます。"
---

## **ウォーターマークについて**

**プレゼンテーション**の**ウォーターマーク**は、スライドまたはすべてのスライド全体で使用されるテキストまたは画像のスタンプです。通常、ドラフトであることを示す（例:「Draft」ウォーターマーク）、機密情報を含むことを示す（例:「Confidential」ウォーターマーク）、所属企業を示す（例:「Company Name」ウォーターマーク）、作成者を特定するなどに使用されます。ウォーターマークは、プレゼンテーションをコピーすべきでないことを示すことで著作権侵害を防止する役割も果たします。ウォーターマークは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用されます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP ファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) では、PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、そのデザインや動作を変更するさまざまな方法が用意されています。共通点は、テキストウォーターマークを追加する場合は [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 型を使用し、画像ウォーターマークを追加する場合は [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) クラスまたはウォーターマーク形状に画像を塗りつぶすことです。`PictureFrame` は [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 型を実装しているため、形状オブジェクトの柔軟な設定すべてを利用できます。`TextFrame` は形状ではなく設定が限定的なので、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 通りあります: 単一スライドに適用するか、すべてのスライドに適用するかです。すべてのスライドにウォーターマークを適用するには **Slide Master** を使用します。ウォーターマークは Slide Master に追加され、そこで完全にデザインされ、個々のスライドの編集権限に影響を与えることなくすべてのスライドに適用されます。

通常、ウォーターマークは他のユーザーによる編集ができないように設定されます。ウォーターマーク（正確にはウォーターマークの親形状）の編集を防止するために、Aspose.Slides は形状ロック機能を提供します。特定の形状は通常のスライドまたは Slide Master 上でロックできます。Slide Master 上でウォーターマーク形状がロックされると、すべてのスライドでロックされた状態になります。

将来ウォーターマークを削除したい場合に備えて、名前を設定しておくとスライドの形状コレクションから名前で検索できます。

ウォーターマークのデザインは自由ですが、一般的に中央揃え、回転、前面表示などの共通の特徴があります。以下の例でそれらの使い方を説明します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加**

PPT、PPTX、ODP にテキストウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 型で表されます。この型は [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) から継承されておらず、柔軟な位置指定プロパティがありません。そのため、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトは [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) オブジェクトにラップされます。形状にウォーターマークテキストを追加するには、ウォーターマークテキストを引数として渡す [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) メソッドを使用します:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="See also" %}} 
- 使用方法 [TextFrame](/slides/ja/nodejs-java/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキストウォーターマークを追加**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) に追加します。残りのロジックは単一スライドに追加する場合と同じです。まず [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) オブジェクトを作成し、次に [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) メソッドでウォーターマークを追加します:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="See also" %}} 
- [使用方法 ](/slides/ja/nodejs-java/slide-master/)[Slide Master](/slides/ja/nodejs-java/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定**

デフォルトでは、長方形形状は塗りつぶしと線の色が設定されています。次のコードで形状を透明にします。
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


### **ウォーターマークテキストの色を設定**

ウォーターマークテキストの色を設定するには、次のコードを使用します。
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

スライド上でウォーターマークを中央に配置するには、次のようにします。
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

### **プレゼンテーションに画像ウォーターマークを追加**

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

ウォーターマークの編集を防止する必要がある場合は、形状の [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) メソッドを使用します。このプロパティを使用すると、形状の選択、サイズ変更、位置変更、他の要素とのグループ化、テキストの編集ロックなどを保護できます。
```javascript
// ウォーターマーク形状の変更をロック
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **ウォーターマークを前面に持ってくる**

Aspose.Slides では、形状の Z オーダーを [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、形状参照と順序番号を渡します。これにより、形状を前面に持ってくるか、背面に送ることができます。この機能は、ウォーターマークをスライドの前面に配置したい場合に特に便利です。
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ウォーターマークの回転を設定**

次のコード例は、ウォーターマークをスライド全体に対角線状に配置するための回転設定方法を示しています。
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **ウォーターマークに名前を付ける**

Aspose.Slides では形状に名前を設定できます。形状名を使用すれば、将来その形状にアクセスして変更または削除できます。ウォーターマーク形状に名前を付けるには、[**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) メソッドを使用します。
```javascript
watermarkShape.setName("watermark");
```


### **ウォーターマークを削除**

ウォーターマーク形状を削除するには、[AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) メソッドでスライドの形状コレクションから検索し、[**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) メソッドに形状を渡します。
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**ウォーターマークとは何ですか、なぜ使用すべきですか？**

ウォーターマークはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知を高めたり、プレゼンテーションの不正使用を防止したりするために使用されます。

**プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？**

はい、Aspose.Slides を使用すれば、プレゼンテーションの各スライドにウォーターマークを追加できます。すべてのスライドをループし、個別にウォーターマーク設定を適用します。

**ウォーターマークの透明度を調整するには？**

形状の [fill 設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) を変更することで、ウォーターマークの透明度を調整できます。これにより、ウォーターマークが控えめになり、スライド内容の妨げになりません。

**ウォーターマークでサポートされている画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式をサポートしています。

**テキストウォーターマークのフォントやスタイルをカスタマイズできますか？**

はい、プレゼンテーションのデザインやブランドの一貫性に合わせて、任意のフォント、サイズ、スタイルを選択できます。

**ウォーターマークの位置や向きを変更するには？**

形状の座標、サイズ、回転プロパティを変更することで、ウォーターマークの位置や向きを調整できます。