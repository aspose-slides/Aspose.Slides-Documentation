---
title: ズームの管理
type: docs
weight: 60
url: /ja/androidjava/manage-zoom/
keywords: "ズーム, ズームフレーム, ズームの追加, ズームフレームのフォーマット, サマリーズーム, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPointのズームを使用すると、特定のスライド、セクション、プレゼンテーションの部分へジャンプできます。プレゼンテーション中に、コンテンツ間を迅速に移動できるこの機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を1つのスライドで要約するには、[サマリーズーム](#Summary-Zoom)を使用します。
* 選択したスライドのみを表示するには、[スライドズーム](#Slide-Zoom)を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom)を使用します。

## **スライドズーム**
スライドズームを使うと、プレゼンテーションの流れを中断することなく、任意の順序でスライド間を自由に移動でき、プレゼンテーションがよりダイナミックになります。スライドズームはセクションがあまりない短いプレゼンテーションに最適ですが、異なるプレゼンテーションシナリオでも使用できます。

スライドズームを使用すると、1つのキャンバス上にいるように感じながら、複数の情報の詳細に掘り下げることができます。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについて、Aspose.Slidesは[ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType)列挙型、[IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame)インターフェイス、および[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)インターフェイスの下にいくつかのメソッドを提供しています。

### **ズームフレームの作成**

この方法でスライドにズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームをリンクする新しいスライドを作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、スライドにズームフレームを作成する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドのための背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2番目のスライドのためのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("セカンド スライド");

    // 3番目のスライドのための背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3番目のスライドのためのテキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("サード スライド");

    //ズームフレームオブジェクトを追加
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **カスタム画像を使ったズームフレームの作成**
Aspose.Slides for Android via Javaを使用すると、異なるスライドプレビュー画像を持つズームフレームを次のように作成できます：
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームをリンクする新しいスライドを作成します。
3. スライドに識別テキストと背景を追加します。
4. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これはフレームを埋めるために使用されます。
5. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、異なる画像でズームフレームを作成する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドのための背景を作成
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2番目のスライドのためのテキストボックスを作成
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("セカンド スライド");

    // ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //ズームフレームオブジェクトを追加
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **ズームフレームのフォーマット**
前のセクションでは、単純なズームフレームを作成する方法を示しました。より複雑なズームフレームを作成するには、単純なフレームのフォーマットを変更する必要があります。ズームフレームに適用できるフォーマットオプションは複数あります。

スライド上のズームフレームのフォーマットを次のように制御できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. ズームフレームをリンクする新しいスライドを作成します。
3. 作成したスライドにいくつかの識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これはフレームを埋めるために使用されます。
6. 最初のズームフレームオブジェクトにカスタム画像を設定します。
7. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
8. 2番目のズームフレームオブジェクトの画像から背景を削除します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、スライド上のズームフレームのフォーマットを変更する方法を示しています：

``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 2番目のスライドのための背景を作成
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 2番目のスライドのためのテキストボックスを作成
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("セカンド スライド");

    // 3番目のスライドのための背景を作成
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 3番目のスライドのためのテキストボックスを作成
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("サード スライド");

    //ズームフレームオブジェクトを追加
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
    // zoomFrame1オブジェクトにカスタム画像を設定
    zoomFrame1.setImage(picture);

    // zoomFrame2オブジェクトのためのズームフレームフォーマットを設定
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // zoomFrame2オブジェクトの背景を表示しない設定
    zoomFrame2.setShowBackground(false);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用すると、本当に強調したいセクションに戻ることができます。また、プレゼンテーションの特定の部分がどのように関連するかを強調するためにも使用できます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについて、Aspose.Slidesは[ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame)インターフェイスと[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)インターフェイスの下にいくつかのメソッドを提供しています。

### **セクションズームフレームの作成**

この方法でスライドにセクションズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクする新しいセクションを作成します。
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、スライドにズームフレームを作成する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **カスタム画像を使ったセクションズームフレームの作成**

Aspose.Slides for Android via Javaを使用すると、異なるスライドプレビュー画像を持つセクションズームフレームを次のように作成できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクする新しいセクションを作成します。
5. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これはフレームを埋めるために使用されます。
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、異なる画像でセクションズームフレームを作成する方法を示しています：

``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    // ズームオブジェクト用の新しい画像を作成
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **セクションズームフレームのフォーマット**

より複雑なセクションズームフレームを作成するには、単純なフレームのフォーマットを変更する必要があります。セクションズームフレームに適用できるフォーマットオプションは複数あります。

スライド上のセクションズームフレームのフォーマットを次のように制御できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクする新しいセクションを作成します。
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 作成したセクションズームオブジェクトのサイズと位置を変更します。
7. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これはフレームを埋めるために使用されます。
8. 作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9. *リンクされたセクションから元のスライドに戻る*機能を設定します。
10. セクションズームフレームオブジェクトの画像から背景を削除します。
11. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
12. トランジションの duración を変更します。
13. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、セクションズームフレームのフォーマットを変更する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // セクションズームフレームのためのフォーマット
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

サマリーズームは、プレゼンテーションのすべての部分が一度に表示されるランディングページのようなものです。プレゼンテーション中に、このズームを使用して、プレゼンテーション内の1つの場所から別の場所に好きな順序で移動できます。クリエイティブな発想を得ることができ、先に進めたり、スライドショーの部分を revisit したりすることができ、プレゼンテーションの流れを中断することなくスムーズに進められます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトについて、Aspose.Slidesは[ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)、および[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)インターフェイスの下にいくつかのメソッドを提供しています。

### **サマリーズームの作成**

この方法でスライドにサマリーズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 識別背景と新しいセクションを作成した新しいスライドを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、スライドにサマリーズームフレームを作成する方法を示しています：

``` java 
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 2", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 3", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 4", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは、[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)オブジェクトに格納されています。これにより、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)インターフェイスを通じてサマリーズームセクションオブジェクトを追加または削除できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 識別背景と新しいセクションを作成した新しいスライドを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 新しいスライドとセクションをプレゼンテーションに追加します。
5. 作成したセクションをサマリーズームフレームに追加します。
6. サマリーズームフレームから最初のセクションを削除します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 2", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    ISection section3 = pres.getSections().addSection("セクション 3", slide);

    // サマリズームにセクションを追加
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // サマリーズームからセクションを削除
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // プレゼンテーションを保存
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **サマリーズームセクションのフォーマット**

より複雑なサマリーズームセクションオブジェクトを作成するには、単純なフレームのフォーマットを変更する必要があります。サマリーズームセクションオブジェクトに適用できるフォーマットオプションは複数あります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトのフォーマットを次のように制御できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 識別背景と新しいセクションを作成した新しいスライドを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. [ISummaryZoomSectionCollection]から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
5. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これはフレームを埋めるために使用されます。
6. 作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7. *リンクされたセクションから元のスライドに戻る*機能を設定します。
8. 2番目のズームフレームオブジェクトのラインフォーマットを変更します。
9. トランジションのdurationを変更します。
10. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このJavaコードは、サマリーズームセクションオブジェクトのフォーマットを変更する方法を示しています：

``` java
Presentation pres = new Presentation();
try {
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // プレゼンテーションに新しいセクションを追加
    pres.getSections().addSection("セクション 2", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 最初のサマリーズームセクションオブジェクトを取得
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // サマリズームセクションオブジェクトのフォーマット
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