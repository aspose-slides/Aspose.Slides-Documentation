---
title: 管理 .NET 中的 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/net/manage-paragraph/
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
- 項目清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉圖片
- 文字轉圖片
- 匯出段落
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 精通段落格式設定——在 C# 中優化 PPT、PPTX 與 ODP 簡報的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供了您在 C# 中處理 PowerPoint 文字、段落和文字區段所需的所有介面和類別。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 介面，讓您能夠加入表示段落的物件。`ITextFame` 物件可以具有一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 介面，讓您能夠加入表示文字區段的物件。`IParagraph` 物件可以具有一個或多個區段（iPortions 物件的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/) 介面，讓您能夠加入表示文字及其格式屬性的物件。

`IParagraph` 物件能夠透過其底層的 `IPortion` 物件處理具有不同格式屬性的文字。

## **新增多個段落且每個段落包含多個區段**

以下步驟示範如何新增一個包含 3 個段落，且每個段落包含 3 個區段的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得相關投影片的參考。  
3. 在投影片上加入一個矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。  
4. 取得與 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 相關聯的 ITextFrame。  
5. 建立兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 物件，並將它們加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 的 `IParagraphs` 集合中。  
6. 為每個新的 `IParagraph` 建立三個 [IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/) 物件（預設段落僅兩個 Portion 物件），並將每個 `IPortion` 物件加入各自 `IParagraph` 的 IPortion 集合中。  
7. 為每個區段設定文字。  
8. 使用 `IPortion` 物件所提供的格式屬性，為每個區段套用您偏好的格式設定。  
9. 儲存已修改的簡報。  

以下 C# 程式碼示範了加入包含區段的段落的實作步驟：

```c#
 // 實例化代表 PPTX 檔案的 Presentation 類別
 using (Presentation pres = new Presentation())
 {
     // 存取第一張投影片
     ISlide slide = pres.Slides[0];

     // 新增一個矩形 IAutoShape
     IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

     // 存取 AutoShape 的 TextFrame
     ITextFrame tf = ashp.TextFrame;

     // 建立具有不同文字格式的段落與區段
     IParagraph para0 = tf.Paragraphs[0];
     IPortion port01 = new Portion();
     IPortion port02 = new Portion();
     para0.Portions.Add(port01);
     para0.Portions.Add(port02);

     IParagraph para1 = new Paragraph();
     tf.Paragraphs.Add(para1);
     IPortion port10 = new Portion();
     IPortion port11 = new Portion();
     IPortion port12 = new Portion();
     para1.Portions.Add(port10);
     para1.Portions.Add(port11);
     para1.Portions.Add(port12);

     IParagraph para2 = new Paragraph();
     tf.Paragraphs.Add(para2);
     IPortion port20 = new Portion();
     IPortion port21 = new Portion();
     IPortion port22 = new Portion();
     para2.Portions.Add(port20);
     para2.Portions.Add(port21);
     para2.Portions.Add(port22);

     for (int i = 0; i < 3; i++)
         for (int j = 0; j < 3; j++)
         {
             tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
             if (j == 0)
             {
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
             }
             else if (j == 1)
             {
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
             }
         }
     // 儲存已修改的簡報
     pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
 }
```

## **管理段落項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。使用項目符號的段落更易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得相關投影片的參考。  
3. 在選取的投影片上加入一個 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。  
4. 取得 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。  
5. 移除 `TextFrame` 中的預設段落。  
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。  
8. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。  
9. 設定段落的 `Text`。  
10. 設定段落的項目符號 `Indent`。  
11. 為項目符號設定顏色。  
12. 設定項目符號的高度。  
13. 將新段落加入 `TextFrame` 的段落集合中。  
14. 加入第二個段落，並重複第 7 至 13 步的流程。  
15. 儲存簡報。  

以下 C# 程式碼示範如何新增段落項目符號：

