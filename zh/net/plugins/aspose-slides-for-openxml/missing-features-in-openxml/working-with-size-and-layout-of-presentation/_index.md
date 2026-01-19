---
title: 使用演示文稿的大小和布局
type: docs
weight: 90
url: /zh/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** 和 **SlideSize.Size** 是演示文稿类的属性，可如下示例所示进行设置或获取。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instantiate a Presentation object that represents a presentation file 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set the slide size of generated presentations to that of source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下载运行示例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

欲了解更多详情，请访问 [更改 .NET 中的演示文稿幻灯片大小](/slides/zh/net/slide-size/)。

{{% /alert %}}