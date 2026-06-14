---
title: 如何在 .NET 中為簡報加入頁首與頁尾
linktitle: 加入頁首與頁尾
type: docs
weight: 20
url: /zh-hant/net/how-to-add-header-footer-in-a-presentation/
keywords:
- 遷移
- 新增頁首
- 新增頁尾
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中使用舊版與新版 Aspose.Slides API，於 PowerPoint PPT、PPTX 與 ODP 簡報中加入頁首與頁尾。"
---
{{% alert color="primary" %}} 
已發布全新的 [Aspose.Slides for .NET API](/slides/zh-hant/net/)，現在此單一產品支援從頭生成 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}} 
## **支援舊版程式碼**
為了使用 Aspose.Slides for .NET 13.x 之前版本開發的舊版程式碼，您需要對程式碼做少量修改，程式碼即可如同以前般運作。舊版 Aspose.Slides for .NET 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別，現在已合併至單一的 Aspose.Slides 命名空間。請查看以下用於在簡報中加入頁首頁腳的簡單程式碼片段（使用舊版 Aspose.Slides API），並依照說明步驟將其遷移至新合併的 API。
## **舊版 Aspose.Slides for .NET 方法**
```c#
PresentationEx sourcePres = new PresentationEx();

//設定頁首與頁尾的可見性屬性
sourcePres.UpdateSlideNumberFields = true;

//更新日期時間欄位
sourcePres.UpdateDateTimeFields = true;

//顯示日期時間佔位符
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//顯示頁尾佔位符
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//顯示投影片編號
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//設定標題投影片的頁首與頁尾可見性
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//將簡報寫入磁碟
sourcePres.Write("NewSource.pptx");
```

```c#
//建立簡報
Presentation pres = new Presentation();

//取得第一張投影片
Slide sld = pres.GetSlideByPosition(1);

//存取投影片的頁首 / 頁尾
HeaderFooter hf = sld.HeaderFooter;

//設定頁碼可見性
hf.PageNumberVisible = true;

//設定頁尾可見性
hf.FooterVisible = true;

//設定頁首可見性
hf.HeaderVisible = true;

//設定日期時間可見性
hf.DateTimeVisible = true;

//設定日期時間格式
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//設定頁首文字
hf.HeaderText = "Header Text";

//設定頁尾文字
hf.FooterText = "Footer Text";

//將簡報寫入磁碟
pres.Write("HeadFoot.ppt");
```

## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //設定頁首與頁尾的可見性屬性
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //更新日期時間欄位
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //顯示日期時間佔位符
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //顯示頁尾佔位符
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //設定標題投影片的頁首與頁尾可見性
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //將簡報寫入磁碟
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```