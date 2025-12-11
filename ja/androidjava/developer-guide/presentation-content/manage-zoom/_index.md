---
title: Androidでプレゼンテーションズームを管理する
linktitle: ズームを管理する
type: docs
weight: 60
url: /ja/androidjava/manage-zoom/
keywords:
- ズーム
- ズーム フレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームの追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してズームを作成・カスタマイズします — セクション間をジャンプし、サムネイルやトランジションを PPT、PPTX、ODP プレゼンテーションに追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、部分へ、またそこからジャンプできます。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドに要約するには、[Summary Zoom](#Summary-Zoom) を使用します。
* 特定のスライドだけを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。
* 特定のセクションだけを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **スライド ズーム**
スライド ズームを使用すると、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断することなく、より動的な資料を作成できます。スライド ズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも活用できます。

スライド ズームを使用すると、単一のキャンバス上にいるように感じながら、複数の情報にドリルダウンできます。

![overview_image](slidezoomsel.png)

スライド ズーム オブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) インターフェイス、そして [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **ズーム フレームの作成**

スライドにズーム フレームを追加する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズーム フレームでリンクする新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。
5.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはスライドにズーム フレームを作成する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //2枚目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //2枚目のスライドのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //3枚目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //3枚目のスライドのテキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame オブジェクトを追加
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム画像付きズーム フレームの作成**
Aspose.Slides for Android via Java を使用すると、別のスライド プレビュー画像を使用したズーム フレームを次のように作成できます。
1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	ズーム フレームでリンクする新しいスライドを作成します。 
3.	スライドに識別用テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
5.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。
6.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードは別の画像を使用したズーム フレームの作成方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2枚目のスライドの背景を作成
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 3枚目のスライドのテキストボックスを作成
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

### **ズーム フレームの書式設定**
前節ではシンプルなズーム フレームの作成方法を示しました。より複雑なズーム フレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズーム フレームに適用できる書式設定オプションはいくつかあります。

スライド上でズーム フレームの書式設定を制御する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	最初のスライドにズーム フレーム（作成したスライドへの参照を含む）を追加します。
5.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
6.	最初のズーム フレーム オブジェクトにカスタム画像を設定します。
7.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。
8.	2 番目のズーム フレーム オブジェクトの画像から背景を削除します。
5.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはスライド上でズーム フレームの書式設定を変更する方法を示しています: 
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //2枚目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //2枚目のスライドのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //3枚目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //3枚目のスライドのテキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame オブジェクトを追加
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //zoomFrame1 オブジェクトにカスタム画像を設定
    zoomFrame1.setImage(picture);

    //zoomFrame2 オブジェクトのズームフレーム書式を設定
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    //zoomFrame2 オブジェクトの背景を表示しない設定
    zoomFrame2.setShowBackground(false);

    //プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **セクション ズーム**

セクション ズームはプレゼンテーション内のセクションへのリンクです。セクション ズームを使用して、強調したいセクションに戻ったり、プレゼンテーションの構成要素同士のつながりをハイライトしたりできます。

![overview_image](seczoomsel.png)

セクション ズーム オブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **セクション ズーム フレームの作成**

スライドにセクション ズーム フレームを追加する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	最初のスライドにセクション ズーム フレーム（作成したセクションへの参照を含む）を追加します。
6.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはスライドにセクション ズーム フレームを作成する方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新しいセクションを追加
    pres.getSections().addSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム画像付きセクション ズーム フレームの作成**

Aspose.Slides for Android via Java を使用すると、別のスライド プレビュー画像を使用したセクション ズーム フレームを次のように作成できます。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
5.	最初のスライドにセクション ズーム フレーム（作成したセクションへの参照を含む）を追加します。
6.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードは別の画像を使用したセクション ズーム フレームの作成方法を示しています:
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新しいセクションをプレゼンテーションに追加
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

### **セクション ズーム フレームの書式設定**

より複雑なセクション ズーム フレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクション ズーム フレームに適用できる書式設定オプションはいくつかあります。

スライド上でセクション ズーム フレームの書式設定を制御する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	最初のスライドにセクション ズーム フレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクション ズーム オブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
8.	作成したセクション ズーム フレーム オブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
10.	セクション ズーム フレーム オブジェクトの画像から背景を削除します。
11.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。
12.	トランジションの長さを変更します。
13.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはセクション ズーム フレームの書式設定を変更する方法を示しています:
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

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```



## **サマリー ズーム**

サマリー ズームは、プレゼンテーションのすべての要素が一度に表示されるランディング ページのようなものです。プレゼンテーション中に、ズームを使用して任意の順序で任意の場所へ移動できます。創造的にスキップしたり、再度表示したりしても、プレゼンテーションの流れを中断しません。

![overview_image](sumzoomsel.png)

サマリー ズーム オブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **サマリー ズームの作成**

スライドにサマリー ズーム フレームを追加する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	最初のスライドにサマリー ズーム フレームを追加します。
4.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはスライドにサマリー ズーム フレームを作成する方法を示しています:
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


### **サマリー ズーム セクションの追加と削除**

サマリー ズーム フレーム内のすべてのセクションは [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) オブジェクトに格納されます。サマリー ズーム セクション オブジェクトは、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスを通じて次のように追加または削除できます。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	最初のスライドにサマリー ズーム フレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリー ズーム フレームに追加します。
6.	サマリー ズーム フレームから最初のセクションを削除します。
7.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはサマリー ズーム フレームでのセクションの追加と削除方法を示しています:
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新しいセクションをプレゼンテーションに追加
    pres.getSections().addSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新しいセクションをプレゼンテーションに追加
    pres.getSections().addSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新しいセクションをプレゼンテーションに追加
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


### **サマリー ズーム セクションの書式設定**

より複雑なサマリー ズーム セクション オブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリー ズーム セクション オブジェクトに適用できる書式設定オプションはいくつかあります。

サマリー ズーム フレーム内のサマリー ズーム セクション オブジェクトの書式設定を制御する方法は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	最初のスライドにサマリー ズーム フレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリー ズーム セクション オブジェクトを取得します。
7.	[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) オブジェクトを作成します。
8.	作成したセクション ズーム フレーム オブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
11.	2 番目のズーム フレーム オブジェクトの線の書式を変更します。
12.	トランジションの長さを変更します。
13.	変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この Java コードはサマリー ズーム セクション オブジェクトの書式設定を変更する方法を示しています:
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

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Gets the first SummaryZoomSection object
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatting for SummaryZoomSection object
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

**対象を表示した後に「親」スライドに戻る動作を制御できますか？**

はい。[Zoom フレーム](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) には、対象コンテンツを表示した後に元のスライドに戻す「return-to-parent」動作があります。

**ズーム トランジションの「速度」や期間を調整できますか？**

はい。ズームはトランジション期間を設定でき、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められるズーム オブジェクトの数に制限はありますか？**

明確な API 上の上限は文書化されていません。実際の制限はプレゼンテーションの全体的な複雑さやビューアのパフォーマンスに依存します。多数のズーム フレームを追加できますが、ファイル サイズやレンダリング時間を考慮してください。