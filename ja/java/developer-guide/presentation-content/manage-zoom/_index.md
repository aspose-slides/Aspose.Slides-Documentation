---
title: Javaでプレゼンテーションズームを管理
linktitle: ズームを管理
type: docs
weight: 60
url: /ja/java/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームの追加
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してズームを作成およびカスタマイズし、セクション間をジャンプし、PPT、PPTX、ODP プレゼンテーション全体にサムネイルやトランジションを追加します。"
---

## **概要**
PowerPoint のズームは、プレゼンテーションの特定のスライド、セクション、範囲間を行き来できるようにします。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。 

![概要画像](overview.png)

* プレゼンテーション全体を 1 枚のスライドに要約するには、[Summary Zoom](#Summary-Zoom) を使用します。
* 選択したスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。
* 単一のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションの流れを中断せずに、任意の順序でスライド間を自由に移動でき、プレゼンテーションがよりダイナミックになります。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも使用できます。

スライドズームを使用すると、単一のキャンバス上にいるような感覚で複数の情報にドリルダウンできます。 

![スライドズーム選択画像](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) インターフェイス、そして [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **ズームフレームの作成**

スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	ズームフレームでリンクする新しいスライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、スライドにズームフレームを作成する方法を示しています。
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2番目のスライドのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 3番目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3番目のスライドのテキストボックスを作成
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

### **カスタム画像付きズームフレームの作成**
Aspose.Slides for Java を使用すると、別のスライドプレビュー画像を使用したズームフレームを次の手順で作成できます。  
1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	ズームフレームでリンクする新しいスライドを作成します。  
3.	スライドに識別テキストと背景を追加します。  
4.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
6.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、別の画像を使用したズームフレームの作成方法を示しています。
``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドの背景を作成
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 3番目のスライドのテキストボックスを作成
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
前のセクションではシンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズームフレームには適用できる書式設定オプションがいくつかあります。  

スライド上でズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	リンク先となる新しいスライドを作成します。  
3.	作成したスライドに識別テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。  
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。  
5.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、スライド上でズームフレームの書式設定を変更する方法を示しています。 
``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドの背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2番目のスライドのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 3番目のスライドの背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3番目のスライドのテキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adds ZoomFrame objects
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

セクションズームは、プレゼンテーション内のセクションへのリンクです。強調したいセクションに戻るためにセクションズームを使用したり、プレゼンテーションの特定の部分同士のつながりを強調したりできます。 

![セクションズーム選択画像](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、スライドにズームフレームを作成する方法を示しています。
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

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム画像付きセクションズームフレームの作成**

Aspose.Slides for Java を使用すると、別のスライドプレビュー画像を使用したセクションズームフレームを次の手順で作成できます。  

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、別の画像を使用したズームフレームの作成方法を示しています。
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

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームには適用できる書式設定オプションがいくつかあります。  

スライド上でセクションズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。  
7.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドへ戻る* 動作を設定します。  
10.	セクションズームフレームオブジェクトの画像から背景を削除します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	トランジションの期間を変更します。  
13.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、セクションズームフレームの書式設定を変更する方法を示しています。
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


## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべての要素を一度に表示するランディング ページのようなものです。プレゼンテーション中に、ズームを使用して任意の順序で任意の場所へジャンプしたり、スキップしたり、再訪したりして、プレゼンテーションの流れを中断せずに操作できます。

![サマリーズーム選択画像](sumzoomsel.png)

サマリーズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) インターフェイス配下のいくつかのメソッドを提供します。

### **サマリーズームの作成**

スライドにサマリーズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリーズームフレームを追加します。  
4.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、サマリーズームフレームをスライドに作成する方法を示しています。
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

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 3", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 4", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) オブジェクトとして表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) オブジェクトに格納されます。セクションの追加または削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) インターフェイスを通じて次の手順で行えます。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリーズームフレームを追加します。  
4.	プレゼンテーションに新しいスライドとセクションを追加します。  
5.	作成したセクションをサマリーズームフレームに追加します。  
6.	サマリーズームフレームから最初のセクションを削除します。  
7.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています。
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

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリーズームセクションオブジェクトには適用できる書式設定オプションがいくつかあります。  

サマリーズームフレーム内のサマリーズームセクションオブジェクトの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリーズームフレームを追加します。  
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションを取得します。  
7.	[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) オブジェクトを作成します。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドへ戻る* 動作を設定します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	トランジションの期間を変更します。  
13.	変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。  

この Java コードは、サマリーズームセクションオブジェクトの書式設定を変更する方法を示しています。
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

**対象を表示した後に「親」スライドに戻る動作を制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、これを有効にすると、閲覧者は対象コンテンツを表示した後に元のスライドに戻ります。

**ズーム トランジションの「速度」や期間を調整できますか？**

はい。Zoom では `TransitionDuration` を設定でき、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められる Zoom オブジェクトの数に制限はありますか？**

明確な API の上限はドキュメントに記載されていません。実際の制限はプレゼンテーション全体の複雑さやビューアーの性能に依存します。多数の Zoom フレームを追加できますが、ファイルサイズとレンダリング時間には注意が必要です。