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
description: "使用 Aspose.Slides for .NET 精通段落格式設定——在 C# 中最佳化 PPT、PPTX 與 ODP 簡報的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供了在 C# 中處理 PowerPoint 文字、段落和部分所需的所有介面與類別。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 介面，使您能夠加入表示段落的物件。`ITextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 介面，使您能夠加入表示部分的物件。`IParagraph` 物件可以包含一個或多個部分（iPortions 物件的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/) 介面，使您能夠加入表示文字及其格式屬性的物件。

`IParagraph` 物件可透過其底層的 `IPortion` 物件來處理具有不同格式屬性的文字。

## **新增多個段落，包含多個部分**

以下步驟示範如何新增一個包含 3 個段落且每個段落含有 3 個部分的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片上新增一個矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
4. 取得與該 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 關聯的 ITextFrame。
5. 建立兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 物件，並將它們加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 的 `IParagraphs` 集合中。
6. 為每個新建的 `IParagraph` 建立三個 [IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/) 物件（預設段落僅建立兩個 Portion 物件），並將每個 `IPortion` 物件加入相應 `IParagraph` 的 IPortion 集合中。
7. 為每個部分設定文字。
8. 使用 `IPortion` 物件提供的格式屬性，對每個部分套用您偏好的格式設定。
9. 儲存已修改的簡報。

```c#
// 實例化一個代表 PPTX 檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = pres.Slides[0];

    // 新增一個矩形 IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // 取得 AutoShape 的 TextFrame
    ITextFrame tf = ashp.TextFrame;

    // 建立具有不同文字格式的段落和部分
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
2. 透過索引取得相關投影片的參照。
3. 在選取的投影片上新增一個 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
4. 取得自動形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。 
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
9. 設定段落的 `Text`。
10. 設定段落的項目符號 `Indent`。
11. 為項目符號設定顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合中。
14. 加入第二個段落，並重複第 7 步至第 13 步的流程。
15. 儲存簡報。

```c#
// 實例化一個代表 PPTX 檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide slide = pres.Slides[0];


    // 新增並取得自動形狀
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得自動形狀的文字框
    ITextFrame txtFrm = aShp.TextFrame;

    // 移除預設段落
    txtFrm.Paragraphs.RemoveAt(0);

    // 建立段落
    Paragraph para = new Paragraph();

    // 設定段落的項目符號樣式與符號
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 設定段落文字
    para.Text = "Welcome to Aspose.Slides";

    // 設定項目符號縮排
    para.ParagraphFormat.Indent = 25;

    // 設定項目符號顏色
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    // 設定項目符號高度
    para.ParagraphFormat.Bullet.Height = 100;

    // 將段落加入文字框
    txtFrm.Paragraphs.Add(para);

    // 建立第二段落
    Paragraph para2 = new Paragraph();

    // 設定段落項目符號類型與樣式
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 加入段落文字
    para2.Text = "This is numbered bullet";

    // 設定項目符號縮排
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    // 設定項目符號高度
    para2.ParagraphFormat.Bullet.Height = 100;

    // 將段落加入文字框
    txtFrm.Paragraphs.Add(para2);


    // 儲存已修改的簡報
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **管理圖片項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。圖片項目符號的段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片上新增一個 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
4. 取得自動形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 在 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 中載入圖片。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/)，並設定圖片。
9. 設定段落的 `Text`。
10. 設定段落的項目符號 `Indent`。
11. 為項目符號設定顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合中。
14. 加入第二個段落，並依照前述步驟重複。
15. 儲存已修改的簡報。

```c#
// 實例化一個代表 PPTX 檔案的 Presentation 類別
Presentation presentation = new Presentation();

// 取得第一張投影片
ISlide slide = presentation.Slides[0];

// 實例化用於項目符號的圖像
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// 新增並取得自動形狀
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// 取得自動形狀的文字框
ITextFrame textFrame = autoShape.TextFrame;

// 移除預設段落
textFrame.Paragraphs.RemoveAt(0);

// 建立新段落
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 設定段落的項目符號樣式與圖像
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 設定項目符號高度
paragraph.ParagraphFormat.Bullet.Height = 100;

// 將段落加入文字框
textFrame.Paragraphs.Add(paragraph);

// 將簡報儲存為 PPTX 檔案
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// 將簡報儲存為 PPT 檔案
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **管理多層級項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在新投影片中新增一個 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
4. 取得自動形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設為 0。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將深度設為 1。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將深度設為 2。
9. 使用 `Paragraph` 類別建立第四個段落實例，並將深度設為 3。
10. 將新段落加入 `TextFrame` 的段落集合中。
11. 儲存已修改的簡報。

```c#
// 實例化一個代表 PPTX 檔案的 Presentation 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide slide = pres.Slides[0];
    
    // 新增並取得自動形狀
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得已建立自動形狀的文字框
    ITextFrame text = aShp.AddTextFrame("");
    
    // 清除預設段落
    text.Paragraphs.Clear();

    // 新增第一段落
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 設定項目符號層級
    para1.ParagraphFormat.Depth = 0;

    // 新增第二段落
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 設定項目符號層級
    para2.ParagraphFormat.Depth = 1;

    // 新增第三段落
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 設定項目符號層級
    para3.ParagraphFormat.Depth = 2;

    // 新增第四段落
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 設定項目符號層級
    para4.ParagraphFormat.Depth = 3;

    // 將段落加入集合
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // 將簡報寫入為 PPTX 檔案
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **管理具有自訂編號清單的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/) 介面提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith) 屬性等，讓您能管理具有自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 取得包含該段落的投影片。
3. 在投影片上新增一個 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
4. 取得自動形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibulletformat/numberedbulletstartwith) 設為 2。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合中。
10. 儲存已修改的簡報。

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 取得已建立自動形狀的文字框
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

