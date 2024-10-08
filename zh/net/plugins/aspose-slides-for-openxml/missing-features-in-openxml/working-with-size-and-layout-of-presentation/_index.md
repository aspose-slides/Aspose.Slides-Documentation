---
title: 处理演示文稿的大小和布局
type: docs
weight: 90
url: /net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** 和 **SlideSize.Size** 是演示文稿类的属性，可以像下面的示例一样设置或获取。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "处理大小和布局.pptx";

//实例化一个表示演示文稿文件的 Presentation 对象

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//将生成的演示文稿的幻灯片大小设置为源文件的大小

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//将演示文稿保存到磁盘

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **下载运行示例**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [处理幻灯片大小和布局](/slides/net/adding-and-editing-slides/#working-with-slide-size-and-layout)。

{{% /alert %}}