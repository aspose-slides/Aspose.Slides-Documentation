---
title: Android でのプレゼンテーション ハイパーリンクの管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/androidjava/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- 図形 ハイパーリンク
- 画像 ハイパーリンク
- ビデオ ハイパーリンク
- 変更可能なハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを簡単に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---
## **概要**

ハイパーリンクは、オブジェクト、データ、または場所への参照です。PowerPoint プレゼンテーションでよく使用されるハイパーリンクは次のとおりです：

* テキスト、図形、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Android via Java を使用すると、プレゼンテーション内のハイパーリンクに関するさまざまな操作を実行できます。

{{% alert color="info" %}} 
Aspose のシンプルな、[無料オンライン PowerPoint エディタ](https://products.aspose.app/slides/ja/editor) をご確認ください。
{{% /alert %}} 

## **URL ハイパーリンクの追加**

### **テキストへの URL ハイパーリンクの追加**

この Java コードは、テキストにウェブサイトへのハイパーリンクを追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **図形またはフレームへの URL ハイパーリンクの追加**

この Java のサンプルコードは、図形にウェブサイトへのハイパーリンクを追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **メディアへの URL ハイパーリンクの追加**

Aspose.Slides を使用すると、画像、音声、ビデオ ファイルにハイパーリンクを追加できます。 

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// プレゼンテーションに画像を追加します
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// 先に追加した画像を基にスライド 1 に画像フレームを作成します
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

このサンプルコードは、**ビデオ**にハイパーリンクを追加する方法を示しています。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="info"  %}} 
※ *[OLE の管理](/slides/ja/androidjava/manage-ole/)* をご覧になるとよいでしょう。
{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや場所への参照を追加できるため、目次の作成に利用できます。 

このサンプルコードは、ハイパーリンク付きの目次を作成する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ハイパーリンクの書式設定**

### **色**

[ColorSource] プロパティを使用すると、[IHyperlink] インターフェイスでハイパーリンクの色を設定したり取得したりできます。この機能は PowerPoint 2019 で初めて導入されたため、古いバージョンの PowerPoint ではこのプロパティの変更は適用されません。

このサンプルコードは、同じスライドに異なる色のハイパーリンクを追加する操作を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **プレゼンテーションからハイパーリンクを削除する**

### **テキストからハイパーリンクを削除する**

この Java コードは、プレゼンテーション スライドのテキストからハイパーリンクを削除する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **図形またはフレームからハイパーリンクを削除する**

この Java コードは、プレゼンテーション スライドの図形からハイパーリンクを削除する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **変更可能なハイパーリンク**

[Hyperlink] クラスは変更可能です。このクラスを使用すると、次のプロパティの値を変更できます。

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

このコード スニペットは、スライドにハイパーリンクを追加し、後でツールチップを編集する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// 既に追加されているハイパーリンクのツールチップを変更します
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries でサポートされているプロパティ**

ハイパーリンクが定義されたプレゼンテーション、スライド、テキストから [IHyperlinkQueries] にアクセスできます。

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries] クラスは、以下のメソッドとプロパティをサポートしています。

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### スライドだけでなく「セクション」やセクションの最初のスライドへ内部ナビゲーションを作成するには？

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは技術的には特定のスライドを対象とします。「セクションへ移動」するには、通常はそのセクションの最初のスライドにリンクします。

### マスタースライドの要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？

はい。マスタースライドやレイアウトの要素にもハイパーリンクを設定できます。これらのリンクは子スライドに引き継がれ、スライドショー中にクリック可能です。

### PDF、HTML、画像、または動画にエクスポートした場合、ハイパーリンクは保持されますか？

[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) では、リンクは通常保持されます。[画像](/slides/ja/androidjava/convert-powerpoint-to-png/) や [動画](/slides/ja/androidjava/convert-powerpoint-to-video/) にエクスポートする場合は、ラスターフレームや動画はハイパーリンクをサポートしないため、クリック可能性は保持されません。