```c#
 // Instantiates a Presentation class that represents a PPTX file
 using (Presentation pres = new Presentation())
 {
 
     // Accesses the first slide
     ISlide slide = pres.Slides[0];
 
 
     // Adds and accesses Autoshape
     IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
 
     // Accesses the autoshape text frame
     ITextFrame txtFrm = aShp.TextFrame;
 
     // Removes the default paragraph
     txtFrm.Paragraphs.RemoveAt(0);
 
     // Creates a paragraph
     Paragraph para = new Paragraph();
 
     // Sets a paragraph bullet style and symbol
     para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 
     // Sets a paragraph text
     para.Text = "Welcome to Aspose.Slides";
 
     // Sets bullet indent
     para.ParagraphFormat.Indent = 25;
 
     // Sets bullet color
     para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
     para.ParagraphFormat.Bullet.Color.Color = Color.Black;
     para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 將 IsBulletHardColor 設為 true 以使用自訂的項目符號顏色
 
     // Sets Bullet Height
     para.ParagraphFormat.Bullet.Height = 100;
 
     // Adds Paragraph to text frame
     txtFrm.Paragraphs.Add(para);
 
     // Creates second paragraph
     Paragraph para2 = new Paragraph();
 
     // Sets paragraph bullet type and style
     para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
     para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
 
     // Adds paragraph text
     para2.Text = "This is numbered bullet";
 
     // Sets bullet indent
     para2.ParagraphFormat.Indent = 25;
 
     para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
     para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
     para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 將 IsBulletHardColor 設為 true 以使用自訂的項目符號顏色
 
     // Sets Bullet Height
     para2.ParagraphFormat.Bullet.Height = 100;
 
     // Adds Paragraph to text frame
     txtFrm.Paragraphs.Add(para2);
 
 
     // Saves the modified presentation
     pres.Save("Bullet_out.pptx", SaveFormat.Pptx);
 
 }
```

## **管理圖片項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。使用圖片項目符號的段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得相關投影片的參考。  
3. 在投影片上加入一個 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。  
4. 取得 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
5. 移除 `TextFrame` 中的預設段落。  
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。  
7. 在 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 中載入影像。  
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/)，並設定影像。  
9. 設定段落的 `Text`。  
10. 設定段落的項目符號 `Indent`。  
11. 為項目符號設定顏色。  
12. 設定項目符號的高度。  
13. 將新段落加入 `TextFrame` 的段落集合中。  
14. 加入第二個段落，並依先前步驟重複。  
15. 儲存已修改的簡報。  

以下 C# 程式碼示範如何新增和管理圖片項目符號：

```c#
 // 實例化代表 PPTX 檔案的 Presentation 類別
 Presentation presentation = new Presentation();

 // 存取第一張投影片
 ISlide slide = presentation.Slides[0];

 // 實例化用於項目符號的影像
 IImage image = Images.FromFile("bullets.png");
 IPPImage ippxImage = presentation.Images.AddImage(image);
 image.Dispose();

 // 新增並存取自動形狀
 IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

 // 存取自動形狀的文字框
 ITextFrame textFrame = autoShape.TextFrame;

 // 移除預設段落
 textFrame.Paragraphs.RemoveAt(0);

 // 建立新的段落
 Paragraph paragraph = new Paragraph();
 paragraph.Text = "Welcome to Aspose.Slides";

 // 設定段落項目符號樣式與影像
 paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
 paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

 // 設定項目符號高度
 paragraph.ParagraphFormat.Bullet.Height = 100;

 // 新增段落至文字框
 textFrame.Paragraphs.Add(paragraph);

 // 將簡報寫入為 PPTX 檔案
 presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

 // 將簡報寫入為 PPT 檔案
 presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **管理多層級項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得相關投影片的參考。  
3. 在新投影片中加入一個 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。  
4. 取得 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
5. 移除 `TextFrame` 中的預設段落。  
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設定為 0。  
7. 透過 `Paragraph` 類別建立第二個段落實例，並將深度設定為 1。  
8. 透過 `Paragraph` 類別建立第三個段落實例，並將深度設定為 2。  
9. 透過 `Paragraph` 類別建立第四個段落實例，並將深度設定為 3。  
10. 將新段落加入 `TextFrame` 的段落集合中。  
11. 儲存已修改的簡報。  

以下 C# 程式碼示範如何新增和管理多層級項目符號：

```c#
 // Instantiates a Presentation class that represents a PPTX file
 using (Presentation pres = new Presentation())
 {
 
     // Accesses the first slide
     ISlide slide = pres.Slides[0];
     
     // Adds and accesses Autoshape
     IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
 
     // Accesses the text frame of created autoshape
     ITextFrame text = aShp.AddTextFrame("");
     
     // Clears the default paragraph
     text.Paragraphs.Clear();
 
     // Adds the first paragraph
     IParagraph para1 = new Paragraph();
     para1.Text = "Content";
     para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
     para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Sets the bullet level
     para1.ParagraphFormat.Depth = 0;
 
     // Adds the second paragraph
     IParagraph para2 = new Paragraph();
     para2.Text = "Second Level";
     para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para2.ParagraphFormat.Bullet.Char = '-';
     para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Sets the bullet level
     para2.ParagraphFormat.Depth = 1;
 
     // Adds the third paragraph
     IParagraph para3 = new Paragraph();
     para3.Text = "Third Level";
     para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
     para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Sets the bullet level
     para3.ParagraphFormat.Depth = 2;
 
     // Adds the fourth paragraph
     IParagraph para4 = new Paragraph();
     para4.Text = "Fourth Level";
     para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para4.ParagraphFormat.Bullet.Char = '-';
     para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Sets the bullet level
     para4.ParagraphFormat.Depth = 3;
 
     // Adds paragraphs to collection
     text.Paragraphs.Add(para1);
     text.Paragraphs.Add(para2);
     text.Paragraphs.Add(para3);
     text.Paragraphs.Add(para4);
 
     // Writes the presentation as a PPTX file
     pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **管理具有自訂編號清單的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/) 介面提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith) 屬性等，可讓您管理具有自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 取得包含該段落的投影片。  
