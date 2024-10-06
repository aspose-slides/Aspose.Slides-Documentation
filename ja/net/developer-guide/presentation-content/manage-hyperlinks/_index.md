---
title: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/net/manage-hyperlinks/
keywords: "ハイパーリンクの追加, PowerPointプレゼンテーション, PowerPointハイパーリンク, テキストハイパーリンク, スライドハイパーリンク, 形状ハイパーリンク, 画像ハイパーリンク, 動画ハイパーリンク, .NET, C#, Csharp"
description: "C#または.NETでPowerPointプレゼンテーションにハイパーリンクを追加する"
---

ハイパーリンクは、オブジェクト、データ、または何かの中の場所への参照です。PowerPointプレゼンテーションで一般的なハイパーリンクは次のとおりです。

* テキスト、形状、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for .NETを使用すると、プレゼンテーション内のハイパーリンクに関する多くの作業を実行できます。

{{% alert color="primary" %}} 

Asposeのシンプルな、[無料のオンラインPowerPointエディタ](https://products.aspose.app/slides/editor)をチェックしてみるとよいでしょう。

{{% /alert %}} 

## **URLハイパーリンクの追加**

### **テキストへのURLハイパーリンクの追加**

このC#コードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています。

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: ファイル形式API");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **形状またはフレームへのURLハイパーリンクの追加**

このC#のサンプルコードは、形状にウェブサイトのハイパーリンクを追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **メディアへのURLハイパーリンクの追加**

Aspose.Slidesを使用すると、画像、音声、および動画ファイルにハイパーリンクを追加することができます。

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    // プレゼンテーションに画像を追加
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 以前に追加した画像に基づいてスライド1に画像フレームを作成
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

このサンプルコードは、**動画**にハイパーリンクを追加する方法を示しています。

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="ヒント"  color="primary"  %}} 

*[OLEの管理](https://docs.aspose.com/slides/net/manage-ole/)*を参照することをお勧めします。

{{% /alert %}} 

## **ハイパーリンクを使用して目次を作成する**

ハイパーリンクを使用すると、オブジェクトや場所への参照を追加できるため、目次を作成するために利用することができます。

このサンプルコードは、ハイパーリンクを使用して目次を作成する方法を示しています。

```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "スライド2のタイトル .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "ページ2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **ハイパーリンクのフォーマット**

### **色**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)インターフェースの[ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource)プロパティを使って、ハイパーリンクの色を設定したり、ハイパーリンクから色の情報を取得したりすることができます。この機能はPowerPoint 2019で初めて導入されたため、プロパティに関する変更は古いPowerPointバージョンには適用されません。

このサンプルコードは、異なる色のハイパーリンクが同じスライドに追加された操作を示しています。

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("これは色付きのハイパーリンクのサンプルです。");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("これは通常のハイパーリンクのサンプルです。");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **音**

Aspose.Slidesは、ハイパーリンクを音で強調表示できるようにするためのこれらのプロパティを提供します：
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **ハイパーリンクサウンドの追加**

このC#コードは、音を再生するハイパーリンクを設定し、別のハイパーリンクでそれを停止する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
	// プレゼンテーションの音声コレクションに新しい音声を追加
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 次のスライドへのハイパーリンクを持つ新しい形状を追加
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// "音なし"に対してハイパーリンクをチェック
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 音を再生するハイパーリンクを設定
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 空のスライドを追加 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoActionハイパーリンクを持つ新しい形状を追加
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// "前の音を停止"フラグを設定
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **ハイパーリンク音の抽出**

このC#コードは、ハイパーリンクで使用されている音を抽出する方法を示しています。

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 最初の形状のハイパーリンクを取得
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// ハイパーリンク音をバイト配列として抽出
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **プレゼンテーションからのハイパーリンクの削除**

### **テキストからのハイパーリンクの削除**

このC#コードは、プレゼンテーションスライドのテキストからハイパーリンクを削除する方法を示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **形状またはフレームからのハイパーリンクの削除**

このC#コードは、プレゼンテーションスライドの形状からハイパーリンクを削除する方法を示しています。 

``` csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **ミュータブルハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink)クラスはミュータブルです。このクラスを使用すると、次のプロパティの値を変更できます。

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

このコードスニペットは、スライドにハイパーリンクを追加し、後でそのツールチップを編集する方法を示しています。

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: ファイル形式API");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "70％以上のフォーチュン100企業がAspose APIを信頼しています";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **IHyperlinkQueriesでサポートされているプロパティ**

プレゼンテーション、スライド、またはハイパーリンクが定義されているテキストからIHyperlinkQueriesにアクセスできます。 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueriesクラスは、次のメソッドとプロパティをサポートしています。

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)