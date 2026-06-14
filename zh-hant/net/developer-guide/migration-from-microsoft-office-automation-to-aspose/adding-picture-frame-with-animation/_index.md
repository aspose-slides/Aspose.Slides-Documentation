---
title: 使用 VSTO 與 Aspose.Slides for .NET 為圖片框添加動畫
linktitle: 帶動畫的圖片框
type: docs
weight: 60
url: /zh-hant/net/adding-picture-frame-with-animation/
keywords:
- 圖片框
- 新增影像
- 新增圖片
- 動畫影像
- 動畫圖片
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "從 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並使用簡潔的 C# 程式碼在 PowerPoint（PPT、PPTX）投影片中為圖片框添加動畫。"
---
{{% alert color="primary" %}} 
圖片框架可套用於 Microsoft PowerPoint 中的形狀或影像，以在投影片中為影像加框。本篇文章說明如何以程式方式先使用 [VSTO 2008](/slides/zh-hant/net/adding-picture-frame-with-animation/) 再使用 [Aspose.Slides for .NET](/slides/zh-hant/net/adding-picture-frame-with-animation/) 來建立圖片框並套用動畫。首先，我們示範如何使用 VSTO 2008 套用框架與動畫。接著，我們示範如何使用 Aspose.Slides for .NET 執行相同的步驟。
{{% /alert %}} 
## **新增圖片框架與動畫**
以下程式範例會建立一個包含投影片的簡報，加入帶有圖片框的影像，並對其套用動畫。
### **VSTO 2008 範例**
使用 VSTO 2008，請遵循以下步驟：

1. 建立簡報。
1. 新增一張空白投影片。
1. 在投影片中加入圖片形狀。
1. 對圖片套用動畫。
1. 將簡報寫入磁碟。

**使用 VSTO 建立的輸出簡報** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//建立空白簡報
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//新增圖片框
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//對圖片框套用動畫
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//儲存簡報
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET 範例**
使用 Aspose.Slides for .NET，請執行以下步驟：

1. 建立簡報。
1. 存取第一張投影片。
1. 將影像新增至圖片集合。
1. 在投影片中加入圖片形狀。
1. 對圖片套用動畫。
1. 將簡報寫入磁碟。

**使用 Aspose.Slides 建立的輸出簡報** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// 建立空白簡報
using (Presentation pres = new Presentation())
{
    // 存取第一張投影片
    ISlide slide = pres.Slides[0];

    // 將影像加入簡報的影像集合
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 新增一個高度與寬度與影像相同的圖片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 取得投影片的主要動畫序列
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 為圖片框加入「從左側飛入」動畫效果
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 儲存簡報
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```