3. 在投影片上加入一個 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。  
4. 取得 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
5. 移除 `TextFrame` 中的預設段落。  
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith) 設為 2。  
7. 透過 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。  
8. 透過 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。  
9. 將新段落加入 `TextFrame` 的段落集合中。  
10. 儲存已修改的簡報。  

以下 C# 程式碼示範如何新增和管理具有自訂編號或格式的段落：

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 存取已建立的自動形狀的文字框
	ITextFrame textFrame = shape.TextFrame;

	// 移除預設的現有段落
	textFrame.Paragraphs.RemoveAt(0);

	// 第一個清單
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **設定段落第一行縮排**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 屬性來控制段落的第一行縮排。此屬性僅會移動第一行相對於段落左側邊界的距離。正值會將第一行向右移動，而其餘行則保持與段落本體對齊。

當需要移動整個段落時，請使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/)；當只需移動第一行時，請使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/)。

以下範例會建立多個段落，並套用不同的 `Indent` 值，以示範第一行縮排如何影響段落版面配置。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 取得目標投影片。  
3. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。  
4. 加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 到圖形並移除預設段落。  
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 值。  
6. 將段落加入文字框。  
7. 儲存已修改的簡報。  

以下程式碼示範如何設定段落縮排：

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

![段落的第一行縮排](first_line_indent.png)

## **設定懸掛縮排的段落**

懸掛縮排是一種段落版面配置，其第一行相較於其餘行向左縮進。在 Aspose.Slides 中，您可使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 屬性來產生此效果。將 `Indent` 設為負值，即可將第一行相對於段落本體向左移動。

實務上，[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/) 定義段落本體的左側位置，而 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 定義第一行相對於該邊界的位置。若要建立懸掛縮排，請將 `MarginLeft` 設為正值，`Indent` 設為負值。

