---
title: 在 .NET 中管理簡報占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh-hant/net/manage-placeholder/
keywords:
- 占位符
- 文字占位符
- 圖像占位符
- 圖表占位符
- 提示文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "輕鬆在 Aspose.Slides for .NET 中管理占位符：取代文字、客製化提示與設定 PowerPoint 與 OpenDocument 中圖片的透明度。"
---
## **概觀**

Aspose.Slides 允許您以程式方式管理簡報中的版位占位符。本文說明如何在投影片上尋找版位占位符並變更其文字、為版位占位符佈局設定自訂提示文字，以及調整用作版位占位符背景的圖片的透明度。文章還提供簡短的 FAQ，說明基礎版位占位符與投影片本機圖形的差異、如何透過佈局或母片套用版位占位符變更，並指向頁眉與頁腳版位占位符的管理方式。

## **變更版位占位符中的文字**
使用 [Aspose.Slides for .NET](/slides/zh-hant/net/)，您可以在簡報的投影片上找到並修改版位占位符。Aspose.Slides 允許您變更版位占位符內的文字。

**先決條件**：您需要一個包含版位占位符的簡報。您可以在標準的 Microsoft PowerPoint 應用程式中建立此類簡報。

以下說明如何使用 Aspose.Slides 取代該簡報中版位占位符的文字：

1. 建立 [`Presentation`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，並將簡報作為參數傳入。
2. 透過索引取得投影片參考。
3. 逐一迭代圖形以尋找版位占位符。
4. 將版位占位符圖形型別轉換為 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)，並使用與該 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/) 相關聯的 [`TextFrame`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 變更文字。
5. 保存已修改的簡報。

以下 C# 程式碼示範如何變更版位占位符中的文字：

```c#
// 建立一個 Presentation 類別的實例
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 存取第一張投影片
    ISlide sld = pres.Slides[0];

    // 遍歷圖形以尋找占位符
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 變更每個占位符的文字
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // 將簡報儲存至磁碟
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **在版位占位符中設定提示文字**
標準和預建佈局包含如 ***Click to add a title*** 或 ***Click to add a subtitle*** 的版位占位符提示文字。使用 Aspose.Slides，您可以將自訂的提示文字插入版位占位符佈局。

以下 C# 程式碼示範如何在版位占位符中設定提示文字：

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // 遍歷投影片
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint 顯示「按一下新增標題」
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // 新增副標題
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **設定版位占位符圖片的透明度**

Aspose.Slides 允許您設定文字版位占位符背景圖片的透明度。透過調整此框架內圖片的透明度，您可以讓文字或圖片更突出（取決於文字與圖片的顏色）。

以下 C# 程式碼示範如何為圖片背景（位於圖形內）設定透明度：

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**什麼是基礎版位占位符，它與投影片上的本機圖形有何不同？**

基礎版位占位符是佈局或母片上原始的圖形，投影片的圖形會從它繼承類型、位置以及部分格式設定。本機圖形則是獨立的；若沒有基礎版位占位符，則不會發生繼承。

**如何在不逐一遍歷每張投影片的情況下，更新整個簡報中的所有標題或說明文字？**

編輯佈局或母片上的相應版位占位符。基於那些佈局或母片的投影片將自動繼承此變更。

**我要如何控制標準的頁眉/頁腳版位占位符——日期與時間、投影片編號以及頁腳文字？**

在適當的範圍（普通投影片、佈局、母片、備註/講義）使用 HeaderFooter 管理器，開啟或關閉這些版位占位符，並設定其內容。