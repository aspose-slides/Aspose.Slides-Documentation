---
title: 在 .NET 中管理簡報中的項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 70
url: /zh-hant/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - 項目符號
  - 項目符號清單
  - 編號清單
  - 符號項目符號
  - 圖片項目符號
  - 自訂項目符號
  - 多層次清單
  - 建立項目符號
  - 新增項目符號
  - 新增清單
  - PowerPoint
  - OpenDocument
  - 簡報
  - .NET
  - C#
  - Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號、圖片、多層次與編號清單。"
---
## **概觀**

Aspose.Slides for .NET 讓您能在 PowerPoint 和 OpenDocument 簡報中建立與格式化項目符號和編號清單。清單項目是段落，其項目符號設定由段落格式控制。

使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/paragraphformat/) 屬性存取段落層級的清單設定。主要入口是 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/)，它會傳回一個 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/) 物件。透過此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式以及起始編號。

This article shows how to:

- 建立具有自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層次清單
- 建立編號清單
- 檢查並變更現有簡報中的清單格式

## **建立項目符號清單**

若要建立項目符號清單，將 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 物件新增至 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 並將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。之後，您可以設定 [IBulletFormat.Char](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/char/)、[IBulletFormat.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/color/)、[IBulletFormat.Height](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/height/) 以控制項目符號的外觀。

The following C# code demonstrates how to create a bulleted list in a slide:

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

結果：

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

當項目的順序重要時，請使用編號清單。將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。您亦可使用 [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstyle/) 來選擇編號格式，或在清單需從非 1 的值開始時設定 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith/)。

The following C# code shows how to create a numbered list in a slide:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

結果：

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您以圖片取代一般的項目符號。圖片項目符號最適合使用在小尺寸仍能保持可讀性的簡單圖像，例如圖示或小型透明 PNG 檔案。

{{% alert color="primary" %}}
理想情況下，如果您打算以圖像取代一般項目符號，最好選擇具有透明背景的簡單圖形。此類圖像非常適合作為自訂項目符號。

請記住，圖像會被縮小至極小的尺寸。因此，我們強烈建議選擇在作為清單項目符號時仍保持清晰且視覺有效的圖像。
{{% /alert %}}

要建立圖片項目符號，先將圖像新增至 [Presentation.Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/images/)，再將回傳的圖像物件指派給 [IBulletFormat.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/picture/)。在指派圖像之前，請將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。

假設我們有一個 "image.png"：

![項目符號圖片](picture_for_bullets.png)

The following C# code shows how to create picture bullets in a slide:

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

結果：

![圖片項目符號](picture_bullets.png)

## **建立多層次清單**

使用 [IParagraphFormat.Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/depth/) 可將清單項目放在不同層級。層級 0 為最上層，層級 1 為其下的子層，以此類推。

The following C# code shows how to create a multilevel bulleted list:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

結果：

![多層次清單](multilevel_list.png)

## **變更現有清單**

若要變更現有簡報中的清單格式，存取目標段落並更新其 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/) 設定。建立清單時使用的相同屬性亦可用於檢查或修改從 PPT、PPTX 或 ODP 檔案載入的清單。

The following C# code changes the first paragraph in a text frame to use a numbered list style:

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **常見問題**

**是否可以將項目符號和編號清單匯出為 PDF 或圖像？**

可以。當目標格式支援相應的文字排版與項目符號功能時，Aspose.Slides 會保留清單的格式。

**我可以編輯現有簡報中的清單嗎？**

可以。載入簡報後，存取目標段落，檢查或更新其 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/) 設定，然後儲存簡報。

**清單可以包含非拉丁文字嗎？**

可以。清單項目的文字可以包含 Unicode 字元，因而能在多語言簡報中建立清單。請確保簡報中使用的字型支援您所需的字元。