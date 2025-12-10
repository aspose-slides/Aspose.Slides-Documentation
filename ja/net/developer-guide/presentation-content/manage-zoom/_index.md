---
title: .NET でプレゼンテーションズームを管理
linktitle: ズームの管理
type: docs
weight: 60
url: /ja/net/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリズーム
- ズームの追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、サムネイルやトランジションを PPT、PPTX、ODP プレゼンテーション全体に追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、領域へ、またそこからジャンプできます。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を 1 枚のスライドにまとめるには、[サマリーズーム](#Summary-Zoom) を使用します。
* 選択したスライドだけを表示するには、[スライドズーム](#Slide-Zoom) を使用します。
* 単一のセクションだけを表示するには、[セクションズーム](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションがよりダイナミックになり、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断することなく進められます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも活用できます。

スライドズームは、単一のキャンバス上にいるかのように、複数の情報を掘り下げて表示できます。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) 列挙体、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **ズームフレームの作成**

スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクさせる新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、スライドにズームフレームを作成する方法を示しています:
``` csharp
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //2枚目のスライドの背景を作成
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //2枚目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //3枚目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //3枚目のスライド用のテキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrameオブジェクトを追加
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **カスタム画像付きズームフレームの作成**
Aspose.Slides for .NET を使用すると、別のスライドプレビュー画像を持つズームフレームを次の手順で作成できます。
1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクさせる新しいスライドを作成します。 
3.	スライドに識別用テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
5.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、別の画像を使用したズームフレームの作成方法を示しています:
``` csharp
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //2番目のスライドの背景を作成
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //3番目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //ZoomFrameオブジェクトを追加
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **ズームフレームの書式設定**
前のセクションでは、シンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズームフレームには適用できる書式設定オプションがいくつかあります。

スライド上でズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクさせる新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、スライド上でズームフレームの書式設定を変更する方法を示しています:
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

    // 2枚目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 3枚目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3枚目のスライド用のテキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1オブジェクトにカスタム画像を設定
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2オブジェクトのズームフレーム書式を設定
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2オブジェクトの背景を表示しない設定
    zoomFrame2.ShowBackground = false;

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。強調したいセクションへ戻るためにセクションズームを使用したり、プレゼンテーションの特定のパーツがどのように結びつくかをハイライトしたりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクさせる新しいセクションを作成します。 
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、スライドにズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrameオブジェクトを追加
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
4.	ズームフレームをリンクさせる新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、別の画像を使用したズームフレームの作成方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    //ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //SectionZoomFrameオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームに適用できる書式設定オプションはいくつかあります。

スライド上でセクションズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクさせる新しいセクションを作成します。 
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。 
10.	セクションズームフレームオブジェクトの画像から背景を削除します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、セクションズームフレームの書式設定を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    //SectionZoomFrameオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    //SectionZoomFrameの書式設定
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

    //プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべてのパーツを一度に表示するランディングページのようなものです。プレゼンテーション中に、ズームを使って任意の順序でスライド間を移動でき、クリエイティブにスキップしたり、スライドショーの一部を再訪したりできます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイス下のいくつかのメソッドを提供します。

### **サマリーズームの作成**

スライドにサマリーズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	サマリーズームフレームを最初のスライドに追加します。
4.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、スライドにサマリーズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 2", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 3", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 4", slide);

    // SummaryZoomFrameオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) オブジェクトとして表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) オブジェクトに格納されます。次の手順で [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスを介してサマリーズームセクションオブジェクトを追加または削除できます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、サマリーズームフレーム内のセクションの追加と削除方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrameオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoomにセクションを追加
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoomからセクションを削除
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **サマリーズームセクションの書式設定**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリーズームセクションオブジェクトに適用できる書式設定オプションはいくつかあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
7.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。 
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを PPTX ファイルとして書き出ます。

この C# コードは、サマリーズームセクションオブジェクトの書式設定を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrameオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 最初のSummaryZoomSectionオブジェクトを取得
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSectionオブジェクトの書式設定
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**対象を表示した後、親スライドに戻ることはできますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、オンにすると対象コンテンツを訪問した後、元のスライドに戻ります。

**Zoom の速度やトランジションの継続時間を調整できますか？**

はい。Zoom は `TransitionDuration` を設定でき、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含まれる Zoom オブジェクトの数に制限はありますか？**

明確に文書化されたハードな API 制限はありません。実際の制限はプレゼンテーション全体の複雑さやビューアのパフォーマンスに依存します。多数の Zoom フレームを追加できますが、ファイルサイズや描画時間を考慮してください。