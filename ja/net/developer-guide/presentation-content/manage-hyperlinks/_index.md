---
title: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/net/manage-hyperlinks/
keywords: "ハイパーリンクを追加, PowerPoint プレゼンテーション, PowerPoint ハイパーリンク, テキスト ハイパーリンク, スライド ハイパーリンク, シェイプ ハイパーリンク, 画像 ハイパーリンク, ビデオ ハイパーリンク, .NET, C#, Csharp"
description: "C# または .NET で PowerPoint プレゼンテーションにハイパーリンクを追加する"
---

ハイパーリンクは、オブジェクトやデータ、または何かの中の場所への参照です。これらはPowerPointプレゼンテーションで一般的に使用されるハイパーリンクです：

* テキスト、シェイプ、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for .NET を使用すると、プレゼンテーション内のハイパーリンクに関する多くのタスクを実行できます。

{{% alert color="primary" %}} 
Asposeシンプル版や、[無料のオンラインPowerPointエディタ。](https://products.aspose.app/slides/editor)をご確認ください。
{{% /alert %}} 

## **ハイパーリンクを使用した目次の作成**

### **テキストへのURLハイパーリンクの追加**

このC#コードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています。
```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


### **シェイプまたはフレームへのURLハイパーリンクの追加**

このC#サンプルコードは、シェイプにウェブサイトのハイパーリンクを追加する方法を示しています。
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **メディアへのURLハイパーリンクの追加**

Aspose.Slides を使用すると、画像、音声、動画ファイルにハイパーリンクを追加できます。 

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    // プレゼンテーションに画像を追加
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 以前に追加した画像を元にスライド1に画像フレームを作成
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspify APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


このサンプルコードは、**動画**にハイパーリンクを追加する方法を示しています：
``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


{{%  alert  title="Tip"  color="primary"  %}} 
*[OLEの管理](https://docs.aspose.com/slides/net/manage-ole/)*をご覧ください。
{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや場所への参照を追加できるため、目次の作成に利用できます。 

このサンプルコードは、ハイパーリンク付きの目次を作成する方法を示しています。
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
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```


## **ハイパーリンクの書式設定**

### **カラー**

IHyperlink インターフェイスの [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) プロパティを使用すると、ハイパーリンクの色を設定したり、ハイパーリンクから色情報を取得したりできます。この機能は PowerPoint 2019 で初めて導入されたため、プロパティに関する変更は古い PowerPoint バージョンには適用されません。

このサンプルコードは、異なる色のハイパーリンクを同じスライドに追加する操作を示しています：
```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **サウンド**

Aspose.Slides は、ハイパーリンクにサウンドを付加して強調できる以下のプロパティを提供します。

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **ハイパーリンクサウンドの追加**

このC#コードは、サウンドを再生するハイパーリンクを設定し、別のハイパーリンクで停止させる方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
	// プレゼンテーションのオーディオコレクションに新しいオーディオを追加
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 次のスライドへのハイパーリンクを持つ新しいシェイプを追加
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 「無音」かどうかハイパーリンクをチェック
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 音声を再生するハイパーリンクを設定
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 空のスライドを追加 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoAction ハイパーリンクを持つ新しいシェイプを追加
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// ハイパーリンクの「前の音を停止」フラグを設定
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **ハイパーリンクサウンドの抽出**

このC#コードは、ハイパーリンクで使用されているサウンドを抽出する方法を示しています：
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 最初のシェイプのハイパーリンクを取得
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// ハイパーリンクのサウンドをバイト配列として抽出
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **プレゼンテーションからハイパーリンクを削除する**

### **テキストからハイパーリンクを削除する**

このC#コードは、プレゼンテーションスライドのテキストからハイパーリンクを削除する方法を示しています：
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


### **シェイプまたはフレームからハイパーリンクを削除する**

このC#コードは、プレゼンテーションスライドのシェイプからハイパーリンクを削除する方法を示しています： 
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


## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) クラスは可変です。このクラスを使用すると、以下のプロパティの値を変更できます。

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

このコードスニペットは、スライドにハイパーリンクを追加し、後でツールチップを編集する方法を示しています：
```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **IHyperlinkQueries のサポートプロパティ**

ハイパーリンクが定義されているプレゼンテーション、スライド、またはテキストから IHyperlinkQueries にアクセスできます。 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries クラスは、以下のメソッドとプロパティをサポートしています。 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**スライドだけでなく、セクションやセクションの最初のスライドへの内部ナビゲーションはどう作成できますか？**

PowerPoint のセクションはスライドのグループであり、ナビゲーションは技術的には特定のスライドを対象とします。セクションへ「移動」するには、通常、そのセクションの最初のスライドへのリンクを作成します。

**マスタースライドの要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートします。そのようなリンクは子スライド上に表示され、スライドショー中にクリック可能です。

**PDF、HTML、画像、動画へエクスポートするときにハイパーリンクは保持されますか？**

[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/net/convert-powerpoint-to-html/) では、リンクは通常保持されます。[画像](/slides/ja/net/convert-powerpoint-to-png/) や [動画](/slides/ja/net/convert-powerpoint-to-video/) へエクスポートする場合、これらのフォーマットはラスターフレーム/ビデオでハイパーリンクをサポートしないため、クリック可能性は引き継がれません。