此格式在參考文獻、引用、詞彙表條目等段落中非常有用，因為換行的文字需要對齊在段落本體下方，而不是首行的第一個字元下方。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 取得目標投影片。  
3. 在投影片上加入一個矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。  
4. 加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 到圖形並移除預設段落。  
5. 為每個段落設定正值的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/)。  
6. 設定負值的 [Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 以建立懸掛縮排效果。  
7. 將段落加入文字框。  
8. 儲存已修改的簡報。  

以下程式碼示範如何設定段落的懸掛縮排：

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

![段落的懸掛縮排](hanging_indent.png)

## **管理段落結尾執行屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
1. 透過其位置取得包含段落的投影片參考。  
1. 在投影片上加入一個矩形的 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。  
1. 在矩形中加入一個含有兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
1. 為段落設定 `FontHeight` 與字型類型。  
1. 設定段落的 End 屬性。  
1. 將已修改的簡報寫入為 PPTX 檔案。  

以下 C# 程式碼示範如何為 PowerPoint 中的段落設定 End 屬性：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的支援，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得相關投影片的參考。  
3. 在投影片上加入一個 [autoshape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。  
4. 加入並取得 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。  
5. 移除 `ITextFrame` 中的預設段落。  
6. 使用 TextReader 讀取來源 HTML 檔案。  
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。  
8. 將讀取的 TextReader 中的 HTML 檔案內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphcollection/)。  
9. 儲存已修改的簡報。  

以下 C# 程式碼示範上述匯入 HTML 文字至段落的步驟：

```c#
// 建立空白的簡報實例
using (Presentation pres = new Presentation())
{
    // 取得簡報的預設第一張投影片
    ISlide slide = pres.Slides[0];

    // 新增 AutoShape 以容納 HTML 內容
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 為圖形新增文字框
    ashape.AddTextFrame("");

    // 清除已新增文字框中的所有段落
    ashape.TextFrame.Paragraphs.Clear();

    // 使用 StreamReader 載入 HTML 檔案
    TextReader tr = new StreamReader("file.html");

    // 將 HTML StreamReader 的文字加入文字框
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // 儲存簡報
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的支援，可將文字（位於段落中）匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，並載入目標簡報。  
2. 透過索引取得相關投影片的參考。  
3. 取得包含將匯出為 HTML 之文字的圖形。  
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
5. 建立 `StreamWriter` 的實例，並新增 HTML 檔案。  
6. 為 StreamWriter 提供起始索引，並匯出您選擇的段落。  

以下 C# 程式碼示範如何將 PowerPoint 段落文字匯出為 HTML：

```c#
// 載入簡報檔案
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // 取得簡報的預設第一張投影片
    ISlide slide = pres.Slides[0];

    // 取得所需的索引
    int index = 0;

    // 取得已加入的圖形
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 將段落資料寫入 HTML，透過指定段落起始索引與要複製的段落數量
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **將段落另存為圖片**

在本節中，我們將探討兩個範例，示範如何將以 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 介面表示的文字段落另存為圖片。兩個範例皆包括使用 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面的 `GetImage` 方法取得包含該段落的圖形影像、計算段落在圖形中的邊界，並將其匯出為位圖圖像。這些方法讓您能從 PowerPoint 簡報中擷取特定文字部份，並另存為個別圖片，於各種情境中進一步使用。

假設我們有一個名為 sample.pptx 的簡報檔，只有一張投影片，第一個圖形是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**範例 1**

在此範例中，我們取得第二段落的影像。為此，我們先從簡報的第一張投影片中擷取圖形的影像，然後計算該圖形文字框中第二段落的邊界。接著，將段落重新繪製到新的位圖影像上，最後以 PNG 格式儲存。此方法特別適用於需要將特定段落另存為獨立圖片，同時保留文字的精確尺寸與格式的情況。

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// 將形狀以位圖形式儲存在記憶體中。
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// 從記憶體建立形狀位圖。
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 計算第二段落的邊界。
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// 計算輸出影像的大小（最小尺寸為 1x1 像素）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 為段落準備位圖。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// 將段落從形狀位圖重新繪製到段落位圖。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

![段落影像](paragraph_to_image_output.png)

**範例 2**

在此範例中，我們在前述方法基礎上加入比例因子，以調整段落影像的縮放。圖形從簡報中抽取，並以 `2` 的縮放比例儲存為影像。這樣在匯出段落時即可得到較高解析度的輸出。接著在考慮縮放比例的情況下計算段落的邊界。當需要更高細節的影像時（例如用於高品質印刷材料），縮放特別有用。

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **常見問題**

**我可以完全停用文字框內的自動換行嗎？**

可以。使用文字框的換行設定 ([WrapText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/wraptext/)) 將換行關閉，即可避免行在文字框邊緣斷行。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一區段）的邊界矩形，以得知其在投影片上的精確位置與大小。

**段落對齊（左、右、置中、兩端對齊）是在哪裡控制的？**

[Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphformat/alignment/) 是段落層級的設定，屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphformat/)；它會套用於整個段落，而不受個別區段格式的影響。

**我可以只為段落中的部分文字（例如單一詞彙）設定拼字檢查語言嗎？**

可以。語言設定在區段層級 ([PortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/))，因此在同一段落中可以同時存在多種語言。