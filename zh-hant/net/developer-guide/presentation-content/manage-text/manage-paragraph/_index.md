---
title: 管理 .NET 中的 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉圖像
- 文字轉圖像
- 匯出段落
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 建立與格式化段落、文字片段、項目符號、編號清單、縮排、HTML 內容與段落圖像。"
---
## **概述**

Aspose.Slides for .NET 以文字框、段落與文字片段的階層結構來表示文字：

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 表示形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 代表文字框中的單一段落，並提供對其文字片段與段落層級格式的存取。
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 代表段落內的文字執行。每個文字片段可以擁有自己的文字與字元層級格式。

因此，一個段落可以透過多個文字片段來容納具有不同字型、顏色、大小及其他格式的文字。

## **建立與格式化段落**

在形狀的文字框中建立段落，並使用文字片段來格式化個別的文字執行。本節說明如何在每個段落內結合多個文字片段，並套用不同的顏色、字型大小與樣式。

### **建立含多個文字片段的段落**

以下 C# 範例在其 [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) 集合中建立三個段落，每個段落包含三個文字執行。它先重複使用預設段落及其空白文字片段，接著加入其餘的段落與文字片段。格式透過 [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) 套用：每個段落的第一個文字片段為紅色、粗體、15 點；第二個為藍色、斜體、18 點；第三個保留預設格式：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **建立項目符號與編號清單**

將段落文字組織為符號、編號或自訂圖片的清單。本節的範例涵蓋項目符號格式、多階層清單，以及自訂起始編號。

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。在 Aspose.Slides 中，清單設定透過 [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 定義。

此 C# 範例在同一文字框中加入符號項目與編號項目。[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 選擇項目符號類型，[IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) 提供符號，而 [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) 選擇編號樣式。兩個項目均使用黑色項目符號、高度為 100%，段落縮排為 25 點：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **使用圖片項目符號**

圖片項目符號允許使用自訂圖片取代符號或編號。

此 C# 範例將一張圖片加入簡報的圖片集合，作為一個 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)，並將其用作段落的項目符號。它將 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 設為使用圖片項目符號，並透過 [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) 指定圖片。[IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) 設為 100% 以相對於段落文字調整項目符號大小：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **建立多階層清單**

將 [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 設為不同的深度，以在清單中放置不同層級的段落。最高層級的深度為 `0`。

此 C# 範例為四個段落分別指定 0 到 3 的 [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 值，於同一文字框內建立層級結構。每個段落使用符號項目符號，並利用 [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) 在圓形項目符號與連字號之間交替，以區分相鄰層級：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **以自訂值開始編號清單項目**

使用 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 來設定編號段落的起始數字。

此 C# 範例將 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 設為編號，並為三個段落分別設定 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 為 2、3、7。每個段落的起始值皆可獨立設定，使顯示的編號可以跳過特定數字：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **控制段落版面與結尾屬性**

調整段落的邊距與縮排，以控制第一行與換行行的位置。您亦可分別格式化段落結尾標記，與可見文字片段區分開來。

### **設定首行縮排**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 屬性來控制段落的首行縮排。此屬性僅移動第一行相對於段落左側邊距的距離。正值會將首行向右移動，其餘行則保持與段落本體對齊。

當需要移動整個段落時使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/)，而僅想移動首行時使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)。

以下範例將三個段落的 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 設為 20 點，且分別將 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 設為 0、20、40 點。首行的起始位置逐步遞增，而換行行則保留相同的左側邊距：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是指段落的第一行位於其餘行的左側。在 Aspose.Slides 中，可利用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 屬性實現。將 `Indent` 設為負值即可將第一行向左移動。

實務上，[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 定義段落本體的左側位置，而 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 定義第一行相對於該邊距的位置。要建立懸掛縮排，請將正的 `MarginLeft` 值與負的 `Indent` 值同時設定。

此格式常用於書目、參考文獻、詞彙表條目等需要讓換行行對齊於段落本體而非首行第一個字元的情況。

以下 C# 範例將 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 設為 40 與 60 點，並分別將 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 設為 -20 與 -30 點。每個段落的第一行都位於換行行左側；第二個段落的懸掛縮排更深：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) 屬性控制段落結尾標記的格式。以下範例建立一個 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)，將 [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 設為 48 點，並將 [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) 設為 Times New Roman。然後將此格式指派給第二段落的結尾標記，且不影響可見文字片段：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **計算已渲染的行數**

關於會影響自動換行與行尾標點的段落規則，請參閱 [Control Line Breaking](/slides/zh-hant/net/text-formatting/#control-line-breaking) 與 [Control Hanging Punctuation](/slides/zh-hant/net/text-formatting/#control-hanging-punctuation)。

使用 [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) 可取得段落在文字佈局後所佔的行數，包含自動換行。此功能在檢查投影片範本的文字長度與版面時相當有用。

段落是 [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) 中的一個項目，可能佔用多行已渲染的行。段落內的明確換行會強制換到新行，但不會產生新段落。自動換行則依可用寬度產生行，而不會在文字中插入明確的換行字元。因此，僅計算段落或換行字元無法得到已渲染的行數。

以下範例建立一個文字形狀，計算其行數，然後縮小形狀寬度，再以較短的字串取代文字。範例同時啟用 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) 並停用 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/)，使形狀寬度控制換行，而不會自動縮小文字或調整形狀大小。每一次測量皆使用 [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/)。形狀尺寸以點為單位。最後，範例再加入一個段落，並將整個文字框的行數加總：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

