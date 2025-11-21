---
title: "ズームの管理"
type: docs
weight: 60
url: /ja/nodejs-java/manage-zoom/
keywords: "ズーム、ズームフレーム、ズームの追加、ズームフレームの書式設定、サマリズーム、PowerPoint プレゼンテーション、Java、Aspose.Slides for Node.js via Java"
description: "PowerPoint プレゼンテーションにズームまたはズームフレームを JavaScript で追加する"
---

## **概要**

PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、または領域へジャンプしたり、そこから戻ったりできます。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。 

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドにまとめるには、[Summary Zoom](#Summary-Zoom) を使用します。  
* 選択したスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。  
* 単一のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。  

## **スライドズーム**

スライドズームを使用すると、プレゼンテーションの流れを中断せずに、任意の順序でスライド間を自由にナビゲートできます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも活用できます。

スライドズームを使用すると、単一のキャンバス上にいるかのように複数の情報にドリルダウンできます。  

![overview_image](slidezoomsel.png)

スライドズーム用オブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType) 列挙、[ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) クラス、そして [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスのいくつかのメソッドを提供します。

### **ズームフレームの作成**

スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	ズームフレームをリンクしたい新規スライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、スライドにズームフレームを作成する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 2番目のスライドの背景を作成します
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 2番目のスライドのテキストボックスを作成します
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 3番目のスライドの背景を作成します
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 3番目のスライドのテキストボックスを作成します
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame オブジェクトを追加します
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **カスタム画像付きズームフレームの作成**

Node.js 用 Aspose.Slides for Java を使用して、別のスライドプレビュー画像を持つズームフレームを作成する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	ズームフレームをリンクしたい新規スライドを作成します。  
3.	スライドに識別テキストと背景を追加します。  
4.	[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加してフレームを埋めます。  
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、別の画像を使用したズームフレームの作成方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 2番目のスライドの背景を作成します
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 3番目のスライドのテキストボックスを作成します
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // ズームオブジェクト用の新しい画像を作成します
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ZoomFrame オブジェクトを追加します
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **ズームフレームの書式設定**

前述のセクションではシンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。ズームフレームに適用できる書式設定オプションは多数あります。

スライド上でズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	リンクしたい新規スライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) に関連付けられた Images コレクションに画像を追加してフレームを埋めます。  
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。  
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。  
9.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、スライド上でズームフレームの書式を変更する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 2番目のスライドの背景を作成します
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 2番目のスライドのテキストボックスを作成します
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 3番目のスライドの背景を作成します
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 3番目のスライドのテキストボックスを作成します
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame オブジェクトを追加します
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // ズームオブジェクト用の新しい画像を作成します
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // zoomFrame1 オブジェクトにカスタム画像を設定します
    zoomFrame1.setImage(picture);
    // zoomFrame2 オブジェクトのズームフレーム書式を設定します
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // zoomFrame2 オブジェクトの背景非表示設定
    zoomFrame2.setShowBackground(false);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **セクションズーム**

セクションズームは、プレゼンテーション内の特定のセクションへのリンクです。重要なセクションに戻ったり、プレゼンテーションのつながりを強調したりするのに使用できます。  

![overview_image](seczoomsel.png)

セクションズーム用オブジェクトについては、Aspose.Slides が [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) クラスと、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスのいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新規スライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームをリンクしたい新規セクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、スライドにセクションズームフレームを作成する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame オブジェクトを追加します
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **カスタム画像付きセクションズームフレームの作成**

Node.js 用 Aspose.Slides for Java を使用して、別のスライドプレビュー画像を持つセクションズームフレームを作成する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新規スライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームをリンクしたい新規セクションを作成します。  
5.	[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) に関連付けられた Images コレクションに画像を追加してフレームを埋めます。  
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、別の画像を使用したセクションズームフレームの作成方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // ズームオブジェクト用の新しい画像を作成します
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // SectionZoomFrame オブジェクトを追加します
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。セクションズームフレームに適用できる書式設定オプションは多数あります。

スライド上でセクションズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新規スライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームをリンクしたい新規セクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。  
7.	[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) に関連付けられた Images コレクションに画像を追加してフレームを埋めます。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。  
10.	セクションズームフレームオブジェクトの画像から背景を削除します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	トランジションの継続時間を変更します。  
13.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、セクションズームフレームの書式を変更する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame オブジェクトを追加します
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame の書式設定
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **サマリズーム**

サマリズームは、プレゼンテーションの全体像を一度に表示できるランディングページのようなものです。プレゼンテーション中に、任意の順序でスライド間をジャンプしたり、前に戻ったり、スキップしたりして、流れを中断せずに内容を自由に操作できます。  

![overview_image](sumzoomsel.png)

サマリズーム用オブジェクトについては、Aspose.Slides が [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame)、[SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection)、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) クラスと、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスのいくつかのメソッドを提供します。

### **サマリズームの作成**

スライドにサマリズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新規セクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、スライドにサマリズームフレームを作成する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 2", slide);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 3", slide);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 4", slide);
    // SummaryZoomFrame オブジェクトを追加します
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **サマリズームセクションの追加と削除**

サマリズームフレーム内のすべてのセクションは [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) オブジェクトで表され、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) オブジェクトに格納されます。セクションの追加または削除は、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) クラスを介して行います。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新規セクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	プレゼンテーションに新しいスライドとセクションを追加します。  
5.	作成したセクションをサマリズームフレームに追加します。  
6.	サマリズームフレームから最初のセクションを削除します。  
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、サマリズームフレーム内のセクションを追加および削除する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame オブジェクトを追加します
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Summary Zoom にセクションを追加します
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Summary Zoom からセクションを削除します
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **サマリズームセクションの書式設定**

より複雑なサマリズームセクションオブジェクトを作成するには、シンプルなフレームの書式を変更する必要があります。サマリズームセクションオブジェクトに適用できる書式設定オプションは多数あります。

サマリズームフレーム内のセクションオブジェクトの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新規セクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリズームセクションを取得します。  
5.	[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) に関連付けられた images コレクションに画像を追加してフレームを埋めます。  
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
7.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。  
8.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
9.	トランジションの継続時間を変更します。  
10.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この JavaScript コードは、サマリズームセクションオブジェクトの書式を変更する方法を示しています。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションに新しいスライドを追加します
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 1", slide);
    // プレゼンテーションに新しいスライドを追加します
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // プレゼンテーションに新しいセクションを追加します
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame オブジェクトを追加します
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 最初の SummaryZoomSection オブジェクトを取得します
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // SummaryZoomSection オブジェクトの書式設定
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // プレゼンテーションを保存します
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**対象スライドを表示した後、親スライドに戻す制御は可能ですか？**

はい。 [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) には `setReturnToParent` メソッドがあり、有効にすると閲覧者は対象コンテンツ閲覧後に元のスライドへ戻ります。

**ズーム遷移の「速度」や継続時間を調整できますか？**

はい。Zoom には `setTransitionDuration` メソッドが用意されており、ジャンプアニメーションの長さを制御できます。

**プレゼンテーションに含められるズームオブジェクトの数に制限はありますか？**

明確な API 上の上限はドキュメントに記載されていません。実際の制限はプレゼンテーション全体の複雑さや閲覧環境のパフォーマンスに依存します。多数のズームフレームを追加できますが、ファイルサイズや描画時間を考慮してください。