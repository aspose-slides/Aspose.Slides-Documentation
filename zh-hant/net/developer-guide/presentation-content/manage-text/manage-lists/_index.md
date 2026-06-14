---
title: 在 .NET 中管理簡報中的項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 70
url: /zh-hant/net/manage-lists/
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
## **概覽**

Aspose.Slides for .NET 讓您在 PowerPoint 與 OpenDocument 簡報中建立和格式化項目符號與編號清單。清單項目是一個段落，其項目符號設定由段落格式控制。

使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/paragraphformat/) 屬性以存取段落層級的清單設定。主要入口點是 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/)，它會回傳一個 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/) 物件。透過此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式，以及起始編號。

本文件說明如何：

- 建立具有自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層次清單
- 建立編號清單
- 檢視並變更現有簡報中的清單格式

## **建立項目符號清單**

若要建立項目符號清單，將 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 物件加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)，並將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。之後您可以設定 [IBulletFormat.Char](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/char/)、[IBulletFormat.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/color/) 與 [IBulletFormat.Height](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/height/) 以控制項目符號外觀。

以下 C# 程式碼示範如何在投影片中建立項目符號清單：

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

當項目的順序很重要時，請使用編號清單。將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。您也可以使用 [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstyle/) 選擇編號格式，或在清單應從 1 以外的數值開始時設定 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith/)。

以下 C# 程式碼示範如何在投影片中建立編號清單：

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

Aspose.Slides 允許您以圖片取代一般的項目符號。圖片項目符號最適合使用簡單且在小尺寸仍保持可讀性的圖像，例如圖示或小型透明 PNG 檔。

{{% alert color="primary" %}}
理想情況下，如果您打算以圖片取代一般項目符號，最好選擇具有透明背景的簡易圖形。此類圖像很適合作為自訂項目符號。
請記住，圖片會被縮小到非常小的尺寸。因此，我們強烈建議選擇在作為清單項目符號使用時仍然清晰且視覺上有效的圖像。
{{% /alert %}}

若要建立圖片項目符號，請將圖像加入 [Presentation.Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/images/)，並將回傳的圖像物件指派給 [IBulletFormat.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/picture/)。在指派圖像之前，先將 [IBulletFormat.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/bullettype/)。

假設我們有一個 "image.png"：

![用於項目符號的圖片](picture_for_bullets.png)

以下 C# 程式碼示範如何在投影片中建立圖片項目符號：

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

使用 [IParagraphFormat.Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/depth/) 可將清單項目放置於不同層級。層級 0 為最高層，層級 1 位於其下，以此類推。

以下 C# 程式碼示範如何建立多層次項目符號清單：

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

若要變更現有簡報中的清單格式，存取目標段落並更新其 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/) 設定。建立清單時使用的相同屬性，也可用於檢視或修改從 PPT、PPTX 或 ODP 檔載入的清單。

以下 C# 程式碼將文字框中的第一個段落變更為使用編號清單樣式：

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

**項目符號與編號清單可以匯出為 PDF 或圖片嗎？**

可以。當目標格式支援相應的文字版面配置與項目符號功能時，Aspose.Slides 會保留清單格式。

**我可以編輯現有簡報中的清單嗎？**

可以。載入簡報，存取目標段落，檢視或更新其 [IParagraphFormat.Bullet](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/bullet/) 設定，然後儲存簡報。

**清單可以包含非拉丁文字嗎？**

可以。清單項目的文字可以包含 Unicode 字元，您可以在多語言簡報中建立清單。請確保簡報中使用的字型支援所需的字元。