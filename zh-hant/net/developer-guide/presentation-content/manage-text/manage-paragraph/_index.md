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
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 建立與格式化段落、文字段、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概述**

Aspose.Slides for .NET 以文字框、段落和文字段的層級結構表示文字：

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 代表文字框中的單一段落，並提供對其文字段與段落層級格式設定的存取。
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 代表段落中的一段文字。每個文字段都可以擁有自己的文字和字元層級的格式設定。

因此，一個段落可以透過多個文字段來包含不同字型、顏色、大小和其他格式的文字。

## **建立與格式化段落**

### **建立包含多個文字段的段落**

以下步驟會建立一個包含三個段落、每個段落都有三個文字段的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在投影片上新增一個矩形 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 取得該圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
5. 使用預設段落，並向文字框中再新增兩個 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 物件。
6. 為每個段落加入足夠的 [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 物件，使其包含三個文字段。預設段落已包含一個空的文字段。
7. 設定每個文字段的文字內容。
8. 透過 [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) 套用字元層級的格式設定。
9. 儲存已修改的簡報。

以下 C# 範例實作上述步驟：

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

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。於 Aspose.Slides 中，清單設定是透過 [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在選取的投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 取得圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目符號建立一個 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)。
7. 將 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) 並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)。
11. 配置編號項目符號樣式，並將段落加入文字框。
12. 儲存簡報。

以下 C# 範例會建立符號項目符號和編號項目符號：

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

圖片項目符號允許您使用自訂圖片取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 並取得其 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號圖片，並以 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 的形式加入簡報的圖片集合。
6. 建立 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 並設定其文字。
7. 將 [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) 設為 [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)。
8. 透過 [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) 指定圖片，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

以下 C# 範例會建立圖片項目符號：

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

### **建立多層次清單**

將 [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 設為不同值，可將段落放置於清單的不同層級。最上層的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並取得一張投影片。
2. 新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 並從其文字框中清除預設段落。
3. 建立四個段落，並設定各自的項目符號符號。
4. 將它們的 [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 分別設定為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

以下 C# 範例會建立四層級的項目符號清單：

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

### **自訂編號清單的起始值**

使用 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 可設定編號段落的起始數字。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
2. 清除圖形文字框中的預設段落。
3. 建立三個編號段落。
4. 將 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 分別設為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

以下 C# 範例會為每個段落指派自訂的起始編號：

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

### **設定首行縮排**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 屬性可控制段落的首行縮排。此屬性僅會移動第一行相對於段落左邊界的距離；正值會將第一行向右移動，其他行則保持與段落正文對齊。

當需要整段移動時，請使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/)；當只想移動第一行時，請使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)。

