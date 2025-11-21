---
title: ".NET でプレゼンテーションズームを管理"
linktitle: "ズームを管理"
type: docs
weight: 60
url: /ja/net/manage-zoom/
keywords:
- "ズーム"
- "ズームフレーム"
- "スライドズーム"
- "セクションズーム"
- "サマリズーム"
- "ズームを追加"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET 用 Aspose.Slides でズームを作成およびカスタマイズ — セクション間をジャンプし、PPT、PPTX、ODP プレゼンテーション全体にサムネイルやトランジションを追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーションの特定のスライド、セクション、領域間を自由にジャンプできます。プレゼンテーション中にコンテンツを素早くナビゲートできるこの機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドにまとめるには、[Summary Zoom](#Summary-Zoom) を使用します。  
* 特定のスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。  
* 特定のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションの流れを中断せずに、任意の順序でスライド間を自由に移動でき、プレゼンテーションをよりダイナミックにします。スライドズームはセクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオで活用できます。

スライドズームを使用すると、単一のキャンバス上にいるかのように複数の情報を掘り下げられます。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **ズームフレームの作成**

スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	ズームフレームでリンクする新しいスライドを作成します。  
3.	作成したスライドに識別用テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、スライド上にズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2枚目のスライドの背景を作成
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2枚目のスライド用テキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 3枚目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3枚目のスライド用テキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame オブジェクトを追加
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **カスタム画像付きズームフレームの作成**
Aspose.Slides for .NET を使用すると、別のスライドプレビュー画像を持つズームフレームを次の手順で作成できます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	ズームフレームでリンクする新しいスライドを作成します。  
3.	スライドに識別用テキストと背景を追加します。  
4.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成してフレームを埋めます。  
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
6.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、別の画像を使用したズームフレームの作成方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Creates a background for the second slide
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Creates a text box for the third slide
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Creates a new image for the zoom object
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Adds the ZoomFrame object
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Saves the presentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **ズームフレームの書式設定**
前節ではシンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。ズームフレームに適用できる書式設定オプションはいくつかあります。

スライド上でズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	リンク先となる新しいスライドを作成します。  
3.	作成したスライドに識別用テキストと背景を追加します。  
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。  
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。  
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。  
9.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、スライド上でズームフレームの書式を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2枚目のスライドの背景を作成
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2枚目のスライド用テキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 3枚目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3枚目のスライド用テキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame オブジェクトを追加
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1 オブジェクトにカスタム画像を設定
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2 オブジェクトのズームフレーム書式を設定
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2 オブジェクトの背景を表示しない設定
    zoomFrame2.ShowBackground = false;

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。強調したいセクションに戻るためや、プレゼンテーションの特定の部分がどのように連携しているかを示すために使用できます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) インターフェイスと [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、スライド上にセクションズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **カスタム画像付きセクションズームフレームの作成**

Aspose.Slides for .NET を使用すると、別のスライドプレビュー画像を持つセクションズームフレームを次の手順で作成できます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
7.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、別の画像を使用したセクションズームフレームの作成方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    //ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。セクションズームフレームに適用できる書式設定オプションはいくつかあります。

スライド上でセクションズームフレームの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームでリンクする新しいセクションを作成します。  
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。  
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。  
7.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	*リンクされたセクションから元のスライドに戻る* 動作を有効にします。  
10.	セクションズームフレームオブジェクトの画像から背景を削除します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	遷移時間を変更します。  
13.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、セクションズームフレームの書式を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // SectionZoomFrame の書式設定
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```



## **サマリズーム**

サマリズームは、プレゼンテーションのすべての要素を一度に表示するランディングページのようなものです。プレゼンテーション中にサマリズームを使用すれば、任意の順序でスライド間を行き来でき、創造的にスキップしたり、再訪したりしながらプレゼンテーションの流れを中断せずに進められます。

![overview_image](sumzoomsel.png)

サマリズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **サマリズームの作成**

スライドにサマリズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、スライド上にサマリズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 2", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 3", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 4", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **サマリズームセクションの追加と削除**

サマリズームフレーム内のすべてのセクションは [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) オブジェクトに格納されています。セクションの追加または削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスを通じて次のように行えます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	プレゼンテーションに新しいスライドとセクションを追加します。  
5.	作成したセクションをサマリズームフレームに追加します。  
6.	サマリズームフレームから最初のセクションを削除します。  
7.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、サマリズームフレーム内のセクションを追加および削除する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoom にセクションを追加
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoom からセクションを削除
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **サマリズームセクションの書式設定**

より複雑なサマリズームセクションオブジェクトを作成するには、シンプルなフレームの書式を変更する必要があります。サマリズームセクションオブジェクトに適用できる書式設定オプションはいくつかあります。

サマリズームフレーム内のセクションオブジェクトの書式を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。  
3.	最初のスライドにサマリズームフレームを追加します。  
4.	`ISummaryZoomSectionCollection` から最初のセクションオブジェクトを取得します。  
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
7.	*リンクされたセクションから元のスライドに戻る* 動作を有効にします。  
8.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
9.	遷移時間を変更します。  
10.	変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、サマリズームセクションオブジェクトの書式を変更する方法を示しています:
```csharp
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    //新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    //新しいセクションをプレゼンテーションに追加
    pres.Sections.AddSection("Section 2", slide);

    //SummaryZoomFrame オブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //最初の SummaryZoomSection オブジェクトを取得
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //SummaryZoomSection オブジェクトの書式設定
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**対象を表示した後に「親」スライドに戻る動作を制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、これを有効にすると、閲覧者は対象コンテンツの閲覧後に元のスライドへ戻ります。

**ズーム遷移の「速度」や期間を調整できますか？**

はい。Zoom では `TransitionDuration` を設定でき、ジャンプアニメーションの時間を制御できます。

**プレゼンテーションに含められるズームオブジェクトの数に制限はありますか？**

ドキュメント化されたハードな API 制限はありません。実際の制限はプレゼンテーション全体の複雑さやビューアーのパフォーマンスに依存します。多くのズームフレームを追加できますが、ファイルサイズやレンダリング時間を考慮してください。