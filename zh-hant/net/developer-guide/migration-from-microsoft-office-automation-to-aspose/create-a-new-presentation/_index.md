---
title: 使用 VSTO 與 Aspose.Slides for .NET 建立新簡報
linktitle: 建立新簡報
type: docs
weight: 10
url: /zh-hant/net/create-a-new-presentation/
keywords:
- 建立簡報
- 新簡報
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "從 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並使用乾淨、可靠的 C# 程式碼建立新的 PowerPoint (PPT, PPTX) 簡報。"
---
{{% alert color="info" %}} 
VSTO 的開發目的是讓開發人員建立可以在 Microsoft Office 中執行的應用程式。VSTO 基於 COM，但被封裝在 .NET 物件中，以便在 .NET 應用程式中使用。VSTO 需要 .NET 框架支援以及 Microsoft Office 基於 CLR 的執行階段。雖然它可用於製作 Microsoft Office 加載項，但幾乎不可能作為伺服器端元件使用。它也存在嚴重的部署問題。

Aspose.Slides for .NET 是一個可用來操作 Microsoft PowerPoint 簡報的元件，功能與 VSTO 類似，但具有以下幾項優勢：

- Aspose.Slides 只包含受管理的程式碼，且不需要安裝 Microsoft Office 執行階段。
- 它可以作為客戶端元件或伺服器端元件使用。
- 部署容易，因為 Aspose.Slides 僅包含於單一 DLL 中。

{{% /alert %}} 
## **建立簡報**
下面有兩個程式碼範例說明如何使用 VSTO 與 Aspose.Slides for .NET 來達成相同的目標。第一個範例是 [VSTO](/slides/zh-hant/net/create-a-new-presentation/);[第二個範例](/slides/zh-hant/net/create-a-new-presentation/) 使用 Aspose.Slides。
### **VSTO 範例**
**VSTO 輸出** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//注意：PowerPoint 是先前定義的命名空間，如下所示
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//建立簡報
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//取得標題投影片佈局
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


### **Aspose.Slides for .NET 範例**
**Aspose.Slides 的輸出** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//建立簡報
Presentation pres = new Presentation();

//新增標題投影片
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//設定標題文字
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//設定副標題文字
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//將輸出寫入磁碟
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```