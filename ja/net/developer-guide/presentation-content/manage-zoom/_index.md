---
title: ズームの管理
type: docs
weight: 60
url: /ja/net/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- ズームの追加
- ズームフレームの書式設定
- サマリズーム
- PowerPointプレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPoint のズーム機能を使用すると、特定のスライド、セクション、プレゼンテーションの一部にジャンプしたり戻ったりできます。プレゼンテーション中に、コンテンツを素早く移動できるこの機能は非常に便利です。

![概要画像](overview.png)

* プレゼンテーション全体を 1 枚のスライドに要約するには、[Summary Zoom](#Summary-Zoom) を使用します。
* 選択したスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。
* 単一のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションがよりダイナミックになり、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断せずに済みます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも使用できます。

スライドズームは、単一のキャンバス上にいるかのように複数の情報にドリルダウンできるようにします。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスのいくつかのメソッドを提供します。

### **Creating Zoom Frames**
スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドに、作成したスライドへの参照を含むズームフレームを追加します。
5.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、スライド上にズームフレームを作成する方法を示しています:
``` csharp
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2枚目のスライドの背景を作成します
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2枚目のスライド用のテキストボックスを作成します
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 3枚目のスライドの背景を作成します
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3枚目のスライド用のテキストボックスを作成します
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame オブジェクトを追加します
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Creating Zoom Frames with Custom Images**
Aspose.Slides for .NET を使用すると、異なるスライドプレビュー画像を持つズームフレームを次の手順で作成できます。 
1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。 
3.	スライドに識別テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成し、フレームの塗りつぶしに使用します。
5.	最初のスライドに、作成したスライドへの参照を含むズームフレームを追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、異なる画像を使用したズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2枚目のスライドの背景を作成します
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 3枚目のスライド用のテキストボックスを作成します
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ズームオブジェクト用の新しい画像を作成します
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //ZoomFrame オブジェクトを追加します
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatting Zoom Frames**
前のセクションでは、シンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズームフレームに適用できる書式設定オプションはいくつかあります。 

スライド上でズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドに、作成したスライドへの参照を含むズームフレームを追加します。
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像背景を削除します。
5.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、スライド上でズームフレームの書式設定を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2枚目のスライドの背景を作成します
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2枚目のスライド用のテキストボックスを作成します
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 3枚目のスライドの背景を作成します
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3枚目のスライド用のテキストボックスを作成します
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame オブジェクトを追加します
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ズームオブジェクト用の新しい画像を作成します
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1 オブジェクトのカスタム画像を設定します
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2 オブジェクトのズームフレーム書式を設定します
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2 オブジェクトの背景を表示しない設定
    zoomFrame2.ShowBackground = false;

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **セクションズーム**
セクションズームは、プレゼンテーション内のセクションへのリンクです。強調したいセクションに戻るために使用したり、プレゼンテーションの各部分がどのように接続しているかを強調したりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスのいくつかのメソッドを提供します。

### **Creating Section Zoom Frames**
スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	最初のスライドに、作成したセクションへの参照を含むセクションズームフレームを追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、スライド上にセクションズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加します
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Creating Section Zoom Frames with Custom Images**
Aspose.Slides for .NET を使用すると、異なるスライドプレビュー画像を持つセクションズームフレームを次の手順で作成できます。 

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
5.	最初のスライドに、作成したセクションへの参照を含むセクションズームフレームを追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、異なる画像を使用したセクションズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新しいセクションをプレゼンテーションに追加します
    pres.Sections.AddSection("Section 1", slide);

    // ズームオブジェクト用の新しい画像を作成します
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SectionZoomFrame オブジェクトを追加します
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatting Section Zoom Frames**
より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームに適用できる書式設定オプションはいくつかあります。 

スライド上でセクションズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	最初のスライドに、作成したセクションへの参照を含むセクションズームフレームを追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
10.	セクションズームフレームオブジェクトの画像背景を削除します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、セクションズームフレームの書式設定を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame オブジェクトを追加します
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

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **サマリズーム**
サマリズームは、プレゼンテーションのすべての要素が一度に表示されるランディングページのようなものです。プレゼンテーション中に、任意の順序で任意の場所へジャンプできるため、創造的に進めたり、前後に飛び回ったりしても、プレゼンテーションの流れを中断せずに済みます。

![overview_image](sumzoomsel.png)

サマリズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスのいくつかのメソッドを提供します。

### **Creating Summary Zoom**
スライドにサマリズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	作成したスライド用に識別背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリズームフレームを追加します。
4.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、スライド上にサマリズームフレームを作成する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 2", slide);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 3", slide);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 4", slide);

    // SummaryZoomFrame オブジェクトを追加します
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Adding and Removing Summary Zoom Section**
サマリズームフレーム内のすべてのセクションは [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) オブジェクトとして表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) オブジェクトに格納されます。サマリズームセクションオブジェクトは、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) インターフェイスを介して次の手順で追加または削除できます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	作成したスライド用に識別背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリズームフレームに追加します。
6.	サマリズームフレームから最初のセクションを削除します。
7.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、サマリズームフレームでセクションを追加および削除する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加します
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoom にセクションを追加します
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoom からセクションを削除します
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Formatting Summary Zoom Sections**
より複雑なサマリズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリズームセクションオブジェクトに適用できる書式設定オプションはいくつかあります。 

サマリズームフレーム内のサマリズームセクションオブジェクトの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2.	作成したスライド用に識別背景と新しいセクションを持つ新しいスライドを作成します。
3.	最初のスライドにサマリズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリズームセクションオブジェクトを取得します。
7.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトに関連付けられた images コレクションに画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C# コードは、サマリズームセクションオブジェクトの書式設定を変更する方法を示しています:
``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加します
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 1", slide);

    //プレゼンテーションに新しいスライドを追加します
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加します
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame オブジェクトを追加します
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 最初の SummaryZoomSection オブジェクトを取得します
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection オブジェクトの書式設定
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // プレゼンテーションを保存します
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

はい。[Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) には `ReturnToParent` 動作があり、これを有効にすると対象コンテンツの表示後に元のスライドに戻ります。

**Can I adjust the 'speed' or duration of the Zoom transition?**

はい。Zoom では `TransitionDuration` を設定でき、ジャンプアニメーションの長さを制御できます。

**Are there limits on how many Zoom objects a presentation can contain?**

ドキュメントに記載されたハードな API 制限はありません。実際の制限はプレゼンテーションの全体的な複雑さやビューアのパフォーマンスに依存します。多数のズームフレームを追加できますが、ファイルサイズとレンダリング時間を考慮してください。