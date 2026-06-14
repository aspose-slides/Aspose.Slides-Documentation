---
title: 使用 VSTO 和 Aspose.Slides for .NET 建立新簡報
linktitle: 建立新簡報
type: docs
weight: 10
url: /zh-hant/net/create-a-new-presentation/
keywords:
- 建立簡報
- 新簡報
- 移轉
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "將 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並使用 C# 以乾淨且可靠的程式碼建立新的 PowerPoint (PPT, PPTX) 簡報。"
---
{{% alert color="primary" %}} 

VSTO 是為了讓開發人員能夠建立可在 Microsoft Office 內執行的應用程式而開發的。VSTO 基於 COM，但它被封裝在 .NET 物件中，因而可以在 .NET 應用程式中使用。VSTO 需要 .NET framework 支援以及 Microsoft Office 基於 CLR 的執行環境。雖然它可以用來製作 Microsoft Office 外掛程式，但幾乎不可能用作伺服器端元件。它也存在嚴重的部署問題。

Aspose.Slides for .NET 是一個可用於操作 Microsoft PowerPoint 簡報的元件，就像 VSTO 一樣，但它有多項優勢：

- Aspose.Slides 僅包含受控程式碼，且不需要安裝 Microsoft Office 執行時。
- 它可作為客戶端元件或伺服器端元件使用。
- 部署很簡單，因為 Aspose.Slides 包含在單一個 DLL 中。

{{% /alert %}} 
## **Creating a Presentation**
以下兩個程式碼範例說明如何使用 VSTO 與 Aspose.Slides for .NET 來達成相同的目標。第一個範例是 [VSTO](/slides/zh-hant/net/create-a-new-presentation/)，[第二個範例](/slides/zh-hant/net/create-a-new-presentation/) 使用 Aspose.Slides。
### **VSTO Example**
**The VSTO output** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//注意：PowerPoint 是在上方這樣定義的命名空間
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//建立簡報
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//取得標題投影片版面配置
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//新增標題投影片。
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//設定標題文字
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//設定副標題文字
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//將輸出寫入磁碟
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Example**
**The output from Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//建立簡報
Presentation pres = new Presentation();

//新增標題投影片
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//設定標題文字
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//設定副標題文字
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//將輸出寫入磁碟
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```