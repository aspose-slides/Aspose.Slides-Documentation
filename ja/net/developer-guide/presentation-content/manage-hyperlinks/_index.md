---
title: .NET でプレゼンテーションハイパーリンクを管理する
linktitle: ハイパーリンクを管理する
type: docs
weight: 20
url: /ja/net/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを簡単に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---
## **はじめに**

ハイパーリンクは、オブジェクトやデータ、または何かの場所への参照です。これらは PowerPoint プレゼンテーションで一般的に使用されるハイパーリンクです：

* テキスト、図形、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for .NET を使用すると、プレゼンテーション内のハイパーリンクに関連するさまざまなタスクを実行できます。

{{% alert color="info" %}} 
Aspose のシンプルな[無料オンライン PowerPoint エディター](https://products.aspose.app/slides/ja/editor)をご覧になることをお勧めします。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

### **テキストへの URL ハイパーリンクの追加**

この C# コードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **図形またはフレームへの URL ハイパーリンクの追加**

この C# のサンプルコードは、図形にウェブサイトのハイパーリンクを追加する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **メディアへの URL ハイパーリンクの追加**

Aspose.Slides を使用すると、画像、音声、動画ファイルにハイパーリンクを追加できます。

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // プレゼンテーションに画像を追加します
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // スライド 1 に、前に追加した画像を基にピクチャーフレームを作成します
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
以下をご覧になるとよいでしょう *[OLE の管理](https://docs.aspose.com/slides/ja/net/manage-ole/)*。
{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや場所への参照を追加できるため、目次の作成に利用できます。

このサンプルコードは、ハイパーリンクを使用した目次の作成方法を示しています：
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **色**

IHyperlink インターフェイスの [ColorSource](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/colorsource) プロパティを使用すると、ハイパーリンクの色を設定したり、ハイパーリンクから色情報を取得したりできます。この機能は PowerPoint 2019 で初めて導入されたため、プロパティに関する変更は旧バージョンの PowerPoint には適用されません。

このサンプルコードは、同じスライドに異なる色のハイパーリンクが追加された操作を示しています：
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides は、ハイパーリンクにサウンドを付加して強調できる以下のプロパティを提供します：

- [IHyperlink.Sound](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/sound)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **ハイパーリンクにサウンドを追加**

この C# コードは、サウンドを再生するハイパーリンクを設定し、別のハイパーリンクで停止させる方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// プレゼンテーションのオーディオコレクションに新しいオーディオを追加します
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 次のスライドへのハイパーリンクを持つ新しい図形を追加します
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// ハイパーリンクが「無音」かどうかをチェックします
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 音声を再生するハイパーリンクを設定します
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 空のスライドを追加します
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoAction ハイパーリンクを持つ新しい図形を追加します
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// ハイパーリンクの「前の音を止める」フラグを設定します
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **ハイパーリンクのサウンドを抽出**

この C# コードは、ハイパーリンクで使用されているサウンドを抽出する方法を示しています：
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 最初の図形のハイパーリンクを取得します
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// ハイパーリンクのサウンドをバイト配列で抽出します
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **プレゼンテーションからハイパーリンクを削除**

### **テキストからハイパーリンクを削除**

この C# コードは、プレゼンテーションスライドのテキストからハイパーリンクを削除する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **図形またはフレームからハイパーリンクを削除**

この C# コードは、プレゼンテーションスライドの図形からハイパーリンクを削除する方法を示しています：
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

[Hyperlink](https://reference.aspose.com/slides/ja/net/aspose.slides/hyperlink) クラスは可変です。このクラスを使用すると、以下のプロパティの値を変更できます：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlink/properties/highlightclick)

このコードスニペットは、スライドにハイパーリンクを追加し、後でツールチップを編集する方法を示しています：
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **IHyperlinkQueries のサポートされているプロパティ**

プレゼンテーション、スライド、またはハイパーリンクが定義されているテキストから IHyperlinkQueries にアクセスできます。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries クラスは以下のメソッドとプロパティをサポートします：

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **よくある質問**

### スライドだけでなく「セクション」やセクションの最初のスライドへ内部ナビゲーションを作成するには？

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは技術的には特定のスライドを対象とします。「セクションへ移動」したい場合は、通常そのセクションの最初のスライドにリンクします。

### マスタースライドの要素にハイパーリンクを添付すれば、すべてのスライドで機能しますか？

はい。マスタースライドやレイアウトの要素はハイパーリンクをサポートしており、子スライドでも表示され、スライドショー中にクリック可能です。

### ハイパーリンクは PDF、HTML、画像、またはビデオへのエクスポート時に保存されますか？

[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/net/convert-powerpoint-to-html/) ではリンクは一般に保存されます。[画像](/slides/ja/net/convert-powerpoint-to-png/) と [ビデオ](/slides/ja/net/convert-powerpoint-to-video/) へのエクスポートでは、ラスタフレームやビデオはハイパーリンクをサポートしないため、クリック可能性は引き継がれません。