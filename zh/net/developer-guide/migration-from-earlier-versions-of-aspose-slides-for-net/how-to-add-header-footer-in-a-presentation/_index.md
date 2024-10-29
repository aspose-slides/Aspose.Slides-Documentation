---
title: 如何在演示文稿中添加页眉和页脚
type: docs
weight: 20
url: /zh/net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

一个新的 [Aspose.Slides for .NET API](/slides/zh/net/) 已经发布，现在这个单一产品支持从头生成 PowerPoint 文档和编辑现有文档的功能。

{{% /alert %}} 
## **对旧代码的支持**
为了使用使用 Aspose.Slides for .NET 13.x 之前版本开发的旧代码，您需要对代码进行一些小的更改，代码将如之前一样工作。以前在 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下的所有类现在已合并到单个 Aspose.Slides 命名空间中。请查看以下简单代码片段，以了解如何在旧版 Aspose.Slides API 中添加演示文稿的页眉和页脚，并按照描述如何迁移到新的合并 API 的步骤进行操作。
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

//显示幻灯片编号
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//在标题幻灯片上设置页眉页脚可见性
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//将演示文稿写入磁盘
sourcePres.Write("NewSource.pptx");
```

```c#
//创建演示文稿
Presentation pres = new Presentation();

//获取第一张幻灯片
Slide sld = pres.GetSlideByPosition(1);

//访问幻灯片的页眉/页脚
HeaderFooter hf = sld.HeaderFooter;

//设置页码可见性
hf.PageNumberVisible = true;

//设置页脚可见性
hf.FooterVisible = true;

//设置页眉可见性
hf.HeaderVisible = true;

//设置日期时间可见性
hf.DateTimeVisible = true;

//设置日期时间格式
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//设置页眉文本
hf.HeaderText = "页眉文本";

//设置页脚文本
hf.FooterText = "页脚文本";

//将演示文稿写入磁盘
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
    
    //在所有标题幻灯片上设置页眉页脚可见性
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //将演示文稿写入磁盘
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```