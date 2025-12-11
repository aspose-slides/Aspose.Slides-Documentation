---
title: Androidでプレゼンテーションズームを管理
linktitle: ズームの管理
type: docs
weight: 60
url: /ja/androidjava/manage-zoom/
keywords:
- ズーム
- ズーム フレーム
- スライド ズーム
- セクション ズーム
- サマリー ズーム
- ズーム の追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してズームを作成およびカスタマイズし、セクション間をジャンプし、サムネイルとトランジションを PPT、PPTX、ODP プレゼンテーションに追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、または領域へ簡単にジャンプできます。プレゼンテーション中にコンテンツを素早く移動できるこの機能は、非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドにまとめるには、[概要ズーム](#Summary-Zoom) を使用します。
* 特定のスライドだけを表示するには、[スライドズーム](#Slide-Zoom) を使用します。
* 特定のセクションだけを表示するには、[セクションズーム](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションをより動的にし、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断せずに済みます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも活用できます。

スライドズームは、単一のキャンバス上にいるかのように複数の情報にドリルダウンできるようにします。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトに対して、Aspose.Slides は [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) インターフェイス、そして [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **ズームフレームの作成**

スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームでリンクする新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、スライドにズームフレームを作成する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2枚目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2枚目のスライド用テキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 3枚目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3枚目のスライド用テキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame オブジェクトを追加
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム画像付きズームフレームの作成**
Aspose.Slides for Android via Java を使用すると、別のスライドプレビュー画像を持つズームフレームを次の手順で作成できます。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームでリンクする新しいスライドを作成します。 
3.	スライドに識別テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成してフレームを埋めます。
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、別の画像を使用してズームフレームを作成する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2枚目のスライドの背景を作成
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 3枚目のスライド用テキストボックスを作成
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //ZoomFrame オブジェクトを追加
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **ズームフレームの書式設定**
前節ではシンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。ズームフレームに適用できる書式設定オプションはいくつかあります。

スライド上でズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズームフレームでリンクする新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。
5.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、スライド上でズームフレームの書式を変更する方法を示しています:
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2枚目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2枚目のスライド用テキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 3枚目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3枚目のスライド用テキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame オブジェクトを追加
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // zoomFrame1 オブジェクトにカスタム画像を設定
    zoomFrame1.setImage(picture);

    // zoomFrame2 オブジェクトのズームフレーム書式を設定
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // zoomFrame2 オブジェクトの背景非表示設定
    zoomFrame2.setShowBackground(false);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、強調したいセクションに戻ったり、プレゼンテーションの特定の部分同士のつながりをハイライトしたりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトに対して、Aspose.Slides は [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用背景を追加します。
4.	リンクする新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、スライドにセクションズームフレームを作成する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    //SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム画像付きセクションズームフレームの作成**

Aspose.Slides for Android via Java を使用すると、別のスライドプレビュー画像を持つセクションズームフレームを次の手順で作成できます。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンクする新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成してフレームを埋めます。
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、別の画像を使用してセクションズームフレームを作成する方法を示しています:
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    // ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。セクションズームフレームに適用できる書式設定オプションはいくつかあります。

スライド上でセクションズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンクする新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドへ戻る* 動作を有効にします。 
10.	セクションズームフレームオブジェクトの画像から背景を削除します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの時間を変更します。
13.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、セクションズームフレームの書式を変更する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //新しいセクションをプレゼンテーションに追加
    pres.getSections().addSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // SectionZoomFrame の書式設定
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    //プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべての要素を一度に表示するランディングページのようなものです。プレゼンテーション中に、サマリーズームを使って任意の順序で任意の場所へジャンプできます。クリエイティブにスキップしたり、スライドショーの特定の部分に戻ったりして、プレゼンテーションの流れを止めません。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトに対して、Aspose.Slides は [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **サマリーズームの作成**

スライドにサマリーズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、サマリーズームフレームをスライドに作成する方法を示しています:
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 2", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 3", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 4", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) オブジェクトとして表現され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) に格納されます。セクションの追加や削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスを通じて次のように行えます。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、サマリーズームフレームでセクションを追加および削除する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Summary Zoom にセクションを追加
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Summary Zoom からセクションを削除
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **サマリーズームセクションの書式設定**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式を変更する必要があります。サマリーズームセクションオブジェクトに適用できる書式設定オプションはいくつかあります。

サマリーズームフレーム内のセクションオブジェクトの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションを取得します。
7.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) に関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドへ戻る* 動作を有効にします。 
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの時間を変更します。
13.	修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、サマリーズームセクションオブジェクトの書式を変更する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 最初の SummaryZoomSection オブジェクトを取得
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // SummaryZoomSection オブジェクトの書式設定
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**対象スライドを表示した後、元の「親」スライドに戻す動作を制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) には、戻る動作があり、これを有効にすると閲覧者はターゲット コンテンツを閲覧した後に元のスライドへ戻ります。

**ズームのトランジション「速度」や時間を調整できますか？**

はい。ズームはトランジション時間を設定できるため、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められるズームオブジェクトの数に制限はありますか？**

公式に明記されたハードリミットはありません。実際の制限はプレゼンテーション全体の複雑さやビューアの性能に依存します。ズームフレームは多数追加できますが、ファイルサイズや描画時間を考慮してください。