以下範例建立多個段落，並套用不同的 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 值，以示範首行縮排對段落版面的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 取得圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 並移除預設段落。
5. 建立多個段落，為它們設定不同的 [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

以下程式碼示範如何設定段落縮排：

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

懸掛縮排是一種段落版面配置，第一行會位於其餘行的左側。在 Aspose.Slides 中，可使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 屬性達成此效果。將 `Indent` 設為負值，即可使第一行相對於段落本文向左移動。

實務上，[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 定義段落正文的左側位置，而 [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 定義第一行相對於該左邊界的位置。若要建立懸掛縮排，請將正的 `MarginLeft` 值與負的 `Indent` 值結合使用。

此格式常用於參考文獻、書目、詞彙表條目等需要讓換行後的文字對齊於段落正文而非首字的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 取得圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 並移除預設段落。
5. 為每個段落設定正的 [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 值。
6. 設定負的 [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 值，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

以下程式碼示範如何為段落設定懸掛縮排：

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

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) 屬性控制段落結尾標記的格式。以下範例為第二段的結尾標記指定字型大小與西文字型：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並取得投影片。
2. 新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 並清除其預設段落。
3. 建立兩個段落，並為它們加入文字段。
4. 為第二段的結尾標記建立 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)。
5. 設定 [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 與 [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/)。
6. 將格式指派給 [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/)，並儲存簡報。

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

欲了解會影響自動換行與行尾標點的段落規則，請參閱[控制換行](/slides/zh-hant/net/text-formatting/#control-line-breaking)與[控制懸掛標點](/slides/zh-hant/net/text-formatting/#control-hanging-punctuation)。

使用 [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) 可以取得段落在排版後佔用的行數（包括自動換行）。此功能在檢查簡報範本的文字長度與版面配置時相當有用。

段落是 [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) 中的一個項目，可能會跨越多條已渲染的行。段落內的手動換行會強制換行但不會產生新段落；自動換行則根據可用寬度產生新行，而不會在文字中插入換行字元。因此，僅計算段落數或換行字元並無法得出已渲染的行數。

以下範例會建立一個文字圖形，計算其行數，縮小圖形，然後以較短的字串取代文字。示例已啟用換行且關閉自動縮放，以使圖形寬度控制換行，而不會自動縮小文字或調整圖形大小。圖形尺寸以點為單位。最後，範例會再加入一個段落，並將文字框內所有段落的行數相加。

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

在此文字與尺寸下，縮小圖形會增加行數，而以較短字串取代則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動縮放設定而異。請使用目標環境的字型與版面設定來檢查範本。

僅憑行數無法判斷文字是否會超出容器；可用高度、行高、段落與行距以及自動縮放行為亦會影響，即使只有單行，若關閉換行，仍可能超出可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) 可將 HTML 標記轉換為文字框內的段落與文字段。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例。
2. 取得投影片並新增一個 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
3. 取得圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/)。
6. 儲存已修改的簡報。

以下 C# 範例會將 HTML 匯入文字框：

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

使用 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例並載入目標簡報。
2. 取得投影片，並找出包含文字的 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
3. 取得圖形的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
4. 呼叫 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) 並傳入起始段落索引與欲匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

以下 C# 範例會匯出第一個文字圖形中的所有段落：

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **將段落渲染為影像**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 直接渲染單一段落，並回傳一個 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)。使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 可將結果儲存為檔案或串流。您不必先渲染整個圖形或自行裁切位圖。

若段落無法在其父集合中找到、沒有有效的渲染範圍，或無法渲染，則 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 可能會傳回 `null`。請在儲存前檢查結果，並於使用完畢後釋放圖像。

#### **以預設比例渲染段落**

假設我們有一個名為 `sample.pptx` 的簡報檔案，內含一張投影片，第一個圖形是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例會在預設比例下，將第二段落在常規文字圖形中渲染，並以 PNG 格式儲存回傳的影像。`using` 陳述式確保影像能正確釋放。

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

![段落影像](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放渲染段落**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) 版本，可設定水平與垂直的縮放係數。以下範例會建立一個表格，並在第一個儲存格內以兩倍寬度與高度渲染段落，最後以 PNG 影像儲存結果。

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

縮放係數 `1` 表示該軸保持預設像素大小。例如，同時使用 `2` 會產生寬度與高度皆約為預設兩倍的影像，像素數量約為原本的四倍。較大的係數通常可在放大或高解析度輸出時提供更銳利的文字，但同時會增加記憶體使用與檔案大小。小於 `1` 的係數則會產生較小且細節較少的影像。若想保持段落的長寬比，請使用相同的水平與垂直係數；不同的係數會使輸出分別在水平與垂直方向上拉伸。

在需要同時呈現圖形填色、邊框或其他視覺上下文時，仍可使用 [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) 來渲染整個圖形。若僅需段落影像，請使用 [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)。

## **常見問題**

**我可以完全停用文字框內的自動換行嗎？**

可以。將 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) 設為停用，即可禁止換行，使行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) 可取得段落的邊界矩形。[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) 則提供單一文字段的邊界。

**段落對齊（左、右、置中或兩端對齊）在哪裡控制？**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 為段落層級設定，會套用於整個段落，與個別文字段的格式無關。

若要在同一行內讓不同字型大小的文字垂直對齊，請參閱[在行內對齊字型](/slides/zh-hant/net/text-formatting/#align-fonts-within-a-line)。

**我可以為段落的部分文字設定校對語言嗎？**

可以。將 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) 設定於個別文字段，即可讓同一段落內的文字使用多種語言。