## **設定段落的首行縮排**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 屬性來控制段落的首行縮排。此屬性僅會移動第一行相對於段落左邊界的距離。正值會將第一行向右移動，其他行則保持與段落本文對齊。

若需移動整個段落，請使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/)；若只需移動第一行，請使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/)。

以下範例建立多個段落，並套用不同的 `Indent` 值，以示範首行縮排如何影響段落版面配置。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。
4. 為形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

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

![段落的首行縮排](first_line_indent.png)

## **設定段落的懸掛縮排**

懸掛縮排是一種段落排版方式，第一行相對於其餘行向左縮排。於 Aspose.Slides 中，可使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 屬性來實作此效果。將 `Indent` 設為負值，即可使第一行相對於段落正文向左移動。

實務上，[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/) 定義段落本文的左側位置，而 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 定義第一行相對於該邊界的位置。若要建立懸掛縮排，請將正值的 `MarginLeft` 與負值的 `Indent` 同時設定。

此格式常用於書目、參考文獻、詞彙表等段落，讓換行的文字在段落正文下方對齊，而非在第一行的第一個字元下方。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。
4. 為形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 並移除預設段落。
5. 為每個段落設定正值的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginleft/)。
6. 設定負值的 [Indent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/indent/) 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

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
1. 取得包含該段落的投影片的參照（依其位置）。
1. 在投影片上新增一個矩形 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。
1. 為矩形新增一個含兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。
1. 為段落設定 `FontHeight` 與字型類型。
1. 為段落設定結尾屬性。
1. 將已修改的簡報寫入為 PPTX 檔案。

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

Aspose.Slides 提供加強的 HTML 文字匯入支援，可將 HTML 內容匯入段落中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片上新增一個 [自動形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。
4. 為 `自動形狀` 取得 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的預設段落。
6. 使用 TextReader 讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphcollection/)。
9. 儲存已修改的簡報。

```c#
// 建立空的簡報實例
using (Presentation pres = new Presentation())
{
    // 存取簡報的預設第一張投影片
    ISlide slide = pres.Slides[0];

    // 加入自動形狀以容納 HTML 內容
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 為形狀新增文字框
    ashape.AddTextFrame("");

    // 清除已加入文字框中的所有段落
    ashape.TextFrame.Paragraphs.Clear();

    // 使用串流讀取器載入 HTML 檔案
    TextReader tr = new StreamReader("file.html");

    // 將 HTML 串流讀取器的文字加入文字框
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // 儲存簡報
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的文字（段落）匯出為 HTML 的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入目標簡報。
2. 透過索引取得相關投影片的參照。
3. 取得包含欲匯出為 HTML 文字的形狀。
4. 取得該形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例並新增 HTML 檔案。
6. 為 StreamWriter 提供起始索引，並匯出您選取的段落。

```c#
// 載入簡報檔案
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // 存取簡報的預設第一張投影片
    ISlide slide = pres.Slides[0];

    // 取得所需的索引
    int index = 0;

    // 存取已加入的形狀
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 依據指定的段落起始索引與要複製的段落數量，將段落資料寫入 HTML
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **將段落另存為圖像**

在本節中，我們將探討兩個範例，說明如何將由 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 介面表示的文字段落另存為圖像。兩個範例皆包括使用 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面的 `GetImage` 方法取得包含段落的形狀圖像、計算段落在形狀內的界限，並將其匯出為位圖圖像。這些做法允許您從 PowerPoint 簡報中提取特定文字部份，並以獨立圖像儲存，於各種情境中進一步使用。

假設我們有一個名為 sample.pptx 的簡報檔案，內含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**Example 1**

在此範例中，我們將第二個段落取得為圖像。為此，我們先從簡報的第一張投影片取得形狀圖像，然後計算第二個段落在形狀文字框中的界限。接著將段落重新繪製到新的位圖圖像中，並以 PNG 格式儲存。此方法特別適用於需要將特定段落另存為單獨圖像，同時保留文字的精確尺寸與格式的情況。

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// 在記憶體中將形狀儲存為位圖。
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// 從記憶體建立形狀位圖。
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 計算第二段的邊界。
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// 計算輸出圖像的大小（最小尺寸為 1x1 像素）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 為段落準備位圖。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// 將段落從形狀位圖重新繪製至段落位圖。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

![段落圖像](paragraph_to_image_output.png)

**Example 2**

在此範例中，我們在前一個方法的基礎上加入了縮放因子。形狀以縮放因子 `2` 取得圖像，這可在匯出段落時產生較高解析度的輸出。段落界限則會依縮放比例重新計算。當需要更高解析度的圖像（例如用於高品質印刷材料）時，縮放尤為有用。

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

可以。使用文字框的換行設定（[WrapText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/wraptext/)）將換行關閉，這樣行就不會在框架邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至是單一部分）的外框矩形，以了解其在投影片上的精確位置與尺寸。

**段落對齊方式（左、右、置中、兩端對齊）在哪裡設定？**

[Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphformat/alignment/) 為段落層級的設定，屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphformat/)；它會套用於整段文字，與單獨部分的格式無關。

**我可以只為段落的一部分（例如單字）設定拼寫檢查語言嗎？**

可以。語言設定在部分層級（[PortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/)），因此同一段落中可以同時存在多種語言。