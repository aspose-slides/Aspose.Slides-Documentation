---
title: 在 .NET 中向演示文稿添加页眉和页脚的指南
linktitle: 添加页眉和页脚
type: docs
weight: 20
url: /zh/net/how-to-add-header-footer-in-a-presentation/
keywords:
- 迁移
- 添加页眉
- 添加页脚
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中使用旧版和新版 Aspose.Slides API 为 PowerPoint PPT、PPTX 和 ODP 演示文稿添加页眉和页脚。"
---

{{% alert color="primary" %}} 

全新 [Aspose.Slides for .NET API](/slides/zh/net/) 已发布，现在该产品支持从头生成 PowerPoint 文档以及编辑现有文档的功能。

{{% /alert %}} 
## **支持旧版代码**
为了使用 Aspose.Slides for .NET 13.x 之前版本开发的旧版代码，您需要对代码进行少量修改，代码即可像以前一样工作。旧版 Aspose.Slides for .NET 中位于 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间的所有类现已合并到单一的 Aspose.Slides 命名空间。请查看以下在旧版 Aspose.Slides API 中为演示文稿添加页眉页脚的简单代码片段，并按照步骤了解如何迁移到新的合并 API。

## **旧版 Aspose.Slides for .NET 方法**
```c#
PresentationEx sourcePres = new PresentationEx();

//设置页眉页脚可见性属性
sourcePres.UpdateSlideNumberFields = true;

//更新日期时间字段
sourcePres.UpdateDateTimeFields = true;

//显示日期时间占位符
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//显示页脚占位符
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//显示幻灯片页码
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//在标题幻灯片上设置页眉页脚可见性
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//将演示文稿写入磁盘
sourcePres.Write("NewSource.pptx");
```

```c#
//创建演示文稿
Presentation pres = new Presentation();

//Get first slide
Slide sld = pres.GetSlideByPosition(1);

//Access the Header / Footer of the slide
HeaderFooter hf = sld.HeaderFooter;

//Set Page Number Visibility
hf.PageNumberVisible = true;

//Set Footer Visibility
hf.FooterVisible = true;

//Set Header Visibility
hf.HeaderVisible = true;

//Set Date Time Visibility
hf.DateTimeVisible = true;

//Set Date Time format
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Set Header Text
hf.HeaderText = "Header Text";

//Set Footer Text
hf.FooterText = "Footer Text";

//Write the presentation to the disk
pres.Write("HeadFoot.ppt");
```




## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //设置页眉页脚可见性属性
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //更新日期时间字段
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //显示日期时间占位符
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //显示页脚占位符
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //在标题幻灯片上设置页眉页脚可见性
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //将演示文稿写入磁盘
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
