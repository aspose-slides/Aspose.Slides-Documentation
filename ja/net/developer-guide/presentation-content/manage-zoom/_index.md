---
title: ズームの管理
type: docs
weight: 60
url: /net/manage-zoom/
keywords: 
- ズーム
- ズームフレーム
- ズームの追加
- ズームフレームのフォーマット
- サマリーズーム
- PowerPointプレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPointのズーム機能を使用すると、特定のスライド、セクション、およびプレゼンテーションの一部にジャンプすることができます。プレゼンテーションを行う際に、この内容間を迅速にナビゲートする機能は非常に便利です。

![overview_image](overview.png)

* プレゼンテーション全体を1枚のスライドに要約するには、[サマリーズーム](#Summary-Zoom)を使用します。
* 選択したスライドのみを表示するには、[スライズーム](#Slide-Zoom)を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom)を使用します。

## **スライズーム**
スライズームを使用すると、プレゼンテーションをよりダイナミックにし、プレゼンテーションの流れを中断することなく、選択した順序でスライド間を自由にナビゲートできます。スライズームは、多くのセクションがない短いプレゼンテーションに最適ですが、さまざまなプレゼンテーションシナリオでも使用できます。

スライズームを使用すると、1つのキャンバス上にいるように感じながら、複数の情報に深く掘り下げることができます。

![overview_image](slidezoomsel.png)

スライズームオブジェクトについて、Aspose.Slidesは[ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)列挙型、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)インターフェイス、および[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)インターフェイスのいくつかのメソッドを提供しています。

### **ズームフレームの作成**

次の手順でスライドにズームフレームを追加できます。

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	ズームフレームをリンクするスライドを新しく作成します。
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、スライド上にズームフレームを作成する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2番目のスライドの背景を作成
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2番目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "2番目のスライド";

    // 3番目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3番目のスライド用のテキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "第3のスライド";

    //ズームフレームオブジェクトを追加
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **カスタム画像を使用したズームフレームの作成**
Aspose.Slides for .NETを使用して、異なるスライドプレビュー画像を持つズームフレームを次のように作成できます：
1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	ズームフレームをリンクする新しいスライドを作成します。
3.	スライドに識別テキストと背景を追加します。
4.	[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。これがフレームを埋めるために使用されます。
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、異なる画像を持つズームフレームを作成する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2番目のスライドの背景を作成
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 3番目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "2番目のスライド";

    // ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // ズームフレームオブジェクトを追加
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **ズームフレームのフォーマット**
前のセクションでは、シンプルなズームフレームを作成する方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。ズームフレームに適用できるフォーマットオプションはいくつかあります。

スライド上のズームフレームのフォーマットを次のように制御できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	ズームフレームをリンクしたい新しいスライドを作成します。
3.	作成したスライドに識別テキストと背景をいくつか追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。これがフレームを埋めるために使用されます。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2番目のズームフレームオブジェクトのラインフォーマットを変更します。
8.	2番目のズームフレームオブジェクトの画像から背景を削除します。
5.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、スライド上のズームフレームのフォーマットを変更する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 2番目のスライドの背景を作成
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 2番目のスライド用のテキストボックスを作成
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "2番目のスライド";

    // 3番目のスライドの背景を作成
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 3番目のスライド用のテキストボックスを作成
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "第3のスライド";

    //ズームフレームオブジェクトを追加
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1オブジェクトのカスタム画像を設定
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2オブジェクトのフォーマットを設定
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

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用すると、本当に強調したいセクションに戻ることができます。また、プレゼンテーションの特定の部分がどのように関連しているかを強調表示するために使用することもできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについて、Aspose.Slidesは[ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe)インターフェイスと[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)インターフェイスのいくつかのメソッドを提供しています。

### **セクションズームフレームの作成**

次の手順でスライドにセクションズームフレームを追加できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、スライドにズームフレームを作成する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **カスタム画像を使用したセクションズームフレームの作成**

Aspose.Slides for .NETを使用すると、異なるスライドプレビュー画像を持つセクションズームフレームを次のように作成できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。
5.	[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。これがフレームを埋めるために使用されます。
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、異なる画像を持つズームフレームを作成する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    // ズームオブジェクト用の新しい画像を作成
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **セクションズームフレームのフォーマット**

より複雑なセクションズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。セクションズームフレームに適用できるフォーマットオプションはいくつかあります。

スライド上のセクションズームフレームのフォーマットを次のように制御できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別背景を追加します。
4.	ズームフレームにリンクする新しいセクションを作成します。
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加します。これがフレームを埋めるために使用されます。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る*機能を設定します。
10.	セクションズームフレームオブジェクトの画像から背景を削除します。
11.	2番目のズームフレームオブジェクトのラインフォーマットを変更します。
12.	トランジションの持続時間を変更します。
13.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、セクションズームフレームのフォーマットを変更する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    // セクションズームフレームオブジェクトを追加
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // セクションズームフレームのフォーマット
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

## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべての要素が一度に表示されるランディングページのようなものです。プレゼンテーションを行っているときに、ズームを使用してプレゼンテーション内の任意の場所に好きな順番で移動することができます。創造的になることができ、前に進んだり、スライドショーの部分を訪れたりして、プレゼンテーションの流れを中断することなく行えます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトについて、Aspose.Slidesは[ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)、および[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)インターフェイスと[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)インターフェイスのいくつかのメソッドを提供しています。

### **サマリーズームの作成**

次の手順でスライドにサマリーズームフレームを追加できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	識別背景を持つ新しいスライドを作成し、作成したスライド用に新しいセクションを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、スライドにサマリーズームフレームを作成する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 2", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 3", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 4", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)オブジェクトとして表されており、これらは[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)オブジェクトに保存されています。サマリーズームセクションオブジェクトを[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)インターフェイスを介してこのようにして追加または削除できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	識別背景を持つ新しいスライドを作成し、作成したスライド用に新しいセクションを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	新しいスライドとセクションをプレゼンテーションに追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、サマリーズームフレーム内でセクションを追加および削除する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 2", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    ISection section3 = pres.Sections.AddSection("セクション 3", slide);

    // サマリーズームにセクションを追加
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // サマリーズームからセクションを削除
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // プレゼンテーションを保存
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **サマリーズームセクションのフォーマット**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームのフォーマットを変更する必要があります。サマリーズームセクションオブジェクトに適用できるフォーマットオプションはいくつかあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトのフォーマットを次のように制御できます：

1.	[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2.	識別背景を持つ新しいスライドを作成し、作成したスライド用に新しいセクションを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection`から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
5.	[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトに関連付けられた画像コレクションに画像を追加します。これがフレームを埋めるために使用されます。
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7.	*リンクされたセクションから元のスライドに戻る*機能を設定します。
8.	2番目のズームフレームオブジェクトのラインフォーマットを変更します。
9.	トランジションの持続時間を変更します。
10.	修正したプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、サマリーズームセクションオブジェクトのフォーマットを変更する方法を示しています：

``` csharp 
using (Presentation pres = new Presentation())
{
    //プレゼンテーションに新しいスライドを追加
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 1", slide);

    //プレゼンテーションに新しいスライドを追加
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // プレゼンテーションに新しいセクションを追加
    pres.Sections.AddSection("セクション 2", slide);

    // サマリーズームフレームオブジェクトを追加
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 最初のサマリーズームセクションオブジェクトを取得
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // サマリーズームセクションオブジェクトのフォーマットを設定
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