在此文字與尺寸下，縮小形狀會增加行數，而以短字串取代文字則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動適應設定而有所不同；請使用目標環境的字型與版面設定進行檢測。

僅依行數無法判斷文字是否溢出容器。可用高度、行高、段落與行間距、以及自動適應行為亦需考量；即使只有單行，在關閉換行時也可能超過可用寬度。

## **匯入與匯出段落內容**

使用 HTML 可將文字匯入簡報，或將現有段落匯出供外部使用。本節同時說明如何將單一段落渲染為圖像，包含表格儲存格內的段落。

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) 可將 HTML 標記轉換為文字框中的段落與文字片段。

此 C# 範例從檔案讀取 HTML，並將標記傳遞給 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/)。它會清除文字框的預設段落，使框架僅保留匯入的內容。矩形形狀在投影片四周保留 10 點的邊距：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **將段落文字匯出為 HTML**

使用 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) 可將選取的段落範圍匯出為 HTML。當在網站上重新使用簡報文字時，您可能希望保留本地的強調效果，而不帶入簡報的字型、大小或文字方塊樣式。將 [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) 設為適當的值，即可控制匯出器沿用格式繼承的深度。

下載 [範例簡報](text-inheritance.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個文字形狀，文字為「Inherited text; explicit red 18pt」。輸入刻意使用了多層格式：

- 簡報的預設文字樣式提供 Calibri 字型，大小為 28 pt。
- 文字框的一級文字樣式提供藍色文字與斜體。
- 段落明確設定為粗體。
- 第二個文字片段「explicit red 18pt」明確設定為紅色文字，大小為 18 pt。

以下完整範例將相同段落匯出三次。它將 [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) 傳遞給匯出方法，並將每個結果寫入獨立的 UTF-8 HTML 檔案：

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

產生的 HTML 針對第一個文字片段「Inherited text; 」包含以下 CSS。表格列出相關宣告；其他產生的屬性為簡化說明而省略。

| 輸出 | 首段文字的相關 CSS | 外觀 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體，28 pt Calibri（若該字型可用） |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體；字型與大小由頁面或瀏覽器決定 |
| `ParagraphOnly.html` | `font-weight:bold` | 粗體；字型、大小、顏色與斜體由頁面或瀏覽器決定 |

第二個文字片段在所有三個輸出中皆保留 `color:#ff0000`、`font-size:18pt` 與 `font-weight:bold`。在 `All` 與 `TextBox` 中亦保留斜體，但在 `ParagraphOnly` 中則沒有。限制繼承因此不會移除明確指派給段落或文字片段的格式。

在同一瀏覽器中開啟這些檔案以進行比較。於受限模式中省略的 CSS 屬性會由目標頁面的樣式或瀏覽器預設補足，故最終外觀取決於 HTML 的使用環境。

### **將段落渲染為圖像**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 可直接渲染單一段落，並回傳一個 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)。使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 可將結果儲存為檔案或串流，無需先渲染包含的形狀或手動裁切位圖。

若段落在其父集合中找不到、沒有有效的渲染範圍，或無法渲染，[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 會回傳 `null`。請在儲存前檢查回傳結果，並於使用完畢後釋放圖像。

#### **以預設比例渲染段落**

此範例使用一個投影片，第一個形狀為包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下程式碼選取索引為 1 的第二段落，呼叫未帶比例參數的 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)。它會先確認形狀包含所需段落，且渲染返回圖像後，才呼叫 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 以 PNG 格式儲存。`using` 陳述式會在使用完畢後釋放圖像：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

結果：

![段落圖像](paragraph_to_image_output.png)

#### **在表格儲存格內以縮放渲染段落**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 版本，可設定水平與垂直的縮放比例。以下範例建立一個表格，於其第一個儲存格內以兩倍的預設寬度與高度渲染段落，並將結果儲存為 PNG 圖像。

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

縮放係數為 `1` 時，該軸保持預設像素大小。例如，同時將兩個係數設為 `2`，則圖像的寬度與高度約為預設的兩倍，像素數量為四倍。較大的係數通常會在放大或高解析度輸出時產生更銳利的文字，但也會增加記憶體使用量與檔案大小。係數低於 `1` 則會產生較小且細節較少的圖像。使用相同的係數可保持段落的長寬比；不同的水平與垂直係數則會分別拉伸輸出。

在需要同時保留形狀填色、邊框或其他視覺上下文的情況下，仍可使用 [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/)。若僅需段落圖像，請使用 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)。

## **常見問題** 

**我可以完全停用文字框內的換行嗎？**

可以。將 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) 設為停用，即可關閉換行，使行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) 取得段落的邊界矩形。[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) 則提供單一文字片段的邊界。

**段落對齊（左、右、置中或兩端對齊）在何處控制？**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 為段落層級設定，會套用於整個段落，與個別文字片段的格式無關。

若要在每行內垂直對齊不同字型大小的文字片段，請參閱 [Align Fonts Within a Line](/slides/zh-hant/net/text-formatting/#align-fonts-within-a-line)。

**我可以為段落的一部分設定校對語言嗎？**

可以。將 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) 設定於個別文字片段，即可在同一段落中包含多種語言的文字。